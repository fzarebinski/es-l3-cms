using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace es_l3_cms
{
    class ExpertUtil
    {
        public static Decision[] Decisions = new Decision[12];
        public static Solution[] Solutions = new Solution[11];
        public static List<List<int>> Mapper = new List<List<int>>();

        public static void ReadDecisions()
        {
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
            ExpertUtil.Solutions[0] = new Solution("Zainstaluj go", new int[,] { { 0, 0 } });
            ExpertUtil.Solutions[1] = new Solution("Problem opisany w błędzie", new int[,] { { 0, 1 }, { 1, 1 }, { 2, 1 } });
            ExpertUtil.Solutions[2] = new Solution("Strona działa", new int[,] { { 0, 1 }, { 1, 1 }, { 2, 0 }, { 4, 1 } });
        }

        public static void PrintQuestion(int it = 0)
        {
            if (it < 0)
            {
                foreach (Solution solution in ExpertUtil.Solutions)
                {
                    if (solution.CheckSolution(ExpertUtil.Mapper))
                    {
                        Console.WriteLine(solution.GetSolution()); Console.Read();
                        Console.Read();
                        break;
                    }
                }
                return;
            }

            Console.WriteLine(ExpertUtil.Decisions[it].GetQuestion());
            Console.Write("Odpowiedz [1 - Tak], [0 - Nie]: ");

            int answer = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();
            list.Add(it);
            list.Add(answer);
            Mapper.Add(list);

            ExpertUtil.PrintQuestion(ExpertUtil.Decisions[it].GetSkip(answer));
        }
    }
}
