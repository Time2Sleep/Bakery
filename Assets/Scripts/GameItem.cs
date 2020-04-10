using UnityEngine;

public class GameItem : MonoBehaviour
{
    private bool isMouseOver = false;
    void OnMouseOver()
    {
        if (!isMouseOver)
        {
            isMouseOver = true;
            transform.localScale *= 1.1f;
        }
    }

    void OnMouseExit()
    {
        isMouseOver = false;
        transform.localScale /= 1.1f;
    }
}