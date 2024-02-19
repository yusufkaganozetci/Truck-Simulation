using UnityEngine;

public class TrailerHandler : MonoBehaviour
{
    [SerializeField] Rigidbody truckRB;

    public Trailer currentTrailer = null;

    public static TrailerHandler Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ConnectTrailer(Trailer trailer)
    {
        if(trailer != currentTrailer)
        {
            currentTrailer = trailer;
            currentTrailer.ConnectTrailer(truckRB);
        }
    }

    public void DisconnectTrailer()
    {
        if(currentTrailer != null)
        {
            currentTrailer.DisconnectTrailer();
            currentTrailer = null;
        }
    }

}