using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;
using WebsiteFPT.Common;

namespace Models.Dao
{
    public class UserDao
    {
        WebsiteFPTDbContext db = null;
        public UserDao()
        {
            db = new WebsiteFPTDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Email = entity.Email;
                user.Address = entity.Address;
                user.NumberPhone = entity.NumberPhone;
                user.IdCourse = entity.IdCourse;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = Encryptor.MD5Hash(entity.Password);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);

        }
        public User GetByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);

        }
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public bool Login(string userName, string passWord)
        {
            var result = db.Users.Count(x => x.UserName == userName && x.Password == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<User> ListAll()
        {
            return db.Users.ToList();
        }
    }
}
