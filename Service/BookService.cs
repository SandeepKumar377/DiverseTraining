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
                Description = x.Description
            }).ToListAsync();
            return records;
        }
        public async Task<BookDto> GetBookById(int id)
        {
            var records = await _context.Books.Where(x => x.Id == id).Select(x => new BookDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).FirstOrDefaultAsync();
            return records;
        }
        public async Task<int> AddNewBook(BookDto bookDto)
        {
            //convert BookModel data to Book
            var book = new Books()
            {
                Name = bookDto.Name,
                Description = bookDto.Description
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }
        public async Task UpdateBook(int id, BookDto bookDto)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                book.Name = bookDto.Name;
                book.Description = bookDto.Description;
                await _context.SaveChangesAsync();
            }
        }
    }
}