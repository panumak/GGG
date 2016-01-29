using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;
using thopframwork;
public class MouseClick : MonoBehaviour
{
    [HideInInspector]
    public string[] _choices = new[] { "ClickBase", "Scale", "Rotation", "DragDrop" };
    [HideInInspector]
    public int _choiceIndex = 0;
    public int ChoiceIndex
    {
        get { return _choiceIndex; }
        set { _choiceIndex = value; Reset(_choiceIndex); }
    }
    private bool onScale;
    private bool onRotate;
    private bool onDragDrop;
    [HideInInspector]
    public float speedTime;
    [HideInInspector]
    public float timeAwake;


    //////////Parametor Scale//////////
    [HideInInspector]
    public bool retrunScale = true;
    [HideInInspector]
    public Vector3 newScale = new Vector3(1.5f, 1.5f, 0f);
   
    [HideInInspector]
    public AnimationCurve curveScaleIn = new AnimationCurve(new Keyframe[] {
        new Keyframe(0f,0f), new Keyframe(1f,1f)
        });
    [HideInInspector]
    public AnimationCurve curveScaleOut = new AnimationCurve(new Keyframe[] {
        new Keyframe(0f,0f), new Keyframe(1f,1f)
        });
    private bool smootimg = false;
    /// <summary>
    /// //////////////////// End Parametor Scale //////////////////
    /// </summary>


    //////////////Parametor Rotation/////////////////
    [HideInInspector]
    public bool onRotateOnly =false;   
    [HideInInspector]
    public Vector3 angleRotate;
    [HideInInspector]
    public Vector3 angleTo;
    [HideInInspector]
    public AnimationCurve curveRotateIn = new AnimationCurve(new Keyframe[] {
        new Keyframe(0f,0f), new Keyframe(1f,1f)
        });


    /// <summary>
    /// //////////////////// End Parametor Rotation//////////////
    /// </summary>
    /// 
    //////////////Parametor DragDrop ///////////////
    [HideInInspector]
    public bool snapTag = false;
    [HideInInspector]
    public string Tag;

    private Ray Ray;
    /// <summary>
    /// ////////////////End DragDrop ////////////////
    /// </summary>


    private Action actions;
    public AudioClip soundClick;
    public UnityEvent OnClick;

    Vector3 mySacle;
    void OnMouseDown()
    {
       
            if (!smootimg)
            {
                if (soundClick != null)
                    DJ.PlayAudioButton(soundClick);

                OnClick.Invoke();

                if (onScale)
                    StartCoroutine(SmootScale());
                else if (onRotate)
                    StartCoroutine(SmootRotation());
                else if (onDragDrop)
                    StartCoroutine(DragDrop());
            }
        
    }
    
   
    IEnumerator SmootScale()
    {
        smootimg = true;
        actions = null;
        actions += AddActions;

        if (mySacle.x == 0f)
            mySacle = this.gameObject.transform.localScale;

        ThopFW.TransformAll.ScaleTo(this.gameObject, newScale, speedTime, curveScaleIn);
        yield return new WaitForSeconds(timeAwake);
        if (retrunScale)
            ThopFW.TransformAll.ScaleTo(this.gameObject, mySacle, speedTime, curveScaleOut, actions);

    }

    IEnumerator SmootRotation()
    {
        smootimg = true;
        if (onRotateOnly)
        {
            ThopFW.TransformAll.RotateARound(this.gameObject, angleRotate, speedTime);
            yield return null;
        }
        else
        {
            ThopFW.TransformAll.RotateTo(this.gameObject, angleTo, speedTime, curveRotateIn, 
actions);
            yield return null;
        }
        smootimg = false;
    }

    IEnumerator DragDrop()
    {
        smootimg = true;
        bool c = true;     
        while (c)
        {
            Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            transform.position = new Vector2(Ray.origin.x, Ray.origin.y);
            if (Input.GetMouseButtonUp(0))
                c = false;
            yield return null;
        }
        smootimg = false;
        this.StopAllCoroutines();
    }

    void AddActions()
    {
        smootimg = false;
    }

    void Reset(int index)
    {
      

        if (index == 1)
        {
            onScale = true;
            onRotate = false;
            onDragDrop = false;
        }
        else if (index == 2)
        {
            onRotate = true;
            onScale = false;
            onDragDrop = false;
        }
        else if (index == 3)
        {
            onDragDrop = true;
            onScale = false;
            onRotate = false;
        }
    }
}
