using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHandler : MonoBehaviour
{
    public string[] locations = {"Forest", "Desert", "Mountain", "Village", "Cave"};
    public string[] boss = {"Bandit King", "Spider Queen", "Mech Lord", "Vicious Bear", "Goblin Leader"};
    // success chance
    // time to complete
    // rewards

    public void getAvailableMissions(int level) {
        // Determine how many missions to get

        // loop and get a location/boss/calculate success/time and rewards
        int numberOfMissions = 0;
        if((level >= 1) && (level <= 10)) {
            numberOfMissions = 3;
        } else {
            numberOfMissions = 5;
        }

        for(int i = 0; i < numberOfMissions; i++) {
            Debug.Log($"Worked minion level {level}");
        }

    }
}
