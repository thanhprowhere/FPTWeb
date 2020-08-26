using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.Dao
{
    public class CategoryCourseDao
    {
        WebsiteFPTDbContext db = null;
        public CategoryCourseDao()
        {
            db = new WebsiteFPTDbContext();
        }
        public IEnumerable<CourseCategory> ListAllPaging(int page, int pageSize)
        {
            return db.CourseCategories.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public long Insert(CourseCategory entity)
        {
            db.CourseCategories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(CourseCategory entity)
        {
            try
            {
                var course = db.CourseCategories.Find(entity.ID);
                course.Name = entity.Name;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public CourseCategory ViewDetail(int id)
        {
            return db.CourseCategories.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var CourseCategories = db.CourseCategories.Find(id);
                db.CourseCategories.Remove(CourseCategories);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<CourseCategory> ListAll()
        {
            return db.CourseCategories.ToList();
        }

    }
}
