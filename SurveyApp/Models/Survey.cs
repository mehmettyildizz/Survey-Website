using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class Survey
    {
        
        public int survey_id { get; set; }
       
        public int survey_person_id { get; set; }

        public string survey_name { get; set; }



        public Survey(int survey_id, int survey_person_id, string survey_name)
        {
            this.survey_id = survey_id;
            this.survey_person_id = survey_person_id;
            this.survey_name = survey_name;
        }



        public Survey(string survey_name)
        {
            
           
            this.survey_name = survey_name;
        }







    }
}