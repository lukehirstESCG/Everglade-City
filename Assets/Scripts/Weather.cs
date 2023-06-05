using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    public GameObject[] Rain;

    private int particleRandom;

    private float chanceOfRain = 0.25f;
    private bool isRaining;

    private float dice;

    private float timer = 0f;

    private void Start()
    {
        isRaining = false;
        Rain[particleRandom].SetActive(false);
    }

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
                timer = Random.Range(5f, 120f);
                FindObjectOfType<AudioManager>().Play("Rain");
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
                FindObjectOfType<AudioManager>().Stop("Rain");
            }
        }
    }
}