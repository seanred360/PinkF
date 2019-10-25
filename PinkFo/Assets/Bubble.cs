using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    public Sprite[] bubbles;
    public Sprite[] words;
    public GameObject popParticle;
    public Image wordObject;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        GetComponent<Image>().sprite = bubbles[Random.Range(0, bubbles.Length)];
        wordObject.sprite = words[Random.Range(0, words.Length)];
    }

    private void Update()
    {
        transform.position = transform.position + new Vector3(0,3 * Time.deltaTime, 0);
    }

    public void PopBubble()
    {
        audioManager.PlayMusic(Random.Range(0, 2));
        audioManager.PlaySFX(0);
        Instantiate(popParticle,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
