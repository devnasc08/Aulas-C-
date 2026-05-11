using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Bibliotecas

namespace PrimeiroProjeto  // Agrupamento de Classes
{
    internal class Program  // Classe
    {
        static void Main(string[] args)  // Método de Entrada
        {
            /*
             Tipos de Dados
            
            int idade = 17;
            double valor = 17.50;
            char caractere = 'A';
            string nome = "Kauã";
            bool verdadeiro = true;
            */

            /*  Concatenação  
            string nome = "Kauã";
            int idade = 17;
            //sobreNome - Camel Case
            //sobre_nome - Snake Case

            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("Idade: " + idade);
            */


            /* Const
            string aluno = "Guilherme";
            Console.WriteLine(aluno);
            aluno = "Diogo";
            Console.WriteLine(aluno);
            
            const string aluno = "Guilherme";
            Console.WriteLine("o valor da Constante é: " + aluno);
            */


            /* Entrada de Dados
            
            int dataNasc, idade;
            Console.Write("Digite o ano que você nasceu: ");
            dataNasc = int.Parse(Console.ReadLine());
            idade = 2026 - dataNasc;
            Console.WriteLine("Olá, Você tem " + idade + " anos");

            int idade;
            double altura;

            Console.Write("Digite sua idade: ");
            idade = int.Parse(Console.ReadLine());

            Console.Write("Digite a sua altura: ");
            altura = double.Parse(Console.ReadLine());

                    
            Console.WriteLine("A sua idade é: " + idade);
            Console.WriteLine("A sua altura é: " + altura);

            =====================================

            int a = 5;
            int b = 2;
            double resultado;
            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            resultado = (double)a / b;
            Console.WriteLine(resultado);
            Console.WriteLine(a % b);
            int c = 18;
            Console.WriteLine(c / 3.0);
            Console.WriteLine(a & b); //1
            
            ===================================

            int a = 10;
            int b = 2;

            double resultado = (double)a / b;

            Console.WriteLine($"Divisão inteira: {a / b}");
            Console.WriteLine($"Divisão Decimal: {resultado:F2}");

            
            double numero;
            Console.WriteLine("Digite um número: ");
            numero = double.Parse(Console.ReadLine());
            if (numero % 2 == 0)
            {
                Console.WriteLine("O número é par!");
            }
            else
            {
                Console.WriteLine("O número é impar");
            }
            */

            int num = 10;
            if (num == 10)
            {
                Console.WriteLine("num: igual a 10");
            }
            Console.WriteLine("Próxima Linha");



                Console.ReadKey();
        }
    }
}
