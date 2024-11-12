using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    /// <summary>
    /// Die PriorityQueue ist eine erweiterte Form der Warteschlange. Den Elementen, 
    /// die in die Warteschlange gelegt werden, wird eine Prioritaet mitgegeben, 
    /// welche die Reihenfolge der Abarbeitung der Elemente bestimmt.
    /// </summary>
    /// <typeparam name="P">Prioritaets-Type (Muss IComparable implementieren)</typeparam>
    /// <typeparam name="T">Uneingeschraenkte Datentyp</typeparam>
    public class PriorityQueue...???
    {

        /// <summary>
        /// Gibt an, ob Elemente in der Queue vorhanden sind.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Ruft die Anzahl der Elemente ab, die in der PriorityQueue<P, T> enthalten sind.
        /// </summary>
        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Entfernt alle Objekte aus der PriorityQueue<P, T>.
        /// </summary>
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gibt das Objekt am Anfang von PriorityQueue<P, T> zurück, ohne es zu entfernen.
        /// </summary>
        /// <returns>Das Objekt am Anfang der PriorityQueue<P, T></returns>
        public T Peek()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fügt am Ende der PriorityQueue<P, T> ein Objekt hinzu.
        /// </summary>
        /// <param name="priority">Die Prioritaet mit der das Element eingefuegt wird.</param>
        /// <param name="data">Das enzufuegende Datenobjekt.</param>
        public void Push(P priority, T data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Entfernt das Objekt am Anfang von PriorityQueue<P, T> und gibt es zurueck.
        /// </summary>
        /// <returns>Das Objekt, das vom Anfang der PriorityQueue<P, T> entfernt wurde.</returns>
        public T Pop()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gibt eine Zeichenfolge zurück, die das aktuelle Objekt darstellt.
        /// Zeilenweise werden die Elemente zu einem String-Objekt zusammengefuegt.
        /// [Prioritaet Objekt]
        /// [Prioritaet Objekt]
        /// </summary>
        /// <returns>Eine Zeichenfolge, die das aktuelle Objekt darstellt.</returns>
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
