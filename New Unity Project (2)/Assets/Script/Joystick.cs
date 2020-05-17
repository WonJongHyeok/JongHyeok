using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public Transform Player;
    public Transform Stick;

    private Animator ani;
    private bool PlayerMove;
    private Vector3 StickFirstPos;
    private Vector3 Joyvector;
    private float Radius;

    // Start is called before the first frame update
    void Start()
    {
        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        StickFirstPos = Stick.transform.position;
        PlayerMove = false;
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (PlayerMove) Player.transform.Translate(Vector3.forward * Time.deltaTime * 10f);
        ani.SetBool("Iswalking", true);
    }


    public void Drag(BaseEventData _Data)
    {
        PointerEventData Data = _Data as PointerEventData;
        Vector3 Pos = Data.position;
        Joyvector = (Pos - StickFirstPos).normalized;
        float Dis = Vector3.Distance(Pos, StickFirstPos);

        if (Dis < Radius)
            Stick.position = StickFirstPos + Joyvector * Dis;

        else
            Stick.position = StickFirstPos + Joyvector * Radius;
        Player.eulerAngles = new Vector3(0, Mathf.Atan2(Joyvector.x, Joyvector.y) * Mathf.Rad2Deg, 0);
    }

    public void DragEnd()
    {
        Stick.position = StickFirstPos; 
        Joyvector = Vector3.zero;
        PlayerMove = false;
        ani.SetBool("Iswalking", false);
    }

}
