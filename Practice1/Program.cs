using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public int Challenge(int[] input)
        {
            if (input == null || input.Length == 0) throw new ArgumentException("input is null");
            if (input.Length < 2) throw new ArgumentException("input length should be greater than 2");

            int i;
            int maxPositive/*max item in positive items in input*/, maxNegative/*max item in negative items in input*/;
            int[] arrPositiveCounts/*holds the count of each positive item in input arr*/, arrNegativeCounts/*holds the count of each negative item in in input arr*/;
            bool[] arrExclusion;/*holds the items which should not be checked*/
            int maxOccurences = 0;/*maximum occurences in array*/
            bool notNegativeValuesExists = false;/*is there a nonnegative value in input*/

            maxNegative = maxPositive = 0;
            for (i = 0; i < input.Length - 1; i++)
            {
                if (input[i] < 0)
                {
                    //negative value
                    if (maxNegative < input[i] * -1)
                    {
                        maxNegative = input[i] * -1;
                    }
                }
                else
                {
                    notNegativeValuesExists = true;
                    if (maxPositive < input[i])
                    {
                        maxPositive = input[i];
                    }
                }
            }

            if (maxPositive == 0 && notNegativeValuesExists)
            {
                //we have only an array with 0 values and/or negative values 
                //we don't have positive values so the answer is 0
                return 0;
            }


            arrPositiveCounts = new int[maxPositive + 1];
            arrNegativeCounts = new int[maxNegative + 1];

            arrExclusion = new bool[input.Length];

            for (i = 0; i <= input.Length - 1; i++)
            {
                if (input[i] >= 0)
                {
                    arrPositiveCounts[input[i]] = arrPositiveCounts[input[i]] + 1;

                    if (arrPositiveCounts[input[i]] > maxOccurences)
                    {
                        maxOccurences = arrPositiveCounts[input[i]];
                    }
                }
                else
                {
                    arrNegativeCounts[-1 * input[i]] = arrNegativeCounts[-1 * input[i]] + 1;

                    if (arrNegativeCounts[-1 * input[i]] > maxOccurences)
                    {
                        maxOccurences = arrNegativeCounts[-1 * input[i]];
                    }
                }
            }

            for (i = 0; i <= input.Length - 1; i++)
            {
                if (input[i] >= 0)
                {
                    if (arrPositiveCounts[input[i]] != maxOccurences
                        && arrPositiveCounts[input[i]] != maxOccurences - 1)
                    {
                        arrExclusion[i] = true;
                    }
                }
                else
                {
                    if (arrNegativeCounts[-1 * input[i]] != maxOccurences
                          && arrNegativeCounts[-1 * input[i]] != maxOccurences - 1)
                    {
                        arrExclusion[i] = true;
                    }

                }
            }


            int previousIndex = 0;
            int maxNeighbour = int.MinValue;
            for (i = 0; i <= input.Length - 1; i++)
            {
                if (!arrExclusion[i])
                {
                    if (i > 0 && input[i] == input[previousIndex])
                    {
                        if (input[i] * 2 > maxNeighbour)
                        {
                            maxNeighbour = input[i] * 2;
                        }
                    }
                    previousIndex = i;
                }
            }
            return maxNeighbour;
        }

    }
}

