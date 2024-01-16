using SuperBooks.Interfaces;
using System.Reflection;

namespace SuperBooks.BLC
{
    public class BLC // should be singleton
    {
        private IDAO dao;

        public BLC(string libraryName)
        {
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
            // we should check if we are really creating the instance of IDAO
            dao = (IDAO) Activator.CreateInstance(typeToCreate!, null)!;
        }

        public IEnumerable<IBook> GetBooks() => dao.GetAllBooks();
        public IEnumerable<IPublisher> GetPublishers() => dao.GetAllPublishers();
    }
}