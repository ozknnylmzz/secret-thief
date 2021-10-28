using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class joystick : MonoBehaviour
{
    public FixedJoystick stick;
    public ThirdPersonUserControl thirdpersonusercontrol;
    // Start is called before the first frame update
    void Start()
    {
        
        thirdpersonusercontrol = thirdpersonusercontrol.GetComponent<ThirdPersonUserControl>();
    }

    void Update()
    {
        thirdpersonusercontrol.Himput = stick.Horizontal;
        thirdpersonusercontrol.Vinput = stick.Vertical;
    }
}
