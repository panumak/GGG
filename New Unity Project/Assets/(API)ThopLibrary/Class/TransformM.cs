using UnityEngine;
using System.Collections;
using System;
public class TransformM : MonoBehaviour
{
    private Vector3 startPosition;

    [HideInInspector]
    public AnimationCurve curve = new AnimationCurve(new Keyframe[] {
        new Keyframe(0f,0f), new Keyframe(1f,1f)
        });
    [HideInInspector]
    public Action onFinish;   
    [HideInInspector]
    public Vector3 position;  
    [HideInInspector]
    public bool onPosition = false;   
    [HideInInspector]
    public bool onRotatetionAR = false;
    [HideInInspector]
    public float time;

    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        float ratio = 0;
        float spendTime = 0;
       
        if (onPosition)
        {
            startPosition = transform.position;
            Vector3 dif = position - startPosition;
            while (spendTime <= time)
            {
                spendTime += Time.deltaTime;
                ratio = spendTime / time;
                transform.position = startPosition + ( dif *curve.Evaluate (ratio));
                yield return new WaitForEndOfFrame();
            }
            transform.position = position;
        }
       
    
        
        this.Stop();
    }
    public void Stop()
    {
        this.StopAllCoroutines();
        if (onFinish != null)
            onFinish();
        Destroy(this);
    }
    public void ReUse()
    {
        this.StopAllCoroutines();
        StartCoroutine(Move());
    }

  
}
