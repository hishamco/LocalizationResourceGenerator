using System;
using System.IO;

namespace LocalizationResourceGenerator
{
    internal class ResourceFile
    {
        public ResourceFile(FileInfo file, ResourceFileType type)
        {
            File = file;
            Type = type;
        }

        public FileInfo File { get; }
        public ResourceFileType Type { get; }

        public static ResourceFile Create(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            ResourceFileType type;
            var extension = fileInfo.Extension.ToLowerInvariant();

            switch (extension)
            {
                case ".resx":
                    type = ResourceFileType.Resx;
                    break;
                case ".restext":
                    type = ResourceFileType.Restext;
                    break;
                default:
                    throw new NotSupportedException($"Unsupported resource file with extension '{extension}'.");
            }

            return new ResourceFile(fileInfo, type);
        }
    }
}
