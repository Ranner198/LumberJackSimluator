using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaveText : MonoBehaviour {

    public float Timer;

    private Text WaveNumberText;
    private float _timer;
    public static bool ShowWave = false;
    public SpawnerController spawner;
    
    void Start()
    {
        WaveNumberText = GetComponent<Text>();
        WaveNumberText.enabled = false;
    }

    void Update()
    {
        WaveNumberText.text = "Wave: " + spawner.wave;
        if (ShowWave)
        {
            if (_timer >= 0)
            {
                _timer -= Time.deltaTime;
                WaveNumberText.enabled = true;
            }
            if (_timer < 0)
            {
                WaveNumberText.enabled = false;
                ShowWave = false;
                _timer = Timer;
            }
        }
    }
}
