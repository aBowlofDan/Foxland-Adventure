using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerHealth : MonoBehaviour
{
    public float fullHealth;
    public GameObject deathFX;

    public restartGame theGameManager;

    float currentHealth;

    playerController controlMovement;

    //Audio Variables
    public AudioClip playerHurt;
    AudioSource playerAS;

    //HUD Variables
    public Slider healthSlider;
    public Image damageScreen;
    public TextMeshProUGUI gameOverScreen;
    public TextMeshProUGUI youWinScreen;

    bool damaged = false;
    Color damagedColour = new Color(0f, 0f, 0f, 0.75f);
    float smoothColour  = 5f;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
        controlMovement = GetComponent<playerController>();

        //HUD Initialisation
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        playerAS = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(damaged)
        {
            damageScreen.color = damagedColour;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColour*Time.deltaTime);
        }
        damaged = false;
        
    }

    public void addDamage(float damage)
    {
        if(damage <= 0)
        {
            return;
        }
        currentHealth -= damage;

        playerAS.clip = playerHurt;
        playerAS.Play();
        
        healthSlider.value = currentHealth;

        damaged = true;

        if(currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if(currentHealth > fullHealth)
        {
            currentHealth = fullHealth;
        }
        healthSlider.value = currentHealth;
    }

    public void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        Animator gameOverAnimator = gameOverScreen.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("gameOver");
        theGameManager.restartTheGame();
    }

    public void winGame()
    {
        Destroy(gameObject);
        Animator youWinAnimator = youWinScreen.GetComponent<Animator>();
        youWinAnimator.SetTrigger("gameOver");
        theGameManager.restartTheGame();


    }
}
