using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust=100;
    [SerializeField] float rotateSpeed=10;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);   
        }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Rotating left");
            ApplyRotation(rotateSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotating right");
            ApplyRotation(-rotateSpeed);
        }
    }

    private void ApplyRotation(float rotateSpeed)
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime );
    }
}
