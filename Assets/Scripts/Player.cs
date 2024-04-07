using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public RisingWater water;
    public GameObject underwaterFilter;

    // Start is called before the first frame update
    void Start()
    {
        underwaterFilter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (water.transform.position.y > gameObject.transform.position.y)
        {
            underwaterFilter.SetActive(true);
        }
        else
        {
            underwaterFilter.SetActive(false);
        }
    }
}
