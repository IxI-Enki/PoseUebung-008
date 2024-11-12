using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCollections;

namespace PrintSpooler.ConApp
{
    class Program
    {
        public static Random RandomGenerator { get; private set; } 
        
        static Program()
        {
            RandomGenerator = new Random(DateTime.Now.Millisecond);
        }

        static void Main(string[] args)
        {
            PriorityQueue<int, string> printSpooler = new PriorityQueue<int, string>();

            for (int i = 0; i < 25; i++)
            {
                int priority = RandomGenerator.Next(1, 100);

                printSpooler.Push(priority, String.Format("Druckauftrag #{0,-3} mit der Priorität {1}", i + 1, priority));
            }

            Console.WriteLine("Abarbeitung der Druckaufträge:");
            Console.WriteLine("------------------------------");

            while (printSpooler.IsEmpty == false)
            {
                Console.WriteLine(printSpooler.Pop());
            }
        }
    }
}
