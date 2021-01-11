using System;
using System.Collections.Generic;
using System.Text;

namespace Console_filter
{
    class Student
    {
        string name;
        string gender;
        int score;

        public Student(string name, string gender, int score)
        {
            this.name = name;
            this.gender = gender;
            this.score = score;
        }

        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Score { get => score; set => score = value; }
    }
}
