using Microsoft.AspNetCore.Mvc;
using Practica.Models;
using System.Diagnostics;
using System.Net;

namespace Practica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<bool> nuevo([FromBody] DTO ins)
        {
            var file = ins.firma.Split(new char[] { ',' }, StringSplitOptions.None);
            string filePath = "wwwroot/Firmas/" + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "-") + "_" + 1 + ".png";
            byte[] data = Convert.FromBase64String(file[1]);

            //guardar las imagenes en una carpeta que debes crear 
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(data, 0, data.Length);
            }
           
            //var datos = await _context.Tininspectores.Where(x => x.NInspectorId == nuevo.NInspectorId).FirstOrDefaultAsync();
            
            //Aqui lo descomentas y lo agregas 
            //if (datos != null)
            //{
            //    datos.SFirma = filePath;
            //    _context.Entry(datos).State = EntityState.Modified;
            //    _context.SaveChanges();
            //}
            return true;
        }
    }
}