using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace Flower_Shop_Project.Flowers
{
    public class Bouquet
    {
        public ICollection<Flower> flowers = new List<Flower>();
        public JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        string txtPath = @"d:\Bouquet.txt";
        string binPath = @"d:\Bouquet.dat";
        string jsonPath = @"d:\Flowers.json";

        string connectionString = @"Data Source=EPBYMINW0324\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";

        public void DisplayBouquet()
        {
            Console.WriteLine("Your bouquet:");
            foreach (Flower f in flowers)
            {
                Console.WriteLine(f.ToString());
            }
        }
        public void AddFlower(Flower f)
        {
            flowers.Add(f);
            Console.WriteLine("Flower has been added to your bouquet - {0} ", f.ToString());
           
        }

        public void FindFlowerByPrice(int min, int max)
        {
            //flowers.Where(x => (x.Price >= min) && (x.Price <= max)).ToList();
            //Console.WriteLine(flowers.ToString());
            int count = 0;
            foreach (Flower f in flowers.Where(x => (x.price >= min) && (x.price <= max)))
            {
                count++;
                Console.WriteLine("Found the flower {0}",f.ToString());
            }
            if (count == 0) Console.WriteLine("There ara no flowers matching your criteria");
        }

        public void SortFlowersByPrice()
        {
            Console.WriteLine("\nBefore sort:");
            foreach (Flower f in flowers)
            {
                Console.WriteLine(f.ToString());
            }


            var temp = flowers.OrderBy(x => x.price).ToList();
            flowers.Clear();
            foreach (var c in temp)
            {
                flowers.Add(c);

            }

            Console.WriteLine("\nAfter sort by price:");
            foreach (Flower f in flowers)
            {
                Console.WriteLine(f.ToString());
            }
        }

        public void GetBouquetPrice()
        {
            Console.WriteLine("Bouquet total price is {0}", flowers.Sum(x => x.price).ToString());
        }

        public void WriteBouquetInfoToTextFile()
        {
           try
           {
               // Создание файла и запись в него
                using (StreamWriter sw = new StreamWriter(txtPath, false))
                {
                    sw.WriteLine("Flowers in bouquet:");
                    foreach (Flower f in flowers)
                    {
                        sw.WriteLine(f.ToString());
                    }
                    sw.Close();
                    Console.WriteLine("File {0} was created/updated", txtPath);
                }
           }
           catch (IOException)
           {
               Console.WriteLine("File error!");
           }

        }

        public void ReadBouquetInfoFromTextFile()
        {
            if(File.Exists(txtPath))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(txtPath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }

                        sr.Close();
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("File error!");
                }
            }
                else 
                {
                    Console.WriteLine("File {0} does not exist",txtPath);
                }
        }

        public void WriteToBinaryFile()
        {
            FileStream writer = null;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (writer = new FileStream(binPath, FileMode.OpenOrCreate))
                {
                    foreach (Flower f in flowers)
                    {
                        formatter.Serialize(writer, f);

                    }
                        Console.WriteLine("Objects serialized to {0}", binPath);
                        writer.Close();                       
                    }
            }
            catch (IOException)
            {
                Console.WriteLine("File error!");
            }
            finally
            {
                writer.Close();
            }
            
        }


        public void ReadFromBinaryFile()
        {
            if(File.Exists(binPath))
            {
                FileStream fs = null;
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                try
                {

                    using (fs = new FileStream(binPath, FileMode.Open, FileAccess.Read))
                    {
                        Flower f = null;
                        long position = 0;
                        while (position < fs.Length)
                        {
                            fs.Seek(position, SeekOrigin.Begin);
                            f = (Flower)formatter.Deserialize(fs);
                            position = fs.Position;
                            Console.WriteLine(f.ToString());
                        }
                        Console.WriteLine("Objects deserialized");
                    }
                    
                }
                catch (IOException)
                {
                    Console.WriteLine("File error!");
                }
                finally
                {
                    fs.Close();
                }
                
            }
            else
            {
                Console.WriteLine("File {0} does not exist", binPath);
            }

        }


        public void JsonSerialize()
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(flowers, settings);
                StreamWriter sw = new StreamWriter(jsonPath);
                sw.WriteLine(jsonString);
                sw.Close();
                Console.WriteLine("Json - Objects serialized to {0}", jsonPath);
            }
            catch (JsonException)
            {
               Console.WriteLine("Json Serialize Exception");
            }
        }

        public void JsonDeserialize()
        {
            try
            {
                using (StreamReader r = new StreamReader(jsonPath))
                {
                    string json = r.ReadToEnd();
                    flowers = JsonConvert.DeserializeObject<List<Flower>>(json, settings);
                    foreach (Flower f in flowers)
                    {
                        Console.WriteLine(f.ToString());
                    }
                }
            }
            catch (JsonException)
            {
                Console.WriteLine("Json Deserialize Exception");
            }

        }

        public void InsertDataIntoEmployees()
        {
            using (var myConnection = new SqlConnection())
            {
                Console.WriteLine("Connection object:" + myConnection.GetType().Name);
                myConnection.ConnectionString = connectionString;

                //open connection
                try
                {
                    myConnection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot connect to DataBase. Details: " + e.ToString());
                }

                try
                {
                    int numberOfAffectedRows = 0;
                    SqlCommand insertCommand = new SqlCommand("Insert into Employees(LastName, FirstName, City) values ('Cayman', 'Joe', 'Minsk');", myConnection);
                    insertCommand.ExecuteNonQuery();
                    numberOfAffectedRows = insertCommand.ExecuteNonQuery();
                    Console.WriteLine("-----Results of INSERT command-----");
                    Console.WriteLine("Number of affected rows: " + numberOfAffectedRows);
                    Console.WriteLine("\n");
                }

                catch (Exception e)
                {
                    Console.WriteLine("Cannot execute INSERT command: " + e.ToString());
                }
                finally { myConnection.Close(); }
            }

        }

        public void UpdateDataInEmployees()
        {
            using (var myConnection = new SqlConnection())
            {
                Console.WriteLine("Connection object:" + myConnection.GetType().Name);
                myConnection.ConnectionString = connectionString;

                //open connection
                try
                {
                    myConnection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot connect to DataBase. Details: " + e.ToString());
                }
                try
                {
                    int numberOfAffectedRows = 0;
                    SqlCommand updateCommand = new SqlCommand("UPDATE Employees SET FirstName = 'Jody', City = 'New York' WHERE LastName='Cayman' AND FirstName='Joe';", myConnection);
                    numberOfAffectedRows = updateCommand.ExecuteNonQuery();
                    Console.WriteLine("-----Results of UPDATE command-----");
                    Console.WriteLine("Number of affected rows: " + numberOfAffectedRows);
                    Console.WriteLine("\n");
                }

                catch (Exception e)
                {
                    Console.WriteLine("Cannot execute UPDATE command: " + e.ToString());
                }
                finally { myConnection.Close(); }
            }

        }

        public void SelectDataFromEmployees()
        {
            using (var myConnection = new SqlConnection())
            {
                Console.WriteLine("Connection object:" + myConnection.GetType().Name);
                myConnection.ConnectionString = connectionString;

                //open connection
                try
                {
                    myConnection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot connect to DataBase. Details: " + e.ToString());
                }


                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand selectCommand = new SqlCommand("Select top 5 * from Employees order by EmployeeID desc;", myConnection);
                    myReader = selectCommand.ExecuteReader();
                    Console.WriteLine("-----Results of SELECT command-----");
                    while (myReader.Read())
                    {

                        Console.WriteLine("EmployeeID: " + myReader["EmployeeID"].ToString());
                        Console.WriteLine("First Name: " + myReader["FirstName"].ToString());
                        Console.WriteLine("Last Name: " + myReader["LastName"].ToString());
                        Console.WriteLine("City: " + myReader["City"].ToString());
                        Console.WriteLine("\n");

                    }
                    myReader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot execute  SELECT command: " + e.ToString());
                }
                finally { myConnection.Close(); }
            }
        }

        public void DeleteDataFromEmployees()
        {
            using (var myConnection = new SqlConnection())
            {
                Console.WriteLine("Connection object:" + myConnection.GetType().Name);
                myConnection.ConnectionString = connectionString;

                //open connection
                try
                {
                    myConnection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot connect to DataBase. Details: " + e.ToString());
                }

                int numberOfAffectedRows = 0;
                try
                {
                    SqlCommand deleteCommand = new SqlCommand("Delete from Employees where LastName = 'Cayman' ", myConnection);
                    numberOfAffectedRows = deleteCommand.ExecuteNonQuery();
                    Console.WriteLine("-----Results of DELETE command-----");
                    Console.WriteLine("Number of affected rows: " + numberOfAffectedRows);
                    Console.WriteLine("\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot execute  DELETE command: " + e.ToString());
                }
                finally { myConnection.Close(); }
            }
        }

        public void ExecuteStoredProcedureSalesByCategory()
        {
            using (var myConnection = new SqlConnection())
            {
                Console.WriteLine("Connection object:" + myConnection.GetType().Name);
                myConnection.ConnectionString = connectionString;

                //open connection
                try
                {
                    myConnection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot connect to DataBase. Details: " + e.ToString());
                }
                var Employees = new DataTable();
                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand storedProcedure = new SqlCommand("SalesByCategory", myConnection);
                    storedProcedure.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@CategoryName", SqlDbType.NVarChar, 15);
                    SqlParameter param2 = new SqlParameter("@OrdYear", SqlDbType.NVarChar, 4);
                    param1.Value = "Produce";
                    param2.Value = "1996";
                    storedProcedure.Parameters.Add(param1);
                    storedProcedure.Parameters.Add(param2);
                    myReader = storedProcedure.ExecuteReader();

                    Console.WriteLine("-----Results of Stored procedure-----");
                    while (myReader.Read())
                    {

                        Console.WriteLine("Product Name: " + myReader["ProductName"].ToString());
                        Console.WriteLine("Total Purchase: " + myReader["TotalPurchase"].ToString());
                        Console.WriteLine("\n");
                    }
                    myReader.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot execute  Stored Procedure: " + e.ToString());
                }
                finally { myConnection.Close(); }
            }
        }


    }
}
