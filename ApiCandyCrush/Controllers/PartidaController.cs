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
        static List<Dulce> listElementos1;
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // POST api/Partida
        public async Task<IHttpActionResult> PostPartida([FromBody] ApplicationUser user)
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

        public void sd(int movimiento1, int movimiento2)
        {
            var move2 = listElementos.First(x => x.id == movimiento2);
            var move = listElementos.First(x => x.id == movimiento1);
            listElementos.Remove(move);
            move.id = movimiento2;
            listElementos.Remove(move2);
            move2.id = movimiento1;
            listElementos.Add(move);
            listElementos.Add(move2);

        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // Put api/Partida
        public async Task<IHttpActionResult> PutPartida(int id,
            [FromBody] Movimiento usuarioMovimientos)
        {

            /** 
             * 
             * 
             * izquierda y derecha del sugundo click
             * 
             * */


            //Logica de negocios
            var move2 = listElementos.First(x => x.id == usuarioMovimientos.movimiento2);
            var move = listElementos.First(x => x.id == usuarioMovimientos.movimiento1);
            var next = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 + 1);
            var ant = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 - 1);
            if (move != null && next != null && ant != null)
            {
                if (move.color == next.color && move.color == ant.color)
                {
                    listElementos.Remove(move);
                    move.id = usuarioMovimientos.movimiento2;
                    listElementos.Remove(move2);
                    move2.id = usuarioMovimientos.movimiento1;
                    listElementos.Add(move);
                    listElementos.Add(move2);
                    var uno = listElementos.First(x => x.id == ant.id - 9);
                    var dos = listElementos.First(x => x.id == move.id - 9);
                    var tres = listElementos.First(x => x.id == next.id - 9);
                    ant.color = uno.color;
                    move.color = dos.color;
                    next.color = tres.color;

                    var idw = dos.id;
                    var flag = true;
                    listElementos1 = new List<Dulce>();
                    while (flag)
                    {
                        var move1 = listElementos.First(x => x.id == idw);
                        var next1 = listElementos.First(x => x.id == idw + 1);
                        var ant1 = listElementos.First(x => x.id == idw - 1);
                        if (idw <= 8)
                        {
                            Array values = Enum.GetValues(typeof(Color));
                            Random random = new Random();
                            var randomColor1 = Color.red;
                            var randomColor2 = Color.red;
                            var randomColor3 = Color.red;
                            randomColor1 = (Color)values.GetValue(random.Next(values.Length));
                            randomColor2 = (Color)values.GetValue(random.Next(values.Length));
                            randomColor3 = (Color)values.GetValue(random.Next(values.Length));
                            move1.color = randomColor1;
                            next1.color = randomColor2;
                            ant1.color = randomColor3;
                            flag = false;
                        }
                        else
                        {
                            var uno1 = listElementos.First(x => x.id == ant1.id - 9);
                            var dos1 = listElementos.First(x => x.id == move1.id - 9);
                            var tres1 = listElementos.First(x => x.id == next1.id - 9);

                            ant1.color = uno1.color;
                            move1.color = dos1.color;
                            next1.color = tres1.color;
                        }

                        idw = move1.id - 9;

                    }


                    oPartida.dulces = listElementos.OrderBy(x => x.id).ToList();
                    return Json(oPartida);

                }
            }


            ///**
            // * arriba y abajo del segundo click
            // * 
            // * 
            // **/
            next = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 + 9);
            ant = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 - 9);
            if (move != null && next != null && ant != null)
            {
                if (move.color == next.color && move.color == ant.color)
                {
                    sd(usuarioMovimientos.movimiento1, usuarioMovimientos.movimiento2);
                    var uno = listElementos.First(x => x.id == ant.id - 27);
                    var dos = listElementos.First(x => x.id == move.id - 27);
                    var tres = listElementos.First(x => x.id == next.id - 27);
                    ant.color = uno.color;
                    move.color = dos.color;
                    next.color = tres.color;
                    var idw = dos.id;
                    var flag = true;
                    while (flag)
                    {
                        var move1 = listElementos.First(x => x.id == idw);
                        var next1 = listElementos.First(x => x.id == idw + 9);
                        var ant1 = listElementos.First(x => x.id == idw - 9);
                        if (idw <= 26)
                        {
                            Array values = Enum.GetValues(typeof(Color));
                            Random random = new Random();
                            var randomColor1 = Color.red;
                            var randomColor2 = Color.red;
                            var randomColor3 = Color.red;
                            randomColor1 = (Color)values.GetValue(random.Next(values.Length));
                            randomColor2 = (Color)values.GetValue(random.Next(values.Length));
                            randomColor3 = (Color)values.GetValue(random.Next(values.Length));
                            move1.color = randomColor1;
                            next1.color = randomColor2;
                            ant1.color = randomColor3;
                            flag = false;
                        }
                        else
                        {
                            var uno1 = listElementos.First(x => x.id == ant1.id - 27);
                            var dos1 = listElementos.First(x => x.id == move1.id - 27);
                            var tres1 = listElementos.First(x => x.id == next1.id - 27);

                            ant1.color = uno1.color;
                            move1.color = dos1.color;
                            next1.color = tres1.color;
                        }

                        idw = move1.id - 27;

                    }

                    oPartida.dulces = listElementos.OrderBy(x => x.id).ToList();
                    return Json(oPartida);
                }
            }

            ///**
            // * 
            // * dos arriba del segundo click
            // * 
            // * 
            // **/

            next = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 - 9);
            ant = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 - 18);
            next = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 + 9);
            var nexA = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 + 18);
            if (move != null && nexA != null && ant != null)
            {
                if (move.color == next.color && move.color == ant.color)
                {
                    var uno = listElementos.First(x => x.id == move2.id - 27);
                    var dos = listElementos.First(x => x.id == ant.id - 27);
                    var tres = listElementos.First(x => x.id == nexA.id - 27);

                    move2.color = uno.color;
                    next.color = dos.color;
                    nexA.color = tres.color;

                    var idw = dos.id;
                    var flag = true;
                    while (flag)
                    {
                        var next1 = listElementos.First(x => x.id == idw + 9);
                        var betw1 = listElementos.First(x => x.id == idw);
                        var ant1 = listElementos.First(x => x.id == idw - 9);

                        if (idw == 0 || idw == 1 || idw == 2 || idw == 3 ||
                            idw == 4 || idw == 5 || idw == 6 || idw == 7 || idw == 8)
                        {
                            Array values = Enum.GetValues(typeof(Color));
                            Random random = new Random();
                            var randomColor1 = Color.red;
                            var randomColor2 = Color.red;
                            var randomColor3 = Color.red;
                            randomColor1 = (Color)values.GetValue(random.Next(values.Length));
                            randomColor2 = (Color)values.GetValue(random.Next(values.Length));
                            randomColor3 = (Color)values.GetValue(random.Next(values.Length));
                            betw1.color = randomColor1;
                            next1.color = randomColor2;
                            ant1.color = randomColor3;
                            flag = false;
                        }
                        else
                        {
                            var uno1 = listElementos.First(x => x.id == next1.id - 27);
                            var dos1 = listElementos.First(x => x.id == betw1.id - 27);
                            var tres1 = listElementos.First(x => x.id == ant1.id - 27);
                            next1.color = uno1.color;
                            betw1.color = dos1.color;
                            ant1.color = tres1.color;
                            idw = dos1.id - 27;
                        }


                    }
                }
            }

            ///**
            //* 
            //* dos abajo del segundo click
            //* 
            //* 
            //**/

            move2 = listElementos.First(x => x.id == usuarioMovimientos.movimiento2);
            move = listElementos.First(x => x.id == usuarioMovimientos.movimiento1);
            next = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 + 9);
            nexA = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 + 18);
          
                if (move.color == nexA.color && move.color == ant.color)
                {
                var uno = listElementos.First(x => x.id == move2.id - 27);
                var dos = listElementos.First(x => x.id == ant.id  -27);
                var tres = listElementos.First(x => x.id == nexA.id - 27);

                move2.color = uno.color;
                next.color = dos.color;
                nexA.color = tres.color;

                var idw = dos.id;
                var flag = true;
                while (flag)
                {
                    var next1 = listElementos.First(x => x.id == idw + 9);
                    var betw1 = listElementos.First(x => x.id == idw);
                    var ant1 = listElementos.First(x => x.id == idw - 9);

                    if (idw == 0 || idw == 1 || idw == 2 || idw == 3 ||
                        idw == 4 || idw == 5 || idw == 6 || idw == 7 || idw == 8)
                    {
                        Array values = Enum.GetValues(typeof(Color));
                        Random random = new Random();
                        var randomColor1 = Color.red;
                        var randomColor2 = Color.red;
                        var randomColor3 = Color.red;
                        randomColor1 = (Color)values.GetValue(random.Next(values.Length));
                        randomColor2 = (Color)values.GetValue(random.Next(values.Length));
                        randomColor3 = (Color)values.GetValue(random.Next(values.Length));
                        betw1.color = randomColor1;
                        next1.color = randomColor2;
                        ant1.color = randomColor3;
                        flag = false;
                    }
                    else
                    {
                        var uno1 = listElementos.First(x => x.id == next1.id - 27);
                        var dos1 = listElementos.First(x => x.id == betw1.id - 27);
                        var tres1 = listElementos.First(x => x.id == ant1.id - 27);
                        next1.color = uno1.color;
                        betw1.color = dos1.color;
                        ant1.color = tres1.color;
                        idw = dos1.id - 27;
                    }


                }
            }


            /**
            * 
            * dos a la derecha del segundo click
            * 
            * 
            **/
            move2 = listElementos.First(x => x.id == usuarioMovimientos.movimiento2);
            move = listElementos.First(x => x.id == usuarioMovimientos.movimiento1);
            ant = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 + 1);
            var tras = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 + 2);
            if (move.color == ant.color && move.color == tras.color)
            {

                var uno = listElementos.First(x => x.id == move2.id - 9);
                var dos = listElementos.First(x => x.id == ant.id - 9);
                var tres = listElementos.First(x => x.id == tras.id - 9);

                move2.color = uno.color;
                ant.color = dos.color;
                tras.color = tres.color;

                var idw = dos.id;
                var flag = true;
                while (flag)
                {
                    var next1 = listElementos.First(x => x.id == idw + 1);
                    var betw1 = listElementos.First(x => x.id == idw);
                    var ant1 = listElementos.First(x => x.id == idw - 1);

                    if (idw == 0 || idw == 1 || idw == 2 || idw == 3 ||
                        idw == 4 || idw == 5 || idw == 6 || idw == 7 || idw == 8)
                    {
                        Array values = Enum.GetValues(typeof(Color));
                        Random random = new Random();
                        var randomColor1 = Color.red;
                        var randomColor2 = Color.red;
                        var randomColor3 = Color.red;
                        randomColor1 = (Color)values.GetValue(random.Next(values.Length));
                        randomColor2 = (Color)values.GetValue(random.Next(values.Length));
                        randomColor3 = (Color)values.GetValue(random.Next(values.Length));
                        betw1.color = randomColor1;
                        next1.color = randomColor2;
                        ant1.color = randomColor3;
                        flag = false;
                    }
                    else
                    {
                        var uno1 = listElementos.First(x => x.id == next1.id - 9);
                        var dos1 = listElementos.First(x => x.id == betw1.id - 9);
                        var tres1 = listElementos.First(x => x.id == ant1.id - 9);
                        next1.color = uno1.color;
                        betw1.color = dos1.color;
                        ant1.color = tres1.color;
                        idw = dos1.id - 9;
                    }


                }
            }


            /**
          * 
          * dos a la izquierda del segundo click
          * 
          * 
          **/

            move2 = listElementos.First(x => x.id == usuarioMovimientos.movimiento2);
            move = listElementos.First(x => x.id == usuarioMovimientos.movimiento1);
            ant = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 - 1);
            tras = listElementos.First(x => x.id == usuarioMovimientos.movimiento2 - 2);


            if (move.color == ant.color && move.color == tras.color)
            {

                var uno = listElementos.First(x => x.id == move2.id - 9);
                var dos = listElementos.First(x => x.id == ant.id - 9);
                var tres = listElementos.First(x => x.id == tras.id - 9);

                move2.color = uno.color;
                ant.color = dos.color;
                tras.color = tres.color;

                var idw = dos.id;
                var flag = true;
                while (flag)
                {
                    var next1 = listElementos.First(x => x.id == idw + 1);
                    var betw1 = listElementos.First(x => x.id == idw);
                    var ant1 = listElementos.First(x => x.id == idw - 1);

                    if (idw == 0 || idw == 1 || idw == 2 || idw == 3 ||
                        idw == 4 || idw == 5 || idw == 6 || idw == 7 || idw == 8)
                    {
                        Array values = Enum.GetValues(typeof(Color));
                        Random random = new Random();
                        var randomColor1 = Color.red;
                        var randomColor2 = Color.red;
                        var randomColor3 = Color.red;
                        randomColor1 = (Color)values.GetValue(random.Next(values.Length));
                        randomColor2 = (Color)values.GetValue(random.Next(values.Length));
                        randomColor3 = (Color)values.GetValue(random.Next(values.Length));
                        betw1.color = randomColor1;
                        next1.color = randomColor2;
                        ant1.color = randomColor3;
                        flag = false;
                    }
                    else
                    {
                        var uno1 = listElementos.First(x => x.id == next1.id - 9);
                        var dos1 = listElementos.First(x => x.id == betw1.id - 9);
                        var tres1 = listElementos.First(x => x.id == ant1.id - 9);
                        next1.color = uno1.color;
                        betw1.color = dos1.color;
                        ant1.color = tres1.color;
                        idw = dos1.id - 9;
                    }


                }
            }

            oPartida.dulces = listElementos.OrderBy(x => x.id).ToList();
                return Json(oPartida);

            
        }
    }
}
