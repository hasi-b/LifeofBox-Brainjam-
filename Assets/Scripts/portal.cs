using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SoundManager.PlaySound("health");
            Debug.Log("playerDetection");
            int y = SceneManager.GetActiveScene().buildIndex;
           
                SceneManager.LoadScene(y + 1);
            
          
            
        }
    }
}
