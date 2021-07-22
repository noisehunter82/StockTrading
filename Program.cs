using System;

namespace StockTrading
{
  class Program
  {
    static bool Continue { get; set; }


    //---------------  Utility methods

    static void AskToContinue()
    {
      Console.WriteLine("\nPress any key to continue. Press 'ESC' to quit.");

      if (Console.ReadKey().Key == ConsoleKey.Escape)
      {
        Continue = false;
      }
      else
      {
        Continue = true;
      }
    }


    static decimal[] ConvertToDecimal(string str)
    {
      string[] splitPrices = str.Split(',', StringSplitOptions.TrimEntries);
      return Array.ConvertAll<string, decimal>(splitPrices, Convert.ToDecimal);
    }


    static string DisplayResults(LowDailyPrice low, HighDailyPrice high)
    {

      var lowDay = low.IndexOfLow + 1;
      var lowPrice = low.LowPrice.ToString("0.00");
      var highDay = high.IndexOfHigh == null ? "N/A" : (high.IndexOfHigh + 1).ToString();
      var highPrice = high.HighPrice.ToString("0.00");

      return $"{lowDay}({lowPrice}),{highDay}({highPrice})";

    }


    static string Run(string str)
    {
      // Split and convert to decimal array and handle FormatExceptions.
      decimal[] numericPrices;
      
      try
      {
        numericPrices = ConvertToDecimal(str);
      }
      catch (System.FormatException)
      {
        return "\nIncorrect data format.";
      }

      // Implement new instances and call methods for daily low and high prices.
      LowDailyPrice Low = new LowDailyPrice();
      Low.FindLowest(numericPrices);

      HighDailyPrice High = new HighDailyPrice();
      High.FindHighest(numericPrices, Low.IndexOfLow);


      return $"\nResults: { DisplayResults(Low, High)}";
    }



    static void Main(string[] args)
    {
      Continue = true;
      while (Continue)
      {
        Console.WriteLine("\nPlease input list of prices");
        string priceList = Console.ReadLine();

        var output = Run(priceList);
        Console.WriteLine(output);
        
        AskToContinue();
      }

      return;
    }
  }
}
