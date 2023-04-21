using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    public GameObject[] Rain;

    public Color RainyColour;
    public Color ClearColour;

    private int particleRandom;

    private float chanceOfRain = 0.5f;
    private float RainLength;
    private bool isRaining;

    private float dice;

    private float timer = 0f;

    private void Update()
    {
        Raining();
        NotRaining();
    }

    private void Raining(int particleRandom)
    {
        Rain[particleRandom].SetActive(true);
    }

    private void StopRaining(int particleRandom)
    {
        Rain[particleRandom].SetActive(false);
    }

    private void Raining()
    {
        // Not raining
        if (!isRaining)
        {
            dice = Random.Range(0f, 100f);

            // Raining
            if (dice < chanceOfRain)
            {
                particleRandom = Random.Range(0, Rain.Length);
                Raining(particleRandom);
                isRaining = true;
                timer = Random.Range(5f, 20f);
                RenderSettings.ambientSkyColor = RainyColour;
            }
        }
    }

    private void NotRaining()
    {
        // Is it already raining?
        if (isRaining)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                // Stop raining
                isRaining = false;
                StopRaining(particleRandom);
                RenderSettings.ambientSkyColor = ClearColour;
            }
        }
    }
}