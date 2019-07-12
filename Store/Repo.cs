using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class Repo<T>
    {
        protected List<T> items;

        protected string db;
        
        public Repo(string filename = null)
        {
            filename = filename == null ? typeof(T).Name + "db.csv" : filename;

            items = new List<T>();

            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
            }

            else
            {
                var lines = File.ReadAllLines(filename);
                items = lines.Skip(1).Select(line => (T)Activator.CreateInstance(typeof(T), line)).ToList();
            }

            db = filename;
        }

        public void Add(T item)
        {
            items.Add(item);
            SaveChanges();
        }

        public void Remove(T item)
        {
            items.Remove(item);
            SaveChanges();
        }

        public T[] GetItems()
        {
            return items.ToArray();
        }

        public void SaveChanges()
        {
            var filelines = new StringBuilder();
            var props = typeof(T).GetProperties();

            for (var i = 0; i < props.Length; i++)
            {
                if (i == props.Length - 1)
                {
                    filelines.Append($"{props[i].Name}");
                }
                else
                {
                    filelines.Append($"{props[i].Name},");
                }
            }

            foreach (var item in items)
            {
                filelines.Append($"\n{item}");
            }

            File.WriteAllLines(db, new[] { filelines.ToString() });
        }
    }
}
