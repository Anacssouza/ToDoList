using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Repositorio;

namespace ToDoList.Controllers
{
    public class Atividades : Controller
    {
        private readonly IAtividadeRepositorio _atividadeRepositorio;
        public Atividades(IAtividadeRepositorio atividadeRepositorio)
        {
            _atividadeRepositorio = atividadeRepositorio;
        }
        public IActionResult Index()
        {
            List<AtividadesModel> atividades = _atividadeRepositorio.BuscarTodos();
            return View(atividades);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)

        {
           AtividadesModel atividade = _atividadeRepositorio.ListarPorId(id);
            return View(atividade);
        }

        public IActionResult Apagar(int id)
        {
            AtividadesModel atividade = _atividadeRepositorio.ListarPorId(id);
            return View(atividade);
        }

        public IActionResult Apaga(int id)
        {
            try
            {
                bool apagado = _atividadeRepositorio.Apaga(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Atividade apagada com Sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = $"Sentimos muito, mas não foi possível Atualizae a atividade, tente novamente.";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Sentimos muito, mas não foi possível Atualizae a atividade, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]

        public IActionResult Criar(AtividadesModel atividade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _atividadeRepositorio.Adicionar(atividade);
                    TempData["MensagemSucesso"] = "Atividade Cadastrada com Sucesso";
                    return RedirectToAction("Index");
                }

                return View(atividade);
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Sentimos muito, mas não foi possível cadastrar a nova atividade, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]

        public IActionResult Alterar(AtividadesModel atividade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _atividadeRepositorio.Atualizar(atividade);
                    TempData["MensagemSucesso"] = "Atividade Alterada com Sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", atividade);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Sentimos muito, mas não foi possível Atualizae a atividade, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
