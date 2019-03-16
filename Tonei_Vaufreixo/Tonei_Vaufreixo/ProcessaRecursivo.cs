using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tonei_Vaufreixo
{
    public static class ProcessaRecursivo
    {

        private static int Resposta = -1;

        public static int Resolucao(Tuple<int, int>[] Entradas, int posEsperada)
        {
            bool[] vet = new bool[Entradas.Length];

             ExecutaPossibilidade(vet, Entradas.Length, 0, Entradas, posEsperada);

            return Resposta;
        }

        static void ExecutaPossibilidade(bool[] row, int n, int i, Tuple<int, int>[] Entradas, int posEsperada)
        {
            if (i == n)
            {
                int R = Esforco(row, Entradas, posEsperada);

                if(Resposta == -1)
                {
                    Resposta = R;
                }
                else
                {
                    Resposta = Resposta > R ? R : Resposta;
                }

                
            }
            else
            {
                row[i] = false;
                ExecutaPossibilidade(row, n, i + 1, Entradas, posEsperada);
                row[i] = true;
                ExecutaPossibilidade(row, n, i + 1, Entradas, posEsperada);
            }
        }

        private static int Esforco(bool[] possibilidade, Tuple<int, int>[] Entradas, int Esperado)
        {

            int pontos = 0;
            int esforco = 0;
            int possicao = 1;
            Esforco(possibilidade, Entradas, possibilidade.Length-1, ref pontos, ref esforco, ref possicao);

            if (possicao <= Esperado) return esforco;
            else return -1;

        }


        private static void Esforco(bool[] possibilidade, Tuple<int, int>[] Entradas, int i, ref int Pontos, ref int esforco, ref int Possicao)
        {
            //Item 1 posicao, intem 2 esforço

            if (possibilidade[i])
            {
                Pontos++;
                esforco += Entradas[i].Item2;
            }

            if (i > 0) Esforco(possibilidade, Entradas, i-1, ref Pontos, ref esforco, ref Possicao);

            if (Pontos < Entradas[i].Item1 || (Pontos == Entradas[i].Item1 && !possibilidade[i]))
            {
                Possicao++;
            }

        }


    }
}
