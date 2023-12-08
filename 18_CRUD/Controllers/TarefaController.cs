using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using _18_CRUD.Models;


namespace _18_CRUD.Controllers
{
    //Criando a classe TarefaController e herdando seus métodos de Controller
    public class TarefaController : Controller
    {
        //Criando um objeto _tarefas que armazenará uma lista de tarefas
        private static List<Tarefa> _tarefas = new List<Tarefa>();
        public IActionResult Index()
        {
            return View(_tarefas);
        }
        //Criando o método GET para carregar a tela
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Tarefa novaTarefa)
        {
            //Verificando o total de tarefas da lista e somando mais 1 para o ID
            novaTarefa.Id = _tarefas.Count + 1;
            //Adicionando minha nova tarefa à minha lista
            _tarefas.Add(novaTarefa);
            //Redirecionar para a página com a lista de tarefas
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int Id)
        {
            //Buscando na minha lista a tarefa que desejo alterar
            Tarefa tarefaBD = _tarefas.FirstOrDefault(t => t.Id == Id);
            //Verificando se encontrou a tarefa, se ela não é null
            if (tarefaBD == null)
            {
                return NotFound();
            }
            //Enviando para a View a tarefa encontrada que queremos alterar
            return View(tarefaBD);
        }

        [HttpPost]

        public IActionResult Editar (Tarefa tarefaEditando)
        {
            Tarefa tarefaDB = _tarefas.Find(t => t.Id == tarefaEditando.Id);
            if (tarefaDB == null)
            {
                return NotFound();
            }
            //Atualizando os dados da tarefa que já esta na lista
             tarefaDB.descricao = tarefaEditando.descricao;
             tarefaDB.concluida = tarefaEditando.concluida;
             //Redirecionando para a lista de tarefas
             return RedirectToAction("Index");
        }

        public IActionResult Deletar(int Id)
        {
            //Buscando na minha lista a tarefa que desejo alterar
            Tarefa tarefaBD = _tarefas.FirstOrDefault(t => t.Id == Id);
            //Verificando se encontrou a tarefa, se ela não é null
            if (tarefaBD == null)
            {
                return NotFound();
            }
            //Enviando para a View a tarefa encontrada que queremos deletar
            return View(tarefaBD);
        }

        [HttpPost]

        public IActionResult DeletarConfirmado(Tarefa tarefaDeletando)
        {
            //Buscando na minha lista a tarefa que desejo alterar
            Tarefa tarefaBD = _tarefas.FirstOrDefault(t => t.Id == tarefaDeletando.Id);
            //Verificando se encontrou a tarefa, se ela não é null
            if (tarefaBD == null)
            {
                return NotFound();
            }
            _tarefas.Remove(tarefaBD);
            //Enviando para a View a tarefa encontrada que queremos deletar
            return RedirectToAction("Index");
        }

        
       

    }
}