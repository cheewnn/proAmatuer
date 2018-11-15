using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBlock : MonoBehaviour {

    public Transform LongBlocks;
    public Rigidbody LBL;
    int vertical = 90;
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        LBL.AddForce(0, vertical * Time.deltaTime, 0);

        if (LongBlocks.position.y >= 6)
        {
            LBL.AddForce(0, -vertical * Time.deltaTime, 0, ForceMode.VelocityChange);

        }
        else if (LongBlocks.position.y <= 1)
        {
            LBL.AddForce(0, vertical * Time.deltaTime, 0, ForceMode.VelocityChange);

        }

    }
}
