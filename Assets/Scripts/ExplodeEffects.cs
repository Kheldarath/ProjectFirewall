using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeEffects : MonoBehaviour
{
    [SerializeField] ParticleSystem ShieldedHit;
    [SerializeField] ParticleSystem DeathHit;

    ParticleSystem instance;
    AudioPlayer audioPlayer;

    void Awake()
    {
      audioPlayer = FindObjectOfType<AudioPlayer>(); 
    }

    public void PlayHitEffect(bool killer)
    {
        if (!killer)
        {
            instance = Instantiate(ShieldedHit, transform.position, Quaternion.identity);
            audioPlayer.PlayDamageClip();
        }
        else
        {
            instance = Instantiate(DeathHit, transform.position, Quaternion.identity);
            audioPlayer.PlayExplosionClip();
        }

        Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
    }

    //public void PlayHitEffect(bool killer)
    //{
    //    ParticleSystem prefab = ShieldedHit;  //assigns the default prefab as shield hit
    //    audioPlayer.PlayDamageClip();

    //    if (killer) //Checks call
    //    {
    //        prefab = DeathHit; //If it is a kill it, then it changes the prefab to death hit
    //        audioPlayer.PlayExplosionClip();

    //    }
    //    Instantiate(prefab, transform.position, Quaternion.identity); //otherwise it simply plays the shield hit
        
    //}


}
