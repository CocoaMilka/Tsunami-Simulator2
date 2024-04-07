using UnityEngine;

public class RisingWater : MonoBehaviour
{
    // Water position
    public float waterHeight = -2.0f;

    // How fast the water rises
    public float waterSpeed = 0.001f;

    bool isRising = true;

    // Continually called at a fixed interval (infinite loop)
    void FixedUpdate()
    {
        if (isRising)
        {
            // Update water height
            waterHeight += waterSpeed;

            // Move water up to new waterHeight
            // Grab the transform (x, y, z) of the gameobject this script is attached to
            // Update the transform to the new water level
            gameObject.transform.position = new Vector3(0, waterHeight, 0);
        }
    }

    public void StopWaterRising()
    {
        isRising = false;
    }

    public void StartWaterRising()
    {
        isRising = true;
    }

    public void ToggleWaterRising()
    {
        isRising = !isRising;
    }

    public void ResetWaterHeight()
    {
        waterHeight = -1f;
    }
}