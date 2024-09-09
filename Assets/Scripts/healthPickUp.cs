using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickUp : MonoBehaviour
{
    public float healthAmount;
    public AudioClip pickupSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerHealth theHealth = other.gameObject.GetComponent<playerHealth>();
            theHealth.addHealth(healthAmount);
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            Destroy(gameObject);
        }
    }
}
