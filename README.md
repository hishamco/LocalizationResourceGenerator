# LocalizationResourceGenerator
Localization Resource Generator &amp; Translator CommandLine Tool for ASP.NET Core Application

### dotnet resgen

`dotnet resgen` is a localization resource (resx) generator for the .NET Core applications. Also it translates the resource entries using Microsoft Translation APIs during the generation process.

### How To Install

1. Run the following command: `dotnet publish -c Debug -r {runtime identifier}`
2. Add the binaries folder path - which is located in `LocalizationResourceGenerator\src\LocalizationResourceGenerator\bin\Debug\{netcoreapp version}\{runtime identifier}` - to the System PATH.

### How To Use

    dotnet resgen [arguments] [options]

    Arguments:
      cultures   List of cultures, that the command will generate a resource file(s) for each one for them

    Options:
      -h|--help            Show help information
      --default <CULTURE>  The default culture that the command will use it to translate from
      -t|--type <TYPE>     The type of the resource file [resx|restext]

Here is a few examples:

| Command                            | Description                                              |
| -----------------------------------| -------------------------------------------------------- |
| dotnet resgen fr                   | Generates a `fr.resx` resource file from `<resource>.resx` file with `en` as default culture |
| dotnet resgen fr es                | Generates a `fr.resx` and `es.resx` resource files from `<resource>.resx` file with `en` as default culture |
| dotnet resgen fr --default es      | Generates a `fr.resx` resource file from `<resource>.resx` file with Spanish as default culture |
| dotnet resgen fr -t restext        | Generates a `fr.resx` resource file from `<resource>.restext` file with Spanish as default culture |

There are few steps you should consider before using the `dotnet resgen` command:
- Create your default resource file **without append the culture name** in your resource directory
- Go to the resource directory using command line
- Run `dotnet resgen` command