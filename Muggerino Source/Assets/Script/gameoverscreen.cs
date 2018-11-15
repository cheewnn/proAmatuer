using UnityEngine.SceneManagement;
using UnityEngine;

public class gameoverscreen : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Level01");

    }


    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
