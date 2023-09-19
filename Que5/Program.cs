using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Que5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Collection = new CustomList<String>();
            Collection[0] = "Akash singh";
            Collection[1] = "Kanha";
            Collection[2] = "Devendra sharma";
            Collection[3] = "Bobby chaudhary";
            Collection[4] = "Trilok rajput";
            Console.WriteLine("Akash singh Friends : ");
            for (int i = 0; i < 5; i++)
                Console.WriteLine(Collection[i]);
        }
    }
    class CustomList<T>
    {
        private T[] list = new T[5];
        public T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }
    }
}
       
