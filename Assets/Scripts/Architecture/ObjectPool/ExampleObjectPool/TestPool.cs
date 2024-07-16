using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Architecture.ObjectPool.ExampleObjectPool
{
    public class TestPool : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private MyObjectClass _prefab;

        private ObjectPool<MyObjectClass> _pool;

        private void Awake()
        {
            _pool = new ConcreteObjectPool(_prefab, _container, 4);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) {
                var obj = _pool.GetObject();
                if (obj != null) StartCoroutine(LifeCicle(obj));
            }
        }

        private IEnumerator LifeCicle(MyObjectClass obj)
        {
            yield return new WaitForSeconds(3);
            _pool.ReturnObject(obj);
        }
    }
}
