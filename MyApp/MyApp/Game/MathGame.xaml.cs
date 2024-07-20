using MyApp.Audio;
using MyApp.RegisterAndLoginPage.EmployeeSetting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyApp
{
    public partial class MathGame : ContentPage
    {


        private int num1 = 0;
        private int num2 = 0;
        private int correct = 0;
        private int resultCorrect = 0;

        Random random = new Random();
        EmployeeSaveAndGet employeeSave = new EmployeeSaveAndGet();
        public MathGame()
        {
            InitializeComponent();
            employeeSave.GetEmployee();
            correct = Convert.ToInt32(App.Current.Properties["RecordMathGame"]);
            correctLabel.Text = correct.ToString();
            updateView();
        }

        private void updateView()
        {
            employeeSave.SaveEmployee();
            randomNumbers.BackgroundColor = Color.White;
            RandomsNumbers();
            correctLabel.Text = "Счет : " + correct;
        }
        private async void ButtonCorrect(string value)
        {
            randomNumbers.Text = num1 + " + " + num2;
            if (resultCorrect == Convert.ToInt32(value))
            {
                DependencyService.Get<IAudio>().PlayAudioFile("CorrectAudio.mp3");
                correct++;
                randomNumbers.BackgroundColor = Color.GreenYellow;
                App.Current.Properties["RecordMathGame"] = correct;
            }
            else
            {
                DependencyService.Get<IAudio>().PlayAudioFile("NotCorrectAudio.mp3");
                randomNumbers.BackgroundColor = Color.Red;
            }
            OnOffButton();
            await Task.Delay(1500);
            updateView();
        }
        private void RandomsNumbers()
        {
            num1 = random.Next(113, 499);
            num2 = random.Next(113, 499);

            randomNumbers.Text = num1 + " + " + num2;
            resultCorrect = num1 + num2;
            But1.Text = Convert.ToString(resultCorrect - 12);
            But2.Text = Convert.ToString(resultCorrect - 5);
            But3.Text = Convert.ToString(resultCorrect + 10);
            But4.Text = Convert.ToString(resultCorrect + 8);
            RandomLocationCorrect();
        }
        private void RandomLocationCorrect()
        {
            int rand = random.Next(1, 4);
            if (rand == 1)
                But1.Text = Convert.ToString(resultCorrect);
            if (rand == 2)
                But2.Text = Convert.ToString(resultCorrect);
            if (rand == 3)
                But3.Text = Convert.ToString(resultCorrect);
            if (rand == 4)
                But4.Text = Convert.ToString(resultCorrect);
        }
        public async void OnOffButton()
        {
            But1.IsEnabled = false;
            But2.IsEnabled = false;
            But3.IsEnabled = false;
            But4.IsEnabled = false;
            await Task.Delay(1500);

            But1.IsEnabled = true;
            But2.IsEnabled = true;
            But3.IsEnabled = true;
            But4.IsEnabled = true;
        }

        private void But_Clicked1(object sender, EventArgs e)
        {
            ButtonCorrect(But1.Text);
        }

        private void But_Clicked2(object sender, EventArgs e)
        {
            ButtonCorrect(But2.Text);
        }

        private void But_Clicked3(object sender, EventArgs e)
        {
            ButtonCorrect(But3.Text);
        }

        private void But_Clicked4(object sender, EventArgs e)
        {
            ButtonCorrect(But4.Text);
        }
    }
}
