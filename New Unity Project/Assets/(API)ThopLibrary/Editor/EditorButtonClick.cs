using UnityEditor;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using MasterDJ;
[CustomEditor(typeof(MouseClick))]
public class EditorButtonClick : Editor
{
    
    MouseClick myScript;
    public override void OnInspectorGUI()
    {     
        if(myScript==null)
        myScript = (MouseClick)target;
        myScript.ChoiceIndex = EditorGUILayout.Popup("Mode", myScript.ChoiceIndex, myScript._choices);

        switch (myScript.ChoiceIndex)
        { 
            case 1 :
                ParametorScale();
                break;
            case 2:
                ParametorRotation();
                break;
            case 3:
                ParametorDragDrop();
                break;

            default:              
                break;
        }
        DrawDefaultInspector();
    }

    void ParametorScale()
    {        
        myScript.retrunScale = EditorGUILayout.Toggle("OnRetrun", myScript.retrunScale);
        myScript.newScale = EditorGUILayout.Vector3Field("newScale", myScript.newScale);
        myScript.speedTime = EditorGUILayout.FloatField("speed", myScript.speedTime);
        myScript.timeAwake = EditorGUILayout.FloatField("Time Awake", myScript.timeAwake);
        myScript.curveScaleIn = EditorGUILayout.CurveField("Curve In", myScript.curveScaleIn);
        myScript.curveScaleOut = EditorGUILayout.CurveField("Curve Out", myScript.curveScaleOut);

    }

    void ParametorRotation()
    {
        myScript.onRotateOnly = EditorGUILayout.Toggle("OnRotateOnly", myScript.onRotateOnly);
        if (myScript.onRotateOnly)
        {
            myScript.angleRotate = EditorGUILayout.Vector3Field("Angle Rotate", myScript.angleRotate);
        }
        else
        {
            myScript.angleTo = EditorGUILayout.Vector3Field("Angle To", myScript.angleTo);
        }
        myScript.speedTime = EditorGUILayout.FloatField("speed", myScript.speedTime);
        myScript.curveRotateIn = EditorGUILayout.CurveField("Curve In",myScript.curveRotateIn);
    }

    void ParametorDragDrop()
    {
        myScript.snapTag = EditorGUILayout.Toggle("Snap Tag",myScript.snapTag);
        if (myScript.snapTag)
            myScript.Tag = EditorGUILayout.TextField("Tag",myScript.Tag);
      
    }
   
}

[CustomEditor(typeof(ControlVoulme))]
public class EditorButtonUpdateSound : Editor
{
    ControlVoulme myscript;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Update"))
        {
            myscript.UpdateDJ();
        }      
    }
}




