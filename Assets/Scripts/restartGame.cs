using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour
{
    public float restartTime;
    bool restartNow = false;
    float resetTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(restartNow == true && resetTime <= Time.time)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    public void restartTheGame()
    {
        restartNow = true;
        resetTime = Time.time + restartTime;
    }
}
