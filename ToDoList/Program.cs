using ToDoList.Classes;

class Program
{
    static void Main(string[] args)
    {
        GerenciadorDeTarefas gerenciador = new GerenciadorDeTarefas();

        ExibirMenu();

        void ExibirLogo()
        {
            Console.WriteLine(@"

    ████████╗░█████╗░  ██████╗░░█████╗░  ██╗░░░░░██╗░██████╗████████╗
    ╚══██╔══╝██╔══██╗  ██╔══██╗██╔══██╗  ██║░░░░░██║██╔════╝╚══██╔══╝
    ░░░██║░░░██║░░██║  ██║░░██║██║░░██║  ██║░░░░░██║╚█████╗░░░░██║░░░
    ░░░██║░░░██║░░██║  ██║░░██║██║░░██║  ██║░░░░░██║░╚═══██╗░░░██║░░░
    ░░░██║░░░╚█████╔╝  ██████╔╝╚█████╔╝  ███████╗██║██████╔╝░░░██║░░░
    ░░░╚═╝░░░░╚════╝░  ╚═════╝░░╚════╝░  ╚══════╝╚═╝╚═════╝░░░░╚═╝░░░
    ");
        }

        void ExibirMenu()
        {
            ExibirLogo();

            Console.WriteLine("1. Adicionar Tarefa");
            Console.WriteLine("2. Listar Tarefas");
            Console.WriteLine("3. Atualizar Tarefa");
            Console.WriteLine("4. Remover Tarefa");
            Console.WriteLine("5. Concluir Tarefa");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite a descrição da tarefa: ");
                    var descricao = Console.ReadLine();
                    gerenciador.AdicionarTarefa(descricao);
                    Console.WriteLine($"A tarefa foi registrada com sucesso!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    ExibirMenu();
                    break;
                case "2":
                    var tarefas = gerenciador.ListarTarefas();
                    foreach (var tarefa in tarefas)
                    {
                        Console.WriteLine($"{tarefa.Id}. {tarefa.Descricao} - {(tarefa.Concluida ? "Concluída" : "Pendente")}");
                    }
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirMenu();
                    break;
                case "3":
                    Console.Write("Digite o ID da tarefa a ser atualizada: ");
                    var idAtualizar = int.Parse(Console.ReadLine());
                    Console.Write("Digite a nova descrição: ");
                    var novaDescricao = Console.ReadLine();
                    Console.Write("A tarefa está concluída? (s/n): ");
                    var concluida = Console.ReadLine().ToLower() == "s";
                    gerenciador.AtualizarTarefa(idAtualizar, novaDescricao, concluida);
                    Console.WriteLine($"A tarefa foi atualizada com sucesso!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    ExibirMenu();
                    break;
                case "4":
                    Console.Write("Digite o ID da tarefa a ser removida: ");
                    var idRemover = int.Parse(Console.ReadLine());
                    gerenciador.RemoverTarefa(idRemover);
                    Console.WriteLine($"A tarefa foi removida com sucesso!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    ExibirMenu();
                    break;
                case "5":
                    Console.WriteLine("Digite o ID da tarefa que deseja concluir: ");
                    var idConcluir = int.Parse(Console.ReadLine());
                    gerenciador.ConcluirTarefa(idConcluir);
                    Console.WriteLine($"A tarefa foi concluída com sucesso!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    ExibirMenu();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    ExibirMenu();
                    break;
            }
        }
    }
}
