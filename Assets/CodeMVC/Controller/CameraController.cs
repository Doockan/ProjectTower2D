using CodeMVC.Interface;
using UnityEngine;

namespace CodeMVC.Controller
{
    internal sealed class CameraController : ILateExecute
    {
        private readonly GameObject _playerProvider;
        private readonly Transform _mainCamera;
        private readonly Vector3 _offset;

        public CameraController(GameObject playerProvider, Transform mainCamera)
        {
            _playerProvider = playerProvider;
            _mainCamera = mainCamera;
            _offset = _mainCamera.position - _playerProvider.transform.position;
        }

        public void LateExecute(float deltaTime)
        {
            _mainCamera.position = new Vector3(_playerProvider.transform.position.x, _mainCamera.position.y, _offset.z);
        }
    }
}
