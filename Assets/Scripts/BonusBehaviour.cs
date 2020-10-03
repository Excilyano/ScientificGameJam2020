using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBehaviour : MonoBehaviour
{
    public enum BonusType {
        AS,
        Bullets,
        Score
    }

    public BonusType type;

    private Vector2 translationVector = new Vector2(0f, -1f);

    public void Update() {
        transform.Translate(translationVector * Time.deltaTime);
        if (Camera.main.WorldToViewportPoint(transform.position).y < 0f) Destroy(gameObject);
    }
}
