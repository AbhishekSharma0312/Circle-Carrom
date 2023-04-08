using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject goStriker;
    private void OnMouseUp() 
    {
        Vector3 mouseUpPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("mouseUpPosition = " + mouseUpPosition);
        Vector3 direction = goStriker.transform.position - mouseUpPosition;
        Debug.Log("Direction to shoot = " + direction);
    }
}
