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
        public Button resumeButton;

        public Slider BGSoundVolume;
        public Slider FXSoundVolume;

        public Image DelayImage;
        public void UIOnUpdate()
        {
            BGSoundVolume.value = PlayerPrefs.GetFloat("BGSoundVolume");
        }
        public void OpenStartGame()
        {
            gameStart.SetActive(false);
            StartCoroutine("FadeOpen");
        }

        IEnumerator FadeOpen()
        {
            var canvas =gameStart.GetComponent<CanvasGroup>();
            canvas.alpha = 0;
            float time = 0;
            while (time < 2)
            {
                time += Time.deltaTime;
                canvas.alpha = time/2;
                yield return null;
            }
            
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
            gameSettings.SetActive(!gameSettings.activeSelf);
            if (!gameSettings.activeSelf)
            {
            startButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(true);
            }
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