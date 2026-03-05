using UnityEngine;

public class CarColorChanger : MonoBehaviour
{
    private Renderer[] renderers;

    void Awake()
    {
        // Find all renderers inside the car model
        renderers = GetComponentsInChildren<Renderer>();
    }

    void ApplyColor(Color c)
    {
        foreach (var r in renderers)
        {
            // Optional: skip glass/windows if needed by name
            if (r.gameObject.name.ToLower().Contains("glass")) continue;

            r.material.color = c;
        }
    }

    public void SetRed()   => ApplyColor(Color.red);
    public void SetBlue()  => ApplyColor(Color.blue);
    public void SetWhite() => ApplyColor(Color.white);
    public void SetBlack() => ApplyColor(Color.black);
}