using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Peuru : MonoBehaviour
{
    Rigidbody rb;
    public Transform tip;

    public ParticleSystem particle;
    void Start()
        
    {
      rb = GetComponent<Rigidbody>();
        /*        rb.velocity = transform.forward * 2200f;
        */


    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 50f;
         CheckCollision();
    }
    private void OnTriggerEnter(Collider other)
    {
    }
    
   

    private void CheckCollision()
    {
        if (Physics.Linecast(Vector3.zero, tip.position, out RaycastHit hitInfo))
        {
            Debug.Log(hitInfo.transform.gameObject.name);

            if (hitInfo.transform.gameObject.CompareTag("Target")) Debug.Log("Nambah Score");
        }
    }
}
