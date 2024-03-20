using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust=100;
    [SerializeField] float rotateSpeed=10;
    Rigidbody rb;
    AudioSource au;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        au= GetComponent<AudioSource>();
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
            if(!au.isPlaying)
            {
                au.Play();
            }   
        }
        else
        {
            au.Stop();
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
        rb.freezeRotation=true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime );
        rb.freezeRotation=false; // unfreezing rotation so the physics system can take over
    }
}
