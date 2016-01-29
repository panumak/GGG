using UnityEngine;
using System.Collections;
using System;
public class TransformS : MonoBehaviour
{
    private Vector3 startScale;
    [HideInInspector]
    public AnimationCurve curve = new AnimationCurve(new Keyframe[] {
        new Keyframe(0f,0f), new Keyframe(1f,1f)
        });
    [HideInInspector]
    public Action onFinish;
    [HideInInspector]
    public Vector3 scale;
    [HideInInspector]
    public bool onScale = false;
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
        if (onScale)
        {
            startScale = transform.localScale;
            Vector3 dif = scale - startScale;
            while (spendTime <= time)
            {
                spendTime += Time.deltaTime;
                ratio = spendTime / time;
                transform.localScale = startScale + (dif * curve.Evaluate(ratio));
                yield return new WaitForEndOfFrame();
            }
            transform.localScale = scale;
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