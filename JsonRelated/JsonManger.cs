using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;


public class JsonManger : MonoBehaviour
{

    List<Students> studentslist = new List<Students>();


    //手动创建一个json文件
    public void Initalize()
    {
        for (int i = 0; i < 5; i++)
        {
            Students s = new Students();
            s.PLayerName = (i + 50).ToString();
            s.ID = i;
            s.Age = Random.Range(15, 20);
            studentslist.Add(s);
        }

        Persons.Instance.students = studentslist.ToArray();
        Persons.Instance.Amount = 100;
        string path = Application.streamingAssetsPath + "/studentsdata.json";
        if (!File.Exists(path))
        {

            FileStream fs = File.Create("studentsdata.json");
             fs.Close();
            Debug.Log("filecreated");
        }
        string json = JsonUtility.ToJson(Persons.Instance);
        File.WriteAllText(path, json, Encoding.UTF8);
        Debug.Log("jsoncreated");
    }


    public void LoadDataFromJson()
    {
        var data = File.ReadAllText(Application.streamingAssetsPath + "/studentsdata.json");
        Persons.Instance = JsonUtility.FromJson<Persons>(data as string);
        for (int i = 0; i < Persons.Instance.students.Length; i++)
        {
            Debug.Log(Persons.Instance.students[i].Age);
        }
    }

}
