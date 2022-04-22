using UnityEngine;

[System.Serializable]
public class PlayerData : IData
{   
    [field: SerializeField]
    public string Name { get; set; }
    
    [field: SerializeField]
    public int Gold { get; set; }

    public PlayerData()
    {
        Name = "홍길동";
        Gold = 0;
    }

    public PlayerData(string name, int gold)
    {
        Name = name;
        Gold = gold;
    }
}
