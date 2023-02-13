using RestWithASP_NET.Model;

namespace RestWithASP_NET.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void delete(long id);
    }
}
