using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentVehicle
{
    public class MotorCycle : Vehicle
    {
        public MotorCycle(string brand, string model, int value,  double dailyRentalCost, double insurancePerDay) : base(brand, model, value, dailyRentalCost, insurancePerDay)
        {
            
        }
        public MotorCycle() { }

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

        public override void PrintInvoice(Customer customer)
        {
            
            Console.WriteLine();
            Console.WriteLine("A motorcycle valued at " + "$" + Value.ToString("N2") + ", and the driver is " + customer.Age.ToString() + " years old.");
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

            SetDailyRentalCost(customer, 15, 10);

            Console.WriteLine();
            Console.WriteLine("Rental cost per day: " + "$" + DailyRentalCost.ToString("N2"));

            double initialInsurance = 0.0002 * Value;

            Console.WriteLine("Initial insurance per day: " + "$" + initialInsurance.ToString("N2"));
            double insuranceAdditionPerDay = 0;
            if (customer.Age < 25)
            {
                insuranceAdditionPerDay = initialInsurance * 0.2;
                Console.WriteLine("Insurance addition per day: " + "$" + insuranceAdditionPerDay.ToString("N2"));
            }
            double insurancePerDay = initialInsurance + insuranceAdditionPerDay;
            Console.WriteLine("Insurance per day: " + "$" + insurancePerDay.ToString("N2"));
            Console.WriteLine();

            double totalRent;
            double earlyRent = EarlyReturnForRent(customer);
            if (earlyRent > 0)
                totalRent = earlyRent;
            else
                totalRent = DailyRentalCost * customer.RentalPeriod;
            Console.WriteLine("Total rent: " + "$" + totalRent.ToString("N2"));

            double totalInsurance = 0;
            if (customer.ActualRentalPeriod < customer.RentalPeriod)
                totalInsurance = insurancePerDay * customer.ActualRentalPeriod;
            else
                totalInsurance = insurancePerDay * customer.RentalPeriod;
            Console.WriteLine("Total insurance: " + "$" + totalInsurance.ToString("N2"));

            double total = totalRent + totalInsurance;
            Console.WriteLine("Total: " + "$" + total.ToString("N2"));
            Console.WriteLine("XXXXXXXXXXXXXXXXXX");
            Console.WriteLine();
        }
    }
}
