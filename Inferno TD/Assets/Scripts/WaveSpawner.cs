using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    private int wave;
    public GameObject spawnPortal;
    public float spawnRate = 2f;
    public GameObject enemy1;
    public GameObject enemy2;

    public GameObject enemy3;

    private SpriteRenderer rend;
    public Color hoverColor;
    public Sprite normal;
    public Sprite hover;
	// Use this for initialization
	void Start () {
        wave = 1;
	}
	
	// Update is called once per frame
	void Update () {
        rend = GetComponent<SpriteRenderer>();
    }

    void NextWave()
    {
        wave++;
        spawnRate -= 0.2f;
    }

    void OnMouseDown()
    {
        if (wave == 3)
        {
            StartCoroutine(SpawnWave2(1));
        }
        if(wave == 5)
        {
            StartCoroutine(SpawnWave3(1));
        }
        if(wave == 7)
        {
            StartCoroutine(SpawnWave3(3));
            StartCoroutine(SpawnWave2(3));
        }
        if (wave == 7)
        {
            StartCoroutine(SpawnWave3(10));
            StartCoroutine(SpawnWave2(10));
        }
        StartCoroutine(SpawnWave());
        
    }

    public int getWaveNumber()
    {
        return wave;
    }

    //Carotine Spawner modified from brackeys tutorial
    //Available at: https://www.youtube.com/watch?v=n2DXF1ifUbU&t=566s
    //Last accessed 6/09/2018
    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(1f);
        for (int i=0; i< wave * 4; i++)
        {
            Instantiate(enemy1, spawnPortal.transform.position, spawnPortal.transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }
        NextWave();

    }

    IEnumerator SpawnWave2(int k)
    {
        for (int i = 0; i < k; i++)
        {
            Instantiate(enemy2, spawnPortal.transform.position, spawnPortal.transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }

    }

    IEnumerator SpawnWave3(int k)
    {
        for (int i = 0; i < k; i++)
        {
            Instantiate(enemy3, spawnPortal.transform.position, spawnPortal.transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }

    }


    void OnMouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = hover;
    }

    void OnMouseExit()
    {
        rend.sprite = normal;
    }
}
