namespace FileManipulation
{
    internal class FileManipulator
    {
        private static string _path = @"C:\\Users\\" + Environment.UserName;
        public string FullPath { get; set; }
        StreamWriter sw;
        StreamReader sr;

        public FileManipulator(string fileName)
        {
            FullPath = _path + @"\\Documents\\" + fileName + ".txt";
        }

        public bool CreatePath()
        {
            try
            {
                if (File.Exists(FullPath)) sw = File.AppendText(FullPath);
                else sw = new StreamWriter(FullPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: "+ ex.Message);
                return false;
            }
            return true;
        }

        public bool WritePerson(Person person)
        {
            try
            {
                sw.WriteLine(person);
            } catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return false;
            }
            sw.Close();
            return true;
        }

        public string ReadFile()
        {
            if (File.Exists(FullPath)) sr = new StreamReader(FullPath);
            else return "";

            string text = sr.ReadToEnd();
            sr.Close();

            return text;
        }

        public override string ToString()
        {
            return ReadFile();
        }
    }
}
