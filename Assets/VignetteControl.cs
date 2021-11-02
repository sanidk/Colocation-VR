using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class VignetteControl : MonoBehaviour
{
    //public PostProcessVolume volume;
    public float vignetteIntensity;
    public float vignetteFalloff = 0.01f;
    public Volume volume;
    Vignette vignette;
    //UnityEngine.Rendering.Volume volume; 
    // Start is called before the first frame update


    private void Start()
    {
        volume.profile.TryGet<Vignette>(out vignette);


        //volume.profile.TryGetSettings(out _Vignette);
        //volume.profile.TryGet(out _Vignette);
        //_Vignette.intensity.value = 0;
    }

    private void FixedUpdate()
    {
        
        //vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
        if (vignetteIntensity > 1)
        {
            vignetteIntensity = 1;
        }

        if (vignetteIntensity > 0)
        {
            vignetteIntensity -= vignetteFalloff;
            vignette.intensity.value = vignetteIntensity;
        }
        


    }

}
