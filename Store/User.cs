using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class User
    {
        public string ID { get; private set; }
        private string Password { get; set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Address { get; private set; }
        public bool IsManager { get; private set; }

        private void Fill(string id, string password, string firstname, string lastname, string address, bool isManager)
        {
            
            this.ID = id;
            this.Password = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Address = address;
            this.IsManager = isManager;
        }

        public User(string itemString)
        {
            var props = itemString.Split(',');

            if (this.GetType().GetProperties().Length != props.Length)
            {
                throw new Exception("فایل فرمت مورد نظر را ندارد");
            }

            var id = props[0];
            var pass = props[1];
            var first = props[2];
            var last = props[3];
            var address = props[4];
            var isManager = bool.Parse(props[5]);

            Fill(id, pass, first, last, address, isManager);
        }

        public override string ToString()
        {
            return $"{ID},{Password},{Firstname},{Lastname},{Address.Replace(',',';')},{IsManager}";
        }
    }
}
