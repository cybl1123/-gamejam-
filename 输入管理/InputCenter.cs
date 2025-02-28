using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�˴���Ϊһ���࣬���⴫���������ļ�ʱֵ
public static class InputElements
{
    public static bool jump;
    public static bool r_walk;
    public static bool l_walk;
    public static bool climb;
    public static bool squat;
    public static bool swift;
    public static bool dash;
    public static bool interact;
    public static bool cancel;
    public static bool[] bools = {jump,r_walk,l_walk,climb,squat,swift,dash,interact,cancel };//���￨��һ��
    //Ҫ��Ӽ�λ����ҲҪ��� ����˳�����
    public static void Getbool()//��update����ʵʱ��ȡboolֵ
    {
        jump=bools[0];
        r_walk=bools[1];
        l_walk = bools[2];
        climb=bools[3];
        squat=bools[4];
        swift=bools[5];
        dash=bools[6];
        interact=bools[7];
        cancel=bools[8];
    }
    public static void LongGetbool()
    {
        int[] indexs = InputKeys.LongPressedIndex;
        for (int i = 0; i < indexs.Length; i++)
        {
            bools[indexs[i]] = InputKeys.AllKeysSave[indexs[i]].condition;
        }
       
    }
    public static void TriggerGetbool(InputKeyBag keyBag)
    {
        bools[keyBag.index]=keyBag.condition;
    }
}
public static class InputKeys
{
    //����������Ҫ�ı����InputKeyBag����condition��ֵ
    static InputKeyBag jumpKey = new InputKeyBag(false, 0, "jump", KeyCode.Space);
    static InputKeyBag r_walkKey = new InputKeyBag(false, 1, "r_walk", KeyCode.D);
    static InputKeyBag l_walkKey = new InputKeyBag(false, 2, "l_walk", KeyCode.A);
    static InputKeyBag climbKey = new InputKeyBag(false, 3, "climb", KeyCode.W);
    static InputKeyBag squatKey = new InputKeyBag(false, 4, "squat", KeyCode.S);
    static InputKeyBag swiftKey = new InputKeyBag(false, 5, "swift", KeyCode.LeftControl);
    static InputKeyBag dashKey = new InputKeyBag(false, 6, "dash", KeyCode.LeftShift);
    static InputKeyBag interactKey = new InputKeyBag(false, 7, "interact", KeyCode.Return);
    static InputKeyBag cancelKey = new InputKeyBag(false, 8, "cancel", KeyCode.Escape);
    //��������µļ�λ

    //����ֵ䴢��ȫ����
    public static Dictionary<int, InputKeyBag> AllKeysSave = new Dictionary<int, InputKeyBag>()
    {
        {0,jumpKey },
        {1,r_walkKey},
        {2,l_walkKey},
        {3,climbKey},
        {4,squatKey},
        {5,swiftKey},
        {6,dashKey},
        {7,interactKey },
        {8,cancelKey},
    };



    //���ݷ��ཫ���������Ӧ����
    static public int[] LongPressedIndex = new int[] 
    {
    r_walkKey.index,
    l_walkKey.index,
    climbKey.index,
    squatKey.index
    };
    static public int[] TriggerIndex = new int[]
    {
     jumpKey.index,
     swiftKey.index,
     dashKey.index,
     interactKey.index,
     cancelKey.index
    };


    //������һ���ֵ����ҵ�Ĭ�ϼ�λ������д洢��������ҿ���ͨ�������ط��Դˣ�����ֵ䣩�����޸�
    public static Dictionary<string, KeyCode> SettedKeys = new Dictionary<string, KeyCode>
    {
        {"jump",KeyCode.Space },
        {"r_walk",KeyCode.D },
        {"l_walk", KeyCode.A },
        {"climb", KeyCode.W },
        {"squat", KeyCode.S },
        {"swift", KeyCode.LeftControl },
        {"dash", KeyCode.LeftShift },
        {"interact", KeyCode.Return },
        { "cancel",KeyCode.Escape }
    };
    

    //��������������󶨵ļ�λ���и��£�����һ������ť�󶨵ķ���������������ð�ť֮�󣬵���󶨵İ�ť�ķ��������Դ��������ʹ�ð�ť���豻��ȡ��
    //��������Ϸ��ʼ��ʱ����Զ�ȡ�洢�����ݿ��ڲ������������Ϣ
    public static void UpdateKeys()
    {
        int index = 0;
        foreach (KeyCode keycode in SettedKeys.Values)
        {
            AllKeysSave[index].keyCode = keycode;
            index++;
        }
    }
}
public class InputCenter : MonoBehaviour
{
    private void Awake()
    {
        InputKeys.UpdateKeys();
    }

    void Update()
    {


        //Ϊ�������ٶ�ֱ������������������ֱ�����룬�ǵô��ע�ͣ�
        for (int i = 0; i < InputKeys.LongPressedIndex.Length; i++)
        {
            LongPressedTest(InputKeys.AllKeysSave[InputKeys.LongPressedIndex[i]]);
        }
        InputElements.LongGetbool();
        for (int i = 0; i < InputKeys.TriggerIndex.Length; i++)
        {
            TriggerTest(InputKeys.AllKeysSave[InputKeys.TriggerIndex[i]]);
        }
        InputElements.Getbool();
    }
    static void LongPressedTest(InputKeyBag keyBag)
    {
        if (Input.GetKey(keyBag.keyCode))
        {
            keyBag.condition = true;
        }
        else if (Input.GetKeyUp(keyBag.keyCode))
        {
            keyBag.condition = false;
        }
    }
    static void TriggerTest(InputKeyBag keyBag)
    {
        if (Input.GetKeyDown(keyBag.keyCode))
        {
            keyBag.condition = true;
            InputElements.TriggerGetbool(keyBag);
        }
        else
        {
            keyBag.condition = false;
        }
        InputElements.TriggerGetbool(keyBag);
    }
}
