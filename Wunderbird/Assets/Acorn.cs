using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    private GameObject acorn;

    // Start is called before the first frame update
    void Start()
    {
        acorn = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.Find("Acorn Spawner").GetComponent<AcornSpawner>().isAcorn = false;
            GameObject.Find("Blue Bird").GetComponent<Bird>().ClearSpikes();
            Destroy(this.gameObject);
        }
    }
}
