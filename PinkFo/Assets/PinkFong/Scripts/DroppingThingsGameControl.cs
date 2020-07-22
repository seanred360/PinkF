using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DroppingThingsGameControl : MonoBehaviour
{
    public GameObject[] prefabs;
    GameObject randomPrefab;
    public Transform canvas;
    GameObject clone;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            randomPrefab = prefabs[Random.Range(0, prefabs.Length)];
            Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            clone = Instantiate(randomPrefab, new Vector3(p.x, p.y, 0.0f), Quaternion.identity);
            clone.transform.SetParent(canvas);
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
