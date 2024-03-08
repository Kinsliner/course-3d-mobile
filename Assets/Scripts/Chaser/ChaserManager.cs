using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace c3m.Sample
{
    public static class ChaserManager
    {
        private static Transform target; // 要追逐的目標
        private static List<Chaser> chasers = new List<Chaser>(); // 所有追逐者的清單

        // 設定要追逐的目標
        public static void SetTarget(Transform target)
        {
            ChaserManager.target = target;

            // 通知所有追逐者要追逐的目標已經改變
            foreach (Chaser chaser in chasers)
            {
                chaser.SetTarget(target);
            }
        }

        // 新增追逐者
        public static void AddChaser(Chaser chaser)
        {
            // 如果追逐者已經存在於清單中，則不做任何事
            if (chasers.Contains(chaser))
                return;

            // 將追逐者加入清單
            chasers.Add(chaser);

            // 設定追逐者的目標
            chaser.SetTarget(target);
        }

        // 移除追逐者
        public static void RemoveChaser(Chaser chaser)
        {
            // 如果追逐者不存在於清單中，則不做任何事
            if (!chasers.Contains(chaser))
                return;

            // 將追逐者從清單中移除
            chasers.Remove(chaser);
        }
    }

}
