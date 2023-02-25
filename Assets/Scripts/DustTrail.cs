using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{  
    [SerializeField] ParticleSystem dustEffects;
    [SerializeField] AudioSource skiAudio;

    public bool disableSki = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" && !disableSki) //Ketika player menyetuh tanah
        {

            dustEffects.Play();

            skiAudio.pitch = Random.Range(2f, 3f);
            skiAudio.Play();

            
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground") //Ketika player tidak menyetuh tanah
        {
            dustEffects.Stop();

            skiAudio.Stop();
        }
          
    }
}
