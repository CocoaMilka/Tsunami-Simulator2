using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public RisingWater water;
    public GameObject underwaterFilter;

    public RectTransform healthMeter;
    public RectTransform oxygenMeter;

    public int health;
    public int oxygen;

    // Start is called before the first frame update
    void Start()
    {
        underwaterFilter.SetActive(false);

        health = 800;
        oxygen = 800;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (water.transform.position.y > gameObject.transform.position.y)
        {
            underwaterFilter.SetActive(true);

            // decrease oxygen then update UI
            oxygen--;
            oxygenMeter.sizeDelta = new Vector2(oxygen, oxygenMeter.sizeDelta.y);

        }
        else
        {
            // Increase oxygen until max
            if (oxygen < 800) 
            { 
                oxygen++; 
                oxygenMeter.sizeDelta = new Vector2(oxygen, oxygenMeter.sizeDelta.y);
            }

            underwaterFilter.SetActive(false);
        }
    }

    void UpdateMeters()
    {

    }
}
