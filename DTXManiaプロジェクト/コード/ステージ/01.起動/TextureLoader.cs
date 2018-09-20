using FDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTXMania
{
    class TextureLoader : CActivity
    {
        const string BASE = @"Graphics\";

        // Stage
        const string TITLE = @"1_Title\";
        const string CONFIG = @"2_Config\";
        const string SONGSELECT = @"3_SongSelect\";
        const string SONGLOADING = @"4_SongLoading\";
        const string GAME = @"5_Game\";
        const string RESULT = @"6_Result\";
        const string EXIT = @"7_Exit\";

        // InGame
        const string CHARA = @"1_Chara\";
        const string DANCER = @"2_Dancer\";
        const string MOB = @"3_Mob\";
        const string COURSESYMBOL = @"4_CourseSymbol\";
        const string BACKGROUND = @"5_Background\";
        const string TAIKO = @"6_Taiko\";
        const string GAUGE = @"7_Gauge\";
        const string FOOTER = @"8_Footer\";
        const string END = @"9_End\";
        const string EFFECTS = @"10_Effects\";
        const string BALLOON = @"11_Balloon\";
        const string LANE = @"12_Lane\";
        const string GENRE = @"13_Genre\";
        const string GAMEMODE = @"14_GameMode\";
        const string FAILED = @"15_Failed\";
        const string RUNNER = @"16_Runner\";

        // InGame_Effects
        const string FIRE = @"Fire\";
        const string HIT = @"Hit\";
        const string ROLL = @"Roll\";
        const string SPLASH = @"Splash\";


        public TextureLoader()
        {
            // コンストラクタ

        }

        internal CTexture TxC(string FileName)
        {
            return CDTXMania.tテクスチャの生成(CSkin.Path(BASE + FileName));
        }
        internal CTextureAf TxCAf(string FileName)
        {
            return CDTXMania.tテクスチャの生成Af(CSkin.Path(BASE + FileName));
        }
        internal CTexture TxCGen(string FileName)
        {
            return CDTXMania.tテクスチャの生成(CSkin.Path(BASE + GAME + GENRE + FileName + ".png"));
        }

        public void LoadTexture()
        {
            #region 共通
            Tile_Black = TxC(@"Tile_Black.png");
            Tile_White = TxC(@"Tile_White.png");
            Menu_Title = TxC(@"Menu_Title.png");
            Menu_Highlight = TxC(@"Menu_Highlight.png");
            Enum_Song = TxC(@"Enum_Song.png");
            Overlay = TxC(@"Overlay.png");
            NamePlate = new CTexture[2];
            NamePlate[0] = TxC(@"1P_NamePlate.png");
            NamePlate[1] = TxC(@"2P_NamePlate.png");
            #endregion
            #region 1_タイトル画面
            Title_Background = TxC(TITLE + @"Background.png");
            Title_Menu = TxC(TITLE + @"Menu.png");
            #endregion

            #region 2_コンフィグ画面
            Config_Background = TxC(CONFIG + @"Background.png");
            Config_Cursor = TxC(CONFIG + @"Cursor.png");
            Config_ItemBox = TxC(CONFIG + @"ItemBox.png");
            Config_Arrow = TxC(CONFIG + @"Arrow.png");
            Config_KeyAssign = TxC(CONFIG + @"KeyAssign.png");
            Config_Font = TxC(CONFIG + @"Font.png");
            Config_Font_Bold = TxC(CONFIG + @"Font_Bold.png");
            Config_Enum_Song = TxC(CONFIG + @"Enum_Song.png");
            #endregion

            #region 3_選曲画面
            SongSelect_Background = TxC(SONGSELECT + @"Background.png");
            SongSelect_Header = TxC(SONGSELECT + @"Header.png");
            SongSelect_Footer = TxC(SONGSELECT + @"Footer.png");
            SongSelect_Difficulty = TxC(SONGSELECT + @"Difficulty.png");
            SongSelect_Auto = TxC(SONGSELECT + @"Auto.png");
            SongSelect_Level = TxC(SONGSELECT + @"Level.png");
            SongSelect_Branch = TxC(SONGSELECT + @"Branch.png");
            SongSelect_Branch_Text = TxC(SONGSELECT + @"Branch_Text.png");
            SongSelect_Bar_Center = TxC(SONGSELECT + @"Bar_Center.png");
            SongSelect_Frame_Score = TxC(SONGSELECT + @"Frame_Score.png");
            SongSelect_Frame_Box = TxC(SONGSELECT + @"Frame_Box.png");
            SongSelect_Frame_BackBox = TxC(SONGSELECT + @"Frame_BackBox.png");
            SongSelect_Frame_Random = TxC(SONGSELECT + @"Frame_Random.png");
            SongSelect_Score_Select = TxC(SONGSELECT + @"Score_Select.png");
            //SongSelect_Frame_Dani = TxC(SONGSELECT + @"Frame_Dani.png");
            SongSelect_GenreText = TxC(SONGSELECT + @"GenreText.png");
            SongSelect_Cursor_Left = TxC(SONGSELECT + @"Cursor_Left.png");
            SongSelect_Cursor_Right = TxC(SONGSELECT + @"Cursor_Right.png");
            for (int i = 0; i < 9; i++)
            {
                SongSelect_Bar_Genre[i] = TxC(SONGSELECT + @"Bar_Genre_" + i.ToString() + ".png");
            }
            for (int i = 0; i < 5; i++)
            {
                SongSelect_ScoreWindow[i] = TxC(SONGSELECT + @"ScoreWindow_" + i.ToString() + ".png");
            }

            for (int i = 0; i < 9; i++)
            {
                SongSelect_GenreBack[i] = TxC(SONGSELECT + @"GenreBackground_" + i.ToString() + ".png");
            }
            SongSelect_ScoreWindow_Text = TxC(SONGSELECT + @"ScoreWindow_Text.png");
            #endregion

            #region 4_読み込み画面
            SongLoading_Plate = TxC(SONGLOADING + @"Plate.png");
            SongLoading_FadeIn = TxC(SONGLOADING + @"FadeIn.png");
            SongLoading_FadeOut = TxC(SONGLOADING + @"FadeOut.png");
            #endregion

            #region 5_演奏画面
            #region 共通
            Notes = TxC(GAME + @"Notes.png");
            Judge_Frame = TxC(GAME + @"Notes.png");
            SenNotes = TxC(GAME + @"SenNotes.png");
            Notes_Arm = TxC(GAME + @"Notes_Arm.png");
            Judge = TxC(GAME + @"Judge.png");

            Judge_Meter = TxC(GAME + @"Judge_Meter.png");
            Bar = TxC(GAME + @"Bar.png");
            Bar_Branch = TxC(GAME + @"Bar_Branch.png");

            #endregion
            #region キャラクター
            CDTXMania.Skin.Game_Chara_Ptn_Normal = CDTXMania.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"Normal\"));
            if (CDTXMania.Skin.Game_Chara_Ptn_Normal != 0)
            {
                Chara_Normal = new CTexture[CDTXMania.Skin.Game_Chara_Ptn_Normal];
                for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_Normal; i++)
                {
                    Chara_Normal[i] = TxC(GAME + CHARA + @"Normal\" + i.ToString() + ".png");
                }
            }
            CDTXMania.Skin.Game_Chara_Ptn_Clear = CDTXMania.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"Clear\"));
            if (CDTXMania.Skin.Game_Chara_Ptn_Clear != 0)
            {
                Chara_Normal_Cleared = new CTexture[CDTXMania.Skin.Game_Chara_Ptn_Clear];
                for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_Clear; i++)
                {
                    Chara_Normal_Cleared[i] = TxC(GAME + CHARA + @"Clear\" + i.ToString() + ".png");
                }
            }
            if (CDTXMania.Skin.Game_Chara_Ptn_Clear != 0)
            {
                Chara_Normal_Maxed = new CTexture[CDTXMania.Skin.Game_Chara_Ptn_Clear];
                for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_Clear; i++)
                {
                    Chara_Normal_Maxed[i] = TxC(GAME + CHARA + @"Clear_Max\" + i.ToString() + ".png");
                }
            }
            CDTXMania.Skin.Game_Chara_Ptn_GoGo = CDTXMania.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"GoGo\"));
            if (CDTXMania.Skin.Game_Chara_Ptn_GoGo != 0)
            {
                Chara_GoGoTime = new CTexture[CDTXMania.Skin.Game_Chara_Ptn_GoGo];
                for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_GoGo; i++)
                {
                    Chara_GoGoTime[i] = TxC(GAME + CHARA + @"GoGo\" + i.ToString() + ".png");
                }
            }
            if (CDTXMania.Skin.Game_Chara_Ptn_GoGo != 0)
            {
                Chara_GoGoTime_Maxed = new CTexture[CDTXMania.Skin.Game_Chara_Ptn_GoGo];
                for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_GoGo; i++)
                {
                    Chara_GoGoTime_Maxed[i] = TxC(GAME + CHARA + @"GoGo_Max\" + i.ToString() + ".png");
                }
            }

            CDTXMania.Skin.Game_Chara_Ptn_10combo = CDTXMania.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"10combo\"));
            if (CDTXMania.Skin.Game_Chara_Ptn_10combo != 0)
            {
                Chara_10Combo = new CTexture[CDTXMania.Skin.Game_Chara_Ptn_10combo];
                for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_10combo; i++)
                {
                    Chara_10Combo[i] = TxC(GAME + CHARA + @"10combo\" + i.ToString() + ".png");
                }
            }
            CDTXMania.Skin.Game_Chara_Ptn_10combo_Max = CDTXMania.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"10combo_Max\"));
            if (CDTXMania.Skin.Game_Chara_Ptn_10combo_Max != 0)
            {
                Chara_10Combo_Maxed = new CTexture[CDTXMania.Skin.Game_Chara_Ptn_10combo_Max];
                for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_10combo_Max; i++)
                {
                    Chara_10Combo_Maxed[i] = TxC(GAME + CHARA + @"10combo_Max\" + i.ToString() + ".png");
                }
            }

            CDTXMania.Skin.Game_Chara_Ptn_GoGoStart = CDTXMania.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"GoGoStart\"));
            if (CDTXMania.Skin.Game_Chara_Ptn_GoGoStart != 0)
            {
                Chara_GoGoStart = new CTexture[CDTXMania.Skin.Game_Chara_Ptn_GoGoStart];
                for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_GoGoStart; i++)
                {
                    Chara_GoGoStart[i] = TxC(GAME + CHARA + @"GoGoStart\" + i.ToString() + ".png");
                }
            }
            CDTXMania.Skin.Game_Chara_Ptn_GoGoStart_Max = CDTXMania.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"GoGoStart_Max\"));
            if (CDTXMania.Skin.Game_Chara_Ptn_GoGoStart_Max != 0)
            {
                Chara_GoGoStart_Maxed = new CTexture[CDTXMania.Skin.Game_Chara_Ptn_GoGoStart_Max];
                for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_GoGoStart_Max; i++)
                {
                    Chara_GoGoStart_Maxed[i] = TxC(GAME + CHARA + @"GoGoStart_Max\" + i.ToString() + ".png");
                }
            }
            CDTXMania.Skin.Game_Chara_Ptn_ClearIn = CDTXMania.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"ClearIn\"));
            if (CDTXMania.Skin.Game_Chara_Ptn_ClearIn != 0)
            {
                Chara_Become_Cleared = new CTexture[CDTXMania.Skin.Game_Chara_Ptn_ClearIn];
                for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_ClearIn; i++)
                {
                    Chara_Become_Cleared[i] = TxC(GAME + CHARA + @"ClearIn\" + i.ToString() + ".png");
                }
            }
            CDTXMania.Skin.Game_Chara_Ptn_SoulIn = CDTXMania.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"SoulIn\"));
            if (CDTXMania.Skin.Game_Chara_Ptn_SoulIn != 0)
            {
                Chara_Become_Maxed = new CTexture[CDTXMania.Skin.Game_Chara_Ptn_SoulIn];
                for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_SoulIn; i++)
                {
                    Chara_Become_Maxed[i] = TxC(GAME + CHARA + @"SoulIn\" + i.ToString() + ".png");
                }
            }
            Chara_Balloon_Breaking = TxC(GAME + CHARA + @"Breaking.png");
            Chara_Balloon_Broken = TxC(GAME + CHARA + @"Broken.png");
            #endregion
            #region 踊り子
            CDTXMania.Skin.Game_Dancer_Ptn = CDTXMania.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + DANCER + @"1\"));
            if (CDTXMania.Skin.Game_Dancer_Ptn != 0)
            {
                Dancer = new CTexture[5][];
                for (int i = 0; i < 5; i++)
                {
                    Dancer[i] = new CTexture[CDTXMania.Skin.Game_Dancer_Ptn];
                    for (int p = 0; p < CDTXMania.Skin.Game_Dancer_Ptn; p++)
                    {
                        Dancer[i][p] = TxC(GAME + DANCER + (i + 1) + @"\" + p.ToString() + ".png");
                    }
                }
            }
            #endregion
            #region モブ
            CDTXMania.Skin.Game_Mob_Ptn = CDTXMania.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + MOB));
            Mob = new CTexture[CDTXMania.Skin.Game_Mob_Ptn];
            for (int i = 0; i < CDTXMania.Skin.Game_Mob_Ptn; i++)
            {
                Mob[i] = TxC(GAME + MOB + i.ToString() + ".png");
            }
            #endregion
            #region フッター
            Mob_Footer = TxC(GAME + FOOTER + @"0.png");
            #endregion
            #region 背景
            Background = TxC(GAME + Background + @"0\" + @"Background.png");
            Background_Up = new CTexture[2];
            Background_Up[0] = TxC(GAME + BACKGROUND + @"0\" + @"1P_Up.png");
            Background_Up[1] = TxC(GAME + BACKGROUND + @"0\" + @"2P_Up.png");
            Background_Up_Clear = new CTexture[2];
            Background_Up_Clear[0] = TxC(GAME + BACKGROUND + @"0\" + @"1P_Up_Clear.png");
            Background_Up_Clear[1] = TxC(GAME + BACKGROUND + @"0\" + @"2P_Up_Clear.png");
            Background_Down = TxC(GAME + BACKGROUND + @"0\" + @"Down.png");
            Background_Down_Clear = TxC(GAME + BACKGROUND + @"0\" + @"Down_Clear.png");
            Background_Down_Scroll = TxC(GAME + BACKGROUND + @"0\" + @"Down_Scroll.png");

            #endregion
            #region 太鼓
            Taiko_Background = new CTexture[2];
            Taiko_Background[0] = TxC(GAME + TAIKO + @"1P_Background.png");
            Taiko_Background[1] = TxC(GAME + TAIKO + @"2P_Background.png");
            Taiko_Frame = new CTexture[2];
            Taiko_Frame[0] = TxC(GAME + TAIKO + @"1P_Frame.png");
            Taiko_Frame[1] = TxC(GAME + TAIKO + @"2P_Frame.png");
            Taiko_PlayerNumber = new CTexture[2];
            Taiko_PlayerNumber[0] = TxC(GAME + TAIKO + @"1P_PlayerNumber.png");
            Taiko_PlayerNumber[1] = TxC(GAME + TAIKO + @"2P_PlayerNumber.png");
            Taiko_NamePlate = new CTexture[2];
            Taiko_NamePlate[0] = TxC(GAME + TAIKO + @"1P_NamePlate.png");
            Taiko_NamePlate[1] = TxC(GAME + TAIKO + @"2P_NamePlate.png");
            Taiko_Base = TxC(GAME + TAIKO + @"Base.png");
            Taiko_Don_Left = TxC(GAME + TAIKO + @"Don.png");
            Taiko_Don_Right = TxC(GAME + TAIKO + @"Don.png");
            Taiko_Ka_Left = TxC(GAME + TAIKO + @"Ka.png");
            Taiko_Ka_Right = TxC(GAME + TAIKO + @"Ka.png");
            Taiko_LevelUp = TxC(GAME + TAIKO + @"LevelUp.png");
            Taiko_LevelDown = TxC(GAME + TAIKO + @"LevelDown.png");
            Couse_Symbol = new CTexture[6];
            string[] Couse_Symbols = new string[6] { "Easy", "Normal", "Hard", "Oni", "Edit", "Shin" };
            for (int i = 0; i < 6; i++)
            {
                Couse_Symbol[i] = TxC(GAME + COURSESYMBOL + Couse_Symbols[i] + ".png");
            }
            Taiko_Score = new CTexture[3];
            Taiko_Score[0] = TxC(GAME + TAIKO + @"Score.png");
            Taiko_Score[1] = TxC(GAME + TAIKO + @"Score_1P.png");
            Taiko_Score[2] = TxC(GAME + TAIKO + @"Score_2P.png");
            Taiko_Combo = new CTexture[2];
            Taiko_Combo[0] = TxC(GAME + TAIKO + @"Combo.png");
            Taiko_Combo[1] = TxC(GAME + TAIKO + @"Combo_Big.png");
            Taiko_Combo_Effect = TxC(GAME + TAIKO + @"Combo_Effect.png");
            Taiko_Combo_Text = TxC(GAME + TAIKO + @"Combo_Text.png");
            #endregion
            #region ゲージ
            Gauge = new CTexture[2];
            Gauge[0] = TxC(GAME + GAUGE + @"1P.png");
            Gauge[1] = TxC(GAME + GAUGE + @"2P.png");
            Gauge_Base = new CTexture[2];
            Gauge_Base[0] = TxC(GAME + GAUGE + @"1P_Base.png");
            Gauge_Base[1] = TxC(GAME + GAUGE + @"2P_Base.png");
            Gauge_Line = new CTexture[2];
            Gauge_Line[0] = TxC(GAME + GAUGE + @"1P_Line.png");
            Gauge_Line[1] = TxC(GAME + GAUGE + @"2P_Line.png");
            CDTXMania.Skin.Game_Gauge_Rainbow_Ptn = CDTXMania.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + GAUGE + @"Rainbow\"));
            if (CDTXMania.Skin.Game_Gauge_Rainbow_Ptn != 0)
            {
                Gauge_Rainbow = new CTexture[CDTXMania.Skin.Game_Gauge_Rainbow_Ptn];
                for (int i = 0; i < CDTXMania.Skin.Game_Gauge_Rainbow_Ptn; i++)
                {
                    Gauge_Rainbow[i] = TxC(GAME + GAUGE + @"Rainbow\" + i.ToString() + ".png");
                }
            }
            Gauge_Soul = TxC(GAME + GAUGE + @"Soul.png");
            Gauge_Soul_Fire = TxC(GAME + GAUGE + @"Fire.png");
            Gauge_Soul_Explosion = new CTexture[2];
            Gauge_Soul_Explosion[0] = TxC(GAME + GAUGE + @"1P_Explosion.png");
            Gauge_Soul_Explosion[1] = TxC(GAME + GAUGE + @"2P_Explosion.png");
            #endregion
            #region 吹き出し
            Balloon_Combo = new CTexture[2];
            Balloon_Combo[0] = TxC(GAME + BALLOON + @"Combo_1P.png");
            Balloon_Combo[1] = TxC(GAME + BALLOON + @"Combo_2P.png");
            Balloon_Roll = TxC(GAME + BALLOON + @"Roll.png");
            Balloon_Balloon = TxC(GAME + BALLOON + @"Balloon.png");
            Balloon_Number_Roll = TxC(GAME + BALLOON + @"Number_Roll.png");
            Balloon_Number_Combo = TxC(GAME + BALLOON + @"Number_Combo.png");

            Balloon_Breaking = new CTexture[6];
            for (int i = 0; i < 6; i++)
            {
                Balloon_Breaking[i] = TxC(GAME + BALLOON + @"Breaking_" + i.ToString() + ".png");
            }
            #endregion
            #region エフェクト
            Effects_Hit_Explosion = TxCAf(GAME + EFFECTS + @"Hit\Explosion.png");
            if (Effects_Hit_Explosion != null) Effects_Hit_Explosion.b加算合成 = true;
            Effects_Hit_Explosion_Big = TxC(GAME + EFFECTS + @"Hit\Explosion_Big.png");
            if (Effects_Hit_Explosion_Big != null) Effects_Hit_Explosion.b加算合成 = true;
            Effects_Hit_FireWorks = new CTextureAf[2];
            Effects_Hit_FireWorks[0] = TxCAf(GAME + EFFECTS + @"Hit\FireWorks_1P.png");
            if (Effects_Hit_FireWorks[0] != null) Effects_Hit_FireWorks[0].b加算合成 = true;
            Effects_Hit_FireWorks[1] = TxCAf(GAME + EFFECTS + @"Hit\FireWorks_2P.png");
            if (Effects_Hit_FireWorks[1] != null) Effects_Hit_FireWorks[1].b加算合成 = true;


            Effects_Fire = TxC(GAME + EFFECTS + @"Fire.png");
            if (Effects_Fire != null) Effects_Fire.b加算合成 = true;

            Effects_Rainbow = TxC(GAME + EFFECTS + @"Rainbow.png");

            Effects_Splash = new CTexture[30];
            for (int i = 0; i < 30; i++)
            {
                Effects_Splash[i] = TxC(GAME + EFFECTS + @"Splash\" + i.ToString() + ".png");
                if (Effects_Splash[i] != null) Effects_Splash[i].b加算合成 = true;
            }
            Effects_Hit_Great = new CTexture[15];
            Effects_Hit_Great_Big = new CTexture[15];
            Effects_Hit_Good = new CTexture[15];
            Effects_Hit_Good_Big = new CTexture[15];
            for (int i = 0; i < 15; i++)
            {
                Effects_Hit_Great[i] = TxC(GAME + EFFECTS + @"Hit\" + @"Great\" + i.ToString() + ".png");
                Effects_Hit_Great_Big[i] = TxC(GAME + EFFECTS + @"Hit\" + @"Great_Big\" + i.ToString() + ".png");
                Effects_Hit_Good[i] = TxC(GAME + EFFECTS + @"Hit\" + @"Good\" + i.ToString() + ".png");
                Effects_Hit_Good_Big[i] = TxC(GAME + EFFECTS + @"Hit\" + @"Good_Big\" + i.ToString() + ".png");
            }
            Effects_Roll = new CTexture[4];
            for (int i = 0; i < 4; i++)
            {
                Effects_Roll[i] = TxC(GAME + EFFECTS + @"Roll\" + i.ToString() + ".png");
            }
            #endregion
            #region レーン
            Lane_Base = new CTexture[3];
            Lane_Text = new CTexture[3];
            string[] Lanes = new string[3] { "Normal", "Expert", "Master" };
            for (int i = 0; i < 3; i++)
            {
                Lane_Base[i] = TxC(GAME + LANE + "Base_" + Lanes[i] + ".png");
                Lane_Text[i] = TxC(GAME + LANE + "Text_" + Lanes[i] + ".png");
            }
            Lane_Red = TxC(GAME + LANE + @"Red.png");
            Lane_Blue = TxC(GAME + LANE + @"Blue.png");
            Lane_Yellow = TxC(GAME + LANE + @"Yellow.png");
            Lane_Background_Main = TxC(GAME + LANE + @"Background_Main.png");
            Lane_Background_Sub = TxC(GAME + LANE + @"Background_Sub.png");
            Lane_Background_GoGo = TxC(GAME + LANE + @"Background_GoGo.png");

            #endregion
            #region 終了演出
            End_Clear_L = new CTexture[5];
            End_Clear_R = new CTexture[5];
            for (int i = 0; i < 5; i++)
            {
                End_Clear_L[i] = TxC(GAME + END + @"Clear_L_" + i.ToString() + ".png");
                End_Clear_R[i] = TxC(GAME + END + @"Clear_R_" + i.ToString() + ".png");
            }
            End_Clear_Text = TxC(GAME + END + @"Clear_Text.png");
            End_Clear_Text_Effect = TxC(GAME + END + @"Clear_Text_Effect.png");
            if (End_Clear_Text_Effect != null) End_Clear_Text_Effect.b加算合成 = true;
            #endregion
            #region ゲームモード
            GameMode_Timer_Tick = TxC(GAME + GAMEMODE + @"Timer_Tick.png");
            GameMode_Timer_Frame = TxC(GAME + GAMEMODE + @"Timer_Frame.png");
            #endregion
            #region ステージ失敗
            Failed_Game = TxC(GAME + FAILED + @"Game.png");
            Failed_Stage = TxC(GAME + FAILED + @"Stage.png");
            #endregion
            #region ランナー
            Runner = TxC(GAME + RUNNER + @"0.png");
            #endregion
            #endregion

            #region 6_結果発表
            Result_Background = TxC(RESULT + @"Background.png");
            Result_FadeIn = TxC(RESULT + @"FadeIn.png");
            Result_Gauge = TxC(RESULT + @"Gauge.png");
            Result_Gauge_Base = TxC(RESULT + @"Gauge_Base.png");
            Result_Judge = TxC(RESULT + @"Judge.png");
            Result_Header = TxC(RESULT + @"Header.png");
            Result_Number = TxC(RESULT + @"Number.png");
            Result_Panel = TxC(RESULT + @"Panel.png");
            Result_Score_Text = TxC(RESULT + @"Score_Text.png");
            Result_Score_Number = TxC(RESULT + @"Score_Number.png");
            #endregion

            #region 7_終了画面
            Exit_Background = TxC(EXIT + @"Background.png");
            #endregion

        }

        public void DisposeTexture()
        {
            CDTXMania.tテクスチャの解放(ref Title_Background);
            CDTXMania.tテクスチャの解放(ref Title_Menu);
            #region 共通
            CDTXMania.tテクスチャの解放(ref Tile_Black);
            CDTXMania.tテクスチャの解放(ref Tile_White);
            CDTXMania.tテクスチャの解放(ref Menu_Title);
            CDTXMania.tテクスチャの解放(ref Menu_Highlight);
            CDTXMania.tテクスチャの解放(ref Enum_Song);
            CDTXMania.tテクスチャの解放(ref Overlay);
            for (int i = 0; i < 2; i++)
            {
                CDTXMania.tテクスチャの解放(ref NamePlate[i]);
            }

            #endregion
            #region 1_タイトル画面
            CDTXMania.tテクスチャの解放(ref Title_Background);
            CDTXMania.tテクスチャの解放(ref Title_Menu);
            #endregion

            #region 2_コンフィグ画面
            CDTXMania.tテクスチャの解放(ref Config_Background);
            CDTXMania.tテクスチャの解放(ref Config_Cursor);
            CDTXMania.tテクスチャの解放(ref Config_ItemBox);
            CDTXMania.tテクスチャの解放(ref Config_Arrow);
            CDTXMania.tテクスチャの解放(ref Config_KeyAssign);
            CDTXMania.tテクスチャの解放(ref Config_Font);
            CDTXMania.tテクスチャの解放(ref Config_Font_Bold);
            CDTXMania.tテクスチャの解放(ref Config_Enum_Song);
            #endregion

            #region 3_選曲画面
            CDTXMania.tテクスチャの解放(ref SongSelect_Background);
            CDTXMania.tテクスチャの解放(ref SongSelect_Header);
            CDTXMania.tテクスチャの解放(ref SongSelect_Footer);
            CDTXMania.tテクスチャの解放(ref SongSelect_Difficulty);
            CDTXMania.tテクスチャの解放(ref SongSelect_Auto);
            CDTXMania.tテクスチャの解放(ref SongSelect_Level);
            CDTXMania.tテクスチャの解放(ref SongSelect_Branch);
            CDTXMania.tテクスチャの解放(ref SongSelect_Branch_Text);
            CDTXMania.tテクスチャの解放(ref SongSelect_Bar_Center);
            CDTXMania.tテクスチャの解放(ref SongSelect_Frame_Score);
            CDTXMania.tテクスチャの解放(ref SongSelect_Frame_Box);
            CDTXMania.tテクスチャの解放(ref SongSelect_Frame_BackBox);
            CDTXMania.tテクスチャの解放(ref SongSelect_Frame_Random);
            CDTXMania.tテクスチャの解放(ref SongSelect_Score_Select);
            CDTXMania.tテクスチャの解放(ref SongSelect_GenreText);
            CDTXMania.tテクスチャの解放(ref SongSelect_Cursor_Left);
            CDTXMania.tテクスチャの解放(ref SongSelect_Cursor_Right);
            for (int i = 0; i < 9; i++)
            {
                CDTXMania.tテクスチャの解放(ref SongSelect_Bar_Genre[i]);
            }
            for (int i = 0; i < 5; i++)
            {
                CDTXMania.tテクスチャの解放(ref SongSelect_ScoreWindow[i]);
            }

            for (int i = 0; i < 9; i++)
            {
                CDTXMania.tテクスチャの解放(ref SongSelect_GenreBack[i]);
            }
            CDTXMania.tテクスチャの解放(ref SongSelect_ScoreWindow_Text);
            #endregion

            #region 4_読み込み画面
            CDTXMania.tテクスチャの解放(ref SongLoading_Plate);
            CDTXMania.tテクスチャの解放(ref SongLoading_FadeIn);
            CDTXMania.tテクスチャの解放(ref SongLoading_FadeOut);
            #endregion

            #region 5_演奏画面
            #region 共通
            CDTXMania.tテクスチャの解放(ref Notes);
            CDTXMania.tテクスチャの解放(ref Judge_Frame);
            CDTXMania.tテクスチャの解放(ref SenNotes);
            CDTXMania.tテクスチャの解放(ref Notes_Arm);
            CDTXMania.tテクスチャの解放(ref Judge);

            CDTXMania.tテクスチャの解放(ref Judge_Meter);
            CDTXMania.tテクスチャの解放(ref Bar);
            CDTXMania.tテクスチャの解放(ref Bar_Branch);

            #endregion
            #region キャラクター

            for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_Normal; i++)
            {
                CDTXMania.tテクスチャの解放(ref Chara_Normal[i]);
            }
            for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_Clear; i++)
            {
                CDTXMania.tテクスチャの解放(ref Chara_Normal_Cleared[i]);
                CDTXMania.tテクスチャの解放(ref Chara_Normal_Maxed[i]);
            }
            for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_GoGo; i++)
            {
                CDTXMania.tテクスチャの解放(ref Chara_GoGoTime[i]);
                CDTXMania.tテクスチャの解放(ref Chara_GoGoTime_Maxed[i]);
            }
            for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_10combo; i++)
            {
                CDTXMania.tテクスチャの解放(ref Chara_10Combo[i]);
            }
            for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_10combo_Max; i++)
            {
                CDTXMania.tテクスチャの解放(ref Chara_10Combo_Maxed[i]);
            }
            for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_GoGoStart; i++)
            {
                CDTXMania.tテクスチャの解放(ref Chara_GoGoStart[i]);
            }
            for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_GoGoStart_Max; i++)
            {
                CDTXMania.tテクスチャの解放(ref Chara_GoGoStart_Maxed[i]);
            }
            for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_ClearIn; i++)
            {
                CDTXMania.tテクスチャの解放(ref Chara_Become_Cleared[i]);
            }
            for (int i = 0; i < CDTXMania.Skin.Game_Chara_Ptn_SoulIn; i++)
            {
                CDTXMania.tテクスチャの解放(ref Chara_Become_Maxed[i]);
            }
            CDTXMania.tテクスチャの解放(ref Chara_Balloon_Breaking);
            CDTXMania.tテクスチャの解放(ref Chara_Balloon_Broken);
            #endregion
            #region 踊り子
            for (int i = 0; i < 5; i++)
            {
                for (int p = 0; p < CDTXMania.Skin.Game_Dancer_Ptn; p++)
                {
                    CDTXMania.tテクスチャの解放(ref Dancer[i][p]);
                }
            }
            #endregion
            #region モブ
            for (int i = 0; i < CDTXMania.Skin.Game_Mob_Ptn; i++)
            {
                CDTXMania.tテクスチャの解放(ref Mob[i]);
            }
            #endregion
            #region フッター
            CDTXMania.tテクスチャの解放(ref Mob_Footer);
            #endregion
            #region 背景
            CDTXMania.tテクスチャの解放(ref Background);
            CDTXMania.tテクスチャの解放(ref Background_Up[0]);
            CDTXMania.tテクスチャの解放(ref Background_Up[1]);
            CDTXMania.tテクスチャの解放(ref Background_Up_Clear[0]);
            CDTXMania.tテクスチャの解放(ref Background_Up_Clear[1]);
            CDTXMania.tテクスチャの解放(ref Background_Down);
            CDTXMania.tテクスチャの解放(ref Background_Down_Clear);
            CDTXMania.tテクスチャの解放(ref Background_Down_Scroll);

            #endregion
            #region 太鼓
            CDTXMania.tテクスチャの解放(ref Taiko_Background[0]);
            CDTXMania.tテクスチャの解放(ref Taiko_Background[1]);
            CDTXMania.tテクスチャの解放(ref Taiko_Frame[0]);
            CDTXMania.tテクスチャの解放(ref Taiko_Frame[1]);
            CDTXMania.tテクスチャの解放(ref Taiko_PlayerNumber[0]);
            CDTXMania.tテクスチャの解放(ref Taiko_PlayerNumber[1]);
            CDTXMania.tテクスチャの解放(ref Taiko_NamePlate[0]);
            CDTXMania.tテクスチャの解放(ref Taiko_NamePlate[1]);
            CDTXMania.tテクスチャの解放(ref Taiko_Base);
            CDTXMania.tテクスチャの解放(ref Taiko_Don_Left);
            CDTXMania.tテクスチャの解放(ref Taiko_Don_Right);
            CDTXMania.tテクスチャの解放(ref Taiko_Ka_Left);
            CDTXMania.tテクスチャの解放(ref Taiko_Ka_Right);
            CDTXMania.tテクスチャの解放(ref Taiko_LevelUp);
            CDTXMania.tテクスチャの解放(ref Taiko_LevelDown);
            for (int i = 0; i < 6; i++)
            {
                CDTXMania.tテクスチャの解放(ref Couse_Symbol[i]);
            }
            CDTXMania.tテクスチャの解放(ref Taiko_Score[0]);
            CDTXMania.tテクスチャの解放(ref Taiko_Score[1]);
            CDTXMania.tテクスチャの解放(ref Taiko_Score[2]);
            CDTXMania.tテクスチャの解放(ref Taiko_Combo[0]);
            CDTXMania.tテクスチャの解放(ref Taiko_Combo[1]);
            CDTXMania.tテクスチャの解放(ref Taiko_Combo_Effect);
            CDTXMania.tテクスチャの解放(ref Taiko_Combo_Text);
            #endregion
            #region ゲージ
            CDTXMania.tテクスチャの解放(ref Gauge[0]);
            CDTXMania.tテクスチャの解放(ref Gauge[1]);
            CDTXMania.tテクスチャの解放(ref Gauge_Base[0]);
            CDTXMania.tテクスチャの解放(ref Gauge_Base[1]);
            CDTXMania.tテクスチャの解放(ref Gauge_Line[0]);
            CDTXMania.tテクスチャの解放(ref Gauge_Line[1]);
            for (int i = 0; i < CDTXMania.Skin.Game_Gauge_Rainbow_Ptn; i++)
            {
                CDTXMania.tテクスチャの解放(ref Gauge_Rainbow[i]);
            }
            CDTXMania.tテクスチャの解放(ref Gauge_Soul);
            CDTXMania.tテクスチャの解放(ref Gauge_Soul_Fire);
            CDTXMania.tテクスチャの解放(ref Gauge_Soul_Explosion[0]);
            CDTXMania.tテクスチャの解放(ref Gauge_Soul_Explosion[1]);
            #endregion
            #region 吹き出し
            CDTXMania.tテクスチャの解放(ref Balloon_Combo[0]);
            CDTXMania.tテクスチャの解放(ref Balloon_Combo[1]);
            CDTXMania.tテクスチャの解放(ref Balloon_Roll);
            CDTXMania.tテクスチャの解放(ref Balloon_Balloon);
            CDTXMania.tテクスチャの解放(ref Balloon_Number_Roll);
            CDTXMania.tテクスチャの解放(ref Balloon_Number_Combo);

            for (int i = 0; i < 6; i++)
            {
                CDTXMania.tテクスチャの解放(ref Balloon_Breaking[i]);
            }
            #endregion
            #region エフェクト
            CDTXMania.tテクスチャの解放(ref Effects_Hit_Explosion);
            CDTXMania.tテクスチャの解放(ref  Effects_Hit_Explosion_Big);
            CDTXMania.tテクスチャの解放(ref Effects_Hit_FireWorks[0]);
            CDTXMania.tテクスチャの解放(ref Effects_Hit_FireWorks[1]);

            CDTXMania.tテクスチャの解放(ref Effects_Fire);
            CDTXMania.tテクスチャの解放(ref Effects_Rainbow);

            for (int i = 0; i < 30; i++)
            {
                CDTXMania.tテクスチャの解放(ref Effects_Splash[i]);
            }
            for (int i = 0; i < 15; i++)
            {
                CDTXMania.tテクスチャの解放(ref Effects_Hit_Great[i]);
                CDTXMania.tテクスチャの解放(ref Effects_Hit_Great_Big[i]);
                CDTXMania.tテクスチャの解放(ref Effects_Hit_Good[i]);
                CDTXMania.tテクスチャの解放(ref Effects_Hit_Good_Big[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                CDTXMania.tテクスチャの解放(ref Effects_Roll[i]);
            }
            #endregion
            #region レーン
            for (int i = 0; i < 3; i++)
            {
                CDTXMania.tテクスチャの解放(ref Lane_Base[i]);
                CDTXMania.tテクスチャの解放(ref Lane_Text[i]);
            }
            CDTXMania.tテクスチャの解放(ref Lane_Red);
            CDTXMania.tテクスチャの解放(ref Lane_Blue);
            CDTXMania.tテクスチャの解放(ref Lane_Yellow);
            CDTXMania.tテクスチャの解放(ref Lane_Background_Main);
            CDTXMania.tテクスチャの解放(ref Lane_Background_Sub);
            CDTXMania.tテクスチャの解放(ref Lane_Background_GoGo);

            #endregion
            #region 終了演出
            for (int i = 0; i < 5; i++)
            {
                CDTXMania.tテクスチャの解放(ref End_Clear_L[i]);
                CDTXMania.tテクスチャの解放(ref End_Clear_R[i]);
            }
            CDTXMania.tテクスチャの解放(ref End_Clear_Text);
            CDTXMania.tテクスチャの解放(ref End_Clear_Text_Effect);
            #endregion
            #region ゲームモード
            CDTXMania.tテクスチャの解放(ref GameMode_Timer_Tick);
            CDTXMania.tテクスチャの解放(ref GameMode_Timer_Frame);
            #endregion
            #region ステージ失敗
            CDTXMania.tテクスチャの解放(ref Failed_Game);
            CDTXMania.tテクスチャの解放(ref Failed_Stage);
            #endregion
            #region ランナー
            CDTXMania.tテクスチャの解放(ref Runner);
            #endregion
            #endregion

            #region 6_結果発表
            CDTXMania.tテクスチャの解放(ref Result_Background);
            CDTXMania.tテクスチャの解放(ref Result_FadeIn);
            CDTXMania.tテクスチャの解放(ref Result_Gauge);
            CDTXMania.tテクスチャの解放(ref Result_Gauge_Base);
            CDTXMania.tテクスチャの解放(ref Result_Judge);
            CDTXMania.tテクスチャの解放(ref Result_Header);
            CDTXMania.tテクスチャの解放(ref Result_Number);
            CDTXMania.tテクスチャの解放(ref Result_Panel);
            CDTXMania.tテクスチャの解放(ref Result_Score_Text);
            CDTXMania.tテクスチャの解放(ref Result_Score_Number);
            #endregion

            #region 7_終了画面
            CDTXMania.tテクスチャの解放(ref Exit_Background);
            #endregion

        }

        #region 共通
        public CTexture Tile_Black,
            Tile_White,
            Menu_Title,
            Menu_Highlight,
            Enum_Song,
            Overlay;
        public CTexture[] NamePlate;
        #endregion
        #region 1_タイトル画面
        public CTexture Title_Background,
            Title_Menu;
        #endregion

        #region 2_コンフィグ画面
        public CTexture Config_Background,
            Config_Cursor,
            Config_ItemBox,
            Config_Arrow,
            Config_KeyAssign,
            Config_Font,
            Config_Font_Bold,
            Config_Enum_Song;
        #endregion

        #region 3_選曲画面
        public CTexture SongSelect_Background,
            SongSelect_Header,
            SongSelect_Footer,
            SongSelect_Difficulty,
            SongSelect_Auto,
            SongSelect_Level,
            SongSelect_Branch,
            SongSelect_Branch_Text,
            SongSelect_Frame_Score,
            SongSelect_Frame_Box,
            SongSelect_Frame_BackBox,
            SongSelect_Frame_Random,
            SongSelect_Score_Select,
            SongSelect_Bar_Center,
            SongSelect_GenreText,
            SongSelect_Cursor_Left,
            SongSelect_Cursor_Right,
            SongSelect_ScoreWindow_Text;
        public CTexture[] SongSelect_GenreBack = new CTexture[9],
            SongSelect_ScoreWindow = new CTexture[5],
            SongSelect_Bar_Genre = new CTexture[9],
            SongSelect_NamePlate = new CTexture[1];
        #endregion

        #region 4_読み込み画面
        public CTexture SongLoading_Plate,
            SongLoading_FadeIn,
            SongLoading_FadeOut;
        #endregion

        #region 5_演奏画面
        #region 共通
        public CTexture Notes,
            Judge_Frame,
            SenNotes,
            Notes_Arm,
            Judge;
        public CTexture Judge_Meter,
            Bar,
            Bar_Branch;
        #endregion
        #region キャラクター
        public CTexture[] Chara_Normal,
            Chara_Normal_Cleared,
            Chara_Normal_Maxed,
            Chara_GoGoTime,
            Chara_GoGoTime_Maxed,
            Chara_10Combo,
            Chara_10Combo_Maxed,
            Chara_GoGoStart,
            Chara_GoGoStart_Maxed,
            Chara_Become_Cleared,
            Chara_Become_Maxed;
        public CTexture Chara_Balloon_Breaking,
            Chara_Balloon_Broken;
        #endregion
        #region 踊り子
        public CTexture[][] Dancer;
        #endregion
        #region モブ
        public CTexture[] Mob;
        public CTexture Mob_Footer;
        #endregion
        #region 背景
        public CTexture Background,
            Background_Down,
            Background_Down_Clear,
            Background_Down_Scroll;
        public CTexture[] Background_Up,
            Background_Up_Clear;
        #endregion
        #region 太鼓
        public CTexture[] Taiko_Frame, // MTaiko下敷き
            Taiko_Background;
        public CTexture Taiko_Base,
            Taiko_Don_Left,
            Taiko_Don_Right,
            Taiko_Ka_Left,
            Taiko_Ka_Right,
            Taiko_LevelUp,
            Taiko_LevelDown,
            Taiko_Combo_Effect,
            Taiko_Combo_Text;
        public CTexture[] Couse_Symbol, // コースシンボル
            Taiko_PlayerNumber,
            Taiko_NamePlate; // ネームプレート
        public CTexture[] Taiko_Score,
            Taiko_Combo;
        #endregion
        #region ゲージ
        public CTexture[] Gauge,
            Gauge_Base,
            Gauge_Line,
            Gauge_Rainbow,
            Gauge_Soul_Explosion;
        public CTexture Gauge_Soul,
            Gauge_Soul_Fire;
        #endregion
        #region 吹き出し
        public CTexture[] Balloon_Combo;
        public CTexture Balloon_Roll,
            Balloon_Balloon,
            Balloon_Number_Roll,
            Balloon_Number_Combo/*,*/
                                /*Balloon_Broken*/;
        public CTexture[] Balloon_Breaking;
        #endregion
        #region エフェクト
        public CTexture Effects_Hit_Explosion,
            Effects_Hit_Explosion_Big,
            Effects_Fire,
            Effects_Rainbow;
        public CTexture[] Effects_Splash;
        public CTextureAf[] Effects_Hit_FireWorks;
        public CTexture[] Effects_Hit_Great,
            Effects_Hit_Good,
            Effects_Hit_Great_Big,
            Effects_Hit_Good_Big;
        public CTexture[] Effects_Roll;
        #endregion
        #region レーン
        public CTexture[] Lane_Base,
            Lane_Text;
        public CTexture Lane_Red,
            Lane_Blue,
            Lane_Yellow;
        public CTexture Lane_Background_Main,
            Lane_Background_Sub,
            Lane_Background_GoGo;
        #endregion
        #region 終了演出
        public CTexture[] End_Clear_L,
            End_Clear_R;
        public CTexture End_Clear_Text,
            End_Clear_Text_Effect;
        #endregion
        #region ゲームモード
        public CTexture GameMode_Timer_Frame,
            GameMode_Timer_Tick;
        #endregion
        #region ステージ失敗
        public CTexture Failed_Game,
            Failed_Stage;
        #endregion
        #region ランナー
        public CTexture Runner;
        #endregion
        #endregion

        #region 6_結果発表
        public CTexture Result_Background,
            Result_FadeIn,
            Result_Gauge,
            Result_Gauge_Base,
            Result_Judge,
            Result_Header,
            Result_Number,
            Result_Panel,
            Result_Score_Text,
            Result_Score_Number;
        #endregion

        #region 7_終了画面
        public CTexture Exit_Background/* , */
                                       /*Exit_Text */;
        #endregion

    }
}
