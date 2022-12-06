using UnityEngine;

/// <summary>
/// AUTHOR: @Nuutti J.
/// Last modified: 01 Dec 2022 by @Daniel K.
/// </summary>

public class CustomCursor : MonoBehaviour {

    /* EXPOSED FIELDS: */
    [SerializeField] Texture2D aimingReticle;

    void Start()
    {
        ConfineMouse();
        SetCustomCursor();
    }

    public static void SetDefaultCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    
    private void SetCustomCursor()
    {
        Vector2 hotspot = new Vector2(aimingReticle.width / 2, aimingReticle.height / 2);
        Cursor.SetCursor(aimingReticle, hotspot, CursorMode.Auto);
    }

    //Added by Daniel K. - 01122022
    private void ConfineMouse()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
