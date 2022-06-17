using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiverseTraining.Data;
using DiverseTraining.DTOs;
using DiverseTraining.Entities;
using DiverseTraining.Interface;
using Microsoft.EntityFrameworkCore;

namespace DiverseTraining.Service
{
    public class BookService : IBookService
    {
        private readonly DataContext _context;

        public BookService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BookDto>> GetAllBooks()
        {
            var records = await _context.Books.Select(x => new BookDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToListAsync();
            if (!records.Any())
            {
                return null;
            }
            return records;
        }
        public async Task<BookDto> GetBookById(int bookId)
        {
            var record = await _context.Books.Where(x => x.Id == bookId).Select(x => new BookDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                UserRegisterId = x.UserRegisterId
            }).FirstOrDefaultAsync();
            if (record == null)
            {
                return null;
            }
            return record;
        }
        public async Task<int> AddNewBook(BookDto bookDto, int userId)
        {
            //convert BookModel data to Book
            var book = new Books()
            {
                Name = bookDto.Name,
                Description = bookDto.Description,
                UserRegisterId = userId
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;

        }
        public async Task<bool> UpdateBook(int bookId, BookDto bookDto, int userId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id.Equals(bookId) && x.UserRegisterId.Equals(userId));
            if (book == null)
            {
                return false;
            }
            book.Name = bookDto.Name;
            book.Description = bookDto.Description;
            await _context.SaveChangesAsync();
            return true; 
        }
    }
}

