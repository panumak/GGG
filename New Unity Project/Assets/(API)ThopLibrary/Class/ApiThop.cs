using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text; 

namespace thopframwork
{
    /// <summary>
    /// This Class is my API
    /// </summary>
    public class ThopFW
    {
        public static void Debug(object Message)
        {
#if UNITY_EDITOR
            if (!consoleMaster.openconsole)
            {
                UnityEngine.Debug.Log(Message);
            }
            else
            {
                if (consoleMaster.instan != null)
                    consoleMaster.instan.NewMessage(Message.ToString());
                else
                    consoleMaster.instanConsole(Message.ToString());


            }
#else
         if (consoleMaster.openconsole)
          if (consoleMaster.instan != null)
                consoleMaster.instan.NewMessage(Message.ToString());
            else
                consoleMaster.instanConsole(Message.ToString());
#endif
        }

        public static int Random(int min, int max)
        {
            return UnityEngine.Random.Range(min, max + 1);
        }
        public static float RandomFloat(float min, float max)
        {
            return UnityEngine.Random.Range(min, max + 1);
        }
        public static Vector2 RandomVector2(float minAll ,float maxAll)
        {
            return new Vector2(RandomFloat(minAll,maxAll),RandomFloat(minAll,maxAll));
        }
        public static Vector2 RandomVector2(float minX,float maxX,float minY,float maxY)
        {
            return new Vector2(RandomFloat(minX, maxX), RandomFloat(minY, maxY));
        }
        public static Vector3 RandomVector3(float minAll, float maxAll)
        {
            return new Vector3(RandomFloat(minAll,maxAll), RandomFloat(minAll, maxAll), RandomFloat(minAll, maxAll));
        }
        public static Vector3 RandomVector3(float minX,float maxX,float minY,float maxY,float minZ,float maxZ)
        {
            return new Vector3(RandomFloat(minX, maxX), RandomFloat(minY, maxY), RandomFloat(minZ, maxZ));
        }

        [Serializable]
        public class SortArrayAndList
        {
            public static void SortMaxToMin<T>(Comparer<T> test)
            {
                ThopFW.Debug("Not Work 555!!!");
            }

            public static void SortMinToMax<T>(T[] array = null, Action onFinsih = null)
            {
                Array.Sort(array);
                if (onFinsih != null)
                    onFinsih();
            }

            public static void SwitchIndexInList<T>(List<T> index, Action onFinsih = null)
            {
                int maxCount = index.Count;
                for (int i = 0; i < maxCount; i++)
                {
                    int indexB = random(i, maxCount);
                    T tmp = index[i];
                    index[i] = index[indexB];
                    index[indexB] = tmp;
                }
                if (onFinsih != null)
                    onFinsih();
            }

            public static void SwitchIndexInArray<T>(T[] index, Action onFinsih = null)
            {
                int maxCount = index.Length;
                for (int i = 0; i < maxCount; i++)
                {
                    int indexB = random(i, maxCount);
                    T tmp = index[i];
                    index[i] = index[indexB];
                    index[indexB] = tmp;
                }
                if (onFinsih != null)
                    onFinsih();
            }

            private static int random(int a, int max)
            {
                int n = UnityEngine.Random.Range(0, max);
                if (n != a)
                    return n;
                else
                    return random(a, max);

            }
        }

