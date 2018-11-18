using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class AnswerCollision : MonoBehaviour
{
    

    public float cummulativedsc = 0f;
    public float dsc = 100f;
    public Playermovement movement;

    public int num1;
    public int num2;
    public int correctanswer;
    public GameObject RightAnswerPrefab;
    public GameObject WrongAnswer1Prefab;
    public GameObject WrongAnswer2Prefab;
    GameObject newrightanswer;
    GameObject newwronganswer1;
    GameObject newwronganswer2;
    public Transform player;
    public int wronganswer1;
    public int wronganswer2;
    public float rAnsPz;
    public float w1AnsPz;
    public float w2AnsPz;
    public float DePosition;
    public float Allowance = 5;
    public GameObject InvisibleWall;
    GameObject newinvisiblewall;
    public float lives = 5;

    public void Start()
    {
        RandomGenerate();
        Debug.Log("DePosition" + DePosition);

    }


    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "RightAnswer")
        {
            
            //Right answer will disappear, invisible wall will disappear
            Destroy(newrightanswer);
            Destroy(newinvisiblewall);

            //prevent player from colliding with other ans
            newwronganswer1.GetComponent<Collider>().enabled = false;
            newwronganswer2.GetComponent<Collider>().enabled = false;
            //RightAnswerPrefab.GetComponent<Canvas>().enabled = false;

            //add points for right answer
            cummulativedsc = cummulativedsc + dsc;

            //add to correct answer
            GameObject.Find("Lifesystem").GetComponent<Lives>().CorrectPoints++;

            //random generate new problem sum with cube
            RandomGenerate();

            


        }

        if (collisionInfo.collider.tag == "WrongAnswer1")
        {
            //wrong answer will disappear
            Destroy(newwronganswer1);
            Destroy(newinvisiblewall);

            //prevent player from colliding with other ans
            newrightanswer.GetComponent<Collider>().enabled = false;
            newwronganswer2.GetComponent<Collider>().enabled = false;

            cummulativedsc = cummulativedsc - dsc;

            GameObject.Find("Lifesystem").GetComponent<Lives>().WrongPoints++;
            RandomGenerate();

        }

        if (collisionInfo.collider.tag == "WrongAnswer2")
        {
            //wrong answer will disappear
            Destroy(newwronganswer2);
            Destroy(newinvisiblewall);

            //prevent player from colliding with other ans
            newrightanswer.GetComponent<Collider>().enabled = false;
            newwronganswer1.GetComponent<Collider>().enabled = false;

            cummulativedsc = cummulativedsc - dsc;


            GameObject.Find("Lifesystem").GetComponent<Lives>().WrongPoints++;
            RandomGenerate();

        }


        /*if (rAnsPz >= w1AnsPz && rAnsPz >= w2AnsPz)
        {
            DePosition = rAnsPz + Allowance;
        }
        else if (w1AnsPz >= rAnsPz && w1AnsPz >= w2AnsPz)
        {
            DePosition = w1AnsPz + Allowance;
        }
        else if (w2AnsPz >= rAnsPz && w2AnsPz >= w1AnsPz)
        {
            DePosition = w2AnsPz + Allowance;
        }*/

        if (collisionInfo.collider.tag == "InvisibleWall")
        {
            GameObject.Find("Lifesystem").GetComponent<Lives>().Skipped++;

            cummulativedsc = cummulativedsc - dsc;

            if (GameObject.Find("Lifesystem").GetComponent<Lives>().Skipped> lives)
            {
                movement.enabled = false;
                FindObjectOfType<GameMannager>().EndGame();
            }
            Destroy(newinvisiblewall);
            RandomGenerate();

        }

      
    }


    public void RandomGenerate()
    {
        //generate new problem sum
        num1 = Random.Range(1, 6);
        num2 = Random.Range(1, 5);
        GameObject.Find("Multiplication").GetComponent<Text>().text = "" + num1 + "x" + num2;
        correctanswer = num1 * num2;

        //spawning new right answer cube
        float rAnsPx = Random.Range(-5, 5);
        rAnsPz = Random.Range(player.position.z + 30, player.position.z + 50);
        newrightanswer = Instantiate(RightAnswerPrefab, new Vector3(rAnsPx, 1, rAnsPz), Quaternion.identity);
        //assigning new answer to right ans text
        newrightanswer.GetComponentInChildren<Text>().text = correctanswer.ToString();

        //spawn wrong ans cube 1
        float w1AnsPx = Random.Range(-5, 5);
        w1AnsPz = Random.Range(player.position.z + 30, player.position.z + 50);
        newwronganswer1 = Instantiate(WrongAnswer1Prefab, new Vector3(w1AnsPx, 1, w1AnsPz), Quaternion.identity);
        //assigning wrong ans to wrong ans 1 text
        wronganswer1 = num1 * Random.Range(7, 11);
        newwronganswer1.GetComponentInChildren<Text>().text = wronganswer1.ToString();

        //spawn wrong ans cube 2
        float w2AnsPx = Random.Range(-5, 5);
        w2AnsPz = Random.Range(player.position.z + 30, player.position.z + 50);
        newwronganswer2 = Instantiate(WrongAnswer2Prefab, new Vector3(w2AnsPx, 1, w2AnsPz), Quaternion.identity);
        //assigning wrong ans to wrong ans 2 text
        wronganswer2 = correctanswer * Random.Range(2, 5);
        newwronganswer2.GetComponentInChildren<Text>().text = wronganswer2.ToString();

        if (rAnsPz >= w1AnsPz && rAnsPz >= w2AnsPz)
        {
            DePosition = rAnsPz + Allowance;
        }
        else if (w1AnsPz >= rAnsPz && w1AnsPz >= w2AnsPz)
        {
            DePosition = w1AnsPz + Allowance;
        }
        else if (w2AnsPz >= rAnsPz && w2AnsPz >= w1AnsPz)
        {
            DePosition = w2AnsPz + Allowance;
        }

        //generate invisible end wall 

        newinvisiblewall = Instantiate(InvisibleWall, new Vector3(0, 6, DePosition), Quaternion.identity);
        Debug.Log(player.position.z + " " + correctanswer);

        



    }



    

}