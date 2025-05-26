using UnityEngine;

public class Resource : MonoBehaviour {
    public ResourceType resourceType;

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Drone"){
            collision.TryGetComponent(out Drone drone);
            if (drone != null && resourceType != ResourceType.none)
                StartCoroutine(drone.PickUp(this));
        }
    }
    
}