using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {





            string[] personagens = { "Guerreiro", "Mago", "Arqueiro" };
            //Console.WriteLine(personagens[0]);
            string[] itens = { "Espada de Ferro", "Cajaco Magico", "Arco Longo" };
            Console.WriteLine(itens[0]);
            string[] locais = { "Catelo Abandonado", "Floresta Sombria", "Vila dos Mercadores", "Caverna de Dragão" };
            Console.WriteLine(locais[0]);
            string[] inimigos = { "Globin", "Lobo Sombrio", "Guardiao de Pedra", "Dragao Sombrio" };

            Console.WriteLine("=========================");
            Console.WriteLine("     RPG COM VETORES     ");
            Console.WriteLine("=========================");

            Console.Write("Digite o nome do Herói: ");
            string nome = Console.ReadLine();

            Console.Write("");
            Console.WriteLine("Escolha o seu personagem: ");
            Console.WriteLine("1 - "+ personagens[0]);
            Console.WriteLine("2 - " + personagens[1]);
            Console.WriteLine("3 - " + personagens[2]);
            int opcaoPersonagem =int.Parse(Console.ReadLine());

            int vida = 100;
            int ouro = 20;
            int pocao = 1;
            if ((opcaoPersonagem >= 0) || (opcaoPersonagem <= 2))
            {
                Console.WriteLine("");
                Console.WriteLine("Heroi: " + nome);
                Console.WriteLine("Personagem: " + personagens[opcaoPersonagem]);
                Console.WriteLine("Item Inicial: " + itens[opcaoPersonagem]);
                Console.WriteLine("Vida: " + vida);
                Console.WriteLine("Ouro: " + ouro);
                Console.WriteLine("Poção: " + pocao);

                Console.WriteLine("");
                Console.WriteLine("Sua aventura começa no " + locais[1]);
                Console.WriteLine($"Um {inimigos[1]} aparece no corredor.");
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("1 - Atacar com " + itens[opcaoPersonagem]);
                Console.WriteLine("2 - Fugir");
                Console.WriteLine("3 - Tentar conversar");
                int escolheu = int.Parse(Console.ReadLine());

                switch (escolheu)
                {
                    case 1:
                        Console.WriteLine($"Você atacou o {inimigos[1]} e venceu.");
                        ouro = ouro + 40;
                        Console.WriteLine("Você ganhou 40 moedas");
                        break;

                    case 2:
                        Console.WriteLine("Você fugiu, mas caiu em uma armadilha");
                        vida = vida - 25;
                        Console.WriteLine("Vida atual: " + vida);
                        break;

                    case 3:
                        Console.WriteLine($"O {inimigos[1]} aceitou conversar");
                        Console.WriteLine("Ele revelou uma passagem secreta");
                        break;

                    default:
                        Console.WriteLine("Escolha inválida.");
                        break;
                }

                Console.WriteLine("");
                Console.WriteLine("Agora você encontra três caminhos: ");
                Console.WriteLine("1 - Ir para a " + locais[2]);
                Console.WriteLine("2 - Ir para a " + locais[3]);
                Console.WriteLine("Explorar uma sala secreta");
                escolheu = int.Parse(Console.ReadLine());

                switch (escolheu)
                {
                    case 1:
                        Console.WriteLine("");
                        Console.WriteLine($"Você entrou na {locais[2]}");
                        Console.WriteLine($"um {inimigos[2]} apareceu");
                        Console.WriteLine("1 - Lutar");
                        Console.WriteLine("2 - Subir em uma árvore");
                        escolheu = int.Parse(Console.ReadLine());
                        
                        switch (escolheu)
                        {
                            case 1:
                                Console.WriteLine("Você venceu o Lobo");
                                ouro = ouro + 30;
                                break;
                            case 2:
                                Console.WriteLine("Você escapou, mas se feriu");
                                vida = vida - 15;
                                break;

                            default:
                                Console.WriteLine("Escolha Inválida!");
                                break;
                        }
                        break;

                    case 2:
                        Console.WriteLine("");
                        Console.WriteLine("Você chegou na " + locais[3]);
                        Console.WriteLine("Um comerciante oferece itens ");
                        Console.WriteLine("1 - comprar pocao por 20 moedas");
                        Console.WriteLine("2 - Comprar armadura por 30 moedas");
                        Console.WriteLine("3 - Não comprar nada");
                        
                        escolheu = int.Parse(Console.ReadLine());

                        switch (escolheu)
                        {
                            case 1: 
                                if (ouro >= 20)
                                {
                                    ouro = ouro - 20;
                                    pocao = pocao + 1;
                                        Console.WriteLine("Você comprou uma poção");
                                }
                                else
                                {
                                    Console.WriteLine("Ouro insuficiente");
                                }
                            break;

                            case 2:
                                if (ouro >= 20)
                                {
                                    ouro = ouro - 30;
                                    vida = vida + 20;
                                    Console.WriteLine("Você comprou uma armadura");
                                    Console.WriteLine("Vida aumentada");
                                }
                                else
                                {
                                    Console.WriteLine("Ouro Insuficiente");
                                }
                            break;
                            case 3:
                                Console.WriteLine("Você decidiu guardar seu ouro");
                            break;
                            default:
                                Console.WriteLine("Opção Inválida");
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("");
                        Console.WriteLine("Você encontrou uma sala secreta");
                        Console.WriteLine("Dentro dela havia um baú");
                        Console.WriteLine("1 - Abrir baú");
                        Console.WriteLine("2 - Ignorar baú");
                        escolheu = int.Parse(Console.ReadLine());

                        switch(escolheu)
                        {
                            case 1:
                                Console.WriteLine("O baú tinha ouros e uma poção");
                                ouro = ouro + 80;
                                pocao = pocao + 1;
                                break;

                            case 2:
                                Console.WriteLine("Você saiu da sala sem pegar nada");
                                break;
                            default:
                                Console.WriteLine("Escolha inválida");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }

                Console.WriteLine("");
                Console.WriteLine("Depois de continuar a jornada, você chega na " + locais[4]);
                Console.WriteLine($"Antes de entrar, um {inimigos[3]} bloqueia a passagem");
                Console.WriteLine("1 - Atacar");
                Console.WriteLine("2 - Usar poção");
                Console.WriteLine("3 - Tentar enganar o Guardião");
                escolheu = int.Parse(Console.ReadLine());

                switch (escolheu)
                {
                    case 1:
                        Console.WriteLine("Você lutou contra o " + inimigos[3]);
                        vida = vida - 30;
                        Console.WriteLine("Você venceu, mas perdeu vida");
                        Console.WriteLine("Vida Atual: " + vida);
                        break;
                    case 2:
                        if (pocao > 0)
                        {
                            pocao = pocao - 1;
                            vida = vida + 40;
                            Console.WriteLine("Você usou uma poção");
                            Console.WriteLine("Vida atual: " + vida);
                        }
                        else
                        {
                            Console.WriteLine("Você não possui poções");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Você enganou o guardião e passou sem lutar");
                        ouro = ouro + 30;
                        break;

                    default:
                        Console.WriteLine("Escolha inválida");
                        break;
                }
                Console.WriteLine("");
                Console.WriteLine("BATALHA FINAL!");
                Console.WriteLine($"O {inimigos[4]} apareceu");
                Console.WriteLine("1 - Atacar com tudo");
                Console.WriteLine("2 - Defender Primeiro ");
                Console.WriteLine("3 - Usar poção antes da luta");
                escolheu = int.Parse(Console.ReadLine());


                switch (escolheu)
                {
                    case 1:
                        if (vida >= 80)
                        {
                            Console.WriteLine("Você atacou com coragem e derrotou o dragão!");
                            ouro = ouro + 300;
                        }
                        else
                        {
                            Console.WriteLine("Você estava fraco demais");
                            vida = 0;
                        }
                            break;

                    case 2:
                        Console.WriteLine("Você defendeu o primeiro ataque");
                        vida = vida - 20;
                        if (vida > 0)
                        {
                            Console.WriteLine("Depois da defesa, você contra-atacou e venceu!");
                            ouro = ouro + 250;
                        }
                        else
                        {
                            Console.WriteLine("O ataque do dragão foi muito forte.");
                        }
                            break;

                    case 3:
                    if (pocao > 0)
                        {
                            pocao = pocao - 1;
                            vida = vida + 50;
                            Console.WriteLine("Você usou uma poção antes da batalha");
                            Console.WriteLine("Com mais energia, você venceu o dragão");
                            ouro = ouro + 300;
                        }
                        else
                        {
                            Console.WriteLine("Você não tinha poção");
                            vida = vida - 50;
                        }
                            break;
                    default:
                        Console.WriteLine("Escolha inválida");
                        break;
                }

                Console.WriteLine("=========================");
                Console.WriteLine("     FIM DA AVENTURA     ");
                Console.WriteLine("=========================");
                Console.WriteLine("Heroi: " + nome);
                Console.WriteLine("Personagem: " + personagens[opcaoPersonagem]);
                Console.WriteLine("Item Principal: " + itens[opcaoPersonagem]);
                Console.WriteLine("Vida final: " + vida);
                Console.WriteLine("Ouro final: " + ouro);
                Console.WriteLine("Poções restantes: " + pocao);

                if (vida > 0)
                {
                    Console.WriteLine("Parabéns! Você sobreviveu a aventura.");
                }
                else
                {
                    Console.WriteLine("Você foi derrotado na jornada");
                }
                //Personagens
            }
            else
            {
                Console.WriteLine("Personagem Inválido.");
            }
        // static void main
        }
    }
}
