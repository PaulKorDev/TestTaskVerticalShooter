using UnityEngine;
using Assets.Scripts.Enemy.EnemyTypes;

namespace Assets.Scripts.Architecture.ObjectPool.ExampleObjectPool
{
    public class EnemyObjectPool : ObjectPool<EnemyBase>
    {
        private static int _preload = 3;
        private static bool _autoExpand = true;

        public EnemyObjectPool(int preload) : base(FactoryMethod, GetEffect, ReturnEffect, _preload, _autoExpand)
        { 
        }

        private static EnemyBase FactoryMethod()
        {
            //enemyfactory.createEnemy();
            return null;
        }
        private static void GetEffect(EnemyBase enemy) {
            enemy.InitEnemy();
            enemy.gameObject.SetActive(true);
        } 
        private static void ReturnEffect(EnemyBase enemy) => enemy.gameObject.SetActive(false);
    }
}
