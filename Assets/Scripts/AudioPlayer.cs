using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShotType { basicLaser, aiShip, bossLaser }

public class AudioPlayer : MonoBehaviour
{
    Player player;

    [Header("Shooting")]
    [SerializeField] AudioClip basicShootingClip;
    [SerializeField] AudioClip enemyShootingClip;
    [SerializeField] AudioClip bossShootingClip;
    [SerializeField][Range(0f, 1f)] private float shootVolume = 1f;

    [Header("Exploding")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField] AudioClip damagedClip;
    [SerializeField] AudioClip enemyDamagedClip;
    [SerializeField][Range(0f, 1f)] private float hitVolume = 1f;



    public void PlayShootingClip(ShotType shooter)
    {
        switch(shooter)
        {
            case ShotType.basicLaser:
                {
                    if (basicShootingClip != null)
                    {
                        AudioSource.PlayClipAtPoint(basicShootingClip, gameObject.transform.position, shootVolume);
                    }
                    break;
                }

            case ShotType.aiShip:
                {
                    if (enemyShootingClip != null)
                    {
                        AudioSource.PlayClipAtPoint(enemyShootingClip, gameObject.transform.position, shootVolume);
                    }
                    break;
                }

            case ShotType.bossLaser:
                {
                    if (bossShootingClip != null)
                    {
                        AudioSource.PlayClipAtPoint(bossShootingClip, gameObject.transform.position, shootVolume);
                    }
                    break;
                }

            default:
                break;
        }
        
    }

    //public void PlayDamageClip(ShotType shooter)
    //{
    //    if(shooter == ShotType.aiShip || shooter == ShotType.bossLaser)
    //    {
    //        if (damagedClip != null)
    //        {
    //            AudioSource.PlayClipAtPoint(damagedClip, gameObject.transform.position, hitVolume);
    //        }
    //    }
    //    else
    //    { 
    //        if (enemyDamagedClip != null)
    //        {
    //            AudioSource.PlayClipAtPoint(enemyDamagedClip, gameObject.transform.position, hitVolume);
    //        }
    //    }

    //}

    public void PlayDamageClip()
    {
        PlayClip(damagedClip, hitVolume);
    }


    public void PlayExplosionClip()
    {
        PlayClip(explosionClip, hitVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (explosionClip != null)
        {
            AudioSource.PlayClipAtPoint(clip, gameObject.transform.position, volume);
        }
    }
}
