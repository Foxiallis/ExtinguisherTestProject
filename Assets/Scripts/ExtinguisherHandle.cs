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
            animator.SetBool(valueName, false);
            manager.handlePressed = false;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool(valueName, true);
            manager.handlePressed = true;
        }
    }
}
