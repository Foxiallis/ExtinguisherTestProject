using UnityEngine;

public class AnimatorActivator : MonoBehaviour
{
    public Animator animator;
    public string valueName;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger(valueName);
        }
    }
}
