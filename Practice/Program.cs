namespace Practice
{
    public class Program
    {
        public static void Main()
        {
            //var list = new LinkedList<int>();
            //Console.WriteLine($"Length : {list.Length}");
            //list.AddTail(1);
            //list.AddTail(2);
            //list.AddTail(3);
            //list.AddTail(4);
            //Console.WriteLine($"Length : {list.Length}");
            //Console.WriteLine(list.Value(0));
            //Console.WriteLine(list.Value(1));
            //Console.WriteLine(list.Value(2));
            //Console.WriteLine(list.Value(3));
            //Console.WriteLine(list.Value(4));
            //Console.WriteLine(list.ToString());

            var rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(rand.Next(3));
            }
        }
    }
}