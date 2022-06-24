namespace Module3.Interfaces.Services
{
     interface IFiles
    {
        public async Task<string> WriteTextAsync(string text) { await Task.Run(() => { }); return text; }

        public void WriteList();

        public void Backup(IList<string> a);
    }
}
