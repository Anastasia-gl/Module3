using Newtonsoft.Json;
using Module3.Info;
using Module3.Interfaces.Services;

namespace Module3.Services
{
    internal class Files : IFiles
    {
        public string SomeText { get; init; } = "SomeText";
        public int Number { get; set; }

        public MyList myList;
       
        public Files()
        {
            myList = new MyList();
        }

        private const string _mainFile = "main.txt";
        private const string _dirPath = @"C:\Users\Anastasia\Desktop\\Module3\Module3\bin\Debug\net6.0\Backup";

        public async Task<string> WriteTextAsync(string text)
        {
            var directory = File.ReadAllText("config.json");
            Number = Convert.ToInt32(JsonConvert.DeserializeObject(directory));

            await Task.Run(() =>
            {
                for (int i = 0; i < Number; i++)
                {

                    using (var sw = new StreamWriter(_mainFile, true))
                    {

                        sw.WriteLine(text);
                    }
                    myList.infoList.Add(text);

                }
                Backup(myList.infoList);
            });

            return text;
        }

        public void WriteList()
        {
            using (var sr = new StreamReader(_mainFile))
            {
                for (int i = 0; i < File.ReadAllLines(_mainFile).Length; i++)
                {                
                    var line = sr.ReadLine();
                    myList.infoList.Add(line);
                }
            };
        }

        public void Backup(IList<string> log)
        {
            Alert alert = new Alert();
            alert.OnListChanged = alert.Massage;

            if (log.Count % Number == 0)
            {
                alert.OnListChanged(log, Number);
                string path = DateTime.Now.ToString("hh_mm_FF dd-MM-yyyy") + ".txt";

                string pathString = Path.Combine(_dirPath, path);
                foreach (var item in log)
                {
                    using (var sw = new StreamWriter(pathString, true))
                    {
                        sw.WriteLine(item);
                    }
                }
            }
        }
    }
}