using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace c3m.Sample
{
    public class ChaserTarget : MonoBehaviour
    {
        public UnityEvent OnArrived; // 抵達目標時觸發的事件

        // Start is called before the first frame update
        void Start()
        {
            // 設定要追逐的目標
            ChaserManager.SetTarget(transform);
        }
    }

}
