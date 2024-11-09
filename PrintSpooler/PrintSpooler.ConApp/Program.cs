using PrintSpooler.ClassLib;

namespace PrintSpooler.ConApp;

internal class Program
{
  static void Main()
  {
    Console.Write("\n Print Spooler \n");


    ClassLib.Queue<PrintDataSet> printerSpooler = new();

    ClassLib.PrintDataSet set1 = new(10);
    ClassLib.PrintDataSet set2 = new(22);
    ClassLib.PrintDataSet set3 = new(111);
    ClassLib.PrintDataSet set4 = new(-3);
    printerSpooler.Add(set1);
    printerSpooler.Add(set2);
    printerSpooler.Add(set3);
    printerSpooler.Add(set4);
    Console.WriteLine(printerSpooler);

    printerSpooler.Remove();
    printerSpooler.Remove();
    printerSpooler.Remove();


    Console.WriteLine(printerSpooler);

  }
}