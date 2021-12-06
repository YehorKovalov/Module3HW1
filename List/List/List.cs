using System;
using System.Collections;
using System.Collections.Generic;

namespace List
{
    public class List<T> : IReadOnlyCollection<T>, IList<T>
    {
        private T[] _array;

        public List()
        {
            const byte initialCapacity = 4;
            Capacity = initialCapacity;
            _array = new T[initialCapacity];
        }

        public int Count { get; private set; }
        public int Capacity { get; set; }

        public T this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public void Add(T item)
        {
            const byte itemsLength = 1;
            ExtendArray(itemsLength);
            var lastIndexBeforeExtending = Count - 1;
            _array[lastIndexBeforeExtending] = item;
        }

        public void AddRange(IReadOnlyCollection<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException();
            }

            var lastIndex = Count == 0 ? 0 : Count - 1;
            ExtendArray(items.Count);
            foreach (var item in items)
            {
                _array[lastIndex++] = item;
            }
        }

        public bool Remove(T item)
        {
            var isSucceed = false;
            for (var i = 0; i < Count; i++)
            {
                if (_array[i].Equals(item))
                {
                    isSucceed = RemoveAt(i);
                    break;
                }
            }

            return isSucceed;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                return false;
            }

            var tempArray = _array;
            _array = new T[--Count];
            for (int i = 0; i < Count; i++)
            {
                _array[i] = tempArray[i];
            }

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _array[i];
            }
        }

        public void Sort(IComparer<T> comparer) => Array.Sort<T>(_array, comparer);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void ExtendArray(int newItemsLength)
        {
            Count += newItemsLength;
            while (CapacityExtendingIsNeeded())
            {
                ExtendCapacity();
            }

            var tempArray = _array;
            _array = new T[Capacity];
            tempArray.CopyTo(_array, 0);
        }

        private void ExtendCapacity()
        {
            const byte extendingFactor = 2;
            Capacity *= extendingFactor;
        }

        private bool CapacityExtendingIsNeeded() => Capacity < Count;
    }
}