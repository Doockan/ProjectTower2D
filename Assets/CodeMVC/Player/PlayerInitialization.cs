using CodeMVC.Controller;
using CodeMVC.Interface;
using UnityEngine;

namespace CodeMVC.Player
{
    internal sealed class PlayerInitialization : IInitialization
    {
        private const string InitialPointTag = "InitialPoint";

        private GameObject _player;
        private GameObject _playrPointOnTrajectoryRenderer;

        public PlayerInitialization(IGameFactory gameFactory)
        {
            _player = gameFactory.CreatePlayer(GameObject.FindWithTag(InitialPointTag));
            _playrPointOnTrajectoryRenderer = gameFactory.CreatTrajectoryLineRenderer();
        }
        
        public void Initialization()
        {
        }

        public GameObject GetPlayer()
        {
            return _player;
        }

        public GameObject GetTrajectoryLine()
        {
            return _playrPointOnTrajectoryRenderer;
        }
    }
}