using System.Collections.Generic;

namespace MaximumMatching
{
    class Graph
    {
        //private int[] marks1;
        //private int[] marks2;
        //private int[] pairs; 
        //List<int>[] half1;
        //List<int>[] half2;
        private int[] marks1;
        private int[] marks2;
        private int[] pairs;
        private Dictionary<int, List<int>> half1;
        private Dictionary<int, List<int>> half2;
        int size;


         /// <summary>
         /// конструктор графа
         /// </summary>
        public Graph()
        {
            size = 0;
            half1 = new Dictionary<int, List<int>>();
            half2 = new Dictionary<int, List<int>>();
        }

        /// <summary>
        /// Доавление связей
        /// </summary>
        /// <param name="num"> Номер вершины первой доли </param>
        /// <param name="connections"> Номера вершин второй доли, с которой соединена эта вершина</param>
        public void AddConnection(int num, IEnumerable<int> connections)
        {
            size++;
            half1[num] = new List<int>(connections);
            foreach (int con in connections)
            {
                if (!half2.ContainsKey(con))
                {
                    half2[con] = new List<int>();
                }
                half2[con].Add(num);
            }
        }

        /// <summary>
        /// Метод, находящий перосочетания
        /// </summary>
        /// <returns>
        /// Массив со связями вершины из второй доли с вершиной из первой доли 
        /// i-тый элемент массива - это вершина первой доли, с которой соединена i-тая вершина второй доли
        /// </returns>
        public int [] FindPairs()
        {
            marks1 = new int[size];
            marks2 = new int[size];
            pairs = new int[size];

            for (int i = 0; i < size; i++)
                pairs[i] = -1;

            bool foundMatching;
            
            while (true)
            {
                List<int> curNodes1 = new List<int>();
                List<int> curNodes2 = new List<int>();

                List<int> pairsList = new List<int>((IEnumerable<int>)pairs);

                for (int i = 0; i < size; i++)
                {
                    if (!pairsList.Contains(i))
                        curNodes1.Add(i); 
                }

                for (int i = 0; i < size; i++)
                {
                    marks1[i] = -1;
                    marks2[i] = -1;
                }

                do
                {
                    foundMatching = false;

                    FirstHalfWork(ref curNodes1, ref curNodes2, out foundMatching);
                    curNodes1.Clear();
                    if (foundMatching)
                        break;
                    if (curNodes2.Count == 0) 
                        return pairs;
                    SecondHalfWork(ref curNodes1, ref curNodes2);
                    curNodes2.Clear();

                } while (curNodes1.Count > 0);
            }
        }

        private void FirstHalfWork(ref List<int> curNodes1, ref List<int> curNodes2, out bool foundMatching)
        {
            foreach (int node in curNodes1)
            {
                foreach (int child in half1[node])
                    if (marks2[child] == -1&&pairs[child]!=node)
                    {
                        marks2[child] = node;
                        if (pairs[child] == -1)
                        {
                            foundMatching = true;
                            ReverseChain(child);
                            return;
                        }
                        curNodes2.Add(child);
                    }
            }
            foundMatching = false;
        }

        private void SecondHalfWork(ref List<int> curNodes1, ref List<int> curNodes2)
        {
            foreach (int node in curNodes2)
            {
                foreach (int child in half2[node])
                    if (marks1[child] == -1&&pairs[node]==child)
                    {
                        marks1[child] = node;
                        curNodes1.Add(child);
                    }
            }
        }


        private void ReverseChain(int child)
        {
            int currNode = child;
            while (currNode!=-1)
            {
                pairs[currNode] = marks2[currNode];
                currNode = marks1[marks2[currNode]];

            }
        }
    }
}
