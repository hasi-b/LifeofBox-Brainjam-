using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyEnables : MonoBehaviour
{
    [SerializeField] private GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SoundManager.PlaySound("health");
            key.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
