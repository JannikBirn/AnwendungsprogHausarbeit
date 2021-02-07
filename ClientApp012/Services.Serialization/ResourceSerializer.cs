using Services.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Services.Serialization
{
    public class ResourceSerializer
    {
        public static String SaveFile(string sourcePath, string destinationPath)
        {
           
            if (File.Exists(destinationPath))
                File.Delete(destinationPath);            
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
            }

            File.Copy(sourcePath, destinationPath);
            return destinationPath;
        }
    }
}
