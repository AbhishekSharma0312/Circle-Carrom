using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikerScript : MonoBehaviour
{
    Vector3 spawnPosition;
    Vector3 mouseClickPoition;
    Vector3 mouseReleasePosition;
    Vector3 shootDirection;
    [SerializeField] Rigidbody rbStriker;
    [SerializeField] float shootPower;


    private void Start() {
        spawnPosition = transform.position;
    }

    public void Shoot(Vector3 position)
    {
        shootDirection = transform.position - position;
        Debug.Log("Direction at = " + shootDirection);
        
        rbStriker.AddForce(shootDirection * shootPower, ForceMode.Impulse);
    }

}