using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyApp.Models;
using System.Data.SqlClient;
using SurveyApp.Data;
using System.Data;


namespace SurveyApp.Controllers
{
    public class questionSolving : Controller
    {
       
        public IActionResult Index(int id)
        {


            return View(getquestion(id));
        }


        public static List<Question> getquestion(int id)
        {

            string connectionString = "Data Source=DESKTOP-0AIPCBK\\SQLEXPRESS01;Database=survey_database;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlConnection connection = new SqlConnection(connectionString);
            List<Question> question= new List<Question>();
           

            SqlCommand command = new SqlCommand("SELECT question FROM survey_question WHERE question_survey_id="+id, connection);


            SqlDataReader reader;
            try
            {
                connection.Open();

                reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Question que = new Question(Convert.ToString(reader[0]));
                    question.Add(que);
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



            return question;

        }



    }


}

