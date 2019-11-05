using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Pump : MonoBehaviour
{
    int pumpNumber;
    bool canMove;
    AudioManager audioManager;
    Rigidbody2D rb;
    Vector3 originalPOS, originalScale;
    Quaternion originalRotation;
    public Transform canvas, spawnPoint, balloon, balloonPrefab;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        rb = balloon.GetComponent<Rigidbody2D>();
        originalPOS = spawnPoint.position;
        originalRotation = spawnPoint.rotation;
        originalScale = spawnPoint.localScale;
        balloon = Instantiate(balloonPrefab, originalPOS, originalRotation);
        balloon.SetParent(canvas);
        balloon.localScale = originalScale;
    }

    private void Update()
    {
        if (canMove)
        {
            balloon.GetComponent<Rigidbody2D>().AddRelativeForce(transform.up * 20);
        }
    }

    public void PumpBalloon()
    {
        if(pumpNumber == 5)
        {
            balloon.DOScale(balloon.localScale - new Vector3(100, 100, 100), 10f).OnComplete(DestroyBalloon);
            balloon.GetComponent<Rigidbody2D>().isKinematic = false;
            balloon.GetComponent<Rigidbody2D>().AddTorque(50f);
            canMove = true;
            audioManager.PlaySFX(2);
        }
        else
        {
            audioManager.PlaySFX(0);
            balloon.DOScale(balloon.localScale + new Vector3(20, 20, 20), 1f);
            pumpNumber += 1;
        }
    }

    void DestroyBalloon()
    {
        StartCoroutine(DestroyBalloonRoutine());
    }

    IEnumerator DestroyBalloonRoutine()
    {
        pumpNumber = 0;
        canMove = false;
        audioManager.PlaySFX(1);
        Destroy(balloon.gameObject);
        yield return new WaitForSeconds(2f);
        audioManager.PlaySFX(0);
        Transform clone = Instantiate(balloonPrefab, originalPOS, originalRotation);
        clone.SetParent(canvas);
        clone.localScale = originalScale;
        balloon = clone;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
