using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Minion : MonoBehaviour
{
    public MissionHandler missionHandler;
    public ScreenTransitions screenTransitions;
    public Slider slider;

    public Coroutine theMission;

    public TMP_Text titleLevel;
    public Button missionButton;
    public Button returnButton;
    public TMP_Text rewardBank;
    public TMP_Text experienceText;
    public GameObject rewards;

    public enum MinionClass {Warrior, Mage, Rogue, Priest};

    public MinionClass minClass = MinionClass.Warrior;
    public int minLevel = 1;
    public List<Mission> allMissions = new List<Mission>();
    public string[] locations = {"Forest", "Desert", "Mountain", "Village", "Cave"};
    public string[] boss = {"Bandit King", "Spider Queen", "Mech Lord", "Vicious Bear", "Goblin Leader"};

    public int experienceToNextLevel;
    public int currentExp;
    public int experienceBank = 0;

    // Start is called before the first frame update
    void Start()
    {
        experienceToNextLevel = minLevel * 50;
        // minLevel = Random.Range(1, 15);
        minClass = (MinionClass)Random.Range(0, 4);

        switch(minClass.ToString()) {
            case("Warrior"):
                gameObject.GetComponent<Image>().color = new Color32(123, 94, 69, 255);
                break;
            case("Mage"):
                gameObject.GetComponent<Image>().color = new Color32(86, 174, 191, 255);
                break;
            case("Rogue"):
                gameObject.GetComponent<Image>().color = new Color32(70, 47, 101, 255);
                break;
            case("Priest"):
                gameObject.GetComponent<Image>().color = new Color32(179, 178, 55, 255);
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
            Mission myMission = new Mission(locations[Random.Range(0, locations.Length)], boss[Random.Range(0, boss.Length)], Random.Range(2, 3), Random.Range(1, 16));
            allMissions.Add(myMission);
        }
    }

    public void startMission(Mission mission) {
        Debug.Log($"Level {minLevel} {minClass} started mission in the {mission.location} with the end boss {mission.boss} and will receive {mission.experience}. This mission will take {mission.timeToComplete}.");
        missionButton.gameObject.SetActive(false);
        theMission = missionHandler.startMission(this, mission, slider);
        returnButton.gameObject.SetActive(true);
        rewards.gameObject.SetActive(true);
    }

    public void missionComplete(Mission mission) {
        experienceBank += mission.experience;
        updateRewardBank();

        startMission(mission);
    }

    public void gainExp(int exp) {
        int remainingExp = experienceToNextLevel - (exp + currentExp);

        if(remainingExp < 1) {
            minLevel++;
            currentExp = 0;
            titleLevel.text = $"{minClass.ToString()}: Level {minLevel.ToString()}";
            experienceToNextLevel = minLevel * 50;
            gainExp(remainingExp * -1);
        } else {
            currentExp += exp;
            experienceText.text = $"Experience: {currentExp} / {experienceToNextLevel}";
        }
    }

    public void returnFromMission() {
        // Stop mission
        StopCoroutine(theMission);
        slider.value = 0;
        gainExp(experienceBank);
        experienceBank = 0;
        returnButton.gameObject.SetActive(false);
        missionButton.gameObject.SetActive(true);
        rewardBank.text = "Exp: 0";
        rewards.gameObject.SetActive(false);
    }

    public void updateRewardBank() {
        rewardBank.text = $"Exp: {experienceBank}";
    }
}


// TODOS
// 2. After recalling from mission show rewards button/logic