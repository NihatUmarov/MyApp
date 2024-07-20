using MyApp.Audio;
using MyApp.RegisterAndLoginPage.EmployeeSetting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyApp
{
    public partial class MemoryGame : ContentPage
    {
        string originalButtonColor = "#fff";
        string[] colors = { "#59DAB4", "#E74C70", "#F188E8", "#f00000", "#ff6b42", "#ffb914", "#a16102" };
        List<int> patternIndexes;
        List<Color> patternColors;
        bool patternShowing;
        int currentPatternIndex;
        int bestScore;
        int score = 0;

        EmployeeSaveAndGet employeeSave = new EmployeeSaveAndGet();

        public MemoryGame()
        {
            InitializeComponent();
            employeeSave.GetEmployee();
            bestScore = Convert.ToInt32(App.Current.Properties["RecordMemoryGame"]);
            gridView.SizeChanged += (object sender, EventArgs e) => { gridView.HeightRequest = gridView.Width; };
        }

        protected override void OnAppearing()
        {
            InitializingGameParameters();
        }

        public void SelectingButton(int buttonIndex, Color color)
        {
            switch (buttonIndex)
            {
                case 0:
                    one.BackgroundColor = color;
                    break;
                case 1:
                    two.BackgroundColor = color;
                    break;
                case 2:
                    three.BackgroundColor = color;
                    break;
                case 3:
                    four.BackgroundColor = color;
                    break;
                case 4:
                    five.BackgroundColor = color;
                    break;
                case 5:
                    six.BackgroundColor = color;
                    break;
                case 6:
                    seven.BackgroundColor = color;
                    break;
                case 7:
                    eight.BackgroundColor = color;
                    break;
                case 8:
                    nine.BackgroundColor = color;
                    break;
            }
        }

        async Task MakingPattern()
        {
            patternShowing = true;
            patternIndexes.Add(new Random().Next(9));
            patternColors.Add(Color.FromHex(colors[new Random().Next(colors.Length)]));
            for (int i = 0; i < patternIndexes.Count; i++)
            {
                SelectingButton(patternIndexes[i], patternColors[i]);
                await Task.Delay(1000);
                SelectingButton(patternIndexes[i], Color.FromHex(originalButtonColor));
                await Task.Delay(250);
            }
            label.Text = "Попробуй воспроизвести шаблон!";
            patternShowing = false;
        }
        public async void ButtonPressed(Object sender, EventArgs e)
        {

            DependencyService.Get<IAudio>().PlayAudioFile("MemoryGameAudio.mp3");
            if (!startGameButton.IsVisible)
            {
                var name = ((Button)sender).Id;
                if (name == one.Id)
                {
                    await CheckingPattern(0);
                }
                else if (name == two.Id)
                {
                    await CheckingPattern(1);
                }
                else if (name == three.Id)
                {
                    await CheckingPattern(2);
                }
                else if (name == four.Id)
                {
                    await CheckingPattern(3);
                }
                else if (name == five.Id)
                {
                    await CheckingPattern(4);
                }
                else if (name == six.Id)
                {
                    await CheckingPattern(5);
                }
                else if (name == seven.Id)
                {
                    await CheckingPattern(6);
                }
                else if (name == eight.Id)
                {
                    await CheckingPattern(7);
                }
                else if (name == nine.Id)
                {
                    await CheckingPattern(8);
                }
            }
        }

        async Task CheckingPattern(int index)
        {
            if (!patternShowing)
            {
                if (index == patternIndexes[currentPatternIndex])
                {
                    label.Text = "Осталось шагов: " + (patternIndexes.Count - currentPatternIndex - 1);
                    SelectingButton(patternIndexes[currentPatternIndex], patternColors[currentPatternIndex]);
                    progressBar.Progress = ((float)(currentPatternIndex + 1) / patternIndexes.Count);
                    currentPatternIndex++;
                    score += (10 * currentPatternIndex);
                    scoreLabel.Text = "Счет: " + score;
                    if (currentPatternIndex >= patternIndexes.Count)
                    {
                        label.Text = "Отличная работа";
                        await Task.Delay(1000);
                        currentPatternIndex = 0;
                        progressBar.Progress = 0;
                        label.Text = "Запомни последовательность!";
                        await MakingPattern();
                    }
                }
                else
                {
                    GameOver();
                }
            }
        }

        void GameOver()
        {
            startGameButton.IsVisible = true;
            progressBar.Progress = 1;
            progressBar.ProgressColor = Color.FromHex("#E74C70");
            label.Text = "Нажмите \"Начать\", чтобы повторить попытку";

            if (score > bestScore)
            {
                bestScore = score;
                App.Current.Properties["RecordMemoryGame"] = bestScore;
                employeeSave.SaveEmployee();
                bestScoreLabel.Text = "Рекорд: " + bestScore;
            }
            InitializingGameParameters();
        }

        private async void StartGameButtonClicked(object sender, EventArgs e)
        {
            if (!patternShowing)
            {
                startGameButton.IsVisible = false;
                label.Text = "Запомните последовательность!";
                progressBar.Progress = 0;
                progressBar.ProgressColor = Color.FromHex("#80CBC4"); //making progress color is green
                await MakingPattern();
            }
        }

        void InitializingGameParameters()
        {
            patternIndexes = new List<int>();
            patternColors = new List<Color>();
            patternShowing = false;
            currentPatternIndex = 0;
            score = 0;
            scoreLabel.Text = "Счет: " + score;
            bestScoreLabel.Text = "Рекорд: " + bestScore;
        }

        private void ButtonReleased(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundColor = Color.FromHex(originalButtonColor);
        }

        private async void OpenLeaderboard(object sender, EventArgs e)
        {
            await ((NavigationPage)Application.Current.MainPage).Navigation.PushAsync(new NavigationPage());
        }
    }
}
