using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;
using System.Data.SqlClient;


namespace PercentageCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection.con.Open();
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter data = new SqlDataAdapter("usp_ComputeAll", Connection.con);
                data.Fill(ds);
                Connection.con.Close();
            }
            catch (Exception e) { throw e; }
            finally
            {
                Connection.con.Close();
            }
            Console.WriteLine("{0,-25}{1,-25}{2,-25}{3,-25}","Associate ID","Name","Score","Percentage Secured");
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Console.Write("{0,-25}{1,-25}{2,-25:0.00}{3,-25:0.00}", item["Associate_ID"], item["Name"], item["Score"], item["Percentage Secured"]);
                Console.WriteLine();
            }
        }
    }
}
