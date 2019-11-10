using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public List<Color> colors;
    public SpriteRenderer rend;

    private void Awake()
    {
        colors.Add(Color.red);
        colors.Add(Color.yellow);
        colors.Add(Color.blue);
        colors.Add(Color.green);
        colors.Add(Color.magenta);
        colors.Add(Color.cyan);
        rend.color = colors[Random.Range(0,colors.Count)];    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioManager>().PlaySFX(Random.Range(0,3));
    }
}
