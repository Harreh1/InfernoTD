using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    private int wave;
    public GameObject spawnPortal;
    public float spawnRate = 2f;
    public GameObject enemy1;

    private SpriteRenderer rend;
    public Color hoverColor;
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
        spawnRate -= 0.1f;
    }

    void OnMouseDown()
    {
        StartCoroutine(SpawnWave());
        
    }

    public int getWaveNumber()
    {
        return wave;
    }

    //Carotine Spawner modified from brackeys tutorial
    //Available at: https://www.youtube.com/watch?v=n2DXF1ifUbU&t=566s
    IEnumerator SpawnWave()
    {
        for(int i=0; i< wave * 2 +1; i++)
        {
            Instantiate(enemy1, spawnPortal.transform.position, spawnPortal.transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }
        NextWave();

    }

    void OnMouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.color = Color.white;
    }
}
