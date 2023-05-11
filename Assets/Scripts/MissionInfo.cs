using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionInfo : MonoBehaviour
{
    public TextMeshProUGUI areaText;
    public TextMeshProUGUI bossText;
    public TextMeshProUGUI chanceText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI rewardText;

    public Mission theMission;


    public void updateMissionText(Mission mission) {
        theMission = mission;
        areaText.text = $"Area: {mission.location}";
        bossText.text = $"Boss: {mission.boss}";
        chanceText.text = $"Success chance: 50%";
        timeText.text = $"Time: {mission.timeToComplete} seconds";
        rewardText.text = $"Rewards: \n {mission.experience}";
    }

    public void selectMission() {
        GameObject missionHandler = GameObject.Find("MissionHandler");
        missionHandler.GetComponent<MissionHandler>().missionSelection(theMission);
    }
}
