using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Lives : MonoBehaviour
{


    public int WrongPoints = 0;
    public int CorrectPoints = 0;
    public int Skipped = 0;
    public int limit;

    public Text correct;
    public Text wrong;
    public Text skipped;

    private void OnGUI()
    {
        correct.text = "Correct:" + CorrectPoints;
        wrong.text = "Wrong:" + WrongPoints;
        skipped.text = "Skipped:" + Skipped;
        /*if (WrongPoints == limit)
        {
            FindObjectOfType<GameMannager>().EndGame();
        }*/

    }
    
}