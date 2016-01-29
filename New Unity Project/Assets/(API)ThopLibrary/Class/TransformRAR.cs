using UnityEngine;
using System.Collections;
using System;
public class TransformRAR : MonoBehaviour
{
    private Vector3 startPosition;
    [HideInInspector]
    public Vector3 rotation;
    [HideInInspector]
    public Vector3 position;
    [HideInInspector]
    public AnimationCurve curve = new AnimationCurve(new Keyframe[] {
        new Keyframe(0f,0f), new Keyframe(1f,1f)
        });
    [HideInInspector]
    public Action onFinish;
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
        if (onRotatetionAR)
        {
            startPosition = transform.position;
            Vector3 dif = position - startPosition;
            while (true)
            {
                this.gameObject.transform.Rotate(rotation * time);
                yield return new WaitForEndOfFrame();
            }
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
