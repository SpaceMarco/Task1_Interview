using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCommands : MonoBehaviour
{
    [SerializeField]
    GameObject start_block;


    public void StartCode()
    {
        foreach(Transform n in start_block.transform)
        {
            // Debug.Log(">>"+ n.name);
            // // Debug.Log(n.name);
            if(n.tag == "block")
            {
                n.GetComponent<IExecutableBlock>().Execute();
            }
        }
    }
}
