using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    private int Health;

    public Player(int health)
    {
        Health = health;
    }

    public int Health1 { get => Health; set => Health = value; }
}
