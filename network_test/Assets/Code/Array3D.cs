using UnityEngine;

public class Array3D : MonoBehaviour {
    public GameObject prefab;
	public Vector3 spacingOffset = new Vector3(2.0f, 2.0f, 2.0f);
	public Vector3 positionOffset = new Vector3(9.0f, 9.0f, 9.0f);
	public int count = 10;

	// START:
    void Start() {
        for (int x = 0; x < count; x++){
			for (int y = 0; y < count; y++){
				for (int z = 0; z < count; z++){
					Instantiate(prefab, new Vector3((x * spacingOffset.x) - positionOffset.x, (y * spacingOffset.y) - positionOffset.y, (z * spacingOffset.z) - positionOffset.z), Quaternion.identity);
				}
			}
		}
    }
}