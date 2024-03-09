using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageReceiver : MonoBehaviour
{
    public UnityEvent<int> OnReceive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Receive(int damage)
    {
        OnReceive?.Invoke(damage);
    }
}
