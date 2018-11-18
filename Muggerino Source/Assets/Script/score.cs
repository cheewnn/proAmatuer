using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    public Transform player;
    public GameObject scoreText;




    public float sc = 0;
    public float pz;
    public float totalsc = 0;

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.Find("Player");
        AnswerCollision answerCollision = Player.GetComponent<AnswerCollision>();
        pz = player.position.z;
        sc = answerCollision.cummulativedsc;

        totalsc = pz + sc;

        scoreText.GetComponent<Text>().text = totalsc.ToString("0");
        Debug.Log("score = " + pz);




    }
}
