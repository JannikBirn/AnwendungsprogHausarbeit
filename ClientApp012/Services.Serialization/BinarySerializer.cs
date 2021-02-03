using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Services.Serialization
{
    public class BinarySerializer
    {
        public static string PERSISTENT_DATA_PATH = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static void BinarySerialize(object data, string filePath)
        {
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath))
                File.Delete(filePath);

            if (!Directory.Exists(filePath))
            {
                //Creates the directory if it dosnt exist
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }

            fileStream = File.Create(filePath);
            bf.Serialize(fileStream, data);
            fileStream.Close();
        }

        public static object BinaryDeserialize(string filePath)
        {
            object obj = null;

            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();

            if (File.Exists(filePath))
            {
                fileStream = File.OpenRead(filePath);
                obj = bf.Deserialize(fileStream);
                fileStream.Close();
            }

            return obj;
        }
    }
}
