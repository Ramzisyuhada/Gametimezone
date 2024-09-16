using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{


    public enum RoleClass
    {
        Shoot,
        Throw,
        GoodPerson
    }
    [SerializeField] private Transform Player;

    [Header("Sound Effect")]
    [SerializeField] private AudioSource SoundWeapon;
    [SerializeField] private AudioSource[] SoundDamage;
    int index = 0;


    [Header("Animator")]
    [SerializeField] Animator animator;


    [Header("Role")]
    public RoleClass role;

    [Header("Role Bomb")]
    [SerializeField] GameObject ins;
    [SerializeField] GameObject BomsPref;


    [Header("UI")]
    [SerializeField] private Image DamageEffect;

    private PlayerView player;
    private float nextfire = 0f;
    public Enemy enemy;
    private EnemyViewModel viewModel;


   
    void Start()
    {
        enemy = new Enemy(1f, 10f, 60);
        viewModel = new EnemyViewModel();
        Player = GameObject.Find("Player").transform;

        player = Player.GetComponent<PlayerView>();
    }

    void Update()
    {
        transform.LookAt(Player.position);
        
        if (Time.time >= nextfire && enemy.Health > 0)
        {

            switch (role)
            {
                case RoleClass.Shoot:
                    ShootRole();
                    break;

                case RoleClass.Throw:
                    ThrowRole();
                    break;

                default:
                    Debug.LogWarning("Unknown role!");
                    break;
            }
            nextfire =  Time.time + enemy.Firerate;
        }
        DieEnemy();

    }

    public void DieEnemy()
    {
        if (enemy.Health <= 0) Destroy(gameObject, 5f); 
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

    private void ShootRole()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, enemy.Firerange))
        {
            Debug.Log(player.player.Health1);
            if (player.player.Health1 > 0)
            {
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

                if (stateInfo.IsName("Shooting"))
                {
                    player.ShowDamage();

                    SoundWeapon.Play();
                    player.Damage(20);


                }
            }
        }
    }
    private void ThrowRole()
    {

        GameObject playerposisition = GameObject.Find("Player");
        Vector3 dir = playerposisition.transform.position - ins.transform.position;
        GameObject bm = Instantiate(BomsPref,ins.transform.position,Quaternion.identity);
        Rigidbody rb = bm.GetComponent<Rigidbody>();

        if (rb != null)
        {
            float distance = Vector3.Distance(ins.transform.position, playerposisition.transform.position);

            float throwForce = Mathf.Sqrt(distance) * 2f; 
            rb.AddForce(dir * throwForce, ForceMode.Impulse);
        }
    }

    
}
