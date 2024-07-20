using MyApp.Audio;
using MyApp.RegisterAndLoginPage.EmployeeSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PuzzleGame : ContentPage
    {
        static Random rnd = new Random();
        private int moves = 0;
        private int movesRecord;

        EmployeeSaveAndGet employeeSave = new EmployeeSaveAndGet();
        static void Shuffle<T>(T[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + rnd.Next(n - i);
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }

        public PuzzleGame()
        {
            InitializeComponent();
            employeeSave.GetEmployee();
            movesRecord = Convert.ToInt32(App.Current.Properties["RecordPuzzleGame"]); 
            RecordMovesLabel.Text = "Рекорд: " + movesRecord;
            StartGame();
        }

        async void BackToMenuBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void EndCheck()
        {

            DependencyService.Get<IAudio>().PlayAudioFile("PuzzleGameAudio.mp3");
            MovesLabel.Text = "Ходов: " + moves;

            if (puz1.Text == "1" && puz2.Text == "2" && puz3.Text == "3" && puz4.Text == "4" && puz5.Text == "5" && puz6.Text == "6" && puz7.Text == "7" && puz8.Text == "8" && puz9.Text == "")
            {
                WinTxt.Text = "Умничка! Ты победил";
                BtnGameReset.IsVisible = true;
                WinTxt.IsVisible= true;
                if (moves < movesRecord || movesRecord == 0)
                {
                    movesRecord= moves;
                    App.Current.Properties["RecordPuzzleGame"] = movesRecord;
                    employeeSave.SaveEmployee();
                    RecordMovesLabel.Text = "Рекорд: " + movesRecord;
                }
            }
            else
            {
                BtnGameReset.IsVisible = false;
                WinTxt.IsVisible = false;
            }
        }

        // moving puzzles
        private void Puz1_Clicked(object sender, EventArgs e)
        {
            if (puz2.Text == "")
            {
                puz2.Text = puz1.Text;
                puz1.Text = "";
                moves++;
            }
            if (puz4.Text == "")
            {
                puz4.Text = puz1.Text;
                puz1.Text = "";
                moves++;
            }

            EndCheck();
        }

        private void Puz2_Clicked(object sender, EventArgs e)
        {
            if (puz1.Text == "")
            {
                puz1.Text = puz2.Text;
                puz2.Text = "";
                moves++;
            }
            if (puz3.Text == "")
            {
                puz3.Text = puz2.Text;
                puz2.Text = "";
                moves++;
            }
            if (puz5.Text == "")
            {
                puz5.Text = puz2.Text;
                puz2.Text = "";
                moves++;
            }

            EndCheck();
        }

        private void Puz3_Clicked(object sender, EventArgs e)
        {
            if (puz2.Text == "")
            {
                puz2.Text = puz3.Text;
                puz3.Text = "";
                moves++;
            }
            if (puz6.Text == "")
            {
                puz6.Text = puz3.Text;
                puz3.Text = "";
                moves++;
            }

            EndCheck();
        }

        private void Puz4_Clicked(object sender, EventArgs e)
        {
            if (puz1.Text == "")
            {
                puz1.Text = puz4.Text;
                puz4.Text = "";
                moves++;
            }
            if (puz5.Text == "")
            {
                puz5.Text = puz4.Text;
                puz4.Text = "";
                moves++;
            }
            if (puz7.Text == "")
            {
                puz7.Text = puz4.Text;
                puz4.Text = "";
                moves++;
            }

            EndCheck();
        }

        private void Puz5_Clicked(object sender, EventArgs e)
        {
            if (puz2.Text == "")
            {
                puz2.Text = puz5.Text;
                puz5.Text = "";
                moves++;
            }
            if (puz4.Text == "")
            {
                puz4.Text = puz5.Text;
                puz5.Text = "";
                moves++;
            }
            if (puz6.Text == "")
            {
                puz6.Text = puz5.Text;
                puz5.Text = "";
                moves++;
            }
            if (puz8.Text == "")
            {
                puz8.Text = puz5.Text;
                puz5.Text = "";
                moves++;
            }

            EndCheck();
        }

        private void Puz6_Clicked(object sender, EventArgs e)
        {
            if (puz3.Text == "")
            {
                puz3.Text = puz6.Text;
                puz6.Text = "";
                moves++;
            }
            if (puz5.Text == "")
            {
                puz5.Text = puz6.Text;
                puz6.Text = "";
                moves++;
            }
            if (puz9.Text == "")
            {
                puz9.Text = puz6.Text;
                puz6.Text = "";
                moves++;
            }

            EndCheck();
        }

        private void Puz7_Clicked(object sender, EventArgs e)
        {
            if (puz4.Text == "")
            {
                puz4.Text = puz7.Text;
                puz7.Text = "";
                moves++;
            }
            if (puz8.Text == "")
            {
                puz8.Text = puz7.Text;
                puz7.Text = "";
                moves++;
            }

            EndCheck();
        }

        private void Puz8_Clicked(object sender, EventArgs e)
        {
            if (puz5.Text == "")
            {
                puz5.Text = puz8.Text;
                puz8.Text = "";
                moves++;
            }
            if (puz7.Text == "")
            {
                puz7.Text = puz8.Text;
                puz8.Text = "";
                moves++;
            }
            if (puz9.Text == "")
            {
                puz9.Text = puz8.Text;
                puz8.Text = "";
                moves++;
            }

            EndCheck();
        }

        private void Puz9_Clicked(object sender, EventArgs e)
        {
            if (puz6.Text == "")
            {
                puz6.Text = puz9.Text;
                puz9.Text = "";
                moves++;
            }
            if (puz8.Text == "")
            {
                puz8.Text = puz9.Text;
                puz9.Text = "";
                moves++;
            }

            EndCheck();
        }

        private void GameReset_Clicked(object sender, EventArgs e)
        {
            StartGame();
        }
        private void StartGame()
        {
            Button[] puzzles = { puz1, puz2, puz3, puz4, puz5, puz6, puz7, puz8, puz9 };

            string[] puz = { "1", "2", "3", "4", "5", "6", "7", "8", "" };

            Shuffle(puz);
            for (int i = 0; i < puzzles.Length; i++)
            {
                puzzles[i].Text = puz[i];
            }
            moves = 0;
            BtnGameReset.IsVisible= false;
            WinTxt.IsVisible=false;
        }
    }
}