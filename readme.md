# <img src="/src/icon.png" height="30px"> Verify.DocNet

[![Build status](https://ci.appveyor.com/api/projects/status/41y3vomprwgnsheq?svg=true)](https://ci.appveyor.com/project/SimonCropp/Verify-DocNet)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.DocNet.svg)](https://www.nuget.org/packages/Verify.DocNet/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow verification of documents via [DocNet](https://github.com/GowenGit/docnet).

Converts pdf documents to png for verification.

This library uses [SixLabors ImageSharp](https://github.com/SixLabors/ImageSharp) for png generation. For commercial application support visit [SixLabors/Pricing](https://sixlabors.com/pricing/).



## NuGet package

https://nuget.org/packages/Verify.DocNet/


## Usage


### Enable Verify.DocNet

<!-- snippet: enable -->
<a id='snippet-enable'></a>
```cs
[ModuleInitializer]
public static void Initialize()
{
    VerifyDocNet.Initialize();
    VerifyImageMagick.RegisterComparers(
        threshold: 0.13,
        ImageMagick.ErrorMetric.PerceptualHash);
```
<sup><a href='/src/Tests/ModuleInitializer.cs#L3-L13' title='Snippet source file'>snippet source</a> | <a href='#snippet-enable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

`VerifyImageMagick.RegisterComparers` (provided by https://github.com/VerifyTests/Verify.ImageMagick) allows minor image changes to be ignored.


### Verify a file

<!-- snippet: VerifyPdf -->
<a id='snippet-verifypdf'></a>
```cs
[Test]
public Task VerifyPdf() =>
    VerifyFile("sample.pdf");
```
<sup><a href='/src/Tests/Samples.cs#L4-L10' title='Snippet source file'>snippet source</a> | <a href='#snippet-verifypdf' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Verify a Stream

<!-- snippet: VerifyPdfStream -->
<a id='snippet-verifypdfstream'></a>
```cs
[Test]
public Task VerifyPdfStream()
{
    var stream = new MemoryStream(File.ReadAllBytes("sample.pdf"));
    return Verify(stream, "pdf");
}
```
<sup><a href='/src/Tests/Samples.cs#L30-L39' title='Snippet source file'>snippet source</a> | <a href='#snippet-verifypdfstream' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Result

[Samples.VerifyPdf.01.verified.png](/src/Tests/Samples.VerifyPdf.00.verified.png):

<img src="/src/Tests/Samples.VerifyPdf.00.verified.png" width="200px">


## PreserveTransparency

<!-- snippet: PreserveTransparency -->
<a id='snippet-preservetransparency'></a>
```cs
[Test]
public Task VerifyPreserveTransparency() =>
    VerifyFile("sample.pdf")
        .PreserveTransparency();
```
<sup><a href='/src/Tests/Samples.cs#L12-L19' title='Snippet source file'>snippet source</a> | <a href='#snippet-preservetransparency' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## PageDimensions

<!-- snippet: PageDimensions -->
<a id='snippet-pagedimensions'></a>
```cs
[Test]
public Task VerifyPageDimensions() =>
    VerifyFile("sample.pdf")
        .PageDimensions(new(1080, 1920));
```
<sup><a href='/src/Tests/Samples.cs#L21-L28' title='Snippet source file'>snippet source</a> | <a href='#snippet-pagedimensions' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

## VerifySinglePage

<!-- snippet: VerifySinglePage -->
<a id='snippet-verifysinglepage'></a>
```cs
[Test]
public Task VerifyFirstPage()
{
    var stream = new MemoryStream(File.ReadAllBytes("sample.pdf"));
    return Verify(stream, "pdf").SinglePage(0);
}

[Test]
public Task VerifySecondPage()
{
    var stream = new MemoryStream(File.ReadAllBytes("sample.pdf"));
    return Verify(stream, "pdf").SinglePage(1);
}
```
<sup><a href='/src/Tests/Samples.cs#L41-L57' title='Snippet source file'>snippet source</a> | <a href='#snippet-verifysinglepage' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

## File Samples

http://file-examples.com/


## Icon

[Pdf](https://thenounproject.com/term/pdf/533502/) designed by [Alfredo](https://thenounproject.com/AlfredoCreates) from [The Noun Project](https://thenounproject.com/).
