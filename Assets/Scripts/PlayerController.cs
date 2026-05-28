using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 15f;

    [SerializeField]
    float angularSpeed = 2f;

    float rotationX;

    Rigidbody2D rb;

    public int count = 0;
    public GameObject explosionFX;
    public GameObject endpanel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        endpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rotationX = CrossPlatformInputManager.GetAxis("Horizontal");
        transform.Rotate(0, 0, rotationX * angularSpeed);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = transform.up * moveSpeed;
        Destroy(GameObject.FindGameObjectWithTag("explosion"), 2.0f);//clearing the explosion
        Destroy(GameObject.FindGameObjectWithTag("coin"), 6.0f);//clearing the coins
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "coin")
        {
            Destroy(collision.gameObject);
            ScoreManager.score += 5;
        }

        if(collision.tag == "enemy" || collision.tag == "missile")
        {
            //Destroy(gameObject);
            count += 1;
        }

        if(count == 2)
        {
            Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(gameObject);
            endpanel.SetActive(true);
        }
    }


}
