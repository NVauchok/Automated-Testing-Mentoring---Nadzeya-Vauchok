using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flower_Shop_Project.Flowers
{
    class Program

    {

        static void Main()
        {
            int min = 0;
            int max = 0;
            Bouquet bouquet = new Bouquet();

            bouquet.AddFlower(new Rose("Sentifolia", Color.Pink, 20));
            bouquet.AddFlower(new Rose("Romantika", Color.White, 12));
            bouquet.AddFlower(new Tulip("Prinses Irene", Color.Red, 10));
            bouquet.AddFlower(new Tulip("Sweetheart", Color.Yellow, 8));
            bouquet.AddFlower(new Gerbera("Gerbera Daisy", Color.Orange, 7));
            bouquet.AddFlower(new Gerbera("Gerbera Daisy", Color.Red, 7));
            bouquet.AddFlower(new Gerbera("Gerbera Daisy", Color.Yellow, 8));

            while (true)
            {
                Console.Clear();
                Console.WriteLine("----Menu----");
                Console.WriteLine("Please press any button to choose the next point of menu after receiving results of previous choice");
                Console.WriteLine();
                Console.WriteLine("[1] Display flowers in bouquet\n");
                Console.WriteLine("[2] Get bouquet price\n");
                Console.WriteLine("[3] Sort flowers in bouquet by price\n");
                Console.WriteLine("[4] Find flower by price\n");
                Console.WriteLine("[5] Write bouquet info text file\n");
                Console.WriteLine("[6] Read bouquet info from text file\n");
                Console.WriteLine("[7] Write bouquet info into binary file\n");
                Console.WriteLine("[8] Read bouquet info from binary file\n");
                Console.WriteLine("[9] Write flowers info json file\n");
                Console.WriteLine("[10] Read flowers from json file\n");
                Console.WriteLine("[11] DataBase - Insert data into Employees table\n");
                Console.WriteLine("[12] DataBase - Update data in Employees table\n");
                Console.WriteLine("[13] DataBase - Select data from Employees table\n");
                Console.WriteLine("[14] DataBase - Delete data from Employees table\n");
                Console.WriteLine("[15] DataBase - ExecuteStoredProcedureSalesByCategory\n");

                Console.WriteLine("[16] Exit\n");

                string menunav = Console.ReadLine();
                int menuint;
                bool menubool = int.TryParse(menunav, out menuint);

                if (menubool == false)
                {
                    Console.WriteLine("An error has occurred");  //string is not an int

                }

                if (menuint > 16 || menuint < 1)
                {
                    Console.WriteLine("\nThe selection has to be between 1 and 16, please re-enter your selection");
                }
                int pauseTime = 3000;
                System.Threading.Thread.Sleep(pauseTime);
                switch (menuint)
                {
                    case 1: bouquet.DisplayBouquet(); break;
                    case 2: bouquet.GetBouquetPrice(); break;
                    case 3: bouquet.SortFlowersByPrice(); break;
                    case 4:
                        Console.WriteLine("Please enter integer min price");
                        
                             min = Convert.ToInt32(Console.ReadLine());
                             if (min <= 0)
                             {
                                 throw (new MyException("Price cannot be negative or zero"));
                             }
                             else{

                                 Console.WriteLine("Please enter integer max price");
                                 max = Convert.ToInt32(Console.ReadLine());
                                 if (max <= 0)
                                 {
                                     throw (new MyException("Price cannot be negative or zero"));
                                 }
                                 else if (max < min)
                                 {
                                     throw (new MyException("Min should be less than max"));

                                 }
                                 else
                                 {
                                     bouquet.FindFlowerByPrice(min, max);
                                 }
                             }                        
                        break;
                    case 5: bouquet.WriteBouquetInfoToTextFile(); break;
                    case 6: bouquet.ReadBouquetInfoFromTextFile(); break;
                    case 7: bouquet.WriteToBinaryFile(); break;
                    case 8: bouquet.ReadFromBinaryFile(); break;
                    case 9: bouquet.JsonSerialize(); break;
                    case 10: bouquet.JsonDeserialize(); break;
                    case 11: bouquet.InsertDataIntoEmployees(); break;
                    case 12: bouquet.UpdateDataInEmployees(); break;
                    case 13: bouquet.SelectDataFromEmployees(); break;
                    case 14: bouquet.DeleteDataFromEmployees(); break;
                    case 15: bouquet.ExecuteStoredProcedureSalesByCategory(); break;
                    case 16: Environment.Exit(0); break;

                }
                Console.ReadKey();
            }
        }


        [Serializable]
        public class MyException : ApplicationException
        {
            
            public MyException() { }
            public MyException(string message) : base(message) { }
            public MyException(string message, Exception ex) : base(message, ex) { }
            // Конструктор для обработки сериализации типа
            protected MyException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext contex)
                : base(info, contex) { }


            
        }
 
    }
}
