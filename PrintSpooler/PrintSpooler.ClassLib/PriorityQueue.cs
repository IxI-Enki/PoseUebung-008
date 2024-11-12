using PrintSpooler.ClassLib;
using System.Text;
namespace PrintSpooler.ClassLib;

/// <summary>
/// Die PriorityQueue ist eine erweiterte Form der Warteschlange. Den Elementen, 
/// die in die Warteschlange gelegt werden, wird eine Prioritaet mitgegeben, 
/// welche die Reihenfolge der Abarbeitung der Elemente bestimmt.
/// </summary>
/// <typeparam name="P">Prioritaets-Type (Muss IComparable implementieren)</typeparam>
/// <typeparam name="T">Uneingeschraenkte Datentyp</typeparam> 
public class PriorityQueue<P, T>
{
  #region FIELDS
  private int _count = 0;
  private Node<P , T>? _first = null;
  #endregion

  #region PROPERTIES
  public Node<P , T>? First
  {
    get => _first ?? null;
    set => _first = value;
  }

  /// <summary>
  /// Ruft die Anzahl der Elemente ab, die in der PriorityQueue<P, T> enthalten sind.
  /// </summary>
  public int Count
  {
    get
    {
      CheckQueueForEmptyness();
      return _count = CalcCount();
    }
  }

  /// <summary>
  /// Gibt an, ob Elemente in der Queue vorhanden sind.
  /// </summary>
  public bool IsEmpty { get => Count == 0; }
  #endregion

  #region METHODS
  // PUBLIC :
  /// <summary>
  /// Entfernt alle Objekte aus der PriorityQueue<P, T>.
  /// </summary>
  public void Clear()
  {
    CheckQueueForEmptyness();
    _first = null;
  }

  /// <summary>
  /// Gibt das Objekt am Anfang von PriorityQueue<P, T> zurück, ohne es zu entfernen.
  /// </summary>
  /// <returns>Das Objekt am Anfang der PriorityQueue<P, T></returns>
  public T Peek()
  {
    Node<P , T> current = _first!;
    return current.Data!;
  }

  /// <summary>
  /// Fügt am Ende der PriorityQueue<P, T> ein Objekt hinzu.
  /// </summary>
  /// <param name="priority">Die Prioritaet mit der das Element eingefuegt wird.</param>
  /// <param name="data">Das enzufuegende Datenobjekt.</param>
  public void Push(P priority , T data)
  {
    if (data != null)
      if (_first == null)
        _first = new Node<P , T>(priority , data);
      else
      {
        Node<P , T> current = _first!;

        while (current.Next != null)
          current = current.Next!;

        current.Next = new Node<P , T>(priority , data);
      }
    else
      throw new ArgumentNullException(nameof(data) , $"{nameof(data)} - No valid Data to add");
  }

  /// <summary>
  /// Entfernt das Objekt am Anfang von PriorityQueue<P, T> und gibt es zurueck.
  /// </summary>
  /// <returns>Das Objekt, das vom Anfang der PriorityQueue<P, T> entfernt wurde.</returns>
  public T Pop()
  {
    if (CheckQueueForEmptyness())
    {
      _first = _first!.Next;
      Node<P , T> current = _first!;

      UpdateOrderNum();

      return current.Data!;
    }
    else
      throw new ArgumentException("The queue is empty");
  }

  // PRIVATE HELPERS :
  private int CalcCount()
  {
    if (_first == null)
      return 0;

    int result = 0;
    Node<P , T> current = _first;

    while (current != null)
    {
      result++;
      current = current.Next!;
    }
    return result;
  }
  private void UpdateOrderNum()
  {
    Node<P , T>? currrent = _first!;
    PriorityQueue<P , T> newQueue = new();

    while (currrent != null)
    {
      newQueue.Push(currrent.Priority! , currrent.Data!);
      currrent = currrent.Next!;
    }

    this.Clear();
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
  /// <summary>
  /// Gibt eine Zeichenfolge zurück, die das aktuelle Objekt darstellt.
  /// Zeilenweise werden die Elemente zu einem String-Objekt zusammengefuegt.
  /// [Prioritaet Objekt]
  /// [Prioritaet Objekt]
  /// </summary>
  /// <returns>Eine Zeichenfolge, die das aktuelle Objekt darstellt.</returns>
  public override string ToString()
  {
    StringBuilder sb = new();

    if (!IsEmpty)
    {
      Node<P , T> current = _first!;

      while (current != null)
      {
        sb.Append($"{current.Data!.ToString()}\n");
        current = current.Next!;
      }
    }
    return sb.ToString();
  }
  #endregion
}