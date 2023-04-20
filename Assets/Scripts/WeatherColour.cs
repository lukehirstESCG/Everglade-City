using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherColour : MonoBehaviour
{
    public ParticleSystem Rain;
    public Color rainyAmbientColor;
    public Color clearAmbientColor;

    private void Update()
    {
        if (Rain.isPlaying)
        {
            RenderSettings.ambientLight = rainyAmbientColor;
        }
        else
        {
            RenderSettings.ambientLight = clearAmbientColor;
        }
    }
}
