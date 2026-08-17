using Microsoft.AspNetCore.Mvc;

using A1.Models;

[Route("webapi")]
[ApiController]
public class A1Controller : Controller
{
    private readonly IA1Repo _repo;
    
    public A1Controller(IA1Repo repo)
    {
        _repo = repo;
    }

    [HttpGet("GetVersion")]
    public string GetVersion()
    {
        return "1.0.0 (Ngāruawāhia) by wtay241";
    }

    [HttpGet("Logo")]
    public ActionResult Logo()
    {
        string path = Directory.GetCurrentDirectory();
        string logosDir = Path.Combine(path, "Logos");
        string fileName = Path.Combine(logosDir, "Logo.png");

        if (!System.IO.File.Exists(fileName))
        {
            return NotFound("File not found");
        }

        return PhysicalFile(fileName, "image/png");
    }

    [HttpGet("AllSigns")]
    public ActionResult<IEnumerable<Sign>> AllSigns()
    {
        IEnumerable<Sign> signs = _repo.GetAllSigns();
        return Ok(signs);
    }

    [HttpGet("Signs/{searchTerm}")]
    public ActionResult<IEnumerable<Sign>> Signs(string searchTerm)
    {
        IEnumerable<Sign> signs = _repo.GetSignsBySearchTerm(searchTerm);
        return Ok(signs);
    }
}