using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tonei_Vaufreixo;

namespace TP_TAP
{
    class Program
    {

        public static Tuple<int, int>[] Entradas()
        {
            //item1 = Pontuacao, item2 = esforço

            /*teste 1*/
            
            //Tuple<int, int>[] entradas = new Tuple<int, int>[3];
            //entradas[0] = new Tuple<int, int>(1, 1);
            //entradas[1] = new Tuple<int, int>(1, 4);
            //entradas[2] = new Tuple<int, int>(2, 2);

            /*teste 2*/

            Tuple<int, int>[] entradas = new Tuple<int, int>[2];
            entradas[0] = new Tuple<int, int>(3, 2);
            entradas[1] = new Tuple<int, int>(4, 0);

            /*teste 3*/
            //Tuple<int, int>[] entradas = new Tuple<int, int>[2];
            //entradas[0] = new Tuple<int, int>(1, 1);
            //entradas[1] = new Tuple<int, int>(1, 3);

            return entradas;
        }


        static void Main(string[] args)
        {

            var stopwatch = new Stopwatch();//Calcular tempo
            int posicaEsperada = 2;
            var entrada = Entradas();

            //Inicio teste interativo
            stopwatch.Start();

            Console.WriteLine("Interativo");
            Console.WriteLine(DateTime.Now);
            int resposta = ProcessoInterativo.Resolucao(entrada, posicaEsperada);
            Console.WriteLine(resposta);
            Console.WriteLine(DateTime.Now);
            stopwatch.Stop();
            var x = stopwatch.Elapsed.Milliseconds;
            Console.WriteLine($"Segudos {x};");
            //Fim teste Interativo

            Console.WriteLine();
            Console.WriteLine();

            //Inicio teste recursivo
            stopwatch.Start();
            Console.WriteLine("Recursivo");
            Console.WriteLine(DateTime.Now);
            int resposta2 = ProcessaRecursivo.Resolucao(entrada, posicaEsperada);
            Console.WriteLine(resposta2);
            Console.WriteLine(DateTime.Now);

            stopwatch.Stop();
            x = stopwatch.Elapsed.Milliseconds;
            Console.WriteLine($"Segudos {x};");
            //Fim teste Recursivo

            Console.ReadKey();

        }

    }
}
