using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuongTrinhThiTracNghiem
{
    class Question
    {
        public string question;
        public List<string> answers = new List<string>();
        public int correctAns;
        public int selectedAns = 0;

        public Question()
        {

        }

        public Question(int id, string question, List<string> answers, char correctAns)
        {
            this.question = question;
            this.answers = answers;
            this.correctAns = correctAns;
        }
    }
}
