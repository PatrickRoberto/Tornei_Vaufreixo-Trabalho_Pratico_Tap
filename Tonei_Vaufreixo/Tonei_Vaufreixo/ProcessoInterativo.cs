using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tonei_Vaufreixo
{
    public static class ProcessoInterativo
    {

        /*Melhorar algoritmos
            Para Isso únificar conteudo de CaculoEsforço com Esforço 
            Bastas ao fim do calculo do resultado de cada possibildiade já adicionar a verficação da possição e do esforço gasto; 
            Adiciona isso a uma váriavel e quando for melhor substituir
         */
        public static int Resolucao(Tuple<int, int>[] Entradas, int posEsperada)
        {
            //Gera Tabela Verdade com todas as combinações de vitoria e derrota
            bool[,] possiblidades = CriarTabela(Entradas.Length);

            Tuple<int, int>[] resultados = new Tuple<int, int>[(int)Math.Pow(2, Entradas.Length)];

            CaluculoEsforco(possiblidades, Entradas, resultados);

            int resposta = MenorEsforco(Entradas, resultados, possiblidades, posEsperada);

            return resposta;

        }



        private static bool[,] CriarTabela(int num)
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

        private static int MenorEsforco(Tuple<int, int>[] entradas, Tuple<int, int>[] resultados, bool[,] possiblidades, int posicaoEsperada)
        {
            int[] posicao = new int[resultados.Length];

            int menorGasto = -1;

            for (int j = 0; j < resultados.Length; j++)
            {
                int pos = 1;
                for (int i = 0; i < entradas.Length; i++)
                {

                    if ((resultados[j].Item2 < entradas[i].Item1) || (resultados[j].Item2 == entradas[i].Item1  && !possiblidades[j, i]))
                    {
                        pos++;
                    }

                    //    if (!possiblidades[j, i]) //Se perdeu a luta
                    //{
                    //    if(resultados[j].Item2 <= entradas[i].Item1) //Se a pontuação for igual ou menor que a do oponente 
                    //    {
                           
                    //    }
                    //}
                    //else if (resultados[j].Item2 < entradas[i].Item1)
                    //{
                    //    pos++;
                    //}
                }
                
                if(pos <= posicaoEsperada)
                {
                    if (menorGasto == -1) menorGasto = resultados[j].Item1;
                    else menorGasto = Math.Min(resultados[j].Item1, menorGasto);
                }

            }

            return menorGasto;
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
