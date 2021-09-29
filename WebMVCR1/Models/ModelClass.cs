using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVCR1.Models
{
    public class ModelClass
    {
        public static string ModelHello()
        {
            int hour = DateTime.Now.Hour;
            string greeting = hour < 12 ? "Good morning!" : "Good afternoon";
            return greeting;
        }
    }
}