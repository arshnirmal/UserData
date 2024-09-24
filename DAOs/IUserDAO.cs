using UserData.Models;

namespace UserData.DAOs {
    public interface IUserDAO {
        List<Person> ReadData();
        Person? ReadData(int id);
        Person AppendData(Person person);

        Person UpdateData(int id, Person person);
    }
}
