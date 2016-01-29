using UnityEngine;
using System.Collections;

public class LoadLevelAsyncS : MonoBehaviour
{
    public string level;
    private string progress = "";
    private bool isLoading = false;
    private bool doneLoading = false;
    private bool allowLoading = false;
    private float isProgresss = 0f;
    public bool loadAuto = false;
   
    public void startLoad()
    {
        if (!isLoading)
        {
            isLoading = true;
            StartCoroutine(LoadRoutine());
        }
    }
    public void LoadContinue()
    {
        if (isLoading)
        {
            if (doneLoading)
            {
                allowLoading = true;
                StartCoroutine(LoadRoutine());
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        { startLoad(); }
        if (Input.GetKeyUp(KeyCode.W))
        { LoadContinue(); }
    }

    public float isProgress()
    {
        return isProgresss;
    }

    private IEnumerator LoadRoutine()
    {
        AsyncOperation op = Application.LoadLevelAsync(level);
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            isProgresss = op.progress;
            yield return null;
        }
        if (loadAuto)
            allowLoading = true;
          else
            doneLoading = true;

        while (!allowLoading)
        {
            isProgresss = op.progress;
            yield return null;
        }
        op.allowSceneActivation = true;
    }
}