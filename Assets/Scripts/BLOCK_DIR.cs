using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLOCK_DIR : MonoBehaviour, IExecutableBlock
{
    GameObject player;
    RectTransform border;

    [SerializeField]
    Vector2 direction;
    [SerializeField]
    string messege;

    float speed = 0.5f;

    void Start()
    {
       player = GameObject.Find("Player");
       border = player.transform.parent.GetComponent<RectTransform>();
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
            
            if( (player.transform.position.x < border.position.x ||
                player.transform.position.y < border.position.y ||
                player.transform.position.x > border.position.x + border.rect.width ||
                player.transform.position.y > border.position.y + border.rect.height))
            {
                startCMD = false;
                Debug.Log("Stopped Player");
            }
        }
    }
}
