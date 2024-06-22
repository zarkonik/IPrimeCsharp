using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentVehicle
{
    public abstract class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public int Value { get; set; }
        public double DailyRentalCost {  get; set; }
      
        public double InsurancePerDay {  get; set; }
       
       

        public Vehicle() { }

        public Vehicle( string brand, string model, int value, double dailyRentalCost,  double insurancePerDay)
        {
            
            this.Brand = brand;
            this.Model = model;
            this.Value = value;
            this.DailyRentalCost = dailyRentalCost;
            this.InsurancePerDay = insurancePerDay;
           
        }

        protected double EarlyReturnForRent(Customer customer) {
            double earlyRent = 0;
            double restOfDays = 0;
            if (customer.ActualRentalPeriod < customer.RentalPeriod)
            {
                earlyRent = DailyRentalCost * customer.ActualRentalPeriod;

                restOfDays = customer.RentalPeriod - customer.ActualRentalPeriod;
                earlyRent += restOfDays * DailyRentalCost / 2;
            }
            return earlyRent;
        }

        public abstract void PrintInvoice(Customer customer);
    }
}
