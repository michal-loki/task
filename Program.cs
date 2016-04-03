using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(String[] args)
        {
            //get the input sentence
            string[] sentence = Console.ReadLine().Split(' ');

            //initial the words dictionary
            Dictionary<string, int> words = new Dictionary<string, int>();

            //for each word in the input sentence
            foreach (string word in sentence)
            {
                //format word
                string s = formatWord(word);

                if (!String.IsNullOrWhiteSpace(s))
                {
                    if (words.ContainsKey(s))
                    {
                        //word occurences increases
                        words[s]++;
                    }
                    else
                    {
                        //word appears first time in the sentence
                        words.Add(s, 1);
                    }
                }
            }

            //Print the results
            foreach (var e in words)
            {
                Console.WriteLine(e.Key + " - " + e.Value.ToString());
            }

        }

        /// <summary>
        /// Format word to be processed
        /// </summary>
        /// <param name="s">string with word to be extracted</param>
        /// <returns></returns>
        static string formatWord(string s)
        {
            //to lower cases
            s = s.ToLower();

            //remove special marks from the end of the word (i.e. like: (" . , : ?))
            int i;
            for (i = s.Length - 1; i >= 0; i--)
            {
                if (char.IsLetterOrDigit(s, i))
                {
                    break;
                }
            }

            //retrieve the word without special marks at the end
            s = s.Substring(0, i+1);


            //remove special marks from the beginning of the word (i.e. like: (" . , : ?))
            int j;
            for (j = 0; j <s.Length; j++)
            {
                if (char.IsLetterOrDigit(s, j))
                {
                    break;
                }
            }

            //retrieve the word without special marks at the beginning
            s = s.Substring(j, s.Length-j);

            return s;
        }
    }
}

