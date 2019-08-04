using System.Collections.Generic;

namespace ChuongTrinhThiTracNghiem
{
    class Question
    {
        public string question;     //A content question
        public List<string> answers = new List<string>();   //The answer list of the above question
        public int correctAns;      //The correct answer
        public int selectedAns = 0; //Your answer

        public Question()
        {

        }

        public Question(string question, List<string> answers, char correctAns)
        {
            this.question = question;
            this.answers = answers;
            this.correctAns = correctAns;
        }
    }
}
