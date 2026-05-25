using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Datas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Datas e Hora
            /*
            DateTime hoje = DateTime.Now;
            Console.WriteLine("Data e Hora atual: " + hoje);
            */

            /* Somente a data
            DateTime hoje = DateTime.Today;
            Console.WriteLine(hoje);
            */

            /* Criando uma data e Hora manualmente
            DateTime aniversario = new DateTime(2026, 05, 10, 14, 30, 00);
            Console.WriteLine(aniversario);
            */


            /* 
            dd - Dia
            MM - Mês
            yyyy - Ano
            HH - Hora (24)
            mm - Minutos
            ss - Segunddos
              */

            /*
            DateTime data = DateTime.Now;

            Console.WriteLine(data.ToString("dd/MM/yyyy"));
            Console.WriteLine(data.ToString("dd-MM-yyyy"));
            Console.WriteLine(data.ToString("HH:mm"));
            Console.WriteLine(data.ToString("dd/MM/yyyy HH:mm:ss"));
            */

            /*
            DateTime hoje = DateTime.Now;
            Console.WriteLine("Hoje: " + hoje);
            Console.WriteLine("Mais 10 dias: " + hoje.AddDays(10));
            Console.WriteLine("Mais 2 meses: " + hoje.AddMonths(2));
            Console.WriteLine("Mais 2 anos: " + hoje.AddYears(2));

            Console.WriteLine("Digite uma data (dd/MM/yyyy)");
            DateTime data = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Você digitou: " + data.ToString("dd/MM/yyyy"));
            */

            /*
            Console.WriteLine("Digite o ano do nascimento: ");
            int ano = int.Parse(Console.ReadLine());

            int idade = DateTime.Now.Year - ano;

            Console.WriteLine("Idade" + idade);             
            */

            DateTime inicio = new DateTime(2026, 5, 20);
            DateTime fim = new DateTime(2026, 5, 25);

            TimeSpan diferente = fim - inicio;

            Console.WriteLine("Dias: " + diferente.Days);
            Console.WriteLine("Horas " + diferente.Hours);
            Console.WriteLine("Minutos " + diferente.Minutes);
            Console.WriteLine("Segundos " + diferente.Seconds);

        }
    }
}
