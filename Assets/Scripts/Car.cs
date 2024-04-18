using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 20;
    private float turnSpeed = 150;
    private float horizontalInput;
    private float forwardInput;
    public string inputID; 
    public float thrust = 1.0f;
    public Rigidbody rb;
    private float normalStrength = 200;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 0, thrust, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        //moves car forward based on vertical input  
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Rotates the car based on horizontal input
        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);

        
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            Rigidbody Player2Rigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer =  other.gameObject.transform.position - transform.position; 
            Player2Rigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);

        }
        else if (other.gameObject.CompareTag("Player1"))
        {
            Rigidbody Player1Rigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer =  other.gameObject.transform.position - transform.position; 
            Player1Rigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);

        }

    
    }
}
