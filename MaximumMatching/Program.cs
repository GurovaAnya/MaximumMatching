using System;

namespace MaximumMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph gr = new Graph(5);
            gr.AddConnection(0, new int[] { 0, 1, 3 });
            gr.AddConnection(1, new int[] { 1, 2 });
            gr.AddConnection(2, new int[] { 1, 2 });
            gr.AddConnection(3, new int[] { 0, 2, 3, 4 });
            gr.AddConnection(4, new int[] { 1, 2 });
            Print(gr.FindPairs());

            Graph gr2 = new Graph(5);
            gr2.AddConnection(0, new int[] { 0,1,3 });
            gr2.AddConnection(1, new int[] { 2,4});
            gr2.AddConnection(2, new int[] { 0,1,3 });
            gr2.AddConnection(3, new int[] { 0,4 });
            gr2.AddConnection(4, new int[] { 2,4 });
            Print(gr2.FindPairs());

            Graph gr3 = new Graph(0);
            Print(gr3.FindPairs());

            Graph gr4 = new Graph(6);
            gr4.AddConnection(0, new int[] { 2,4,5 });
            gr4.AddConnection(1, new int[] { 0,1,5 });
            gr4.AddConnection(2, new int[] { 2,5 });
            gr4.AddConnection(3, new int[] { 0,1,4 });
            gr4.AddConnection(4, new int[] { 2 });
            gr4.AddConnection(5, new int[] { 4,5 });
            Print(gr4.FindPairs());

            Graph gr5 = new Graph(5);
            gr5.AddConnection(0, new int[] { 0, 3,4});
            gr5.AddConnection(1, new int[] { 0,2 });
            gr5.AddConnection(2, new int[] { 0,1,3 });
            gr5.AddConnection(3, new int[] { 1,2,4});
            gr5.AddConnection(4, new int[] { 2,4});
            Print(gr5.FindPairs());



        }

        static void Print(int[] pairs)
        {
            for (int i = 0; i < pairs.Length; i++)
            {
                Console.Write(pairs[i] + 1);
                Console.Write('-');
                Console.WriteLine(i + 1);
            }
            Console.WriteLine(); 
        }
    }
}
