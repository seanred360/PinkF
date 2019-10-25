using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    public Sprite[] bubbles;
    public Sprite[] words;
    public Image wordObject;

    private void Start()
    {
        GetComponent<Image>().sprite = bubbles[Random.Range(0, bubbles.Length)];
        wordObject.sprite = words[Random.Range(0, words.Length)];
    }
}
