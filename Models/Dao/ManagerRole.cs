using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;


namespace Models.Dao
{
    public class ManagerRole
    {
        WebsiteFPTDbContext db = null;
        public ManagerRole()
        {
            db = new WebsiteFPTDbContext();
        }
        public long Insert(Role entity)
        {
            db.Roles.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Role entity)
        {
            try
            {
                var role = db.Roles.Find(entity.ID);
                role.Name = entity.Name;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public IEnumerable<Role> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Role> model = db.Roles;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }

        public Role ViewDetail(int id)
        {
            return db.Roles.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var role = db.Roles.Find(id);
                db.Roles.Remove(role);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Role> ListAll()
        {
            return db.Roles.ToList();
        }
    }
}
