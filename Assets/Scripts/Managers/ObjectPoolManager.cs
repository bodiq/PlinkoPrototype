using System.Collections.Generic;
using Configs;
using Data;
using DefaultNamespace;
using Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
    {
        [SerializeField] private List<ResourcePool> ballPoolList;

        private Dictionary<ColorTypes, ResourcePool> _ballsPool = new();

        protected override void Awake()
        {
            base.Awake();
            InitializePools();
        }

        private void InitializePools()
        {
            foreach (var pool in ballPoolList)
            {
                pool.PoolQueue = new Queue<Ball>();

                for (var i = 0; i < pool.countToCreate; i++)
                {
                    var ball = Instantiate(pool.ballPrefab, pool.parent);
                    ball.Initialize(pool.color);
                    ball.gameObject.SetActive(false);
                    
                    pool.PoolQueue.Enqueue(ball);
                }
                
                _ballsPool.Add(pool.colorType, pool);
            }
        }
        
        public Ball GetBall(ColorTypes colorType)
        {
            var pool = GetPool(colorType);
            if (pool == null) return null;

            if (pool.PoolQueue.Count > 0)
            {
                return pool.PoolQueue.Dequeue();
            }
            else
            {
                var obj = Instantiate(pool.ballPrefab, pool.parent);
                return obj;
            }
        }
        
        private ResourcePool GetPool(ColorTypes colorType)
        {
            if (!_ballsPool.TryGetValue(colorType, out var pool))
            {
                Debug.LogError("Resource type " + colorType + " not found!");
            }
            return pool;
        }

        public void ReturnBall(ColorTypes colorType, Ball ball)
        {
            var pool = GetPool(colorType);
            if (pool == null)
            {
                Destroy(ball);
                return;
            }

            ball.gameObject.SetActive(false);
            pool.PoolQueue.Enqueue(ball);
        }
    }
}