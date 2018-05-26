using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Perceptron
{
    class LeitorEntrada
    {
        List<Entrada> valoresPesos;

        public LeitorEntrada()
        {
            ValoresPesos = new List<Entrada>();
        }

        public List<Entrada> ValoresPesos { get => valoresPesos; set => valoresPesos = value; }

        public List<Entrada> LerEntradas()
        {
            string[] dadosTreinamento = System.IO.File.ReadAllLines(@"C:\Users\Bruno Rocha\Desktop\Perceptron Simples\Simple Perceptron\MultiplasEntradas.txt");

            foreach (string s in dadosTreinamento)
            {
                double[,] aux = new double[2,s.Length];

                int saida = s[s.Length-1] == '1' ? 1 : 0;

                for (int i = 0; i < s.Length - 1; i++)
                {
                    aux[0, i] = (double)char.GetNumericValue(s[i]);
                    aux[1, i] = 0.5;
                }

                //Bias
                aux[0, aux.GetLength(1) - 1] = 1;
                aux[1, aux.GetLength(1) - 1] = 0.5;

                Entrada e = new Entrada();
                e.Valores_pesos = aux;
                e.SaidaEsperada = s[s.Length-1] == '1' ? 1 : 0;
                this.ValoresPesos.Add(e);
            }
            
            return this.ValoresPesos;
        }
    }
}
