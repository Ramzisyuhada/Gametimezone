using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private GameObject cross;
    [SerializeField] private GameObject particle;
    [SerializeField] private AudioSource audio_shoot;
    [SerializeField] private AudioSource audio_reload;

    [SerializeField] private GameObject Peluru;

    private Ray ray;
    private Camera camera;


    private int index = 0;

    private GameObject Shoot_effect;
    void Start()
    {
        camera = Camera.main;
        Shoot_effect = Instantiate(particle);
        index = Peluru.transform.childCount-1;
        Shoot_effect.GetComponent<ParticleSystem>().Pause();
    }

    void Update()
    {


        cross.transform.position = Input.mousePosition;

        ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(ray);
        }
       
    }


    private void Reload()
    {
        audio_reload.Play();
        for (int i = 0; i < Peluru.transform.childCount; i++)
        {
            Peluru.transform.GetChild(i).gameObject.SetActive(true);
        }
        index = 5;

    }
    private void Shoot(Ray ray)
    {
        if (Physics.Raycast(ray,out RaycastHit hit))
        {
            Shoot_effect.transform.position = hit.point;
            ParticleSystem particleSystem = Shoot_effect.GetComponent<ParticleSystem>();
            particleSystem.Stop();
            particleSystem.Play();
            GetComponent<AudioSource>().Play();
            
        }

        Peluru.transform.GetChild(index).gameObject.SetActive(false);
     
        index--;
        if (index < 0)
        {
            Reload();

        }
    }

}
        
