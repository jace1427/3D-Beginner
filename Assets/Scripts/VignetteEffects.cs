using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class VignetteEffects : MonoBehaviour
{
    Vignette vignette = null;
    public bool pulsate = true;
    void Start()
    {
        PostProcessVolume volume = GetComponent<PostProcessVolume>();
        volume.sharedProfile.TryGetSettings<Vignette>(out vignette);
        vignette.intensity.value = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {

        float maxSpeed = 0.1f;
        float minSpeed = 0.2f;
        float alpha = 0.0f;
        float interpolatedSpeed = (1.0f - alpha) * minSpeed + alpha * maxSpeed;
        if (vignette.intensity.value > 0.8f) {
            pulsate = false;
        }
        else if (vignette.intensity.value < 0.2f) {
            pulsate = true;
        }
        if (pulsate == true && vignette.intensity.value < 0.8f) {
            vignette.intensity.value += interpolatedSpeed * Time.deltaTime;
        } else if (pulsate == false && vignette.intensity.value > 0.2f) {
            vignette.intensity.value -= interpolatedSpeed * Time.deltaTime;
        }
    }
}
