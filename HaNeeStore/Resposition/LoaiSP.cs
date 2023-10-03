using HaNeeStore.Models;

namespace HaNeeStore.Resposition
{
    public class LoaiSP : ILoaiSP
    {
        private readonly HaneeStoreContext _context;
        public LoaiSP(HaneeStoreContext context)
        {
            _context = context;
        }
        public Category Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category Delete(string categoryid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCat()
        {
            return _context.Categories;
        }

        public Category GetCat(string categoryid)
        {
            return _context.Categories.Find(categoryid);
        }

        public Category Update(Category category)
        {
            _context.Update(category);
            _context.SaveChanges ();
            return category;
        }
    }
}
