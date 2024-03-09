using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace c3m.Sample
{
    public class Spawner : MonoBehaviour
    {
        public Action<GameObject> OnSpawn; // 生成物件事件

        [Header("玩家物件")]
        public Transform player;
        [Header("要生成的預置物")]
        public GameObject objectPrefab;
        [Header("最大生成範圍半徑")]
        public float maxSpawnRadius = 5f; 
        [Header("最小生成範圍半徑")]
        public float minSpawnRadius = 5f;
        [Header("生成間隔")]
        public float spawnInterval = 2f;

        private float currentSpawnTime; // 生成用的計時器

        private static int number; // 生成物件的編號

        private void Start()
        {
            if (player == null)
            {
                GameObject playerObj = GameObject.FindWithTag("Player");
                if (playerObj != null)
                {
                    player = playerObj.transform;
                }
            }
        }

        private void Update()
        {
            // 如果沒有生成物，則不執行
            if (objectPrefab == null)
            {
                return;
            }

            // 更新計時器
            currentSpawnTime += Time.deltaTime;
            if (currentSpawnTime >= spawnInterval)
            {
                // 重置計時器
                currentSpawnTime = 0f;
                // 生成物件
                SpawnObject();
            }
        }

        [ContextMenu("Spawn")]
        // 生成一個物件的方法
        private void SpawnObject()
        {
            // 在指定的最小範圍外生成一個隨機的角度
            float randomAngle = Random.Range(0f, 360f);
            Vector2 randomDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

            // 將角度轉換為向量來獲取生成的位置
            Vector3 spawnPosition = player.position + new Vector3(randomDirection.x, 0f, randomDirection.y) * Random.Range(minSpawnRadius, maxSpawnRadius);

            // 實例化物件預置體
            GameObject clone = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

            clone.name = clone.name + number++;

            // 觸發生成物件事件
            OnSpawn?.Invoke(clone);
        }
    }
}

