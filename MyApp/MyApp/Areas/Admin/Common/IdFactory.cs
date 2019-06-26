using MyApp.Areas.Admin.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MyApp.Areas.Admin.Common
{
    public static class IdFactory
    {
        private static int TOKEN_LENGTH = 16;

        public static string Generate()
        {
            byte[] token = new byte[TOKEN_LENGTH];

            RNGCryptoServiceProvider gen = new RNGCryptoServiceProvider();
            gen.GetBytes(token);

            StringBuilder buf = new StringBuilder();

            for (int i = 0; i < token.Length; i++)
            {
                buf.AppendFormat("{0:x2}", token[i]);
            }

            return buf.ToString();
        }
    }
}