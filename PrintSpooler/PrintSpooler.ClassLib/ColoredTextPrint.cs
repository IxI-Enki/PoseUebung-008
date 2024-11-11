namespace PrintSpooler.ClassLib;

public sealed class ColoredTextPrint : PrintJob
{
  public ColoredTextPrint(int priority , string textToPrint) : base(priority)
  {
    _textToPrint = textToPrint;
  }
  public string TextToPrint { get => _textToPrint; }
  private string _textToPrint;
  public override string ToString()
    => $"\u001B[38;2;0;255;100m {TextToPrint} - Bunter\u001b[0m - " + base.ToString();
}