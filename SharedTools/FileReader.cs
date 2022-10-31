namespace SharedTools
{
    public class FileReader
    {
        public string Text { get; private set; } = "";
        public string[] TextLines { get; private set; } = new string[0];

        public FileReader(string path, ReadOption readOption)
        {
            switch (readOption)
            {
                case ReadOption.All:
                    Text = File.ReadAllText(path);
                    break;
                case ReadOption.Lines:
                    TextLines = File.ReadAllLines(path);
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
