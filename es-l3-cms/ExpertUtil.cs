using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace es_l3_cms
{
    class ExpertUtil
    {
        public static Decision[] Decisions;
        public static Solution[] Solutions;
        public static List<List<int>> Mapper = new List<List<int>>();

        public static void ReadDecisions()
        {
            ExpertUtil.Decisions = new Decision[12];

            ExpertUtil.Decisions[0] = new Decision("Czy CMS działał wcześniej?", 1, -1);
            ExpertUtil.Decisions[1] = new Decision("Czy widzisz coś na stronie?", 2, 3);
            ExpertUtil.Decisions[2] = new Decision("Czy wyświetla się jakiś błąd?", -1, 4);
            ExpertUtil.Decisions[3] = new Decision("Czy domena jest podłączona?", 5, -1);
            ExpertUtil.Decisions[4] = new Decision("Czy strona wyświetla się poprawnie?", -1, 6);
            ExpertUtil.Decisions[5] = new Decision("Czy jest opłacona?", 7, -1);
            ExpertUtil.Decisions[6] = new Decision("Czy działa administracja?", 8, 9);
            ExpertUtil.Decisions[7] = new Decision("Czy inne strony działają?", 10, -1);
            ExpertUtil.Decisions[8] = new Decision("Czy możesz podejrzeć informacje o tej stronie?", 11, -1);
            ExpertUtil.Decisions[9] = new Decision("Czy modyfikowałeś skrypt?", -1, -1);
            ExpertUtil.Decisions[10] = new Decision("Czy wyświetlają się poprawnie?", 9, -1);
            ExpertUtil.Decisions[11] = new Decision("Czy uruchamia się z panelu?", -1, -1);
        }

        public static void ReadSolutions()
        {
            ExpertUtil.Solutions = new Solution[14];

            ExpertUtil.Solutions[0] = new Solution("Zainstaluj go", new int[,] { { 0, 0 } });
            ExpertUtil.Solutions[1] = new Solution("Problem opisany w błędzie", new int[,] { { 0, 1 }, { 1, 1 }, { 2, 1 } });
            ExpertUtil.Solutions[2] = new Solution("Strona działa", new int[,] { { 0, 1 }, { 1, 1 }, { 2, 0 }, { 4, 1 } });
            ExpertUtil.Solutions[3] = new Solution("Podłacz ją", new int[,] { { 0, 1 }, { 1, 0 }, { 3, 0 } });
            ExpertUtil.Solutions[4] = new Solution("Opłać ją", new int[,] { { 0, 1 }, { 1, 0 }, { 3, 1 }, { 5, 0 } });
            ExpertUtil.Solutions[5] = new Solution("Serwer padł", new int[,] { { 0, 1 }, { 1, 0 }, { 3, 1 }, { 5, 1 }, { 7, 0 } });
            ExpertUtil.Solutions[6] = new Solution("Napisz do pomocy technicznej", new int[,] { { 0, 1 }, { 1, 0 }, { 3, 1 }, { 5, 1 }, { 7, 1 }, { 10, 0 } });
            ExpertUtil.Solutions[7] = new Solution("Cofnij zmiany", new int[,] { { 0, 1 }, { 1, 0 }, { 3, 1 }, { 5, 1 }, { 7, 1 }, { 10, 1 }, { 9, 1 } });
            ExpertUtil.Solutions[8] = new Solution("Napisz do pomocy technicznej", new int[,] { { 0, 1 }, { 1, 0 }, { 3, 1 }, { 5, 1 }, { 7, 1 }, { 10, 1 }, { 9, 0 } });
            ExpertUtil.Solutions[9] = new Solution("Cofnij zmiany", new int[,] { { 0, 1 }, { 1, 1 }, { 2, 0 }, { 4, 0 }, { 6, 0 }, { 9, 1 } });
            ExpertUtil.Solutions[10] = new Solution("Napisz do pomocy technicznej", new int[,] { { 0, 1 }, { 1, 1 }, { 2, 0 }, { 4, 0 }, { 6, 0 }, { 9, 0 } });
            ExpertUtil.Solutions[11] = new Solution("Napisz do pomocy technicznej", new int[,] { { 0, 1 }, { 1, 1 }, { 2, 0 }, { 4, 0 }, { 6, 0 }, { 8, 0 } });
            ExpertUtil.Solutions[12] = new Solution("Strona jest prywatna", new int[,] { { 0, 1 }, { 1, 1 }, { 2, 0 }, { 4, 0 }, { 6, 1 }, { 8, 1 }, { 11, 1 } });
            ExpertUtil.Solutions[13] = new Solution("Usuń wszystkie skrypty", new int[,] { { 0, 1 }, { 1, 1 }, { 2, 0 }, { 4, 0 }, { 6, 1 }, { 8, 1 }, { 11, 0 } });
        }

        public static void PrintQuestion(int it = 0)
        {
            if (it < 0)
            {
                ExpertUtil.PrintSolution();
                return;
            }

            Console.WriteLine(ExpertUtil.Decisions[it].GetQuestion());
            Console.Write("Odpowiedz [1 - Tak], [0 - Nie]: ");

            int answer = ExpertUtil.Ask();

            Mapper.Add(ExpertUtil.PrepareMap(it, answer));
            Console.WriteLine();

            ExpertUtil.PrintQuestion(ExpertUtil.Decisions[it].GetSkip(answer));
        }

        public static void PrintSolution()
        {
            foreach (Solution solution in ExpertUtil.Solutions)
            {
                if (solution.CheckSolution(ExpertUtil.Mapper))
                {
                    Console.WriteLine(solution.GetSolution());
                    Console.Read();
                    return;
                }
            }

            Console.WriteLine("Nie znam rozwiązania.");
            Console.Read();
            return;

        }

        public static List<int> PrepareMap(int it, int answer)
        {
            List<int> list = new List<int>();
            list.Add(it);
            list.Add(answer == 0 ? 0 : 1);

            return list;
        }

        public static int Ask()
        {
            int reply;
            bool parsed = int.TryParse(Console.ReadLine(), out reply);

            return (parsed ? reply : 0);
        }
    }
}
