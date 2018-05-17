using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CSBC.Helper;
using FactoryPower.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(FileHelper))]

namespace FactoryPower.Droid
{
    public class FileHelper:IFileHelper
    {
        public FileHelper()
        {

        }
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }

        public string GetLocalPath()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return path;
        }
    }
}