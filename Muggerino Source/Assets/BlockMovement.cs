using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public Transform Block;
    public Rigidbody BL;
    int horizontal = 150;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BL.AddForce(horizontal * Time.deltaTime, 0, 0);

        if (Block.position.x >= 5)
        {
            BL.AddForce(-horizontal * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }
        else if(Block.position.x<=-5){
            BL.AddForce(horizontal * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }

    }
}
