using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourGenerator {

    ColourSettings _settings;
    Texture2D _texture;
    const int TextureResolution = 50;

    public void UpdateSettings(ColourSettings settings)
    {
        this._settings = settings;
        if (_texture == null)
        {
            _texture = new Texture2D(TextureResolution, 1);
        }
    }

    public void UpdateElevation(MinMax elevationMinMax)
    {
        _settings.planetMaterial.SetVector("_elevationMinMax", new Vector4(elevationMinMax.Min, elevationMinMax.Max));
    }

    public void UpdateColours()
    {
        Color[] colours = new Color[TextureResolution];
        for (int i = 0; i < TextureResolution; i++)
        {
            colours[i] = _settings.gradient.Evaluate(i / (TextureResolution - 1f));
        }
        _texture.SetPixels(colours);
        _texture.Apply();
        _settings.planetMaterial.SetTexture("_texture", _texture);
    }
}