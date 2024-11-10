
namespace PrintSpooler.ClassLib;

public class PrintSpoolerQueue<T>
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

  #endregion

  #region OVERRIDES

  #endregion
}

public class Element<T>
{
  #region FIELDS
  private readonly int _priority;
  private readonly T? _data;
  private Element<T>? _next;
  #endregion

  #region PROPERTIES
  public int Priority { get => _priority; }
  public T? Data { get => _data; }
  public Element<T>? Next { get => _next; }
  #endregion

  #region CONSTRUCTOR
  public Element(T data , int priority , Element<T>? next = null)
  {
    if (data == null)
      throw new ArgumentNullException(nameof(data) , "Data can't be null");
    else
      _data = data;

    _priority =
      priority <= 0 ? 0 :
      priority >= 99 ? 99 :
      priority;

    _next = next;
  }
  #endregion
}