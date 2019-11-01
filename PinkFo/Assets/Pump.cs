using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pump : MonoBehaviour
{
    public Transform balloon;
    int pumpNumber;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void PumpBalloon()
    {
        if(pumpNumber == 10)
        {
            Destroy(balloon.gameObject);
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
