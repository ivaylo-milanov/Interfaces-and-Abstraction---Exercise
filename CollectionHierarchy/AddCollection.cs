using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    using Contracts;
    using System.Collections;

    public class AddCollection : IAddable
    {
        private List<string> collection;
        private List<int> indexes;
        private int currentIndex;

        public AddCollection()
        {
            this.collection = new List<string>();
            this.indexes = new List<int>();
            currentIndex = -1;
        }

        public int Add(string text)
        {
            currentIndex++;
            this.collection.Insert(currentIndex,text);
            this.indexes.Add(currentIndex);
            return currentIndex;
        }
        
        public string JoinIndexes()
        {
            return String.Join(' ', this.indexes);
        }
    }
}
