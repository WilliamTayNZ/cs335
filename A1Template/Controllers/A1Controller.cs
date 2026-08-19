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

    [HttpGet("SignImage/{id}")]
    public ActionResult SignImage(string id)
    {
        string path = Directory.GetCurrentDirectory();
        string imgDir = Path.Combine(path, "SignsImages");

        string[] extensions = { ".png", ".jpg", ".gif", ".pdf" };

        foreach (string extension in extensions)
        {
            string fileName = Path.Combine(imgDir, id + extension);

            if (System.IO.File.Exists(fileName))
            {
                string contentType = extension switch
                {
                    ".png" => "image/png",
                    ".jpg" => "image/jpeg",
                    ".gif" => "image/gif",
                    ".pdf" => "application/pdf",
                    _ => throw new InvalidOperationException("Unsupported file type")
                };

                return PhysicalFile(fileName, contentType);
            }
        }

        string defaultFilename = Path.Combine(imgDir, "default.png");
        return PhysicalFile(defaultFilename, "image/png");
    }

    [HttpGet("GetComment/{id}")]
    public ActionResult<Comment> GetComment(int id)
    {
        var comment = _repo.GetCommentById(id);

        if (comment == null)
        {
            return BadRequest($"Comment {id} does not exist.");
        }

        return Ok(comment);
    }

    [HttpPost("WriteComment")]
    public ActionResult<Comment> WriteComment(CommentInput commentInput)
    {
        Comment comment = new Comment {
            UserComment = commentInput.UserComment,
            Name = commentInput.Name,
            Time = DateTime.UtcNow.ToString("yyyyMMdd'T'HHmmss'Z'"),
            IP = Request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? ""
        };

        Comment result = _repo.AddComment(comment);

        return CreatedAtAction(nameof(GetComment), new { id = result.Id }, result);
    }

    [HttpGet("Comments/{count?}")]
    public ActionResult<IEnumerable<Comment>> Comments(int? count) 
    {
        IEnumerable<Comment> comments = _repo.GetComments(count ?? 5);

        return Ok(comments);
        
    }

}   