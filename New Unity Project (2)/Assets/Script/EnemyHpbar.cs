using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpbar : MonoBehaviour
{
    public Slider EnemyHP;
    public Transform Enemy;
    public float maxHP = 1000f;
    public float currentHP = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Enemy.position;
        EnemyHP.value = currentHP / maxHP;
    }
}
