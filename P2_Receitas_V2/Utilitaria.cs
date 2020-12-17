using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Receitas_V2
{
    class Utilitaria
    {
        #region Methods
        public string EscolherLogIn()
        {
            Console.WriteLine("\n******* Caçarola Receitas *******\n");
            Console.WriteLine("1 - Entrar com Username e Password\n2 - Entrar com PIN\n0 - SAIR DA APLICAÇÃO");
            Console.Write("\nEscolha uma forma de LogIn: ");

            string login = Console.ReadLine();

            return login;
        }

        public string LogInUsername()
        {
            Console.Write("\nUsername: ");

            string username = Console.ReadLine();

            return username;
        }

        public string LogInPassword()
        {
            Console.Write("Password: ");

            string password = Console.ReadLine();

            return password;
        }

        public string LogInPin()
        {
            Console.Write("\nInsira o PIN de 4 dígitos: ");

            string pin = Console.ReadLine();

            return pin;
        }

        public bool MostraSaudacao(Utilizador user)
        {
            // Validação (true ou false --> usuário existe ou não existe)
            if (user != null)
            {
                Console.Clear();
                Console.WriteLine("\n******* Caçarola Receitas *******\n");
                Console.WriteLine($"Olá, {user.Username}!\n");
                Console.ReadKey();

                return true;
            }
            else
            {
                Console.WriteLine("\nLogIn Inválido!");
                Console.ReadKey();

                return false;
            }
        }

        public string MostraMenuInicial()
        {
            Console.Clear();
            Console.WriteLine("\n******* Caçarola Receitas *******\n");
            Console.WriteLine("1 - Adicionar receitas\n2 - Ver receitas\n3 - Favoritar receitas\n4 - Buscar receita\n0 - FAZER LOGOFF");
            Console.Write("\nSelecione a opção desejada: "); 

            string opcao = Console.ReadLine();

            Console.Clear();

            return opcao;
        }

        public int PedirNumeroReceitas() 
        {
            Console.Write("\nQuantas receitas quer adicionar? ");

            int n = PedirInputInt();

            Console.Clear();

            return n;
        }

        public string PedirNomeReceita(int i)
        {
            Console.WriteLine("\n******* Caçarola Receitas *******\n");
            Console.WriteLine("Receita:\n");
            Console.Write($"{i + 1}ª receita: ");

            string nome = Console.ReadLine();

            return nome;
        }

        public Receita.EnumCategoria PedirCategoria()
        {
            Console.WriteLine("\n------------------------------------------------------------");
            Console.WriteLine("\nCategorias:\n\n1 - Aperitivo\n2 - Entrada\n3 - Prato Principal\n4 - Acompanhamento\n5 - Sobremesa\n6 - Bebida\n");
            Console.Write("Categoria da receita: ");

            int cat = PedirInputInt();

            Receita.EnumCategoria categoria = (Receita.EnumCategoria)cat;

            return categoria;
        }

        public int PedirNumeroIngredientes()
        {
            Console.WriteLine("\n------------------------------------------------------------");
            Console.WriteLine("\nIngredientes:");
            Console.Write("\nQuantos ingredientes quer adicionar? ");

            int i = PedirInputInt();

            Console.WriteLine("\n(Exemplo: Água = 10g / Farinha de trigo = 2 chávenas)");
            Console.WriteLine();

            return i;
        }

        public ArrayList PedirIngredientes(int m)
        {
            ArrayList ingredientes = new ArrayList();

            for (int i = 0; i < m; i++)
            {
                Console.Write($"{i + 1}º ingrediente: ");
                ingredientes.Add(Console.ReadLine());
            }

            return ingredientes;
        }

        public string PedirPreparo()
        {
            Console.WriteLine("\n------------------------------------------------------------");
            Console.WriteLine("\nModo de preparo:");
            Console.WriteLine("\nInsira o modo de preparo da sua receita:");

            string preparo = Console.ReadLine();

            return preparo;
        }

        public Receita.EnumDificuldade PedirDificuldade() 
        {
            Console.WriteLine("\n------------------------------------------------------------");
            Console.WriteLine("\nNível de dificuldade:\n\n1 - Fácil\n2 - Médio\n3 - Difícil\n");
            Console.Write("Dificuldade da receita: ");

            int dif = PedirInputInt();

            Receita.EnumDificuldade dificuldade = (Receita.EnumDificuldade) dif;

            return dificuldade;
        }

        public int PedirDuracao() 
        {
            Console.WriteLine("\n------------------------------------------------------------");
            Console.WriteLine("\nTempo de preparo:\n");
            Console.Write("Insira o tempo de preparo (em minutos): ");

            int duracao = PedirInputInt();

            return duracao;
        }

        public bool PerguntarSeReceitaTestada()
        {
            Console.WriteLine("\n------------------------------------------------------------");
            Console.WriteLine("\nEssa receita já foi testada?");
            Console.WriteLine("1 - SIM\n2 - NÃO");
            Console.Write("\nDigite uma opção: ");

            string input = Console.ReadLine();
            bool testada;

            switch (input)
            {
                case "1":
                    testada = true;
                    break;
                case "2":
                    testada = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    testada = false;
                    break;
            }

            return testada;
        }

        public string MenuVerReceitas()
        {
            Console.Clear();
            Console.WriteLine("\n******* Caçarola Receitas *******\n");
            Console.WriteLine("Quais receitas deseja ver?");
            Console.WriteLine("1 - Todas as receitas\n2 - Receitas testadas\n3 - Receitas por testar \n4 - Receitas favoritas\n0 - VOLTAR PARA MENU INICIAL");
            Console.Write("\nDigite uma opção: ");

            string tipoReceita = Console.ReadLine();

            return tipoReceita;
        }
        
        // Lista todas as receitas (todas registadas ou todas as favoritas, a depender do parâmetro)
        public void ListarReceitas(ArrayList receitas)
        {
            Console.Clear();

            if (receitas.Count > 0)
            {
                foreach (Receita item in receitas)
                {
                    Console.WriteLine($"{item.ConverteReceitaCompletaParaString()}\n");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Não foram encontradas receitas.");
            }
            
            Console.ReadKey();
            Console.Clear();
        }

        // Lista receitas testadas ou por testar, conforme escolhido pelo usuário
        public void ListarReceitas(bool testada, ArrayList receitasEncontradas)
        {
            Console.Clear();

            foreach (Receita item in receitasEncontradas)
            {
                Console.WriteLine($"{item.ConverteReceitaCompletaParaString()}\n");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            }

            if (receitasEncontradas.Count == 0)
            {
                if (testada)
                {
                    Console.WriteLine("Não foram registadas Receitas Testadas.");
                }
                else
                {
                    Console.WriteLine("Não foram registadas Receitas Por Testar.");
                }
            }

            Console.ReadKey();
            Console.Clear();
        }

        // Listar número, nome, categoria e dificuldade da receita
        public void MostrarMenuReceitas(ArrayList receitas)
        {
            Console.WriteLine("\n******* Caçarola Receitas *******\n");

            int i = 1;
            foreach (Receita item in receitas)
            {
                Console.WriteLine($"{i} - {item.ConverteReceitaMenuParaString()}\n");
                i++;
            }
        }
        
        // Pergunta quantas receitas usuário quer favoritar e verifica se o número inserido pelo usuário é maior que 0, e menor que o (número de receitas - número de receitas favoritas)
        public int PerguntarQuantidadeReceitasFavoritas(ArrayList receitas, ArrayList receitasFavoritas, Utilizador utilizador)
        {
            int quantReceitas = receitas.Count;
            int quantReceitasFavoritas = receitasFavoritas.Count;
            int limiteSup = (quantReceitas - quantReceitasFavoritas);
            int quantidade = 0;

            if (limiteSup <= 0)
            {
                Console.WriteLine("Você já favoritou todas as receitas.");
            }
            else
            {
                Console.Write("Quantas receitas deseja favoritar? ");
                quantidade = PedirInputInt(0, limiteSup);
            }

            return quantidade;
        }

        // Pergunta quais receitas o usuário deseja favoritas 
        // Direciona ao método do repositório que adc receitas ao ArrayList de receitasFavoritas
        public void FavoritarReceita(int quantidade, ArrayList receitas, Utilizador utilizador, RepositorioReceitasFavoritas repFav)
        {
            for (int i = 1; i <= quantidade; i++)
            {
                Console.Write($"\nInsira o número da {i}ª receita a favoritar: ");
                int numReceita = Convert.ToInt32(Console.ReadLine());
                
                // Verifica se a receita que o usuário escolheu para favoritar já está na sua lista de favoritos
                ReceitaFavorita rf = repFav.ConsultarReceitaFavoritaPorUtilizador((Receita)receitas[numReceita - 1], utilizador);
                if (rf == null)
                {
                    ReceitaFavorita favorita = new ReceitaFavorita(((Receita)receitas[numReceita - 1]), utilizador);
                    repFav.AdicionarReceitaFavoritaPorUsuario(favorita);
                    Console.WriteLine("\nSua receita foi salva como favorita.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\nEssa receita já está na sua lista de favoritos.");
                    Console.ReadKey();
                }    
            }
        } //Favoritar repetido --> tratar

        public string MostraMenuBuscarPorNome()
        {
            Console.WriteLine("\n******* Caçarola Receitas *******\n");
            Console.Write("Pesquisa: ");

            string nome = Console.ReadLine();

            return nome;
        }
        
        // Verifica se o input do usuário é um inteiro e caso não seja, pede novamente até que seja
        // Utilizado para pedir os inputs de informações da receita (número de receitas, categoria, número de ingredientes, dificuldade e duração)
        public int PedirInputInt()
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.Write("Valor inválido. Digite novamente: ");
            }

            return input;
        }

        public int PedirInputInt(int inf, int sup)
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input <= inf || input > sup)
            {
                Console.Write("Valor inválido. Digite novamente: ");
            }

            return input;
        }
        #endregion
    }
}
