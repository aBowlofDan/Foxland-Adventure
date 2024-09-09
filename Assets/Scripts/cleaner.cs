using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleaner : MonoBehaviour
{

    public AudioClip playerDeathSound;
    AudioSource playerDeathAS;


    // Start is called before the first frame update
    void Start()
    {
        playerDeathAS = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerDeathAS.clip = playerDeathSound;
            playerDeathAS.Play();
            playerHealth playerFell = other.GetComponent<playerHealth>();
            playerFell.makeDead();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
