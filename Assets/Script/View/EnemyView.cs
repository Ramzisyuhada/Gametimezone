using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private Transform Player;

    [Header("Sound Effect")]
    [SerializeField] private AudioSource SoundWeapon;
    [SerializeField] private AudioSource[] SoundDamage;
    int index = 0;


    [Header("Animator")]
    [SerializeField] Animator animator;

    private PlayerView player;
    private float nextfire = 0f;
    public Enemy enemy;
    private EnemyViewModel viewModel;


   
    void Start()
    {
        enemy = new Enemy(1f, 10f, 60);
        viewModel = new EnemyViewModel();
        player  = Player.GetComponent<PlayerView>();
    }

    void Update()
    {
        transform.LookAt(Player.position);
        
        if (Time.time >= nextfire && enemy.Health > 0)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            Debug.Log(stateInfo.shortNameHash);

            if (Physics.Raycast(transform.position, transform.forward,out RaycastHit hit ,enemy.Firerange))
            {
                
                viewModel.Shoot(enemy);
                if (player.player.Health1 > 0)
                {
                    player.Damage(20);
                    player.ShowDamage();
                    SoundWeapon.Play();
                }
            }
            nextfire =  Time.time + enemy.Firerate;
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * enemy.Firerange, Color.red);

    }


    public void PlaySoundDamage()
    {
        

        if (index > SoundDamage.Length-1)
        {
            index = 0;
        }
        if (SoundDamage.Length > 0 && index < SoundDamage.Length)
        {
            SoundDamage[index].Play();
            index++; 
        }

    }
}
