using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Simple_Perceptron
{

    class Program
    {
        /*      (w1 * x1 + w2 * x2... wn * xn) + wb * xB
         *      Função de ativação degraus (Se >= 0 então = 1, se < 0 então = 0)
         *      calcular erro E = saida desejada - saida obtida.
         *      Se erro igual a zero, passar para outra entrada.
         *      Se erro != 0, ajustar pessos pela fórmula: peso + taxa de aprendizado * Erro obtido * entrada  
             
         */
        static void Main(string[] args)
        {

            LeitorEntrada entradas = new LeitorEntrada();
            entradas.LerEntradas();
            Neuronio neuronio = new Neuronio();

            for (int i = 0; i < entradas.ValoresPesos.Count; i++)
            {
                neuronio.Aprender(entradas.ValoresPesos[i]);
            }

            Console.WriteLine("Pronto!");
            Console.ReadLine();
            
        }
    }
}
