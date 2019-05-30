using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testboker.admin.Helper
{
    public class CookieHelper
    {
        public static string GetCookie(string key)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie != null)
            {
                return HttpUtility.UrlDecode(cookie.Value);
            }

            return string.Empty;
        }

        public static void SetCookie(string key, string value, int days=3600000)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie == null)
            {
                cookie = new HttpCookie(key);
            }
            cookie.Value = HttpUtility.UrlEncode(value);
            cookie.Expires = DateTime.Now.AddDays(days);

            HttpContext.Current.Response.AppendCookie(cookie);
        }


        public static void RemoveCookie(string key)
        {
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                HttpContext.Current.Response.Cookies.Remove(key);
            }
        }


        public static void ClearCookie()
        {
            HttpContext.Current.Request.Cookies.Clear();
        }
    }
}