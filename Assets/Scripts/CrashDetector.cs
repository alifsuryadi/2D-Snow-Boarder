using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayLoadScene = 0.5f;

    //Akses particle effect dari object lain
    [SerializeField] ParticleSystem crashEffects;
    [SerializeField] AudioClip audioClip;

    bool alreadyCrash = false;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" && !alreadyCrash)
        {
            FindObjectOfType<PlayerController>().StopMove();

            //Matikan audio background dan ski
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Stop();
            GetComponent<DustTrail>().disableSki = true;

            crashEffects.Play();

            GetComponent<AudioSource>().PlayOneShot(audioClip);

            Invoke("Restart", delayLoadScene);

            alreadyCrash = true;
        }    
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
