using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soda : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    AudioManager audioManager;
    Rigidbody2D rb;
    float shakeLevel;
    bool canPlaySFX = true;
    bool canLookAt;
    public GameObject sprayParticle;
    public GameObject sodaLid;
    public GameObject monster;
    public Sprite fullBottle;
    public Transform spraySpawn;
    public Transform target;

    Vector3 delta = Vector3.zero;
    Vector3 lastPos = Vector3.zero;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            delta = Input.mousePosition - lastPos;
            Debug.Log("delta distance : " + delta.magnitude);
            lastPos = Input.mousePosition;
        }

        if(canLookAt)
        {
            float angle = 0;

            Vector3 relative = transform.InverseTransformPoint(target.position);
            angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
            transform.Rotate(0, 0, -angle);
        }
    }

    void OnMouseDown()
    {
        //audioManager.PlayMusic(0);
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        //SpraySoda();
        rb.isKinematic = true;
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        rb.MovePosition(cursorPosition);
        if (delta.magnitude > 30)
        {
            shakeLevel += 1;
            if(shakeLevel > 10) { SpraySoda(); }
        }
    }

    void SpraySoda()
    {
        StartCoroutine(SpawnSprayParticles());
        GetComponent<SpriteRenderer>().sprite = fullBottle;
        monster.GetComponent<Animator>().Play("MonsterDrink");
        if (canPlaySFX)
        {
            canPlaySFX = false;
             canLookAt = true;
            sodaLid.transform.SetParent(null);
            sodaLid.GetComponent<Rigidbody2D>().isKinematic = false;
            Debug.Log("Spraying soda");
            audioManager.PlayMusic(0);
            audioManager.PlayMusic(1);
            audioManager.PlaySFX(0);
            StartCoroutine(PlayGurgleSound());
        }
    }

    IEnumerator SpawnSprayParticles()
    {
        yield return new WaitForSeconds(.3f);
        GameObject clone = Instantiate(sprayParticle, spraySpawn.position,spraySpawn.rotation);
        clone.transform.rotation = spraySpawn.rotation;
        clone.transform.SetParent(transform);
        StartCoroutine(SpawnSprayParticles());
    }

    IEnumerator PlayGurgleSound()
    {
        yield return new WaitForSeconds(1.3f);
        audioManager.PlaySFX(1);
        StartCoroutine(PlayGurgleSound());
    }

    private void OnMouseUp()
    {
        //audioManager.PlayMusic(1);
        rb.isKinematic = false;
    }
}
