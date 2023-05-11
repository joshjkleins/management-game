using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHandler : MonoBehaviour
{
    public GameObject parentMission;
    public GameObject missionPrefab;
    public Minion currentMinion;
    public ScreenTransitions screenTransitions;


    public void createMissions(List<Mission> allMissions, Minion minion) {
        currentMinion = minion;
        foreach (var mission in allMissions) {
            GameObject theMission = Instantiate(missionPrefab, parentMission.transform);
            theMission.GetComponent<MissionInfo>().updateMissionText(mission);
        }
    }

    public void removeMissions() {
        currentMinion = null;
        foreach (Transform child in parentMission.transform) {
            Destroy(child.gameObject);
        }
    }

    public void missionSelection(Mission myMission) {
        currentMinion.startMission(myMission);
        screenTransitions.showMinions();
    }

    public void startMission(Minion minion, Mission mission) {
        StartCoroutine(MissionCountdown(minion, mission));
        
    }

    public IEnumerator MissionCountdown(Minion minion, Mission mission) {
        for (int ttc = mission.timeToComplete; ttc >= 1; ttc--) {
            if(ttc % 10 == 0) {
                Debug.Log($"Level {minion.minLevel} {minion.minClass} has {ttc} seconds remaining on their mission.");
            }
            
            yield return new WaitForSeconds(1.0f);
        }

        minion.missionComplete(mission);
    }
}
