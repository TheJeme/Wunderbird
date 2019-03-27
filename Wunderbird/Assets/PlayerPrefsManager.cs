using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public int highScore;
    string highScoreKey = "HighScore";

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);    
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
