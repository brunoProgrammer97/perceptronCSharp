using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Perceptron
{
    class Neuronio
    {

        double taxaDeAprend;
        double erro;

        public Neuronio()
        {
            taxaDeAprend = 0.3;
        }
        

        private int FuncAtivacao(double value)
        {
            return value >= 0 ? 1 : 0;
        }

        private int CalcularErro(int esperado, int obtido)
        {
            return esperado - obtido;
        }

        private void imprimirResultado(Entrada e, int saida, int iteracoes)
        {
            Console.WriteLine("Entradas");
            for(int i = 0; i < e.Valores_pesos.GetLength(1) - 1; i++)
            {
                Console.Write((e.Valores_pesos[0,i]).ToString()+"|");
            }

            Console.WriteLine("\nSaida: " + saida);
            Console.WriteLine("Iterações: "+iteracoes.ToString() + "\n");
        }

        // Peso novo = peso anterior + taxa aprend. * erro * valor entrada
        private Entrada AjustarPeso(Entrada e)
        {
            for (int i = 0; i < e.Valores_pesos.GetLength(1); i++)
            {
                e.Valores_pesos[1, i] = (e.Valores_pesos[1, i] + this.taxaDeAprend * this.erro * e.Valores_pesos[0, i]);
            }
            return e;
        }

        public void Aprender(Entrada dadosEntrada)
        {
            int iteracoes = 0;
            do
            {

                iteracoes++;

                this.erro = int.MaxValue;
                double valorParcial = 0;

                for (int i = 0; i < dadosEntrada.Valores_pesos.GetLength(1); i++)
                {
                    valorParcial += (dadosEntrada.Valores_pesos[0,i] * dadosEntrada.Valores_pesos[1,i]);
                }

                int saidaObtida = FuncAtivacao(valorParcial);
                this.erro = CalcularErro(dadosEntrada.SaidaEsperada, saidaObtida);
                
                if (this.erro != 0)
                { dadosEntrada = AjustarPeso(dadosEntrada); }

                else
                { imprimirResultado(dadosEntrada, saidaObtida, iteracoes); }


            } while (erro != 0);
        }
    }
}
