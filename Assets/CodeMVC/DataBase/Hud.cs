using UnityEngine;

namespace CodeMVC.DataBase
{
    [CreateAssetMenu(fileName = "InputSettings", menuName = "Data/InputSettings")]
    public sealed class Hud : ScriptableObject
    {
        [SerializeField] private GameObject _hud;
        
        public GameObject HudPrefab => _hud;
    }
}