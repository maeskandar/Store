using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class Item
    {
        public int id;
        private double weight;
        private string color;
        private Size size;

        public override string ToString()
        {
            return $"{id},{weight},{color},{size.ToString()}";
        }

        public Item(string itemString)
        {
            var props = itemString.Split(',');

            if (typeof(Item).GetProperties().Length != props.Length)
            {
                throw new Exception("فایل فرمت مورد نظر را ندارد");
            }

            this.id = int.Parse(props[0]);
            this.weight = double.Parse(props[1]);
            this.color = props[2];
            var size = props[3].Split(';');
            this.size = new Size { Width = double.Parse(size[0]), Height = double.Parse(size[1]), Length = double.Parse(size[2]) };
        }
    }

    class Size
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }

        public override string ToString()
        {
            return $"{Width};{Length};{Height}";
        }
    }
}
