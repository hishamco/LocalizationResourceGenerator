using Microsoft.DotNet.Cli.CommandLine;
using Microsoft.Extensions.Logging;
using TranslatorService;
using System.IO;
using System.Xml.Linq;
using static TranslatorService.LanguageServiceClient;

namespace LocalizationResourceGenerator
{
    public class Program
    {
        private static ILoggerFactory _loggerFactory = new LoggerFactory();
        private static ILogger _logger;
        private static readonly string _appKey = "6CE9C85A41571C050C379F60DA173D286384E0F2";
        private static readonly string _defaultCulture = "en";
        private static readonly LanguageServiceClient client = new LanguageServiceClient(EndpointConfiguration.BasicHttpBinding_LanguageService);

        public static void Main(string[] args)
        {
            var app = new CommandLineApplication();

            app.Name = "dotnet resgen";
            app.FullName = "Resource Generator";
            app.Description = "Generates and translates a localization resource file(s)";
            app.HandleResponseFiles = true;
            app.HelpOption("-h|--help");

            var culturesCommand = app.Argument("cultures", "List of cultures, that the 'dotnet-resgen' command will generate a resource file(s) for each one for them.", true);
            var defaultCultureOption = app.Option("--default <CULTURE>", "The default culture that the 'dotnet-resgen' command will use it to translate from", CommandOptionType.SingleValue);

            _loggerFactory.AddConsole();
            _logger = _loggerFactory.CreateLogger(nameof(Program));

            app.OnExecute(async () =>
            {
                const string resourceExtension = ".resx";
                var defaultCulture = defaultCultureOption.Value() ?? _defaultCulture;
                var cultures = culturesCommand.Values;
                var currentDirectory = Directory.GetCurrentDirectory();

                if (culturesCommand.Values.Count == 0)
                {
                    _logger.LogError("The argument named 'cultures' is required in order to generate the resource files.");
                    return 1;
                }

                foreach (var filePath in Directory.GetFiles(currentDirectory, "*" + resourceExtension))
                {
                    var file = new FileInfo(filePath);

                    if (!Path.GetFileNameWithoutExtension(file.Name).Contains("."))
                    {
                        foreach (var culture in cultures)
                        {
                            var resourceFileName = string.Join(".", Path.GetFileNameWithoutExtension(file.Name), culture, resourceExtension);
                            var resourcePath = Path.Combine(currentDirectory, resourceFileName);

                            File.Copy(file.FullName, resourcePath, true);
                            var doc = XDocument.Load(resourcePath);

                            foreach (var element in doc.Root.Elements("data"))
                            {
                                var key = element.Element("value").Value;
                                var result = await client.TranslateAsync(_appKey, key.ToString(), defaultCulture, culture);

                                element.SetElementValue("value", result);
                            }

                            using (var stream = new FileStream(resourcePath, FileMode.Open, FileAccess.Write))
                            {
                                doc.Save(stream);
                            }
                        }
                    }
                }

                return 0;
            });

            app.Execute(args);
        }
    }
}
