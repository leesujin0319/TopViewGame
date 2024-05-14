using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartName : MonoBehaviour
{
    public GameObject[] characterPrefabs; // ĳ���� ������ �迭
    public Button[] characterButtons; // ĳ���� ���� ��ư �迭
    public InputField playerNameInput;

    private GameObject selectedCharacter; // ������ ĳ����
    private int selectedIndex = -1; // ������ ĳ������ �ε���, �ʱⰪ�� ���õ��� ���� ������ ����

    void Start()
    {

        // �� ĳ���� ��ư�� Ŭ�� �̺�Ʈ ����
        for (int i = 0; i < characterButtons.Length; i++)
        {
            int characterIndex = i; // Ŭ���� ���� �ذ��� ���� �ε��� ������ ������ ����
            characterButtons[i].onClick.AddListener(() => SelectCharacter(characterIndex));
        }
    }

    // ĳ���� ���� �� ȣ��Ǵ� �޼ҵ�
    void SelectCharacter(int index)
    {
        // ���õ� ĳ������ �ε����� ����
        selectedIndex = index;
        Debug.Log(index);
        // ������ ĳ���� ������ Ȱ��ȭ
        for (int i = 0; i < characterPrefabs.Length; i++)
        {
            characterPrefabs[i].SetActive(i == index);
        }

    }

    // ���� ���� ��ư Ŭ�� �� ȣ��Ǵ� �޼ҵ�
    public void StartGame()
    {
        if (selectedIndex != -1)
        {
            // ������ ĳ������ �г����� �����ͼ� ����
            string nickname = playerNameInput.text;
            PlayerPrefs.SetString("Nickname", nickname);

            // ������ ĳ������ �ε����� ����
            PlayerPrefs.SetInt("SelectedCharacterIndex", selectedIndex);

            // ���� ������ �̵�
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            Debug.LogWarning("ĳ���͸� �����ϼ���!");
        }
    }
}
