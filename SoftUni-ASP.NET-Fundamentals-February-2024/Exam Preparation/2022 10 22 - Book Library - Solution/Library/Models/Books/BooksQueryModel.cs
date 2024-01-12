namespace Library.Models.Books
{
    public class AllBooksQueryModel
    {
        public IEnumerable<AllBookViewModel> Books { get; set; }
          = new List<AllBookViewModel>();
    }
}
//Query 