using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Drone : MonoBehaviour{
    public Team team;
    public ResourceType caryngResource;
    public NavMeshAgent navMesh;
    public Target target;
    public TextMeshPro targetText;
    public LineRenderer lineRenderer;

    void Start(){
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;
        target = Target.search;
        targetText.text = "В поиске";
    }

    public IEnumerator PickUp(Resource resource){
        if (caryngResource != ResourceType.none) yield return null;
        yield return new WaitForSeconds(2);
        caryngResource = resource.resourceType;
        Destroy(resource.gameObject);
        GoHome();
    }
    
    GameObject FindNearestResource(){
        GameObject[] resources = GameObject.FindGameObjectsWithTag("Resource");
        GameObject nearest = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        foreach (GameObject res in resources){
            float dist = Vector3.Distance(currentPos, res.transform.position);
            if (dist < minDistance){
                minDistance = dist;
                nearest = res;
            }
        }
        return nearest;
    }

    public void GoHome(){
        target = Target.home;
        if (team == Team.orange)
            navMesh.SetDestination(GameManager.gameManager.orangeBase.transform.position);
        else
            navMesh.SetDestination(GameManager.gameManager.purpleBase.transform.position);
        
        targetText.text = "Домой";
    }

    void FixedUpdate(){
        if (target == Target.search){
            try { navMesh.SetDestination(FindNearestResource().transform.position); }
            catch { }
        }
        
        if (navMesh.hasPath && GameManager.gameManager.ShowPath.isOn){
            NavMeshPath path = navMesh.path;
            lineRenderer.positionCount = path.corners.Length;
            for (int i = 0; i < path.corners.Length; i++){
                lineRenderer.SetPosition(i, path.corners[i]);
            }
        }
        else
            lineRenderer.positionCount = 0;
        
    }

}

public enum Team{
    orange,
    purple
}

public enum Target{
    none,
    search,
    home
}
