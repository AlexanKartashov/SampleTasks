using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();

            list.AddFirst("1");
            list.AddFirst("2");
            list.AddFirst("3");
            list.AddLast("4");
            list.AddLast("5");
            list.AddFirst("6");
            list.DisplayList(); // 6 3 2 1 4 5

            Console.WriteLine();
            Console.WriteLine(list.GetAndRemoveFirst());
            list.DisplayList(); // 3 2 1 4 5

            Console.WriteLine();
            Console.WriteLine(list.GetAndRemoveLast());
            list.DisplayList(); // 3 2 1 4

            var findEl = list[2];
            Console.WriteLine();
            list.InsertAfter(findEl, "7");
            list.DisplayList(); // 3 2 1 7 4

            findEl = list[1];
            Console.WriteLine();
            list.RemoveElement(findEl);
            list.DisplayList(); // 3 1 7 4

            Console.WriteLine();
            list.AddFirst("8");
            list.AddLast("9");
            
            Console.ReadLine();
        }
    }
}
