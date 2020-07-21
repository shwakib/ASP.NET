using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace dbpractice.Models
{
    public class PersonRepository : iPersonRepository
    {
        DataAccess dataAccess;
        public PersonRepository()
        {
            dataAccess = new DataAccess();
        }
        public int Delete(int id)
        {
            string sql = "delete from Persons where id="+id;
            int i = dataAccess.ExecuteQuery(sql);
            if (i > 0)
            {
                return i;
            }
            return 0;
        }

        public List<Person> GetAllPersons()
        {
            string sql = "select * from Persons";
            SqlDataReader reader=dataAccess.GetData(sql);
            if(reader.HasRows)
            {
                List<Person> personList = new List<Person>();
                while(reader.Read())
                {
                    Person p = new Person();
                    p.Id = (int)reader["Id"];
                    p.Name = reader["Name"].ToString();
                    p.Salary = Convert.ToDouble(reader["Salary"]);
                    personList.Add(p);
                }
                return personList;
            }
            return null;
        }

        public Person GetById(int id)
        {
            string sql = "select * from Persons where id="+id;
            SqlDataReader reader = dataAccess.GetData(sql);
                if (reader.HasRows)
                {

                    reader.Read();
                    Person p = new Person();
                    p.Id = (int)reader["Id"];
                    p.Name = reader["Name"].ToString();
                    p.Salary = Convert.ToDouble(reader["Salary"]);
                    return p;
                }
            return null;
            
        }

        public int Insert(Person person)
        {
            string sql = "insert into Persons(Name,Salary) values('" + person.Name + "'," + person.Salary + ")";
            int i= dataAccess.ExecuteQuery(sql);
            if(i>0)
            {
                return i;
            }
            return 0;
        }

        public int Update(Person person)
        {
            string sql = "update Persons SET Name='" + person.Name + "',Salary='" + person.Salary + "' where Id='" + person.Id + "'";
            int i = dataAccess.ExecuteQuery(sql);
            if (i > 0)
            {
                return i;
            }
            return 0;
        }
    }
}