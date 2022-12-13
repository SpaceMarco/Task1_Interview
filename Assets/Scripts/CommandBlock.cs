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
            Transform draggedParent = dragged.transform.parent;
            data.pointerDrag.gameObject.GetComponent<IExecutableBlock>().Stop();
            dragRectTransform = data.pointerDrag.gameObject.GetComponent<RectTransform>();
            if(dragManager.getchildreninStart(dragged)==1)
            {
                dragged.transform.parent = LeftPanel.transform;
            }
            if(draggedParent.tag == "block")
            {
                Debug.Log("dragged: "+draggedParent.name);
                resetBlock(draggedParent.transform);
            }
        }
    }

    void resetBlock(Transform obj)
    {
        int ct=1;
        foreach (Transform child in obj.transform)
        {
            if(child.tag == "block")
            {
                float height =  38f * ct;
                child.position = new Vector2( obj.transform.position.x, (obj.transform.position.y - height) );
                child.transform.parent = obj.transform;
                dragManager.GetChildRecursive(child.gameObject,obj.transform);
                ct++;
            }
        }
    }

}
