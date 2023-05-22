using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public bool hideCursorInScene = false;

    private void Start()
    {
        if (hideCursorInScene)
        {
            HideCursor();
        }
        else
        {
            ShowCursor();
        }
    }

    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}