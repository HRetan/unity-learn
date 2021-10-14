using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private Enemy cTarget;
    private void Awake() {
        iLife = 3;
        eState = UNIT_STATE.IDLE;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack() {
        base.Attack(cTarget);
    }
}
