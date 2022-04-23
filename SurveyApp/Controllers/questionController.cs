using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyApp.Models;
using System.Data.SqlClient;
using SurveyApp.Data;
using System.Data;
using SurveyApp.Controllers;

namespace SurveyApp.Controllers
{
    public class questionController : Controller

    {
        public IActionResult Index()
        {



            return View(getsurveyName());
        }



        public static List<Survey> getsurveyName()
        {

            string connectionString = "Data Source=DESKTOP-0AIPCBK\\SQLEXPRESS01;Database=survey_database;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlConnection connection = new SqlConnection(connectionString);


            List<Survey> allSurveyNames = new List<Survey>();
            surveyRepository.getAllSurveyNamesFromDatabase();

            SqlCommand command = new SqlCommand("SELECT DISTINCT * FROM survey", connection);
            
            //SqlCommand command = new SqlCommand("SELECT * FROM survey", connection);


            SqlDataReader reader;
            try
            {



                connection.Open();

                reader = command.ExecuteReader();




                while (reader.Read())
                {

                    Survey sur = new Survey(Convert.ToInt32(reader[0]),Convert.ToInt32(reader[1]), Convert.ToString(reader[2]));
                    allSurveyNames.Add(sur);
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



            return allSurveyNames;

        }



    }

       


    }
