using System.Text;

namespace PrintSpooler.ClassLib;

public class PrintDataSet
{
  #region FIELDS
  private static int _orderNum = 1;
  private int _thisOrderNum;
  private int _priority = 0;
  #endregion

  #region PROPERTIES
  public int OrderNum => _thisOrderNum;
  public int Priority
  {
    get => _priority;
    private set
    {
      _priority =
        value < 0 ? 0 :
        value > 99 ? 99 :
        value;
    }
  }
  #endregion

  #region CONSTRUCTOR
  public PrintDataSet(int priority)
  {
    Priority = priority;
    _thisOrderNum = _orderNum;
    _orderNum++;
  }
  #endregion 

  #region OVERRIDES
  public override string ToString()
    => new StringBuilder().Append(
        $"Druckauftrag #{OrderNum,3}" +
        $" mit der Priorität {Priority,3}"
        ).ToString();
  #endregion
}