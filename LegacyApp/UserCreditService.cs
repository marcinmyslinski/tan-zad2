using System;

namespace LegacyApp
{
    public class UserCreditService : IDisposable
    {
        public void Dispose()
        {
            //...
        }

        internal int GetCreditLimit(string firstName, string lastName, DateTime dateOfBirth)
        {
            //Fetching the data...
            return 10000;
        }

        public int GetLimit()
        {
            return 10000;
        }
        public void SetCreditLimit(Client cl, User us) // metoda nie działa bo w 
          
        {
            if (cl.Name == "VeryImportantClient")
            {
                us.HasCreditLimit = false;
            }else if (cl.Name == "ImportantClient")
            {
                us.HasCreditLimit = false;
                int creditLimit = GetLimit();
                creditLimit = creditLimit * 2;
                us.CreditLimit = creditLimit;
            }
            else
            {
                us.HasCreditLimit = true;
                int creditLimit = GetLimit();

                us.CreditLimit = creditLimit;
            }
        }
        public bool CheckDefaultClient(User us)
        {
            if (us.HasCreditLimit = true && us.CreditLimit < 500) return false;
            else
            {
                return true;
            }
            
        }
    }
}