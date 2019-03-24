using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornSpawner : MonoBehaviour
{
    public int acornsCollected = 0;
    public GameObject acorn;
    public bool isAcorn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAcorn)
        {
            isAcorn = true;
            Invoke("SpawnAcorn", Random.Range(7f,12f));
        }
    }

    void SpawnAcorn()
    {
        if (GameObject.Find("Bird").GetComponent<Bird>().isAlive)
        {
            Vector2 randomPos = new Vector2(Random.Range(-2.1f, 2.1f), Random.Range(-4f, 4f));
            Instantiate(acorn, randomPos, Quaternion.identity);
        }
    }
}
