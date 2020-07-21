using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbpractice.Models
{
    public interface iPersonRepository
    {
        List<Person> GetAllPersons();
        Person GetById(int id);
        int Insert(Person person);
        int Update(Person person);
        int Delete(int id);
    }
}
