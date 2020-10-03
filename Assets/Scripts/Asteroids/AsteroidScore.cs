using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScore : Asteroid
{
    public GameObject scoreBonus;

    // Update is called once per frame
    new public void Update()
    {
        base.Update();
        if (pointDeVie <= 0) Destruction();
    }

    new public void Destruction() {
        Instantiate(scoreBonus, transform.position, Quaternion.identity);
        base.Destruction();
    }
}
