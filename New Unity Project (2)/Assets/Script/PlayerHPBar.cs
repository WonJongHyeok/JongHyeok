using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    public Slider PlayerHP;
    private Animation ani;
    public Transform Player;
    public float maxHP;
    public float currentHP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position;
        PlayerHP.value = Mathf.Lerp(PlayerHP.value, currentHP / maxHP, Time.deltaTime * 5f);
    }
}
