namespace SharedTools
{
    public class FileReader
    {
        public string Text { get; private set; }

        public FileReader(string path)
        {
            Text = File.ReadAllText(path);
        }
    }
}
