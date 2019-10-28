using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    public int foodNumber;
    //FoodPicker foodPicker;
    public Vector3 startPos;
    public bool isEaten;
    Eater eater;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(gameObject.name);
        //foodPicker = GameObject.FindObjectOfType<FoodPicker>();
        eater = FindObjectOfType<Eater>().GetComponent<Eater>();
    }

    void Update()
    {
        if (isEaten) gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        eater.selectedItem = this.transform;
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }

    private void OnMouseUp()
    {
        
    }
}
