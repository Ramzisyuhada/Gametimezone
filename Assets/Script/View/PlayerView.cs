using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] public Image DamageEffect;

    public Player player = new Player(100);

    public static Image effect ;


    private void Awake()
    {
        effect = DamageEffect;
    }
    void Update()
    {
        
        if (effect.color.a != 0 )
        {
            effect.color = new Color(effect.color.r, effect.color.g, effect.color.b, Mathf.MoveTowards(effect.color.a,0f,0.5f * Time.deltaTime));

        }

    }


    public void Damage(int damage)
    {
        player.Health1 -= damage;
    }


    public void ShowDamage()
    {
        effect.color = new Color(effect.color.r, effect.color.g, effect.color.b, 0.3f);

    }


}
