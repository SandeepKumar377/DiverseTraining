using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiverseTraining.DTOs;

namespace DiverseTraining.Interface
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBooks(int userId);
        Task<BookDto> GetBookById(int userId, int bookId);
        Task<int> AddNewBook(BookDto bookDto, int userId);
        Task<bool> UpdateBook(int bookId, BookDto bookDto, int userId);
    }
}