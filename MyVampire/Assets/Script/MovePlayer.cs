using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public GameObject bullet;
    public Transform orientation;

    public Transform camera;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public TextMeshProUGUI tmpText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }
    }
    private void FixedUpdate()
    {
        PlayerMove();
        Monitoring();
        
    }
    private void PlayerMove()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        Vector3 PlayerVec = new Vector3(transform.position.x, 0, transform.position.z);
        if (PlayerVec.magnitude > 80)
        {
            Vector3 VecPlus = PlayerVec + rb.velocity;
            rb.velocity = PlayerVec.magnitude > VecPlus.magnitude ? rb.velocity : new Vector3(-rb.velocity.x, rb.velocity.y, -rb.velocity.z);
            rb.AddForce(-PlayerVec.normalized * 2, ForceMode.Impulse);
        }
        if (rb.velocity.magnitude > moveSpeed)
        {
            rb.velocity = rb.velocity.normalized * moveSpeed;
        }
    }
    private void Monitoring()
    {
        float velocityFloat = rb.velocity.magnitude;
        tmpText.text = velocityFloat.ToString("F1");
    }
    void Shot()
    {
        Vector3 shootDirection = camera.transform.forward;
        Quaternion shootRotation = Quaternion.LookRotation(shootDirection.normalized);
        Instantiate(bullet,transform.position,shootRotation);
    }
}
