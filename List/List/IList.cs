using System.Collections;
using System.Collections.Generic;

namespace List
{
    public interface IList<T> : IReadOnlyCollection<T>
    {
        int Capacity { get; set; }
        public T this[int index] { get; set; }
        void Add(T item);
        void AddRange(IReadOnlyCollection<T> items);
        bool Remove(T item);
        bool RemoveAt(int index);
        void Sort(IComparer<T> comparer);
    }
}
