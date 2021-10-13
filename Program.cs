using System;

namespace ProjetoDIO
{
    class Program
    {
        static LivrosRepositorio repositorio = new LivrosRepositorio ();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoLeitor();
                  
                  while (opcaoUsuario.ToUpper() != "X")
        {
                     switch (opcaoUsuario)
           {
               case "1":
                    ListarLivros();
                    break;
               case "2":
                    InserirLivros();
                    break;
               case "3":
                    AtualizarLivros();
                    break;
               case "4":
                    ExcluirLivros();
                    break;
               case "5":
                    VisualizarLivros();
                    break;
               case "C":
                    Console.Clear();
                    break;

                default:
                 throw new ArgumentOutOfRangeException();
           } 
           opcaoUsuario = ObterOpcaoLeitor();
           }

           Console.WriteLine("Obrigado por utilizar nossos serviços.");
           Console.ReadLine();
        }
        private static void ExcluirLivros()
		{
			Console.Write("Digite o id do livro: ");
			int indiceLivros = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceLivros);
		}
        private static void VisualizarLivros()
		{
			Console.Write("Digite o id do livro: ");
			int indiceLivros = int.Parse(Console.ReadLine());

			var livros = repositorio.RetornaPorId(indiceLivros);

			Console.WriteLine(livros);
		}
         private static void AtualizarLivros()
		{
			Console.Write("Digite o id do livro: ");
			int indiceLivros = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Livro: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Lançamento do Livro: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Livro: ");
			string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o número de páginas: ");
            int entradaNumeroPaginas = int.Parse(Console.ReadLine());

            Console.Write("Digite a editora do livro: ");
            string entradaEditora = Console.ReadLine();


			Livros AtualizarLivros = new Livros (id: indiceLivros,
										Genero: (Genero)entradaGenero,
										Titulo: entradaTitulo,
										Ano: entradaAno,
										Descricao: entradaDescricao,
                                        NumeroPaginas: entradaNumeroPaginas,
                                        Editora: entradaEditora);

			repositorio.Atualizar(indiceLivros, AtualizarLivros);
		}
        private static void ListarLivros()
        {
            Console.WriteLine("Listar livros");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return;
            }
            
            foreach (var livros in lista)
            {
                var Excluido = livros.RetornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} {2}", livros.RetornaId(), livros.RetornaTitulo(), (Excluido ? "*Excluído*" : ""));
			}
            
        }

        private static void InserirLivros()
        {
            Console.WriteLine("Inserir novo livro");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));

            }

                Console.Write("Digite o gênero entre as opções acima:");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o Título do livro: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite a descrição do Livro: ");
                string entradaDescricao = Console.ReadLine();

                Console.Write("Digite o Ano de lançamento do livro:");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite o número de páginas do livro:");
                int entradaNumeroPaginas = int.Parse(Console.ReadLine());

                Console.Write("Digite a editora do livro:");
                string entradaEditora = Console.ReadLine();

                Livros NovoLivro = new Livros(id: repositorio.ProximoId(),
                                            Genero: (Genero) entradaGenero,
                                            Titulo: entradaTitulo,
                                            Descricao: entradaDescricao,
                                            Ano: entradaAno,
                                            NumeroPaginas: entradaNumeroPaginas,
                                            Editora: entradaEditora);
                repositorio.Insere(NovoLivro);
            }                      
            
               
         private static string ObterOpcaoLeitor()
        { 
            
            Console.WriteLine();
            Console.WriteLine("DIO Livros e desfrute de nosso acervo de livros!");
            Console.WriteLine("Informe sua opção:");
            
            Console.WriteLine("1 - Listar livros");
            Console.WriteLine("2 - Inserir novo livro");
            Console.WriteLine("3 - Atualizar livro");
            Console.WriteLine("4 - Excluir livro");
            Console.WriteLine("5 - Visualizar livro");
            Console.WriteLine("6 - Limpar tela");
            Console.WriteLine("7 - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
   }
}