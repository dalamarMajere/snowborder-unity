using Player;
using UnityEngine;

namespace Surface
{
    [RequireComponent(typeof(SurfaceEffector2D))]
    public class SurfaceController : MonoBehaviour
    {
        [SerializeField] private FloatVariable surfaceSpeedVariable;

        private SurfaceEffector2D _surfaceEffector2D;
        
        private void Start()
        {
            _surfaceEffector2D = GetComponent<SurfaceEffector2D>();
        }

        private void Update()
        {
            _surfaceEffector2D.speed = surfaceSpeedVariable.Value;
        }
    }
}