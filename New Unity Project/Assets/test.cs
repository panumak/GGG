using UnityEngine;
using System.Collections;
using thopframwork;

public class test : MonoBehaviour
{
    RaycastHit hit;
    float distanceToGround = 0;
    public float speed = 5;
    public AnimationCurve curve;
    public AudioClip testtimeBG;
    private int layerMarkFloor;
    void Start()
    {
        layerMarkFloor = LayerMask.NameToLayer("floor");
    }
    
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {               
                if (hit.transform.gameObject.layer == layerMarkFloor)
                {
                    isDraw = true;
                    if (isDraws != null)
                        StopCoroutine(isDraws);
                    isDraws = StartCoroutine(drawLineE());

                    Vector3 relativePos = hit.point - transform.position;
                    Quaternion rotation = Quaternion.LookRotation(relativePos);
                    gameObject.transform.GetChild(0).transform.rotation = new Quaternion(rotation.x, rotation.y, 0f, rotation.w);

                    ThopFW.TransformAll.TranslateTo(this.gameObject, new Vector3(hit.point.x, transform.position.y, hit.point.z), cuSpeed(hit.point), curve);
                }
               
            }
        }
    }
    bool isDraw =false;
    Coroutine isDraws;
    IEnumerator drawLineE()
    {
        while (isDraw)
        {
            Debug.DrawLine(gameObject.transform.position, hit.point, Color.blue);
            yield return null;
        }
    }

    IEnumerator rotateTo (System.Action onFinish)
    {
        Vector3 relativePos = hit.point - transform.position;
        while (true)
        {
            yield return null;
        }
        onFinish();
    }

    float cuSpeed(Vector3 dis)
    {
        float dist = Vector3.Distance(gameObject.transform.position,dis);
        float value = dist / speed;
        return value;
    }
}
