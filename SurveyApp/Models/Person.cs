using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class Person
    {
        public  int userId { get; set; }
        public string userEmail { get; set; }

        public string userPassword { get; set; }

        public string userFirstName { get; set; }

        public string userLastName { get; set; }

        public  Person(int userId,string userEmail,string userPassword,string userFirstName,string userLastName)
        {
            this.userId=userId;
            this.userEmail=userEmail;
            this.userPassword=userPassword;
            this.userFirstName=userFirstName;
            this.userLastName=userLastName;
        }
        public Person(string userEmail,string userPassword,string userFirstName,string userLastName)
        {
            
            this.userEmail=userEmail;
            this.userPassword=userPassword;
            this.userFirstName=userFirstName;
            this.userLastName=userLastName;
        }

        public Person(string userEmail,string userPassword)
        {
            
            this.userEmail=userEmail;
            this.userPassword=userPassword;
            
        }
    }
}