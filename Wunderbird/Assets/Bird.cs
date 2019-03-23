using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public Bird bird;
    private Rigidbody2D rb;
    public GameObject spike;
    public Text pointsText;

    public AudioClip[] audioClip;

    private AudioSource audioSource;
    private Animator anim;

    public GameObject spawnedSpikes;

    public float speed = 3f;
    public int points = 0;

    private bool isFlap;
    public bool isAlive = true;
    public bool isStarted = false;

    private bool isGoingRight = true;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = points.ToString();

        if (isAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Flap();
            }
        }
    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            if (isGoingRight)
            {
                Vector3 temp = transform.position;
                temp.x += speed * Time.deltaTime;
                transform.position = temp;
            }
            else
            {
                Vector3 temp = transform.position;
                temp.x -= speed * Time.deltaTime;
                transform.position = temp;
            }

            if (isFlap)
            {
                isFlap = false;
                rb.velocity = new Vector2(0, 6f);
                audioSource.PlayOneShot(audioClip[0]);
                anim.SetTrigger("Flap");
            }
        }
    }
    public void Flap()
    {
        if (!isStarted)
        {
            isStarted = true;
            Time.timeScale = 1f;
        }
        isFlap = true;
    }

    void ClearSpikes()
    {
        foreach (Transform child in spawnedSpikes.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void SpikeSpawnLeftSide()
    {
        ClearSpikes();
        switch (points)
        {
            case 1:
            case 2:
                SpawnSpikeLeftSide(1);
                break;
            case 3:
            case 4:
            case 5:
                SpawnSpikeLeftSide(2);
                break;
            case 6:
            case 7:
            case 8:
            case 9:
                SpawnSpikeLeftSide(3);
                break;
            case 10:
            case 11:
            case 12:
            case 13:
                SpawnSpikeLeftSide(4);
                break;
            case 14:
            case 15:
            case 16:
            case 17:
                SpawnSpikeLeftSide(5);
                break;
            default:
                SpawnSpikeLeftSide(6);
                break;
        }
    }

    public void SpikeSpawnRightSide()
    {
        ClearSpikes();

        switch (points)
        {
            case 1:
            case 2:
                SpawnSpikeRightSide(1);
                break;
            case 3:
            case 4:
            case 5:
                SpawnSpikeRightSide(2);
                break;
            case 6:
            case 7:
            case 8:
            case 9:
                SpawnSpikeRightSide(3);
                break;
            case 10:
            case 11:
            case 12:
            case 13:
                SpawnSpikeRightSide(4);
                break;
            case 14:
            case 15:
            case 16:
            case 17:
                SpawnSpikeRightSide(5);
                break;
            case 18:
            case 19:
            case 20:
            case 21:
                SpawnSpikeRightSide(6);
                break;
            case 22:
            case 23:
            case 24:
            case 25:
                SpawnSpikeRightSide(7);
                break;
            default:
                SpawnSpikeRightSide(8);
                break;
        }
            
    }
    void SpawnSpikeLeftSide(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            Vector2 leftSideSpawns = new Vector2(-2.3f, Random.Range(-4f, 4f));
            GameObject spawnedLeftSpike = Instantiate(spike, leftSideSpawns, Quaternion.Euler(0, 0, 90));
            spawnedLeftSpike.transform.parent = spawnedSpikes.transform;
        }
    }

    void SpawnSpikeRightSide(int count)
    {
        for(int i = 1; i <= count; i++)
        {
            Vector2 rightSideSpawns = new Vector2(2.3f, Random.Range(-4f, 4f));
            GameObject spawnedRightSpike = Instantiate(spike, rightSideSpawns, Quaternion.Euler(0, 0, -90));
            spawnedRightSpike.transform.parent = spawnedSpikes.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Right")
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isGoingRight = false;
            points++;
            SpikeSpawnLeftSide();
            audioSource.PlayOneShot(audioClip[2]);
        }
        else if (collision.gameObject.tag == "Left")
        {
            transform.localScale = new Vector3(1, 1, 1);
            isGoingRight = true;
            points++;
            SpikeSpawnRightSide();
            audioSource.PlayOneShot(audioClip[2]);
        }
        else if (collision.gameObject.tag == "Deadly" && isAlive)
        {
            Die();
        }
    }

    public void Die()
    {
        GameObject.Find("Bird").GetComponent<Bird>().isAlive = false;
        audioSource.PlayOneShot(audioClip[1]);
        anim.SetTrigger("Die");
        Invoke("ReloadLevel", 1f);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
