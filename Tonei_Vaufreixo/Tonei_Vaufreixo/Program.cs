using System;
using System.Collections.Generic;
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
            /*teste 1*/
            //item1 = Pontuacao, item2 = esforço
            Tuple<int, int>[] entradas = new Tuple<int, int>[3];
            entradas[0] = new Tuple<int, int>(1, 1);
            entradas[1] = new Tuple<int, int>(1, 4);
            entradas[2] = new Tuple<int, int>(2, 2);

            /*teste 2*/
            //item1 = Pontuacao, item2 = esforço
            //Tuple<int, int>[] entradas = new Tuple<int, int>[2];
            //entradas[0] = new Tuple<int, int>(3, 2);
            //entradas[1] = new Tuple<int, int>(4, 0);
            
            /*teste 2*/
            //Tuple<int, int>[] entradas = new Tuple<int, int>[2];
            //entradas[0] = new Tuple<int, int>(1, 1);
            //entradas[1] = new Tuple<int, int>(1, 3);

            return entradas;
        }


        static void Main(string[] args)
        {
            int posicaEsperada = 2;
            var entrada = Entradas();

            Console.WriteLine("Interativo");
            Console.WriteLine(DateTime.Now);
            int resposta = ProcessoInterativo.Resolucao(entrada, posicaEsperada);
            Console.WriteLine(resposta);
            Console.WriteLine(DateTime.Now);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Recursivo");
            Console.WriteLine(DateTime.Now);
            int resposta2 = ProcessaRecursivo.Resolucao(entrada, posicaEsperada);
            Console.WriteLine(resposta2);
            Console.WriteLine(DateTime.Now);
            Console.ReadKey();

        }

    }
}
