namespace Day01_NotQuiteLisp
{
    internal class FileReader
    {
        public string Text { get; set; }

        public FileReader(string path)
        {
            Text = File.ReadAllText(path);
        }
    }
}
