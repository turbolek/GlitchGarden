using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
    const string FIRST_LAUNCH_KEY = "first_launch";
	
	public static void SetMasterVolume (float volume) {
		if (volume < 1f && volume > 0f) {
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume out of range");
		}
	}
	
	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	public static void UnlockLevel (int level) {
		if (level < Application.levelCount - 1) {
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); 
		} else {
			Debug.LogError ("Trying to unlock level that is not n a build order");
		}
	}
	
	public static bool IsLevelUnlocked (int level) {
		if (level < Application.levelCount -1) {
			bool result = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1; 	
			return result;		
		} else {
			Debug.LogError ("Level not in build order");
			return false;
		}
	}
	
	public static void SetDifficulty (float difficulty) {
		if (difficulty == 1 || difficulty == 2 || difficulty == 3) {
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("Difficulty out of range");
		}
	}
	
	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}

    public static void SetFirstLaunch()
    {
        PlayerPrefs.SetInt(FIRST_LAUNCH_KEY, 0);
    }

    public static bool GetFirstLaunch ()
    {
        if (PlayerPrefs.GetInt(FIRST_LAUNCH_KEY) == 0)
        {
            return false;
        }
        SetFirstLaunch();
        return true;
    }
	
}
