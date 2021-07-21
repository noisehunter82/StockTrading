using System;


namespace StockTrading
{
  class Program
  {
    static decimal LowPrice { get; set; }
    static decimal HighPrice { get; set; }
    static int IndexOfLow { get; set; }
    static int IndexOfHigh { get; set; }
    static bool Continue { get; set; }


    //---------------  Utility methods
    static void FindLowest(string[] array)
    {
      for (var i = 0; i < array.Length; i++)
      {
        var dailyPrice = Convert.ToDecimal(array[i]);

        if (dailyPrice < LowPrice)
        {
          LowPrice = dailyPrice;
          IndexOfLow = i;
        }
      }
    }

    static void FindHighest(string[] array, int index)
    {
      if ((index + 1) == array.Length)
      {
        Console.WriteLine("\nLowest dailyPrice was on the last day of the month. Subsequent highest selling dailyPrice is not available.");
      }
      else
      {

        for (int i = index + 1; i < array.Length; i++)
        {
          var dailyPrice = Convert.ToDecimal(array[i]);

          if (dailyPrice > HighPrice)
          {
            HighPrice = dailyPrice;
            IndexOfHigh = i;
          }
        }
      }
    }

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


    // --------------- Main program logic
    static void Run()
    {

      LowPrice = Decimal.MaxValue;
      HighPrice = 0;

      Console.WriteLine("\nPlease input list of prices");

      string priceList = Console.ReadLine();

      string[] splitPrices = priceList.Split(',', StringSplitOptions.TrimEntries);


      try
      {
        FindLowest(splitPrices);
        FindHighest(splitPrices, IndexOfLow);
      }
      catch (System.FormatException)
      {
        Console.WriteLine("\nIncorrect data format.");
        return;
      }


      if (HighPrice > 0)
      {
        Console.WriteLine($"\nResult: {IndexOfLow + 1}({LowPrice.ToString("0.00")}),{IndexOfHigh + 1}({HighPrice.ToString("0.00")})");
      }
      else
      {
        Console.WriteLine($"\nResult: {IndexOfLow + 1}({LowPrice.ToString("0.00")})");
      }

      return;

    }

    // ---------------


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
