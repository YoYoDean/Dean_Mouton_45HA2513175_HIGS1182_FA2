using System.Collections;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio instance;
    public bool isPlaying = false;
    public AudioClip shoot, pickup, demonDie, playerDie, demonAttack, demonAttack2 , demonPatrol, ghostBreath;
    public AudioSource audioSource, audioDemon;

    void Awake()
    {
        instance = this;
    }


    public void PlayShoot()
    {
        if(shoot && audioSource)
        {
            audioSource.PlayOneShot(shoot);
        }
    }

    public void PlayPickup()
    {
        if(pickup && audioSource)
        {
            audioSource.PlayOneShot(pickup);
        }
    }

    public void PlayDemonDie()
    {
        if(demonDie && audioSource)
        {
            audioSource.PlayOneShot(demonDie);
        }
    }

    public void PlayPlayerDie()
    {
        if(playerDie && audioSource)
        {
            audioSource.PlayOneShot(playerDie);
        }
    }

    public void PlayDemonAttack()
    {
        //int i = Random.Range(0 , 2);
        
        if(demonAttack && audioDemon && isPlaying == false)
        {
            isPlaying = true;
            audioDemon.PlayOneShot(demonAttack);
            StartCoroutine(IsPlayingSound());
        }
        /*else if(i == 1 && demonAttack2 && audioDemon)
        {
           audioDemon.PlayOneShot(demonAttack2); 
        }*/
    }
    IEnumerator IsPlayingSound()
    {
        yield return new WaitForSeconds(6f);
        isPlaying = false;
    }

    public void PlayDemonPatrol()
    {
        if(demonPatrol && audioSource)
        {
            audioSource.PlayOneShot(demonPatrol);
        }
    }

    public void PlayGhostBreath()
    {
        if(ghostBreath && audioSource)
        {
            audioSource.PlayOneShot(ghostBreath);
        }
    }
    
}
