using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall :AcidAttck
{
   
    public override void Update()
    {
        transform.Translate(Vector2.left*_speed*Time.deltaTime);
    }
}
