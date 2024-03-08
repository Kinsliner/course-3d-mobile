using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace c3m.Sample
{
    public class ChaserTarget : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // 設定要追逐的目標
            ChaserManager.SetTarget(transform);
        }
    }

}
