using RestWithASPNETCore.Data.Converter;
using RestWithASPNETCore.Data.VO;
using RestWithASPNETCore.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETCore.Data.Converters
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null) return new Book();
            return new Book
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null) return new BookVO();
            return new BookVO
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }

        public List<Book> ParseList(List<BookVO> origins)
        {
            if (origins == null) return new List<Book>();
            return origins.Select(item => Parse(item)).ToList();
        }

        public List<BookVO> ParseList(List<Book> origins)
        {
            if (origins == null) return new List<BookVO>();
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
