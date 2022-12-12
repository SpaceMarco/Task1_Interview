using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLOCK_DIR : MonoBehaviour, IExecutableBlock
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    Vector2 direction;
    [SerializeField]
    string messege;

    float speed = 0.5f;

    void Start()
    {
       player = GameObject.Find("Player");
    }

    bool startCMD = false;
    public void Execute()
    {
        startCMD = true;
    }

    public void Stop()
    {
        startCMD = false;
    }

    void Update()
    {
        if(startCMD)
        {
            player.transform.Translate(direction * speed);
           // Debug.Log(messege);
        }
    }
}
