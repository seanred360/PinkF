using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhonicsLettersController : MonoBehaviour
{
    public List<GameObject> umbrellas;
    public AudioManager audioManager;
    bool canPlaySFX = true;
    public GameObject touchParticle;
    public GameObject letters;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        umbrellas.AddRange(GameObject.FindGameObjectsWithTag("Umbrella"));
    }

    private void Update()
    {
        if(umbrellas.Count <=  0 && canPlaySFX)
        {
            audioManager.PlaySFX(1);
            GameObject.Find("Big Letter").GetComponent<Image>().color = new Color(0f,.72f,1f,1f);
            GameObject.Find("Small Letter").GetComponent<Image>().color = new Color(0f, .72f, 1f, 1f);
            letters.GetComponent<Animator>().Play("LetterDance");
            canPlaySFX = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            Instantiate(touchParticle, new Vector3(p.x, p.y, 0.0f), Quaternion.identity);

        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
