using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text healthText;
    Player player;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        player = FindObjectOfType<Player>();
        slider = FindObjectOfType<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
        //healthText.text = player.GetHealth().ToString();
        //CalculateHealthColor();
    }

    public void UpdateHealthBar()
    {
        slider.value = player.GetHealth();
    }

    void CalculateHealthColor()
    {
        int healthValue = player.GetHealth();
        if (healthValue <= 100)
            // Red
            healthText.color = new Color32(255, 0, 0, 150);
        else if (healthValue <= 300)
            // Yellow
            healthText.color = new Color32(255, 255, 0, 150);
        else
            // Green
            healthText.color = new Color32(0, 255, 0, 150);
    }
}
