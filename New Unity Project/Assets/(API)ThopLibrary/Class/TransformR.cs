using UnityEngine;
using System.Collections;
using System;
public class TransformR : MonoBehaviour
{
    private Vector3 startRotation;
    public AnimationCurve curve = new AnimationCurve(new Keyframe[] {
        new Keyframe(0f,0f), new Keyframe(1f,1f)
        });
    [HideInInspector]
    public Action onFinish;
    [HideInInspector]
    public Vector3 rotation;
    [HideInInspector]
    public Vector3 vectorRotate;
    [HideInInspector]
    public bool onRotatetion = false;
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
         if (onRotatetion)
        {
            startRotation = transform.eulerAngles;
            Vector3 dif = rotation - startRotation;
            while (spendTime <= time)
            {
                spendTime += Time.deltaTime;
                ratio = spendTime / time;
                transform.eulerAngles = startRotation + (dif * curve.Evaluate(ratio));
                yield return new WaitForEndOfFrame();
            }
            transform.eulerAngles = rotation;
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
