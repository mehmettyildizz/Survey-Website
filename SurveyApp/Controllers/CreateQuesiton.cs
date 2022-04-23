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
    public class CreateQuesiton : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Name, String soru)
        {

            string connectionString = "Data Source=DESKTOP-0AIPCBK\\SQLEXPRESS01;Database=survey_database;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlConnection connection = new SqlConnection(connectionString);

          
            Survey survey = new Survey(Name);
            surveyRepository.SurveyAuthorization(survey);
            surveyRepository.getAllSurveyNamesFromDatabase();
            if (!surveyRepository.allSurveyNames.Contains(Name))
            {
                TempData["survey"] = "Wrong survey";

            }
            else { 


            int survey_id = surveyRepository.loginsurvey.survey_id;

            string s2 = "Insert Into survey_question (question_survey_id,question) values (@survey_id,@question)";


            SqlCommand sqlcomm1 = new SqlCommand(s2, connection);
            sqlcomm1.Connection = connection;
            connection.Open();


            sqlcomm1.Parameters.AddWithValue("@survey_id", survey_id);
            sqlcomm1.Parameters.AddWithValue("@question", soru);

            sqlcomm1.ExecuteNonQuery();

            connection.Close();
}
            return View();

        }
    }
}
