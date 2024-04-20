using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Racebil
{
    internal class Fordon
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }
        public bool Finished { get; set; }

        private Stopwatch stopwatch;

        public Fordon(string name)
        {
            Name = name;
            Speed = 120;
            Distance = 0;
            Finished = false;
            stopwatch = new Stopwatch();
        }

         
                  
        public void Drive(List<Fordon> cars) //Main function for starting the race
        {
            stopwatch.Start(); //Stopwatch to keep track of the total time each car takes to finish
            int situationvar = 0;
            while (Distance < 10000 && !Finished)//This makes the car "drive" aslong as it hasn't driven 10000m or has Finished.
            {
                Distance += Speed *1000 /3600; //Calculates the speed per meter
                Thread.Sleep(1000);
                situationvar++;
                if(situationvar%30 == 0)//The modulus will go in the loop for 30,60,90,120 etc and i have 1 sec sleep.
                {                    
                    Problem();
                }                          
            }
            stopwatch.Stop();
            TimeSpan raceTime = stopwatch.Elapsed;
            Finished = true;//Change the Bool to True so the car doesnt continue the loop
            Console.WriteLine($"{Name} has finished the race with the time: {raceTime.TotalSeconds:F2} seconds!!!!");
            
        }
        
        public void Problem()
        {
            while (!Finished)
            {

                Random random = new Random();
                var incidentRoll = random.Next(1,51);//Generate a number between 1 and 50.
                //The odds are fixed by <= so if i generate a 15 and nothing is equal to it the if condition will look for a any other condition
                Console.WriteLine($"\n{Name} rolled a {incidentRoll}");
                if (incidentRoll == 1)  //Refuel
                {
                    Console.WriteLine($"Oh NO!!! {Name} needs to refuel! Stop for 30 seconds\n");
                    Thread.Sleep(30000);
                }
                else if (incidentRoll <= 3) //Puncture 
                {
                    Console.WriteLine($"Oh NO!!! {Name} needs to change Tires! Stop for 20 seconds\n");
                    Thread.Sleep(20000);
                }
                else if (incidentRoll <= 8) //Windshield Clean
                {
                    Console.WriteLine($"Oh NO!!! {Name} needs a clean Windshield! Stops for 10 seconds\n");
                    Thread.Sleep(10000);
                }
                else if (incidentRoll <= 18)  //Speed Control
                {
                    Console.WriteLine($"Oh NO!!! {Name} speed is lowerd by 1km/h\n");
                    Speed--;
                    break;
                }
                else
                {
                    Console.WriteLine("WOW!!!! You didn't face any problems this time!\n");
                    break;
                }
            }
        }
        public static void Status(List<Fordon> cars)
        {            
                
                    Console.WriteLine("The current race status is: ");
                    foreach (Fordon car in cars)//The forloop prints the status for every car in the List
                    {
                        Console.WriteLine($"{car.Name}: has driven {car.Distance} Meters and has a speed of {car.Speed}");
                    }
        }
    }

    
}
