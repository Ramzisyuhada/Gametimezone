using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy 
{
    private float firerate;
    private float firerange;
    private int health;

    public Enemy(float firerate, float firerange, int health)
    {
        this.firerate = firerate;
        this.firerange = firerange;
        this.health = health;
    }

    public float Firerate { get => firerate; set => firerate = value; }
    public float Firerange { get => firerange; set => firerange = value; }
    public int Health { get => health; set => health = value; }
}
