using SitemaComando.Data;
using SitemaComando.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SitemaComando.Models;

namespace MeuSiteEmMVC.Controllers
{
    public class FuncionarioController : Controller { 

 
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        public FuncionarioController(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        public IActionResult Index()
        {
            List<FuncionarioModel> funcionarios = _funcionarioRepositorio.BuscarTodos();

            return View(funcionarios);
        }
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            FuncionarioModel funcionario = _funcionarioRepositorio.ListarPorId(id);

            return View(funcionario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            FuncionarioModel funcionario = _funcionarioRepositorio.ListarPorId(id);
            return View(funcionario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _funcionarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "funcionario apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, não foi possivel apagar o funcionario!";
                }

                return RedirectToAction("Index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel apagar o funcionario ,tente novamente!, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");

            }
        }



        [HttpPost]
        public IActionResult Criar(FuncionarioModel funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _funcionarioRepositorio.Adicionar(funcionario);
                    TempData["MensagemSucesso"] = "Funcionario cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(funcionario);

            }
            catch (Exception erro)
            {
                _funcionarioRepositorio.Adicionar(funcionario);
                TempData["MensagemErro"] = $"Ops, não foi possivel casdatrar o funcionario ,tente novamente!, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }


        [HttpPost]
        public IActionResult Alterar(FuncionarioModel funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _funcionarioRepositorio.Atualizar(funcionario);
                    TempData["MensagemSucesso"] = "funcionario atualizado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", funcionario);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel atualizar o funcionario ,tente novamente!, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

