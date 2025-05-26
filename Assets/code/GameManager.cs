using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
    public static GameManager gameManager;
    void Awake(){
        gameManager = this;
        UpdateText();
    }
    public Resource stone, iron, emerald;
    public Base orangeBase, purpleBase;
    public TextMeshProUGUI emeraldText, ironText, stoneText;
    public TMP_InputField input;
    public Toggle ShowPath;
    public Slider speedSlider;
    public Slider countSlider;
    public List<Drone> drones;
    public List<ResourceSpawner> spawners;
    public ParticleSystem particle;
    public Drone orangeDronePrefab, purpleDronePrefab;

    public void UpdateText()
    {
        emeraldText.text = "<color=#280A28>" + purpleBase.emeraldCount + "    " + "<color=orange>" + orangeBase.emeraldCount;
        ironText.text = "<color=#280A28>" + purpleBase.ironCount + "    " + "<color=orange>" + orangeBase.ironCount;
        stoneText.text = "<color=#280A28>" + purpleBase.stoneCount + "    " + "<color=orange>" + orangeBase.stoneCount;
    }

    public void ChangeSpeedSpawn(){
        float speed = float.Parse(input.text);
        foreach (ResourceSpawner spawner in spawners){
            spawner.timer = speed;
        }
        input.text = null;
        input.placeholder.GetComponent<TextMeshProUGUI>().text = "Скорость ресурсов " + speed;
    }

    public void ChangeDronSpeed(){
        foreach (Drone drone in drones){
            drone.navMesh.speed = speedSlider.value;
        }
    }

    public void ChangeDronesCount(){
        foreach (Drone drone in drones){
            Destroy(drone.gameObject);
        }
        drones.Clear();

        for (byte c = 0; c < countSlider.value; c++){
            drones.Add(Instantiate(orangeDronePrefab));
            drones.Add(Instantiate(purpleDronePrefab));
        }
    } 
}