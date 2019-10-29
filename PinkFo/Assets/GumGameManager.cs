using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GumGameManager : MonoBehaviour
{
    public GameObject endScreen;
    FoodPicker foodPicker;
    public List<Food> m_food;
    public AudioManager endSounds;
    bool canPlayEndSounds = true;

    bool m_isGameOver = false;
    public bool IsGameOver { get { return m_isGameOver; } set { m_isGameOver = value; } }

    private void Start()
    {
        m_food = (Object.FindObjectsOfType<Food>() as Food[]).ToList();
    }

    private void Update()
    {
        if(AreAllFoodsEaten() && canPlayEndSounds)
        {
            canPlayEndSounds = false;
            endScreen.SetActive(true);
            endSounds.PlayMusic(0);
            endSounds.PlaySFX(Random.Range(0, 2));
        }
    }

    bool AreAllFoodsEaten()
    {
        foreach (Food food in m_food)
        {
            if (!food.isEaten)
            {
                return false;
            }
        }
        Debug.Log("all food eaten");
        return true;
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
