using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnswerMovement : MonoBehaviour {


         void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {

            AudioSource source = GetComponent<AudioSource>();
            source.Play();
            
        }
    }
}


