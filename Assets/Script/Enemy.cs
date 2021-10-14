using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject goPlayer;
    private Player cPlayer;
    private Vector2 vecPosition = new Vector2(10, 10);
    private Animator anim;

    // stage 관리하는 오브젝트에 접근해서 스테이지 별 강화 적용

    // Start is called before the first frame update
    private void Awake() {
        this.Awake();
        goPlayer = GameObject.FindWithTag("Player");
        cPlayer = goPlayer.GetComponent<Player>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(vecPosition != transform.position) {
            transform.position += new Vector3(0, -1.0f, 0);
            
        }
    }

    public override void Attack() {
        base.Attack(cPlayer);
    }
}
