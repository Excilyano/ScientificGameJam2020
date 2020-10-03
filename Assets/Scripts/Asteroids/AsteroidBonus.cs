using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBonus : Asteroid
{
    public List<GameObject> bonuses;
    private GameObject currentBonus;

    // Start is called before the first frame update
    new public void Start()
    {
        base.Start();
        currentBonus = bonuses[Random.Range(0, bonuses.Count)];
    }

    // Update is called once per frame
    new public void Update()
    {
        base.Update();
        if (pointDeVie <= 0) Destruction();
    }

    new public void Destruction() {
        Instantiate(currentBonus, transform.position, Quaternion.identity);
        base.Destruction();
    }
}
