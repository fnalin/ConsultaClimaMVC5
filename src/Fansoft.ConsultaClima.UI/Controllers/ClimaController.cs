using Fansoft.ConsultaClima.Core.Contracts;
using Fansoft.ConsultaClima.UI.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Fansoft.ConsultaClima.UI.Controllers
{
    public class ClimaController : Controller
    {
        private readonly IPrevisaoTempoService _service;
        public ClimaController(IPrevisaoTempoService service)
        {
            _service = service;
        }

        [HttpGet, Route("get-tops"), OutputCache(Duration = 120)]
        public async Task<ActionResult> GetTops()
        {
            var max = await _service.ObterCidadesTopMaxAsync(3);
            var min = await _service.ObterCidadesTopMinAsync(3);

            var model = new ClimaGetTopsVM(max, min);
            return PartialView("_GetTops", model);
            //return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpGet, Route("get-cidades"), OutputCache(Duration = 300)]
        public async Task<ActionResult> GetCidades()
        {
            var cidades = await _service.ObterCidadesAsync();
            return Json(cidades.Select(d => new { id = d.Id, text = d.Nome }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("get-por-cidade")]
        public async Task<ActionResult> GetPorCidade(int cidadeId, string cidadeNome)
        {
            var data = await _service.ObterPorCidadeAsync(cidadeId);
            return PartialView("_GetPorCidade", new GetPorCidadeVM { Cidade = cidadeNome, Dados = data });

        }



    }
}
