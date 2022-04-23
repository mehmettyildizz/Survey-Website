using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyApp.Models;
using System.Data.SqlClient;
using SurveyApp.Data;


namespace SurveyApp.Controllers
{
    public class createsurveyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Name)
        {
           
           string connectionString = "Data Source=DESKTOP-0AIPCBK\\SQLEXPRESS01;Database=survey_database;Trusted_Connection=True;MultipleActiveResultSets=true";
           SqlConnection connection = new SqlConnection(connectionString);


            surveyRepository.getAllSurveyNamesFromDatabase();
            if (surveyRepository.allSurveyNames.Contains(Name))
            {
                TempData["alread_had_survey"] = "This survey name is already taken";

            }

            else { 
            int person_id = personRepository.loginPerson.userId;
          
                string s1 = "Insert Into survey (survey_person_id,survey_name) values (@person_id,@survey_name)";
                SqlCommand sqlcomm = new SqlCommand(s1,connection);
                sqlcomm.Connection = connection;
                connection.Open();

                sqlcomm.Parameters.AddWithValue("@person_id", person_id);
                sqlcomm.Parameters.AddWithValue("@survey_name", Name);
                
                sqlcomm.ExecuteNonQuery();

                connection.Close();
             /*   Survey survey = new Survey(Name);
                surveyRepository.SurveyAuthorization(survey);

                System.Diagnostics.Debug.WriteLine(surveyRepository.loginsurvey.survey_id);
                int survey_id= surveyRepository.loginsurvey.survey_id;

                string s2 = "Insert Into survey_question (question_survey_id,question) values (@survey_id,@question)";

            
                SqlCommand sqlcomm1 = new SqlCommand(s2, connection);
                sqlcomm1.Connection = connection;
                connection.Open();




                sqlcomm1.Parameters.AddWithValue("@survey_id", survey_id);
                sqlcomm1.Parameters.AddWithValue("@question", soru);

                sqlcomm1.ExecuteNonQuery();

                connection.Close();*/

            

            //eğer anket ismi daha önce kullanılmışsa.
            
             
            
                //return RedirectToAction("Login");

          }  
                
            
            return View();

        }
       

    }
}
