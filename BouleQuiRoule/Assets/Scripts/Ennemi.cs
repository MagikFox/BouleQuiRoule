using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ennemi : MonoBehaviour
{
    private Rigidbody RB;
    public float rayDiastance = 5;
    public GameObject Target;
    public bool contact = false;
    public Vector3 moveUp;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    enum State
    {
        Wait,
        Aiming,
        Attack,
        Realoding
    }

    private State state = State.Wait;



    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target.transform);
        

        switch (state)
        {
            case State.Wait:
                UpdateWait();
                break;
            case State.Aiming:
                UpdateAim();
                break;
            case State.Attack:
                UpdateAttack();
                break;
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDiastance, Color.red);
        /*transform.LookAt(Target.transform);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*rayDiastance, Color.red);
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDiastance))
        {
            
            
            if(hit.collider.name == Target.name)
            {
                contact = true;
                detect = true;
                Launch();
            }
            
            
        }
        else
        {
            Debug.Log("Stop");
            contact = false;
            detect = false;
            stopAttack = false;
            StopAllCoroutines();
        }*/
    }

    void UpdateWait()
    {
        RaycastHit hit;
        if ((Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDiastance) && hit.collider.name == Target.name) == true)
        {
            StartCoroutine(attack());
        }
    }

    void UpdateAim()
    {
        RaycastHit hit;
        if ((Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDiastance) && hit.collider.name == Target.name)== false)
        {
            state = State.Wait;
            StopAllCoroutines();
        }
    }

    void UpdateAttack()
    {
        RaycastHit hit;
        if ((Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDiastance) && hit.collider.name == Target.name) == false)
        {
            state = State.Wait;
            StopAllCoroutines();
        }
    }

    

    bool detect;
    bool stopAttack = false ;
    void Launch()
    {
        moveUp = transform.position ;
        if(detect == true)
        {
            detect = false;
            StartCoroutine(attack());
        }
    }
    
    IEnumerator attack()
    {
        state = State.Aiming;
        yield return new WaitForSecondsRealtime(1);

        RB.velocity = Vector3.up * 6f;
        gameObject.transform.Find("CFX3_Vortex_Ground").gameObject.GetComponent<ParticleSystem>().Play();


        state = State.Attack;

        yield return new WaitForSecondsRealtime(1);
        AttackFunc();
        gameObject.transform.Find("CFX2_EnemyDeathSkull").gameObject.GetComponent<ParticleSystem>().Play();

        state = State.Realoding;
        yield return new WaitForSecondsRealtime(3);

        state = State.Wait;
    }
    void AttackFunc()
    {
        Vector3 AttackDir = (Target.transform.position - transform.position).normalized;
        RB.velocity = AttackDir * 15f;
        


    }

}
