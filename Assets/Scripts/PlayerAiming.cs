using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AUTHOR: @Nuutti J.
/// </summary>

public class PlayerAiming : MonoBehaviour {

    /* EXPOSED FIELDS: */
    [SerializeField] GameObject weaponPivot;
    [SerializeField] SpriteRenderer playerRenderer;
    [SerializeField] SpriteRenderer weaponRenderer;

    /* HIDDEN FIELDS */


    void Start() {

    }

    void Update() {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Direction between the cursor position and the weapons pivot point
        Vector2 rotateDir = (mouseWorldPos - weaponPivot.transform.position).normalized;

        // Change the weapon pivots right direction (red axis, x) to face the rotation direction
        weaponPivot.transform.right = rotateDir;

        Vector2 weaponScale = weaponPivot.transform.localScale;

        // Hide the weapon if it is rotated "above" the players head
        if (weaponPivot.transform.eulerAngles.z >= 75 && weaponPivot.transform.eulerAngles.z <= 105) {
            Debug.Log("In the restricted zone");
            weaponRenderer.sortingOrder = playerRenderer.sortingOrder - 1;
        } else {
            weaponRenderer.sortingOrder = playerRenderer.sortingOrder + 1;
        }

        // Flip the player and the gun depending on the side the cursor is on
        if (mouseWorldPos.x < transform.position.x) {
            transform.localScale = new Vector3(-1, 1, 1);
            weaponScale.x = -1;
            weaponPivot.transform.localScale = weaponScale;
        } else if(mouseWorldPos.x > transform.position.x) {
            transform.localScale = new Vector3(1, 1, 1);
            weaponScale.x = 1;
            weaponPivot.transform.localScale = weaponScale;
        }

    }
}
