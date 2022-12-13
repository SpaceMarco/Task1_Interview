using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DragInputManager : MonoBehaviour
{
    
    [SerializeField] 
    private List<GameObject> Blocks;
    private GameObject StartBlock;
    float width, height;

    public int getchildreninStart(GameObject obj)
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

    private void Start() {
        StartBlock = GameObject.Find("START");
    }

    bool rectOverlaps(RectTransform rectTrans1, RectTransform rectTrans2)
    {
        Rect rect1 = new Rect(rectTrans1.localPosition.x, rectTrans1.localPosition.y, rectTrans1.rect.width, rectTrans1.rect.height);
        Rect rect2 = new Rect(rectTrans2.localPosition.x, rectTrans2.localPosition.y, rectTrans2.rect.width, rectTrans2.rect.height);
        
        return rect1.Overlaps(rect2);
    }


    public void GetChildRecursive(GameObject obj, Transform Parent)
    {
        if (null == obj)
            return;

        foreach (Transform child in obj.transform){
            if (null == child)
                continue;
            if(obj.tag == "block")
            {
                obj.transform.parent = Parent;
            }
            GetChildRecursive(child.gameObject, StartBlock.transform);
        }
    }

    public void CheckOverlap(RectTransform dragRectTransform)
    {
        if(dragRectTransform.gameObject.tag == "block")
        {
            foreach(GameObject i in Blocks)
            {
                if(dragRectTransform.transform.gameObject != i)
                {
                    RectTransform rectTransform = i.GetComponent<RectTransform>();
                    if(rectTransform.gameObject.tag == "block")
                    {
                        if(rectOverlaps(dragRectTransform, rectTransform))
                        {
                            Debug.Log("--------------------->"+rectTransform.gameObject.name);
                            height =  38f * getchildreninStart(rectTransform.gameObject);
                            dragRectTransform.position = new Vector2( rectTransform.position.x, (rectTransform.position.y - height) );
                            dragRectTransform.transform.parent = rectTransform.transform;
                            GetChildRecursive(dragRectTransform.transform.gameObject,rectTransform.transform);
                            // Debug.Log("child: "+ dragRectTransform.transform.name +", parent: "+ dragRectTransform.transform.parent);
                        }
                    }
                }
            }
        }
    }

}
