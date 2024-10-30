using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    
    //private void OnTriggerEnter2D(Collider2D collision)
        private void OnTriggerEnter(Collider collision)
    {
        
        if(collision.tag == "borders") //destory game object when hit left border outside screen
        {
            Destroy(this.gameObject);            
        }
        else if(collision.CompareTag("Player"))
        {
            ScoreManager scoreManager = GameObject.FindObjectOfType<ScoreManager>();
           

            if (scoreManager != null )
            {
                scoreManager.PlayerDied();

            }

            if (player != null)
            {
                Destroy(player);
                Debug.Log("Player is dead");
            }
 
        }
    }
}
