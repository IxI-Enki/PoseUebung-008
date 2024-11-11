namespace PrintSpooler.ClassLib;

public class SpoolerQueue<T>
{
  #region FIELDS
  private int _count = 0;
  private Element<T>? _first = null;
  #endregion

  #region PROPERTIES
  public Element<T>? First
  {
    get => _first ?? null;
    set => _first = value;
  }
  public int Count
  {
    get
    {
      CheckQueueForEmptyness();

      return _count = CalcCount(); 
    }
  }
  public Element<T> this[ int orderNum ]
  {
    get
    {
      CheckQueueForEmptyness();

      if (orderNum < 0 || orderNum > Count)
        throw new InvalidOperationException($"Invalid orderNum: {orderNum} chosen");

      int count = 0;
      Element<T> current = _first!;

      while (orderNum < Count && orderNum != count)
      {
        current = current.Next!;
        count++;
      }
      return current;
    }
  }
  public int this[ Element<T> printElement ]
  {
    get
    {
      CheckQueueForEmptyness();

      if (printElement == null)
        throw new ArgumentNullException($"Invalid Element: {printElement} chosen");

      int count = 0;
      Element<T> current = _first!;

      while (current != printElement && current != null)
      {
        current = current.Next!;
        count++;
      }
      return count;
    }
  }
  #endregion

  #region METHODS
  // PUBLIC :
  public bool Enqueue(T printJob)
  {
    if (printJob != null && printJob is PrintJob)
      if (_first == null)
      {
        _first = new Element<T>(printJob);
        return true;
      }
      else
      {
        Element<T> current = _first!;

        while (current.Next != null)
          current = current.Next!;

        current.Next = new Element<T>(printJob);

        return true;
      }
    else
      throw new ArgumentNullException(nameof(printJob) ,$"{nameof(printJob)} - No valid PrintJob to add");
  }
  public bool Clear()
  {
    CheckQueueForEmptyness();

    _first = null;
    return true;
  }
  public bool RemoveFirst()
  {
    if (_first == null)
      return false;

    _first = _first.Next;
    UpdateOrderNum();
    return true;
  }
  public Element<T>? Dequeue()
  {
    if (_first == null)
      return null;

    _first = _first!.Next;
    Element<T> current = _first!;

    UpdateOrderNum();

    return current;
  }
  public bool Remove(T printJob)
  {
    if (printJob == null)
      throw new ArgumentNullException(nameof(printJob) , "Can not remove null");
    if (_first == null)
      throw new ArgumentNullException("Printer Queue is empty");

    Element<T>? current = _first!;
    while (current != null)
    {
      if (current != new Element<T>(printJob))
        current = current.Next!;
      else if (current == new Element<T>(printJob))
      {
        current = current.Next!.Next;
        UpdateOrderNum();
        return true;
      }
    }
    return false;
  }
  public Element<T>? GetElement(T printJob)
  {
    if (printJob == null)
      throw new ArgumentNullException(nameof(printJob) , "Can not remove null");
    CheckQueueForEmptyness();

    Element<T>? current = _first!;

    while (current != null)
    {
      if (current == new Element<T>(printJob))
        return new Element<T>(printJob);
    
      current = current.Next!;
    }
    return null;
  }

  // PRIVATE HELPERS :
  private int CalcCount()
  {
    if (_first == null)
      return 0;

    int result = 0;
    Element<T> current = _first;

    while (current != null)
    {
      result++;
      current = current.Next!;
    }
    return result;
  }
  private void UpdateOrderNum()
  {
    Element<T>? currrent = _first!;
    SpoolerQueue<T> newQueue = new();

    while (currrent != null)
    {
      newQueue.Enqueue(currrent.Data!);
      currrent = currrent.Next!;
    }

    this.ClearQueue();
    this.First = newQueue.First;
  }
  private bool CheckQueueForEmptyness()
  {
    if (_first == null)
      throw new ArgumentException("The queue is empty");
    else
      return true;
  }
  #endregion

  #region OVERRIDES
  public override string? ToString()
      => base.ToString();
  #endregion
}

public class Element<T>
{
  #region FIELDS
  private static int _orderNum = 1;

  private int _thisOrderNum;
  private readonly T? _data;
  private Element<T>? _next;
  #endregion

  #region PROPERTIES
  public int OrderNum => _thisOrderNum;

  public T? Data { get => _data; }
  public Element<T>? Next { get => _next; set => _next = value; }
  #endregion

  #region CONSTRUCTOR
  public Element(T data , Element<T>? next = null)
  {
    if (data == null)
      throw new ArgumentNullException(nameof(data) , "Data can't be null");
    else
      _data = data;

    _thisOrderNum = _orderNum;
    _orderNum++;

    _next = next;
  }
  #endregion
}