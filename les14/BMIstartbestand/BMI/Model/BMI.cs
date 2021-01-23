using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI.Model
{
    class BMI:User
    {
        private double weight;
        private double height;
        private DateTime date;
        private int userId;
        private double bmi;
        private User user;


        public BMI()
        {

        }

        
        public double Weight { get => weight; set => weight = value; }
        public double Height { get => height; set => height = value; }
        public DateTime Date { get => date; set => date = value; }
        public int UserId { get => userId; set => userId = value; }
        public double Bmi { get => bmi; set => bmi = value; }
        public User User { get => user; set => user = value; }
    }
}
