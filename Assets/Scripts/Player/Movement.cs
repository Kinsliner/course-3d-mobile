using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform source;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(source == null)
            return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Debug.Log("Horizontal: " + horizontal + " Vertical: " + vertical);

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;

        source.Translate(movement, Space.Self);
        
    }
}
