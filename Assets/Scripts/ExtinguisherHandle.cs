using UnityEngine;

public class ExtinguisherHandle : MonoBehaviour
{
    public ExtinguisherManager manager;
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
        if (Input.GetMouseButtonDown(0))
        {
            SetHandleStatus(true);
        }
    }

    private void SetHandleStatus(bool pressed)
    {
        animator.SetBool(valueName, pressed);
        manager.PressHandle(pressed);
    }
}
