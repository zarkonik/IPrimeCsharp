using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentVehicle
{
    public class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int RentalPeriod { get; set; }
        public int ActualRentalPeriod {  set; get; }
        
        public int Age { get; set; }
        public int yearsOfExperience { get; set; }  

        public Customer(string name, string surname, int rentalPeriod, int actualRentalPeriod, int age, int experience) { 
            this.Name = name;
            this.Surname = surname;
            this.RentalPeriod = rentalPeriod;
            this.ActualRentalPeriod = actualRentalPeriod;
            this.Age = age;
            this.yearsOfExperience = experience;
        }
    }
}
