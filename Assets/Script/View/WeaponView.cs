using InfimaGames.LowPolyShooterPack.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [Header("GUI")]
    [SerializeField] Text ammo;
    [SerializeField] RectTransform Crosshair;


    [Header("Sound")]
    [SerializeField] private AudioSource SoundWeapon;

    [Header("Instantiance")]
    [SerializeField] private GameObject ins;






    private Camera camera;
    private Ray ray;
    private GameObject player;
    void Start()
    {
        camera = Camera.main;
        player = GameObject.FindWithTag("Player"); 
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        ray = camera.ScreenPointToRay(mousePosition);

        Crosshair.transform.position = Input.mousePosition;
        if (Input.GetMouseButtonDown(0)) {
            WeaponViewModel weaponViewModel = new WeaponViewModel();
            SoundWeapon.Play();
            weaponViewModel.Shoot(ins, ray, player);
        }
    }
}
