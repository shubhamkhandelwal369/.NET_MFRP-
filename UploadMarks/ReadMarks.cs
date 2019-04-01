using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using DataAccess;


namespace UploadMarks
{
    public class ReadMarks
    {
        public static bool InsertMarks(string brr)
        {
            SqlParameter[] sq = new SqlParameter[4];
            using (StreamReader sr = new StreamReader(@brr))
            {
                while (sr.Peek() >= 0)
                {
                    string[] strArray = sr.ReadLine().Split(',');
                    SqlParameter sp = new SqlParameter("@Ass_id", int.Parse(strArray[0]));
                    DataSet ds = Connection.ViewSpecificDetails(sp);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        sq[0] = new SqlParameter("@Ass_id", int.Parse(strArray[0]));
                        sq[1] = new SqlParameter("@marks1", int.Parse(strArray[1]));
                        sq[2] = new SqlParameter("@marks2", int.Parse(strArray[2]));
                        sq[3] = new SqlParameter("@marks3", int.Parse(strArray[3]));
                        SqlCommand cmd = new SqlCommand("usp_insertmarks", Connection.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        Connection.con.Open();
                        cmd.Parameters.AddRange(sq);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            return false;
                        }
                        Connection.con.Close();
                    }
                    else
                    {
                        return false;
                    }
                }
                sr.Close();
                return true;
            }
        }
    }
}
