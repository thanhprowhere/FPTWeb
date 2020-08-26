using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class EnrollmentDao
    {
        WebsiteFPTDbContext db = null;
        public EnrollmentDao()
        {
            db = new WebsiteFPTDbContext();
        }
        public long Insert(Enrollment entity)
        {
            db.Enrollments.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Enrollment entity)
        {
            try
            {
                var enroll = db.Enrollments.Find(entity.ID);
                enroll.ID = entity.ID;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public IEnumerable<Enrollment> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Enrollment> model = db.Enrollments;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.User.UserName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }

        public Enrollment ViewDetail(int id)
        {
            return db.Enrollments.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var enroll = db.Enrollments.Find(id);
                db.Enrollments.Remove(enroll);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Enrollment> ListAll()
        {
            return db.Enrollments.ToList();
        }
    }
}

