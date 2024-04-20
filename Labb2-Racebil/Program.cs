namespace Labb2_Racebil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Fordon> cars = new List<Fordon>(); //Create a List to store all the cars in
            Fordon car1 = new Fordon("Ferrari");
            Fordon car2 = new Fordon("Bugatti");
            Fordon car3 = new Fordon("Pagani");

            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            Console.WriteLine("The Race is starting in!");
            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            
            Console.WriteLine("!!!GO GO GO!!!");
            Console.WriteLine("Write 'Status' to see how the cars are doing!\n");
            foreach (var car in cars) //Creats threads for every car in the list.
            {
                Thread raceThread = new Thread(() => car.Drive(cars));
                raceThread.Start();
            }
            while (true)//While loop that listens to the "status" command
            {
                string status = Console.ReadLine();
                if (status.ToLower() == "status")
                {
                    Fordon.Status(cars);
                }

            }
        }
    }
}
