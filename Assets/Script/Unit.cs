using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum UNIT_STATE {
    IDLE,
    ATTACK,
    DAMAGE,
    WALK,
    DEFENCE,
    DEATH,
    NONE
};

enum ATTACK_STATE {
    LEFT,
    RIGHT,
    NONE
}

public class Unit : MonoBehaviour
{
    public int iLife;
    public const int iDamage = 1;
    public UNIT_STATE eState = UNIT_STATE.NONE;
    public ATTACK_STATE eAttack = ATTACK_STATE.NONE;
    public GameManager cGameManager;

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

    public virtual void Attack(Unit target) {
        target.Damage();
    }

    void Damage() {
        iLife -= 1;

        if(iLife == 0) {
            Debug.Log("죽음");
        }
    }
}
