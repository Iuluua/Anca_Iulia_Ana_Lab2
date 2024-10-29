using Anca_Iulia_Ana_Lab2.Models;

namespace Anca_Iulia_Ana_Lab2.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
