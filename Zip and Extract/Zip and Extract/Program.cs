using System;
using System.IO;
using System.IO.Compression;

namespace Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            var startPath = "../../../copyMe";
            var zipPath = "../../../ziped.zip";
            var extractPath = Environment.CurrentDirectory;

            ZipFile.CreateFromDirectory(startPath, zipPath);

            ZipFile.ExtractToDirectory(zipPath, extractPath);

        }
    }
}
