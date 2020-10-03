using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int pointDeVie;
    public GameObject explosion;
    public Vector3 rotationVector;
    private Vector3 translationVector;

    // Start is called before the first frame update
    public void Start()
    {
        float xTranslation = Random.Range(-.5f, .5f);
        float yTranslation = Random.Range(-1.2f, -.8f);
        translationVector = new Vector3(xTranslation, yTranslation, 0f);
    }

    // Update is called once per frame
    public void Update()
    {
        transform.eulerAngles += rotationVector * Time.deltaTime;
        transform.position += (translationVector * Time.deltaTime);
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPosition.x < 0f || viewportPosition.x > .9f) translationVector.x = -translationVector.x;
        if (viewportPosition.y < 0f) Destroy(gameObject);
    }

    public void Destruction() {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
