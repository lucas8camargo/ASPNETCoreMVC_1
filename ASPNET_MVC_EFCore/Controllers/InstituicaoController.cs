using ASPNET_MVC_EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq; // Seria necessário para ulizar o código Linq instituicoes.Select(i => i.InstituicaoId).Max() + 1

namespace ASPNET_MVC_EFCore.Controllers
{
    public class InstituicaoController : Controller
    {
        private static IList<Instituicao> instituicoes = new List<Instituicao>() {
        
            new Instituicao()
            {
                InstituicaoId = 1,
                Nome = "UniParaná",
                Endereco = "Paraná"
            },
            new Instituicao()
            {
                InstituicaoId = 2,
                Nome = "UniSanta",
                Endereco = "Santa Catarina"
            },
            new Instituicao()
            {
                InstituicaoId = 3,
                Nome = "UniSãoPaulo",
                Endereco = "São Paulo"
            },
            new Instituicao()
            {
                InstituicaoId = 4,
                Nome = "UniSulgrandense",
                Endereco = "Rio de Janeiro"
            },
            new Instituicao()
            {
                InstituicaoId = 5,
                Nome = "UniParaná",
                Endereco = "Paraná"
            },

        };

        /*
        public IActionResult Index()
        {
            return View(instituicoes); // É necessário informar a lista como argumento do método que retornar a View
        }
        */

        // Nesse exemplo, o retorno da View recebe os itens em ordem alfabética utilizando o LINQ antes de ser enviada a página index

        public ActionResult Index()
        {
            return View(instituicoes.OrderBy(i => i.Nome));
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instituicao instituicao)
        {
            instituicoes.Add(instituicao);
            instituicao.InstituicaoId = instituicoes.Select(i => i.InstituicaoId).Max() + 1;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoId == id).First());
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoId == instituicao.InstituicaoId).First());
            instituicoes.Add(instituicao);
            return RedirectToAction("Index");
        }
        */

        // No exemplo a seguir, o item é atualizado sem excluir e adicionar novamente a lista

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Instituicao instituicao) 
        {
            // Usando uma manipulação de array, o index é encontrado utilizando o LINQ e em seguida é substituido pelo objeto atualizado
            instituicoes[instituicoes.IndexOf(instituicoes.Where(i => i.InstituicaoId == instituicao.InstituicaoId).First())] = instituicao;
            return RedirectToAction("Index");
        }

        // Recuperando um item específico

        [HttpGet]
        public ActionResult Details(long id) 
        {
            return View(instituicoes.Where(i => i.InstituicaoId == id).First());
        }

        public ActionResult Delete(long id) 
        {
            return View(instituicoes.Where(i => i.InstituicaoId == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoId == instituicao.InstituicaoId).First());
            return RedirectToAction("Index");
        }
    }
}
