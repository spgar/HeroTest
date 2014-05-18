using UnityEngine;
using System.Collections;

public class IntroScreen : MonoBehaviour
{
    public Texture2D backgroundTexture;
    public AudioClip testAudio;

	void Start()
    {
	
	}
	
	void Update()
    {
	
	}

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0.0f, 0.0f, Screen.width, Screen.height), backgroundTexture, ScaleMode.StretchToFill);

        GUI.Label(new Rect(Screen.width / 2.0f - 350.0f, Screen.height / 2.0f - 50.0f, 800.0f, 25.0f), "--> Audio is important in Hero Test. Use the button below to verify audio functionality/volume before clicking 'Play Game' <--");

        if (GUI.Button(new Rect(Screen.width / 2.0f - 100.0f, Screen.height / 2.0f - 20.0f, 200.0f, 50.0f), "Play Test Audio"))
        {
            audio.PlayOneShot(testAudio);
        }

        if (GUI.Button(new Rect(Screen.width / 2.0f - 100.0f, Screen.height / 2.0f + 60.0f, 200.0f, 50.0f), "Play Game"))
        {
            Application.LoadLevel("HeroTest");
        }
    }
}
