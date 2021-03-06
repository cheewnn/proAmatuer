﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMannager : MonoBehaviour {
    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;
    public GameObject treeBark;
    public GameObject treeLeaves;
    public GameObject sphere;
    public GameObject box;

    private void Start()
    {
        

        int duplicateTimes3 =300;
        for (int k = 0; k < duplicateTimes3; k++)
        {
            int randomX = Random.Range(-6, 6);
            int randomZ = Random.Range(5, 10000);
            Instantiate(treeBark, new Vector3(randomX, 1.76f, randomZ), Quaternion.identity);
            Instantiate(treeLeaves, new Vector3(randomX-0.636f, 2.936f, randomZ+ 0.528f), Quaternion.identity);
        }

        int duplicateTimes15 = 50;
        for (int k = 0; k < duplicateTimes15; k++)
        {
            int randomX = Random.Range(-6, 6);
            int randomZ = Random.Range(5, 10000);
            Instantiate(sphere, new Vector3(randomX + 5f, 2, randomZ - 3.123f), Quaternion.identity);
            Instantiate(box, new Vector3(randomX + 3.141f, 1, randomZ - 5f), Quaternion.identity);

        }

    }
    public void CompleteLevel()
    {

        completeLevelUI.SetActive(true);
    }

	public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game over");
            //Invoke("Restart", restartDelay);
            Invoke("GameOver", restartDelay);

        }
    }

    /*void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
