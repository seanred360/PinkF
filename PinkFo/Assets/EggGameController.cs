using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EggGameController : MonoBehaviour
{

    public Transform[] Eggs;
    public Transform[] EggWords;
    public Transform[] nests;
    int wordIndex;

    public List<GameObject> cracks;
    public GameObject crackedEgg;
    int crackNum;
    public AudioManager audioManager;

    private void Start()
    {
        cracks.AddRange(Eggs[wordIndex].GetComponent<Egg>().cracks);    
    }

    public void MoveEggWord()
    {
        StartCoroutine(MoveEggWordRoutine());
    }

    public IEnumerator MoveEggWordRoutine()
    {
        EggWords[wordIndex].gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        EggWords[wordIndex].GetComponent<Animator>().enabled = false;
        EggWords[wordIndex].DOMove(nests[wordIndex].position, 1f);
        EggWords[wordIndex].DOScale(19f, 1f);
        wordIndex += 1;
        yield return new WaitForSeconds(1f);
        Eggs[wordIndex].DOMove(Vector3.zero, 1f);
        Eggs[wordIndex].DOScale(1f, 1f);
    }

    public void CrackEgg()
    {
        foreach (GameObject crack in cracks)
        {
            crack.SetActive(false);
        }

        if (crackNum >= cracks.Count)
        {
            crackedEgg.SetActive(true);
            audioManager.PlayMusic(wordIndex);
            MoveEggWord();
            Eggs[wordIndex].gameObject.SetActive(false);
            crackNum = 0;
            cracks.Clear();
            cracks.AddRange(Eggs[wordIndex + 1].GetComponent<Egg>().cracks);
        }
        else
        {
            cracks[crackNum].SetActive(true);
            crackNum += 1;
            audioManager.PlaySFX(Random.Range(0, 2));
            audioManager.PlaySFX(4);
        }
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
