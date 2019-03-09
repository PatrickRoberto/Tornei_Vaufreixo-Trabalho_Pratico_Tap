using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tonei_Vaufreixo
{

      

    class Program
    {
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

        static void Main(string[] args)
        {
            int nElem = 3; // Nesse Ponto determino quantos Elementos estou trabalhando
            bool[,] possiblidades = CriarTabela(nElem);


            Tuple<int, int>[] entradas = new Tuple<int, int>[3];


            entradas[0] = new Tuple<int, int>(1, 1);
            entradas[1] = new Tuple<int, int>(1, 4);
            entradas[2] = new Tuple<int, int>(2, 2);

            Tuple<int, int>[] resultados = new Tuple<int, int>[8];

            NewMethod(possiblidades, entradas, resultados);

            ExibirResultdo(resultados);

            Console.ReadKey();
            //Criar metodo de cabeçalho - 1

            //Metodo - entrada - saida - 2
            //Criar metodo de leitura do arquivo de entrada - caminho do arquivo de entrada - colocar a entrada em uma lista/vetor de objetos

            //Criar de forma recursiva e interativa - 3
            /* 
             * Criar metodo de calculo de gasto vencendo cada openente - lista/vetor com as entradas - retorna uma lista com as possiblidade de pontos; esforço; e relação de vitorias;
             * Criar um objeto que represente as possiblidades de saida
            */

            /*
             * criar metodo que selecina a melhor posição que o Sir Ducan obteve - Lista de possibilidades - melhor possibilidade
             * a regra selecionar a que teve o menor gasto, mas que mantenha dentro dos K conpetidores
            */
            //Exibir resultado - saido do metodo que seleciona o melhor competidor - exib o esforço minimo em tela. - 5

        }

        private static void NewMethod(bool[,] possiblidades, Tuple<int, int>[] entradas, Tuple<int, int>[] resultados)
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
