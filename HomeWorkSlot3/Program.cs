using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace HomeWork
{
    class Program
    {
        // menu list
        public static String[] menu = {
                "Add Course",
                "Print All Course",
                "Search" ,
                "Sort Course",
                "File options",
                "Quit" };

        static void Main(string[] args)
        { 
            CourseList cList = new CourseList();
            int choice;
            do
            {
                choice = Utils.GetMenuChoice(menu);

                // switch options
                switch (choice)
                {
                    case 1:
                        cList.InputListOfCourse();
                        break;
                    case 2:
                        cList.DisplayListOfCourse();
                        break;
                    case 3:
                        cList.SearchListOfCourse();
                        break;
                    case 4:
                        String[] sortOptions = {
                            "Sort By Id",
                            "Sort By Title",
                            "Sort By StartDate" ,
                            "Return"};
                        int sortOptionChoice = 0;
                        IComparer<Course> comparer = null;
                        do
                        {
                            sortOptionChoice = Utils.GetMenuChoice(sortOptions);

                            switch (sortOptionChoice)
                            {
                                case 1:
                                    comparer = new IdComperer();
                                    cList.SortListOfCourse(comparer);
                                    cList.DisplayListOfCourse();
                                    break;
                                case 2:
                                    comparer = new TitleComperer();
                                    cList.SortListOfCourse(comparer);
                                    cList.DisplayListOfCourse();
                                    break;
                                case 3:
                                    comparer = new StartDateComperer();
                                    cList.SortListOfCourse(comparer);
                                    cList.DisplayListOfCourse();
                                    break;
                            }
                        } while (sortOptionChoice < sortOptions.Length);
                        break;
                    case 5:
                        String[] fileOptions = { 
                            "Show Files in Directory",
                            "Show Files in Directory and its Subdirectory",
                            "Save Course File" , 
                            "Return"};
                        int fileOptionChoice = 0;
                        String path;
                        do
                        {
                            fileOptionChoice = Utils.GetMenuChoice(fileOptions);

                            switch (fileOptionChoice) {
                                case 1:
                                    path = Utils.GetString(".+", "Input Directory Path");
                                    FileUtils.ListFilesInDirectory(path);
                                    break;
                                case 2:
                                    path = Utils.GetString(".+", "Input Directory Path");
                                    FileUtils.ListFilesInDirectoryAndSubDirectory(path);
                                    break;
                                case 3:
                                    cList.WriteFile();
                                    break;
                            }
                        } while (fileOptionChoice < fileOptions.Length);
                        cList.WriteFile();
                        break;
                }
            } while (choice < menu.Length);

        }
    }
}
