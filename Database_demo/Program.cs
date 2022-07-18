using System;
using System.Data.SqlClient;
using System.Security;

namespace Database_demo
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            bool x;
            char [] pass=new char[10];
            int[] id=new int[10];
            int[] sal=new int[10];
            string[] name=new string[10];
            string[] depart=new string[10];
            string connection_string= @"Data Source=.;Initial Catalog=employee;Integrated Security=True";


            //maskinput();


            
            Console.Write("Enter The Password : ");
            

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                
                
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    
                    Console.Write("*");
                    

                }
                else if(ConsoleKey.Enter==keyInfo.Key)
                {
                    
                    break;
                }
            } while (true);

            Console.WriteLine();
            try
            {
               SqlConnection conn = new SqlConnection(connection_string);
                Console.WriteLine("Connection has Sucessfully built");
                Console.WriteLine("Press enter to continue");
                Console.ReadKey();
                Console.Clear();
                conn.Open();

                Console.WriteLine("how many emplooyee details you want to store??");
                int num_of_emp=int.Parse(Console.ReadLine());
                
                for(int i=0;i<num_of_emp;i++)
                {
                    int emp = 1 + i;
                    Console.WriteLine($"Employee : {emp}");
                    Console.Write("\nEnter The Id : ");
                    id[i]=int.Parse(Console.ReadLine());
                    Console.Write("\nEnter The Name : ");
                    name[i] = Console.ReadLine();
                    Console.Write("\nEnter The Department : ");
                    depart[i] = Console.ReadLine();
                    Console.Write("\nEnter The Salary : ");
                    sal[i] = int.Parse(Console.ReadLine());
                    Console.Clear();

                    
                }
                for (int i = 0; i < num_of_emp; i++)
                {

                    string inserting = $"INSERT INTO INFO(ID,Name_emp,Department,Salary) VALUES({id[i]},'{name[i]}','{depart[i]}',{sal[i]})";
                    SqlCommand ic = new SqlCommand(inserting,conn);
                    ic.ExecuteNonQuery();
                    x = true;
                }

                Console.Clear();
                Console.WriteLine("All Entries Has Been Store Into Quarry");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }

        private static void maskinput()
        {
            Console.Write("Enter Your Password : ");
            SecureString pass = new SecureString();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    pass.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                    Console.Write("%");

                }
            } while (keyInfo.Key != ConsoleKey.Enter);
    


        }


    }
}
