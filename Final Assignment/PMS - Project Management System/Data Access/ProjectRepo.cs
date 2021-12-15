using Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    class ProjectRepo : IRepository<Project, int>, IProjectRepo<string,int>
    {
        PMSEntities db;
        public ProjectRepo(PMSEntities db)
        {
            this.db = db;
        }
        public void Add(Project e)
        {
            db.Projects.Add(e);
            db.SaveChanges();
        }

        public void ChangeConfirmStatus(string status,int id)
        {
            var e = db.Projects.FirstOrDefault(en => en.id == id);
            e.confirm_status = status;
            db.Entry(e).CurrentValues.SetValues(e);
            db.SaveChanges();


        }

        public void ChangeConfirmStatus(Project e, Project d)
        {
            throw new NotImplementedException();
        }

   

        public void ChangeState(Project e)
        {
            throw new NotImplementedException();
        }

        public void ChangeState(string e)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var e = db.Projects.FirstOrDefault(en => en.id == id);
            db.Projects.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Project e)
        {
            var d = db.Projects.FirstOrDefault(en => en.id == e.id);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Project> Get()
        {
            return db.Projects.ToList();
        }

        public Project Get(int id)
        {
            return db.Projects.FirstOrDefault(e => e.id == id);
        }
    }
}
