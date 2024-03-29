﻿using MatuszewskiStasiak.SuperBooks.Core;
using MatuszewskiStasiak.SuperBooks.DAOSQL.BO;
using MatuszewskiStasiak.SuperBooks.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
            string currentDirectory = AppContext.BaseDirectory;

            while (currentDirectory != null)
            {
                if (Directory.GetFiles(currentDirectory, "*.csproj").Length > 0 ||
                    Directory.GetFiles(currentDirectory, "*.sln").Length > 0)
                {
                    break;
                }
                currentDirectory = Path.GetDirectoryName(currentDirectory);
            }

            string dbPath = Path.Combine(currentDirectory, "superbooks.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>()
                .HasMany(p => (ICollection<Book>)p.Books)
                .WithOne(b =>(Publisher) b.Publisher);
        }

        public virtual DbSet<Publisher> Publishers{ get; set; }
        public virtual DbSet<Book> Books { get; set; }

        public IBook CreateNewBook(string name, Guid publisherID, int yearPublished, BookType type)
        {
            Publisher? publisher = Publishers.Find(publisherID);
            if (publisher == null)
            {
                throw new ArgumentException("Publisher not found");
            }
            Book book = new Book
            {
                Id = Guid.NewGuid(),
                Name = name,
                Publisher = publisher,
                YearPublished = yearPublished,
                Type = type
            };
            Books.Add(book);
            SaveChanges();
            return book;
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
            try
            {
                return Books.Include(b => b.Publisher).ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
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

        public void EditBook(Guid id, string name, Guid publisherID, int yearPublished, BookType type)
        {
            Book? book = Books.Find(id);
            if (book != null)
            {
                Publisher? publisher = Publishers.Find(publisherID);
                if (publisher == null)
                {
                    throw new ArgumentException("Publisher not found");
                }
                book.Name = name;
                book.Publisher = publisher;
                book.YearPublished = yearPublished;
                book.Type = type;
                SaveChanges();
            }
        }

        public void DeleteBook(Guid id)
        {
            Book? book = Books.Find(id);
            if (book != null)
            {
                Books.Remove(book);
                SaveChanges();
            }
        }

        public IBook? GetBook(Guid id)
        {
           return Books.Find(id);
        }

        public IPublisher? GetPublisher(Guid id)
        {
            return Publishers.Include(p => p.Books).FirstOrDefault(p => p.ID == id);
        }
    }
}
