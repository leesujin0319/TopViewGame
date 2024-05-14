using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public GameObject[] characters; // ĳ���͵��� ������ �迭
    public GameObject player;

    private void Update()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        this.transform.Translate(moveVector);
    }

    private void Start()
    {

        if (PlayerPrefs.HasKey("SelectedCharacterIndex"))
        {
            // PlayerPrefs���� ����� ĳ���� �ε��� ��������
            int selectedIndex = PlayerPrefs.GetInt("SelectedCharacterIndex");

            // ���õ� ĳ���͸� player�� ����
            if (selectedIndex >= 0 && selectedIndex < characters.Length)
            {
                player = characters[selectedIndex];
            }
        }
    }
}