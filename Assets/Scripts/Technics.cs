using UnityEngine;

public class Technics : MonoBehaviour
{
    protected Animator _animation;
    protected bool isOpen = false;

    private void Start()
    {
        _animation = GetComponent<Animator>();
    }

    public void playAnimation()
    {
        if (isOpen)
        {
            isOpen = false;
            _animation.Play("Close");
        }
        else
        {
            isOpen = true;
            _animation.Play("Open");
        }
    }

    public virtual void interact(GameItem pickedObject)
    {
        playAnimation();
    }
}