using System;
using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;

public class JsonManager
{
	public static void ExportJson<T>(T data, string directory) => ExportJson(data, directory, typeof(T).FullName);
	public static void ExportJson<T>(T data, string directory, string fileName)
	{
		string path = Path.Combine(directory, $"{fileName}.json");
		try
		{
			Directory.CreateDirectory(directory);
			string json = JsonConvert.SerializeObject(data, Formatting.Indented);
			File.WriteAllText(path, json, Encoding.UTF8);
			Debug.Log($"Exported JSON for {fileName} to: {path}");
		}
		catch (Exception ex)
		{
			Debug.LogError($"Failed to export JSON for {fileName}: {ex.Message}");
		}
	}

	public static T ImportJson<T>(string directory) => ImportJson<T>(directory, typeof(T).FullName);
	public static T ImportJson<T>(string directory, string fileName)
	{
		string path = Path.Combine(directory, $"{fileName}.json");
		try
		{
			if (File.Exists(path))
			{
				string json = File.ReadAllText(path, Encoding.UTF8);
				return JsonConvert.DeserializeObject<T>(json);
			}
			Debug.LogWarning($"JSON file not found for {fileName}: {path}");
			return default;
        }
        catch (Exception ex)
		{
			Debug.LogError($"Failed to import JSON for {fileName}: {ex.Message}");
			return default;
        }
    }
}