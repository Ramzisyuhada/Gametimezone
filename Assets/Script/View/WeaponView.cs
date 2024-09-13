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
    private Weapon weapon;

    private float nextFiretime = 0f;
   
    void Start()
    {
        camera = Camera.main;
        weapon = new Weapon(100,0.5f);
        ammo.text = weapon.Getammo().ToString();
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        ray = camera.ScreenPointToRay(mousePosition);

        Crosshair.transform.position = Input.mousePosition;
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFiretime) {
            SoundWeapon.Play();
            WeaponViewModel weaponViewModel = new WeaponViewModel();
            weaponViewModel.Shoot(ray);
            if (weapon.Getammo() > 0)
            {
                weapon.Setammo(weapon.Getammo() - 20);
                ammo.text = weapon.Getammo().ToString();
            }
            nextFiretime = Time.time + weapon.Getrateorfire();
        }
    }
}
