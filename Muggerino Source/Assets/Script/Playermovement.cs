using UnityEngine;

public class Playermovement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardForce = 4000f;
    public float sideForce = 500f;
    public float upwardsForce = 1000f;
    public float resistanceForce = 2000f;
    public Transform player;
    public Quaternion OriginalRotation;

    void Start()
    {
        OriginalRotation = player.rotation;
        Debug.Log(OriginalRotation);
    }





    // Update is called once per frame
    void FixedUpdate () {
        float Torque = sideForce * Time.deltaTime;

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)) 
        {

            if (player.position.y <= 2 )
            {
                rb.AddForce(0, upwardsForce * Time.deltaTime, 0, ForceMode.VelocityChange);
            }
            if (player.position.y > 2 && player.position.y <=10)
            {
                rb.AddForce(0, 0, -resistanceForce * Time.deltaTime);
            }


        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Torque, 0, 0, ForceMode.VelocityChange);
            transform.Rotate(0, 0, Torque);
        }

        if (Input.GetKey("a")|| Input.GetKey(KeyCode.LeftArrow))
        {
            
            rb.AddForce(-Torque , 0, 0, ForceMode.VelocityChange);
            transform.Rotate(0, 0, -Torque);

        }

        player.rotation = Quaternion.RotateTowards(player.rotation, OriginalRotation, 25f * Time.deltaTime);

        /*else if (player.rotation.z > -0.4999)
        {
            transform.Rotate(0, 0, -Torque);
        }

        else if (player.rotation.z< -0.50001)
        {
            transform.Rotate(0, 0, Torque);
        }*/
        

        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameMannager>().EndGame();
        }
    }
}
