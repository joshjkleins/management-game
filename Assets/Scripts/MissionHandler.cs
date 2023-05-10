using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHandler : MonoBehaviour
{
    public GameObject parentMission;
    public GameObject missionPrefab;

    // create x amount of missions under panel with updated text etc..

    public void createMissions(List<Mission> allMissions) {
        foreach (var mission in allMissions) {
            Debug.Log($"Location: {mission.location}. Boss: {mission.boss}");
            GameObject theMission = Instantiate(missionPrefab, parentMission.transform);
            // theMission.updateMissionText(mission);
            theMission.GetComponent<MissionInfo>().updateMissionText(mission);
        }
    }

    public void removeMissions() {
        foreach (Transform child in parentMission.transform) {
            Destroy(child.gameObject);
        }
    }
}
