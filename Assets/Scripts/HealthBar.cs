using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public Slider healthSliderPrefab;
    private Canvas Canvas;
    public Color startColor, finishColor;
    public float heightOffset = 16;

    public float Size = 1;

    private Slider HealthSlider;
    private Image fillColor;

    private int healthReference;

    void Start() 
    {
        Canvas = GetComponent<Canvas>();
        HealthSlider = Instantiate(healthSliderPrefab, transform);
        HealthSlider.value = 100f;
        Vector3 scale = HealthSlider.transform.localScale;
        scale *= Size;
        HealthSlider.transform.localScale = scale;
        HealthSlider.transform.parent = Canvas.transform;
        fillColor = HealthSlider.transform.GetChild(1).GetChild(0).GetComponent<Image>();
    }

    public void SetHealth(int val)
    {
        this.healthReference = val;
    }
    public int GetHealth() {
        return this.healthReference;
    }

    void Update()
    {
        HealthSlider.transform.LookAt(2 * Camera.main.transform.position);

        fillColor.color = Color.Lerp(startColor, finishColor, HealthSlider.value / HealthSlider.maxValue);

        HealthSlider.transform.position = new Vector3(transform.position.x, transform.position.y + heightOffset, transform.position.z);
        HealthSlider.value = healthReference;
    }

}
