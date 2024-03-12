using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace _Main_Work.Dam.Scripts
{
    public class UI_Controller:MonoBehaviour
    {
        public GameObject gameStart;
        public GameObject gameSettings;
        public GameObject gameEnd;

        public Button pauseGame;
        public Button startButton;

        public Slider BGSoundVolume;
        public Slider FXSoundVolume;

        public Image DelayImage;
        public void UIOnUpdate()
        {
            BGSoundVolume.value = PlayerPrefs.GetFloat("BGSoundVolume");
        }
        public void OpenStartGame()
        {
            gameStart.SetActive(true);
        }


        public IEnumerator OpenDelayScene()
        {
            DelayImage.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            DelayImage.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);

        }
        public void OpenSetting()
        {
            gameSettings.SetActive(true);
        }

        public void OpenPause()
        {
            pauseGame.gameObject.SetActive(true);
        }

        public void OpenEndGame()
        {
            gameEnd.SetActive(true);
        }
      
    }
}