using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


namespace RentVehicle
{
    public class Rent
    {
        public Customer Customer {  get; set; }
        public Vehicle Vehicle { get; set; } 

        public Rent(Customer customer, Vehicle vehicle) {
            this.Customer = customer;
            this.Vehicle = vehicle;
        }

        public double EarlyReturnForRent()
        {
            double earlyRent = 0;
            double restOfDays = 0;
            if(Customer.ActualRentalPeriod < Customer.RentalPeriod)
            {
                earlyRent = Vehicle.DailyRentalCost * Customer.ActualRentalPeriod;

                restOfDays = Customer.RentalPeriod - Customer.ActualRentalPeriod;
                earlyRent += restOfDays * Vehicle.DailyRentalCost / 2;
            }
            return earlyRent;
        }

        public double EarlyReturnForInsurance()
        {
            double insurancePerDay = 0;
            double totalInsurance = 0;
            if (Customer.ActualRentalPeriod < Customer.RentalPeriod)
            {
                double initialInsurance = 0.0003 * Vehicle.Value;
                Console.WriteLine("Initial insurance per day: " + "$" + initialInsurance.ToString("N2"));
                double insuranceDiscountPerDay = 0;
                if (Customer.yearsOfExperience > 5)
                {
                    insuranceDiscountPerDay = initialInsurance * 0.15;
                    Console.WriteLine("Insurance discount per day: " + "$" + insuranceDiscountPerDay.ToString("N2"));
                }
                insurancePerDay = initialInsurance - insuranceDiscountPerDay;
                Console.WriteLine("Insurance per day: " + "$" + insurancePerDay.ToString("N2"));
                Console.WriteLine();
                totalInsurance = insurancePerDay * Customer.RentalPeriod;
                if (Customer.ActualRentalPeriod < Customer.RentalPeriod)
                {
                   totalInsurance = Customer.ActualRentalPeriod * insurancePerDay;
                }
                
            }
            return totalInsurance;
        }

        public void printInvoice()
        {
            Vehicle.PrintInvoice(Customer);    
        }


        }


    }

