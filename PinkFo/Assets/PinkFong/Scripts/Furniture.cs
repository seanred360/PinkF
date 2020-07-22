using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    bool canPlaySFX = true;
    private Explodable _explodable;
    int health = 3;

    void Start()
    {
        _explodable = GetComponent<Explodable>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Balloon")
        {
            health -= 1;
            GetComponent<Rigidbody2D>().isKinematic = false;
            if (GetComponent<AudioSource>() && canPlaySFX)
            {
                GetComponent<AudioSource>().Play();
                canPlaySFX = false;
            }

            if(health <= 0 && GetComponent<Explodable>())
            {
                _explodable.explode();
                ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
                ef.doExplosion(transform.position);

            }
        }
    }
}
