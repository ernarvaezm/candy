using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCandyCrush.Entitys
{
    public class Dulce
    {
        public enum Color
        {
            red,
            blue,
            yellow,
            orange,
            green,
        };

        public int id { set; get; }

        public Color color { set; get; }

        public string imagen { set; get; }
    }
}