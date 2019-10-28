using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumGameManager : MonoBehaviour
{
    FoodPicker foodPicker;
    List<Food> m_food;
    // have we met the game over condition?
    bool m_isGameOver = false;
    public bool IsGameOver { get { return m_isGameOver; } set { m_isGameOver = value; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
