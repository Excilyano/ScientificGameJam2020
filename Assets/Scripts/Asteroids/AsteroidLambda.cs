using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLambda : Asteroid
{
    // Update is called once per frame
    new public void Update()
    {
        base.Update();
        if (pointDeVie <= 0) Destruction();
    }
}
