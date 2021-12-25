using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiverseTraining.DTOs;

namespace DiverseTraining.Interface
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBooks();
        Task<BookDto> GetBookById(int id);
        Task<int> AddNewBook(BookDto bookDto);
        Task UpdateBook(int id, BookDto bookDto);
    }
}