using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text characterNameTexts; // ĳ���� ���� ��� �̸��� ǥ���ϴ� Text �迭
    public FollowCamera followCamera; // FollowCamera ��ũ��Ʈ�� �����ϱ� ���� ����
    public GameObject changePanel;
    public GameObject characterPanel;
    public InputField playerChangeNameInput;
    public GameObject[] characterPrefabs; // Ȱ��ȭ�� ĳ���� ������ �迭

    private void Start()
    {

        if (PlayerPrefs.HasKey("Nickname"))
        {
            // PlayerPrefs���� ����� �г��� ��������
            string nickname = PlayerPrefs.GetString("Nickname");
            Debug.Log(nickname);
            characterNameTexts.text = nickname; // �⺻ �̸� ����
        }

        if (PlayerPrefs.HasKey("SelectedCharacterIndex"))
        {
            // PlayerPrefs���� ����� ĳ���� �ε��� ��������
            int selectedIndex = PlayerPrefs.GetInt("SelectedCharacterIndex");

            // ĳ���� ������ Ȱ��ȭ
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
