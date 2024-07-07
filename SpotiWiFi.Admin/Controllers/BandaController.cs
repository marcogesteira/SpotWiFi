using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotiWiFi.Application.Streaming;
using SpotiWiFi.Application.Streaming.Dto;

namespace SpotiWiFi.Admin.Controllers
{
    [Authorize]
    public class BandaController : Controller
    {
        private BandaService _bandaService;
        private IWebHostEnvironment _webHostEnv;

        public BandaController(BandaService bandaService, IWebHostEnvironment webHostEnv)
        {
            _bandaService = bandaService;
            _webHostEnv = webHostEnv;
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

        public IActionResult CriarMusica(Guid id, Guid idAlbum)
        {
            ViewBag.Id = id;
            ViewBag.AlbumId = idAlbum;
            return View();
        }

        [HttpPost]
        public IActionResult SalvarMusica(Guid id, Guid idAlbum, MusicaDto dto)
        {
            dto.Id = new Guid();
            dto.AlbumId = idAlbum;

            this._bandaService.AssociarMusica(id, idAlbum, dto);

            return RedirectToAction("Index");
        }

        [Route("CreateReport")]
        public IActionResult CreateReport()
        {

            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\ReportMvc.frx");
            var reportFile = caminhoReport;

            var freport = new FastReport.Report();

            var listaBandas = _bandaService.Obter();

            freport.Dictionary.RegisterBusinessObject(listaBandas, "listaBandas", 10, true);
            freport.Report.Save(reportFile);

            return Ok($"Relatório gerado: {caminhoReport}");
        }

        [Route("BandaReport")]
        public IActionResult BandaReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\ReportMvc.frx");
            var reportFile = caminhoReport;

            var freport = new FastReport.Report();

            var listaBandas = _bandaService.Obter();

            freport.Report.Load(reportFile);
            freport.Dictionary.RegisterBusinessObject(listaBandas, "listaBandas", 10, true);
            freport.Prepare();
            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(freport, ms);
            ms.Flush();
            return File(ms.ToArray(), "application/pdf");
        }
    }
}
