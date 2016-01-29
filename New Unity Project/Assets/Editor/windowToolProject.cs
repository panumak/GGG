using UnityEngine;
using UnityEditor;

public class windowToolProject : EditorWindow
{
    [MenuItem("ThisProject/AddCompoment/EventObject")]
    static void addeventobject()
    {
        GameObject selectObj = Selection.activeGameObject;
        if (selectObj != null)
            selectObj.AddComponent<PlayerEvent>();
    }

}
