using System;
using System.Collections.Generic;

namespace Assets.Scripts.Architecture.Reactive
{
    public class ReactiveList<T>
    {
        public Action<List<T>> OnItemAdded;
        public Action<List<T>> OnItemRemoved;
        public Action<List<T>> OnListCleared;
        public Action<List<T>> OnListChanged;

        private List<T> _list;

        public int Count => _list.Count;
    
        public ReactiveList(List<T> startList)
        {
            _list = startList;
        }

        public void Add(T item)
        {
            _list.Add(item);

            OnItemAdded?.Invoke(_list);
            OnListChanged?.Invoke(_list);
        }
        public void Remove(T item)
        {
            Remove(_list.IndexOf(item));
        }
        public void Remove(int index)
        {
            _list.RemoveAt(index);

            OnItemRemoved?.Invoke(_list);
            OnListChanged?.Invoke(_list);
        }
        
        public void Clear()
        {
            _list.Clear();

            OnListCleared?.Invoke(_list);
            OnListChanged?.Invoke(_list);
        }
        public T GetElement(int index)
        {
            return _list[index];

        }
        public List<T> GetUsualList()
        {
            return _list; 
        }

    }
}
