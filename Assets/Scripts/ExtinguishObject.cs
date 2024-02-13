using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtinguishObject : MonoBehaviour
{
    public ParticleSystem flameParticles;
    public float maxFlameLevel = 300f;
    public float currentFlameLevel;
    [Tooltip("On what height does the extinguisher need to be to fully extinguish this object")]
    public float targetExtinguisherHeight;
    public float targetHeightBuffer;

    [Tooltip("How much level does a flame gain per second if not extinguished")]
    public float flamePower = 50f;

    [HideInInspector]
    public bool isBurning;

    private FillBehaviour fillBehaviour;

    private bool ExtinguisherWithinRange => ExtinguisherManager.instance.transform.position.y > targetExtinguisherHeight - targetHeightBuffer && ExtinguisherManager.instance.transform.position.y < targetExtinguisherHeight + targetHeightBuffer;

    private void Awake()
    {
        isBurning = true;
        fillBehaviour = GetComponent<FillBehaviour>();
    }

    private void Update()
    {
        if (!isBurning) return;

        SetBurningLevel();
    }

    private void SetBurningLevel()
    {
        if (ExtinguisherManager.instance.extinguishing && ExtinguisherWithinRange)
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
        fillBehaviour.SetImageFill(currentFlameLevel, maxFlameLevel);
    }

    private void SetEmissionPower()
    {
        ParticleSystem.EmissionModule em = flameParticles.emission;
        em.rateOverTime = Mathf.RoundToInt(currentFlameLevel);
    }
}
