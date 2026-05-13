using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            int num = 35;
            //Console.WriteLine(num);
            if (num == 10)
            {
                Console.WriteLine("Igual a 10");
            }
            else if (num == 20) //Se não, se
            {
                Console.WriteLine("Igual a 20");
            }
            else if (num == 30)
            {
                Console.WriteLine("Igual a 30");
            }
            else
            {
                Console.WriteLine("Diferente de 10, 20 e 30");
            }*/

            /*
            int opcao;

            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Consultar");
            Console.WriteLine("3 - Sair");
            Console.WriteLine("Escolha uma Opção: ");
            opcao = int.Parse(Console.ReadLine());  // opcao está recebendo um Inteiro | int.Parse é uma conversão p/ Int | ReadLine Sempre recebe String

            switch (opcao)
            {
                case 1: Console.WriteLine("Cadastrar");
                    break;
                case 2: Console.WriteLine("Consultar");
                    break;
                case 3: Console.WriteLine("Sair");
                    break;
                default: Console.WriteLine("Opção Inválida");
                    break;
            }
            */


            /*
            int opcao, num1, num2;

            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Mult");
            Console.WriteLine("3 - Sub");
            Console.WriteLine("4 - Div");
            Console.WriteLine("Digite o valor do Num1: ");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Valor do Num2: ");
            num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Escolha uma Opção: ");
            opcao = int.Parse(Console.ReadLine());  // opcao está recebendo um Inteiro | int.Parse é uma conversão p/ Int | ReadLine Sempre recebe String

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Soma = "+ (num1+num2));
                    break;
                
                case 2:
                    Console.WriteLine("Multiplicação = "+ num1*num2);
                    break;
                
                case 3:
                    Console.WriteLine("Subtração = "+ (num1-num2));
                    break;

                case 4:
                    Console.WriteLine("Divisão = " + (num1/num2));
                    break;

                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
            */

            /*
            string produto;
            double preco;

            Console.WriteLine("Digite o nome do produto: ");
            produto = Console.ReadLine();
            Console.WriteLine("Digite o preço: ");
            preco = double.Parse(Console.ReadLine());
            Console.WriteLine($"Nome Produto: {produto} ");
            Console.WriteLine($"Preço produto: {preco} ");

            Console.ReadKey();
            */

            /*
            double numero;
            Console.WriteLine("Digite um número: ");
            numero = double.Parse(Console.ReadLine());

            if (numero % 2 == 0)
            {
                Console.WriteLine("PAR");
            }
            else
            {
                Console.WriteLine("IMPAR");
            }
            */

            /*
            double numero;
            Console.WriteLine("Digite um número: ");
            numero = double.Parse(Console.ReadLine());

            Console.WriteLine(numero % 2 == 0 ? "Par" : "Impar");
            Console.WriteLine(numero == 10 ? "Igual a 10" : "Diferente de 10");

            // Comparações Simples | Composta | Encadeada
            */

            /*
            string nome;
            double salario, novoSalario;

            Console.WriteLine("Digite o nome do Funcionário: ");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o salário: ");
            salario = double.Parse(Console.ReadLine());
            novoSalario = salario + (salario + 0.15);
            Console.WriteLine("Salário atual: "+ novoSalario);
            */


            /*
            Console.WriteLine($"Novo salário = {novoSalario:F2}");
            double percentual = 0.10;
            novoSalario = salario + (salario * percentual);
            
            novoSalario = salario + 1.10;
            novoSalario = salario + 0.10;
            salario += salario + 0.10;
            */

            /*
            int contador = 0; //Estrutura Enquanto
            while (contador<=10)
            {
                Console.WriteLine(contador);
                contador++;
            }
            */




            /*
            string senhaCorreta = "1234";
            string senhaDigitada = "";
            while (senhaDigitada != senhaCorreta)
            {
                Console.Write("Digite a Senha: ");
                senhaDigitada = Console.ReadLine();

                if (senhaDigitada == senhaCorreta)
                {
                    Console.WriteLine("Acesso Permitido");
                }
                else
                {
                    Console.WriteLine("Senha incorreta. Tente novamente. \n");
                }
            }
            */
             /*
            for (int i =0; i<=10; i++)
            {
                Console.WriteLine(i);
            }
             */

            for (int i = 0; i <= 10; i+=2)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
