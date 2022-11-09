using System.Diagnostics;
using System;

namespace csharp_mongo.Core
{
    internal class Helper
    {
        public static string GetUUID()
        {
            Guid myuuid             = Guid.NewGuid();
            string myuuidAsString   = myuuid.ToString();
            Debug.WriteLine("Your UUID is: " + myuuidAsString);
            return myuuidAsString;
        }
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; 
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
