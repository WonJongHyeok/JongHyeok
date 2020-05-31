using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerAnimation : MonoBehaviour
{
    
    private bool AttackButton = false;
    private Animator ani;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PlayerHPBar>().currentHP == 0)
        {
            ani.SetBool("Die", true);
        }
    }
    public void Click(BaseEventData _Data)
    {
        if(AttackButton == true)
        {
            ani.SetBool("Ispunching", true);
            ani.SetBool("Iswalking", false);
        }
        else if(AttackButton == false)
        {
            ani.SetBool("Ispunching", false);
        }
    }
}
