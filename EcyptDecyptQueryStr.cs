using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using Telerik.Web.UI;

namespace OvationTest
{
    public class EcyptDecyptQueryStr
    {

        public static string Encrypt(string value, string key)
        {
            MACTripleDES mac3des = new MACTripleDES();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            mac3des.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
            
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value)) + '-' + Convert.ToBase64String(mac3des.ComputeHash(Encoding.UTF8.GetBytes(value)));
        }


    }
}
