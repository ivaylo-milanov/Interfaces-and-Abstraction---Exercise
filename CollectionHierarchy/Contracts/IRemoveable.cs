using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Contracts
{
    public interface IRemoveable
    {
        string Remove();
        string GetRemoves(int count);
    }
}
