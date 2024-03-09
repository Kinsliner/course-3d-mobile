using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform source;
    public InputBase inputsystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inputsystem == null)
            return;

        if (source == null)
            return;

        float horizontal = inputsystem.GetHorizontal();
        float vertical = inputsystem.GetVertical();

        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        if(direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            source.rotation = rotation;
        }
    }
}
