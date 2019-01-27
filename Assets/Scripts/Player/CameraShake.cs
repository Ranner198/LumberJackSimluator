using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance = null;

    // How long the object should shake for.
    public float shakeDuration = 0f;
    private float shakeTime;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float amout = 0.1f;
    private float shakeAmount;
    public float decreaseFactor = 1.0f;

    public static bool shake = false;

    Vector3 originalPos;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        shakeTime = shakeDuration;
        shakeAmount = amout;
    }

    void Update()
    {
        if (shake)
        {
            if (shakeTime >= 0)
            {
                transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
                shakeTime -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeAmount = amout;
                shakeTime = shakeDuration;
                shakeTime = shakeDuration;
                transform.localPosition = originalPos;
                shake = false;
            }
        }
    }

    public void Shake() {
        shake = true;
    }

    public void Shake(float amt)
    {
        shake = true;
        this.shakeAmount = amt;
    }

    public void Shake(float amt, float time)
    {
        shake = true;
        this.shakeAmount = amt;
        this.shakeTime = time;
    }
}

