using System.Collections.Generic;

namespace ChuongTrinhThiTracNghiem
{
    class List_Question
    {
        public List<Question> list = new List<Question>();  //The entire questions

        public List_Question()
        {

        }

        public void Add(Question q)
        {
            list.Add(q);
        }

        public void Delete(Question q)
        {
            list.Remove(q);
        }

        public Question this[int index]
        {
            get { return list[index]; }
        }
    }
}
