using System.IO;
using UnityEngine;

namespace CodeMVC.DataBase
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _enemyDataPath;
        [SerializeField] private string _inputDataPath;
        
        private PlayerData _player;
        private EnemyData _enemy;
        private Hud _input;
        
    

        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>(Path.Combine("Data", _playerDataPath));
                }

                return _player;
            }
        }
    

        public EnemyData Enemy
        {
            get
            {
                if (_enemy == null)
                {
                    _enemy = Load<EnemyData>(Path.Combine("Data", _enemyDataPath));
                }

                return _enemy;
            }
        }

        public Hud Input
        {
            get
            {
                if (_input == null)
                {
                    _input = Load<Hud>(Path.Combine("Data", _inputDataPath));
                }

                return _input;
            }
        }
        
        
        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}
