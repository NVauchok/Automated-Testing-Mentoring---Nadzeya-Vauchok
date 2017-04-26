using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class FindString
    {
        static void Main()
        {
            int l;
            string input;
            int temp;
            string tempString;
            
            Console.WriteLine("Please enter number of strings in array");
            input = Console.ReadLine();
            l = Convert.ToInt32(input);
            string[] myStringArray = new string[l];
            for (int i = 0 ; i < l; i++)
            {
                Console.WriteLine("Please enter string #{0}", i+1);
                myStringArray[i] = Console.ReadLine();
            }
            
            int[] ArrayLenght = new int[l];
            for (int i = 0; i < l; i++)
            {
                ArrayLenght[i] = myStringArray[i].Length;
            }

            for (int i = l-1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (ArrayLenght[j] > ArrayLenght[j + 1])
                    {
                        temp = ArrayLenght[j];
                        ArrayLenght[j] = ArrayLenght[j + 1];
                        ArrayLenght[j + 1] = temp;
                        tempString = myStringArray[j];
                        myStringArray[j] = myStringArray[j + 1];
                        myStringArray[j + 1] = tempString;
                    }
                }
                
            }

            Console.WriteLine("Here is sorted array in a ascending order");
            for (int i = 0; i < l; i++)
            {
                Console.WriteLine(myStringArray[i]);
            }

            Console.WriteLine("Here is the second by lenght string in array: {0}", myStringArray[l-2]);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
