

namespace StockTrading
{

  public class LowDailyPrice
  {
    public decimal LowPrice { get; set; }
    public int IndexOfLow { get; set; }

    public void FindLowest(decimal[] array)
    {
      for (var i = 0; i < array.Length; i++)
      {

         if (array[i] < LowPrice)
        {
          LowPrice = array[i];
          IndexOfLow = i;
        }
      }
    }
    //Constructor
    public LowDailyPrice()
    {
      LowPrice = decimal.MaxValue;
    }

  }





}