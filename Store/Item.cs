using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class Item
    {
        public int ID { get; private set; }
        public double Weight { get; private set; }
        public string Color { get; private set; }
        public Size Size { get; private set; }

        public override string ToString()
        {
            return $"{ID},{Weight},{Color},{Size.ToString()}";
        }

        public Item(string itemString)
        {
            var props = itemString.Split(',');

            if (this.GetType().GetProperties().Length != props.Length)
            {
                throw new Exception("فایل فرمت مورد نظر را ندارد");
            }

            var id = int.Parse(props[0]);
            var weight = double.Parse(props[1]);
            var color = props[2];
            var sizeStr = props[3].Split(';');
            var size = new Size(double.Parse(sizeStr[0]), double.Parse(sizeStr[1]), double.Parse(sizeStr[2]));

            Fill(id, weight, color, size);
        }

        private void Fill(int id, double weight, string color, Size size)
        {
            this.ID = id;
            this.Weight = weight;
            this.Color = color;
            this.Size = size;
        }
    }

    class Size
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }

        public Size(double width, double length, double height)
        {
            this.Width = width;
            this.Length = length;
            this.Height = height;
        }

        public override string ToString()
        {
            return $"{Width};{Length};{Height}";
        }
    }
}
