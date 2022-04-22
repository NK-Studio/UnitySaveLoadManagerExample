using UnityEngine;

[System.Serializable]
public class SystemData : IData
{
    [field: SerializeField]
    public float BGMVolume { get; set; }
    
    [field: SerializeField]
    public float SFXVolume { get; set; }

    public SystemData(float bgmVolume, float sfxVolume)
    {
        BGMVolume = bgmVolume;
        SFXVolume = sfxVolume;
    }

    public SystemData()
    {
        BGMVolume = 100f;
        SFXVolume = 100f;
    }
}
