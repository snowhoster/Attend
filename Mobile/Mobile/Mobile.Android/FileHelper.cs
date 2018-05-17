using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Mobile.Droid;
using Service;

[assembly: Xamarin.Forms.Dependency(typeof(FileHelper))]

namespace Mobile.Droid
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