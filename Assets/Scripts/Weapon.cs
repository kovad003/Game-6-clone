using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AUTHOR: @Nuutti J.
/// Last modified: 30 Nov 2022 by @Nuutti J.
/// </summary>

public class Weapon : MonoBehaviour {

    /* EXPOSED FIELDS: */
    [SerializeField] float _damage = 1f;
    [SerializeField] float _rateOfFire = 1f;
    [SerializeField] Projectile _projectile;
    [SerializeField] GameObject _muzzle;

    /* HIDDEN FIELDS: */
    Transform _weaponPivot;

    // Start is called before the first frame update
    void Start() {
        _weaponPivot = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    void Shoot() {
        Quaternion rotation = _weaponPivot.transform.rotation;
        GameObject projectile = Instantiate(_projectile.gameObject, _muzzle.transform.position, rotation);
    }
}
