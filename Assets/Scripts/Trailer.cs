using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailer : MonoBehaviour
{
    private HingeJoint joint;
    
    void Start()
    {
        joint = GetComponent<HingeJoint>();
    }

    public void ConnectTrailer(Rigidbody connectedRB)
    {
        joint.connectedBody = connectedRB;
    }

    public void DisconnectTrailer()
    {
        joint.connectedBody = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("TruckConnectionPoint"))
        {
            TrailerHandler.Instance.ConnectTrailer(this);
        }
    }
}
