using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    private enum UNIT_STATE {
        IDLE,
        ATTACK,
        DAMAGE,
        WALK,
        DEFENCE,
        DEATH,
        NONE
    }

    private enum ATTACK_STATE {
        LEFT,
        RIGHT,
        NONE
    }

    public int m_iLife;
    public const int m_iDamage = 1;
    private UNIT_STATE m_eState = UNIT_STATE.NONE;
    private ATTACK_STATE m_eAttack = ATTACK_STATE.NONE;
    public GameManager m_cGameManager;

    private void Awake() {
        cGameManager = GameObject.find("GameManager").GetComponent<GameManager>();
        cGameManager.goEnemy = gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(Unit target) {
        target.Damage();
    }

    void Damage() {
        m_iLife -= 1;

        if(m_iLife == 0) {
            Debug.Log("죽음");
        }
    }

    public void SetState(int state) {
        m_eState = state;
    }

    public int GetState() {
        return (int)m_eState;
    }
}

public class Player : Unit
{
    private Enemy m_cTarget;
    private void Awake() {
        m_iLife = 3;
        m_eState = UNIT_STATE.IDLE;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack() {
        base.Attack(cTarget);
    }
}

public class Enemy : Unit
{
    private GameObject m_goPlayer;
    private Player m_cPlayer;
    private Vector2 m_vecPoint = new Vector2(10, 10);
    private float m_pointDistance = 0.1f;
    private Animator m_anim;

    // stage 관리하는 오브젝트에 접근해서 스테이지 별 강화 적용

    // Start is called before the first frame update
    private void Awake() {
        this.Awake();
        m_goPlayer = GameObject.FindWithTag("Player");
        m_cPlayer = goPlayer.GetComponent<Player>();
        m_anim = GetComponent<Animator>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float vecDistance = vecPoint.position - transform.position;
        if(m_eState == UNIT_STATE.WALK) {
            if(vecDistance.sqrMagnitude >=  m_pointDistance * m_pointDistance) {
                transform.position += new Vector3(0, -1.0f, 0);
            } else {
                transform.position = vecPoint.position;
                Idle();
            }
        }
    }

    void Idle() {
        m_eState = UNIT_STATE.IDLE;
        m_anim.setBool("isIdle", true);        
    }

    public void Attack() {
        base.Attack(m_cPlayer);
    }
}
