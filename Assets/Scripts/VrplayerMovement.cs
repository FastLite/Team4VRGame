using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class VrplayerMovement : MonoBehaviour
{

    public SteamVR_Action_Vector2 touchpadInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDir = Player.instance.hmdTransform.TransformDirection(new Vector3(touchpadInput.axis.x, 0, touchpadInput.axis.y));
        transform.position += Vector3.ProjectOnPlane(Time.deltaTime * movementDir * 2f, Vector3.up);
    }
}

