using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class peluru : MonoBehaviour
{
    Rigidbody rb;
    public Transform tip;
    int i = 0;
    public GameObject particle;

    private Vector3 _lastpoint;
    void Start()
        
    {
      rb = GetComponent<Rigidbody>();
        /*        rb.velocity = transform.forward * 2200f;
        */

        _lastpoint = new Vector3(0f, 0.629999995f, -0.503000021f);
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
        GameObject pcr;
        if (Physics.Linecast(Vector3.zero, tip.position, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.gameObject.CompareTag("Target"))
            {
                Destroy(hitInfo.transform.gameObject);
                pcr = Instantiate(particle, hitInfo.transform.position, Quaternion.identity);
                pcr.GetComponent<ParticleSystem>().Play();
                gameObject.SetActive(false);

            }
        }
    }

}

