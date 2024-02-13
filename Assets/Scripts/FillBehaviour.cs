using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBehaviour : MonoBehaviour
{
    public Image fillImage;

    public void SetImageFill(float current, float max)
    {
        fillImage.fillAmount = current / max;
    }
}
