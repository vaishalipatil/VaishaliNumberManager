using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Vaishali.DataModel;

namespace Vaishali.DataAccess.FileStorage
{
    public class FileOperations : IDataConnection
    {
        private static string _directoryPath = ".";
        private static string _filePath;
        private static FileInfo _fileInfo;

        public FileOperations()
        {
            LoadFilebase();
        }

        private void LoadFilebase()
        {
            _filePath = _directoryPath+"\\data.txt";
            _fileInfo = new FileInfo(_filePath);
            if (!_fileInfo.Exists)
            {
                if (Directory.Exists(_directoryPath))
                {
                    var writer = new StreamWriter(_filePath, true);
                    int count = 5;
                    while (count > 0)
                    {
                        writer.WriteLine("0");
                        count --;
                    }
                    writer.Close();
                }
            }
        
        }

        public void Write(IList<Number> numbers)
        {
            // Write the string to a file.
            EnsureFile(_fileInfo);
            var file = new System.IO.StreamWriter(_filePath);
            foreach (var number in numbers)
            {
                file.WriteLine(number.NumberValue);
            }
            file.Close();
        }

        protected bool EnsureFile(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

        public IList<Number> Read()
        {
            int counter = 1;
            string line;
            IList<Number> numbers = new List<Number>();
            try
            {
                EnsureFile(_fileInfo);
                var file = new System.IO.StreamReader(_filePath);
                while ((line = file.ReadLine()) != null)
                {
                    int value = int.TryParse(line.Trim(), out value) ? value : 0;
                    var number = new Number(counter, value);
                    numbers.Add(number);
                    counter++;
                }

                file.Close();
            }
            catch (Exception exception)
            {

            }
            
            return numbers;
            
        }
    }
}
