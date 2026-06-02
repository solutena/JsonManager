using System;
using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;

public class JsonManager
{
	public static void Export<T>(T data, string directory, JsonSerializerSettings settings = null) => Export(data, directory, typeof(T).FullName, settings);
	public static void Export<T>(T data, string directory, string fileName, JsonSerializerSettings settings = null)
	{
		string path = Path.Combine(directory, $"{fileName}.json");
		try
		{
			Directory.CreateDirectory(directory);
			string json = JsonConvert.SerializeObject(data, settings);
			File.WriteAllText(path, json, Encoding.UTF8);
			Debug.Log($"Exported JSON for {fileName} to: {path}");
		}
		catch (Exception ex)
		{
			Debug.LogError($"Failed to export JSON for {fileName}: {ex}");
		}
	}

	public static T Import<T>(string directory, JsonSerializerSettings settings = null) => Import<T>(directory, typeof(T).FullName, settings);
	public static T Import<T>(string directory, string fileName, JsonSerializerSettings settings = null)
	{
		string path = Path.Combine(directory, $"{fileName}.json");
		try
		{
			if (File.Exists(path))
			{
				string json = File.ReadAllText(path, Encoding.UTF8);
				return JsonConvert.DeserializeObject<T>(json, settings);
			}
			Debug.LogWarning($"JSON file not found for {fileName}: {path}");
			return default;
        }
        catch (Exception ex)
		{
			Debug.LogError($"Failed to import JSON for {fileName}: {ex}");
			return default;
        }
    }
}