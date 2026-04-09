using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private float step;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enter")
        {
            Vector3 p = other.transform.position;
            p.z += step;
            other.transform.position = p;
        }
    }


}
