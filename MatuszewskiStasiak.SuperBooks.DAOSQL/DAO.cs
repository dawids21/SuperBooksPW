using MatuszewskiStasiak.SuperBooks.Core;
using MatuszewskiStasiak.SuperBooks.DAOSQL.BO;
using MatuszewskiStasiak.SuperBooks.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace MatuszewskiStasiak.SuperBooks.DAOSQL
{
    public class DAO : DbContext, IDAO
    {
        private IConfiguration _configuration;

        public DAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("Sqlite"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>()
                .HasMany(p => (ICollection<Book>)p.Books)
                .WithOne(b =>(Publisher) b.Publisher);
        }

        public virtual DbSet<Publisher> Publishers{ get; set; }
        public virtual DbSet<Book> Books { get; set; }

        public IBook CreateNewBook(IBook book)
        {
            return null;
        }

        public IPublisher CreateNewPublisher(IPublisher publisher)
        {
            return null;
        }

        public IEnumerable<IBook> GetAllBooks()
        {
            return Books.ToList();
        }

        public IEnumerable<IPublisher> GetAllPublishers()
        {
            return Publishers.ToList();
        }

        public void EditPublisher(IPublisher publisher)
        {
        }

        public void DeletePublisher(IPublisher publisher)
        {
        }

        public void EditBook(IBook book)
        {
        }

        public void DeleteBook(IBook book)
        {
        }

        public IBook GetBook(Guid id)
        {
            return null;
        }

        public IPublisher GetPublisher(Guid id)
        {
            return null;
        }
    }
}
