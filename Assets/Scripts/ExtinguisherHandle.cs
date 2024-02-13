using UnityEngine;

public class ExtinguisherHandle : MonoBehaviour
{
    public Animator animator;
    public string valueName;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SetHandleStatus(false);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && ExtinguisherManager.instance.ready)
        {
            SetHandleStatus(true);
        }
    }

    private void SetHandleStatus(bool pressed)
    {
        animator.SetBool(valueName, pressed);
        ExtinguisherManager.instance.OnPressHandle(pressed);
    }
}
