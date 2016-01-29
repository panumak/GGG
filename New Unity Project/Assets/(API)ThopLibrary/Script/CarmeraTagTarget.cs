using UnityEngine;
using System.Collections;

public class CarmeraTagTarget : MonoBehaviour
{
    public GameObject targetFollow;
    public static CarmeraTagTarget MainFollowTarget;
    public KeyCode MouseButtonLeft = KeyCode.Mouse0;
    public KeyCode MouseButtonRight = KeyCode.Mouse1;
    // Use this for initialization
    void Start()
    {
        MainFollowTarget = this.gameObject.GetComponent<CarmeraTagTarget>();
    }


    void Update()
    {
        if (Input.GetKeyUp(MouseButtonLeft))
        {

        }
        else if (Input.GetKeyUp(MouseButtonRight))
        {

        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0) // forward
        {
            //  Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize-1, 6);
            Camera.main.fieldOfView = Mathf.Min(Camera.main.fieldOfView - 1, 6);
            print(Mathf.Min(Camera.main.fieldOfView - 1, 6));
        }
        else
        {
            Camera.main.fieldOfView = Mathf.Min(Camera.main.fieldOfView - 1, 6);
        }
        
    }



}
