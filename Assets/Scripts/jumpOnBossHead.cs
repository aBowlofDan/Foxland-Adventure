using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class jumpOnBossHead : MonoBehaviour
{
    public float springForce; 
    public float springForceRight;
    public AudioClip bossHurtSound;
    public float playerDamage;
    public float bossMaxHealth;
    public GameObject bossDeathFX;
    public AudioClip bossDeathSound;
    public Slider bossHealthSlider;
    public GameObject boss;
    public GameObject player;


    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = bossMaxHealth;
        bossHealthSlider.maxValue = bossMaxHealth;
        bossHealthSlider.value = bossMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            addDamage(playerDamage);
            pushBack(other.transform);
            AudioSource.PlayClipAtPoint(bossHurtSound, transform.position);
        }
    }

    public void addDamage(float damage)
    {
        if(damage <= 0)
        {
            return;
        }

        currentHealth -= damage;
        bossHealthSlider.value = currentHealth;

        if(currentHealth <= 0)
        {
            makeDead();
        }
    }

    void makeDead()
    {
        Destroy(boss);
        AudioSource.PlayClipAtPoint(bossDeathSound, transform.position);
        Instantiate(bossDeathFX, transform.position, transform.rotation);
        playerHealth playerWin = player.gameObject.GetComponent<playerHealth>();
        playerWin.winGame();
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection*=springForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
        //StartCoroutine(waitSeconds());
        // Vector2 pushDirectionRight = new Vector2(1000, 0);
        // pushRB.AddForce(pushDirectionRight, ForceMode2D.Impulse);

    }

    IEnumerator waitSeconds()
    {
        yield return new WaitForSeconds(0.1f);

    }
}
