using System;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Architecture.ObjectPool
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private int _poolLimit;
        public bool AutoExpand { get; set; }

        private readonly Func<T> _factory;
        private readonly Action<T> _returnEffect;
        private readonly Action<T> _getEffect;

        private Queue<T> _pool = new Queue<T>();
        private List<T> _activeObjects = new List<T>();

        public ObjectPool(Func<T> Factory, Action<T> GetEffect, Action<T> ReturnEffect, int precount, bool autoExpand = true, int poolLimit = 0)
        {
            AutoExpand = autoExpand;
            _factory = Factory;
            _getEffect = GetEffect;
            _returnEffect = ReturnEffect;
            _poolLimit = poolLimit;

            CreatePool(precount);
        }



        public T GetObject()
        {
            if (_pool.Count > 0)
            {
                T obj = _pool.Dequeue();       
                _getEffect(obj);
                _activeObjects.Add(obj);
                return obj;
            } else if (AutoExpand)
            {
                T obj = CreateObject(true);
                CheckPoolLimit(_poolLimit); 
                return obj;
            }
                
            Debug.LogError($"No free {typeof(T).Name} objects in pool");
            return null;
        }

        public List<T> GetAllObjects()
        {
            List<T> allObjects = new List<T>();

            foreach (T obj in _pool)
                allObjects.Add(obj);
            foreach (T obj in _activeObjects)
                allObjects.Add(obj);

            return allObjects;
        }
        public List<T> GetAllActiveObjects()
        {
            return _activeObjects;
        }

        public void ReturnObject(T obj)
        {
            _returnEffect(obj);
            _activeObjects.Remove(obj);
            _pool.Enqueue(obj);
        }

        public int CountFreeObjects()
        {
            return _pool.Count;
        }
        public int CountActiveObjects()
        {
            return _activeObjects.Count;
        }
        public int CountAllObjects()
        {
            return CountActiveObjects() + CountFreeObjects();
        }
        private void CreatePool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }
        private void CheckPoolLimit(int currentPoolLimit)
        {
            int ObjectsInPoolCount = CountAllObjects();
            if (ObjectsInPoolCount < currentPoolLimit)
                AutoExpand = true;
            else if (ObjectsInPoolCount >= currentPoolLimit)
                AutoExpand = false;
            if (currentPoolLimit <= 0) //0 OR less mean that pool hasn't limit (infinity)
                AutoExpand = true;
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            T createdObject = _factory();
            if (isActiveByDefault)
            {
                _getEffect(createdObject);
                _activeObjects.Add(createdObject);
            }
            else 
            {
                createdObject.gameObject.SetActive(false);
            }
            return createdObject;

        }
    }
}
