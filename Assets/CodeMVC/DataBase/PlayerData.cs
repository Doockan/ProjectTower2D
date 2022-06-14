using UnityEngine;

namespace CodeMVC.DataBase
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/UnitSettings")]
    public sealed class PlayerData : ScriptableObject
    {
        public string PlayerPath;
    }
}