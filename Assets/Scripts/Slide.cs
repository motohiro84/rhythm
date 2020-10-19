using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public AnimationCurve animCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public Vector3 inPosition1;        // スライドイン後の位置
    public Vector3 inPosition2;        // スライドイン後の位置
    public float duration = 1.0f;    // スライド時間（秒）
    public Vector3 startPos;

    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(StartSlidePanel());
    }

        private IEnumerator StartSlidePanel()
    {
        float startTime = Time.time;
        Vector3 moveDistance;

        if(SenderKey.leftKey)
        {
            moveDistance = (inPosition1 - startPos);
            SenderKey.leftKey = false;
        }
        else
        {
            moveDistance = (inPosition2 - startPos);
            SenderKey.leftKey = true;
        }

        while((Time.time - startTime) < duration)
        {
            transform.localPosition = startPos + moveDistance * animCurve.Evaluate((Time.time - startTime) / duration);
            yield return 0;
        }
        transform.localPosition = startPos + moveDistance;

    }

}
