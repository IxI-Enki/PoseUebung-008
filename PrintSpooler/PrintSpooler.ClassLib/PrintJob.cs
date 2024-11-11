namespace PrintSpooler.ClassLib;

public abstract class PrintJob
{
  #region CONSTRUCTOR
  public PrintJob(int priority)
  {
    _priority =
      priority <= 0 ? 0 :
      priority >= 99 ? 99 :
      priority;
  }
  #endregion

  #region FIELDS
  private int _priority;
  #endregion

  #region PROPERTIES
  public int Priority { get => _priority; }
  #endregion

  #region OVERRIDES
  public override string ToString()
    => $"Druckauftrag mit Priorität: {Priority}";
  #endregion
}