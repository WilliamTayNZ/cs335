using A1.Data;
using A1.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class A1Repo : IA1Repo
{
    private readonly A1DbContext _dbContext;
    public A1Repo(A1DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Sign> GetAllSigns()
    {
        IEnumerable<Sign> signs = _dbContext.Signs.ToList<Sign>();
        return signs;
    }

    public IEnumerable<Sign> GetSignsBySearchTerm(string searchTerm)
    {
        IEnumerable<Sign> signs = _dbContext.Signs.Where(s => s.Description.ToLower().Contains(searchTerm.ToLower())).ToList();
        return signs;
    }

    public Comment? GetCommentById(int id)
    {
        return _dbContext.Comments.FirstOrDefault(c => c.Id == id);

    }

    public Comment AddComment(Comment comment)
    {
        EntityEntry<Comment> entry = _dbContext.Comments.Add(comment);
        Comment c = entry.Entity;
        _dbContext.SaveChanges();

        return c;
    }

    public IEnumerable<Comment> GetComments(int count)
    {
        return _dbContext.Comments.OrderByDescending(c => c.Id).Take(count).ToList();
    }
}