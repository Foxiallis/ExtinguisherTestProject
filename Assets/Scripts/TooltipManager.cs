using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Tooltip
{
    public TMP_Text text;
    public string key;
}

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager instance;

    public List<Tooltip> tooltips;

    public void SetTooltip(string key)
    {
        foreach (Tooltip tooltip in tooltips)
        {
            if (tooltip.key == key)
            {
                tooltip.text.color = new Color(1, 1, 1, 1);
            }
            else
            {
                tooltip.text.color = new Color(1, 1, 1, 0);
            }
        }
    }

    private void Awake()
    {
        instance = this;

        SetTooltip("seal");
    }
}
