using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
        string GetLocalPath();

    }
}
