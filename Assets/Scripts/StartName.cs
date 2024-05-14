using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartName : MonoBehaviour
{
    public GameObject[] characterPrefabs; // 캐릭터 프리팹 배열
    public Button[] characterButtons; // 캐릭터 선택 버튼 배열
    public InputField playerNameInput;

    private GameObject selectedCharacter; // 선택한 캐릭터
    private int selectedIndex = -1; // 선택한 캐릭터의 인덱스, 초기값은 선택되지 않은 것으로 설정

    void Start()
    {

        // 각 캐릭터 버튼에 클릭 이벤트 연결
        for (int i = 0; i < characterButtons.Length; i++)
        {
            int characterIndex = i; // 클로저 문제 해결을 위해 인덱스 변수를 별도로 생성
            characterButtons[i].onClick.AddListener(() => SelectCharacter(characterIndex));
        }
    }

    // 캐릭터 선택 시 호출되는 메소드
    void SelectCharacter(int index)
    {
        // 선택된 캐릭터의 인덱스를 저장
        selectedIndex = index;
        Debug.Log(index);
        // 선택한 캐릭터 프리팹 활성화
        for (int i = 0; i < characterPrefabs.Length; i++)
        {
            characterPrefabs[i].SetActive(i == index);
        }

    }

    // 게임 시작 버튼 클릭 시 호출되는 메소드
    public void StartGame()
    {
        if (selectedIndex != -1)
        {
            // 선택한 캐릭터의 닉네임을 가져와서 저장
            string nickname = playerNameInput.text;
            PlayerPrefs.SetString("Nickname", nickname);

            // 선택한 캐릭터의 인덱스를 저장
            PlayerPrefs.SetInt("SelectedCharacterIndex", selectedIndex);

            // 메인 씬으로 이동
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            Debug.LogWarning("캐릭터를 선택하세요!");
        }
    }
}
