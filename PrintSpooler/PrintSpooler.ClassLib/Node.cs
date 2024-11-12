namespace PrintSpooler.ClassLib;

public class Node<P, T>
{
  #region FIELDS
  private static int _orderNum = 1;

  private int _thisOrderNum;
  private readonly T? _data;
  private P _priority;
  private Node<P , T>? _next;
  #endregion

  #region PROPERTIES
  public int OrderNum => _thisOrderNum;

  public P Priority { get => _priority; }
  public T? Data { get => _data; }
  public Node<P , T>? Next { get => _next; set => _next = value; }
  #endregion

  #region CONSTRUCTOR
  public Node(P priority , T data , Node<P , T>? next = null)
  {
    if (data == null)
      throw new ArgumentNullException(nameof(data) , "Data can't be null");
    else
      _data = data;

    _priority = priority;

    _thisOrderNum = _orderNum;
    _orderNum++;

    _next = next;
  }
  #endregion
}