using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AUTHOR: @Nuutti J.
/// Last modified: 30 Nov 2022 by @Nuutti J.
/// </summary>

public class CustomCursor : MonoBehaviour {

    /* EXPOSED FIELDS: */
    [SerializeField] Texture2D aimingReticle;

    // Start is called before the first frame update
    void Start() {
        //Cursor.visible = false;
        Vector2 hotspot = new Vector2(aimingReticle.width / 2, aimingReticle.height / 2);
        Cursor.SetCursor(aimingReticle, hotspot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
