using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float paddingLeft, paddingRight, paddingTop, paddingBottom;

    Health health;
    Shooter shooter;

    Vector2 minBounds;
    Vector2 maxBounds;

   void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        InitBounds();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void InitBounds()
    {
        Camera mainCamera = Camera.main; //Looks for the main camera in the program hierarchy as only one camera can be the main camera
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1)); //sets bounds the player can move in, relative to the camera position |. '|
    }

    private void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime; //calculates how far to move player due to input
        Vector2 newPos = new Vector2();

        //MathF.Clamp(current position (delta + newpos), min allowable pos, max allowable pos)
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y =  Mathf.Clamp(transform.position.y + delta.y, minBounds.y+paddingBottom, maxBounds.y-paddingTop); 
        //this should clamp the movement to the coords of the bottom left screen (minBounds x , y) and the top right of screen (maxBounds x , y)

        transform.position = newPos; //moves player
    }

    //This allows us to get the raw input value from the input system. so that we can register when a player has pressed a direction control.
    private void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>(); 
        //we use an independent variable for modularity. This allows us to reference the move value in other places in this script, such as in the Update method
        Debug.Log(rawInput); //debugging
    }

    private void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
    
        
    

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Shot")
        {
            DamageDealer dmgDealer = coll.gameObject.GetComponent<DamageDealer>();
            health.HurtUnit(dmgDealer.GetDamage());
            if(coll.gameObject.tag == "Shot")
            {
                dmgDealer.KillProjectile();
            }
        }
    }
}
