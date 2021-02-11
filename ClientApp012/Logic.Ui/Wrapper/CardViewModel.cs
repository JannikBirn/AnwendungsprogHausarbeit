using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper.AbstractViewModels;
using Services.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper
{
    public class CardViewModel : ViewModelBase<Card>
    {
        public CardViewModel() : base()
        {

        }

        public CardViewModel(long id) : base()
        {
            this.Model.Id = id;
        }
        // das 'this' muss raus. Wrapper klassen dürfen nur durchreichen und keine Daten halten. s. Skript S.70
        public long ID
        {
            get
            {
                return this.Model.Id;
            }
        }
 
        public String QuestionText
        {
            get
            {
                return this.Model.QuestionText;
            }
            set
            {
                this.Model.QuestionText = value;
                OnPropertyChanged("QuestionText");
            }
        }
        public String QuestionVideo
        {
            get
            {
                return this.Model.QuestionVideo;
            }
            set
            {
                this.Model.QuestionVideo = value;
                OnPropertyChanged("QuestionVideo");
            }
        }
        public String QuestionImage
        {
            get
            {
                return this.Model.QuestionImage;
            }
            set
            {
                this.Model.QuestionImage = value;
                OnPropertyChanged("QuestionImage");
            }
        }
        public String QuestionAudio
        {
            get
            {
                return this.Model.QuestionAudio;
            }
            set
            {
                this.Model.QuestionAudio = value;
                OnPropertyChanged("QuestionAudio");
            }
        }
        public String AnswerText
        {
            get
            {
                return this.Model.AnswerText;
            }
            set
            {
                this.Model.AnswerText = value;
                OnPropertyChanged("AnswerText");
            }
        }
        public String AnswerVideo
        {
            get
            {
                return this.Model.AnswerVideo;
            }
            set
            {
                this.Model.AnswerVideo = value;
                OnPropertyChanged("AnswerVideo");
            }
        }
        public String AnswerImage
        {
            get
            {
                return this.Model.AnswerImage;
            }
            set
            {
                this.Model.AnswerImage = value;
                OnPropertyChanged("AnswerImage");
            }
        }
        public String AnswerAudio
        {
            get
            {
                return this.Model.AnswerAudio;
            }
            set
            {
                this.Model.AnswerAudio = value;
                OnPropertyChanged("AnswerAudio");
            }
        }

        public void StartAnswering()
        {
            Model.StartAnswering();
        }

        public void FinishAnswer(bool bol)
        {
            Model.FinishAnswer(bol);
        }
        public List<CardAnswer> cardAnswers
        {
            get
            {
                return this.Model.cardAnswers;
            }
        }

        public override void NewModelAssigned()
        {
            //throw new NotImplementedException();
        }
    }
}
