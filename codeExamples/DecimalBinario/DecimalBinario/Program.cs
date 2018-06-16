using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalBinario
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Ingrese el numero decimal: ");
                int a = Convert.ToInt32(Console.ReadLine());
                string binario = "";
                while (a != 1)
                {
                    binario += a % 2;
                    a = a / 2;
                }
                binario += "1";
                string invert = "";
                foreach (char c in binario)
                {
                    invert = c + invert;
                }
                Console.WriteLine("Numero en binario: " + invert);
                Console.WriteLine();
                Console.Write("ingrese el numero binario: ");
                binario = Console.ReadLine();
                int i = 0;
                double elemento = 0;
                foreach (char c in binario.Reverse())
                {
                    a = (int)char.GetNumericValue(c);
                    elemento += Math.Pow(2, i) * a;
                    i++;
                }
                Console.WriteLine("Numero en decimal: " + elemento.ToString());
                Console.WriteLine();
            }
        }
    }
}
