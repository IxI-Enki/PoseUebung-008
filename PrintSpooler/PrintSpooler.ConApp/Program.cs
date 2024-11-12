using PrintSpooler.ClassLib;

namespace PrintSpooler.ConApp;

internal class Program
{
  static void Main()
  {
    Console.Write("\n Print Spooler \n");
    /*
    ClassLib.Queue<PrintDataSet> printerSpooler = new();

    PrintDataSet set1 = new(10);
    PrintDataSet set2 = new(22);
    PrintDataSet set3 = new(111);
    PrintDataSet set4 = new(-3);
    printerSpooler.Enqueue( set1, 10);
    printerSpooler.Enqueue( set2, 22);
    printerSpooler.Enqueue( set3, 111);
    printerSpooler.Enqueue( set4, -3);
    Console.WriteLine(printerSpooler);

    printerSpooler.Remove();
    printerSpooler.Remove();
    printerSpooler.Remove();

    Console.WriteLine(printerSpooler);
    Console.WriteLine(printerSpooler.Count);
    */

    /*
    TextPrint text = new(priority: 10 , "Hello World");
    ColoredTextPrint colorText = new(priority: 1 , "Hello colorfull World");
    Console.WriteLine(text);
    Console.WriteLine(colorText);

    SpoolerQueue<PrintJob> druckwarteschlange = new();
    druckwarteschlange.Enqueue(text);
    druckwarteschlange.Enqueue(colorText);
    */

    ClassLib.PriorityQueue<int , string> printSpooler = new();

    for (int i = 0 ; i < 25 ; i++)
    {
      int priority = RandomGenerator.Next(1 , 100);

      printSpooler.Push(priority , String.Format($"Druckauftrag #{i} mit der Priorität {priority}"));
    }

    Console.Write(
      "\nAbarbeitung der Druckaufträge: \n" +
      "------------------------------ \n");

    while (printSpooler.IsEmpty == false)
      Console.WriteLine(printSpooler.Pop());

  }

  public static Random RandomGenerator { get; private set; }
  static Program() => RandomGenerator = new Random(DateTime.Now.Millisecond);

}