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

<!-- snippet: ModuleInitializer.cs -->
<a id='snippet-ModuleInitializer.cs'></a>
```cs
public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifyDocNet.Initialize();
        VerifyImageMagick.RegisterComparers(threshold: 0.13, ImageMagick.ErrorMetric.PerceptualHash);
    }
}
```
<sup><a href='/src/Tests/ModuleInitializer.cs#L1-L9' title='Snippet source file'>snippet source</a> | <a href='#snippet-ModuleInitializer.cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

`VerifyImageMagick.RegisterComparers` (provided by https://github.com/VerifyTests/Verify.ImageMagick) allows minor image changes to be ignored.


### Verify a file

<!-- snippet: VerifyPdf -->
<a id='snippet-verifypdf'></a>
```cs
[Test]
public Task VerifyPdf()
{
    return VerifyFile("sample.pdf");
}
```
<sup><a href='/src/Tests/Samples.cs#L4-L12' title='Snippet source file'>snippet source</a> | <a href='#snippet-verifypdf' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Verify a Stream

<!-- snippet: VerifyPdfStream -->
<a id='snippet-verifypdfstream'></a>
```cs
[Test]
public Task VerifyPdfStream()
{
    return Verify(File.OpenRead("sample.pdf"))
        .UseExtension("pdf");
}
```
<sup><a href='/src/Tests/Samples.cs#L36-L45' title='Snippet source file'>snippet source</a> | <a href='#snippet-verifypdfstream' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Result

[Samples.VerifyPdf.01.verified.png](/src/Tests/Samples.VerifyPdf.00.verified.png):

<img src="/src/Tests/Samples.VerifyPdf.00.verified.png" width="200px">


## PreserveTransparency

<!-- snippet: PreserveTransparency -->
<a id='snippet-preservetransparency'></a>
```cs
[Test]
public Task VerifyPreserveTransparency()
{
    return VerifyFile("sample.pdf")
        .PreserveTransparency();
}
```
<sup><a href='/src/Tests/Samples.cs#L14-L23' title='Snippet source file'>snippet source</a> | <a href='#snippet-preservetransparency' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## PageDimensions

<!-- snippet: PageDimensions -->
<a id='snippet-pagedimensions'></a>
```cs
[Test]
public Task VerifyPageDimensions()
{
    return VerifyFile("sample.pdf")
        .PageDimensions(new(1080, 1920));
}
```
<sup><a href='/src/Tests/Samples.cs#L25-L34' title='Snippet source file'>snippet source</a> | <a href='#snippet-pagedimensions' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## File Samples

http://file-examples.com/


## Icon

[Pdf](https://thenounproject.com/term/pdf/533502/) designed by [Alfredo](https://thenounproject.com/AlfredoCreates) from [The Noun Project](https://thenounproject.com/).
