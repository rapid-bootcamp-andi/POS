using POS.Repository;

namespace POS.Service
{
    public class CategoryService
    {
        private readonly AplikasiContext _context;
        public CategoryService(AplikasiContext context)
        {
            _context = context;
        }

        public List<Category> GetCategory()
        {
            return _context.CategoryEntities.ToList();
        }
    }
}