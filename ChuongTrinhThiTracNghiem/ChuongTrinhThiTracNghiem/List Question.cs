using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuongTrinhThiTracNghiem
{
    class List_Question
    {
        public List<Question> list = new List<Question>();

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
