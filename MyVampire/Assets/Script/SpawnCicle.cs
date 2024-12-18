using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]  // ������ ��忡���� ����ǵ���
public class SpawnCicle : MonoBehaviour
{
    public GameObject[] objectsToArrange;  // �������� ��ġ�� ������Ʈ��
    public int objectCount = 10;           // ��ġ�� ������Ʈ�� ����
    public float radius = 5f;              // ���� ������

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

            float angle = i * Mathf.PI * 2 / objectCount;  // ���� ���

            // �������� x, z ��ǥ ���
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            // ���� ��ǥ�� �������� ��ü ��ġ
            Vector3 newPosition = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

            // ��ü�� ��ġ ������Ʈ
            objectsToArrange[i].transform.position = newPosition;
        }
    }

    // �����Ϳ��� ���� ��ġ�� ��ġ�� �ǽð����� Ȯ���� �� �ֵ��� Gizmos ���
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);  // ���� ��� �ð�ȭ
    }
}
