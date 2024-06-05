using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Ship Class 
/// </summary>


public class Ship : MonoBehaviour
{
    //field delcration
    float rotateDegreesPerSecond = 15;
    float thrustForce = 10; 
    
    //Intitalizing objects
    Vector3 currentEulerAngles;
    Vector2 thrustDirection = new Vector2(1, 0);
    Rigidbody2D shipPhysicsComponent;


    // Start is called before the first frame update
    void Start()
    {
        shipPhysicsComponent = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Updating ship position and euler angles
        currentEulerAngles = transform.eulerAngles;
    }
    
    //FixedUpdated is called for physics related functionality
    void FixedUpdate()
    {
        //Applying thrust
        if (Input.GetAxis("Thrust")!= 0)
        {
            shipPhysicsComponent.AddForce(thrustForce * thrustDirection, ForceMode2D.Force);

        }
        
        //Code for degree turning properties and aligning thrust direction
        float rotationAmount = rotateDegreesPerSecond * Time.deltaTime;
        float rotationInput = Input.GetAxis("Rotate");
        
        if (rotationInput > 0)
        {
            rotationAmount *= -1;
            transform.Rotate(Vector3.forward, rotationAmount);
        }

        if(rotationInput < 0)
        {
            transform.Rotate(Vector3.forward, rotationAmount);
        }

        thrustDirection.x = Mathf.Cos(currentEulerAngles.z * Mathf.Deg2Rad);
        thrustDirection.y = Mathf.Sin(currentEulerAngles.z * Mathf.Deg2Rad);

    }

}   
   
