using ApiCandyCrush.Entitys;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using static ApiCandyCrush.Entitys.Dulce;
using ApiCandyCrush.Models;

namespace ApiCandyCrush.Controllers
{
    public class PartidaController : ApiController
    {
        static Partida oPartida;
        static List<Dulce> listElementos;
 
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // POST api/Partida
        public async Task<IHttpActionResult> PostPartida([FromBody] ApplicationUser user )
        {
            Array values = Enum.GetValues(typeof(Color));
            Random random = new Random();
            var randomColor = Color.red;

            listElementos = new List<Dulce>();

            for (int i = 0; i < 81; i++)
            {
                randomColor = (Color)values.GetValue(random.Next(values.Length));
                listElementos.Add(new Dulce { id = i, color = randomColor });
            }

            oPartida = new Partida();
            oPartida.id = 1;
            oPartida.dulces = listElementos;
            return Json(oPartida);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // Put api/Partida
        public async Task<IHttpActionResult> PutPartida(int id,
            [FromBody] Movimiento usuarioMovimientos)
        {
            //Logica de negocios
            var move2 = listElementos.First(x => x.id == usuarioMovimientos.movimiento2);
            var move = listElementos.First(x => x.id == usuarioMovimientos.movimiento1);
            var next = listElementos.First(x => x.id == usuarioMovimientos.movimiento2+1);
            var ant = listElementos.First(x => x.id == usuarioMovimientos.movimiento2-1);
            if(move.color== next.color && move.color == ant.color)
            {
                //listElementos.Remove(move);
                //move.id = usuarioMovimientos.movimiento2;
                //listElementos.Remove(move2);
                //move2.id = usuarioMovimientos.movimiento1;
                //listElementos.Add(move);
                //listElementos.Add(move2);

                var uno = listElementos.First(x => x.id == ant.id - 9);
                var dos = listElementos.First(x => x.id == move2.id - 9);
                var tres = listElementos.First(x => x.id == next.id - 9);
                listElementos.Remove(next);
                listElementos.Remove(move2);
                listElementos.Remove(ant);
                
           
                uno.id = ant.id;
                dos.id = move2.id;
                tres.id = next.id;
               // return Json(uno);
                listElementos.Add(uno);
                listElementos.Add(dos);
                listElementos.Add(tres);

                oPartida.dulces = listElementos.OrderBy(x => x.id).ToList();
               return Json(oPartida);

            }
            next = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 + 9);
             ant = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 - 9);
            if (move.color == next.color && move.color == ant.color)
            {

                var uno = listElementos.First(x => x.id == ant.id - 27);
                var dos = listElementos.First(x => x.id == move2.id - 27);
                var tres = listElementos.First(x => x.id == next.id - 27);
                listElementos.Remove(next);
                listElementos.Remove(move2);
                listElementos.Remove(ant);

                uno.id = ant.id;
                dos.id = move2.id;
                tres.id = next.id;
                listElementos.Add(uno);
                listElementos.Add(dos);
                listElementos.Add(tres);
                oPartida.dulces = listElementos.OrderBy(x => x.id).ToList();
                return Json(oPartida);
            }
            next = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 - 9);
            ant = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 - 18);
            if (move.color == next.color && move.color == ant.color)
            {
                //var uno = listElementos.First(x => x.id == ant.id - 27);
                //var dos = listElementos.First(x => x.id == move2.id - 27);
                //var tres = listElementos.First(x => x.id == next.id - 27);
                //listElementos.Remove(next);
                //listElementos.Remove(move2);
                //listElementos.Remove(ant);

                //uno.id = ant.id;
                //dos.id = move2.id;
                //tres.id = next.id;
                //listElementos.Add(uno);
                //listElementos.Add(dos);
                //listElementos.Add(tres);
                oPartida.dulces = listElementos.OrderBy(x => x.id).ToList();
                return Json(oPartida);
            }
            next = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 + 9);
            ant = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 + 18);
            if (move.color == next.color && move.color == ant.color)
            {
                //var uno = listElementos.First(x => x.id == ant.id - 27);
                //var dos = listElementos.First(x => x.id == move2.id - 27);
                //var tres = listElementos.First(x => x.id == next.id - 27);
                //listElementos.Remove(next);
                //listElementos.Remove(move2);
                //listElementos.Remove(ant);

                //uno.id = ant.id;
                //dos.id = move2.id;
                //tres.id = next.id;
                //listElementos.Add(uno);
                //listElementos.Add(dos);
                //listElementos.Add(tres);
                oPartida.dulces = listElementos.OrderBy(x => x.id).ToList();
                return Json(oPartida);
            }
            next = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 + 1);
            ant = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 + 2);
            if (move.color == next.color && move.color == ant.color)
            {

                oPartida.dulces = listElementos.OrderBy(x => x.id).ToList();
                return Json(oPartida);
            }
            //var move = listElementos.First(x => x.id == usuarioMovimientos.movimiento1);
            //listElementos.Remove(move);
            //move.id = usuarioMovimientos.movimiento2;

            //var move2 = listElementos.First(x => x.id == usuarioMovimientos.movimiento2);
            //listElementos.Remove(move2);
            //move2.id = usuarioMovimientos.movimiento1;

            //listElementos.Add(move);
            //listElementos.Add(move2);
            oPartida.dulces = listElementos.OrderBy(x => x.id).ToList();
            return Json(oPartida);

        }
    }
}
