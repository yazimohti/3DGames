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

    void CrushSequence()
    {

    }
    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);   
            if(!au.isPlaying)
            {
                au.PlayOneShot(mainEngine);
            }   
            if (!boosterPart.isPlaying)
            {
                boosterPart.Play();
            }
        }
        else
        {
            au.Stop();
            boosterPart.Stop();
        }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Rotating left");
            ApplyRotation(rotateSpeed);
            if (!leftThrustPart.isPlaying)
            {
                leftThrustPart.Play();
            }
        }
        else
        {
            leftThrustPart.Stop();
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotating right");
            ApplyRotation(-rotateSpeed);
            if (!rightThrustPart.isPlaying)
            {
                rightThrustPart.Play();
            }
        }
        else
        {
            rightThrustPart.Stop();
        }
    }

    private void ApplyRotation(float rotateSpeed)
    {
        rb.freezeRotation=true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime );
        rb.freezeRotation=false; // unfreezing rotation so the physics system can take over
    }
}
