using UnityEditor;
using UnityEngine;

namespace P3D.Game
{
    [CustomEditor(typeof(MovingObject))]
    public class MovingObjectEditor : Editor
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        private static void DrawGizmo(MovingObject movingObject, GizmoType gizmoType)
        {
            if (!ShouldDraw(movingObject, gizmoType))
            {
                return;
            }

            if (!IsValid(movingObject))
            {
                return;
            }

            int pointsCount = movingObject.Points.Count;
            for (int i = 0; i < pointsCount - 1; i++)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(movingObject.Points[i].position, 0.5f);
                
                Gizmos.color = Color.red;
                Gizmos.DrawLine(movingObject.Points[i].position, movingObject.Points[i + 1].position);
            }
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(movingObject.Points[pointsCount - 1].position, 0.5f);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(movingObject.Points[pointsCount - 1].position, movingObject.Points.First().position);
        }

        private static bool IsValid(MovingObject movingObject)
        {
            return movingObject.Points != null || movingObject.Points.Count > 1;
        }

        private static bool ShouldDraw(MovingObject movingObject, GizmoType gizmoType)
        {
            if (gizmoType == GizmoType.Selected)
                return true;

            Transform parent = movingObject.transform.parent;
            if (parent == Selection.activeTransform)
                return true;

            for (int i = 0; i < parent.childCount; i++)
            {
                if (parent.GetChild(i) == Selection.activeTransform)
                    return true;
            }

            return false;
        }
    }
}