using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    public GameObject targetOb;
    public Transform target;
    private Rigidbody2D rb;

    public float speed = 3f;
    public float rotateSpeed = 200f;

    //public static int countHit = 0;
   

    public GameObject explosionFX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetOb = GameObject.FindGameObjectWithTag("player");
        target = targetOb.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.linearVelocity = transform.up * speed;
    }

    
   

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "player" || collision.tag == "enemy" || collision.tag == "missile")
        {
            Instantiate(explosionFX, transform.position, transform.rotation);//this is for the missile hit
            Destroy(gameObject);
            //countHit += 1;
        }
        /*if(countHit == 2 && collision.tag == "player" || collision.tag == "enemy")//this will destroy the ob after 2 hits
        {
            Instantiate(explosionFX, transform.position, transform.rotation);
            //Destroy(collision.gameObject);
            Destroy(gameObject);
        }*/
        
        Debug.Log("Collision");
    }
}
