using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Williams_LinkedListSearch
{
    class LoadFile
    {
        public static LinkedList FileLoad()
        {
            string line;
            string temp = "";
            char tempGender = 'x';
            string tempName = "";
            int tempRank = -1;
            MetaData tempMetaData;
            LinkedList list = new LinkedList();

            string fileName = "yob2019.txt";
            string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string pathToFile = Path.Combine(filePath, fileName);

            System.IO.StreamReader file = new System.IO.StreamReader(pathToFile);
            while ((line = file.ReadLine()) != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != ',')
                    {
                        temp += line[i];
                    }
                    if (line[i] == ',')
                    {
                        i++;
                        tempName = temp;
                        tempGender = line[i];
                        i += 2;
                        temp = "";
                        while (i < line.Length)
                        {
                            temp += line[i];
                            i++;
                        }
                        Int32.TryParse(temp, out tempRank);
                    }
                }
                tempMetaData = new MetaData(tempGender, tempName, tempRank);
                list.Add(tempMetaData);
                temp = "";
            }
            file.Close();
            return list;
        }
    }
}
