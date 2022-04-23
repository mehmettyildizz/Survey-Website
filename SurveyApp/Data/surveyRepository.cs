using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SurveyApp.Models;

namespace SurveyApp.Data
{

    public static class surveyRepository
    {

        private static string connectionString;
        private static SqlConnection connection;
        private static SqlCommand command;

        public static List<string> allSurveyNames;

        public static Survey loginsurvey;
        public static void connectToDatabase()
        {
            connectionString = "Data Source=DESKTOP-0AIPCBK\\SQLEXPRESS01;Database=survey_database;Trusted_Connection=True;MultipleActiveResultSets=true";
            connection = new SqlConnection(connectionString);

        }

       public static Survey SurveyAuthorization(Survey survey)
        {

            connectToDatabase();
            string query = "SELECT * FROM survey where survey_name=@survey_name";

            SqlCommand comm = new SqlCommand(query, connection);

            

          
           comm.Parameters.AddWithValue("@survey_name", survey.survey_name);
            

            SqlDataReader reader;
            try
            {


                connection.Open();

                reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    loginsurvey = new Survey(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1])
                    , Convert.ToString(reader[2]));
                   


                }
               
                reader.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            finally
            {
                connection.Close();
            }

            return loginsurvey;
        }
        public static List<string> getAllSurveyNamesFromDatabase()
        {
            connectToDatabase();

            allSurveyNames = new List<string>();

            command = new SqlCommand("SELECT survey_name FROM survey", connection);


            SqlDataReader reader;
            try
            {



                connection.Open();

                reader = command.ExecuteReader();




                while (reader.Read()) 
                {

                    allSurveyNames.Add(Convert.ToString(reader[0]));
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



            return allSurveyNames;

        }
      
        







    }
}