using UnityEngine;

namespace Assets.Scripts.Architecture.ObjectPool.ExampleObjectPool
{
    public class ConcreteObjectPool : ObjectPool<MyObjectClass>
    {
        public ConcreteObjectPool(MyObjectClass prefab, Transform container, int preload) : base(() => FactoryMethod(prefab, container), GetEffect, ReturnEffect, preload, true, 8)
        { 
        }

        private static MyObjectClass FactoryMethod(MyObjectClass prefab, Transform container) => GameObject.Instantiate(prefab, container);
        private static void GetEffect(MyObjectClass obj) => obj.gameObject.SetActive(true);
        private static void ReturnEffect(MyObjectClass obj) => obj.gameObject.SetActive(false);
    }
}
