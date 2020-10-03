using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionManager : MonoBehaviour
{
    public static void OnJouer() {
        SceneManager.LoadScene("PlayScene");
    }

    public static void OnQuitterInGame() {
        SceneManager.LoadScene("Accueil");
    }

    public static void OnQuitter() {
        Application.Quit();
    }
}
