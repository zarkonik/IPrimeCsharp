using System.ComponentModel.DataAnnotations;

namespace RentVehicle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Rent rent1 = new Rent(new Customer("John", "Doe", 10, 10,  23, 3), new Car("Mitsubishu", "Pajero", 15000, 3, 0, 0));
            rent1.printInvoice();

            Rent rent2 = new Rent(new Customer("Mary", "Johnson", 10, 10, 20, 3), new MotorCycle("Yamaha", "R1", 10000, 0, 0));
            rent2.printInvoice();

            Rent rent3 = new Rent(new Customer("John", "Markson", 15, 10, 22, 8), new CargoVan("Citroen", "Jumper", 20000, 0, 0));
            rent3.printInvoice();

            Rent rent4 = new Rent(new Customer("Mario", "Maric", 15, 11, 23, 3), new Car("Audi", "TT", 15000, 3, 0, 0));
            rent4.printInvoice();

            Rent rent5 = new Rent(new Customer("Milos", "Mikic", 15, 10, 23, 3), new MotorCycle("Suzuki", "Cyber", 10000, 0, 0));
            rent5.printInvoice();
            

        }
    }
}