using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbite : MonoBehaviour
{
    [Range(1,10)]
    public float sensiblité = 1;
    public Transform Target;
    private Vector3 PrevPos;
    private Vector3 finalPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        PrevPos = Target.position;
        finalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 DraggedTargetPos = Vector3.Lerp(PrevPos, transform.position, Time.deltaTime);
        
        transform.LookAt(Target, Vector3.up);
        transform.RotateAround(Target.position, Vector3.up, sensiblité * Input.GetAxis("Mouse X"));

        

        Vector3 targetMouvement = Target.position - PrevPos;


        transform.position += targetMouvement;

        PrevPos = Target.position;
    }
}
