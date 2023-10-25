using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelCompleted = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("triggered");
            finishSound.Play();
            //levelCompleted = true;
            //Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {

    }
}
