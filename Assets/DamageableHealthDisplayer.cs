using UnityEngine;
using UnityEngine.UI;


public class DamageableHealthDisplayer : MonoBehaviour
{

    public Damageable Damageable;
    public Text HealthText;

    public UnityEngine.UI.Slider HealthSlider;

    public void Update()
    {
        if(HealthText)
        {
            HealthText.text = Damageable.Health.ToString("000");
        }
        if(HealthSlider)
        {
            HealthSlider.value = Damageable.Health;
        }
    }

}