using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentVehicle
{
    public class CargoVan : Vehicle
    {

        public CargoVan(string brand, string model, int value, double dailyRentalCost, double insurancePerDay) : base(brand, model, value, dailyRentalCost, insurancePerDay)
        {
            
        }

        public CargoVan() { }


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

        public double EarlyReturnForInsurance( Customer customer)
        {
            double insurancePerDay = 0;
            double totalInsurance = 0;
            if (customer.ActualRentalPeriod < customer.RentalPeriod)
            {
                double initialInsurance = 0.0003 * Value;
                Console.WriteLine("Initial insurance per day: " + "$" + initialInsurance.ToString("N2"));
                double insuranceDiscountPerDay = 0;
                if (customer.yearsOfExperience > 5)
                {
                    insuranceDiscountPerDay = initialInsurance * 0.15;
                    Console.WriteLine("Insurance discount per day: " + "$" + insuranceDiscountPerDay.ToString("N2"));
                }
                insurancePerDay = initialInsurance - insuranceDiscountPerDay;
                Console.WriteLine("Insurance per day: " + "$" + insurancePerDay.ToString("N2"));
                Console.WriteLine();
                totalInsurance = insurancePerDay * customer.RentalPeriod;
                if (customer.ActualRentalPeriod < customer.RentalPeriod)
                {
                    totalInsurance = customer.ActualRentalPeriod * insurancePerDay;
                }

            }
            return totalInsurance;
        }

        public override void PrintInvoice(Customer customer)
        {
            
            Console.WriteLine("A cargo van valued at " + "$" + Value.ToString("N2") + ", and the driver has " + customer.yearsOfExperience.ToString() + " years of driving experience.");
            Console.WriteLine();
            Console.WriteLine("XXXXXXXXXXXX");

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

            SetDailyRentalCost(customer, 50, 40);

            Console.WriteLine();
            Console.WriteLine("Rental cost per day: " + "$" + DailyRentalCost.ToString("N2"));

            double totalInsurance = EarlyReturnForInsurance(customer);

            double rentWithoutDiscount = customer.RentalPeriod * DailyRentalCost;
            double totalRent = EarlyReturnForRent(customer);
            Console.WriteLine();

            if (totalRent > 0)
            {
                double earlyDiscount = rentWithoutDiscount - totalRent;
                Console.WriteLine("Early return discount for rent: " + "$" + earlyDiscount.ToString("N2"));
                Console.WriteLine();
            }
            Console.WriteLine("Total rent: " + "$" + totalRent.ToString("N2"));

            Console.WriteLine("Total insurance: " + "$" + totalInsurance.ToString("N2"));

            double total = totalRent + totalInsurance;
            Console.WriteLine("Total: " + "$" + total.ToString("N2"));
            Console.WriteLine("XXXXXXXXXXXXXXXXXX");
            Console.WriteLine();
        }
    }
}
