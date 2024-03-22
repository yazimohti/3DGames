using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    // PARAMATERS - for tunning
    
    // CACHE - e.g. references for readability or speed

    // STATE - private instance (member) variables
    [SerializeField] float mainThrust=100;
    [SerializeField] float rotateSpeed=10;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem leftThrustPart;
    [SerializeField] ParticleSystem rightThrustPart;
    [SerializeField] ParticleSystem boosterPart;
    Rigidbody rb;
    AudioSource au;
    bool isAlive;
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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else
        {
            StopRotateLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotateRight();
        }
    }
    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!au.isPlaying)
        {
            au.PlayOneShot(mainEngine);
        }
        if (!boosterPart.isPlaying)
        {
            boosterPart.Play();
        }
    }
    void StopThrusting()
    {
        au.Stop();
        boosterPart.Stop();
    }

    void RotateLeft()
    {
        Debug.Log("Rotating left");
        ApplyRotation(rotateSpeed);
        if (!leftThrustPart.isPlaying)
        {
            leftThrustPart.Play();
        }
    }

    void RotateRight()
    {
        Debug.Log("Rotating right");
        ApplyRotation(-rotateSpeed);
        if (!rightThrustPart.isPlaying)
        {
            rightThrustPart.Play();
        }
    }
    void StopRotateLeft()
    {
        leftThrustPart.Stop();
    }
    void StopRotateRight()
    {
        rightThrustPart.Stop();
    }
    void ApplyRotation(float rotateSpeed)
    {
        rb.freezeRotation=true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime );
        rb.freezeRotation=false; // unfreezing rotation so the physics system can take over
    }
}
