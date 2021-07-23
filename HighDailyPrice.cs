

namespace StockTrading
{

  public class HighDailyPrice
  {
    public decimal HighPrice { get; set; }
    public int IndexOfHigh { get; set; }

    public void FindHighest(decimal[] array, int index)
    {
      if ((index + 1) != array.Length)
      {
        for (var i = index + 1; i < array.Length; i++)
        {
          if (array[i] > HighPrice)
          {
            HighPrice = array[i];
            IndexOfHigh = i;
          }
        }
      }
      else
      {
        return;
      }
    }

    //Constructor
    public HighDailyPrice()
    {
      HighPrice = 0m;
      IndexOfHigh = 0;
    }

  }
}