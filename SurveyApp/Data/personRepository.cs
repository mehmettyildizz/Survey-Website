using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SurveyApp.Models;

namespace SurveyApp.Data
{
    public static class personRepository
    {

        private static string connectionString;
        private static SqlConnection connection;
        private static SqlCommand command;

        public static List<string> allEmails = null;

        public static Person loginPerson;
        public static void connectToDatabase()
        {
            connectionString = "Data Source=DESKTOP-0AIPCBK\\SQLEXPRESS01;Database=survey_database;Trusted_Connection=True;MultipleActiveResultSets=true";
            connection = new SqlConnection(connectionString);

        }


        public static void registerPerson(Person p)
        {

            try
            {
                connectToDatabase();
                connection.Open();


                command = new SqlCommand("INSERT INTO person (email,password,firstname,lastname) VALUES(@email, @password,@name, @surname)", connection);
                
                command.Parameters.AddWithValue("@email", p.userEmail);
                command.Parameters.AddWithValue("@password", p.userPassword);
                command.Parameters.AddWithValue("@name", p.userFirstName);
                command.Parameters.AddWithValue("@surname", p.userLastName);
                

                int result = command.ExecuteNonQuery();

                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }




        }

        public static List<string> getAllEmailsFromDatabase()
        {
            connectToDatabase();

            allEmails = new List<string>();

            command = new SqlCommand("SELECT email FROM person", connection);


            SqlDataReader reader;
            try
            {


                
                connection.Open();
               
                reader = command.ExecuteReader();

               


                while (reader.Read()) 
                {
                    
                    allEmails.Add(Convert.ToString(reader[0]));
                }

                reader.Close(); 
            }
            
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            finally
            {
                connection.Close();
            }



            return allEmails;

        }

        public static Person LoginAuthorization(Person person)
        {

            connectToDatabase();
            string query = "SELECT * FROM person where email=@email AND password=@password";

            SqlCommand comm = new SqlCommand(query, connection);

            comm.Parameters.AddWithValue("@email", person.userEmail);
            comm.Parameters.AddWithValue("@password", person.userPassword);

            SqlDataReader reader;
            try
            {

                
                connection.Open();
               
                reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    loginPerson = new Person(Convert.ToInt32(reader[0]), Convert.ToString(reader[1])
                    , Convert.ToString(reader[2]), Convert.ToString(reader[3]),
                   Convert.ToString(reader[4]));


                }
                else
                {
                    loginPerson = null;
                }

                reader.Close();
            }
           
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            finally
            {
                connection.Close();
            }

            return loginPerson;
        }
        








    }
}