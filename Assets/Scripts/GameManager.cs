using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    int points = 0;

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI pointsEndText;
    public TextMeshProUGUI endText;

    public GameObject endScreen;

    public static GameManager instance;

    private void Awake() {
        if (instance != null) {
            Destroy(instance.gameObject);
        }
        instance = this;
    }

    public void ShowEndScreen() {
        endScreen.SetActive(true);

        if (NewHighScore(points)) {
            endText.SetText("New highscore!");
        } else {
            endText.SetText("Highscore: " + PlayerPrefs.GetInt("HighScore"));
        }
    }

    public void GainPoint() {
        points++;
        pointsText.SetText(points.ToString());
        pointsEndText.SetText(points.ToString());

        if (HasKey("HighScore")) {
            if (NewHighScore(points)) {
                PlayerPrefs.SetInt("HighScore", points);
            }
        } else {
            PlayerPrefs.SetInt("HighScore", points);
        }
    }

    bool HasKey(string s) {
        return PlayerPrefs.HasKey(s);
    }

    bool NewHighScore(int score) {
        return PlayerPrefs.GetInt("HighScore") < score;
    }

    public void TryAgain() {
        SceneManager.LoadScene(0);
    }
}
