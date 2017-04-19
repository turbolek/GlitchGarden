using UnityEngine;
using System.Collections;

public class StartVolume : MonoBehaviour {

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        if (PlayerPrefsManager.GetFirstLaunch())
        {
            musicManager.SetVolume(.8f);
            PlayerPrefsManager.SetDifficulty(2f);
            PlayerPrefsManager.SetFirstLaunch();
        } else {
            musicManager.SetVolume(PlayerPrefsManager.GetMasterVolume());
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
