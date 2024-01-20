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

        public IPublisher CreateNewPublisher(string name, string address, int yearCreated)
        {
            Publisher publisher = new Publisher
            {
                ID = Guid.NewGuid(),
                Name = name,
                Address = address,
                YearCreated = yearCreated,
                Books = new List<IBook>()
            };
            Publishers.Add(publisher);
            SaveChanges();
            return publisher;
        }

        public IEnumerable<IBook> GetAllBooks()
        {
            return Books.ToList();
        }

        public IEnumerable<IPublisher> GetAllPublishers()
        {
            return Publishers.ToList();
        }

        public void EditPublisher(Guid id, string name, string address, int yearCreated)
        {
            Publisher? publisher = Publishers.Find(id);
            if (publisher != null)
            {
                publisher.Name = name;
                publisher.Address = address;
                publisher.YearCreated = yearCreated;
                SaveChanges();
            }
        }

        public void DeletePublisher(Guid id)
        {
            Publisher? publisher = Publishers.Find(id);
            if (publisher != null)
            {
                Publishers.Remove(publisher);
                SaveChanges();
            }
        }

        public void EditBook(IBook book)
        {
        }

        public void DeleteBook(IBook book)
        {
        }

        public IBook? GetBook(Guid id)
        {
           return Books.Find(id);
        }

        public IPublisher? GetPublisher(Guid id)
        {
            return Publishers.Find(id);
        }
    }
}
