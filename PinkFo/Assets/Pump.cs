using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pump : MonoBehaviour
{
    public Transform balloon;
    int pumpNumber;
    AudioManager audioManager;
    bool canMove;
    Rigidbody2D rb;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        rb = balloon.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canMove)
        {
            balloon.GetComponent<Rigidbody2D>().AddRelativeForce(transform.up * 10);
        }
            
    }

    public void PumpBalloon()
    {
        if(pumpNumber == 10)
        {
            balloon.DOScale(balloon.localScale - new Vector3(250, 250, 250), 5f);
            balloon.GetComponent<Rigidbody2D>().isKinematic = false;
            balloon.GetComponent<Rigidbody2D>().AddTorque(50f);
            canMove = true;
            //balloon.GetComponent<Rigidbody2D>().AddForce(new Vector2(50f, 0f));
            //Destroy(balloon.gameObject);
            audioManager.PlaySFX(1);
        }
        else
        {
            audioManager.PlaySFX(0);
            balloon.DOScale(balloon.localScale + new Vector3(25, 25, 25), 1f);
            pumpNumber += 1;
        }
    }
}
