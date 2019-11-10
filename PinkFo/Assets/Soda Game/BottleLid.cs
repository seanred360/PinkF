using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleLid : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
