//using MyApp.Audio;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xamarin.Forms;

//namespace MyApp
//{
//    public partial class MathGame : ContentPage
//    {

//        public Question currentQuestion;
//        public int questionCount;
//        public int CorrectCount { get; set; }
//        public int WrongCount { get; set; }

//        public MathGame()
//        {
//            InitializeComponent();
//            GameManage();
//            updateView();
              
          
//        }
//        public void GameManage()
//        {

//            currentQuestion = new Question(5);
//            questionCount++;
//            correctLabel.Text = "Счет = " + CorrectCount;

//            But1.Text = getCurrentQuestion().getAnswerArray()[0].ToString();
//            But2.Text = getCurrentQuestion().getAnswerArray()[1].ToString();
//            But3.Text = getCurrentQuestion().getAnswerArray()[2].ToString();
//            But4.Text = getCurrentQuestion().getAnswerArray()[3].ToString();

//            questionText.Text = getCurrentQuestion().getQuestionPhrase();

//            correctLabel.Text = "Счет = " + CorrectCount;
//        }
//        public void But_Clicked(object sender, EventArgs e)
//        {

//            Button btn = (Button)sender;
//            switch (btn.StyleId) {
//                case "1":
//                    checkAnswer(int.Parse(But1.Text));
//                    generateQuestion();
//                    updateView();
//                    break;
//                case "2":
//                    checkAnswer(int.Parse(But2.Text));
//                    generateQuestion();
//                    updateView();
//                    break;
//                case "3":
//                    checkAnswer(int.Parse(But3.Text));
//                    generateQuestion();
//                    updateView();
//                    break;
//                case "4":
//                    checkAnswer(int.Parse(But4.Text));
//                    generateQuestion();
//                    updateView();
//                    break;
//            }
          
//        }
//        public async void checkAnswer(int answerArg)
//        {
//            if (answerArg == this.currentQuestion.getAnswer())
//            {

//                DependencyService.Get<IAudio>().PlayAudioFile("CorrectAudio.mp3");
//                questionText.BackgroundColor = Color.GreenYellow;
                
//                CorrectCount++;
//                await Task.Delay(1500);
//            }
//            else
//            {

//                DependencyService.Get<IAudio>().PlayAudioFile("NotCorrectAudio.mp3");
//                questionText.BackgroundColor = Color.Red;
//                WrongCount++;
//                await Task.Delay(1500);
//            }
            
//        }
//        public async void OffOnButtons()
//        {
//            But1.IsEnabled = false;
//            But2.IsEnabled = false;
//            But3.IsEnabled = false;
//            But4.IsEnabled = false;
//            await Task.Delay(1500);
//            But1.IsEnabled = true;
//            But2.IsEnabled = true;
//            But3.IsEnabled = true;
//            But4.IsEnabled = true;

//        }
//        public async void updateView()
//        {

//            OffOnButtons();
//            await Task.Delay(1500);
//            questionText.BackgroundColor = Color.White;
//            But1.Text = getCurrentQuestion().getAnswerArray()[0].ToString();
//            But2.Text = getCurrentQuestion().getAnswerArray()[1].ToString();
//            But3.Text = getCurrentQuestion().getAnswerArray()[2].ToString();
//            But4.Text = getCurrentQuestion().getAnswerArray()[3].ToString();

//            questionText.Text = getCurrentQuestion().getQuestionPhrase();

//            correctLabel.Text = "Счет = " + CorrectCount;

//        }
//        public Question getCurrentQuestion()
//        {
//            return this.currentQuestion;
//        }
//        public void generateQuestion()
//        {
//            currentQuestion = new Question(questionCount + 5 * 2);
//            questionCount++;
//        }
//    }
//}
