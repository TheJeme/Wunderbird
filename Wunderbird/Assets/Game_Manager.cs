using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject pointsCanvas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Bird").GetComponent<Bird>().isStarted == true)
        {
            startCanvas.SetActive(false);
            pointsCanvas.SetActive(true);
        }
    }

}
