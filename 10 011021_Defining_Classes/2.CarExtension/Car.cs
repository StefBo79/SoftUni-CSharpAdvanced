using System;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        private double fuelQuantity;

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        private double fuelConsumption;

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public void Drive(double distance)
        {
            double remainingFuel = FuelQuantity - (distance / 100) * FuelConsumption;
            if (remainingFuel > 0)
            {
                FuelQuantity -= remainingFuel;
            }
            else
            {
                System.Console.WriteLine("Not enough fuel to perfom this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuelQuantity: {this.FuelQuantity:F2}");
            return builder.ToString();
        }
    }
}