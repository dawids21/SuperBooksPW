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
    }
}