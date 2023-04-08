using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingScript : MonoBehaviour
{
    [SerializeField] GameObject pointer;
    [SerializeField] GameObject targetPointer;
    [SerializeField] LayerMask layer;
    [SerializeField] StrikerScript sStriker;
    [SerializeField] LineRenderer _testLine;

    // Start is called before the first frame update
    private void OnMouseDrag() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, layer))
        {
            pointer.transform.position = hit.point;
            UpdateTargetPointer();
        }
    }

    void UpdateTargetPointer()
    {
        GameObject goStriker = sStriker.gameObject;

        float currentDistance = Vector3.Distance(pointer.transform.position, goStriker.transform.position);
        Vector3 dimxy = pointer.transform.position - goStriker.transform.position;
        float diff = dimxy.magnitude;
        targetPointer.transform.position = goStriker.transform.position + ((dimxy / diff) * currentDistance * -1);
        //targetPointer.transform.position = new Vector3(targetPointer.transform.position.x, targetPointer.transform.position.y, -0.8f);
        drawLineToTarget();
    }

    void drawLineToTarget()
    {
        Vector3[] vertexs = new Vector3[2];
        vertexs[0] = sStriker.gameObject.transform.position;
        vertexs[1] = targetPointer.transform.position;

        _testLine.positionCount = 2;
        _testLine.SetPositions(vertexs);
        _testLine.enabled = true;
    }


    private void OnMouseUp() {
        sStriker.Shoot(pointer.transform.position);
        _testLine.enabled = false;
    }
}
