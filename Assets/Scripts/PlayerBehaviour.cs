using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject prefabBalle;
    public GameObject smallExplosion;
    public GameObject bigExplosion;
    public Image whiteScreen;
    public Slider healthbar;
    public GameObject playerSprite;

    private int pointDeVie = 3;
    public int nbBalles = 3;
    public float attackSpeed = .4f;
    public GameObject gameOverCanvas;

    private Vector3 yOffset = new Vector3(0f, .9f, 0f);
    private Vector3 xOffset = new Vector3(.2f, 0f, 0f);
    private Vector3 rotationPerBullet = new Vector3(0f, 0f, 6f);
    private bool invulnerable = false;
    private Color semitransparent = new Color(255f, 255f, 255f, 0.7f);
    private Color transparent = new Color(255f, 255f, 255f, 0f);

    public void Start() {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot() {
        yield return new WaitForSeconds(.5f);
        GameObject instance;
        while(true) {
            if (nbBalles % 2 == 1) {
                instance = Instantiate(prefabBalle, transform.position, Quaternion.identity);
                instance.transform.position += yOffset;
                Instantiate(smallExplosion, instance.transform.position, Quaternion.identity);
                for (int i = 1; i < (nbBalles+1)/2; i++) {
                    instance = Instantiate(prefabBalle, transform.position, Quaternion.identity);
                    instance.transform.position += yOffset + i*xOffset;
                    instance.transform.eulerAngles = -i*rotationPerBullet;
                    Instantiate(smallExplosion, instance.transform.position, Quaternion.identity);

                    instance = Instantiate(prefabBalle, transform.position, Quaternion.identity);
                    instance.transform.position += yOffset - i*xOffset;
                    instance.transform.eulerAngles = i*rotationPerBullet;
                    Instantiate(smallExplosion, instance.transform.position, Quaternion.identity);
                }
            } else {
                for (int i = 0; i < nbBalles/2; i++) {
                    instance = Instantiate(prefabBalle, transform.position, Quaternion.identity);
                    instance.transform.position += yOffset + (i+.5f)*xOffset;
                    instance.transform.eulerAngles = -(i+.5f)*rotationPerBullet;
                    Instantiate(smallExplosion, instance.transform.position, Quaternion.identity);

                    instance = Instantiate(prefabBalle, transform.position, Quaternion.identity);
                    instance.transform.position += yOffset - (i+.5f)*xOffset;
                    instance.transform.eulerAngles = (i+.5f)*rotationPerBullet;
                    Instantiate(smallExplosion, instance.transform.position, Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(attackSpeed);
        }
    }

    public void Move(InputAction.CallbackContext context) {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        transform.position = new Vector3(cursorPos.x, cursorPos.y, 0f);
    }

    public void OnTriggerEnter2D(Collider2D coll) {
        if(coll.CompareTag("Asteroid") && !invulnerable) {
            pointDeVie--;
            if (pointDeVie <= 0) {
                StartCoroutine(TEsMort());
            } else {
                healthbar.gameObject.SetActive(true);
                StartCoroutine(AnimationHealthBar());
                whiteScreen.color = Color.white;
                StartCoroutine(ToWhite());
            }
        }
        if(coll.CompareTag("Bonus")) {
            bool resetStat = false;
            if(coll.gameObject.GetComponent<BonusBehaviour>().type == BonusBehaviour.BonusType.AS && attackSpeed > .06f) {
                attackSpeed *= .8f;
            }
            else if(coll.gameObject.GetComponent<BonusBehaviour>().type == BonusBehaviour.BonusType.Bullets && nbBalles < 7) {
                nbBalles ++;
            }
            else if(coll.gameObject.GetComponent<BonusBehaviour>().type == BonusBehaviour.BonusType.Score) {
                resetStat = WaveManager.IncreaseScore();
            }
            
            if (resetStat) {
                nbBalles = 3;
                attackSpeed = .4f;
            } else {
                StartCoroutine(BumpyAnimation());
            }

            Destroy(coll.gameObject);
        }
    }

    private IEnumerator BumpyAnimation() {
        GameObject spriteInstance = Instantiate(playerSprite, transform.position, Quaternion.identity);
        float scale = spriteInstance.transform.localScale.x;
        float goal = scale * 1.6f * 50 * Time.deltaTime;
        while (spriteInstance.transform.localScale.x < goal) {
            spriteInstance.transform.localScale *= 1.03f;
            yield return null;
        }
        Destroy(spriteInstance);
    }

    private IEnumerator TEsMort() {
        Instantiate(bigExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        gameOverCanvas.SetActive(true);
        Cursor.visible = true;
        string recolte = GameObject.Find("recolte").GetComponent<TextMeshProUGUI>().text;
        recolte = recolte.Replace("{0}", WaveManager.that.wave+"");
        GameObject.Find("recolte").GetComponent<TextMeshProUGUI>().text = recolte;
        yield return null;
    }

    private IEnumerator ToWhite() {
        float t = 0f;
        invulnerable = true;
        while (whiteScreen.color.a > 0f) {
            whiteScreen.color = Color.Lerp(semitransparent, transparent, t+=(2f * Time.deltaTime));
            yield return null;
        }
        invulnerable = false;
    }

    private IEnumerator AnimationHealthBar() {
        yield return new WaitForSeconds(.4f);
        healthbar.value = pointDeVie;
        yield return new WaitForSeconds(.4f);
        healthbar.value = pointDeVie + 1;
        yield return new WaitForSeconds(.4f);
        healthbar.value = pointDeVie;
        yield return new WaitForSeconds(.4f);
        healthbar.value = pointDeVie + 1;
        yield return new WaitForSeconds(.4f);
        healthbar.value = pointDeVie;
        yield return new WaitForSeconds(.8f);
        healthbar.gameObject.SetActive(false);
    }
}
