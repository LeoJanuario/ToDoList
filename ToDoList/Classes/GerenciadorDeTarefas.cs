using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Classes
{
    internal class GerenciadorDeTarefas
    {
        private List<Tarefa> Tarefas = new List<Tarefa>();
        private int ProximoId = 1;

        public void AdicionarTarefa(string descricao)
        {
            var tarefa = new Tarefa
            {
                Id = ProximoId++,
                Descricao = descricao,
                Concluida = false
            };

            Tarefas.Add(tarefa);
        }

        public void AtualizarTarefa(int id, string descricao, bool concluido)
        {
            var tarefa = Tarefas.FirstOrDefault(t => t.Id == id);

            if (tarefa != null)
            {
                tarefa.Descricao = descricao;
                tarefa.Concluida = concluido;
            }
        }

        public void ConcluirTarefa(int id)
        {
            var tarefa = Tarefas.FirstOrDefault(t => t.Id == id);

            if (tarefa != null)
                tarefa.Concluida = true;
        }

        public void RemoverTarefa(int id)
        {
            var tarefa = Tarefas.FirstOrDefault(t => t.Id == id);

            Tarefas.Remove(tarefa);
        }

        public List<Tarefa> ListarTarefas()
        {
            return Tarefas;
        }
    }
}
