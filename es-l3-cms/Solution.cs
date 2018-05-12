using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace es_l3_cms
{
    class Solution
    {
        private List<List<int>> mapper = new List<List<int>>();
        private string solution;

        public Solution(string solution, int[,] mapper)
        {
            this.solution = solution;
            
            for (int i = 0; i < (mapper.Length / 2); i++)
            {
                this.AddMap(mapper[i, 0], mapper[i, 1]);
            }
        }

        public void AddMap(int key, int value)
        {
            List<int> map = new List<int>();
            map.Add(key);
            map.Add(value);

            this.mapper.Add(map);
        }

        public bool CheckSolution(List<List<int>> decisionMap)
        {
            if(decisionMap.Count() == this.mapper.Count())
            {
                for (int i = 0; i < this.mapper.Count(); i++)
                {
                    for (int j = 0; j < decisionMap.Count(); j++)
                    {
                        if ((this.mapper[i])[0] == (decisionMap[j])[0] && (this.mapper[i])[1] == (decisionMap[j])[1])
                        {
                            decisionMap.Remove(decisionMap[j]);
                        }
                    }
                }

                return (decisionMap.Count() == 0);
            }
            return false;
        }

        public string GetSolution()
        {
            return this.solution;
        }
    }
}
