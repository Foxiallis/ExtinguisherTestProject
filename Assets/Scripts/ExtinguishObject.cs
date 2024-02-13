using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguishObject : MonoBehaviour
{
    public ParticleSystem flameParticles;
    public float maxFlameLevel = 300f;
    public float currentFlameLevel;
    [Tooltip("How much level does a flame gain per second if not extinguished")]
    public float flamePower = 50f;
    [HideInInspector]
    public bool isBurning;

    private void Awake()
    {
        isBurning = true;
    }

    private void Update()
    {
        if (!isBurning) return;

        SetBurningLevel();
    }

    private void SetBurningLevel()
    {
        if (ExtinguisherManager.instance.extinguishing)
        {
            currentFlameLevel = Mathf.Clamp(currentFlameLevel - (flamePower * Time.deltaTime), 0, maxFlameLevel);
        }
        else
        {
            currentFlameLevel = Mathf.Clamp(currentFlameLevel + (flamePower * Time.deltaTime), 0, maxFlameLevel);
        }

        if (currentFlameLevel <= 0)
        {
            isBurning = false;
        }

        SetEmissionPower();
    }

    private void SetEmissionPower()
    {
        ParticleSystem.EmissionModule em = flameParticles.emission;
        em.rateOverTime = Mathf.RoundToInt(currentFlameLevel);
    }
}
