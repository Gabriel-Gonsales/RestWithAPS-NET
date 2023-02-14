using RestWithASP_NET.Model;

namespace RestWithASP_NET.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void delete(long id);

        bool Exists(long id);
    }
}
