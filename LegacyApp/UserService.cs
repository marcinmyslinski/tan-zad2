using Microsoft.VisualBasic;
using System;

namespace LegacyApp
{
    public class UserService
    {
        //AddUser_ShouldAddUserCorrectly
        //AddUser_ShouldFail_IncorrectEmail
        String fn;
        String ln;
        String mail;
        DateTime dob;
        int cid;
     

        //SOLID
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            fn = firstName;
            ln = lastName;
            mail = email;
            dob = dateOfBirth;
            cid = clientId;
            // utworzebie obiektu client
            Client c = new Client(cid);
           
            // utowrzenie obiektu user a w nim klient
            User u = new User(c, fn, ln, mail, dob);
            // przeniesienie walidacji nazwy maila oraz wieku do klasy użytkownika
            if (u.CheckClientName()==false) return false;
            if (u.CheckMail() == false) return false;
            if (u.CheckAge() == false) return false;

            // wyniesienie ustawinia limitu kredytowego do interfejsu odpowiedzialnego za 
            UserCreditService ucs = new UserCreditService();
            ucs.SetCreditLimit(c,u);


            // do dodania czy klient nie ma limitu mniejszego niż 500
            var clientRepository = new ClientRepository(); // zostawiam klasę. zakładam, że jest to utworzenie danych w bazie danych o kliencie
            var client = clientRepository.GetById(clientId); // j.w.

           // weryfikacja czy klient nie ma zbyt małego limitu i trzeba zablokować jego zakładanie
            if (ucs.CheckDefaultClient(u) == false) return false;
           

            UserDataAccess.AddUser(u);
            return true;
        }
    }
}
