using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_TAP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);

            /*teste 1*/
            Tuple<int, int>[] entradas = new Tuple<int, int>[3];
            int posicaEsperada =2;

            entradas[0] = new Tuple<int, int>(1, 1);
            entradas[1] = new Tuple<int, int>(1, 4);
            entradas[2] = new Tuple<int, int>(2, 2);

            /*teste 2
            //item1 = posicão, item2 = pontuação
            Tuple<int, int>[] entradas = new Tuple<int, int>[2];
            int posicaEsperada = 1;

            entradas[0] = new Tuple<int, int>(3, 2);
            entradas[1] = new Tuple<int, int>(4, 0);
            */
            // Calcula as possibilidade de vitoria e derreta

            bool[,] possiblidades = CriarTabela(entradas.Length);

            //item1 = gasto, item2 = pontos
            Tuple<int, int>[] resultados = new Tuple<int, int>[(int)Math.Pow(2, entradas.Length)];

            //Calcula a pontuações e gasto de cada possiblidade
            CaluculoEsforco(possiblidades, entradas, resultados);

            ExibirResultdo(resultados);

            Console.WriteLine();
            //Calcula qual vai ser o gasto minimo par ficar na possição esperada
            int resposta = Posicao(entradas, resultados, possiblidades, posicaEsperada);

            Console.WriteLine(resposta);

            Console.WriteLine(DateTime.Now);
            Console.ReadKey();

            /*Mano, a parte interativa fechou, depois temos que 
                Peensar em como fazer de forma reculsiva 
                Fazer a leitura das entradas
                Fazer os calculos que o professor pede */

        }


        public static bool[,] CriarTabela(int num)
        {
            // Numero de variaveis e de conectivos
            int nVar = num;

            bool[,] tabela = new bool[(int)Math.Pow(2, nVar), nVar];  //Cria a tabela [linha , coluna]

            //Apenas para auxiliar o preenchimento das variaveis
            ushort aux = Convert.ToUInt16(Math.Pow(2, nVar - 1));  //Define numero de elementos true ou false
            ushort contRepet = 0;

            //'col' = colunas
            for (int col = 0; col < tabela.GetLength(1); col++)
            {
                if (col < nVar)//Verifica se estah em uma coluna de variaveis. Se sim as preenche, se nao define os conectivos a partir das variaveis ja preenchidas
                {
                    //'row' = linhas
                    for (int row = 0; row < tabela.GetLength(0); row++)
                    {
                        contRepet++;
                        if (contRepet > (aux * 2))
                        {
                            contRepet = 1;
                        }

                        if (contRepet <= aux)
                        {
                            tabela[row, col] = true;
                        }
                        else
                        {
                            tabela[row, col] = false;
                        }
                    }
                    // Define ate que ponto vai ser True para depois passar para False
                    aux /= 2;
                }
            }

            return tabela;
        }

        private static int Posicao(Tuple<int, int>[] entradas, Tuple<int, int>[] resultados, bool[,] possiblidades, int posicaoEsperada)
        {
            int[] posicao = new int[resultados.Length];

            for (int j = 0; j < resultados.Length; j++)
            {
                int pos = 1;
                for (int i = 0; i < entradas.Length; i++)
                {
                    if (resultados[j].Item2 == entradas[i].Item1)
                    {
                        if (possiblidades[j, i] == false)
                        {
                            pos++;
                        }
                    }
                    else if (resultados[j].Item2 < entradas[i].Item1)
                    {
                        pos++;
                    }
                }
                posicao[j] = pos;
            }

            int menorGasto = int.MaxValue;
            bool existe = false;
            for (int i = 0; i < posicao.Length; i++)
            {
                if (posicao[i] <= posicaoEsperada)
                {
                    if (menorGasto > resultados[i].Item1) menorGasto = resultados[i].Item1;
                    existe = true;
                }
            }

            if (!existe)
            {
                menorGasto = -1;
            }

            return menorGasto;
        }

        private static void CaluculoEsforco(bool[,] possiblidades, Tuple<int, int>[] entradas, Tuple<int, int>[] resultados)
        {
            for (int i = 0; i < resultados.Length; i++)
            {
                int gasto = 0;
                int pontos = 0;

                for (int j = 0; j < possiblidades.GetLength(1); j++)
                {
                    if (possiblidades[i, j])
                    {
                        gasto += entradas[j].Item2;
                        pontos++;
                    }
                }
                resultados[i] = new Tuple<int, int>(gasto, pontos);
            }
        }

        private static void ExibirResultdo(Tuple<int, int>[] resultados)
        {
            for (int i = 0; i < resultados.Length; i++)
            {
                Console.WriteLine(resultados[i].Item1 + " - " + resultados[i].Item2);
            }
        }
    }
}
