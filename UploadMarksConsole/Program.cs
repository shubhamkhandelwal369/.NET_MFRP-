using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadMarks;

namespace UploadMarksConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the File Path(.txt): ");
            string brr = Console.ReadLine();
            if (ReadMarks.InsertMarks(brr))
            {
                Console.WriteLine("Inserted Successfully");
            }
            else
            {
                Console.WriteLine("Error Inserting Marks!!");
            }
        }
    }
}
