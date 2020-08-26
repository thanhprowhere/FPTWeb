using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.Dao
{
    public class ManagerTopics
    {
        WebsiteFPTDbContext db = null;
        public ManagerTopics()
        {
            db = new WebsiteFPTDbContext();
        }

        public bool Update(Topic entity)
        {
            try
            {
                var topic = db.Topics.Find(entity.ID);
                topic.Name = entity.Name;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<Topic> ListAll()
        {
            return db.Topics.ToList();
        }
        public long Insert(Topic entity)
        {
            db.Topics.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public IEnumerable<Topic> ListAllPaging(int page, int pageSize)
        {
            return db.Topics.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }

        public Topic ViewDetail(int id)
        {
            return db.Topics.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var topic = db.Topics.Find(id);
                db.Topics.Remove(topic);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
