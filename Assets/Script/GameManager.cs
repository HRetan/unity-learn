using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int iStage = 0;
    public float fTempo = 2.0f;
    public GameObject goEnemy = null;
    private bool isStart = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (iStage == 0 && !isStart && Input.GetKeyDown(KeyCode.Return)) {
            goEnemy = Resources.Load("Enemy") as GameObject;
            isStart = true;
            iStage = 1;
        }

        if(goEnemy == null) {
            iStage += 1;
            fTempo -= 0.01f;
            goEnemy = Resources.Load("Enemy") as GameObject;
        }
    }
}
