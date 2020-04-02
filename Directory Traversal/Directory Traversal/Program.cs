using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var filesDict = new Dictionary<string, Dictionary<string, long>>();

            var directory = new DirectoryInfo(Environment.CurrentDirectory);

            var decstopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var files = directory.GetFiles();

            foreach (var file in files)
            {
                var ext = file.Extension;

                if (!filesDict.ContainsKey(ext))
                {
                    filesDict[ext] = new Dictionary<string, long>();
                }
                filesDict[ext][file.Name] = file.Length;
            }

            var sortedByExtension = filesDict
                .OrderByDescending(e => e.Value.Count)
                .ThenBy(e => e.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            using (var writer = new StreamWriter(decstopPath))
            {
                foreach (var extension in sortedByExtension)
                {
                    writer.WriteLine(extension.Key);

                    var currentFile = extension.Value
                        .OrderBy(f => f.Value)
                        .ToDictionary(k => k.Key, v => v.Value);

                    foreach (var file in currentFile)
                    {
                        writer.WriteLine($"--{file.Key} - {(file.Value / 1000.0):F3}kb");
                    }
                }
            }
        }
    }
}
