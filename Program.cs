using System;

namespace StockTrading
{
    class Program
    {

        static decimal lowPrice;
        static decimal highPrice;
        static int indexOfLow;
        static int indexOfHigh;
        static string command = "y";
        

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


            Console.WriteLine(lowPrice.ToString("0.00"));

            if(highPrice > 0) Console.WriteLine(highPrice.ToString("0.00"));

            return;

        }

        static void askToContinue()
        {
          Console.WriteLine("Press 'Y' to continue. Press any other key to quit.");
          command = (Console.ReadLine()).ToLower();
        }


        static void Main(string[] args)
        {


          while (command == "y" ) {

            Run();
            askToContinue();

          }
                 
          return;
        
        
        }
    }
}
