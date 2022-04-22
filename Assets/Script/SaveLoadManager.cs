using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using UnityEngine;

[RequireComponent(typeof(GameData))]
public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance { get; private set; }

    public GameData GameData { get; private set; }

    private string PlayerPath;
    private string SystemPath;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        GameData = GetComponent<GameData>();
        
        PlayerPath = $"{Application.dataPath}/PlayerData.json";
        SystemPath = $"{Application.dataPath}/SystemData.json";
    }

    public void Save<T>(T data = default) where T : IData
    {
        string json;
        string Path;

        if (data != null)
            GameData.RefrashData(data);
        
        switch (typeof(T))
        {
            case var type when type == typeof(PlayerData):
                json = JsonConvert.SerializeObject(GameData._PlayerData);
                Path = PlayerPath;
                break;
            case var type when type == typeof(SystemData):
                json = JsonConvert.SerializeObject(GameData._SystemData);
                Path = SystemPath;
                break;
            default:
                Debug.LogError($"Save : {typeof(T)}가 정의가 되지 않았습니다.");
                return;
        }
        
        //로컬에 저장하는 내용
        File.WriteAllText(Path, json);
    }

    public T Load<T>() where T : IData
    {
        string Path;

        switch (typeof(T))
        {
            case var type when type == typeof(PlayerData):
                Path = PlayerPath;
                break;
            case var type when type == typeof(SystemData):
                Path = SystemPath;
                break;
            default:
                Debug.LogError($"{MethodBase.GetCurrentMethod()} Load : {typeof(T)}가 정의되지 않았습니다.");
                return default;
        }
        
        if (!File.Exists(Path))
        {
            Debug.LogError($"Load : {typeof(T)} 파일을 찾을 수 없습니다.");
            return default;
        }

        string json = File.ReadAllText(Path);

        T Data = JsonConvert.DeserializeObject<T>(json);

        GameData.RefrashData(Data);

        return Data;
    }
}