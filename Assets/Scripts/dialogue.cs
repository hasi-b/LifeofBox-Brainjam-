using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogue : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private string[] sentences;
    private int index;

    [SerializeField] private float typingSpeed;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enter;
     private PlayerMovement pl;
    private float flag = 0;




    IEnumerator Type()
    {

        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            Debug.Log(flag);

        }
        
        yield return new WaitForSeconds(1f);
        enter.SetActive(true);
        flag = 1;


    }
    IEnumerator wait()
    {

        yield return new WaitForSeconds(5f);
        pl.enabled = true;


    }


    public void NextSentence()
    {
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());

        }
        else
        {
            textDisplay.text = "";
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        pl = player.GetComponent<PlayerMovement>();
        StartCoroutine(Type());
        
       // StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            SoundManager.PlaySound("pop");

            textDisplay.text = "";
            pl.enabled = true;
            enter.SetActive(false);
            flag = 0;
        }
    }
}
