using System;

namespace ConsoleApp1
{
    class Program
    {

        static bool PrimeNumberCheck(int number)
        {
            bool status = true;

            for (int i = 2; i < number; i++) //i=2 başlamasının nedeni en küçük 2 asaldır.
            {
                if (number % i == 0) //kalanlarda sıfır varsa asal değildir.
                {
                    status = false;
                    break;
                }
            }

            return status;
        }

        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            long totalPrimeNumber = 1;

            for (int i = number; i >= 2; i--) 
            {
                if (PrimeNumberCheck(i))
                {
                    totalPrimeNumber *= i;
                }
            }
            Console.WriteLine("Total Prime Number:" + totalPrimeNumber);
            Console.ReadKey();            
        }
    }
}
