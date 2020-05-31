using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public Transform PlayerTr;
    public Transform tr;
    public GameObject enemycanvasGo;
    private Animator ani;
    private bool Die = false;
    NavMeshAgent nav;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        PlayerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
        ani = GetComponent<Animator>();
        
}

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(tr.position, PlayerTr.position);
        if(dist <= 2.0f)
        {
            ani.SetBool("Isattacking", true);
            ani.SetBool("Iswalking", false);
        }
        else if(dist > 2.0f)
        {
            ani.SetBool("Isattacking", false);
            ani.SetBool("Iswalking", true);
        }
        if (nav.destination != target.transform.position)
        {
            nav.SetDestination(target.transform.position);
            ani.SetBool("Iswalking", true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Hands"))
        {
            enemycanvasGo.GetComponent<EnemyHpbar>().currentHP -= 200f;
        }
        if(GetComponent<EnemyHpbar>().currentHP == 0)
        {
            ani.SetBool("Die", true);
        }

    }
    
}
