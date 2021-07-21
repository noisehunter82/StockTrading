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


    static void DisplayResults(LowDailyPrice low, HighDailyPrice high)
    {
      if (high.HighPrice > 0)
      {
        Console.WriteLine($"\nResult: {low.IndexOfLow + 1}({low.LowPrice.ToString("0.00")}),{high.IndexOfHigh + 1}({high.HighPrice.ToString("0.00")})");
      }
      else
      {
        Console.WriteLine($"\nLowest daily price was on the last day of the month. Subsequent highest selling daily price is not available.\n\nResult: {low.IndexOfLow + 1}({low.LowPrice.ToString("0.00")})");
      }
    }


    static void Run()
    {
      // Ask user for data
      Console.WriteLine("\nPlease input list of prices");
      string priceList = Console.ReadLine();

      // Split and convert to decimal array and handle FormatExceptions.
      decimal[] numericPrices;
      try
      {
        numericPrices = ConvertToDecimal(priceList);
      }
      catch (System.FormatException)
      {
        Console.WriteLine("\nIncorrect data format.");
        return;
      }

      // Implement new instances and call methods for daily low and high prices.
      LowDailyPrice Low = new LowDailyPrice();
      Low.FindLowest(numericPrices);

      HighDailyPrice High = new HighDailyPrice();
      High.FindHighest(numericPrices, Low.IndexOfLow);

      // Display results
      DisplayResults(Low, High);

      return;

    }



    static void Main(string[] args)
    {
      Continue = true;
      while (Continue)
      {
        Run();
        AskToContinue();
      }

      return;
    }
  }
}
