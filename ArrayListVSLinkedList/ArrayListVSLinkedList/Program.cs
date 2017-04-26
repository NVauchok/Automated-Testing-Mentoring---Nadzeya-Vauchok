using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace ArrayListVSLinkedList
{
    class ArrayListVSLinkedList
    {
        static void Main()
        {
            Console.WriteLine("<-------Please enter number of elements------->");
            int e = Convert.ToInt32(Console.ReadLine());
            
            ArrayList myArrayList = new ArrayList();
            LinkedList<int> myLinkedList = new LinkedList<int>();

            AddElements(myArrayList, myLinkedList, e);
            Console.WriteLine("<-------Please enter number of element for search------->");
            int s = Convert.ToInt32(Console.ReadLine());

            SearchElement(myArrayList, myLinkedList, s);

            DeleteElements(myArrayList, myLinkedList, e);
        }

        static void AddElements(ArrayList myArrayList,LinkedList<int> myLinkedList, int e)
        {
            // Array List
            DateTime StartArrayList = DateTime.Now;
            for (int i = 0; i < e; i++)
            {
                myArrayList.Add(i);                
            }

            //DateTime EndArrayList = DateTime.Now;
            TimeSpan resultArrayList = DateTime.Now - StartArrayList;
            Console.WriteLine("Time of adding {0} elements to ArrayList = {1} miliseconds", myArrayList.Count, resultArrayList.TotalMilliseconds.ToString());

            // Linked List
            
            DateTime StartLinkedList = DateTime.Now;
            for (int i = 0; i < e; i++)
            {
                myLinkedList.AddLast(i);
            }

           // DateTime EndLinkedList = DateTime.Now;
            TimeSpan resultLinkedList = DateTime.Now - StartLinkedList;
            Console.WriteLine("Time of adding {0} elements to LinkedList = {1} miliseconds", myLinkedList.Count, resultLinkedList.TotalMilliseconds.ToString());

            if (resultArrayList < resultLinkedList)
                Console.WriteLine("<-------ArrayList is faster than LinkedList------->\n");
            else if (resultArrayList == resultLinkedList)
                Console.WriteLine("<-------ArrayList and LinkedList are equal------->\n");
            else Console.WriteLine("<------LinkedList is faster than ArrayList------->\n");
        }

        static void DeleteElements(ArrayList myArrayList, LinkedList<int> myLinkedList, int e)
        {
            // Linked List
            DateTime StartLinkedList = DateTime.Now;
            for (int i = 0; i < e; i++)
            {
                myLinkedList.Remove(i);
            }
            DateTime EndLinkedList = DateTime.Now;
            TimeSpan resultLinkedList = EndLinkedList - StartLinkedList;
            Console.WriteLine("Time of removing {0} elements from LinkedList = {1} miliseconds", e, resultLinkedList.Milliseconds.ToString());

            // Array List
            DateTime StartArrayList = DateTime.Now;
            for (int i = 0; i < e; i++)
            {
                myArrayList.Remove(i);
            }

            DateTime EndArrayList = DateTime.Now;
            TimeSpan resultArrayList = EndArrayList - StartArrayList;
            Console.WriteLine("Time of removing {0} elements from ArrayList = {1} miliseconds", e, resultArrayList.Milliseconds.ToString());
            if (resultArrayList < resultLinkedList)
                Console.WriteLine("<-------ArrayList is faster than LinkedList------->\n");
            else if (resultArrayList == resultLinkedList)
                Console.WriteLine("<-------ArrayList and LinkedList are equal------->\n");
            else Console.WriteLine("<------LinkedList is faster than ArrayList------->\n");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }

        static void SearchElement(ArrayList myArrayList, LinkedList<int> myLinkedList, int s)
        {
            // Array List
            DateTime EndArrayList = DateTime.MaxValue;
            DateTime StartArrayList = DateTime.Now;
            for (int i = 0; i < myArrayList.Count; i++)
            {
               if (myArrayList.BinarySearch(50000) > -1)
                 EndArrayList = DateTime.Now;

            }

            TimeSpan resultArrayList = EndArrayList - StartArrayList;
            Console.WriteLine("Time of search {0} element in ArrayList = {1} miliseconds", s, resultArrayList.TotalMilliseconds.ToString());

            // Linked List

            DateTime StartLinkedList = DateTime.Now;
            LinkedListNode<int> t = myLinkedList.Find(s);
            
            TimeSpan resultLinkedList = DateTime.Now - StartLinkedList;
            Console.WriteLine("Time of search {0} element in LinkedList = {1} miliseconds", s, resultLinkedList.TotalMilliseconds.ToString());

            if (resultArrayList < resultLinkedList)
                Console.WriteLine("<-------ArrayList is faster than LinkedList------->\n");
            else if (resultArrayList == resultLinkedList)
                Console.WriteLine("<-------ArrayList and LinkedList are equal------->\n");
            else Console.WriteLine("<------LinkedList is faster than ArrayList------->\n");
        }

    }
}
