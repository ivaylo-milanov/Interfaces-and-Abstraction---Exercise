using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    using Contracts;
    using System.Collections;

    public class MyList : IAddable, IRemoveable
    {
        private List<string> collection;
        private List<int> indexes;

        public MyList()
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

        public string Remove()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException($"The list is empty.");
            }

            string item = this.collection[0];
            this.collection.RemoveAt(0);
            return item;
        }

        public string JoinIndexes()
        {
            return String.Join(' ', this.indexes);
        }

        public int Used { get { return this.collection.Count; } }

        public string GetRemoves(int removeCount)
        {
            List<string> removes = new List<string>();
            for (int i = 0; i < removeCount; i++)
            {
                removes.Add(this.Remove());
            }

            return String.Join(' ', removes);
        }
    }
}
