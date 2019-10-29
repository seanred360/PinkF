using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eater : MonoBehaviour
{
    FoodPicker foodPicker;
    int foodNumber;
    public Transform selectedItem;


    void Start()
    {
        foodPicker = GameObject.FindObjectOfType<FoodPicker>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        foodNumber = collision.gameObject.GetComponent<Food>().foodNumber;
        foodPicker.CheckAnswer(foodNumber);
    }
}
