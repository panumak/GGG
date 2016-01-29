using UnityEngine;
using System.Collections;

public class StaticCoroutine : MonoBehaviour {

    static public StaticCoroutine instance;
    void Awake()
    { 
        instance = this; 
    }
    IEnumerator PerformCoroutine()
    { 
        while (true)
        {
            yield return 0;
        }
    }
}
