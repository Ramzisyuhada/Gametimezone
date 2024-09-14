using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Image DamageEffect;

    public Player player;

    

    void Start()
    {
        player= new Player(100);
    }

    void Update()
    {
        if (DamageEffect.color.a != 0 )
        {
            DamageEffect.color = new Color(DamageEffect.color.r, DamageEffect.color.g, DamageEffect.color.b, Mathf.MoveTowards(DamageEffect.color.a,0f,0.5f * Time.deltaTime));

        }
        if (player.Health1 == 0)
        {
            Debug.Log(player.Health1);


        }
    }


    public void Damage(int damage)
    {
        player.Health1 -= damage;
    }


    public void ShowDamage()
    {
        
           DamageEffect.color = new Color(DamageEffect.color.r, DamageEffect.color.g, DamageEffect.color.b, 0.3f);
         
    }

    
}
