using System;
using System.Text;

namespace Algorithms
{
    public interface IHeap<T> where T : IComparable
    {
        int Count { get; }
        int Max { get; }
        void Add(T item);
        T RemoveMin();
    }

    public class Heap<T> : IHeap<T> where T : IComparable
    {
        private HeapKey<T>[] _items;
        public int Count { get; private set; }
        public int Max { get; }

        public Heap(int maxSize)
        {
            _items = new HeapKey<T>[maxSize];
            for (int i = 0; i < _items.Length - 1; i++)
            {
                _items[i] = new HeapKey<T>(i, default);
            }
            Count = 0;
            Max = maxSize;
        }

        public void Add(T item)
        {
            if (Count >= Max) throw new IndexOutOfRangeException("Exceeds maximum heap size.");
            _items[Count].Item = item;
            SortUp(Count);
            Count++;
        }

        public T RemoveMin()
        {
            var minItem = _items[0].Item;
            _items[0].Item = _items[Count - 1].Item;
            Count--;
            SortDown(0);
            return minItem;
        }

        private void SortUp(int startIndex)
        {
            var currentIndex = startIndex;
            var parentIndex = currentIndex - 1;
            while (currentIndex > 0)
            {
                if (_items[currentIndex] < _items[parentIndex])
                {
                    Swap(currentIndex, parentIndex);
                }
                currentIndex -= 1;
                parentIndex -= 1;
            }
        }

        private void SortDown(int startIndex)
        {
            var currentIndex = startIndex;
            while (true)
            {
                var leftIndex = currentIndex + 1;
                var rightIndex = currentIndex + 2;
                
                if (leftIndex < Count && _items[currentIndex] > _items[leftIndex])
                {
                    var swapIndex = leftIndex;
                    if (rightIndex < Count && _items[leftIndex] > _items[rightIndex])
                    {
                        swapIndex = rightIndex;
                    }
                    Swap(currentIndex, swapIndex);
                    currentIndex = swapIndex;
                    continue;
                }
                break;
            }
        }

        private void Swap(int indexA, int indexB)
        {
            var itemA = _items[indexA].Item;
            var itemB = _items[indexB].Item;
            _items[indexA].Item = itemB;
            _items[indexB].Item = itemA;
        }

        public string GetHeapItemRecords()
        {
            var sb = new StringBuilder();
            var genericType = this.GetType().GetGenericTypeDefinition().Name;
            sb.AppendLine($"[START][Heap::{genericType}][Count={Count}][Max={Max}]");
            for (int i = 0; i < Count; i++)
            {
                sb.AppendLine(_items[i].ToString());
            }
            sb.AppendLine($"[END][Heap::{genericType}][Count={Count}][Max={Max}]");
            return sb.ToString();
        }
    }
}