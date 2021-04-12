using System;

namespace lab_7_delegates_second__train_
{
    public delegate void TrainDelegate();

    class Train
    {
        public string ArrivalTime { get; set; }
        public string Name { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }

        public Train(string Name, string Destination, string Departure, string ArrivalTime)
        {
            this.Name = Name;
            this.Destination = Destination;
            this.Departure = Departure;
            this.ArrivalTime = ArrivalTime;
        }

        public void GetTrainName() => Console.Write($"Поезд с названием {Name} ");

        public void GetTrainDestination() => Console.Write($"прибывает на станцию \"{Destination}\" ");

        public void GetTrainDeparture() => Console.Write($"из станции \"{Departure}\" ");

        public void GetTrainArrivalTime() => Console.WriteLine($"в \"{ArrivalTime}\"");
    }

    class EventGenerator
    {
        public event TrainDelegate TrainEventGenerator = null;

        public void Generate(Train train)
        {
            TrainEventGenerator += train.GetTrainDeparture;
            TrainEventGenerator += train.GetTrainArrivalTime;
            TrainEventGenerator += train.GetTrainName;
            TrainEventGenerator += train.GetTrainDestination;
            TrainEventGenerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Train A = new Train("Chugunka", "Brest", "Gomel", "11:31");
            EventGenerator Event = new EventGenerator();
            Event.Generate(A);
            Train B = new Train("Vsevolod", "Orsha", "Minsk", "23:54");
            EventGenerator Event2 = new EventGenerator();
            Event2.Generate(B);
        }
    }
}
