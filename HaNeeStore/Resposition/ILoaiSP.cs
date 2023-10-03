using HaNeeStore.Models;

namespace HaNeeStore.Resposition
{
    public interface ILoaiSP
    {
        Category Add(Category category);
        Category Update(Category category);
        Category Delete(String categoryid);
        Category GetCat(String categoryid);

        IEnumerable<Category> GetAllCat();
    }
}
