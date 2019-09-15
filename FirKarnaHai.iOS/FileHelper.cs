using System;
using System.IO;
using FirKarnaHai.iOS;
using FirKarnaHai.Persistence;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace FirKarnaHai.iOS
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docfolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docfolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}