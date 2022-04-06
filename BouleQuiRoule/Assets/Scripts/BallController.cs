using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    public float intensity = 1f;
    public float maxAngularVelocity = 50f;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float Horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forwardCamera = Camera.main.transform.forward;
        Vector3 rightCamera = Camera.main.transform.right;

        Vector3 direction = (forwardCamera * vertical) + (rightCamera * Horizontal);
        //direction = new Vector3(direction.x, 0, direction.y);
        //direction.Normalize();

        Roll(direction);
    }
    void Roll(Vector3 moveDirection)
    {
        Vector3 torqueDirection = new Vector3(moveDirection.z, 0, -moveDirection.x).normalized;
        m_rigidbody.AddTorque(torqueDirection * intensity);
    }
}
