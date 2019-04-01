using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using DataAccess;

namespace UploadRank
{
    public class ReadRank
    {
        public static bool InsertRank(string brr)
        {
            SqlParameter[] sq = new SqlParameter[7];
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
                        sq[1] = new SqlParameter("@first", int.Parse(strArray[1]));
                        sq[2] = new SqlParameter("@second", int.Parse(strArray[2]));
                        sq[3] = new SqlParameter("@third", int.Parse(strArray[3]));
                        sq[4] = new SqlParameter("@fourth", int.Parse(strArray[4]));
                        sq[5] = new SqlParameter("@fifth", int.Parse(strArray[5]));
                        sq[6] = new SqlParameter("@sixth", int.Parse(strArray[6]));
                        SqlCommand cmd = new SqlCommand("usp_insertrank", Connection.con);
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
