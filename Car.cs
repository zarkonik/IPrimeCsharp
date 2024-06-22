using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentVehicle
{
    public class Car : Vehicle
    {
    
        public int SafetyRating { get; set; }


        public Car(string brand, string model, int value, int safetyRating, double dailyRentalCost,  double insurancePerDay) : base(brand, model, value, dailyRentalCost, insurancePerDay)
        {
            this.SafetyRating = safetyRating;
        }

        public void SetDailyRentalCost(Customer customer, double more, double less)
        {
            if (customer.RentalPeriod < 8 && customer.RentalPeriod > 0)
            {
                DailyRentalCost = more;
            }
            else
            {
                DailyRentalCost = less;
            }
        }

        public override void PrintInvoice(Customer customer) {
           
            Console.WriteLine("A car that is valued at " + "$" + Value.ToString("N2") + " and has safety rating of " + SafetyRating + ":");
            Console.WriteLine();
            Console.WriteLine("XXXXXXXXXXXXXX");
            Console.WriteLine("Date: " + DateTime.Now.ToString("yyyy-MM-dd"));
            Console.WriteLine("Customer name: " + customer.Name + " " + customer.Surname);
            Console.WriteLine("Rented vehicle: " + Brand + " " + Model);
            Console.WriteLine();
            DateTime endDate = DateTime.Now;
            Console.WriteLine("Reservation start date: " + endDate.AddDays(-customer.RentalPeriod).ToString("yyyy-MM-dd"));
            Console.WriteLine("Reservation end date: " + endDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Reserved rental days: " + customer.RentalPeriod + " days");
            Console.WriteLine();
            Console.WriteLine("Actual return date: " + endDate.AddDays(-customer.RentalPeriod + customer.ActualRentalPeriod).ToString("yyyy-MM-dd"));
            Console.WriteLine("Actual rental days: " + customer.ActualRentalPeriod);
            
            SetDailyRentalCost(customer, 20, 15);

            Console.WriteLine();
            Console.WriteLine("Rental cost per day: " + "$" + DailyRentalCost.ToString("F2"));

            double insurancePerDay = 0.0001 * Value;

            Console.WriteLine("Insurance per day: " + "$" + insurancePerDay.ToString("F2"));
            Console.WriteLine();
            double totalRent;
            double earlyRent = EarlyReturnForRent(customer);
            if (earlyRent > 0)
                totalRent = earlyRent;
            else
                totalRent = DailyRentalCost * customer.RentalPeriod;
            Console.WriteLine("Total rent: " + "$" + totalRent.ToString("F2"));

            if (SafetyRating == 4 || SafetyRating == 5)
            {
                insurancePerDay = insurancePerDay * 0.1;
            }
            double totalInsurance = 0;
            if (customer.ActualRentalPeriod < customer.RentalPeriod)
                totalInsurance = insurancePerDay * customer.ActualRentalPeriod;
            else
                totalInsurance = insurancePerDay * customer.RentalPeriod;


            Console.WriteLine("Total insurance: " + "$" + totalInsurance.ToString("F2"));

            double total = totalRent + totalInsurance;
            Console.WriteLine("Total: " + "$" + total.ToString("F2"));
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXX");
        }



    }
}
