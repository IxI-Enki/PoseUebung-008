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
    printerSpooler.Add( set1, 10);
    printerSpooler.Add( set2, 22);
    printerSpooler.Add( set3, 111);
    printerSpooler.Add( set4, -3);
    Console.WriteLine(printerSpooler);

    printerSpooler.Remove();
    printerSpooler.Remove();
    printerSpooler.Remove();

    Console.WriteLine(printerSpooler);
    Console.WriteLine(printerSpooler.Count);
    */

    PrintSpoolerQueue<PrintJob> druckwarteschlange = new();
    druckwarteschlange.Add(new Element<PrintJob>(new PrintJob() , 10));
  }
}