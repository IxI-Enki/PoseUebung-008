namespace PrintSpooler.ClassLib;

public sealed class TextPrint : PrintJob
{
  public TextPrint(int priority , string textToPrint) : base(priority)
  {
    _textToPrint = textToPrint;
  }
  public string TextToPrint { get => _textToPrint; }
  private string _textToPrint;
  public override string ToString()
    => $" {TextToPrint} - Text - " + base.ToString();
}