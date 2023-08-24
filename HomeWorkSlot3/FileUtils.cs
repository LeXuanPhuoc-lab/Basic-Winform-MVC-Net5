using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class FileUtils
    {
        public static Boolean CreateDirectory(String path)
        {
            Boolean isSucess = false;
            try
            {
                if (Directory.Exists(path))
                {
                    //Console.WriteLine("That path already exist.");
                    return false;
                }

                // Try to create directory
                DirectoryInfo di = Directory.CreateDirectory(path);
                //Console.WriteLine("The directory created sucess at {0}", Directory.GetCreationTime(path));

                if (di != null)
                {
                    isSucess = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The Process failed: {0}", e.ToString());
            }
            return isSucess;
        }

        public static void CreateFileInDirectory(String path, String filename)
        {
            if (!Directory.Exists(path))  // if it doesn't exist, create
                FileUtils.CreateDirectory(path);

            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo fi in di.GetFiles())
            {
                if (fi.Name.Equals(filename))
                {
                    return;
                }
            }
            File.WriteAllText(Path.Combine(path, filename), "");
        }

        public static FileInfo GetFileFromDirectoryByFileName(String path, String filename)
        {
            if (!Directory.Exists(path))  // if it doesn't exist, create
                return null;

            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles(filename);
            return files[0];
        }

        public static void ListFilesInDirectory(String path)
        {
            
            // check existing directory
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"{path} is not exist!");
                return;
            }

            // get all files in directory 
            // init DirectoryInfo for get list of FileInfo 
            DirectoryInfo di = new DirectoryInfo(path);
            // list of files in directory
            FileInfo[] files = di.GetFiles();
            Console.WriteLine("Files in directory");
            // print out name, size of files in list 
            foreach(FileInfo f in files)
            {
                Console.WriteLine($"Filename : {f.Name}, Size: {f.Length}, Create-Date: {f.CreationTime}, Last-modifed-date: {f.LastWriteTime}");
            }
        }

        public static void ListFilesInDirectoryAndSubDirectory(String path)
        {
            // get all files in directory
            ListFilesInDirectory(path);
            // get all files path subdirectory
            DirectoryInfo di = new DirectoryInfo(path);
            var subdirectories = di.EnumerateDirectories();
            Console.WriteLine("Files in sub-directory");
            foreach (DirectoryInfo info in subdirectories)
            {
                FileInfo[] files = info.GetFiles();
                Console.WriteLine($"Subdirectory: {info.Name}");
                foreach(FileInfo f in files)
                {
                    Console.WriteLine($"Filename : {f.Name}, Size: {f.Length}, Create-Date: {f.CreationTime}, Last-modifed-date: {f.LastWriteTime}");
                }
            }
        }
    }
}
