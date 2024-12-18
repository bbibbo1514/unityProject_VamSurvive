using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]  // 에디터 모드에서도 실행되도록
public class SpawnCicle : MonoBehaviour
{
    public GameObject[] objectsToArrange;  // 원형으로 배치할 오브젝트들
    public int objectCount = 10;           // 배치할 오브젝트의 개수
    public float radius = 5f;              // 원의 반지름

    void OnValidate()
    {
        ArrangeObjectsInCircle();
    }

    void ArrangeObjectsInCircle()
    {
        if (objectsToArrange.Length == 0) return;

        for (int i = 0; i < objectCount; i++)
        {
            if (i >= objectsToArrange.Length) return;

            float angle = i * Mathf.PI * 2 / objectCount;  // 각도 계산

            // 원형으로 x, z 좌표 계산
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            // 계산된 좌표를 기준으로 물체 배치
            Vector3 newPosition = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

            // 물체의 위치 업데이트
            objectsToArrange[i].transform.position = newPosition;
        }
    }

    // 에디터에서 원형 배치된 위치를 실시간으로 확인할 수 있도록 Gizmos 사용
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);  // 원형 경로 시각화
    }
}
