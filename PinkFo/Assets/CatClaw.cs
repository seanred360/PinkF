using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatClaw : MonoBehaviour
{
    bool positive;
    
    // Update is called once per frame
    void Update()
    {
        if(positive == false)
        {
            float wiggle = Random.Range(-.2f,-.1f);
            transform.Translate(new Vector3(wiggle, 0, 0) * Time.deltaTime, Space.Self);
            positive = true;
        }

        if (positive == true)
        {
            float wiggle = Random.Range(.1f, .2f);
            transform.Translate(new Vector3(wiggle, 0, 0) * Time.deltaTime, Space.Self);
            positive = false;
        }

    }
}
