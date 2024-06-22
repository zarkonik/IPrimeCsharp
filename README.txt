I have an abstract class named Vehicle, which has several attributes, with the important ones being DailyRentalCost, representing the cost of renting the vehicle per day, and InsurancePerDay, representing the cost of insurance per day.

Three classes inherit Vehicle class: Car, MotorCycle, and CargoVan. In addition to the inherited attributes, the Car class also contains a SafetyRating property.

The Customer class represents a client who rented a vehicle. It has properties RentalPeriod and ActualRentalPeriod, representing the number of days initially wanted and the number of days when the vehicle was returned before the expected date.

For each vehicle, the daily rental price is given based on whether the vehicle is rented for a week or less or for more than a week.

In class Vehicle, there is abstract method PrintInvoice(Customer customer). Every inherited class override that 
method and prints the information for each individual class that inherits Vehicle class.

In case when customer returns vehicle before expected rental period, I have functions that calculates total cost
for renting and for insurance. Rental cost is calculated full price for the elapsed days and half price for remaining days. Insurance cost is only calculated for elapsed days. 

The Rent class is a class where we call printInvoice method for a Vehicle reference. There I have reference to Customer that came in the renting company and reference to Vehicle that customer rented. In printInvoice method I simply print on the console all the details of the subclasses because printInvoice is abstract method in Vehicle class and all subclasses override that method and print their own data.

In Program.cs I make rent objects that can print individual invoice for client that has come and vehicle that he rented.
 
Project is done in Visual Studio 2022.