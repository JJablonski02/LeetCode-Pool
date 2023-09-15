using LeetCode;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace OfficeProgrammingWalkthruComplete
{
    class Walkthrough
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Insert string: ");
                string input = Console.ReadLine();

                TasksGroup1.Solution10 solution10 = new TasksGroup1.Solution10();
                Console.WriteLine(solution10.isPalindrome(input));
            }
            while (!Console.ReadKey().Equals(ConsoleKey.Escape));
        }
        //static void Main(string[] args)a
        //{
        //    // Create a list of accounts.
        //    var bankAccounts = new List<Account>
        //    {
        //        new Account {
        //                      ID = 345678,
        //                      Balance = 541.27
        //                    },
        //        new Account {
        //                      ID = 1230221,
        //                      Balance = -127.44
        //                    }
        //    };

        //    // Display the list in an Excel spreadsheet.
        //    DisplayInExcel(bankAccounts);
            

        //}

        //static void DisplayInExcel(IEnumerable<Account> accounts)
        //{
        //    var excelApp = new Excel.Application();
        //    excelApp.Visible= true;
        //}

        //public class Account
        //{
        //    public int ID { get; set; }
        //    public double Balance { get; set; }
        //}
    }
}