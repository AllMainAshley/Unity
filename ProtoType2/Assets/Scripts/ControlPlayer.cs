using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 10.0f;
    public float verticalInput;
    public float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput= Input.GetAxis("Vertical");
        verticalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed * verticalInput);
    }
}
