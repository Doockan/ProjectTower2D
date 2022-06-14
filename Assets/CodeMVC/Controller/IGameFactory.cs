using UnityEngine;

namespace CodeMVC.Controller
{
    public interface IGameFactory
    {
        GameObject CreateJoystick();
        GameObject CreatePlayer(GameObject at);
        GameObject CreatTrajectoryLineRenderer();
    }
}