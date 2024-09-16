using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayDemo : MonoBehaviour
{

    [Header("Prefab Enemy")]
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject point;

    private List<GameObject>  enemylist;
    void Start()
    {
        enemylist = new List<GameObject>();

        for (int i = 0; i < point.transform.childCount-1; i++)
        {
            enemylist.Add(point.transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 3)
        {
            RandomPosisition();
        }
    }


    private void RandomPosisition()
    {
        GameObject ins;

        int random = Random.RandomRange(0, enemylist.Count - 1);
        ins = Instantiate(enemy, enemylist[random].transform.position,Quaternion.identity);
    }
}
