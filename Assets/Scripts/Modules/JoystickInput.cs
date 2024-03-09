using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : InputBase
{
    public Joystick joystick;

    private void Start()
    {
        if(joystick == null)
        {
            joystick = FindObjectOfType<Joystick>();
        }
    }

    public override float GetHorizontal()
    {
        return joystick.Horizontal;
    }

    public override float GetVertical()
    {
        return joystick.Vertical;
    }
}
