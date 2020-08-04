﻿using UnityEngine;

namespace MVCExample
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        public IEnemy CreateEnemy(EnemyData data, EnemyType type)
        {
            var enemyProvider = data.GetEnemy(type);

            return Object.Instantiate(enemyProvider, new Vector3(Random.Range(-5, 5), Random.Range(-5, 5)), Quaternion.identity);
        }
    }
}
