using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCandyCrush.Entitys
{
    public class Partida
    {
        public int id { get; set; }
        public string Usuario { get; set; }
        public int movimiento { get; set; }
        public int puntos { get; set; }
        public List<Dulce> dulces { get; set; }
    }
}