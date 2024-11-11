using System.Text;
namespace PrintSpooler.ClassLib;
public class Queue<T>
{
  #region FIELDS
  private Element<PrintDataSet>? _first = null;
  private int _count = 0;
  #endregion

  #region PROPERTIES
  public int Count
  {
    get
    {
      int count = 0;

      if (_first == null)
        return count;
      if (_first != null)
      {
        Element<PrintDataSet> current = _first;

        while (current != null)
        {
          current = current.Next!;
          count++;
        }
        _count = count;
      }
      return _count;
    }
  }
  public Element<PrintDataSet>? First
  {
    get => _first;
    set => _first = value;
  }
  #endregion
 
  #region METHODS     // SPEZIELLE SYNTAX FÜR GENERISCHE PROGRAMMIERUNG BEISPIELHAFT
  public bool Add<T>(T dataToAdd , int priority) where T : PrintDataSet
  {
    if (_first == null && dataToAdd is PrintDataSet)
      _first = new Element<PrintDataSet>(new PrintDataSet(priority));
    else
    {
      Element<PrintDataSet> current = _first!;

      while (current.Next != null)
        current = current.Next!;


      current.Next = new Element<PrintDataSet>(new PrintDataSet(priority));
    }
    return true;
  }
  public bool Remove()
  {
    if (_first != null)
    {
      _first = _first.Next;
      return true;
    }
    return false;
  }
  #endregion

  #region OVERRIDES
  public override string ToString()
  {
    StringBuilder sb = new();

    if (_first != null)
    {
      Element<PrintDataSet> current = _first;

      while (current != null)
      {
        sb.Append($"{current!.PrintData!.ToString()}\n");
        current = current.Next!;
      }
    }
    if (_first == null)
      sb.Append("empty Queue");

    return sb.ToString();
  }
  #endregion

  #region EMBEDED CLASS
  public class Element<T>(T? printData , Element<T>? next = null)
  {
    #region FIELDS
    private Element<T>? _next = next;
    private T? _printData = printData;
    #endregion

    #region PROPERTIES
    public Element<T>? Next { get => _next; set => _next = value; }
    public T? PrintData
    {
      get => _printData;
      set => _printData = value;
    }
    #endregion
  }
  #endregion
}