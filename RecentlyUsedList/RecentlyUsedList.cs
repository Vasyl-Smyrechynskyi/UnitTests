using System;
using System.Collections.Generic;
using System.Linq;

namespace RecentlyUsedList
{
    public class RecentlyUsedList : List<string>
    {
        private readonly List<string> _uniqueStrings;
        private int _listSize = -1;
        private const int DefaultListSize = 5;

        public RecentlyUsedList()
        {
            _uniqueStrings = new List<string>();
            _listSize = DefaultListSize;
        }

        public RecentlyUsedList(int listSize)
        {
            _uniqueStrings = new List<string>();
            _listSize = listSize;
        }

        public RecentlyUsedList(IEnumerable<string> listItems)
        {
            _uniqueStrings = listItems.ToList();
            _listSize = DefaultListSize;
        }

        public RecentlyUsedList(int listSize, IEnumerable<string> listItems)
        {
            _uniqueStrings = listItems.ToList();
            _listSize = listSize;

            TrimListToTheSizeDefined();
        }

        public new void Add(string listitem)
        {
            if (string.IsNullOrEmpty(listitem))
                throw new ArgumentException($"List items should not be Empty or Null. But it was {listitem}");
            AvoidDuplicateInsertion(listitem);

            _uniqueStrings.Insert(0, listitem);

            TrimListToTheSizeDefined();
        }

        public string GetListItem(int index)
        {
            CheckForValidIndex(index);

            return _uniqueStrings != null ? _uniqueStrings[index] : string.Empty;
        }

        public new int Count => _uniqueStrings != null
            ? _uniqueStrings.Count
            : 0;

        public int Size => _listSize;

        public void SetSize(int size)
        {
            _listSize = size >= 0 ? size : _listSize;
        }

        public List<string> ToList() => _uniqueStrings;

        private void CheckForValidIndex(int index)
        {
            if (index < 0)
                throw new ArgumentException(string.Format($"Provided index {index} should be non-negative and not greater than {_uniqueStrings.Count - 1}"));

            if (index > _uniqueStrings.Count - 1)
                throw new ArgumentException(string.Format($"Provided index {index} should not be greater than {_uniqueStrings.Count - 1}."));
        }

        private void AvoidDuplicateInsertion(string listitem)
        {
            var indexOccurenceofItem = _uniqueStrings.IndexOf(listitem);

            if (indexOccurenceofItem > -1)
                _uniqueStrings.RemoveAt(indexOccurenceofItem);
        }

        private void TrimListToTheSizeDefined()
        {
            if (_listSize != -1)
                while (_uniqueStrings.Count > _listSize)
                    _uniqueStrings.RemoveAt(0);
        }
    }
}