        [Serializable]
        public class TransformAll
        {
            /// <summary>
            /// "ScaleTo"(scale Target To scale Vector3 in speedTime ,Callback onFinish)
            /// </summary>
            public static TransformS ScaleTo(GameObject target, Vector3 scale, float speedTime, AnimationCurve curve = null, Action onFinish = null)
            {

                TransformS obj;
                if (target.GetComponent<TransformS>())
                {
                    obj = target.GetComponent<TransformS>();
                    if (curve != null)
                        obj.curve = curve;
                    obj.scale = scale;
                    obj.time = speedTime;
                    obj.onScale = true;
                    if (onFinish != null)
                        obj.onFinish = onFinish;
                    obj.ReUse();
                    return null;
                }
                else {
                    obj = target.AddComponent<TransformS>();
                    if (curve != null)
                        obj.curve = curve;
                    obj.scale = scale;
                    obj.time = speedTime;
                    obj.onScale = true;
                    if (onFinish != null)
                        obj.onFinish = onFinish;
                    return obj;
                }
            }
            /// <summary>
            /// "TranslateTo"(Translate Target To Vector3 position in speedTime ,Callback onFinish)
            /// </summary>
            public static TransformM TranslateTo(GameObject target, Vector3 position, float speedTime, AnimationCurve curve = null, Action onFinish = null)
            {                
                TransformM obj;
                if (target.GetComponent<TransformM>())
                {
                    obj = target.GetComponent<TransformM>();
                    if (curve != null)
                        obj.curve = curve;
                    obj.position = position;
                    obj.time = speedTime;
                    obj.onPosition = true;
                    if (onFinish != null)
                        obj.onFinish = onFinish;
                    obj.ReUse();
                    return null;
                }
                else
                {
                    obj = target.AddComponent<TransformM>();
                    if (curve != null)
                        obj.curve = curve;
                    obj.position = position;
                    obj.time = speedTime;
                    obj.onPosition = true;
                    if (onFinish != null)
                        obj.onFinish = onFinish;
                    return obj;
                }
            }
            /// <summary>
            /// "RotateTo Angles in Vector3"
            /// </summary>
            public static TransformR RotateTo(GameObject target, Vector3 rotation, float speedTime, AnimationCurve curve = null, Action onFinish = null)
            {
                TransformR obj;
                if (target.GetComponent<TransformR>())
                {
                    obj = target.GetComponent<TransformR>();
                    if (curve != null)
                        obj.curve = curve;
                    obj.rotation = rotation;
                    obj.time = speedTime;
                    obj.onRotatetion = true;
                    if (onFinish != null)
                        obj.onFinish = onFinish;
                    return null;
                }
                else
                {
                    obj = target.AddComponent<TransformR>();
                    if (curve != null)
                        obj.curve = curve;
                    obj.rotation = rotation;
                    obj.time = speedTime;
                    obj.onRotatetion = true;
                    if (onFinish != null)
                        obj.onFinish = onFinish;
                    return obj;
                }
               
            }
            /// <summary>
            /// "RotateARound Vector3"
            /// </summary>
            public static TransformRAR RotateARound(GameObject target, Vector3 rotation, float speedTime)
            {
                TransformRAR obj;
                if (target.GetComponent<TransformRAR>() == null)
                    obj = target.AddComponent<TransformRAR>();
                else
                    obj = target.GetComponent<TransformRAR>();

                obj.rotation = rotation;
                obj.time = speedTime;
                obj.onRotatetionAR = true;
                return obj;
            }
            /// <summary>
            /// "Stop RotateARound Vector3"
            /// </summary>
            public static void StopRotateARound(GameObject target, Action onFinish = null)
            {
                TransformRAR obj;
                if (target.GetComponent<TransformRAR>() == null)
                    return;
                else
                {
                    obj = target.GetComponent<TransformRAR>();
                    obj.Stop();
                }

            }
            public static void LookAtPos(GameObject target,Transform lookAtTo, Action onFinsih = null)
            {

            }
        }

        [Serializable]
        public class CatchTime
        {
            public float CatchTimerPlus(float time)
            {
                time += Time.deltaTime;
                return time;
            }
            public static float CatchTimerMinus(float time, float lasttime)
            {
                if (time > lasttime)
                    time -= Time.time;
                else
                    time = 0;

                return time;
            }

        }

        [Serializable]
        public class CarmeraM
        {

            public static CarmeraTagTarget CarmeraFollowTarget(string cameraname, GameObject tragetTag, Action onFinish = null)
            {
                GameObject obj = GameObject.Find(cameraname);
                CarmeraTagTarget compo;
                if (obj.GetComponent<CarmeraTagTarget>() == null)
                    compo = obj.AddComponent<CarmeraTagTarget>();
                else
                    compo = obj.GetComponent<CarmeraTagTarget>();
                compo.targetFollow = tragetTag;
                if (onFinish != null)
                    onFinish();
                return compo;
            }
            public static void CarmeraChangeTarget(GameObject newTarget)
            {
                CarmeraTagTarget.MainFollowTarget.targetFollow = newTarget;
            }
            public static void CarmeraSettingHotKey(KeyCode MouseButtonLeft, KeyCode MouseButtonRight)
            {
                CarmeraTagTarget newkey = CarmeraTagTarget.MainFollowTarget;
                newkey.MouseButtonLeft = MouseButtonLeft;
                newkey.MouseButtonRight = MouseButtonRight;
            }

