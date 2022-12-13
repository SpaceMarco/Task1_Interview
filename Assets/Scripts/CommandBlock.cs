using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CommandBlock : MonoBehaviour,  IDragHandler, IBeginDragHandler, IEndDragHandler
{
    GameObject dragged;
    GameObject LeftPanel;
    RectTransform rectTransform;
    RectTransform dragRectTransform;
    private DragInputManager dragManager;
    private StartCommands startManager;
    private GameObject StartBlock;



    void Start()
    {
        LeftPanel = GameObject.Find("Left Panel");
        StartBlock = GameObject.Find("START");
        rectTransform = GetComponent<RectTransform>();
        dragManager = GameObject.Find("Manager").GetComponent<DragInputManager>();
        startManager = GameObject.Find("Manager").GetComponent<StartCommands>();
    }

    public void OnEndDrag(PointerEventData data)
    {
       dragManager.CheckOverlap(dragRectTransform);

       if(StartBlock.transform.childCount > 1)
       {
            startManager.StartCode();
       }
    }

    public void OnDrag(PointerEventData data)
    {
        transform.position = data.position;
    }
    
    public void OnBeginDrag(PointerEventData data)
    {
        if(data.pointerDrag.gameObject.tag == "block")
        {
            dragged = data.pointerDrag.gameObject;
            data.pointerDrag.gameObject.GetComponent<IExecutableBlock>().Stop();
            dragRectTransform = data.pointerDrag.gameObject.GetComponent<RectTransform>();
            if(getchildreninStart(dragged)==1)
            {
                dragRectTransform.gameObject.transform.parent = LeftPanel.transform;
            }
        }
    }

    int getchildreninStart(GameObject obj)
    {
        int ct = 1;
        foreach(Transform n in obj.transform)
        {
            if(n.tag == "block")
            {
                ct++;
            }
        }
        return ct;
    }

}
