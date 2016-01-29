using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class consoleMaster : MonoBehaviour
{
    public GameObject obj;
    public static bool openconsole = false;
    public int maxLines = 8;
    private Queue<string> queue = new Queue<string>();
    private string Mytext = "";
    public static consoleMaster instan;
    void Awake()
    {
        instan = this.gameObject.GetComponent<consoleMaster>();
        DontDestroyOnLoad(this.gameObject);
    }
    public static void instanConsole(string message)
    {
        if (instan == null)
        {
            GameObject instanObj = Instantiate(Resources.Load("System/ConsoleDebug", typeof(GameObject))) as GameObject;
            instan = instanObj.GetComponent<consoleMaster>();
            instan.NewMessage(message);
        }
    }

    public void NewMessage(string message)
    {
        if (queue.Count >= maxLines)
            queue.Dequeue();
        queue.Enqueue(message);
        Mytext = "";
        foreach (string st in queue)
            Mytext = Mytext + st + "\n";
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F7))
            openconsole = !openconsole;
    }

    void OnGUI()
    {
        if (openconsole)
        {
            GUI.Label(new Rect(5, (Screen.height - 150), 500f, 150f), Mytext, GUI.skin.textArea);
            if (GUI.Button(new Rect(0, Screen.height - 185, 50, 30), "Clear"))
                ClearList();
        }

    }
    private void ClearList()
    {
        queue.Clear();
        Mytext = "";
    }
}

   
   
    
   

