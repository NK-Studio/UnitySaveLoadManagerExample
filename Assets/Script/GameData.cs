using System;
using UnityEngine;

public interface IData
{
}

[DisallowMultipleComponent]
public class GameData : MonoBehaviour
{
    public PlayerData _PlayerData { get; private set; }
    
    public SystemData _SystemData { get; private set; }

    private void Awake()
    {
        _PlayerData = new PlayerData();
        _SystemData = new SystemData();
    }

    public void RefrashData<T>(T Data) where T : IData
    {
        switch (Data.GetType())
        {
            case var type when type == typeof(PlayerData):
                _PlayerData = Data as PlayerData;
                break;
            case var type when type == typeof(SystemData):
                _SystemData = Data as SystemData;
                break;
            default:
                Debug.LogError($"RefrashData : {typeof(T)}가 정의되지 않았습니다.");
                break;
        }
    }
}