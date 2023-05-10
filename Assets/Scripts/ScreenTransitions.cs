using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransitions : MonoBehaviour
{

    public GameObject minions;
    public GameObject missions;
    public MissionHandler missionHandler;

    public void showMissions(List<Mission> allMissions) {
        missionHandler.createMissions(allMissions);
        minions.SetActive(false);
        missions.SetActive(true);
    }

    public void showMinions() {
        minions.SetActive(true);
        missionHandler.removeMissions();
        missions.SetActive(false);
    }

}