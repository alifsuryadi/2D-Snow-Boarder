using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishDetector : MonoBehaviour
{
    [SerializeField] float delayLoadScene = 1f;

    //Akses particle effect dari object lain
    [SerializeField] ParticleSystem finishEffect;

    AudioSource finishAudio;

    private PlayerController playerController;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            GameObject.FindObjectOfType<PlayerController>().StopMove();

            //Matikan sound background
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Stop();

            finishEffect.Play();

            GetComponent<AudioSource>().Play();

            Invoke("ReloadScene", delayLoadScene);
            
        }
        
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
