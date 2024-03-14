using UnityEngine;

namespace _Main_Work.Dam.Scripts
{
    public class Trigger : MonoBehaviour
    {
        [Header("Dùng cho: DropTrap, MoveTrap, SuddenTrap")]
        public string note = "ae chú ý";
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var trap = transform.GetChild(0);
                trap.gameObject.SetActive(true);
            }
               
        }
        
        
        void OnDrawGizmos()
        {
            var position = transform.position;
            Gizmos.color = Color.white; // Màu của dấu cộng
            // Vẽ dấu cộng
            Gizmos.DrawLine(position + Vector3.left, position + Vector3.right);
            Gizmos.DrawLine(position + Vector3.up, position + Vector3.down);
        }
    }
}