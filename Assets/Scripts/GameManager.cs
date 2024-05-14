using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text characterNameTexts; // 캐릭터 위에 띄울 이름을 표시하는 Text 배열
    public FollowCamera followCamera; // FollowCamera 스크립트에 접근하기 위한 변수
    public GameObject changePanel;
    public GameObject characterPanel;
    public InputField playerChangeNameInput;
    public GameObject[] characterPrefabs; // 활성화할 캐릭터 프리팹 배열

    private void Start()
    {

        if (PlayerPrefs.HasKey("Nickname"))
        {
            // PlayerPrefs에서 저장된 닉네임 가져오기
            string nickname = PlayerPrefs.GetString("Nickname");
            Debug.Log(nickname);
            characterNameTexts.text = nickname; // 기본 이름 설정
        }

        if (PlayerPrefs.HasKey("SelectedCharacterIndex"))
        {
            // PlayerPrefs에서 저장된 캐릭터 인덱스 가져오기
            int selectedIndex = PlayerPrefs.GetInt("SelectedCharacterIndex");

            // 캐릭터 프리팹 활성화
            for (int i = 0; i < characterPrefabs.Length; i++)
            {
                characterPrefabs[i].SetActive(i == selectedIndex);
            }

        }
    }

    public void ActivePanel()
    {
        changePanel.SetActive(true);
    }


    public void ActiveCharacterPanel()
    {
        characterPanel.SetActive(true);
    }

    public void ChangeNickName()
    {
        string newname = playerChangeNameInput.text;
        PlayerPrefs.SetString("Nickname", newname);
        characterNameTexts.text = newname;
        changePanel.SetActive(false);

    }

    public void ChangeCharacter(int index)
    {
         PlayerPrefs.SetInt("SelectedCharacterIndex", index);
        characterPrefabs[index].SetActive(true);
        characterPanel.SetActive(false);
    }
}
