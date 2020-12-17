using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P2_Receitas_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciar classe Utilitaria
            Utilitaria util = new Utilitaria();

            // Instanciar Repositorios
            RepositorioUtilizador repositorioUtilizador = new RepositorioUtilizador();
            RepositorioReceitas repositorioReceitas = new RepositorioReceitas();
            RepositorioReceitasFavoritas repositorioReceitasFavoritas = new RepositorioReceitasFavoritas();

            // Declarar Utilizador (a instância foi feita na classe Repositório, ao ser criado o ArrayList)
            Utilizador user = null;

            bool validado;
            do
            {
                do
                {
                    // LOGIN
                    // Pede tipo de login até que seja um login válido
                    switch (util.EscolherLogIn())
                    {
                        case "1":
                            // Pede username e password
                            string username = util.LogInUsername();
                            string password = util.LogInPassword();

                            // Consulta dados no repositório e retorna Utilizador, caso exista, e null, caso não exista
                            user = repositorioUtilizador.Consultar(username, password);

                            // Mostra saudação (Olá, fulano! ou LogIn inválido!)
                            validado = util.MostraSaudacao(user);

                            break;

                        case "2":
                            // Pede username e password
                            string pin = util.LogInPin();

                            // Consulta o PIN no repositório
                            user = repositorioUtilizador.Consultar(pin);

                            // Mostra saudação (Olá, fulano! ou LogIn inválido!)
                            validado = util.MostraSaudacao(user);

                            break;

                        case "0":
                            return;

                        default:
                            Console.Clear();
                            Console.WriteLine("\n******* Caçarola Receitas *******\n");
                            Console.WriteLine("Opção inválida!");
                            validado = false;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                } while (validado == false);

                string opcao;
                do
                {   // MENU INICIAL
                    opcao = util.MostraMenuInicial();
                    switch (opcao)
                    {
                        // ADICIONAR RECEITAS
                        case "1":

                            // Pedir número de receitas que o usuário vai inserir
                            int n = util.PedirNumeroReceitas();
                            for (int i = 0; i < n; i++)
                            {
                                // Pedir informações da receita i:

                                // Nome da receita
                                string nomeReceita = util.PedirNomeReceita(i);

                                // Categoria da receita
                                Receita.EnumCategoria categoria = util.PedirCategoria();

                                // Pedir número (m) de ingredientes que compõem a receita
                                int m = util.PedirNumeroIngredientes();

                                // Pedir os m ingredientes e quantidades correspondentes
                                ArrayList ingredientes = util.PedirIngredientes(m);

                                // Pedir modo de preparo
                                string preparo = util.PedirPreparo();

                                // Pedir dificuldade da receita
                                Receita.EnumDificuldade dificuldade = util.PedirDificuldade();

                                // Pedir tempo de preparo da receita (em minutos)
                                int duracao = util.PedirDuracao();

                                // Perguntar se a receita já foi testada?
                                bool testada = util.PerguntarSeReceitaTestada();

                                // Adicionar receita ao ArrayList
                                // Declarar como Receita (genérico), mas...
                                Receita receita;

                                if (testada)
                                {
                                    // ...Instanciar como ReceitaTestada ou ...
                                    receita = new ReceitaTestada(nomeReceita, categoria, ingredientes, preparo, dificuldade, duracao);
                                }
                                else
                                {
                                    // ...Instanciar como ReceitaPorTestar
                                    receita = new ReceitaPorTestar(nomeReceita, categoria, ingredientes, preparo, dificuldade, duracao);
                                }

                                // Adicionar receita ao ArrayList em RepositorioReceitas
                                repositorioReceitas.AdicionarReceita(receita);

                                Console.Clear();
                            }
                            break;

                        // VER RECEITAS
                        case "2":

                            string tipoReceita;
                            do
                            {
                                do
                                {
                                    // Perguntar qual tipo de receita o utilizador deseja ver (Todas, apenas testadas, apenas por testar ou favoritas)
                                    tipoReceita = util.MenuVerReceitas();
                                    
                                    switch (tipoReceita)
                                    {
                                        // Ver todas as receitas
                                        case "1":
                                            ArrayList receitasTodas = repositorioReceitas.ConsultarReceitas();
                                            util.ListarReceitas(receitasTodas);
                                            break;
                                        // Ver apenas receitas testadas (true)
                                        case "2":
                                            ArrayList receitasTestadas = repositorioReceitas.ConsultarReceitas(true);
                                            util.ListarReceitas(true, receitasTestadas);
                                            break;
                                        // Ver apenas receitas por testar (false)
                                        case "3":
                                            ArrayList receitasPorTestar = repositorioReceitas.ConsultarReceitas(false);
                                            util.ListarReceitas(false, receitasPorTestar);
                                            break;
                                        // Ver apenar receitas favoritas
                                        case "4":
                                            ArrayList receitasFavoritas = repositorioReceitasFavoritas.ConsultarReceitasFavoritasPorutilizador(user);
                                            util.ListarReceitas(receitasFavoritas);
                                            break;
                                        // Voltar ao menu inicial
                                        case "0":
                                            break;
                                        // Opção inválida
                                        default:
                                            Console.WriteLine("\nOpção inválida!");
                                            Console.ReadKey();
                                            break;
                                    }
                                } while (tipoReceita != "1" && tipoReceita != "2" && tipoReceita != "3" && tipoReceita != "0");

                            } while (tipoReceita != "0");

                            break;

                        // FAVORITAR RECEITAS
                        case "3":
                            // Criar ArrayList de receitas
                            ArrayList receitas = repositorioReceitas.ConsultarReceitas();
                            ArrayList receitasFav = repositorioReceitasFavoritas.ConsultarReceitasFavoritasPorutilizador(user);
                            // Se existirem receitas registadas...
                            if (receitas.Count > 0)
                            {
                                // Listar na consola o número, o nome, a categoria e a dificuldade da receita
                                util.MostrarMenuReceitas(receitas);
                                // Perguntar quantas receitas o usuário deseja favoritar
                                int quantidade = util.PerguntarQuantidadeReceitasFavoritas(receitas, receitasFav, user);
                                if (quantidade != 0)
                                {
                                    // Salvar a receita como favorita
                                    util.FavoritarReceita(quantidade, receitas, user, repositorioReceitasFavoritas);
                                }
                            }
                            // Se não existirem receitas registadas, informar o usuário
                            else
                            {
                                Console.WriteLine("Não há receitas registadas.");
                                Console.ReadKey();
                            }                          

                            break;

                        // BUSCAR RECEITAS
                        case "4":
                            // Mostrar menu para busca de receita --> realiza busca pelo nome da receita
                            string nome = util.MostraMenuBuscarPorNome();
                            // Crias um ArrayList com as receitas encontradas na busca
                            ArrayList receitasEncontradas = repositorioReceitas.ConsultaReceitasPorNome(nome);
                            // Listar receitas encontradas
                            util.ListarReceitas(receitasEncontradas);
                            break;

                        // FAZER LOGOFF
                        case "0":
                            break;

                        // MOSTRAR MENU INICIAL NOVAMENTE
                        default:
                            Console.Clear();
                            Console.WriteLine("Opção inválida!");
                            break;
                    }

                } while (opcao != "0");
            } while (true);
        }
    }
}
