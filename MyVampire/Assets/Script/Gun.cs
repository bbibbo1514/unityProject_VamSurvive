using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform gunExit;
    public Camera cam;
    public GameObject target;
    public LineRenderer lR;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }
        lR.SetPosition(0, transform.position);
        lR.SetPosition(1, target.transform.position);
    }
    // Update is called once per frame
    void Shot()
    {
        Vector3 shootDirection = target.transform.position - transform.position;
        Quaternion shootRotation = Quaternion.LookRotation(shootDirection.normalized);
        GameObject bullets = Instantiate(bullet, gunExit.position + shootDirection.normalized * 0.2f, shootRotation);
    }
}
