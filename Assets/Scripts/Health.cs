using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    [SerializeField] private float startingHealth;
    [SerializeField] private Transform spawn;
    [SerializeField] private GameObject deadbody;
    [SerializeField] private GameObject restart;
    public float currentHealth { get; private set; }

    [SerializeField] private float invunerabilityTime;
    [SerializeField] private int flashNumb;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = startingHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage,0,startingHealth);
        if (currentHealth > 0)
        {
            StartCoroutine(Invunerability());
            Instantiate(deadbody, transform.position, Quaternion.identity);
          
           // transform.position = spawn.position;
        }
        else
        {
            SoundManager.PlaySound("lost");
            restart.SetActive(true);
            this.gameObject.SetActive(false);
            

        }
    }


    public void AddHealth(float _health)
    {
        currentHealth = Mathf.Clamp(currentHealth + _health, 0, startingHealth);
    }




    private IEnumerator Invunerability()
    {

        SoundManager.PlaySound("hurt");
        Physics2D.IgnoreLayerCollision(7,8,true);
        for (int i = 0;  i < flashNumb; i++){
            spriteRend.color = new Color(1,0,0,0.5f);
            yield return new WaitForSeconds(invunerabilityTime/(flashNumb*2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(invunerabilityTime / (flashNumb * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);

    }






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
