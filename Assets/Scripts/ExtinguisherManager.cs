using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguisherManager : MonoBehaviour
{
    public HoseController hoseController;
    public bool handlePressed;
    public float maximumFoamCapacity = 10f;
    public float currentFoamCapacity = 10f;

    public bool extinguishing => handlePressed && currentFoamCapacity > 0;

    public AudioClip unsealClip;
    public AudioClip readyClip;
    public AudioClip extinguishClip;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PressHandle(bool pressed)
    {
        handlePressed = pressed;

        if (extinguishing)
        {
            PlaySound(extinguishClip);
        }
        else
        {
            source.Stop();
        }
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

    public void PlayReadySound()
    {
        PlaySound(readyClip);
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
