using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace MyApp
{
    internal class PlayerData
    {
        FirebaseClient firebase = new FirebaseClient("https://myapp-7f8d5-default-rtdb.firebaseio.com/");

        public string UserID { get; set; }
        public string Name { get; set; }
        public int RecordMathGame { get; set; }
        public int RecordMathGameMinus { get; set; }
        public int RecordPuzzleGame { get; set; }
        public int RecordMemoryGame { get; set; }

    }
}
