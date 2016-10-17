# LocalizationResourceGenerator
Localization Resource Generator &amp; Translator CommandLine Tool for ASP.NET Core Application

### dotnet-resgen

`dotnet-resgen` is a localization resource (resx) generator for the .NET Core applications. Also it translates the resource entries using Microsoft Translation APIs during the generation process.

### How To Install

Simply add the binaries folder - which is located in `LocalizationResourceGenerator\src\LocalizationResourceGenerator\bin\Debug\netcoreapp1.0\win10-x64` - to the System PATH.

### How To Use

    dotnet resgen [arguments] [options]

    Arguments:
      cultures   List of cultures, that the 'dotnet-resgen' command will generate a resource file(s) for each one for them

    Options:
      -h|--help            Show help information
      --default <CULTURE>  The default culture that the 'dotnet-resgen' command will use it to translate from

Here is a few examples:

| Command                        | Description                                              |
| -------------------------------| -------------------------------------------------------- |
| dotnet resgen fr               | Generates a `fr.resx` resource file from English language |
| dotnet resgen fr es            | Generates a `fr.resx` and `es.resx` resource files from English language |
| dotnet resgen fr --default es  | Generates a `fr.resx` resource file from Spanish language |