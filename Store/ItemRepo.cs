using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class ItemRepo
    {
        List<Item> items;
        string db;

        public ItemRepo(string filename = "Itemdb.csv")
        {
            items = new List<Item>();

            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
            }

            else
            {
                var lines = File.ReadAllLines(filename);
                items = lines.Skip(1).Select(line => new Item(line)).ToList();
            }

            db = filename;
        }

        public void Add(Item item)
        {
            items.Add(item);
            SaveChanges();
        }

        public void Remove(Item item)
        {
            items.Remove(item);
            SaveChanges();
        }

        public Item[] GetItems()
        {
            return items.ToArray();
        }

        public void SaveChanges()
        {
            var filelines = new StringBuilder();
            var props = typeof(Item).GetProperties();

            for (var i = 0; i < props.Length; i++)
            {
                if (i == props.Length - 1)
                {
                    filelines.Append($"{props[i].Name}\n");
                }
                else
	            {
                    filelines.Append($"{props[i].Name},"); 
                }
            }

            foreach (var item in items)
            {
                filelines.Append($"{item}\n");
            }

            File.WriteAllLines(db, new[] { filelines.ToString() });
        }
    }
}
