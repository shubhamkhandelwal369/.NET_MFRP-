using System;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace DataAccess
{
    public class Connection
    {
        public static SqlConnection con = new SqlConnection("Data Source=PC252242;Initial Catalog=ABC_Technologies_Solution;Persist Security Info=True;User ID=sa;Password=password-1");

        public static void InsertDetails(SqlParameter[] sq)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_insertass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddRange(sq);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e) { throw e; }
            finally
            {
                con.Close();
            }
        }
        public static DataSet ViewAllDetails()
        {
            con.Open();
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter data = new SqlDataAdapter("usp_viewall_ass", con);
                data.Fill(ds);
                con.Close();
            }
            catch (Exception e) { throw e; }
            finally
            {
                con.Close();
            }
            return ds;
        }
        public static DataSet ViewSpecificDetails(SqlParameter sq)
        {
            con.Open();
            DataSet ds = new DataSet();
            
            try
            {
                
                
               SqlCommand cmd = new SqlCommand("usp_viewass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(sq);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
               // da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
            }
            catch (Exception e)
            {
                //throw e;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public static void DelSpecificDetails(SqlParameter sq)
        {
            con.Open();         
            try
            {
                SqlCommand cmd = new SqlCommand("usp_deleteass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(sq);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                //throw e;
            }
            finally
            {
                con.Close();
            }
        }
        public static void EditSpecificDetails(SqlParameter[] sq)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddRange(sq);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e) { //throw e; 
            }
            finally
            {
                con.Close();
            }
        }
    }
}
