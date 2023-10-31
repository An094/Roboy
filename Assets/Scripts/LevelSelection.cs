using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private Button[] lvlButtons;
    [SerializeField] private Image[] lvlButtonsLockedImage;
    [SerializeField] private Image[] lvlButtonsUnlockedImage;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScene();
    }

    private void UpdateScene()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < lvlButtons.Length; ++i)
        {
            if (i + 2 > levelAt)
            {
                lvlButtonsLockedImage[i].enabled = true;
                lvlButtonsUnlockedImage[i].enabled = false;
                lvlButtons[i].interactable = false;
            }
            else
            {
                lvlButtonsLockedImage[i].enabled = false;
                lvlButtonsUnlockedImage[i].enabled = true;
                lvlButtons[i].interactable = true;
            }
        }
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index + 1);
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        UpdateScene();
    }
}
