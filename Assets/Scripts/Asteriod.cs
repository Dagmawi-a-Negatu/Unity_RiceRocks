using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Asteriod Class
/// </summary>

public class Asteriod : MonoBehaviour
{
    // needed for spawning
    [SerializeField]
    GameObject prefabRock;

    // saved for efficiency
    [SerializeField]
    Sprite greenRockSprite;
    [SerializeField]
    Sprite magentaRockSprite;
    [SerializeField]
    Sprite whiteRockSprite;

    //public void initialize(Dircetion) Move code under start method here
    //{

    //}



    // Start is called before the first frame update
    void Start()
    {

        //Randomly choose one of three sprites
        SpriteRenderer spriteRenderer = prefabRock.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            spriteRenderer.sprite = greenRockSprite;
        }
        else if (spriteNumber == 1)
        {
            spriteRenderer.sprite = magentaRockSprite;
        }
        else
        {
            spriteRenderer.sprite = whiteRockSprite;
        }

        //Move rock with random direction and impulse force
        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 2f;
        float angle = Random.Range(205, 345) * Mathf.Deg2Rad; //Random.Range(135,225) * Mathf.PI;
        Vector2 moveDirection = new Vector2( Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        Rigidbody2D AsteriodPhysicsComponent = prefabRock.GetComponent<Rigidbody2D>();
        AsteriodPhysicsComponent.AddForce(moveDirection*magnitude, ForceMode2D.Impulse);

        
       
    }

}
