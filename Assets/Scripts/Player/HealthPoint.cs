using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    public int maxPoint = 100;

    public GameObject deadEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Decrease(int damage)
    {
        maxPoint -= damage;
        if (maxPoint <= 0)
        {
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
