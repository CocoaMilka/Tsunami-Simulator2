using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioSource src,src2;
    public AudioClip sfx1,sfx2;
    public RisingWater water;
    public GameObject underwaterFilter;

    public RectTransform healthMeter;
    public RectTransform oxygenMeter;

    float health = 1f; // Now in percentage (0 to 1)
    float oxygen = 1f; // Now in percentage (0 to 1)

    private const float MaxMeterWidth = 800f; // Max length of the meter
    private bool UnderWaterSound = false;

    // Start is called before the first frame update
    void Start()
    {
        src.clip = sfx1;
        src.loop = true;
        src.Play();
        underwaterFilter.SetActive(false);
    }

    // FixedUpdate is used for consistent updates
    void FixedUpdate()
    {

        if (water.transform.position.y > gameObject.transform.position.y)
        {
            underwaterFilter.SetActive(true);
            DecreaseOxygen();
            if (UnderWaterSound == false){
                src.volume = 0.15f;
                src2.clip = sfx2;
                src2.loop = true;
                src2.Play();
                UnderWaterSound = true;
            }
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
