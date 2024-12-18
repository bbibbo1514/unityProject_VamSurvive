using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward.normalized * Time.deltaTime * speed;        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            speed = 0;            
        }        
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            transform.position -= transform.forward * Time.deltaTime;
        }
    }
}
