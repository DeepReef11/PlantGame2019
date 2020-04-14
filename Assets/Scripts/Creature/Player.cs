using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Player : CreatureBase
{
    //Rigidbody2D rb2d;

    [ConditionalField("ShowStats")]
    public float InputDeadZone = .4f;

    protected override void Awake()
    {
        base.Awake();
        
        //rb2d = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = "Player";
        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    public override void UpdateNormal()
    {
        base.UpdateNormal();
        PlayerInputMovement();
        
    }

    public override void UpdateFixed()
    {
        base.UpdateFixed();
        PlayerInputAction();
    }

    void PlayerInputMovement()
    {
        float x = Mathf.Abs(Input.GetAxis("Horizontal")) > InputDeadZone ? Input.GetAxis("Horizontal") : 0f;
        float y = Mathf.Abs(Input.GetAxis("Vertical")) > InputDeadZone ? Input.GetAxis("Vertical") : 0f;
        _direction = new Vector2(x,y);
        _direction.Normalize();
    }

    RaycastHit2D hit;
    Transform land;

    void PlayerInputAction()
    {
        //Todo: Replace with proper controller
        
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            hit = Physics2D.Raycast(transform.position, -Vector2.up, .1f, layerMask:LayerMask.GetMask("Player"));
            land = hit.transform;
            if(land !=null)
            {
                GameObject plant = land.gameObject.CreateChildren("Plant");
                //plant.AddComponent<PlantBase>().Seed();
                Debug.Log("Planted on " + land.name);
            }
            
        }
        if (Input.GetKey(KeyCode.Space))
        {

        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            land = null;
        }
        
    }

    
}
