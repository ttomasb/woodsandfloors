using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecentEntriesLib
{
    public class RecentEntries
    {
        public Queue<string> EntriesQueue { get; set; }

        private bool FileExists;
        private string FileDirectory;
        private string ControlName;
        private string FullFilePath;

        public RecentEntries(string controlName)
        {
            EntriesQueue = GetEntires();
            ControlName = controlName;
            FileDirectory = Directory.GetCurrentDirectory() + "\\RecentEntriesData";
            

            if (!IsFolderCreated())
            {
                CreateDataFolder();
            }
            if (!IsFileCreated())
            {
                CreateFile();
            }
            FullFilePath = FileDirectory + "\\" + ControlName + ".txt";
        }

        public void AddAndSaveEntry(string entry)
        {
            if (!EntriesQueue.Contains(entry))
            {
                EntriesQueue.Enqueue(entry);
            }

            if (EntriesQueue.Count > 9)
            {
                EntriesQueue.Dequeue();
            }
            SaveEntries();
        }

        public void SaveEntries()
        {
            try
            {
                using (StreamWriter sw = File.CreateText(FullFilePath))
                {
                    foreach (string line in EntriesQueue)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to save Entries");
            }
        }

        private bool IsFileCreated()
        {

            foreach (string file in Directory.GetFiles(FileDirectory, "*.txt"))
            {
                if (file.Contains(ControlName))
                {
                    FileExists = true;
                    return true;
                }
            }
            return false;
        }

        private void CreateFile()
        {
            try
            {
                if (FullFilePath != "")
                {
                    File.Create(FullFilePath);
                    FileExists = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private bool IsFolderCreated()
        {
            return Directory.Exists(FileDirectory);
        }

        private void CreateDataFolder()
        {
            Directory.CreateDirectory(FileDirectory);
        }

        

        public Queue<string> GetEntires()
        {
            if (FileExists)
            {
                EntriesQueue = new Queue<string>(File.ReadAllLines(FullFilePath).Reverse());
            }
            else
            {
                EntriesQueue = new Queue<string>();
            }
            return EntriesQueue;
        }
    }
}
