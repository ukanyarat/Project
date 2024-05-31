using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09
{
    class FileManagement
    {

//FileManagement file = new FileManagement("D:\\000000\\WpfApp1\\WpfApp1\\person.txt");
//private List<string> texts = new List<string>();
        private string fileName;

        public FileManagement(string fileName)
        {
            this.fileName = fileName;
        }

        public List<string> ReadFile()
        {
            List<string> texts = new List<string>();
            try
            {
                string[] fileContent = File.ReadAllLines(fileName);
                texts.AddRange(fileContent);
                return texts;
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                return texts;
            }
        }

        public void WriteFile(string v, List<string> texts)
        {
            try
            {
                File.Delete(fileName);
                //File.AppendAllLines(fileName, texts);
                File.WriteAllLines(fileName, texts);
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
         }
      
        internal void AppendToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true)) // true เพื่อเขียนต่อในไฟล์
            {
                sw.WriteLine(text);
            }
        }

        internal string[] ReadAllLines(string v)
        {
            if (File.Exists(fileName))
            {
                return File.ReadAllLines(fileName);
            }
            else
            {
                throw new FileNotFoundException("The specified file was not found.", fileName);
            }
        }
        public void WriteAllLines(string filename, string[] lines)
        {
            File.WriteAllLines(Path.Combine(filename), lines);
        }
    }
}
