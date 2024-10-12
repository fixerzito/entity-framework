using Microsoft.AspNetCore.Mvc;
using Web.BancoDados;
using Web.Entidades;
using Web.ViewModels;
using Web.ViewModels.Forms;

namespace Web.Controllers
{
    [Route("/cor")]
    public class CorController : Controller
    {
        private readonly VendasContexto _contexto;

        public CorController(VendasContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cores  = _contexto.Cores.ToList();

            //criar lista de objeto de cores que sera utilizado na tela
            var coresViewModel = new List<CorViewModel>();
            // ´percorrer cada uma das cores que form consultadas na tabeka de cores
            foreach(var cor in cores)
            {
                //inicializacao rapida de objeto
                var corViewModel = new CorViewModel
                {
                    Id = cor.Id,
                    Nome = cor.Nome,
                };


                coresViewModel.Add(corViewModel);
            }
            
            return View(coresViewModel);
        }

        [HttpGet]
        [Route("cadastrar")]
        public IActionResult Cadastrar()
        {
            var form = new CorCadastrarViewModel();
            return View(form);
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar(string nome)
        {
            //instanciando um objeto de classe Cor
            var cor = new Cor();
            // Atribuindo valor para a propriedade  
            cor.Nome = nome;

            // aicionando na tabela de cores a cor instanciada
            _contexto.Cores.Add(cor);
            //concretizando as alteraçpes feitas
            _contexto.SaveChanges();


            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("apagar")]

        public IActionResult apagar (int id)
        {
            //filtrando a cor por id
            var cor = _contexto.Cores.Find(id);

            // caso não encontrar retornar nuill comm mensagem
            if(cor is null)
            {
                return NotFound("Cor não encontrada");
            }

            //removendo cores
            _contexto.Cores.Remove(cor);
            // concretizando
            _contexto.SaveChanges();

            // retorna para a lista
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("editar")]

        public IActionResult Editar(int id)
        {
            var cor = _contexto.Cores.Find(id);
            if(cor is null)
            {
                return NotFound("Cor não encontrada");
            }

            var viewModel = new CorEditarViewModel();
            viewModel.Id = cor.Id;
            viewModel.Nome = cor.Nome;

            return View(viewModel);
        }

        [HttpPost]
        [Route("editar")]
        public IActionResult Editar(int id, string nome)
        {
            var cor = _contexto.Cores.Find(id);

            if(cor is null)
            {
                return NotFound("Cor não encontrada");
            }

            cor.Nome = nome;

            _contexto.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
