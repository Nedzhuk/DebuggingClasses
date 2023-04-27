using System.Diagnostics;

namespace DebuggingClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileInfo trace = new("Log.txt");
            trace.Create().Close();
            _ = Trace.Listeners.Add(new TextWriterTraceListener(trace.OpenWrite()));
            _ = Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;

            Person object1 = new();
            object1.Square();
            object1.Max();
        }
        
    }
    class Person
    {
        public void Square()
        {
            for (int i = 1; i < 11; i++)
            {
                int sq = i * i;
                Console.WriteLine($"Квадрат числа {i} => {sq}");
                //Trace.WriteLine(sq);
                Debug.WriteLine(sq);
            }
        }
        public void Max()
        {
            int[] array = new int[5]{ 11, 23, 31, 14, 50 };
            int max = array[0];
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    //Trace.Write($"Новый максимум = {max} при i = {i}\n");
                    Debug.Print($"Новый максимум = {max} при i = {i}");
                }
            }
        }
    }
}