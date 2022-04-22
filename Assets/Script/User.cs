using UnityEngine;

public class User : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //현재 게임데이터를 Json으로 로컬에 저장함
            SaveLoadManager.Instance.Save<PlayerData>();
            Debug.Log("데이터를 저장했습니다.");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //값을 변경하고 게임데이터를 Json으로 로컬에 저장함
            PlayerData playerData = new PlayerData("파이리", 100);
            SaveLoadManager.Instance.Save<PlayerData>(playerData);
            Debug.Log("데이터를 변경하고 저장했습니다.");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //로컬 저장소에서 파일을 불러와서 게임 데이터를 로드함
            SaveLoadManager.Instance.Load<PlayerData>();
            Debug.Log("GameData-PlayerData를 저장한 값으로 불러오기 했습니다.");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //로컬 저장소에서 파일을 불러와서 게임 데이터를 로드하고 그것에 맞는 데이터를 전달한다.
            PlayerData data = SaveLoadManager.Instance.Load<PlayerData>();
            Debug.Log("GameData-PlayerData를 저장한 값으로 불러오고 값을 객체에 할당했습니다.");

            Debug.Log($"이름 : {data.Name}");
            Debug.Log($"재화 : {data.Gold}");
        }
    }
}