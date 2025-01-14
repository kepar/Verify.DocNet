using Docnet.Core;
using Docnet.Core.Converters;
using Docnet.Core.Readers;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace VerifyTests;

public static partial class VerifyDocNet
{
    static ConversionResult Convert(Stream stream, IReadOnlyDictionary<string, object> settings)
    {
        var pageDimensions = settings.GetPageDimensions(new(scalingFactor: 2));
        using var reader = DocLib.Instance.GetDocReader(stream.ToBytes(), pageDimensions);

        return Convert(reader, settings);
    }

    static ConversionResult Convert(IDocReader document, IReadOnlyDictionary<string, object> settings)
    {
        var targets = GetStreams(document, settings).ToList();
        return new(null, targets);
    }

    static NaiveTransparencyRemover transparencyRemover = new();

    static IEnumerable<Target> GetStreams(IDocReader document, IReadOnlyDictionary<string, object> settings)
    {
        var numberOfPages = document.GetPageCount();
        var pagesToInclude = settings.GetPagesToInclude(numberOfPages);

        var start = 0;
        var singlePage = settings.GetSinglePage();
        if (singlePage != -1)
        {
            if (singlePage >= numberOfPages)
            {
                throw new ArgumentOutOfRangeException("singlePage", singlePage, $"Cannot Verify Page {singlePage} (0-based index) document containts only {numberOfPages} Page(s).");
            }

            start = singlePage;
            pagesToInclude = singlePage + 1;
        }

        var preserveTransparency = settings.GetPreserveTransparency();
        for (var index = start; index < pagesToInclude; index++)
        {
            using var reader = document.GetPageReader(index);

            var rawBytes = preserveTransparency ? reader.GetImage() : reader.GetImage(transparencyRemover);

            var width = reader.GetPageWidth();
            var height = reader.GetPageHeight();

            var image = Image.LoadPixelData<Bgra32>(rawBytes, width, height);

            var stream = new MemoryStream();
            image.SaveAsPng(stream);
            yield return new("png", stream);
        }
    }
}