using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Services.Serialization;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class NewTopicWindowViewModel
    {
        public Image TopicImage = null;


        public TopicCollectionViewModel TopicCollection; 
        public String Name { get; set; }
        public String TopicImagePath { get; set; }
        public TopicCollectionViewModel TCVM { get; set; }
        public RelayCommand AddTopic { get; }
        public RelayCommand LoadTopicImage { get; }


        public NewTopicWindowViewModel(RootViewModel model)
        {
            AddTopic = new RelayCommand(() => AddTopicMethod());
            LoadTopicImage = new RelayCommand(() => LoadTopicImageMethod());
            TopicCollection = model.TopicCollection;
        }

        private void AddTopicMethod()
        {
            
            long topicId = DateTime.Now.Ticks;
            if (TopicImage != null)
            {
                TopicImagePath = Save(TopicImagePath, "TopicImage", topicId);
            }

            // Check ob Text angegeben wurde



            TopicViewModel tvm = new TopicViewModel()
            {
                Name = Name,
                Img = TopicImagePath,
            };

            TopicCollection.Add(tvm);
        }

        private void LoadTopicImageMethod()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg; *.png) | *.jpg; *.png"
            };
            if (dialog.ShowDialog() == true)
            {
                TopicImage = Image.FromFile(dialog.FileName);
                TopicImagePath = dialog.FileName;
            }
        }

        public String Save(string source, string folderName, long id)
        {
            return ResourceSerializer.SaveFile(source, $"\\{TopicCollection.Count+1}\\{Path.GetExtension(source)}");

        }
    }
}
