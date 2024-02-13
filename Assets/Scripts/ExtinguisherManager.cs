using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguisherManager : MonoBehaviour
{
    public static ExtinguisherManager instance;

    public HoseController hoseController;
    [HideInInspector]
    public bool ready;
    public bool handlePressed;
    public float maximumFoamCapacity = 10f;
    public float currentFoamCapacity = 10f;

    public bool extinguishing => handlePressed && currentFoamCapacity > 0;

    public AudioClip unsealClip;
    public AudioClip readyClip;
    public AudioClip extinguishClip;

    public ParticleSystem particles;

    private AudioSource source;
   
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        instance = this;
    }

    private void Update()
    {
        if (!extinguishing) return;

        float newCurrentFoamCapacity = Mathf.Clamp(currentFoamCapacity - Time.deltaTime, 0f, 10f);
        if (currentFoamCapacity > 0 && newCurrentFoamCapacity <= 0)
        {
            currentFoamCapacity = newCurrentFoamCapacity;
            ChangeExtinguishState();
        }
        else
        {
            currentFoamCapacity = newCurrentFoamCapacity; //duplicated from above because of checking the variable in if
        }
    }

    public void OnPressHandle(bool pressed)
    {
        handlePressed = pressed;

        ChangeExtinguishState();
    }

    private void ChangeExtinguishState()
    {
        SetEmission(extinguishing);

        if (extinguishing)
        {
            PlaySound(extinguishClip);
        }
        else
        {
            source.Stop();
        }
    }

    private void SetEmission(bool enabled)
    {
        ParticleSystem.EmissionModule em = particles.emission;
        em.enabled = enabled;
    }

    private void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    //Functions for the animator
    public void PlayUnsealSound()
    {
        PlaySound(unsealClip);
    }

    public void Ready()
    {
        PlaySound(readyClip);

        ready = true;
    }

    public void SetChangeHoseGravity()
    {
        StartCoroutine(ChangeHoseGravity());
    }

    IEnumerator ChangeHoseGravity()
    {
        float elapsedTime = 0;
        float animationDuration = 0.67f;
        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            hoseController.gravity = Mathf.Lerp(-0.3f, 0.2f, Mathf.Clamp01(elapsedTime / animationDuration));
            yield return null;
        }
    }
}
