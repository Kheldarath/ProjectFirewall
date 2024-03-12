using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Generics")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float aliveTime = 5f;
    [SerializeField] float fireSpeed = 0.5f;
    [SerializeField] float spawnAngle = 0f;
    

    [Header("AI")]
    [SerializeField] bool useAI;    
    [SerializeField] float shotTimeVariance = 0.5f;
    [SerializeField] float minShotTime = 0.1f;

    [HideInInspector] public bool isFiring;

    AudioPlayer audioPlayer;

    ShotType ship;

    Coroutine firingCoroutine;
    float timeBetweenShots = 0.1f;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        GetEnumValue();
    }

    void Start()
    {
        if(useAI) 
        {
            isFiring = true; 
            
        }
    }

    
    void Update()
    {
        Fire();
    }

    

    /// <summary>
    /// Takes in the fire action and runs the coroutine to instantiate the object. 
    /// we need to check there is not a firing corutine already running as well else problems are caused.
    /// after fire is realeased, nullifies the coroutine.
    /// </summary>
    void Fire()
    {
        
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null) 
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    /// <summary>
    /// This should instantiate projectiles as required, it loops indefinately as we will be starting and
    /// stopping the coroutine in the fire method.
    /// </summary>
    /// <returns></returns>
    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, spawnAngle)); //instantiate object
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>(); //get RigidBody of shot

            if (rb != null)
            {                
                rb.velocity = transform.up * projectileSpeed; //applies velocity to the rigid body of the shot
            }

            audioPlayer.PlayShootingClip(ship); //play sound

            Destroy(instance, aliveTime); //destroy shot

            timeBetweenShots = GetRandomSpawnTime(); //queue up next shot

            yield return new WaitForSeconds(timeBetweenShots); //wait for time then shoot next shot

        }

    }

    void GetEnumValue()
    {
        if(gameObject.tag is "Player")
        {
            ship = ShotType.basicLaser;
        }
        else if(gameObject.tag is "Enemy")
        {
            ship = ShotType.aiShip;
        }
        else if(gameObject.tag is "Boss")
        {
            ship = ShotType.bossLaser;
        }
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(fireSpeed - shotTimeVariance, fireSpeed + shotTimeVariance);
        return Mathf.Clamp(spawnTime, minShotTime, float.MaxValue);
    }
}
