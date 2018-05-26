using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Perceptron
{
    class Entrada
    {
        double[,] valores_pesos;
        int saidaEsperada;

        public Entrada()
        {

        }

        public double[,] Valores_pesos { get => valores_pesos; set => valores_pesos = value; }
        public int SaidaEsperada { get => saidaEsperada; set => saidaEsperada = value; }
    }
}
