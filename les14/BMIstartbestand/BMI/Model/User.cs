using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI.Model
{
    class User
    {
        private string name;
        private DateTime birthdate;
        private int id;
        public User()
        {

        }

        public string Name { get => name; set => name = value; }
        public DateTime Birthdate { get => birthdate; set => birthdate = value; }
        public int Id { get => id; set => id = value; }
    }
}
