using System.Text;

namespace PrintSpooler.ClassLib;

public class Queue<T>
{
  #region FIELDS
  private Element<T>? _first = null;
  #endregion

  #region PROPERTIES
  public Element<T>? First
  {
    get => _first;
    set => _first = value;
  }
  #endregion

  #region CONSTRUCTOR

  #endregion

  #region METHODS
  public bool Add(T dataToAdd)
  {
    if (_first == null)
      _first = new Element<T>(dataToAdd);
    else
    {
      Element<T> current = _first;

      while (current.Next != null)
        current = current.Next!;

      current.Next = new Element<T>(dataToAdd);
    }
    return true;
  }

  #region PRIVATE HELPER METHODS


  public bool Remove()
  {
    if (_first != null)
    {
      _first = _first.Next;
      return true;
    }
    return false;
  }

  public bool Remove(Element<T> elementToRemove)
  {

    return false;
  }


  #endregion
  #endregion

  #region OVERRIDES
  public override string ToString()
  {
    StringBuilder sb = new();

    if (_first != null)
    {
      Element<T> current = _first;

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