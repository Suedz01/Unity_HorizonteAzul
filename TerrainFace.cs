using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFace {

    ShapeGenerator _shapeGenerator;
    Mesh _mesh;
    int _resolution;
    Vector3 _localUp;
    Vector3 _axisA;
    Vector3 _axisB;

    public TerrainFace(ShapeGenerator shapeGenerator, Mesh mesh, int resolution, Vector3 localUp)
    {
        this._shapeGenerator = shapeGenerator;
        this._mesh = mesh;
        this._resolution = resolution;
        this._localUp = localUp;

        _axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        _axisB = Vector3.Cross(localUp, _axisA);
    }

    public void ConstructMesh()
    {
        Vector3[] vertices = new Vector3[_resolution * _resolution];
        int[] triangles = new int[(_resolution - 1) * (_resolution - 1) * 6];
        int triIndex = 0;

        for (int y = 0; y < _resolution; y++)
        {
            for (int x = 0; x < _resolution; x++)
            {
                int i = x + y * _resolution;
                Vector2 percent = new Vector2(x, y) / (_resolution - 1);
                Vector3 pointOnUnitCube = _localUp + (percent.x - .5f) * 2 * _axisA + (percent.y - .5f) * 2 * _axisB;
                Vector3 pointOnUnitSphere = pointOnUnitCube.normalized;
                vertices[i] = _shapeGenerator.CalculatePointOnPlanet(pointOnUnitSphere);

                if (x != _resolution - 1 && y != _resolution - 1)
                {
                    triangles[triIndex] = i;
                    triangles[triIndex + 1] = i + _resolution + 1;
                    triangles[triIndex + 2] = i + _resolution;

                    triangles[triIndex + 3] = i;
                    triangles[triIndex + 4] = i + 1;
                    triangles[triIndex + 5] = i + _resolution + 1;
                    triIndex += 6;
                }
            }
        }
        _mesh.Clear();
        _mesh.vertices = vertices;
        _mesh.triangles = triangles;
        _mesh.RecalculateNormals();
    }
}