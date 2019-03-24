using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject pointsCanvas;
    public GameObject endCanvas;
    public GameObject playareaCanvas;

    public GameObject bronzeMedal;
    public GameObject silverMedal;
    public GameObject goldMedal;

    public Text scoretxt;
    public Text highScoretxt;

    public int highScore = 0;
    string highScoreKey = "HighScore";

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Bird").GetComponent<Bird>().isStarted == true)
        {
            startCanvas.SetActive(false);
            pointsCanvas.SetActive(true);
        }

        if (GameObject.Find("Bird").GetComponent<Bird>().isAlive == false)
        {
            endCanvas.SetActive(true);
            pointsCanvas.SetActive(false);
            playareaCanvas.SetActive(false);
            int score = GameObject.Find("Bird").GetComponent<Bird>().points;

            scoretxt.text = score.ToString();
            highScoretxt.text = highScore.ToString();

            if (score <= 25)
                bronzeMedal.SetActive(true);
            else if (score <= 50)
                silverMedal.SetActive(true);
            else
                goldMedal.SetActive(true);

            if (score > highScore)
            {
                highScoretxt.text = score.ToString();
                PlayerPrefs.SetInt(highScoreKey, score);
                PlayerPrefs.Save();
            }
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
