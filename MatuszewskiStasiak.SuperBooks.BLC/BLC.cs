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
        public IBook CreateNewBook(IBook book) => dao.CreateNewBook(book);
        public IPublisher CreateNewPublisher(string name, string address, int yearCreated) => dao.CreateNewPublisher(name, address, yearCreated);
        public void EditBook(IBook book) => dao.EditBook(book);
        public void EditPublisher(Guid id, string name, string address, int yearCreated) => dao.EditPublisher(id, name, address, yearCreated);
        public void DeleteBook(IBook book) => dao.DeleteBook(book);
        public void DeletePublisher(Guid id) => dao.DeletePublisher(id);
    }
}