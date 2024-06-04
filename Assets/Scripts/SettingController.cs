using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingController : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider, _sfxSlider;
    [SerializeField] private Animator m_settingSceneAnimator;

    private void Start()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        _sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }
    // Start is called before the first frame update
    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }


    IEnumerator Load(string name)
    {
        m_settingSceneAnimator.SetTrigger("Close");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(name);
    }

    public void OnButtonClosePressed()
    {
        AudioManager.Instance.PlaySFX("MouseClick");

        if(Application.platform == RuntimePlatform.Android)
        {
            StartCoroutine(Load("Menu"));
        }
        else
        {
            StartCoroutine(Load("W_Menu"));
        }
    }
}
