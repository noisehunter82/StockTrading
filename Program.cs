using System;

namespace StockTrading
{
  public class Program
  {
    public static bool Continue { get; set; }


    //--------- Utilities

    public static decimal[] ConvertToDecimal(string Str)
    {
      string[] SplitPrices = Str.Split(',', StringSplitOptions.TrimEntries);
      return Array.ConvertAll<string, decimal>(SplitPrices, Convert.ToDecimal);
    }


    public static string FormatResults(int LowIndex, decimal LowPrice, int HighIndex, decimal HighPrice)
    {

      var lowDay = (LowIndex + 1).ToString();
      var lowPrice = LowPrice.ToString("0.00");
      var highDay = HighIndex == 0m ? "N/A" : (HighIndex + 1).ToString();
      var highPrice = HighPrice.ToString("0.00");

      return $"\n{lowDay}({lowPrice}),{highDay}({highPrice})";

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

      return FormatResults(Low.IndexOfLow, Low.LowPrice, High.IndexOfHigh,High.HighPrice);
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
