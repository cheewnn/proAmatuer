using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinMovement : MonoBehaviour {

    public GameObject Coin;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 90 * Time.deltaTime);
	}

     void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {

            Coin.GetComponent<Renderer>().enabled = false;
            AudioSource source = GetComponent<AudioSource>();
            source.Play();
           // other.GetComponent<CoinDetect>().points++;
            Destroy(gameObject, 1.0f);

           //RandomGenerator generate = GetComponent<RandomGenerator>();
         //  generate.RandomGenerate();
           // other.GetComponent<RandomGenerator>();

        }
    }
}
