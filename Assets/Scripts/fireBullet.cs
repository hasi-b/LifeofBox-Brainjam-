using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour
{

    // [SerializeField] private Transform firepoint;
    // [SerializeField] private GameObject[] fireballs;

    [SerializeField] private Transform Target;
    [SerializeField] private float Range;
    
    bool Detected = false;
    [SerializeField] private GameObject Light;
    [SerializeField] private GameObject shooter;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float FireRate;
    float shootDuration = 0;
    [SerializeField] private float force;

    [SerializeField] private Transform shootPoint;
    Vector2 Direction;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;

        Direction = targetPos -(Vector2) transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,Direction,Range);

        if (rayInfo)
        {
           
            if(rayInfo.collider.gameObject.tag=="Player")
            {
                if(Detected == false)
                {
                    Detected = true;
                    Light.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
            

        }
        else
        {
            
            if (Detected == true)
            {
                Detected = false;

                Light.GetComponent<SpriteRenderer>().color = Color.green;
            }

        }


        if (Detected)
        {
            shooter.transform.up = Direction;

            if (Time.time > shootDuration)
            {
                shootDuration = Time.time + 1 / FireRate;
                shoot();
            }


        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
    private void shoot()
    {
       GameObject BulletIns =  Instantiate(bullet,shootPoint.position,Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction*force);
        SoundManager.PlaySound("fire");
    }

}
