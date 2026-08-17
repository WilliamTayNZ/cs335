using A1.Models;
public interface IA1Repo
{
    IEnumerable<Sign> GetAllSigns();
    IEnumerable<Sign> GetSignsBySearchTerm(string searchTerm);
}