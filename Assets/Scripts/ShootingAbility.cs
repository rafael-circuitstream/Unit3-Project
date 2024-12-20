using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAbility : MonoBehaviour
{
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Rigidbody projectilePrefab;
    [SerializeField] private float shootingForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        Rigidbody clonedRigidbody = Instantiate(projectilePrefab, weaponTip.position, weaponTip.rotation);
        clonedRigidbody.AddForce(weaponTip.forward * shootingForce);
    }
}
