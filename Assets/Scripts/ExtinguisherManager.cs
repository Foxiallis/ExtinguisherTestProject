using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguisherManager : MonoBehaviour
{
    public HoseController hoseController;
    public bool handlePressed;

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
