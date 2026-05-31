using BusinessObjects.Models;

namespace Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
    }
}
