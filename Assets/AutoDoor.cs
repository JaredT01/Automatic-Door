using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public Vector3 DoorMove;
    private bool Opening;
    private bool Closing;
    private Vector3 Moved = new Vector3(0,0,0);
    private Vector3 moveIncrement;
    private Vector3 OriginalPosition;
    private Vector3 BlankVector = new Vector3(0, 0, 0);
    private bool FullyOpened;

    public GameObject Door;

    private void Start()
    {
        OriginalPosition = Door.gameObject.transform.position;
    }
    private void Update()
    {
        if(Opening == true)
        {
            moveIncrement = DoorMove * Time.deltaTime;
            if(DoorMove.x <= Moved.x)
            {
                if (DoorMove.y <= Moved.y)
                {
                    if (DoorMove.z <= Moved.z)
                    {
                        Opening = false;
                        FullyOpened = true;
                    }
                    else
                    {
                        Door.gameObject.transform.Translate(moveIncrement, Space.World);

                    }
                }
                else
                {
                    Door.gameObject.transform.Translate(moveIncrement, Space.World);

                }
            }
            else
            {
            Door.gameObject.transform.Translate(moveIncrement, Space.World);

            }
            Moved = Moved + moveIncrement;
        } else if (Closing == true)
        {
            if(FullyOpened == true)
            {
                Moved = DoorMove * 1.5f;
                FullyOpened = false;
            }
            else
            {

            }
            moveIncrement = -DoorMove * Time.deltaTime;
            if (OriginalPosition.x >= Moved.x)
            {
                if (OriginalPosition.y >= Moved.y)
                {
                    if (OriginalPosition.z >= Moved.z)
                    {
                        Closing = false;
                    }
                    else
                    {
                        Door.gameObject.transform.Translate(moveIncrement, Space.World);

                    }
                }
                else
                {
                    Door.gameObject.transform.Translate(moveIncrement, Space.World);

                }
            }
            else
            {
                Door.gameObject.transform.Translate(moveIncrement, Space.World);

            }
            Moved = Moved + moveIncrement;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Opening = true;
        Moved = BlankVector;
        FullyOpened = false;
       // this.gameObject.transform.Translate(DoorMove, Space.World);
    }
    private void OnTriggerExit(Collider other)
    {
        Closing = true;
        
    }
}
