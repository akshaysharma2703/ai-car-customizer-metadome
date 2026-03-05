using UnityEngine;
using TMPro;

public class AIRecommendation : MonoBehaviour
{
    public CarColorChanger car;
    public TMP_Text feedbackText;

    public void Sporty()
    {
        car.SetRed();
        feedbackText.text = "Sporty configuration applied";
    }

    public void Luxury()
    {
        car.SetBlack();
        feedbackText.text = "Luxury configuration applied";
    }

    public void Minimal()
    {
        car.SetWhite();
        feedbackText.text = "Minimal configuration applied";
    }
}