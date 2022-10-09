using System;
using System.Collections.Generic;

namespace Algorithms
{

    public class HeapKey<T> where T : IComparable
    {
        protected bool Equals(HeapKey<T> other)
        {
            return Index == other.Index && EqualityComparer<T>.Default.Equals(Item, other.Item);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((HeapKey<T>) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Index, Item);
        }

        public HeapKey(int index, T item)
        {
            Index = index;
            Item = item;
        }
        public int Index { get; set; }

        public T Item { get; set; }

        public int Compare(HeapKey<T> other)
        {
            return Item.CompareTo(other.Item);
        }
        public override string ToString()
        {
            return $"[HeapKey][Index={Index}]:: {Item}";
        }

        public static bool operator <(HeapKey<T> a, HeapKey<T> b)
        {
            return a.Item.CompareTo(b.Item) < 0;
        }

        public static bool operator >(HeapKey<T> a, HeapKey<T> b)
        {
            return a.Item.CompareTo(b.Item) > 0;
        }

        public static bool operator ==(HeapKey<T> a, HeapKey<T> b)
        {
            return a.Item.CompareTo(b.Item) == 0;
        }

        public static bool operator !=(HeapKey<T> a, HeapKey<T> b)
        {
            return !(a == b);
        }
    }


}
