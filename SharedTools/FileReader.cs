namespace SharedTools
{
    public class FileReader
    {
        public string Text { get; private set; }
        public IEnumerable<string> TextLines { get; private set; }

        public FileReader(string path, ReadOption readOption)
        {
            switch (readOption)
            {
                case ReadOption.All:
                    Text = File.ReadAllText(path);
                    break;
                case ReadOption.Lines:
                    TextLines = File.ReadLines(path);
                    break;
                default:
                    Text = File.ReadAllText(path);
                    break;
            }

        }
    }

    public enum ReadOption
    {
        All,
        Lines
    }
}
