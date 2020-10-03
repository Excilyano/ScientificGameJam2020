using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject background;
    public GameObject etoiles;
    private GameObject instanceNova1;
    private GameObject instanceNova2;
    private GameObject instanceEtoile1;
    private GameObject instanceEtoile2;
    private Vector3 translationVector = new Vector3(0f, -.08f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        instanceNova1 = Instantiate(background, transform.position, Quaternion.identity);
        instanceNova1.transform.position = new Vector3(0f, 15f, 0f);
        instanceNova2 = Instantiate(background, transform.position, Quaternion.identity);
        instanceNova2.transform.position = new Vector3(0f, 0f, 0f);
        
        instanceEtoile1 = Instantiate(etoiles, transform.position, Quaternion.identity);
        instanceEtoile1.transform.position = new Vector3(0f, 15f, 0f);
        instanceEtoile2 = Instantiate(etoiles, transform.position, Quaternion.identity);
        instanceEtoile2.transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        instanceNova1.transform.Translate(translationVector*Time.deltaTime);
        instanceNova2.transform.Translate(translationVector*Time.deltaTime);
        
        if (instanceNova2.transform.position.y <= -15f) {
            Destroy(instanceNova2);
            instanceNova2 = instanceNova1;
            instanceNova1 = Instantiate(background, transform.position, Quaternion.identity);
            instanceNova1.transform.position = new Vector3(0f, 15f, 0f);
        }

        instanceEtoile1.transform.Translate(translationVector*Time.deltaTime*10f);
        instanceEtoile2.transform.Translate(translationVector*Time.deltaTime*10f);
        
        if (instanceEtoile2.transform.position.y <= -15f) {
            Destroy(instanceEtoile2);
            instanceEtoile2 = instanceEtoile1;
            instanceEtoile1 = Instantiate(etoiles, transform.position, Quaternion.identity);
            instanceEtoile1.transform.position = new Vector3(0f, 15f, 0f);
        }
    }
}
