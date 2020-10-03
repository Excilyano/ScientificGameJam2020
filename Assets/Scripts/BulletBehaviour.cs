using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Vector2 translationVector;
    public GameObject explosion;

    void Start() {
        StartCoroutine(DestroyOnOutOfScreen());
    }

    private IEnumerator DestroyOnOutOfScreen() {
        while(true) {
            Vector2 currentViewPort = Camera.main.WorldToViewportPoint(transform.position);
            if (currentViewPort.y > 1f) Destroy(gameObject);
            yield return new WaitForSeconds(1f);
        }
    }

    public void OnTriggerEnter2D(Collider2D coll) {
        if(coll.CompareTag("Asteroid")) {
            coll.gameObject.GetComponent<Asteroid>().pointDeVie--;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(translationVector * Time.deltaTime);
    }
}
