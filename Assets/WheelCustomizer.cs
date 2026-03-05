using UnityEngine;

public class WheelCustomizer : MonoBehaviour
{
    public Renderer[] wheels;

    public Material sportWheel;
    public Material luxuryWheel;
    public Material minimalWheel;

    void ApplyWheel(Material m)
    {
        foreach (Renderer r in wheels)
        {
            r.material = m;
        }
    }

    public void SportyWheels()
    {
        ApplyWheel(sportWheel);
    }

    public void LuxuryWheels()
    {
        ApplyWheel(luxuryWheel);
    }

    public void MinimalWheels()
    {
        ApplyWheel(minimalWheel);
    }
}