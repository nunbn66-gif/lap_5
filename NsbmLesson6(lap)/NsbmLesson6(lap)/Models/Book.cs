using Microsoft.AspNetCore.Mvc.Rendering;

namespace NsbmLesson6.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPages { get; set; }
        public string Sumary { get; set; }
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id=1,
                    Title="Chí Phèo",
                    AuthorId=1,
                    GenreId=1,
                    Image="wwwroot/img/2.jpg",
                    Price=100000,
                    TotalPages=200,
                    Sumary="Một tác phẩm kinh điển của Nam Cao"
                }
            };
            return books;
        }
        public Book GetBookById(int id)
        { Book book=this.GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }

        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Nam Cao" },
            new SelectListItem { Value = "2", Text = "Ngô Tất Tố" },
            new SelectListItem { Value = "3", Text = "Adamkhoom" }
        };
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text="Truyện tranh" },
            new SelectListItem { Value = "2", Text="Tiểu thuyết" },
            new SelectListItem { Value = "3", Text="Khoa học viễn tưởng" }
        };

    }
    }


