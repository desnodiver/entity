using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public testEntities db { get; set; }
        public List<Test> Loadcategory ()
        {
            var res = new List<Test>();
            using (db = new testEntities())
            { 
                var categories = db.categories;
                foreach (category u in categories)
                {
                    res.Add(new Test
                    {
                        Id = u.Id,
                        Name = u.Name,
                        ParentId = u.ParentId,
                    });
                }
            }
            return res;
        }
        public void AddCategory(string Name, int? ParentId)
        {
            using (db = new testEntities())
            {
                category category = new category { Name = Name, ParentId = ParentId };
                db.categories.Add(category);
                db.SaveChanges();
            }
        }
        public void EditCategory(string Name, int? ParentId, int Id)
        {
            using (db = new testEntities())
            {
                category category = db.categories.Where(u =>u.Id == Id).FirstOrDefault();
                category.Name = Name;
                category.ParentId = ParentId;
                db.SaveChanges();
            }
        }
    }
}
