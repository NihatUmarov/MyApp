using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp
{
    public class Question
    {
        private int firstNumber;
        private int secondNumber;
        private int answer;
        private int[] answerArray = new int[4];
        private int answerPosition;
        private string questionPhrase;
        

        public Question(int value)
        {
            firstNumber = new Random().Next(100,489);
            secondNumber = new Random().Next(100,489);
            answer = firstNumber + secondNumber;

                questionPhrase = firstNumber + " + " + secondNumber;
                answerPosition = new Random().Next(4);
            
                this.answerArray[0] = answer + 10;
                this.answerArray[1] = answer + 3;
                this.answerArray[2] = answer - 5;
                this.answerArray[3] = answer - 10;

                ShuffleArray(this.answerArray);

                this.answerArray[answerPosition] = answer;
        }

        public int[] getAnswerArray() {
            return this.answerArray;
        }

        public void setQuestionPhrase(string questionPhrase) {
            this.questionPhrase = questionPhrase;
        }

        public string getQuestionPhrase() {
            return questionPhrase;
        }

        public int getAnswer() {
            return this.answer;
        }

        public void ShuffleArray(int[] array) {
            int randomIndex = new Random().Next(4);
            for (int i = 0; i < array.Length; i++) {
                int temp = array[randomIndex];
                array[randomIndex] = array[i];
                array[i] = temp;
            }
            
        }
    }
}
