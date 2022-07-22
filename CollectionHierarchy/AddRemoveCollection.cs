using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CollectionHierarchy
{
    using Contracts;
    using System.Collections;

    public class AddRemoveCollection : IAddable, IRemoveable
    {
        private List<string> collection;
        private List<int> indexes;

        public AddRemoveCollection()
        {
            this.collection = new List<string>();
            this.indexes = new List<int>();
        }
        public int Add(string text)
        {
            this.collection.Insert(0, text);
            this.indexes.Add(0);
            return 0;
        }

        public string GetRemoves(int removeCount)
        {
            List<string> removes = new List<string>();
            for (int i = 0; i < removeCount; i++)
            {
                removes.Add(this.Remove());
            }

            return String.Join(' ', removes);
        }

        public string JoinIndexes()
        {
            return String.Join(' ', this.indexes);
        }

        public string Remove()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException($"The list is empty.");
            }

            string item = this.collection[this.collection.Count - 1];
            this.collection.RemoveAt(this.collection.Count - 1);
            return item;
        }
       
    }
}
