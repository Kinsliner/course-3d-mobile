using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace c3m.Sample
{
    public class Chaser : MonoBehaviour
    {
        public bool IsChasing { get; private set; } // 是否正在追蹤
        public bool IsArrived { get; private set; } // 是否已經抵達目標

        [SerializeField]
        private Transform target; // 要追逐的目標
        [SerializeField]
        private float moveSpeed = 5f; // 追逐者的移動速度
        [SerializeField]
        private float stopChaseDistance = 2f; // 停止追逐的距離

        /// <summary>
        /// 設定要追逐的目標
        /// </summary>
        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        private void OnEnable()
        {
            // 新增追逐者
            ChaserManager.AddChaser(this);
        }

        private void OnDisable()
        {
            // 移除追逐者
            ChaserManager.RemoveChaser(this);
        }

        void Update()
        {
            if (target == null)
                return;

            // 計算目標方向
            Vector3 direction = (target.position - transform.position).normalized;

            // 計算旋轉角度，並使追逐者朝向目標
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

            // 計算追逐者與目標之間的距離
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            // 如果距離小於停止追逐的距離，則停止追逐
            if (distanceToTarget <= stopChaseDistance)
            {
                IsChasing = false;

                IsArrived = true;
            }
            else
            {
                IsChasing = true;

                IsArrived = false;
            }

            if (IsChasing)
            {
                // 追逐目標
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
        }
    }
}

