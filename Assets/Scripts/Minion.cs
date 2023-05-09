using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Minion : MonoBehaviour
{
    public MissionHandler missionHandler;
    public ScreenTransitions screenTransitions;
    public enum MinionClass {Warrior, Mage, Rogue, Priest}
    public TMP_Text titleLevel;

    public MinionClass minClass;
    public int minLevel;

    // Start is called before the first frame update
    void Start()
    {
        minLevel = Random.Range(1, 15);
        minClass = (MinionClass)Random.Range(0, 3);
        titleLevel.text = $"{minClass.ToString()}: Level {minLevel.ToString()}";

        // generateMissions();
    }

    public void availableMissions() {
        missionHandler.getAvailableMissions(minLevel);
        screenTransitions.showMissions();
    }

    void generateMissions() {
        // generate list of available missions
        // save data to this minion

        // when button is clicked pass that data to missions object to display
    }

}
