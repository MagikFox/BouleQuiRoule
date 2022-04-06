using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    public SpawnPoint spawnPoint;
    public bool GentilLaser = false;
    /*[SerializeField]
    private int ActiveSpawnPoint;
    [SerializeField]
    private Transform[] SpawnPoint;*/
    [SerializeField]
    private Transform PointA;
    [SerializeField]
    private Transform PointB;
    [SerializeField]
    private LayerMask layer;
    private LineRenderer m_lineRenderer;
    [SerializeField]
    private int NewSpawPoint;

    private void Awake()
    {
        m_lineRenderer = GetComponent<LineRenderer>();

        if (!GentilLaser)
        {
            m_lineRenderer.material.color = Color.red;
        }
        else
        {
            m_lineRenderer.material.color = Color.cyan;
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_lineRenderer.positionCount = 2;
        m_lineRenderer.SetPositions(new Vector3[2]{PointA.position, PointB.position});

        RaycastHit HitInfo;
        if (Physics.Linecast(PointA.transform.position, PointB.transform.position,out HitInfo, layer))
        {
            if (!GentilLaser)
            {
                m_lineRenderer.SetPosition(1, HitInfo.point);
                Debug.Log("Rayon hit");
                Debug.DrawLine(PointA.transform.position, PointB.transform.position, Color.green);
                m_lineRenderer.material.color = Color.green;
                TeleportPlayerToActiveSP(HitInfo);
            }else
            {
                spawnPoint.SetSpawnPoint(NewSpawPoint);
            }
            
        }
        else
        {
            if (!GentilLaser)
            {
                Debug.DrawLine(PointA.transform.position, PointB.transform.position, Color.red);
                m_lineRenderer.material.color = Color.red;
            }else
            {

            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(PointA.transform.position, 0.5f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(PointB.transform.position, 0.5f);
        Gizmos.color= Color.blue;
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }

    public void TeleportPlayerToActiveSP(RaycastHit HitInfo)
    {

        HitInfo.transform.position = spawnPoint.GetSpawnPoint();
        HitInfo.rigidbody.velocity = Vector3.zero;
        HitInfo.rigidbody.angularVelocity = Vector3.zero;
        
        /*try
        {
            HitInfo.transform.position = SpawnPoint[ActiveSpawnPoint].position;
        }catch
        {
            Debug.Log("Il n'y a pas de SpawnPoint alloué a ce nombre !");
        }*/
    }
}
