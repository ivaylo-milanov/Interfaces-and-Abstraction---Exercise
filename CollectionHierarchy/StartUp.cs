using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class StartUp
    {
        private static int removeCount;
        static void Main(string[] args)
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            string[] meals = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            removeCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < meals.Length; i++)
            {
                addCollection.Add(meals[i]);
                addRemoveCollection.Add(meals[i]);
                myList.Add(meals[i]);
            }

            Console.WriteLine(addCollection.JoinIndexes());
            Console.WriteLine(addRemoveCollection.JoinIndexes());
            Console.WriteLine(myList.JoinIndexes());
            Console.WriteLine(addRemoveCollection.GetRemoves(removeCount));
            Console.WriteLine(myList.GetRemoves(removeCount));
        }
        
    }
}
