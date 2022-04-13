using Microsoft.AspNetCore.Http;
using System;
using System.Text;

namespace ZaminEducationClone.Service.Helpers
{
    public class AccesToContext
    {
        public static IHttpContextAccessor Accessor;
        public static HttpContext Context => Accessor?.HttpContext;
        public static IHeaderDictionary ResponseHeaders => Context?.Response?.Headers;
        public static string Language => Context?.Request?.Headers["Accept-Language"].ToString();



        private static string Authorization => Context?.Request?.Headers["Authorization"].ToString();
        public static string BasicUser => GetLoginAndPassword().login;
        public static string BasicPassword => GetLoginAndPassword().password;


        private static (string login, string password) GetLoginAndPassword()
        {

            string[] temp = Authorization.Split(' ');
            if (temp.Length != 2)
                return (null, null);

            byte[] data = Convert.FromBase64String(temp[1]);
            string decodestring = Encoding.UTF8.GetString(data);

            return (decodestring.Split(':')[0], decodestring.Split(':')[1]);            
           
        }

    }
}
