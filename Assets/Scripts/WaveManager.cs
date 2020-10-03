using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public GameObject StandardAsteroid;
    public GameObject BonusAsteroid;
    public GameObject ScoringAsteroid;
    public TextMeshProUGUI completionText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI echantillonRecolte;
    private int completion = 0;
    public int wave = 1;
    private float fontSize;

    public static WaveManager that;
    // Start is called before the first frame update
    void Start()
    {
        that = this;
        waveText.text = "Vague " + that.wave;
        completionText.text = completion + "%";
        Cursor.visible = false;
        fontSize = completionText.fontSize;
        StartWaveManagement();
    }

    public void StartWaveManagement() {
        StartCoroutine(LaunchWave());
    }

    private IEnumerator LaunchWave() {
        yield return new WaitForSeconds(1f);
        int percentageStandard = 40 + (wave*2);
        int percentageBonus = 15;
        int percentageScore = 15;
        while (completion < 100) {
            int randomAsteroid = Random.Range(0, percentageBonus+percentageScore+percentageStandard);
            float randomPosition = Random.Range(0f, 1f);
            GameObject currentAsteroidType;
            if (randomAsteroid < percentageStandard) {
                currentAsteroidType = StandardAsteroid;
            } else if (randomAsteroid < percentageStandard + percentageBonus) {
                currentAsteroidType = BonusAsteroid;
            } else {
                currentAsteroidType = ScoringAsteroid;
            }
            Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(randomPosition, 1f, 0f));
            position.z = 0f;
            GameObject instance = Instantiate(currentAsteroidType, position, Quaternion.identity);
            
            yield return new WaitForSeconds(1f - ((float)wave/300f));
        }
    }

    public static bool IncreaseScore() {
        bool result = false;
        that.completion += 10 - that.wave/5;

        if (that.completion >= 100) {
            that.StartCoroutine(that.WaveSuccessful());
            that.completion = 0;
            that.wave++;
            that.StartWaveManagement();
            result = true;
        }

        that.completionText.text = that.completion + "%";
        that.StartCoroutine(that.BumpyAnimation());
        that.waveText.text = "Vague " + that.wave;

        return result;
    }

    private IEnumerator BumpyAnimation() {
        completionText.fontSize = fontSize * 1.6f;
        while (completionText.fontSize > fontSize) {
            completionText.fontSize-=1f;
            yield return null;
        }
        completionText.fontSize = fontSize;
        yield return null;
    }

    private IEnumerator WaveSuccessful() {
        foreach (GameObject current in GameObject.FindGameObjectsWithTag("Asteroid"))
        {
            Destroy(current);
        }
        foreach (GameObject current in GameObject.FindGameObjectsWithTag("Bonus"))
        {
            Destroy(current);
        }

        Vector3 position = new Vector3(-800, 0, 0);
        echantillonRecolte.transform.localPosition = position;

        while(position.x < 0) {
            position.x+=(5000f*Time.deltaTime);
            echantillonRecolte.transform.localPosition = position;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        while(position.x < 800) {
            position.x+=(5000f*Time.deltaTime);
            echantillonRecolte.transform.localPosition = position;
            yield return null;
        }
    }
}
