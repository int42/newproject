using UnityEngine;

public class Base : MonoBehaviour{
    public byte emeraldCount, ironCount, stoneCount;

    void OnTriggerEnter2D(Collider2D collision){
        collision.TryGetComponent(out Drone drone);
        if (drone == null || drone.caryngResource == 0) return;
        switch (drone.caryngResource)
        {
            case ResourceType.stone:
                stoneCount++;
                break;
            case ResourceType.iron:
                ironCount++;
                break;
            case ResourceType.emerald:
                emeraldCount++;
                break;
        }
        drone.caryngResource = 0;
        GameManager.gameManager.UpdateText();
        drone.target = Target.search;
        drone.targetText.text = "В поиске";
        Destroy(Instantiate(GameManager.gameManager.particle, transform.position, Quaternion.identity), 2);
    }
}