using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendTo(GameObject obj)
    {
        var receiver = obj.GetComponentInChildren<DamageReceiver>();
        if (receiver == null)
        {
            receiver = obj.GetComponentInParent<DamageReceiver>();
        }
        if (receiver != null)
        {
            receiver.Receive(damage);
        }
    }
}
