using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomBounce : MonoBehaviour
{
    public float springForce; 
    public AudioClip bounceSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            pushBack(other.transform);
            AudioSource.PlayClipAtPoint(bounceSound, transform.position);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2((pushedObject.position.x - transform.position.x), (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection*=springForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
