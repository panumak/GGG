using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using thopframwork;
public class PlayerEvent : MonoBehaviour {

    public UnityEvent eventA;
    GameObject sprite;
    Vector3 ScaleOp = new Vector3(0.25f,0.25f,0.25f);
    // Use this for initialization
    void Start()
    {
        sprite = Instantiate(Resources.Load("ProjectAssets/image/E_btn") as GameObject);
        sprite.transform.SetParent(gameObject.transform);
        sprite.transform.localPosition = new Vector3(-1.5f,2f,-1f);
    }
	   
    private Coroutine startEvent;
    void OnTriggerEnter(Collider other)
    {     
        if (other.tag == "Player")
        {
            iswork = true;
            ThopFW.TransformAll.ScaleTo(sprite,ScaleOp,0.25f,null,()=>{ startEvent = StartCoroutine(isWork()); });
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            iswork = false;
            StopCoroutine(isWork());
            ThopFW.TransformAll.ScaleTo(sprite, Vector3.zero, 0.25f,null,()=> {  });
        }
    }
    bool iswork = true;
    IEnumerator isWork()
    {
        while (iswork)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                ThopFW.TransformAll.ScaleTo(sprite, Vector3.zero, 0.25f, null, () => { eventA.Invoke(); StopCoroutine(isWork()); });
            }
            yield return null ;
        }
    }
    public void testinveoke()
    {
        ThopFW.TransformAll.ScaleTo(this.gameObject,Vector3.zero,0.25f);
    }

}
