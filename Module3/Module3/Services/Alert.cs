using Module3.Info;

namespace Module3.Services
{
    internal class Alert
    {
        public MyList myList;
        public Files files;
        public Action<IList<string>, int> OnListChanged;

        public Alert()
        {
            myList = new MyList();
            files = new Files();

        }

        public void Massage(IList<string> list, int num)
        {
            if (list.Count % num == 0)
            {
                var massage = "Backup";
                Console.WriteLine(massage);
            }
        }
    }
}

