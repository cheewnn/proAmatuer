using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerCollision : MonoBehaviour
{
 
    public Playermovement movement;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
       
            movement.enabled = false;
            FindObjectOfType<GameMannager>().EndGame();
        }

      
          
        
    }

}