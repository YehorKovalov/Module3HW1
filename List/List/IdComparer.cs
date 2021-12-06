using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class IdComparer : IComparer<TestObject>
    {
        public int Compare(TestObject obj1, TestObject obj2)
        {
            if (obj1 == null)
            {
                return 0;
            }

            return obj1.Id.CompareTo(obj2?.Id);
        }
    }
}
