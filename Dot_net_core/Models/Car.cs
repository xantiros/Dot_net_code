using System;
using System.Collections.Generic;
using System.Text;

namespace Dot_net_core.Models
{
    public abstract class Car
    {
        public double Speed { get; protected set; } = 100;

        public double Acceleration { get; protected set; } = 5;

        public void Start()
        {
            Console.WriteLine("Turning on the engine...");
            Console.WriteLine($"Running at: {Speed.ToString()} km/h.");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping the car...");
        }

        public virtual void Accelerate()
        {
            Console.WriteLine("Accelerating...");
            Speed += Acceleration;
            Console.WriteLine($"Running at: {Speed} km/h.");
        }

        public abstract void Boost(); //abstrakcyjna klasa nie posiada ciała

    }

    public class Truck : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a truck...");
            Speed += Acceleration;
            Console.WriteLine($"Running the truck at: {Speed} km/h.");
        }

        public override void Boost()
        {
            Console.WriteLine("Boosting...");
            Speed += 50;
            Console.WriteLine($"Running at: {Speed} km/h.");
        }
    }
    public class SportCar : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a spor car...");
            base.Accelerate();
        }

        public override void Boost()
        {
            Console.WriteLine("Boosting...");
            Speed += 100;
            Console.WriteLine($"Running at: {Speed} km/h.");
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Sport Car.");
        }

    }
    public class Race
    {
        public void Begin()
        {
            //Car car = new Car(); --tak nie idzie bo car jest klasą abstrakcyjna
            SportCar sportCar = new SportCar();
            Truck truck = new Truck();
            Car sportcar2 = new SportCar();

            List<Car> cars = new List<Car>()
            {
                sportCar, truck
            };

            foreach(Car car in cars)
            {
                car.Start();
                car.Accelerate();
                car.Boost();
            }
        }

        public void Casting() //rzutowanie
        {
            Car sportCar = new SportCar();
            Car truck = new Truck();

            SportCar realSportCar = (SportCar)sportCar; //rzutowanie w dół
            SportCar castedSportCar = sportCar as SportCar;
            if(realSportCar != null) //zabezpieczenie czy zadziałało rzutowanie
            {
                realSportCar.DisplayInfo(); //rzutowanie daje dostęp do metod 
            }
            Car realCar = (Car)realSportCar; //rzutowanie w góre

        }

    }
}
