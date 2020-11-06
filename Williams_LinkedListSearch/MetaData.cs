using System;
using System.Collections.Generic;
using System.Text;

namespace Williams_LinkedListSearch
{
    class MetaData
    {
        private char gender;
        private string name;
        private int rank;
        private static int nodeCount = 0;
        private static int maleCount = 0;
        private static int femaleCount = 0;

        public MetaData(char gender, string name, int rank) {
            this.gender = gender;
            this.name = name;
            this.rank = rank;
            GenderCount();
            nodeCount++;
        }
        public char Gender
        {
            get { return gender; }
        }
        public string Name
        {
            get { return name; }
        }
        public int Rank
        {
            get { return rank; }
        }

        public int NodeCount { get { return nodeCount; } }
        public int MaleCount { get { return maleCount; } }
        public int FemaleCount { get { return femaleCount; } }


        public void GenderCount() {
            if (gender == 'M')
            {
                maleCount++;
            }
            else {
                femaleCount++;
            }
        }
    }
}
