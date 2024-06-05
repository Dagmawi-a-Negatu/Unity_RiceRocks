using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Scrren Wrapper Class
/// </summary>

public class screenwrapper : MonoBehaviour
{
    //Field decleration
    float shipRadius;
    float asteriodRadius;

    //Intialziation
    Vector2 shipPosition = new Vector2(0, 0);
    Vector2 asteriodPosition = new Vector2(0, 0);
    Rigidbody2D shipPhysicsComponent;
    Rigidbody2D asteriodPhysicsComponent;

    //Serilazing and poupluating asteriod game object on inspector
    [SerializeField]
    GameObject asteriodObject;
    [SerializeField]
    GameObject shipObject;

   
    // Start is called before the first frame update
    void Start()
    {
        //Accesing radius
        asteriodRadius = asteriodObject.GetComponent<CircleCollider2D>().radius;
        shipRadius = shipObject.GetComponent<CircleCollider2D>().radius;

        //Accesing physics component
        shipPhysicsComponent = shipObject.GetComponent<Rigidbody2D>();
        asteriodPhysicsComponent = asteriodObject.GetComponent<Rigidbody2D>();
    }

    //Uupdate is called once per frame rate
    void Update()
    {
        //Update position
        shipPosition = shipPhysicsComponent.position;
        asteriodPosition = asteriodPhysicsComponent.position;
    }

    //Method used for wraping funcitonality
    void OnBecameInvisible()
    {
        //Check if ship left screen and update accordingly
        if (shipPosition.x > ScreenUtils.ScreenRight)
        {
            shipPosition.x = ScreenUtils.ScreenLeft;
        }
        if (shipPosition.x < ScreenUtils.ScreenLeft)
        {
            shipPosition.x = ScreenUtils.ScreenRight;
        }
        if (shipPosition.y > ScreenUtils.ScreenTop)
        {
            shipPosition.y = ScreenUtils.ScreenBottom;
        }
        if (shipPosition.y < ScreenUtils.ScreenBottom)
        {
            shipPosition.y = ScreenUtils.ScreenTop;
        }


        //Check if asteriod left screen and update accoridngly
        if (asteriodPosition.x > ScreenUtils.ScreenRight)
        {
            asteriodPosition.x = ScreenUtils.ScreenLeft;
        }
        if (asteriodPosition.x < ScreenUtils.ScreenLeft)
        {
            shipPosition.x = ScreenUtils.ScreenRight;
        }
        if (asteriodPosition.y > ScreenUtils.ScreenTop)
        {
            asteriodPosition.y = ScreenUtils.ScreenBottom;
        }
        if (asteriodPosition.y < ScreenUtils.ScreenBottom)
        {
            asteriodPosition.y = ScreenUtils.ScreenTop;
        }

        //Update asteriod and ship position
        shipPhysicsComponent.position = shipPosition;
        asteriodPhysicsComponent.position = asteriodPosition;

    }

    

}

