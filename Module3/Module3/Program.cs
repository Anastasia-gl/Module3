namespace Module3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Services.Starter starter = new Services.Starter();
            starter.Run();
            Console.ReadLine();
        }
    }
}