using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {

        static void Main(string[] args)
        {
            IDbConnection conn = new SqlConnection("Data Source=SQL5105.site4now.net;Initial Catalog=db_a7d3c0_opendi;User Id=db_a7d3c0_opendi_admin;Password=qwerty20039");
            var connection = new SqlConnection("Data Source=SQL5105.site4now.net;Initial Catalog=db_a7d3c0_opendi;User Id=db_a7d3c0_opendi_admin;Password=qwerty20039");
            List<Notes> notes = new List<Notes>();
            Notes noteInsert = new Notes();
            string Choice;
            string sql;
            while (true)
            {
                Console.WriteLine("Show [1]\nInsert [2]\nDelete [3]");
                Choice = Console.ReadLine();
                if (Choice.Contains("1"))
                {
                    Console.Clear();

                    notes = conn.Query<Notes>("SELECT * FROM [Notes]").ToList();


                    foreach (var item in notes)
                    {
                        Console.WriteLine(item);
                    }
                }
                if (Choice.Contains("2"))
                {
                    Console.WriteLine("Enter Title");
                    noteInsert.Title = Console.ReadLine();
                    Console.WriteLine("Enter body");
                    noteInsert.Body = Console.ReadLine();
                    noteInsert.CreationDate = DateTime.Now.Date;

                    try
                    {
                        sql = "INSERT INTO Notes Values (@Title,@Body,@CreationDate);";

                        connection.Open();

                        var affectedRows = connection.Execute(sql, new { Title = noteInsert.Title, Body = noteInsert.Body, CreationDate = noteInsert.CreationDate });
                        Console.WriteLine(affectedRows);

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                if (Choice.Contains("3"))
                {
                    Console.Clear();
                    notes = conn.Query<Notes>("SELECT * FROM [Notes]").ToList();
                    foreach (var item in notes)
                    {
                        Console.WriteLine(item);
                    }
                    int id = 0;
                    bool check = false;
                    sql = "DELETE FROM Notes WHERE ID = @ID";

                    Console.WriteLine("Enter id to del");
                    do
                    {
                        try
                        {
                            id = int.Parse(Console.ReadLine());
                            check = true;
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Enter numb!");
                            check = false;
                        }
                    } while (!check);
                    connection.Execute(sql, new { ID = id });
                    Console.Clear();
                    Console.WriteLine("After Delete");
                    notes = conn.Query<Notes>("SELECT * FROM [Notes]").ToList();
                    foreach (var item in notes)
                    {
                        Console.WriteLine(item);
                    }

                }
            }

        }
    }
}
