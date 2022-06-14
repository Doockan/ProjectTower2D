using CodeMVC.AssetManagement;
using UnityEngine;

namespace CodeMVC.Controller
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }



        public GameObject CreateJoystick() =>
            Instantiate(AssetPath.HudPath);

        public GameObject CreatePlayer(GameObject at) => 
            Instantiate(AssetPath.HeroPath, at.transform.position);

        public GameObject CreatTrajectoryLineRenderer() => 
            Instantiate(AssetPath.TrajectoryLinePath);


        private GameObject Instantiate(string prefabPath, Vector3 at) => 
            _assetProvider.Instantiate(prefabPath, at);

        private GameObject Instantiate(string prefabPath) => 
            _assetProvider.Instantiate(path: prefabPath);
    }
}