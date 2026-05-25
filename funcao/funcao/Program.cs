using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funcao
{
    internal class Program
    {
        public class Recursiva
        {
            // Recursividade - função chamando ela mesma
            public void excutar(string mensagem, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(mensagem);
                }


            }
        }

        public void executarRecursivo(string mensagem, int n)
        {
            // Verifica se N é maior que 0
            // Condição de para da recursão
            if (n > 0)
            {
                // Chama o próprio método
                Console.WriteLine(mensagem);
                Console.WriteLine(mensagem, n - 1);
            }
        }

        #region
        static void MostrarMenu()
        {
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Listar");
            Console.WriteLine("3 - Sair");
        }

        static int Dobro(int n)
        {
            return n * 2;
        }

        static int Somar (int n1, int n2)
        {
            return n1 + n2;
        } 

        static string Saudacao(string nome)
        {
            return $"Olá {nome}, seja bem-vindo";
        }

        #endregion

        static bool Aprovado (double nota)
        {
            return nota >= 7;
        }


        public void contagem(int num)
        {
            if (num >= 0)
            {
                Console.WriteLine(num);
                contagem(num - 1);
            }
        }


        static void Main(string[] args)
        {
            Recursiva r = new Recursiva();
            

        }
    }
}
 