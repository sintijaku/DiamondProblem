using System.Collections.Generic;
using System.Linq;

namespace DiamondProblem
{
    class Program
    {
        static void Main(string[] args)
        {}
    }

    public class DiamondCreator
    {
        public List<string> CreateDiamond(string letter)
        {
            var alphabetDictionary = CreateDictionary();
            int widestPoint = alphabetDictionary.Where(x => x.Value == letter.ToString()).Select(y => y.Key).FirstOrDefault();
            int innerSpaces = 0;
            int outerSpaces = widestPoint;
            var diamondHalf = new List<string>();

            if (widestPoint == 0)
            {
                return new List<string>() { "A" };
            }
            else
            {
                for (int i = 0; i <= widestPoint; i++)
                {
                    if (i == 0)
                    {
                        diamondHalf.Add($"{CreateSpaces(outerSpaces)}{alphabetDictionary[i]}{CreateSpaces(outerSpaces)}");
                    }
                    else
                    {
                        diamondHalf.Add($"{CreateSpaces(outerSpaces)}{alphabetDictionary[i]}{CreateSpaces(innerSpaces)}{alphabetDictionary[i]}{CreateSpaces(outerSpaces)}");
                    }

                    innerSpaces = innerSpaces >= 1 ? innerSpaces + 2 : innerSpaces + 1;
                    outerSpaces -= 1;
                }
            }

            return ComposeFullDiamond(diamondHalf);
        }

        private string CreateSpaces(int numberOfSpaces)
        {
            string spaces = string.Empty;
            for (int i = 0; i < numberOfSpaces; i++)
            {
                spaces += " "; 
            }
            
            return spaces;
        }

        private List<string> ComposeFullDiamond(List<string> diamondHalf)
        {
            var result = new List<string>();
            result.AddRange(diamondHalf);
            diamondHalf.Reverse();
            diamondHalf.RemoveAt(0);
            result.AddRange(diamondHalf);

            return result;
        }

        private Dictionary<int, string> CreateDictionary()
        {
            var alphabetDictionary = new Dictionary<int, string>();

            for (char i = 'A'; i <= 'Z'; i++)
            {
                int key = i - 'A';
                alphabetDictionary.Add(key, i.ToString());
            }

            return alphabetDictionary;
        }
    }
}
