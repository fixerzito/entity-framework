using Microsoft.AspNetCore.Mvc;
using Web.BancoDados;
using Web.Entidades;
using Web.ViewModels;
using Web.ViewModels.Forms;

namespace Web.Controllers
{
    [Route("/opcional")]
    public class OpcionalController : Controller
    {
        public readonly VendasContexto _contexto;

        public OpcionalController(VendasContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var opcoes = _contexto.Opcoes.ToList();
            
            var opcoesViewModel = new List<OpcionalViewModel>();
            
            foreach (var opcao in opcoes)
            {
                var opcaoViewModel = new OpcionalViewModel
                {
                    Id = opcao.Id,
                    Nome = opcao.Nome,
                };

                opcoesViewModel.Add(opcaoViewModel);
            }

            return View(opcoesViewModel);
        }

        [HttpGet]
        [Route("cadastrar")]
        public IActionResult Cadastrar()
        {
            var form = new OpcionalCadastrarViewModel();
            return View(form);
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar(string nome)
        {
            //instanciando um objeto de classe Cor
            var opcional = new Opcoes();
            // Atribuindo valor para a propriedade  
            opcional.Nome = nome;

            // aicionando na tabela de cores a cor instanciada
            _contexto.Opcoes.Add(opcional);
            //concretizando as alteraçpes feitas
            _contexto.SaveChanges();


            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("apagar")]

        public IActionResult apagar(int id)
        {
            var opcional = _contexto.Opcoes.Find(id);

            if (opcional is null)
            {
                return NotFound("Opcional não encontrado");
            }

            //removendo cores
            _contexto.Opcoes.Remove(opcional);
            // concretizando
            _contexto.SaveChanges();

            // retorna para a lista
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("editar")]

        public IActionResult Editar(int id)
        {
            var opcional = _contexto.Opcoes.Find(id);
            if (opcional is null)
            {
                return NotFound("Opcional não encontrada");
            }

            var viewModel = new OpcionalEditarViewModel();
            viewModel.Id = opcional.Id;
            viewModel.Nome = opcional.Nome;

            return View(viewModel);
        }

        [HttpPost]
        [Route("editar")]
        public IActionResult Editar(int id, string nome)
        {
            var opcional = _contexto.Opcoes.Find(id);

            if (opcional is null)
            {
                return NotFound("Opcional não encontrada");
            }

            opcional.Nome = nome;

            _contexto.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
