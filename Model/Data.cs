using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace TechnicalSupport.Model
{
    static class Data
    {
        static public string LogIn(TechnicalSupportDBEntities db, int id)
        {
            SqlParameter Id = new SqlParameter("@id", id);
            return db.Database.SqlQuery<string>("select epassword from employee where employeeid = @id", Id).Single();
        }

        static public List<Client> GetAllClients(TechnicalSupportDBEntities db)
        {
            return db.Clients.ToList();
        }

        static public List<Answer> GetAllAnswers(TechnicalSupportDBEntities db, int id)
        {
            SqlParameter Id = new SqlParameter("@id", id);
            return db.Answers.SqlQuery("select * from Answer where HandlingId = @id", Id).ToList();
        }

        static public List<Department> GetAllDepartments(TechnicalSupportDBEntities db)
        {
            return db.Departments.ToList();
        }

        static public List<Handling> GetAllHandlings(TechnicalSupportDBEntities db, int cid, int eid)
        {
            SqlParameter Cid = new SqlParameter("@cid", cid);
            SqlParameter Eid = new SqlParameter("@eid", eid);
            return db.Handlings.SqlQuery("select * from handling where clientid = @cid and employeeid = @eid", Cid, Eid).ToList();
        }

        static public List<Employee> GetAllEmployees(TechnicalSupportDBEntities db)
        {
            return db.Employees.ToList();
        }

        static public Answer FindAnswer(TechnicalSupportDBEntities db, int id)
        {
            return db.Answers.First(x => x.AnswerId == id);
        }
        static public Client FindClient(TechnicalSupportDBEntities db, int id)
        {
            return db.Clients.First(x => x.ClientId == id);
        }
        static public Department FindDepartment(TechnicalSupportDBEntities db, string Name, string Level)
        {
            SqlParameter name = new SqlParameter("@name", Name);
            SqlParameter level = new SqlParameter("@level", Level);
            return db.Departments.SqlQuery("select * from department where dname = @name and dlevel = @level", name, level).Single();
        }
        static public Handling FindHandling(TechnicalSupportDBEntities db, int id)
        {
            return db.Handlings.First(x => x.HandlingId == id);
        }
        static public Employee FindEmployee(TechnicalSupportDBEntities db, int id)
        {
            return db.Employees.First(x => x.EmployeeId == id);
        }

        static public void DeleteAnswer(TechnicalSupportDBEntities db, Answer a)
        {
            db.Answers.Remove(a);
            db.SaveChanges();
        }
        static public void DeleteClient(TechnicalSupportDBEntities db, Client a)
        {
            db.Clients.Remove(a);
            db.SaveChanges();
        }
        static public void DeleteHandling(TechnicalSupportDBEntities db, Handling a)
        {
            db.Handlings.Remove(a);
            db.SaveChanges();
        }
        static public void DeleteEmployee(TechnicalSupportDBEntities db, Employee a)
        {
            db.Employees.Remove(a);
            db.SaveChanges();
        }

        static public void AddAnswer(TechnicalSupportDBEntities db, Answer a)
        {
            db.Answers.Add(a);
            db.SaveChanges();
        }
        static public void AddClient(TechnicalSupportDBEntities db, Client a)
        {
            db.Clients.Add(a);
            db.SaveChanges();
        }
        static public void AddDepartment(TechnicalSupportDBEntities db, Department a)
        {
            if (!(db.Departments.Any(i => i.DName == a.DName) && db.Departments.Any(i => i.DLevel == a.DLevel)))
            {
                db.Departments.Add(a);
                db.SaveChanges();
            }

        }
        static public void AddHandling(TechnicalSupportDBEntities db, Handling a)
        {
            db.Handlings.Add(a);
            db.SaveChanges();
        }
        static public void AddEmployee(TechnicalSupportDBEntities db, Employee a)
        {
            db.Employees.Add(a);
            db.SaveChanges();
        }

        static public void ChangeClient(TechnicalSupportDBEntities db, Client old, Client n)
        {
            var client = db.Clients.Find(old.ClientId);
            client.CPhone = n.CPhone;
            client.CFirstName = n.CFirstName;
            client.CLastName = n.CLastName;
            client.CSecondName = n.CSecondName;
            db.SaveChanges();
        }

        static public void ChangeEmployee(TechnicalSupportDBEntities db, Employee old, Employee n)
        {
            var emp = db.Employees.Find(old.EmployeeId);
            emp.EPhone = n.EPhone;
            emp.ELastName = n.ELastName;
            emp.EFirstName = n.EFirstName;
            emp.ESecondName = n.ESecondName;
            emp.EPassword = n.EPassword;
            emp.DepartmentId = n.DepartmentId;
            db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        static public void ChangeHandling(TechnicalSupportDBEntities db, Handling old, Handling n)
        {
            var handling = db.Handlings.Find(old.HandlingId);
            handling.HDate = n.HDate;
            handling.CText = n.CText;
            db.SaveChanges();
        }

        static public void ChangeAnswer(TechnicalSupportDBEntities db, Answer old, Answer a)
        {
            var answer = db.Answers.Find(old.AnswerId);
            answer.ADate = a.ADate;
            answer.CText = a.CText;
            db.SaveChanges();
        }
    }
}

