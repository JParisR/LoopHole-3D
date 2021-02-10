using UnityEngine;

public static class Utilities {

    // Genera un Vector3 con valores aleatorios en el rango [-limit, limit]
    public static Vector3 RandomVector3(Vector3 limit)
    {
        return new Vector3(
                            Random.Range(-limit.x, limit.x),
                            Random.Range(-limit.y, limit.y),
                            Random.Range(-limit.z, limit.z)
                        );
    }

    // Genera un Quaternion con ángulos aleatorios
    public static Quaternion RandomAngle()
    {
        return Quaternion.Euler(
                            Random.Range(0, 360),
                            Random.Range(0, 360),
                            Random.Range(0, 360)
                        );
    }
}
