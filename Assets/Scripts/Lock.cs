using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject saw;
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
        if (collision.tag == "bullet")
        {

            SoundManager.PlaySound("health");
            saw.SetActive(true);
            Destroy(wall);
            Destroy(this.gameObject);
        }
    }
}
