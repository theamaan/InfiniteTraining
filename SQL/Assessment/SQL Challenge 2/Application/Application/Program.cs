using System;
using System.Data;
using System.Data.SqlClient;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=ICS-LT-H3J9R73\SQLEXPRESS;Initial Catalog=Employeemanagement;Integrated Security=True;";
            string query = "exec addNewRows @EmpName = 'Viraj Dobriayl', @Empsal = 45000.0, @Emptype = 'F';";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    string selectQuery = "SELECT * FROM Employee_Details";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "Employee_Details");
                        DataTable table = dataSet.Tables["Employee_Details"];
                        foreach (DataRow row in table.Rows)
                        {
                            foreach (DataColumn column in table.Columns)
                            {
                                Console.Write(row[column] + "\t");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.ReadLine();
        }
    }
}
