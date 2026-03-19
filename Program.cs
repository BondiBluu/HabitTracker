using System;
using Microsoft.Data.Sqlite;

namespace HabitTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            //using a string to connect to the database (the string has information about the data source)
            string connectionString = @"Data Source=habit-Tracker.db";

            //getting an instance of the sqlite connection class (providd by a library we'll bring in)
            using(var connection = new SqliteConnection(connectionString))
            {
                //open connecttion
                connection.Open();

                //create a command to send to the database
                var tableCmd = connection.CreateCommand();

                //this command is a command text that creates a sql database
                tableCmd.CommandText = 
                @"CREATE TABLE IF NOT EXISTS drinking_water (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT,
                    Quantity INTEGER
                    )";

                //executing the command, doesn't let the database return any values, we're just telling it to create a table
                tableCmd.ExecuteNonQuery();

                //close the connection
                connection.Close();
                
            }

            GetUserInput();

        }


        //ask the user what they want to do
        static void GetUserInput()
        {
            bool closeApp = false;

            //keep going if the user didn't ask to close the app
            while(closeApp == false)
            {
                Console.WriteLine("\n\n Main Menu");
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("\nType 0 to Close Application");
                Console.WriteLine("\nType 1 to Veiw All Records");
                Console.WriteLine("\nType 2 to Insert Record");
                Console.WriteLine("\nType 3 to Delete Record");
                Console.WriteLine("\nType 4 to Update Record");
                Console.WriteLine("-----------------------------------------------\n");

                string commandInput = Console.ReadLine();

                //whatever corresponding number is chosen, execute that
                switch (commandInput)
                {
                    case "0":
                        Console.WriteLine("\nGoodbye!\n");
                        Console.ReadLine();
                        closeApp = true;
                        break;
                    case "1":
                        GetAllRecords();
                        break;
                    case "2":
                        Insert();
                        break;
                    case "3":
                        Delete();
                        break;
                    case "4":
                        Update();
                        break;
                    default:
                    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
                    break;
                }
            }
        }

        static void GetAllRecords()
        {
            Console.WriteLine(@"Getting Records");
        }
        private static void Insert()
        {
            
            string date = GetDateInput();

            int quantity = GetNumberInput(@"\n\n Please insert number or glasses or other measure of your choice (no)
            decimals allowed\n\n");
        }

        //asking the user to put in the date in a certain format
        internal static string GetDateInput()
        {
            Console.WriteLine("\n\nPlease insert the date: (Format: dd-mm-yy). Type 0 to return to the main menu");

            string dateInput = Console.ReadLine();

            //if user inputs 0, go back to the choice menu
            if(dateInput == "0")
            {
                GetUserInput();
            }
            
            return dateInput;
        }

        internal static int GetNumberInput(string message)
        {
            return 0;
        }

        static void Delete()
        {
            Console.WriteLine(@"Deleting Records");
        }
        static void Update()
        {
            Console.WriteLine(@"Updating Records");
        }


    }
}