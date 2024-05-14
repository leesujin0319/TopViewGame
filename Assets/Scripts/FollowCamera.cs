using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public GameObject[] characters; // 캐릭터들을 저장할 배열
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
            // PlayerPrefs에서 저장된 캐릭터 인덱스 가져오기
            int selectedIndex = PlayerPrefs.GetInt("SelectedCharacterIndex");

            // 선택된 캐릭터를 player로 설정
            if (selectedIndex >= 0 && selectedIndex < characters.Length)
            {
                player = characters[selectedIndex];
            }
        }
    }
}