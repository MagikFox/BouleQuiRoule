using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform VisualDragging;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VisualDragging.position = Vector3.Lerp(VisualDragging.position, transform.position, Time.deltaTime);
    }
}
