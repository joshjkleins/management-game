using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Minion : MonoBehaviour
{
    public MissionHandler missionHandler;
    public ScreenTransitions screenTransitions;
    public enum MinionClass {Warrior, Mage, Rogue, Priest};
    public TMP_Text titleLevel;

    public MinionClass minClass;
    public int minLevel;

    public List<Mission> allMissions = new List<Mission>();

    public string[] locations = {"Forest", "Desert", "Mountain", "Village", "Cave"};
    public string[] boss = {"Bandit King", "Spider Queen", "Mech Lord", "Vicious Bear", "Goblin Leader"};

    // Start is called before the first frame update
    void Start()
    {
        minLevel = Random.Range(1, 15);
        minClass = (MinionClass)Random.Range(0, 3);
        titleLevel.text = $"{minClass.ToString()}: Level {minLevel.ToString()}";

        getMissions();
    }

    public void availableMissions() {
        screenTransitions.showMissions(allMissions);
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
            Mission myMission = new Mission(locations[Random.Range(0, locations.Length)], boss[Random.Range(0, boss.Length)], 30, 100);
            allMissions.Add(myMission);
        }
    }
}
