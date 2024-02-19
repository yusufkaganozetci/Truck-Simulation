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
        if (other.CompareTag("TruckConnectionPoint"))
        {
            TrailerHandler.Instance.ConnectTrailer(this);
        }
    }

}