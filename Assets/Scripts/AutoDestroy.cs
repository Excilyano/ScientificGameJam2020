using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float timeBeforeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestroy());
    }

    private IEnumerator SelfDestroy() {
        yield return new WaitForSeconds(timeBeforeDestroy);
        Destroy(gameObject);
    }
}
