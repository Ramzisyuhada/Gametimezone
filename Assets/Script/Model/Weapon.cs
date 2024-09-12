using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Weapon 
{
    private int ammo;
    private int rateorfire;


    Weapon(int ammo, int rateorfire)
    {
        this.ammo = ammo;
        this.rateorfire = rateorfire;
    }

    
}
