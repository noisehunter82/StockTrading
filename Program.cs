using System;

namespace StockTrading
{
    class Program
    {

        static decimal lowPrice;
        static decimal highPrice;
        static int indexOfLow;
        static int indexOfHigh;
        

        static void findLowest(string[] array)
        {
               for (int i = 0; i < array.Length; i++)
               {
                  decimal price = Convert.ToDecimal(array[i]);

                  if(price < lowPrice)
                  {
                   lowPrice = price;
                   indexOfLow = i;
                  }             
                }
           }
           

        static void findHighest(string[] array, int index) 
           {
              if((index + 1) == array.Length) {

                Console.WriteLine("Lowest price was on the last day of the month. Subsequent highest selling price is not available.");

              } else {

                 for (int i = index + 1; i < array.Length; i++)
              {
                  decimal price = Convert.ToDecimal(array[i]);

                  if(price > highPrice)
                  {
                   highPrice = price;
                   indexOfHigh = i;
                  }             
               }

              }

             
           }


        static void Run()
        {

            lowPrice = Decimal.MaxValue;
            highPrice = 0;

            Console.WriteLine("Please input list of prices");
            string priceList = Console.ReadLine();

            string[] splitPrices = priceList.Split(',', StringSplitOptions.TrimEntries);

            try
            {
              findLowest(splitPrices);   
              findHighest(splitPrices, indexOfLow);  
            } 
            catch(System.FormatException)
            {
              Console.WriteLine("Incorrect data format.");
              return;
            }


            Console.WriteLine(lowPrice);

            if(highPrice > 0) Console.WriteLine(highPrice);

            return;

        }

        static string askToContinue()
        {
          Console.WriteLine("Wouldyou like to start again? (Y/N)");
          
        return (Console.ReadLine()).ToLower();;
        }


        static void Main(string[] args)
        {

          Run();

          string command = askToContinue();

          if(command == "y") {
            Run();
          }
          if(command == "n") {
          return;
          }

          askToContinue();

        
        }
    }
}
