namespace Module3.Services
{
    internal class Starter
    {
        public Files file;

        public Starter()
        {
            file = new Files();
        }

        public void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                file.WriteTextAsync(file.SomeText).Wait();
                file.WriteTextAsync(file.SomeText).Wait();             
            }
            file.WriteList(); 
        }  
    }
}
