using System;
using System.IO;
using FirKarnaHai.Droid;
using FirKarnaHai.Persistence;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace FirKarnaHai.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}