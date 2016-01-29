using UnityEngine;
using UnityEditor;

public class windows : EditorWindow {
    [MenuItem("ThopFW/AddComponent/ButtonClick")]
    static void addbuttonclick()
    {
        GameObject SelectObject = Selection.activeGameObject;
        if (SelectObject != null)
            SelectObject.AddComponent<MouseClick>();
    }
    [MenuItem("ThopFW/AddComponent/PoolingContrainer")]
    static void addpoolingcontrainer()
    {
        GameObject SelectObject = Selection.activeGameObject;
        if (SelectObject != null)
            SelectObject.AddComponent<ContrainerPooling>();
    }
    [MenuItem("ThopFW/AddComponent/LoadLevelAsyncS")]
    static void addloadleveladdsyncs()
    {
        GameObject SelectObject = Selection.activeGameObject;
        if (SelectObject != null)
            SelectObject.AddComponent<LoadLevelAsyncS>();
    }
    [MenuItem("ThopFW/AddComponent/Carmera/CarmeraTagTarget")]
    static void addcarmeratagtarget()
    {
        Debug.Log("coming soon...");
      /*  GameObject SelectObject = Selection.activeGameObject;
        if (SelectObject != null)
            SelectObject.AddComponent<CarmeraTagTarget>();*/
        
    }
    [MenuItem("ThopFW/AddComponent/Carmera/OrbitCameraControl")]
    static void addthridpresincarmera()
    {
        GameObject SelectObject = Selection.activeGameObject;
        if (SelectObject != null)
            SelectObject.AddComponent<OrbitCameraControl>();
        if (!SelectObject.GetComponent<Camera>())
            SelectObject.GetComponent<OrbitCameraControl>().target = SelectObject.transform;
    }
    [MenuItem("ThopFW/Instantiate/DJ")]
    static void djinstan()
    {
      if(GameObject.Find("DJ")==null)
        {
            Instantiate(Resources.Load("System/DJ")as GameObject);          
        }
    }
   
}
