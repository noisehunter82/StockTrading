using System;

namespace StockTrading
{
  public class Program
  {
    public static bool Continue { get; set; }


    //--------- Utilities

    public static decimal[] ConvertToDecimal(string str)
    {
      string[] splitPrices = str.Split(',', StringSplitOptions.TrimEntries);
      return Array.ConvertAll<string, decimal>(splitPrices, Convert.ToDecimal);
    }


    public static string FormatResults(LowDailyPrice low, HighDailyPrice high)
    {

      var lowDay = low.IndexOfLow + 1;
      var lowPrice = low.LowPrice.ToString("0.00");
      var highDay = high.IndexOfHigh == null ? "N/A" : (high.IndexOfHigh + 1).ToString();
      var highPrice = high.HighPrice.ToString("0.00");

      return $"{lowDay}({lowPrice}),{highDay}({highPrice})";

    }


    // --------- Operations

    public static string GetPrices(string str)
    {
      // Split string.
      decimal[] numericPrices;

      // Convert to decimal array and handle FormatExceptions.
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

      return FormatResults(Low, High);
    }


    public static void ToggleContinue(ConsoleKey key)
    {
      if (key == ConsoleKey.Escape)
      {
        Continue = false;
      }
      else
      {
        Continue = true;
      }
    }


    static void Main(string[] args)
    {
      Continue = true;

      while (Continue)
      {
        // Get user input
        Console.WriteLine("\nPlease input list of prices");
        var priceList = Console.ReadLine();

        // Run core logic
        var result = GetPrices(priceList);

        // Display results
        Console.WriteLine(result);

        // Quit or contuinue
        Console.WriteLine("\nPress any key to continue. Press 'ESC' to quit.");
        var key = Console.ReadKey().Key;
        ToggleContinue(key);
      }

      return;
    }
  }
}
