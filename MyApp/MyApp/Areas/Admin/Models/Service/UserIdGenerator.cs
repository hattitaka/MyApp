using MyApp.Areas.Admin.Models.Models;
using System;
using System.Text;

namespace MyApp.Areas.Admin.Models.Service
{
    public static class UserIdGenerator
    {
        private static readonly string ID_CHARS = "0123456789abcdefghijklmnopqrstuvwxyz";

        private static readonly int ID_LENGTH = 8;

        public static string Generate()
        {
            StringBuilder sb = new StringBuilder(ID_LENGTH);
            Random r = new Random();

            for (int i = 0; i < ID_LENGTH; i++)
            {
                int pos = r.Next(ID_CHARS.Length);
                char c = ID_CHARS[pos];
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}