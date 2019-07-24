using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject Hazard;
    public Vector3 SpawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GUIText gameOverText;
    public GUIText restartText;
    public GUIText scoreText;
    public bool gameOver;
    private int score;
    

    void Start ()
    {
        Screen.SetResolution(640,480,false);
        gameOver = false;
        gameOverText.text = "";
        restartText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves ());
    }
    void Update()
    {
        if (gameOver)
        {
            restartText.text = "Press 'R' for Restart";
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i=0;i<hazardCount;i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(Hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds (waveWait);

            if (gameOver)
            {
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over"+"\n" +"lalala" +"\n"+"是不是很想把这歌听完"+"\n"+ "哈哈哈";
        gameOver = true;
    }
}
