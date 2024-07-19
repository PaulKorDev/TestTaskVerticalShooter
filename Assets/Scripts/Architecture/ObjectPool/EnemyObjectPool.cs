using UnityEngine;
using Assets.Scripts.Enemy.EnemyTypes;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Enemy.Factory;

namespace Assets.Scripts.Architecture.ObjectPool
{
    public class EnemyObjectPool : ObjectPool<EnemyBase>, IService
    {
        private static int _preload = 3;
        private static bool _autoExpand = true;

        public EnemyObjectPool() : base(FactoryMethod, GetEffect, ReturnEffect, _preload, _autoExpand)
        { 
        }

        private static EnemyBase FactoryMethod()
        {
            return ServiceLocator.ServiceLocator.Get<EnemyFactory>().CreateEnemy();
        }
        private static void GetEffect(EnemyBase enemy, Vector3 spawnPoint) {
            enemy.transform.position = spawnPoint;
            enemy.InitEnemy();
            enemy.gameObject.SetActive(true);
        } 
        private static void ReturnEffect(EnemyBase enemy) => enemy.gameObject.SetActive(false);
    }
}
