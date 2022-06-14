using UnityEngine;

namespace CodeMVC.Player
{
    public class TrajectoryRenderer : MonoBehaviour
    {
        private LineRenderer _line;

        private void Awake()
        {
            _line = GetComponent<LineRenderer>();
        }

        public void ShowTrajectory(Vector3 origin, Vector3 direction)
        {
            Vector3[] points = new Vector3[100];
            _line.positionCount = points.Length;
            for (int i = 0; i < points.Length; i++)
            {
                float time = i* 0.1f;
                points[i] = origin + direction * time + Physics.gravity * time * time / 2f;
            }
        
            _line.SetPositions(points);
        
        }
    }
}