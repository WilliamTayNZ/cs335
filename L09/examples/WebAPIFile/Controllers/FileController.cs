using Microsoft.AspNetCore.Mvc;

namespace WebAPIImg.Controllers
{
    [Route("api")]
    [ApiController]
    public class FileController : Controller
    {
        [HttpGet("GetFile/{name}")]
        public ActionResult GetFile(string name)
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "Files");
            string fileName1 = Path.Combine(imgDir, name + ".png");
            string fileName2 = Path.Combine(imgDir, name + ".pdf");
            string respHeader = "";
            string fileName = "";
            if (System.IO.File.Exists(fileName1))
            {
                respHeader = "image/png";
                fileName = fileName1;
            }
            else if (System.IO.File.Exists(fileName2))
            {
                respHeader = "application/pdf";
                fileName = fileName2;
            }
            else
                return NotFound("File not found");
            return PhysicalFile(fileName, respHeader);
        }
    }
}
