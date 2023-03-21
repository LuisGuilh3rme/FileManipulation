using System.Runtime.CompilerServices;

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

        public bool WritePerson(Person person)
        {
            try
            {
                if (FileExists()) sw = File.AppendText(FullPath);
                else sw = new StreamWriter(FullPath);

                sw.WriteLine(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return false;
            }
            sw.Close();

            return true;
        }

        public string[] ReadFileLines(int l)
        {
            if (File.Exists(FullPath)) sr = new StreamReader(FullPath);
            else return null;

            string[] fullText = new string[l];

            for (int i = 0; i < l; i++)
            {
                fullText[i] = sr.ReadLine();
            }
            return fullText;
        }

        public string ReadFile()
        {
            if (File.Exists(FullPath)) sr = new StreamReader(FullPath);
            else return "";

            string text = sr.ReadToEnd();
            sr.Close();

            return text;
        }

        public bool FileExists()
        {
            return File.Exists(FullPath);
        }

        public override string ToString()
        {
            return ReadFile();
        }
    }
}
