﻿using Services.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace De.HsFlensburg.ClientApp012.Services.Serialization
{
    public class ResourceSerializer
    {
        public static String SaveFile(string sourcePath, string destinationPath)
        {
            if (File.Exists(BinarySerializer.PERSISTENT_DATA_PATH + destinationPath))
                File.Delete(BinarySerializer.PERSISTENT_DATA_PATH + destinationPath);
            if (!Directory.Exists(BinarySerializer.PERSISTENT_DATA_PATH + destinationPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(BinarySerializer.PERSISTENT_DATA_PATH + destinationPath));
            }

            File.Copy(sourcePath, BinarySerializer.PERSISTENT_DATA_PATH + destinationPath);
            return destinationPath;
        }

        public static String LoadImagePath()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg; *.png) | *.jpg; *.png"
            };
            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }
            else
            {
                return null;
            }
        }

        public static void DeleteDirectory(string destination)
        {
            if (Directory.Exists(BinarySerializer.PERSISTENT_DATA_PATH + destination))
            {
                Directory.Delete(BinarySerializer.PERSISTENT_DATA_PATH + destination, true);
            }
        }

        public static String LoadVideoPath()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Video Files (*.mp4; *.mpeg; *.mov; *.mkv; *.m4v) | *.mp4; *.mpeg; *.mov; *.mkv; *.m4v"
            };
            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }
            else
            {
                return null;
            }
        }

        public static String LoadAudioPath()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Audio Files (*.mp3; *.wav)| *.mp3; *.wav"
            };
            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }
            else
            {
                return null;
            }
        }



    }
}

