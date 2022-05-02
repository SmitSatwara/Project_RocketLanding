using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    public float mainThrust=1000f;
    public float rotateSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerThrust();
        PlayerRotation();
    }

    void PlayerThrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
        }
    }

    void PlayerRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
           ApplyRotation(-rotateSpeed);
        }
    }
    private void ApplyRotation(float rotationFrame)
    {
        rb.freezeRotation = true;//freeze other physics system rotation
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationFrame);//apply our own rotation
        rb.freezeRotation = false;//unfreeze the other physics system
    }
}
