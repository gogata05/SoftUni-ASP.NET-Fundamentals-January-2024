namespace Asynchronous_Processing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int startNumber = int.Parse(Console.ReadLine());
            //int endNumber = int.Parse(Console.ReadLine());

            //Thread evens = new Thread(() => PrintEvenNumbers(startNumber, endNumber));
            //evens.Start();
            //evens.Join();
            //Console.WriteLine("Thread finished work");

            //long result = 0;

            //var task = Task.Run(() =>
            //{

            //    for (int i = 0; i < 10000000000; i++)
            //    {
            //        if (i % 2 == 0)
            //            result += i;
            //    }
            //    return result;
            //});

            //while (true)
            //{
            //    var input = Console.ReadLine();
            //    if(input == "exit")
            //    {
            //        return;
            //    }
            //    if(input == "show")
            //    {
                    
            //        Console.WriteLine(result);
            //    }
            //}

            var chronometer = new Chronometer();

            string input = string.Empty;

            while((input = Console.ReadLine()) != "exit") 
            {
                if(input == "start")
                {
                    Task.Run(() =>
                    {
                        chronometer.Start();
                    });
                }

                else if (input == "stop")
                {
                    chronometer.Stop();
                }

                else if (input == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if (input == "laps")
                {
                    if(chronometer.Laps.Count == 0)
                    {
                        Console.WriteLine("No current laps");
                        continue;
                    }
                    Console.WriteLine("Laps:");
                    for(int i = 0; i < chronometer.Laps.Count; i++)
                    {
                        Console.WriteLine($"{i+1}. {chronometer.Laps[i]}");
                    };
                }

                else if (input == "reset")
                {
                    chronometer.Reset();
                }

                else if (input == "time")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
            }
            chronometer.Stop();
        }

        public static long SumAsync()
        {
            return Task.Run(() =>
            {
                long sum = 0;
                for (int i = 0; i < 1000000000000; i++)
                {
                    if (i % 2 == 0)
                        sum += i;
                }
                return sum;
            }).Result;
        }

        public static void PrintEvenNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if(i % 2 == 0)
                {
                    Thread thread = new Thread(() => Console.WriteLine(i));
                    thread.Start();
                    thread.Join();
                    
                }
            }
        }
    }
}