using FDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TJAPlayer3
{
    class TextureLoader
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
        const string PUCHICHARA = @"18_PuchiChara\";
        const string DANC = @"17_DanC\";

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
            return TJAPlayer3.tテクスチャの生成(CSkin.Path(BASE + FileName));
        }
        internal CTextureAf TxCAf(string FileName)
        {
            return TJAPlayer3.tテクスチャの生成Af(CSkin.Path(BASE + FileName));
        }
        internal CTexture TxCGen(string FileName)
        {
            return TJAPlayer3.tテクスチャの生成(CSkin.Path(BASE + GAME + GENRE + FileName + ".png"));
        }

        public void LoadTexture()
        {
            #region 共通
            Tile_Black = TxC(@"Tile_Black.png");
            Tile_White = TxC(@"Tile_White.png");
            Menu_Title = TxC(@"Menu_Title.png");
            Menu_Highlight = TxC(@"Menu_Highlight.png");
            Enum_Song = TxC(@"Enum_Song.png");
            Scanning_Loudness = TxC(@"Scanning_Loudness.png");
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
            for (int i = 0; i < (int)Difficulty.Total; i++)
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
            SENotes = TxC(GAME + @"SENotes.png");
            Notes_Arm = TxC(GAME + @"Notes_Arm.png");
            Judge = TxC(GAME + @"Judge.png");

            Judge_Meter = TxC(GAME + @"Judge_Meter.png");
            Bar = TxC(GAME + @"Bar.png");
            Bar_Branch = TxC(GAME + @"Bar_Branch.png");

            #endregion
            #region キャラクター
            for (int nPlayer = 0; nPlayer < 2; nPlayer++)
            {
                string Player = (nPlayer + 1).ToString() + @"P\";
                TJAPlayer3.Skin.Game_Chara_Ptn_Normal[nPlayer] = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + Player +  @"Normal\"));
                if (TJAPlayer3.Skin.Game_Chara_Ptn_Normal[nPlayer] != 0)
                {
                    Chara_Normal[nPlayer] = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_Normal[nPlayer]];
                    for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Normal[nPlayer]; i++)
                    {
                        Chara_Normal[nPlayer][i] = TxC(GAME + CHARA + Player + @"Normal\" + i.ToString() + ".png");
                    }
                }
                TJAPlayer3.Skin.Game_Chara_Ptn_Clear[nPlayer] = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + Player + @"Clear\"));
                if (TJAPlayer3.Skin.Game_Chara_Ptn_Clear[nPlayer] != 0)
                {
                    Chara_Normal_Cleared[nPlayer] = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_Clear[nPlayer]];
                    for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Clear[nPlayer]; i++)
                    {
                        Chara_Normal_Cleared[nPlayer][i] = TxC(GAME + CHARA + Player + @"Clear\" + i.ToString() + ".png");
                    }
                }
                if (TJAPlayer3.Skin.Game_Chara_Ptn_Clear[nPlayer] != 0)
                {
                    Chara_Normal_Maxed[nPlayer] = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_Clear[nPlayer]];
                    for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Clear[nPlayer]; i++)
                    {
                        Chara_Normal_Maxed[nPlayer][i] = TxC(GAME + CHARA + Player + @"Clear_Max\" + i.ToString() + ".png");
                    }
                }
                TJAPlayer3.Skin.Game_Chara_Ptn_GoGo[nPlayer] = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + Player + @"GoGo\"));
                if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGo[nPlayer] != 0)
                {
                    Chara_GoGoTime[nPlayer] = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_GoGo[nPlayer]];
                    for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_GoGo[nPlayer]; i++)
                    {
                        Chara_GoGoTime[nPlayer][i] = TxC(GAME + CHARA + Player + @"GoGo\" + i.ToString() + ".png");
                    }
                }
                if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGo[nPlayer] != 0)
                {
                    Chara_GoGoTime_Maxed[nPlayer] = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_GoGo[nPlayer]];
                    for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_GoGo[nPlayer]; i++)
                    {
                        Chara_GoGoTime_Maxed[nPlayer][i] = TxC(GAME + CHARA + Player + @"GoGo_Max\" + i.ToString() + ".png");
                    }
                }

                TJAPlayer3.Skin.Game_Chara_Ptn_10combo[nPlayer] = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + Player + @"10combo\"));
                if (TJAPlayer3.Skin.Game_Chara_Ptn_10combo[nPlayer] != 0)
                {
                    Chara_10Combo[nPlayer] = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_10combo[nPlayer]];
                    for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_10combo[nPlayer]; i++)
                    {
                        Chara_10Combo[nPlayer][i] = TxC(GAME + CHARA + Player + @"10combo\" + i.ToString() + ".png");
                    }
                }
                TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max[nPlayer] = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + Player + @"10combo_Max\"));
                if (TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max[nPlayer] != 0)
                {
                    Chara_10Combo_Maxed[nPlayer] = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max[nPlayer]];
                    for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max[nPlayer]; i++)
                    {
                        Chara_10Combo_Maxed[nPlayer][i] = TxC(GAME + CHARA + Player + @"10combo_Max\" + i.ToString() + ".png");
                    }
                }

                TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart[nPlayer] = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + Player + @"GoGoStart\"));
                if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart[nPlayer] != 0)
                {
                    Chara_GoGoStart[nPlayer] = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart[nPlayer]];
                    for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart[nPlayer]; i++)
                    {
                        Chara_GoGoStart[nPlayer][i] = TxC(GAME + CHARA + Player + @"GoGoStart\" + i.ToString() + ".png");
                    }
                }
                TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max[nPlayer] = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + Player + @"GoGoStart_Max\"));
                if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max[nPlayer] != 0)
                {
                    Chara_GoGoStart_Maxed[nPlayer] = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max[nPlayer]];
                    for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max[nPlayer]; i++)
                    {
                        Chara_GoGoStart_Maxed[nPlayer][i] = TxC(GAME + CHARA + Player + @"GoGoStart_Max\" + i.ToString() + ".png");
                    }
                }
                TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn[nPlayer] = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + Player + @"ClearIn\"));
                if (TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn[nPlayer] != 0)
                {
                    Chara_Become_Cleared[nPlayer] = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn[nPlayer]];
                    for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn[nPlayer]; i++)
                    {
                        Chara_Become_Cleared[nPlayer][i] = TxC(GAME + CHARA + Player + @"ClearIn\" + i.ToString() + ".png");
                    }
                }
                TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn[nPlayer] = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + Player + @"SoulIn\"));
                if (TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn[nPlayer] != 0)
                {
                    Chara_Become_Maxed[nPlayer] = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn[nPlayer]];
                    for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn[nPlayer]; i++)
                    {
                        Chara_Become_Maxed[nPlayer][i] = TxC(GAME + CHARA + Player + @"SoulIn\" + i.ToString() + ".png");
                    }
                }
                TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Breaking[nPlayer] = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + Player + @"Balloon_Breaking\"));
                if (TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Breaking[nPlayer] != 0)
                {
                    Chara_Balloon_Breaking[nPlayer] = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Breaking[nPlayer]];
                    for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Breaking[nPlayer]; i++)
                    {
                        Chara_Balloon_Breaking[nPlayer][i] = TxC(GAME + CHARA + Player + @"Balloon_Breaking\" + i.ToString() + ".png");
                    }
                }
                TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke[nPlayer] = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + Player + @"Balloon_Broke\"));
                if (TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke[nPlayer] != 0)
                {
                    Chara_Balloon_Broke[nPlayer] = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke[nPlayer]];
                    for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke[nPlayer]; i++)
                    {
                        Chara_Balloon_Broke[nPlayer][i] = TxC(GAME + CHARA + Player + @"Balloon_Broke\" + i.ToString() + ".png");
                    }
                }
                TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss[nPlayer] = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + Player + @"Balloon_Miss\"));
                if (TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss[nPlayer] != 0)
                {
                    Chara_Balloon_Miss[nPlayer] = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss[nPlayer]];
                    for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss[nPlayer]; i++)
                    {
                        Chara_Balloon_Miss[nPlayer][i] = TxC(GAME + CHARA + Player + @"Balloon_Miss\" + i.ToString() + ".png");
                    }
                }
            }
            #endregion
            #region 踊り子
            TJAPlayer3.Skin.Game_Dancer_Ptn = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + DANCER + @"1\"));
            if (TJAPlayer3.Skin.Game_Dancer_Ptn != 0)
            {
                Dancer = new CTexture[5][];
                for (int i = 0; i < 5; i++)
                {
                    Dancer[i] = new CTexture[TJAPlayer3.Skin.Game_Dancer_Ptn];
                    for (int p = 0; p < TJAPlayer3.Skin.Game_Dancer_Ptn; p++)
                    {
                        Dancer[i][p] = TxC(GAME + DANCER + (i + 1) + @"\" + p.ToString() + ".png");
                    }
                }
            }
            #endregion
            #region モブ
            TJAPlayer3.Skin.Game_Mob_Ptn = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + MOB));
            Mob = new CTexture[TJAPlayer3.Skin.Game_Mob_Ptn];
            for (int i = 0; i < TJAPlayer3.Skin.Game_Mob_Ptn; i++)
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
            Couse_Symbol = new CTexture[(int)Difficulty.Total + 1]; // +1は真打ちモードの分
            string[] Couse_Symbols = new string[(int)Difficulty.Total + 1] { "Easy", "Normal", "Hard", "Oni", "Edit", "Tower", "Dan", "Shin" };
            for (int i = 0; i < (int)Difficulty.Total + 1; i++)
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
            TJAPlayer3.Skin.Game_Gauge_Rainbow_Ptn = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + GAUGE + @"Rainbow\"));
            if (TJAPlayer3.Skin.Game_Gauge_Rainbow_Ptn != 0)
            {
                Gauge_Rainbow = new CTexture[TJAPlayer3.Skin.Game_Gauge_Rainbow_Ptn];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Gauge_Rainbow_Ptn; i++)
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
            if (Effects_Hit_Explosion != null) Effects_Hit_Explosion.b加算合成 = TJAPlayer3.Skin.Game_Effect_HitExplosion_AddBlend;
            Effects_Hit_Explosion_Big = TxC(GAME + EFFECTS + @"Hit\Explosion_Big.png");
            if (Effects_Hit_Explosion_Big != null) Effects_Hit_Explosion_Big.b加算合成 = TJAPlayer3.Skin.Game_Effect_HitExplosionBig_AddBlend;
            Effects_Hit_FireWorks = TxC(GAME + EFFECTS + @"Hit\FireWorks.png");
            if (Effects_Hit_FireWorks != null) Effects_Hit_FireWorks.b加算合成 = TJAPlayer3.Skin.Game_Effect_FireWorks_AddBlend;


            Effects_Fire = TxC(GAME + EFFECTS + @"Fire.png");
            if (Effects_Fire != null) Effects_Fire.b加算合成 = TJAPlayer3.Skin.Game_Effect_Fire_AddBlend;

            Effects_Rainbow = TxC(GAME + EFFECTS + @"Rainbow.png");

            Effects_GoGoSplash = TxC(GAME + EFFECTS + @"GoGoSplash.png");
            if (Effects_GoGoSplash != null) Effects_GoGoSplash.b加算合成 = TJAPlayer3.Skin.Game_Effect_GoGoSplash_AddBlend;
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
            TJAPlayer3.Skin.Game_Effect_Roll_Ptn = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + EFFECTS + @"Roll\"));
            Effects_Roll = new CTexture[TJAPlayer3.Skin.Game_Effect_Roll_Ptn];
            for (int i = 0; i < TJAPlayer3.Skin.Game_Effect_Roll_Ptn; i++)
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
            #region DanC
            DanC_Background = TxC(GAME + DANC + @"Background.png");
            DanC_Gauge = new CTexture[4];
            var type = new string[] { "Normal", "Reach", "Clear", "Flush" };
            for (int i = 0; i < 4; i++)
            {
                DanC_Gauge[i] = TxC(GAME + DANC + @"Gauge_" + type[i] + ".png");
            }
            DanC_Base = TxC(GAME + DANC + @"Base.png");
            DanC_Failed = TxC(GAME + DANC + @"Failed.png");
            DanC_Number = TxC(GAME + DANC + @"Number.png");
            DanC_ExamType = TxC(GAME + DANC + @"ExamType.png");
            DanC_ExamRange = TxC(GAME + DANC + @"ExamRange.png");
            DanC_ExamUnit = TxC(GAME + DANC + @"ExamUnit.png");
            DanC_Screen = TxC(GAME + DANC + @"Screen.png");
            #endregion
            #region PuichiChara
            PuchiChara = TxC(GAME + PUCHICHARA + @"0.png");
            #endregion
            #endregion

            #region 6_結果発表

            Result_Judge = TxC(RESULT + @"Judge.png");
            Result_Number = TxC(RESULT + @"Number.png");
            Result_Panel = TxC(RESULT + @"Panel.png");
            Result_Score_Text = TxC(RESULT + @"Score_Text.png");
            Result_Score_Number = TxC(RESULT + @"Score_Number.png");
            Result_Dan = TxC(RESULT + @"Dan.png");
            Result_Background[0] = TxC(RESULT + @"Background.png");
            Result_FadeIn[0] = TxC(RESULT + @"FadeIn.png");
            Result_Header[0] = TxC(RESULT + @"Header.png");
            Result_Background[1] = TxC(RESULT + @"Background_2P.png");
            Result_FadeIn[1] = TxC(RESULT + @"FadeIn_2P.png");
            Result_Header[1] = TxC(RESULT + @"Header_2P.png");
            for (int i = 0; i < 2; i++)
            {
                Result_Gauge[i] = TxC(RESULT + @"Gauge_" + (i + 1).ToString() + "P.png");
                Result_Gauge_Base[i] = TxC(RESULT + @"Gauge_Base_" + (i + 1).ToString() + "P.png");
            }
            #endregion

            #region 7_終了画面
            Exit_Background = TxC(EXIT + @"Background.png");
            #endregion

        }

        public void DisposeTexture()
        {
            TJAPlayer3.tテクスチャの解放(ref Title_Background);
            TJAPlayer3.tテクスチャの解放(ref Title_Menu);
            #region 共通
            TJAPlayer3.tテクスチャの解放(ref Tile_Black);
            TJAPlayer3.tテクスチャの解放(ref Tile_White);
            TJAPlayer3.tテクスチャの解放(ref Menu_Title);
            TJAPlayer3.tテクスチャの解放(ref Menu_Highlight);
            TJAPlayer3.tテクスチャの解放(ref Enum_Song);
            TJAPlayer3.tテクスチャの解放(ref Scanning_Loudness);
            TJAPlayer3.tテクスチャの解放(ref Overlay);
            for (int i = 0; i < 2; i++)
            {
                TJAPlayer3.tテクスチャの解放(ref NamePlate[i]);
            }

            #endregion
            #region 1_タイトル画面
            TJAPlayer3.tテクスチャの解放(ref Title_Background);
            TJAPlayer3.tテクスチャの解放(ref Title_Menu);
            #endregion

            #region 2_コンフィグ画面
            TJAPlayer3.tテクスチャの解放(ref Config_Background);
            TJAPlayer3.tテクスチャの解放(ref Config_Cursor);
            TJAPlayer3.tテクスチャの解放(ref Config_ItemBox);
            TJAPlayer3.tテクスチャの解放(ref Config_Arrow);
            TJAPlayer3.tテクスチャの解放(ref Config_KeyAssign);
            TJAPlayer3.tテクスチャの解放(ref Config_Font);
            TJAPlayer3.tテクスチャの解放(ref Config_Font_Bold);
            TJAPlayer3.tテクスチャの解放(ref Config_Enum_Song);
            #endregion

            #region 3_選曲画面
            TJAPlayer3.tテクスチャの解放(ref SongSelect_Background);
            TJAPlayer3.tテクスチャの解放(ref SongSelect_Header);
            TJAPlayer3.tテクスチャの解放(ref SongSelect_Footer);
            TJAPlayer3.tテクスチャの解放(ref SongSelect_Difficulty);
            TJAPlayer3.tテクスチャの解放(ref SongSelect_Auto);
            TJAPlayer3.tテクスチャの解放(ref SongSelect_Level);
            TJAPlayer3.tテクスチャの解放(ref SongSelect_Branch);
            TJAPlayer3.tテクスチャの解放(ref SongSelect_Branch_Text);
            TJAPlayer3.tテクスチャの解放(ref SongSelect_Bar_Center);
            TJAPlayer3.tテクスチャの解放(ref SongSelect_Frame_Score);
            TJAPlayer3.tテクスチャの解放(ref SongSelect_Frame_Box);
            TJAPlayer3.tテクスチャの解放(ref SongSelect_Frame_BackBox);
            TJAPlayer3.tテクスチャの解放(ref SongSelect_Frame_Random);
            TJAPlayer3.tテクスチャの解放(ref SongSelect_Score_Select);
            TJAPlayer3.tテクスチャの解放(ref SongSelect_GenreText);
            TJAPlayer3.tテクスチャの解放(ref SongSelect_Cursor_Left);
            TJAPlayer3.tテクスチャの解放(ref SongSelect_Cursor_Right);
            for (int i = 0; i < 9; i++)
            {
                TJAPlayer3.tテクスチャの解放(ref SongSelect_Bar_Genre[i]);
            }
            for (int i = 0; i < (int)Difficulty.Total; i++)
            {
                TJAPlayer3.tテクスチャの解放(ref SongSelect_ScoreWindow[i]);
            }

            for (int i = 0; i < 9; i++)
            {
                TJAPlayer3.tテクスチャの解放(ref SongSelect_GenreBack[i]);
            }
            TJAPlayer3.tテクスチャの解放(ref SongSelect_ScoreWindow_Text);
            #endregion

            #region 4_読み込み画面
            TJAPlayer3.tテクスチャの解放(ref SongLoading_Plate);
            TJAPlayer3.tテクスチャの解放(ref SongLoading_FadeIn);
            TJAPlayer3.tテクスチャの解放(ref SongLoading_FadeOut);
            #endregion

            #region 5_演奏画面
            #region 共通
            TJAPlayer3.tテクスチャの解放(ref Notes);
            TJAPlayer3.tテクスチャの解放(ref Judge_Frame);
            TJAPlayer3.tテクスチャの解放(ref SENotes);
            TJAPlayer3.tテクスチャの解放(ref Notes_Arm);
            TJAPlayer3.tテクスチャの解放(ref Judge);

            TJAPlayer3.tテクスチャの解放(ref Judge_Meter);
            TJAPlayer3.tテクスチャの解放(ref Bar);
            TJAPlayer3.tテクスチャの解放(ref Bar_Branch);

            #endregion
            #region キャラクター
            for (int nPlayer = 0; nPlayer < 2; nPlayer++)
            {
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Normal[nPlayer]; i++)
                {
                    TJAPlayer3.tテクスチャの解放(ref Chara_Normal[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Clear[nPlayer]; i++)
                {
                    TJAPlayer3.tテクスチャの解放(ref Chara_Normal_Cleared[nPlayer][i]);
                    TJAPlayer3.tテクスチャの解放(ref Chara_Normal_Maxed[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_GoGo[nPlayer]; i++)
                {
                    TJAPlayer3.tテクスチャの解放(ref Chara_GoGoTime[nPlayer][i]);
                    TJAPlayer3.tテクスチャの解放(ref Chara_GoGoTime_Maxed[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_10combo[nPlayer]; i++)
                {
                    TJAPlayer3.tテクスチャの解放(ref Chara_10Combo[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max[nPlayer]; i++)
                {
                    TJAPlayer3.tテクスチャの解放(ref Chara_10Combo_Maxed[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart[nPlayer]; i++)
                {
                    TJAPlayer3.tテクスチャの解放(ref Chara_GoGoStart[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max[nPlayer]; i++)
                {
                    TJAPlayer3.tテクスチャの解放(ref Chara_GoGoStart_Maxed[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn[nPlayer]; i++)
                {
                    TJAPlayer3.tテクスチャの解放(ref Chara_Become_Cleared[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn[nPlayer]; i++)
                {
                    TJAPlayer3.tテクスチャの解放(ref Chara_Become_Maxed[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Breaking[nPlayer]; i++)
                {
                    TJAPlayer3.tテクスチャの解放(ref Chara_Balloon_Breaking[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke[nPlayer]; i++)
                {
                    TJAPlayer3.tテクスチャの解放(ref Chara_Balloon_Broke[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss[nPlayer]; i++)
                {
                    TJAPlayer3.tテクスチャの解放(ref Chara_Balloon_Miss[nPlayer][i]);
                }
            }
            #endregion
            #region 踊り子
            for (int i = 0; i < 5; i++)
            {
                for (int p = 0; p < TJAPlayer3.Skin.Game_Dancer_Ptn; p++)
                {
                    TJAPlayer3.tテクスチャの解放(ref Dancer[i][p]);
                }
            }
            #endregion
            #region モブ
            for (int i = 0; i < TJAPlayer3.Skin.Game_Mob_Ptn; i++)
            {
                TJAPlayer3.tテクスチャの解放(ref Mob[i]);
            }
            #endregion
            #region フッター
            TJAPlayer3.tテクスチャの解放(ref Mob_Footer);
            #endregion
            #region 背景
            TJAPlayer3.tテクスチャの解放(ref Background);
            TJAPlayer3.tテクスチャの解放(ref Background_Up[0]);
            TJAPlayer3.tテクスチャの解放(ref Background_Up[1]);
            TJAPlayer3.tテクスチャの解放(ref Background_Up_Clear[0]);
            TJAPlayer3.tテクスチャの解放(ref Background_Up_Clear[1]);
            TJAPlayer3.tテクスチャの解放(ref Background_Down);
            TJAPlayer3.tテクスチャの解放(ref Background_Down_Clear);
            TJAPlayer3.tテクスチャの解放(ref Background_Down_Scroll);

            #endregion
            #region 太鼓
            TJAPlayer3.tテクスチャの解放(ref Taiko_Background[0]);
            TJAPlayer3.tテクスチャの解放(ref Taiko_Background[1]);
            TJAPlayer3.tテクスチャの解放(ref Taiko_Frame[0]);
            TJAPlayer3.tテクスチャの解放(ref Taiko_Frame[1]);
            TJAPlayer3.tテクスチャの解放(ref Taiko_PlayerNumber[0]);
            TJAPlayer3.tテクスチャの解放(ref Taiko_PlayerNumber[1]);
            TJAPlayer3.tテクスチャの解放(ref Taiko_NamePlate[0]);
            TJAPlayer3.tテクスチャの解放(ref Taiko_NamePlate[1]);
            TJAPlayer3.tテクスチャの解放(ref Taiko_Base);
            TJAPlayer3.tテクスチャの解放(ref Taiko_Don_Left);
            TJAPlayer3.tテクスチャの解放(ref Taiko_Don_Right);
            TJAPlayer3.tテクスチャの解放(ref Taiko_Ka_Left);
            TJAPlayer3.tテクスチャの解放(ref Taiko_Ka_Right);
            TJAPlayer3.tテクスチャの解放(ref Taiko_LevelUp);
            TJAPlayer3.tテクスチャの解放(ref Taiko_LevelDown);
            for (int i = 0; i < 6; i++)
            {
                TJAPlayer3.tテクスチャの解放(ref Couse_Symbol[i]);
            }
            TJAPlayer3.tテクスチャの解放(ref Taiko_Score[0]);
            TJAPlayer3.tテクスチャの解放(ref Taiko_Score[1]);
            TJAPlayer3.tテクスチャの解放(ref Taiko_Score[2]);
            TJAPlayer3.tテクスチャの解放(ref Taiko_Combo[0]);
            TJAPlayer3.tテクスチャの解放(ref Taiko_Combo[1]);
            TJAPlayer3.tテクスチャの解放(ref Taiko_Combo_Effect);
            TJAPlayer3.tテクスチャの解放(ref Taiko_Combo_Text);
            #endregion
            #region ゲージ
            TJAPlayer3.tテクスチャの解放(ref Gauge[0]);
            TJAPlayer3.tテクスチャの解放(ref Gauge[1]);
            TJAPlayer3.tテクスチャの解放(ref Gauge_Base[0]);
            TJAPlayer3.tテクスチャの解放(ref Gauge_Base[1]);
            TJAPlayer3.tテクスチャの解放(ref Gauge_Line[0]);
            TJAPlayer3.tテクスチャの解放(ref Gauge_Line[1]);
            for (int i = 0; i < TJAPlayer3.Skin.Game_Gauge_Rainbow_Ptn; i++)
            {
                TJAPlayer3.tテクスチャの解放(ref Gauge_Rainbow[i]);
            }
            TJAPlayer3.tテクスチャの解放(ref Gauge_Soul);
            TJAPlayer3.tテクスチャの解放(ref Gauge_Soul_Fire);
            TJAPlayer3.tテクスチャの解放(ref Gauge_Soul_Explosion[0]);
            TJAPlayer3.tテクスチャの解放(ref Gauge_Soul_Explosion[1]);
            #endregion
            #region 吹き出し
            TJAPlayer3.tテクスチャの解放(ref Balloon_Combo[0]);
            TJAPlayer3.tテクスチャの解放(ref Balloon_Combo[1]);
            TJAPlayer3.tテクスチャの解放(ref Balloon_Roll);
            TJAPlayer3.tテクスチャの解放(ref Balloon_Balloon);
            TJAPlayer3.tテクスチャの解放(ref Balloon_Number_Roll);
            TJAPlayer3.tテクスチャの解放(ref Balloon_Number_Combo);

            for (int i = 0; i < 6; i++)
            {
                TJAPlayer3.tテクスチャの解放(ref Balloon_Breaking[i]);
            }
            #endregion
            #region エフェクト
            TJAPlayer3.tテクスチャの解放(ref Effects_Hit_Explosion);
            TJAPlayer3.tテクスチャの解放(ref  Effects_Hit_Explosion_Big);
            TJAPlayer3.tテクスチャの解放(ref Effects_Hit_FireWorks);

            TJAPlayer3.tテクスチャの解放(ref Effects_Fire);
            TJAPlayer3.tテクスチャの解放(ref Effects_Rainbow);

            TJAPlayer3.tテクスチャの解放(ref Effects_GoGoSplash);

            for (int i = 0; i < 15; i++)
            {
                TJAPlayer3.tテクスチャの解放(ref Effects_Hit_Great[i]);
                TJAPlayer3.tテクスチャの解放(ref Effects_Hit_Great_Big[i]);
                TJAPlayer3.tテクスチャの解放(ref Effects_Hit_Good[i]);
                TJAPlayer3.tテクスチャの解放(ref Effects_Hit_Good_Big[i]);
            }
            for (int i = 0; i < TJAPlayer3.Skin.Game_Effect_Roll_Ptn; i++)
            {
                TJAPlayer3.tテクスチャの解放(ref Effects_Roll[i]);
            }
            #endregion
            #region レーン
            for (int i = 0; i < 3; i++)
            {
                TJAPlayer3.tテクスチャの解放(ref Lane_Base[i]);
                TJAPlayer3.tテクスチャの解放(ref Lane_Text[i]);
            }
            TJAPlayer3.tテクスチャの解放(ref Lane_Red);
            TJAPlayer3.tテクスチャの解放(ref Lane_Blue);
            TJAPlayer3.tテクスチャの解放(ref Lane_Yellow);
            TJAPlayer3.tテクスチャの解放(ref Lane_Background_Main);
            TJAPlayer3.tテクスチャの解放(ref Lane_Background_Sub);
            TJAPlayer3.tテクスチャの解放(ref Lane_Background_GoGo);

            #endregion
            #region 終了演出
            for (int i = 0; i < 5; i++)
            {
                TJAPlayer3.tテクスチャの解放(ref End_Clear_L[i]);
                TJAPlayer3.tテクスチャの解放(ref End_Clear_R[i]);
            }
            TJAPlayer3.tテクスチャの解放(ref End_Clear_Text);
            TJAPlayer3.tテクスチャの解放(ref End_Clear_Text_Effect);
            #endregion
            #region ゲームモード
            TJAPlayer3.tテクスチャの解放(ref GameMode_Timer_Tick);
            TJAPlayer3.tテクスチャの解放(ref GameMode_Timer_Frame);
            #endregion
            #region ステージ失敗
            TJAPlayer3.tテクスチャの解放(ref Failed_Game);
            TJAPlayer3.tテクスチャの解放(ref Failed_Stage);
            #endregion
            #region ランナー
            TJAPlayer3.tテクスチャの解放(ref Runner);
            #endregion
            #region DanC
            DanC_Background?.Dispose();
            for (int i = 0; i < 4; i++)
            {
                DanC_Gauge[i]?.Dispose();
            }
            DanC_Base?.Dispose();
            DanC_Failed?.Dispose();
            DanC_Number?.Dispose();
            DanC_ExamRange?.Dispose();
            DanC_ExamUnit?.Dispose();
            DanC_ExamType?.Dispose();
            DanC_Screen?.Dispose();
            #endregion
            #region PuchiChara
            TJAPlayer3.tテクスチャの解放(ref PuchiChara);
            #endregion
            #endregion

            #region 6_結果発表
            TJAPlayer3.tテクスチャの解放(ref Result_Judge);
            TJAPlayer3.tテクスチャの解放(ref Result_Number);
            TJAPlayer3.tテクスチャの解放(ref Result_Panel);
            TJAPlayer3.tテクスチャの解放(ref Result_Score_Text);
            TJAPlayer3.tテクスチャの解放(ref Result_Score_Number);
            TJAPlayer3.tテクスチャの解放(ref Result_Dan);
            for (int i = 0; i < 2; i++)
            {
                TJAPlayer3.tテクスチャの解放(ref Result_Gauge[i]);
                TJAPlayer3.tテクスチャの解放(ref Result_Gauge_Base[i]);
                TJAPlayer3.tテクスチャの解放(ref Result_Header[i]);
                TJAPlayer3.tテクスチャの解放(ref Result_Background[i]);
                TJAPlayer3.tテクスチャの解放(ref Result_FadeIn[i]);
            }
            #endregion

            #region 7_終了画面
            TJAPlayer3.tテクスチャの解放(ref Exit_Background);
            #endregion

        }

        #region 共通
        public CTexture Tile_Black,
            Tile_White,
            Menu_Title,
            Menu_Highlight,
            Enum_Song,
            Scanning_Loudness,
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
            SongSelect_ScoreWindow = new CTexture[(int)Difficulty.Total],
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
            SENotes,
            Notes_Arm,
            Judge;
        public CTexture Judge_Meter,
            Bar,
            Bar_Branch;
        #endregion
        #region キャラクター
        public CTexture[][] Chara_Normal = new CTexture[2][],
            Chara_Normal_Cleared = new CTexture[2][],
            Chara_Normal_Maxed = new CTexture[2][],
            Chara_GoGoTime = new CTexture[2][],
            Chara_GoGoTime_Maxed = new CTexture[2][],
            Chara_10Combo = new CTexture[2][],
            Chara_10Combo_Maxed = new CTexture[2][],
            Chara_GoGoStart = new CTexture[2][],
            Chara_GoGoStart_Maxed = new CTexture[2][],
            Chara_Become_Cleared = new CTexture[2][],
            Chara_Become_Maxed = new CTexture[2][],
            Chara_Balloon_Breaking = new CTexture[2][],
            Chara_Balloon_Broke = new CTexture[2][],
            Chara_Balloon_Miss = new CTexture[2][];
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
            Effects_Rainbow,
            Effects_GoGoSplash,
            Effects_Hit_FireWorks;
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
        #region DanC
        public CTexture DanC_Background;
        public CTexture[] DanC_Gauge;
        public CTexture DanC_Base;
        public CTexture DanC_Failed;
        public CTexture DanC_Number,
            DanC_ExamType,
            DanC_ExamRange,
            DanC_ExamUnit;
        public CTexture DanC_Screen;
        #endregion
        #region PuchiChara
        public CTexture PuchiChara;
        #endregion
        #endregion

        #region 6_結果発表
        public CTexture Result_Judge,
            Result_Number,
            Result_Panel,
            Result_Score_Text,
            Result_Score_Number,
            Result_Dan;
        public CTexture[] Result_Gauge = new CTexture[2],
            Result_Gauge_Base = new CTexture[2],
            Result_Background = new CTexture[2],
            Result_Header = new CTexture[2],
            Result_FadeIn = new CTexture[2];
        #endregion

        #region 7_終了画面
        public CTexture Exit_Background/* , */
                                       /*Exit_Text */;
        #endregion

    }
}
