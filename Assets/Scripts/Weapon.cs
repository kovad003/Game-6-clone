using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AUTHOR: @Nuutti J.
/// Last modified: 1 Dec. 2022 by @Nuutti J.
/// </summary>

public class Weapon : MonoBehaviour {

    /* EXPOSED FIELDS: */
    [Header("Weapon properties")]

    [Tooltip("How long does it take to shoot another projectile")]
    [SerializeField] float _rateOfFire = 0.33f;

    [Header("Weapon objects")]
    [Tooltip("What does the weapon shoot")]
    [SerializeField] Projectile _projectile;
    
    [Tooltip("The instantiation point of the projectile")]
    [SerializeField] Transform _muzzle;

    /* HIDDEN FIELDS: */
    float nextFire;

    /* HIDDEN FIELDS: */
    Transform _weaponPivot;

    // Start is called before the first frame update
    void Start() {
        _weaponPivot = GetComponentInParent<Transform>();
    }

    /* FUNCTIONS */
    public void Shoot() {
        // Shoot if the time of the latest shot has passed the fire rate
        if(Time.time > nextFire) {
            nextFire = Time.time + _rateOfFire;

            Quaternion rotation = _weaponPivot.transform.rotation;
            GameObject projectile = Instantiate(_projectile.gameObject, _muzzle.position, rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            rb.AddForce(_muzzle.right * _projectile._speed, ForceMode2D.Impulse);
        }
        
    }
}
