using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using McMaster.Extensions.CommandLineUtils;
using TranslatorService;
using static TranslatorService.LanguageServiceClient;

namespace LocalizationResourceGenerator
{
    public class Program
    {
        private static readonly string _appKey = "6CE9C85A41571C050C379F60DA173D286384E0F2";
        private static readonly string _defaultCulture = "en";
        private static readonly string _defaultResourceType = "resx";
        private static readonly LanguageServiceClient client = new LanguageServiceClient(EndpointConfiguration.BasicHttpBinding_LanguageService);

        public static int Main(string[] args)
            => CommandLineApplication.Execute<Program>("fr");

        [Argument(0, Name = "cultures", Description = "List of cultures, that command will generate a resource file(s) for each one for them")]
        [Required]
        public IList<string> Cultures { get; }

        [Option("--default <CULTURE>", LongName = "default", Description = "The default culture that the command will use it to translate from")]
        public string DefaultCulture { get; }

        [Option("-t|--type <TYPE>", ShortName ="t", LongName = "type", Description = "The type of the resource file [resx|restext]")]
        public string ResourceType { get; }

        private async Task<int> OnExecuteAsync()
        {
            const string resourceExtension = "resx";
            var defaultCulture = DefaultCulture ?? _defaultCulture;
            var resourceType = (ResourceFileType)Enum.Parse(typeof(ResourceFileType), ResourceType ?? _defaultResourceType, true);

            switch (resourceType)
            {
                case ResourceFileType.Resx:
                case ResourceFileType.Restext:
                    var currentDirectory = Directory.GetCurrentDirectory();
                    XDocument doc = null;

                    foreach (var filePath in Directory.GetFiles(currentDirectory, "*." + resourceType.ToString().ToLower()))
                    {
                        var file = new FileInfo(filePath);

                        if (!Path.GetFileNameWithoutExtension(file.Name).Contains("."))
                        {
                            foreach (var culture in Cultures)
                            {
                                var resourceFileName = string.Join(".", Path.GetFileNameWithoutExtension(file.Name), culture, resourceExtension);
                                var resourcePath = Path.Combine(currentDirectory, resourceFileName);

                                if (resourceType == ResourceFileType.Resx)
                                {
                                    File.Copy(file.FullName, resourcePath, true);
                                    doc = XDocument.Load(resourcePath);
                                }
                                else
                                {
                                    doc = ResourceTextFile.Load(file.OpenRead());
                                }

                                foreach (var element in doc.Root.Elements("data"))
                                {
                                    var key = element.Element("value").Value;
                                    var result = await client.TranslateAsync(_appKey, key.ToString(), defaultCulture, culture);

                                    element.SetElementValue("value", result);
                                }

                                using (var stream = new FileStream(resourcePath, FileMode.OpenOrCreate, FileAccess.Write))
                                {
                                    doc.Save(stream);
                                }
                            }
                        }
                    }

                    return 0;
                default:
                    throw new NotSupportedException($"Unsupported resource file with extension {resourceType}.");
            }
        }
    }
}
