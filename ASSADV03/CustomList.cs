using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSADV03
{
    public class CustomList<T>
    {
        private List<T> _items;

        public CustomList()
        {
            _items = new List<T>();
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            _items.AddRange(collection);
        }

        // 1. Exists
        public bool Exists(Predicate<T> match)
        {
            if (match == null) throw new ArgumentNullException(nameof(match));
            foreach (T item in _items)
            {
                if (match(item)) return true;
            }
            return false;
        }

        // 2. Find
        public T Find(Predicate<T> match)
        {
            if (match == null) throw new ArgumentNullException(nameof(match));
            foreach (T item in _items)
            {
                if (match(item)) return item;
            }
            return default(T);
        }

        // 3. FindAll
        public List<T> FindAll(Predicate<T> match)
        {
            if (match == null) throw new ArgumentNullException(nameof(match));
            List<T> results = new List<T>();
            foreach (T item in _items)
            {
                if (match(item)) results.Add(item);
            }
            return results;
        }

        // 4. FindIndex
        public int FindIndex(Predicate<T> match)
        {
            return FindIndex(0, _items.Count, match);
        }

        public int FindIndex(int startIndex, Predicate<T> match)
        {
            return FindIndex(startIndex, _items.Count - startIndex, match);
        }

        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            if (match == null) throw new ArgumentNullException(nameof(match));
            if (startIndex < 0 || startIndex > _items.Count) throw new ArgumentOutOfRangeException(nameof(startIndex));
            if (count < 0 || startIndex + count > _items.Count) throw new ArgumentOutOfRangeException(nameof(count));

            int endIndex = startIndex + count;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (match(_items[i])) return i;
            }
            return -1;
        }

        // 5. FindLast
        public T FindLast(Predicate<T> match)
        {
            if (match == null) throw new ArgumentNullException(nameof(match));
            for (int i = _items.Count - 1; i >= 0; i--)
            {
                if (match(_items[i])) return _items[i];
            }
            return default(T);
        }

        // 6. FindLastIndex
        public int FindLastIndex(Predicate<T> match)
        {
            return FindLastIndex(0, _items.Count, match);
        }

        public int FindLastIndex(int startIndex, Predicate<T> match)
        {
            return FindLastIndex(startIndex, _items.Count - startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<T> match)
        {
            if (match == null) throw new ArgumentNullException(nameof(match));
            if (startIndex < 0 || startIndex >= _items.Count) throw new ArgumentOutOfRangeException(nameof(startIndex));
            if (count < 0 || startIndex + count > _items.Count) throw new ArgumentOutOfRangeException(nameof(count));

            int endIndex = startIndex - count + 1;
            for (int i = startIndex; i >= endIndex; i--)
            {
                if (match(_items[i])) return i;
            }
            return -1;
        }

        // 7. ForEach
        public void ForEach(Action<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            foreach (T item in _items)
            {
                action(item);
            }
        }

        // 8. TrueForAll
        public bool TrueForAll(Predicate<T> match)
        {
            if (match == null) throw new ArgumentNullException(nameof(match));
            foreach (T item in _items)
            {
                if (!match(item)) return false;
            }
            return true;
        }

        // Additional Methods (Optional)
        public int Count => _items.Count;
        public T this[int index] => _items[index];

        // Other methods like Remove, RemoveAt, Clear, etc., can also be implemented as needed.
    }

}
