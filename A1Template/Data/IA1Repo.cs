using A1.Models;
public interface IA1Repo
{
    IEnumerable<Sign> GetAllSigns();
    IEnumerable<Sign> GetSignsBySearchTerm(string searchTerm);

    Comment? GetCommentById(int id);
    Comment AddComment(Comment comment);

    IEnumerable<Comment> GetComments(int count);
}