using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour {
    public GameObject gameoverText; 
    public Text timeText;

    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private float surviveTime; 
    private bool isGameover;

    private float spawnRate; 
    private float timeAfterSpawn; 

    void Start() {
        surviveTime = 0;
        isGameover = false;

       
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    void Update() {
        if (!isGameover)
        {
            timeAfterSpawn += Time.deltaTime;
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
         
            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0f;

                GameObject bullet = Instantiate(bulletPrefab,new Vector3(Random.Range(-8f, 8f), 20f, Random.Range(-120f, 120f)),Quaternion.identity);
                GameObject bullet2 = Instantiate(bulletPrefab, new Vector3(Random.Range(-8f, 8f), 20f, Random.Range(-120f, 120f)), Quaternion.identity);
                GameObject bullet3 = Instantiate(bulletPrefab, new Vector3(Random.Range(-8f, 8f), 20f, Random.Range(-120f, 120f)), Quaternion.identity);

                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }

            if (surviveTime > 30)
            {
                PlayerController con = FindObjectOfType<PlayerController>();
                con.gameObject.SetActive(false);
                EndGame();
            }
        }
       
    }

    public void EndGame() {
        isGameover = true;
       
        gameoverText.SetActive(true);
        Application.Quit();

        


    }
}