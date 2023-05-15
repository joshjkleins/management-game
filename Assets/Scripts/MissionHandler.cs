using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void startMission(Minion minion, Mission mission, Slider slider) {
        slider.value = 0;
        slider.maxValue = mission.timeToComplete;
        StartCoroutine(MissionCountdown(minion, mission, slider));
    }

    public IEnumerator MissionCountdown(Minion minion, Mission mission, Slider slider) {
        for (int ttc = mission.timeToComplete; ttc >= 1; ttc--) {
            yield return new WaitForSeconds(1.0f);
            slider.value++;
        }

        minion.missionComplete(mission);
    }
}
