using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    [Serializable]
    public class ManagerCourse
    {
        WebsiteDbContext db = null;
        public ManagerCourse()
        {
            db = new WebsiteDbContext();
        }
        public long Insert(Course entity)
        {
            db.Courses.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Course entity)
        {
            try
            {
                var course = db.Courses.Find(entity.ID);
                course.Name = entity.Name;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public IEnumerable<Course> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Course> model = db.Courses;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.IdCategoryCourse).ToPagedList(page, pageSize);
        }

        public Course ViewDetail(int id)
        {
            return db.Courses.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var course = db.Courses.Find(id);
                db.Courses.Remove(course);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Course> ListAll()
        {
            return db.Courses.ToList();
        }
    }
}

