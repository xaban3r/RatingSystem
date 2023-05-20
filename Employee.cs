using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingSystem
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhotoPath { get; set; }
        public int Rating { get; set; }

        public Employee(string id,string name, string photoPath, int rating)
        {
            Id = id;
            Name = name;
            PhotoPath = photoPath;
            Rating = rating;
        }
    }
}
