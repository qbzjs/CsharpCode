


using UnityEngine;
public class AudioCustomizeSettings
{
    public static CustomizeSettingData ProjCustomizeSettings
    {
        get
        {
            if (customizeSettings == null)
            {
                customizeSettings = new CustomizeSettingData();
                customizeSettings.Init();
            }
            return customizeSettings;
        }
    }
    private static CustomizeSettingData customizeSettings;
    public static string DeveloperWwiseInstallationPath = "";//= @"E:\Wwise 2017.2.8.6698\";
    public static string DeveloperWwiseProjectPath = ""; //@"E:\MyWwise\ShengSiJuJi\ShengSiJuJi\ShengSiJuJi.wproj";
    public static bool GetCreatePacker()
    {
#if UNITY_EDITOR

        return CustomizeSettingData.D_CreatedPicker;

#else
                    return false;
#endif
    }
#if UNITY_EDITOR
    public static void SetCreatePacker(bool usePicker)
    {


        CustomizeSettingData.D_CreatedPicker = usePicker;

    }
    
#endif
    public static bool GetCreateWwiseGlobal()
    {
#if UNITY_EDITOR


        return CustomizeSettingData.D_CreateWwiseGlobal;

#else
          return ProjCustomizeSettings.CreateWwiseGlobal;
#endif
    }
    public static bool GetCreateWwiseListener()
    {
#if UNITY_EDITOR

        return CustomizeSettingData.D_CreateWwiseListener;
#else
          return ProjCustomizeSettings.CreateWwiseListener;
#endif
    }
    public static string GetBankAssetFolder()
    {
#if UNITY_EDITOR

        string path_unityEditor = System.IO.Path.Combine(Application.dataPath, CustomizeSettingData.BankEditorAssetRelativePath);
        AkBasePathGetter.FixSlashes(ref path_unityEditor);
        return path_unityEditor;


#else
                return Application.streamingAssetsPath;
          //return Application.dataPath + "/StreamingAssets";
#endif
    }

    [System.Serializable]
    public class CustomizeSettingData
    {

        //  public const string WwiseSettingsFilename = "WwiseSettings.xml";

        //  private static WwiseSettings instance;

        public bool CopySoundBanksAsPreBuildStep = false;

        public static bool D_CreatedPicker = false;
        //default is true
        public bool CreateWwiseGlobal = true;
        public const bool D_CreateWwiseGlobal = true;
        //default is false
        public bool CreateWwiseListener = false;
        public static bool D_CreateWwiseListener = false;

        public bool GenerateSoundBanksAsPreBuildStep = false;
        public bool ShowMissingRigidBodyWarning = false;
        public static string BankEditorAssetRelativePath = "Assets/Sound/WiseBank";


        public string BankFolder_UnityEditor;
        // public string WwiseInstallationPathMac = @"E:\Wwise 2017.2.8.6698\";



        public void Init()
        {
#if UNITY_EDITOR
            BankFolder_UnityEditor = System.IO.Path.Combine(Application.dataPath, BankEditorAssetRelativePath);
            AkBasePathGetter.FixSlashes(ref BankFolder_UnityEditor);
#else
#endif
        }



    }
}