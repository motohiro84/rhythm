using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEditor;
// using UnityEngine.Sprite;

public class Slider : MonoBehaviour
{
    public AnimationCurve animCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public Vector3 inPosition1;        // スライドイン後の位置
    public Vector3 inPosition2;        // スライドイン後の位置
    public float duration = 1.0f;    // スライド時間（秒）
    bool key = true;
    public Vector3 startPos;
    public GameObject prefab1;
    private GameObject prefab2;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Canvas = GameObject.Find("Canvas");
        prefab2 = prefab1;
        
        prefab1.transform.SetParent(Canvas.transform, false);
        prefab2.transform.SetParent(Canvas.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if ( Music.IsJustChangedBar() )
        {

                PrefabNew();

            // StartCoroutine(StartSlidePanel());
        }
    }

    void PrefabNew()
    {
        if(key)
        {
            prefab1.transform.localScale = new Vector3(2,2,2);
            Instantiate( prefab1 , obj.transform );
            key = false;
        }
        else
        {
            prefab1.transform.localScale = new Vector3(1,1,1);
            Instantiate( prefab2 , obj.transform );
            key = true;
        }
    }

    // private IEnumerator StartSlidePanel()
    // {
    //     float startTime = Time.time;
    //     Vector3 moveDistance;

    //     if(key)
    //     {
    //         moveDistance = (inPosition1 - startPos);
    //     }
    //     else
    //     {
    //         moveDistance = (inPosition2 - startPos);
    //     }

    //     while((Time.time - startTime) < duration)
    //     {
    //         transform.localPosition = startPos + moveDistance * animCurve.Evaluate((Time.time - startTime) / duration);
    //         yield return 0;
    //     }
    //     transform.localPosition = startPos + moveDistance;

    // }

}