            public static CarmeraSlideX CarmeraSlideX(string cameraname, Action onFinish = null)
            {
                GameObject obj = GameObject.Find(cameraname);
                CarmeraSlideX compo;
                if (obj.GetComponent<CarmeraSlideX>() == null)
                    compo = obj.AddComponent<CarmeraSlideX>();
                else
                    compo = obj.GetComponent<CarmeraSlideX>();


                return compo;
            }

            public static CarmeraSlideY CarmeraSlideY(string cameraname, Action onFinish = null)
            {
                GameObject obj = GameObject.Find(cameraname);
                CarmeraSlideY compo;
                if (obj.GetComponent<CarmeraSlideY>() == null)
                    compo = obj.AddComponent<CarmeraSlideY>();
                else
                    compo = obj.GetComponent<CarmeraSlideY>();


                return compo;
            }

        }

        [Serializable]
        public class XML
        {
            static string location = "Assets/Resources/xml";
            static string path;

            public static void SaveClassToMXL<T>(string nameFile, T Class, string path = null)
            {
                if (path == null)
                    path = OpenLoction();

                if (path == "test")
                    path = location;

                string XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(T));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, Class);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                StreamWriter writer;
                FileInfo t = new FileInfo(path + "\\" + nameFile + ".xml");
                /*   if (!t.Exists)
                   {
                       writer = t.CreateText();
                   }
                   else
                   {
                       t.Delete();
                       writer = t.CreateText();
                   }
                   writer.Write(XmlizedString);
                   writer.Close();*/
            }

            public static object LoadClassFormXML<T>(string nameFile)
            {
                StreamReader r = File.OpenText(location + "\\" + nameFile + ".xml");
                string _info = r.ReadToEnd();
                r.Close();
                XmlSerializer xs = new XmlSerializer(typeof(T));
                MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(_info));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return xs.Deserialize(memoryStream);

            }
            /// <summary>
            /// Form  (T)ApiThop.XML.LoadClassFormXML<T>(string "nameFile")
            /// </summary>
            /// 
            static string UTF8ByteArrayToString(byte[] characters)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                string constructedString = encoding.GetString(characters);
                return (constructedString);
            }

            static byte[] StringToUTF8ByteArray(string pXmlString)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] byteArray = encoding.GetBytes(pXmlString);
                return byteArray;
            }

            static string OpenLoction()
            {
                string path = "Assets/Resources/xml";
                path = UnityEditor.EditorUtility.OpenFolderPanel("Seletion File", path, "");
                string[] a = path.Split('/');
                path = "";
                bool chack = false;
                foreach (var item in a)
                {
                    if (item == "Assets")
                        chack = true;

                    if (chack)
                        path += item + "/";
                }
                return path;
            }
        }

        [Serializable]
        public class Pooling
        {
            public static ContrainerPooling CreateContraner(string nameSetPooling, GameObject target, int count, GameObject objPool)
            {
                ContrainerPooling obj;
                if (target.GetComponent<ContrainerPooling>() != null)
                    obj = target.GetComponent<ContrainerPooling>();
                else
                    obj = target.AddComponent<ContrainerPooling>();

                obj.countPool = count;
                obj.nameSetPool = nameSetPooling;
                obj.objPool = objPool;
                obj.countPool = count;
                return obj;
            }

            public static ContrainerPooling CreateContraner(string nameSetPooling, GameObject target, int count, GameObject objPool, Transform newTransform, bool Rotation, bool position)
            {
                ContrainerPooling obj = CreateContraner(nameSetPooling, target, count, objPool);
                obj.PositionInst = newTransform;
                obj.onNewRotation = Rotation;
                obj.onNewPosition = position;
                return obj;
            }

        }

        [Serializable]
        public class LoadLevelAsync
        {
            private static LoadLevelAsyncS obj;

            public static LoadLevelAsyncS ToLevel(GameObject form, string namestring)
            {
                if (form.GetComponent<LoadLevelAsyncS>() != null)
                    obj = form.GetComponent<LoadLevelAsyncS>();
                else
                    obj = form.AddComponent<LoadLevelAsyncS>();

                obj.level = namestring;
                return obj;
            }
            public static void StartLoadLevelAsync(Action actions = null)
            {
                obj.startLoad();
                if (actions != null)
                    actions();
            }
            public static float isProgress()
            {
                return obj.isProgress();
            }
            public static void ContinueLoadComplete(Action actions = null)
            {
                obj.LoadContinue();
                if (actions != null)
                    actions();
            }
        }
    }

}





