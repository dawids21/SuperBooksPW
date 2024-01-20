using MatuszewskiStasiak.SuperBooks.Core;
using MatuszewskiStasiak.SuperBooks.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace MatuszewskiStasiak.SuperBooks.BLC
{
    public class BLC // should be singleton
    {
        private IDAO dao;

        public BLC(IConfiguration configuration)
        {
            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DBLibraryName"]!;
            Assembly assembly = Assembly.UnsafeLoadFrom(libraryName);
            Type? typeToCreate = null;

            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsAssignableTo(typeof(IDAO)))
                {
                    typeToCreate = type;
                    break;
                }
            }
            ConstructorInfo? constructor = typeToCreate!.GetConstructor(new[] { typeof(IConfiguration) });
            if (constructor != null)
            {
                dao = (IDAO)constructor.Invoke(new object[] { configuration })!;
            }
            else
            {
                dao = (IDAO)Activator.CreateInstance(typeToCreate!, null)!;
            }
        }

        public IEnumerable<IBook> GetBooks() => dao.GetAllBooks();
        public IEnumerable<IPublisher> GetPublishers() => dao.GetAllPublishers();
        public IBook? GetBook(Guid id) => dao.GetBook(id);
        public IPublisher? GetPublisher(Guid id) => dao.GetPublisher(id);
        public IBook CreateNewBook(string name, Guid publisher, int yearPublished, BookType type) => dao.CreateNewBook(name, publisher, yearPublished, type);
        public IPublisher CreateNewPublisher(string name, string address, int yearCreated) => dao.CreateNewPublisher(name, address, yearCreated);
        public void EditBook(Guid id, string name, Guid publisher, int yearPublished, BookType type) => dao.EditBook(id, name, publisher, yearPublished, type);
        public void EditPublisher(Guid id, string name, string address, int yearCreated) => dao.EditPublisher(id, name, address, yearCreated);
        public void DeleteBook(Guid id) => dao.DeleteBook(id);
        public void DeletePublisher(Guid id) => dao.DeletePublisher(id);
        public IEnumerable<IPublisher> FilterPublishersByName(string name)
        {
            return dao.GetAllPublishers().Where(p => p.Name.ToLower().Contains(name.ToLower()));
        }
        public IEnumerable<IBook> FilterBooksByName(string name)
        {
            return dao.GetAllBooks().Where(p => p.Name.ToLower().Contains(name.ToLower()));
        }
    }
}