using System;

namespace LegacyApp
{
    public class User
    {
        // object Client;
        private string firstName;
        private string lastName;
        private string email;
        private DateTime dateOfBirth;
       // private int clientId;

        public User(Object c, string fn, string ln, string mail, DateTime dob)
        {
            this.Client = c;
            this.firstName = fn;
            this.lastName = ln;
            this.email = mail;
            this.dateOfBirth = dob;
         //   this.clientId = cid;
        }

        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }


        public bool CheckClientName()
        {
            bool status;
            if ((String.IsNullOrEmpty(this.firstName) == true) || (string.IsNullOrEmpty(this.lastName))==true)
            {
                status = false;
            }
            else
            {
                status = true;
            }
            return status;
        }
        public bool CheckMail()
        {
            bool status;
            if ((this.email.Contains("@") && !this.email.Contains("."))==true)
            {
                status = false;
            }
            else
            {
                status = true;
            }
            return status;
        }
        public bool CheckAge()
        {
            bool status;
            var now = DateTime.Now;
            int age = now.Year - this.dateOfBirth.Year;
            if (now.Month < this.dateOfBirth.Month || (now.Month == this.dateOfBirth.Month && now.Day < this.dateOfBirth.Day)) age--;
            if (age < 21)
            {
                status = false;
            }
            else status = true;
            return status;
        }
    }
}