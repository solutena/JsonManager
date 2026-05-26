# JsonManager

Unity에서 JSON 파일을 간단하게 저장하고 불러오기 위한 유틸리티입니다.

JsonManager는 Newtonsoft.Json을 사용하여 객체를 JSON으로 직렬화하고, 다시 객체로 역직렬화합니다.  
저장 경로의 폴더가 없으면 자동으로 생성되며, 파일 이름을 지정하지 않으면 타입의 `FullName`을 기본 파일명으로 사용합니다.


# 설치

<img width="399" height="299" alt="image" src="https://github.com/user-attachments/assets/5483dc30-2703-4bf5-a9a7-dff86c2398f6" />

1. URL 복사


![image](https://github.com/user-attachments/assets/f4060f1d-94aa-4a49-b001-e7a5e01316e1)

2. 패키지 매니저에서 Add Package from Git URL 선택


<img width="798" height="48" alt="image" src="https://github.com/user-attachments/assets/342a43dd-996d-4e3c-992f-68e7e7951a5e" />

3.  복사한 URL로 설치

## 주요 기능

### JSON 저장

객체를 JSON 파일로 저장합니다.

JsonManager.ExportJson(data, directory);

파일 이름을 직접 지정할 수도 있습니다.

JsonManager.ExportJson(data, directory, "SaveData");

### JSON 불러오기

JSON 파일을 읽어 객체로 변환합니다.

```var data = JsonManager.ImportJson<SaveData>(directory);```

파일 이름을 직접 지정할 수도 있습니다.

```var data = JsonManager.ImportJson<SaveData>(directory, "SaveData");```

파일이 없거나 불러오기에 실패하면 default 값을 반환합니다.

## 예제

```
[Serializable]
public class SaveData
{
    public int level;
    public string playerName;
}
```

```
SaveData saveData = new SaveData
{
    level = 10,
    playerName = "Player"
};

string directory = Application.persistentDataPath;

// 저장
JsonManager.ExportJson(saveData, directory, "SaveData");

// 불러오기
SaveData loadedData = JsonManager.ImportJson<SaveData>(directory, "SaveData");
```

## 참고

- JSON 직렬화에는 Newtonsoft.Json을 사용합니다.

- 저장 시 Formatting.Indented 옵션을 사용하여 읽기 쉬운 형태로 저장됩니다.

- 파일은 UTF-8 인코딩으로 저장됩니다.

- 저장 폴더가 없으면 자동으로 생성됩니다.
