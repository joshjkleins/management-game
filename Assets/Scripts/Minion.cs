using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Minion : MonoBehaviour
{
    public MissionHandler missionHandler;
    public ScreenTransitions screenTransitions;

    public TMP_Text titleLevel;
    public Button missionButton;

    public enum MinionClass {Warrior, Mage, Rogue, Priest};

    public MinionClass minClass = MinionClass.Warrior;
    public int minLevel = 1;
    public List<Mission> allMissions = new List<Mission>();
    public string[] locations = {"Forest", "Desert", "Mountain", "Village", "Cave"};
    public string[] boss = {"Bandit King", "Spider Queen", "Mech Lord", "Vicious Bear", "Goblin Leader"};
    public bool onMission = false;

    // Start is called before the first frame update
    void Start()
    {
        minLevel = Random.Range(1, 15);
        minClass = (MinionClass)Random.Range(0, 4);

        switch(minClass.ToString()) {
            case("Warrior"):
                gameObject.GetComponent<Image>().color = new Color32(173, 106, 48, 255);
                break;
            case("Mage"):
                gameObject.GetComponent<Image>().color = new Color32(97, 230, 255, 255);
                break;
            case("Rogue"):
                gameObject.GetComponent<Image>().color = new Color32(38, 53, 123, 255);
                break;
            case("Priest"):
                gameObject.GetComponent<Image>().color = new Color32(255, 242, 47, 255);
                break;
            default:
                break;
        }
        titleLevel.text = $"{minClass.ToString()}: Level {minLevel.ToString()}";

        getMissions();
    }

    public void availableMissions() {
        screenTransitions.showMissions(allMissions, this);
    }

    public void getMissions() {
        // Determine how many missions to generate
        int numberOfMissions = 0;
        if((minLevel >= 1) && (minLevel <= 10)) {
            numberOfMissions = 3;
        } else {
            numberOfMissions = 5;
        }

        for(int i = 0; i < numberOfMissions; i++) {
            Mission myMission = new Mission(locations[Random.Range(0, locations.Length)], boss[Random.Range(0, boss.Length)], Random.Range(0, 50), Random.Range(100, 200));
            allMissions.Add(myMission);
        }
    }

    public void startMission(Mission mission) {
        Debug.Log($"Level {minLevel} {minClass} started mission in the {mission.location} with the end boss {mission.boss} and will receive {mission.experience}. This mission will take {mission.timeToComplete}.");
        missionButton.gameObject.SetActive(false);
        missionHandler.startMission(this, mission);
    }

    public void missionComplete(Mission mission) {
        Debug.Log($"Your {minClass} has completed their mission!!!");
        Debug.Log($"They have received {mission.experience} experience.");

        // Show progress of mission
        // reward screen
    }
}
