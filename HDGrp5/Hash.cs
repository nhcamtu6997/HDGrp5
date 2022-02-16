using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace HDGrp5
{
    public class Hash
    {
        public static string HashString(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return String.Empty;
            }
            using (var sha256 = new SHA256Managed())
            {
                //String to byte array
                byte[] textbytes = System.Text.Encoding.UTF8.GetBytes(text);
                //Hash
                byte[] hashbytes = sha256.ComputeHash(textbytes);
                //Hash back to string
                string hash = BitConverter
                    .ToString(hashbytes)
                    .Replace("-", String.Empty);

                return hash;

            }
        }
    }
}