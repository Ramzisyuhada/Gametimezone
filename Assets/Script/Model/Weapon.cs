using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Weapon 
{
    private int ammo;
    private float rateorfire;


    public  Weapon(int ammo, float rateorfire)
    {
        this.ammo = ammo;
        this.rateorfire = rateorfire;
    }


    public int Getammo()
    {
        return ammo;
    }

    public void Setammo(int ammo)
    {
        this.ammo = ammo;
    }

    public float Getrateorfire()
    {
        return rateorfire;
    }

    public void Setrateorfire(float rateorfire)
    {
        this.rateorfire = rateorfire;
    }

}
