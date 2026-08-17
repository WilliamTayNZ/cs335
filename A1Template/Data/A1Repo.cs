using A1.Data;
using A1.Models;
using Microsoft.AspNetCore.Http.HttpResults;

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
}