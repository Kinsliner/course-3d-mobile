using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputBase : MonoBehaviour
{
    public abstract float GetHorizontal();
    public abstract float GetVertical();
}
