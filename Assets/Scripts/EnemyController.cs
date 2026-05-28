using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject targetOb;
    public Transform target;
    private Rigidbody2D rb;

    public float speed = 0.2f;
    public float rotateSpeed = 80f;

    public int count = 0;

   // public GameObject explosionFX;
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
        if (collision.tag == "missile")
        {
            //Destroy(gameObject);
            count += 1;
        }

        if(count == 2)
        {
            Destroy(gameObject);
        }
    }


}
