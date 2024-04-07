using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public RisingWater water;
    public GameObject underwaterFilter;

    public RectTransform healthMeter;
    public RectTransform oxygenMeter;

    public float health = 1f; // Now in percentage (0 to 1)
    public float oxygen = 1f; // Now in percentage (0 to 1)

    private const float MaxMeterWidth = 800f; // Max length of the meter

    // Start is called before the first frame update
    void Start()
    {
        underwaterFilter.SetActive(false);
    }

    // FixedUpdate is used for consistent updates
    void FixedUpdate()
    {
        if (water.transform.position.y > gameObject.transform.position.y)
        {
            underwaterFilter.SetActive(true);
            DecreaseOxygen();
        }
        else
        {
            underwaterFilter.SetActive(false);
            IncreaseOxygen();
        }

        UpdateMeters();
    }

    void DecreaseOxygen()
    {
        // Decrease oxygen then update UI
        if (oxygen > 0)
        {
            oxygen -= Time.fixedDeltaTime / 10; // 10 seconds to deplete oxygen
        }
        else if (health > 0) // If oxygen is depleted, start decreasing health
        {
            health -= Time.fixedDeltaTime / 20; // Health decreases half as fast as oxygen
        }
    }

    void IncreaseOxygen()
    {
        // Increase oxygen until max and oxygen is not full
        if (oxygen < 1f)
        {
            oxygen += Time.fixedDeltaTime / 30; // Replenish oxygen faster than it depletes
            oxygen = Mathf.Min(oxygen, 1f); // Ensure oxygen does not exceed 100%
        }
    }

    void UpdateMeters()
    {
        oxygenMeter.sizeDelta = new Vector2(oxygen * MaxMeterWidth, oxygenMeter.sizeDelta.y);
        healthMeter.sizeDelta = new Vector2(health * MaxMeterWidth, healthMeter.sizeDelta.y);
    }
}
