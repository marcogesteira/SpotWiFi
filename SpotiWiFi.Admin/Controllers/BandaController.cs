using Microsoft.AspNetCore.Mvc;
using SpotiWiFi.Application.Streaming;
using SpotiWiFi.Application.Streaming.Dto;

namespace SpotiWiFi.Admin.Controllers
{
    public class BandaController : Controller
    {
        private BandaService _bandaService;

        public BandaController(BandaService bandaService)
        {
            _bandaService = bandaService;
        }

        public IActionResult Index()
        {
            var result = this._bandaService.Obter();
            return View(result);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(BandaDto dto)
        {
            if (ModelState.IsValid == false)
            {
                return View("Criar");
            }

            this._bandaService.Criar(dto);

            return RedirectToAction("Index");
        }
        
        public IActionResult Albuns(Guid id)
        {
            ViewBag.Id = id;
            var result = this._bandaService.ObterAlbum(id);
            return View(result);
        }

        public IActionResult CriarAlbum(Guid id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public IActionResult SalvarAlbum(Guid id, AlbumDto dto)
        {
            if (ModelState.IsValid == false)
            {
                return View("CriarAlbum");
            }
            dto.BandaId = id;
            this._bandaService.AssociarAlbum(dto);

            return RedirectToAction("Index");
        }
    }
}
