using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class Question
    {
        public int question_id { get; set; }
        public int survey_id { get; set; }

        public string question { get; set; }


        public Question(string question)
        {


            this.question = question;
        }



    }
}
