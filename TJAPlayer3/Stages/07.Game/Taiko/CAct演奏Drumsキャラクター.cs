using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;
using FDK;


namespace TJAPlayer3
{
    //クラスの設置位置は必ず演奏画面共通に置くこと。
    //そうしなければBPM変化に対応できません。

    //完成している部分は以下のとおり。(画像完成+動作確認完了で完成とする)
    //_通常モーション
    //_ゴーゴータイムモーション
    //_クリア時モーション
    //
    internal class CAct演奏Drumsキャラクター : CActivity
    {
        public CAct演奏Drumsキャラクター()
        {

        }

        public override void On活性化()
        {

            this.b演奏中 = false;

            // ふうせん系アニメーションの総再生時間は画像枚数 x Tick間隔なので、
            // フェードアウトの開始タイミングは、総再生時間 - フェードアウト時間。
            var tick = TJAPlayer3.Skin.Game_Chara_Balloon_Timer;
            var balloonBrokePtn = TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke;
            var balloonMissPtn = TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss;

            CharaAction_Balloon_FadeOut = new Animations.FadeOut[2];
            for (int nPlayer = 0; nPlayer < TJAPlayer3.ConfigIni.nPlayerCount; nPlayer++)
            {
                CharaAction_Balloon_FadeOut_StartMs[nPlayer] = new int[2];
                CharaAction_Balloon_FadeOut[nPlayer] = new Animations.FadeOut(TJAPlayer3.Skin.Game_Chara_Balloon_FadeOut);
                CharaAction_Balloon_FadeOut_StartMs[nPlayer][0] = (balloonBrokePtn * tick) - TJAPlayer3.Skin.Game_Chara_Balloon_FadeOut;
                CharaAction_Balloon_FadeOut_StartMs[nPlayer][1] = (balloonMissPtn * tick) - TJAPlayer3.Skin.Game_Chara_Balloon_FadeOut;
                if (balloonBrokePtn > 1) CharaAction_Balloon_FadeOut_StartMs[nPlayer][0] /= balloonBrokePtn - 1;
                if (balloonMissPtn > 1) CharaAction_Balloon_FadeOut_StartMs[nPlayer][1] /= balloonMissPtn - 1; // - 1はタイマー用
            }

            base.On活性化();
        }

        public override void On非活性化()
        {

            this.ctキャラクターアクション_10コンボ = null;
            this.ctキャラクターアクション_10コンボMAX = null;
            this.ctキャラクターアクション_ゴーゴースタート = null;
            this.ctキャラクターアクション_ゴーゴースタートMAX = null;
            this.ctキャラクターアクション_ノルマ = null;
            this.ctキャラクターアクション_魂MAX = null;
            CharaAction_Balloon_Breaking = null;
            CharaAction_Balloon_Broke = null;
            CharaAction_Balloon_Miss = null;
            CharaAction_Balloon_Delay = null;
            CharaAction_Balloon_FadeOut = null;
       
            base.On非活性化();
        }

        public override void OnManagedリソースの作成()
        {
            this.b風船連打中 = new bool[2] { false, false };
            this.bマイどんアクション中 = new bool[2] { false, false };

            this.arモーション番号 = C変換.ar配列形式のstringをint配列に変換して返す( TJAPlayer3.Skin.Game_Chara_Motion_Normal);
            this.arゴーゴーモーション番号 = C変換.ar配列形式のstringをint配列に変換して返す(TJAPlayer3.Skin.Game_Chara_Motion_GoGo);
            this.arクリアモーション番号 = C変換.ar配列形式のstringをint配列に変換して返す(TJAPlayer3.Skin.Game_Chara_Motion_Clear);
            if (arモーション番号 == null) this.arモーション番号 = C変換.ar配列形式のstringをint配列に変換して返す("0,0");
            if (arゴーゴーモーション番号 == null) this.arゴーゴーモーション番号 = C変換.ar配列形式のstringをint配列に変換して返す("0,0");
            if (arクリアモーション番号 == null) this.arクリアモーション番号 = C変換.ar配列形式のstringをint配列に変換して返す("0,0");
            ctChara_Normal = new CCounter[2];
            ctChara_GoGo = new CCounter[2];
            ctChara_Clear = new CCounter[2];
            this.ctキャラクターアクション_10コンボ = new CCounter[2];
            this.ctキャラクターアクション_10コンボMAX = new CCounter[2];
            this.ctキャラクターアクション_ゴーゴースタート = new CCounter[2];
            this.ctキャラクターアクション_ゴーゴースタートMAX = new CCounter[2];
            this.ctキャラクターアクション_ノルマ = new CCounter[2];
            this.ctキャラクターアクション_魂MAX = new CCounter[2];
            CharaAction_Balloon_Breaking = new CCounter[2];
            CharaAction_Balloon_Broke = new CCounter[2];
            CharaAction_Balloon_Miss = new CCounter[2];
            CharaAction_Balloon_Delay = new CCounter[2];
            for (int nPlayer = 0; nPlayer < TJAPlayer3.ConfigIni.nPlayerCount; nPlayer++)
            {
                ctChara_Normal[nPlayer] = new CCounter();
                ctChara_GoGo[nPlayer] = new CCounter();
                ctChara_Clear[nPlayer] = new CCounter();
                this.ctキャラクターアクション_10コンボ[nPlayer] = new CCounter();
                this.ctキャラクターアクション_10コンボMAX[nPlayer] = new CCounter();
                this.ctキャラクターアクション_ゴーゴースタート[nPlayer] = new CCounter();
                this.ctキャラクターアクション_ゴーゴースタートMAX[nPlayer] = new CCounter();
                this.ctキャラクターアクション_ノルマ[nPlayer] = new CCounter();
                this.ctキャラクターアクション_魂MAX[nPlayer] = new CCounter();
                CharaAction_Balloon_Breaking[nPlayer] = new CCounter();
                CharaAction_Balloon_Broke[nPlayer] = new CCounter();
                CharaAction_Balloon_Miss[nPlayer] = new CCounter();
                CharaAction_Balloon_Delay[nPlayer] = new CCounter();

                ctChara_Normal[nPlayer] = new CCounter(0, arモーション番号.Length - 1, 10, CSound管理.rc演奏用タイマ);
                ctChara_GoGo[nPlayer] = new CCounter(0, arゴーゴーモーション番号.Length - 1, 10, CSound管理.rc演奏用タイマ);
                ctChara_Clear[nPlayer] = new CCounter(0, arクリアモーション番号.Length - 1, 10, CSound管理.rc演奏用タイマ);
                if (CharaAction_Balloon_Delay[nPlayer] != null) CharaAction_Balloon_Delay[nPlayer].n現在の値 = CharaAction_Balloon_Delay[nPlayer].n終了値;
            }
            base.OnManagedリソースの作成();
        }

        public override void OnManagedリソースの解放()
        {
            ctChara_Normal = null;
            ctChara_GoGo = null;
            ctChara_Clear = null;
            base.OnManagedリソースの解放();
        }

        public override int On進行描画()
        {
            for (int nPlayer = 0; nPlayer < TJAPlayer3.ConfigIni.nPlayerCount; nPlayer++)
            {
                if (ctChara_Normal[nPlayer] != null || TJAPlayer3.Skin.Game_Chara_Ptn_Normal != 0) ctChara_Normal[nPlayer].t進行LoopDb();
                if (ctChara_GoGo[nPlayer] != null || TJAPlayer3.Skin.Game_Chara_Ptn_GoGo != 0) ctChara_GoGo[nPlayer].t進行LoopDb();
                if (ctChara_Clear[nPlayer] != null || TJAPlayer3.Skin.Game_Chara_Ptn_Clear != 0) ctChara_Clear[nPlayer].t進行LoopDb();
                if (this.ctキャラクターアクション_10コンボ[nPlayer] != null || TJAPlayer3.Skin.Game_Chara_Ptn_10combo != 0) this.ctキャラクターアクション_10コンボ[nPlayer].t進行db();
                if (this.ctキャラクターアクション_10コンボMAX[nPlayer] != null || TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max != 0) this.ctキャラクターアクション_10コンボMAX[nPlayer].t進行db();
                if (this.ctキャラクターアクション_ゴーゴースタート[nPlayer] != null || TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart != 0) this.ctキャラクターアクション_ゴーゴースタート[nPlayer].t進行db();
                if (this.ctキャラクターアクション_ゴーゴースタートMAX[nPlayer] != null || TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max != 0) this.ctキャラクターアクション_ゴーゴースタートMAX[nPlayer].t進行db();
                if (this.ctキャラクターアクション_ノルマ[nPlayer] != null || TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn != 0) this.ctキャラクターアクション_ノルマ[nPlayer].t進行db();
                if (this.ctキャラクターアクション_魂MAX[nPlayer] != null || TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn != 0) this.ctキャラクターアクション_魂MAX[nPlayer].t進行db();


                if (this.b風船連打中[nPlayer] != true && this.bマイどんアクション中[nPlayer] != true && CharaAction_Balloon_Delay[nPlayer].b終了値に達した)
                {
                    if (!TJAPlayer3.stage演奏ドラム画面.bIsGOGOTIME[nPlayer])
                    {
                        if (TJAPlayer3.stage演奏ドラム画面.actGauge.db現在のゲージ値[nPlayer] >= 100.0 && TJAPlayer3.Skin.Game_Chara_Ptn_Clear != 0)
                        {
                            if (TJAPlayer3.Skin.Game_Chara_Ptn_Clear != 0)
                                TJAPlayer3.Tx.Chara_Normal_Maxed[this.arクリアモーション番号[(int)this.ctChara_Clear[nPlayer].db現在の値]].t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Chara_X[nPlayer], TJAPlayer3.Skin.Game_Chara_Y[nPlayer]);
                        }
                        else if (TJAPlayer3.stage演奏ドラム画面.actGauge.db現在のゲージ値[nPlayer] >= 80.0 && TJAPlayer3.Skin.Game_Chara_Ptn_Clear != 0)
                        {
                            if (TJAPlayer3.Skin.Game_Chara_Ptn_Clear != 0)
                            {
                                TJAPlayer3.Tx.Chara_Normal_Cleared[this.arクリアモーション番号[(int)this.ctChara_Clear[nPlayer].db現在の値]].t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Chara_X[nPlayer], TJAPlayer3.Skin.Game_Chara_Y[nPlayer]);
                            }
                        }
                        else
                        {
                            if (TJAPlayer3.Skin.Game_Chara_Ptn_Normal != 0)
                            {
                                TJAPlayer3.Tx.Chara_Normal[this.arモーション番号[(int)this.ctChara_Normal[nPlayer].db現在の値]].t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Chara_X[nPlayer], TJAPlayer3.Skin.Game_Chara_Y[nPlayer]);
                            }
                        }
                    }
                    else
                    {
                        if (TJAPlayer3.stage演奏ドラム画面.actGauge.db現在のゲージ値[nPlayer] >= 100.0 && TJAPlayer3.Skin.Game_Chara_Ptn_GoGo != 0)
                        {
                            if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGo != 0)
                                TJAPlayer3.Tx.Chara_GoGoTime_Maxed[this.arゴーゴーモーション番号[(int)this.ctChara_GoGo[nPlayer].db現在の値]].t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Chara_X[nPlayer], TJAPlayer3.Skin.Game_Chara_Y[nPlayer]);
                        }
                        else
                        {
                            if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGo != 0)
                                TJAPlayer3.Tx.Chara_GoGoTime[this.arゴーゴーモーション番号[(int)this.ctChara_GoGo[nPlayer].db現在の値]].t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Chara_X[nPlayer], TJAPlayer3.Skin.Game_Chara_Y[nPlayer]);
                        }
                    }
                }

                if (this.b風船連打中[nPlayer] != true && bマイどんアクション中[nPlayer] == true && CharaAction_Balloon_Delay[nPlayer].b終了値に達した)
                {

                    if (this.ctキャラクターアクション_10コンボ[nPlayer].b進行中db)
                    {
                        if (TJAPlayer3.Tx.Chara_10Combo[0] != null && TJAPlayer3.Skin.Game_Chara_Ptn_10combo != 0)
                        {
                            TJAPlayer3.Tx.Chara_10Combo[(int)this.ctキャラクターアクション_10コンボ[nPlayer].db現在の値].t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Chara_X[nPlayer], TJAPlayer3.Skin.Game_Chara_Y[nPlayer]);
                        }
                        if (this.ctキャラクターアクション_10コンボ[nPlayer].b終了値に達したdb)
                        {
                            this.bマイどんアクション中[nPlayer] = false;
                            this.ctキャラクターアクション_10コンボ[nPlayer].t停止();
                            this.ctキャラクターアクション_10コンボ[nPlayer].db現在の値 = 0D;
                        }
                    }


                    if (this.ctキャラクターアクション_10コンボMAX[nPlayer].b進行中db)
                    {
                        if (TJAPlayer3.Tx.Chara_10Combo_Maxed[0] != null && TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max != 0)
                        {
                            TJAPlayer3.Tx.Chara_10Combo_Maxed[(int)this.ctキャラクターアクション_10コンボMAX[nPlayer].db現在の値].t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Chara_X[nPlayer], TJAPlayer3.Skin.Game_Chara_Y[nPlayer]);
                        }
                        if (this.ctキャラクターアクション_10コンボMAX[nPlayer].b終了値に達したdb)
                        {
                            this.bマイどんアクション中[nPlayer] = false;
                            this.ctキャラクターアクション_10コンボMAX[nPlayer].t停止();
                            this.ctキャラクターアクション_10コンボMAX[nPlayer].db現在の値 = 0D;
                        }

                    }

                    if (this.ctキャラクターアクション_ゴーゴースタート[nPlayer].b進行中db)
                    {
                        if (TJAPlayer3.Tx.Chara_GoGoStart[0] != null && TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart != 0)
                        {
                            TJAPlayer3.Tx.Chara_GoGoStart[(int)this.ctキャラクターアクション_ゴーゴースタート[nPlayer].db現在の値].t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Chara_X[nPlayer], TJAPlayer3.Skin.Game_Chara_Y[nPlayer]);
                        }
                        if (this.ctキャラクターアクション_ゴーゴースタート[nPlayer].b終了値に達したdb)
                        {
                            this.bマイどんアクション中[nPlayer] = false;
                            this.ctキャラクターアクション_ゴーゴースタート[nPlayer].t停止();
                            this.ctキャラクターアクション_ゴーゴースタート[nPlayer].db現在の値 = 0D;
                            this.ctChara_GoGo[nPlayer].db現在の値 = TJAPlayer3.Skin.Game_Chara_Ptn_GoGo / 2;
                        }
                    }

                    if (this.ctキャラクターアクション_ゴーゴースタートMAX[nPlayer].b進行中db)
                    {
                        if (TJAPlayer3.Tx.Chara_GoGoStart_Maxed[0] != null && TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max != 0)
                        {
                            TJAPlayer3.Tx.Chara_GoGoStart_Maxed[(int)this.ctキャラクターアクション_ゴーゴースタートMAX[nPlayer].db現在の値].t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Chara_X[nPlayer], TJAPlayer3.Skin.Game_Chara_Y[nPlayer]);
                        }
                        if (this.ctキャラクターアクション_ゴーゴースタートMAX[nPlayer].b終了値に達したdb)
                        {
                            this.bマイどんアクション中[nPlayer] = false;
                            this.ctキャラクターアクション_ゴーゴースタートMAX[nPlayer].t停止();
                            this.ctキャラクターアクション_ゴーゴースタートMAX[nPlayer].db現在の値 = 0D;
                            this.ctChara_GoGo[nPlayer].db現在の値 = TJAPlayer3.Skin.Game_Chara_Ptn_GoGo / 2;
                        }
                    }

                    if (this.ctキャラクターアクション_ノルマ[nPlayer].b進行中db)
                    {
                        if (TJAPlayer3.Tx.Chara_Become_Cleared[0] != null && TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn != 0)
                        {
                            TJAPlayer3.Tx.Chara_Become_Cleared[(int)this.ctキャラクターアクション_ノルマ[nPlayer].db現在の値].t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Chara_X[nPlayer], TJAPlayer3.Skin.Game_Chara_Y[nPlayer]);
                        }
                        if (this.ctキャラクターアクション_ノルマ[nPlayer].b終了値に達したdb)
                        {
                            this.bマイどんアクション中[nPlayer] = false;
                            this.ctキャラクターアクション_ノルマ[nPlayer].t停止();
                            this.ctキャラクターアクション_ノルマ[nPlayer].db現在の値 = 0D;
                        }
                    }

                    if (this.ctキャラクターアクション_魂MAX[nPlayer].b進行中db)
                    {
                        if (TJAPlayer3.Tx.Chara_Become_Maxed[0] != null && TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn != 0)
                        {
                            TJAPlayer3.Tx.Chara_Become_Maxed[(int)this.ctキャラクターアクション_魂MAX[nPlayer].db現在の値].t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Chara_X[nPlayer], TJAPlayer3.Skin.Game_Chara_Y[nPlayer]);
                        }
                        if (this.ctキャラクターアクション_魂MAX[nPlayer].b終了値に達したdb)
                        {
                            this.bマイどんアクション中[nPlayer] = false;
                            this.ctキャラクターアクション_魂MAX[nPlayer].t停止();
                            this.ctキャラクターアクション_魂MAX[nPlayer].db現在の値 = 0D;
                        }
                    }
                }
                if (this.b風船連打中[nPlayer] != true && CharaAction_Balloon_Delay[nPlayer].b終了値に達した)
                {
                    TJAPlayer3.stage演奏ドラム画面.PuchiChara.On進行描画(TJAPlayer3.Skin.Game_PuchiChara_X[nPlayer], TJAPlayer3.Skin.Game_PuchiChara_Y[nPlayer], TJAPlayer3.stage演奏ドラム画面.bIsAlreadyMaxed[nPlayer]);
                }
            }
            return base.On進行描画();
        }

        public void OnDraw_Balloon()
        {
            for (int nPlayer = 0; nPlayer < TJAPlayer3.ConfigIni.nPlayerCount; nPlayer++)
            {
                if (TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Breaking != 0) CharaAction_Balloon_Breaking[nPlayer]?.t進行();
                if (TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke != 0) CharaAction_Balloon_Broke[nPlayer]?.t進行();
                CharaAction_Balloon_Delay[nPlayer]?.t進行();
                if (TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss != 0) CharaAction_Balloon_Miss[nPlayer]?.t進行();
                CharaAction_Balloon_FadeOut[nPlayer].Tick();

                //CharaAction_Balloon_Delay?.t進行();
                //CDTXMania.act文字コンソール.tPrint(0, 0, C文字コンソール.Eフォント種別.白, CharaAction_Balloon_Broke?.b進行中.ToString());
                //CDTXMania.act文字コンソール.tPrint(0, 20, C文字コンソール.Eフォント種別.白, CharaAction_Balloon_Miss?.b進行中.ToString());
                //CDTXMania.act文字コンソール.tPrint(0, 40, C文字コンソール.Eフォント種別.白, CharaAction_Balloon_Breaking?.b進行中.ToString());

                if (bマイどんアクション中[nPlayer])
                {
                    var nowOpacity = CharaAction_Balloon_FadeOut[nPlayer].Counter.b進行中 ? (int)CharaAction_Balloon_FadeOut[nPlayer].GetAnimation() : 255;
                    if (CharaAction_Balloon_Broke[nPlayer]?.b進行中 == true && TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke != 0)
                    {
                        if (CharaAction_Balloon_FadeOut[nPlayer].Counter.b停止中 && CharaAction_Balloon_Broke[nPlayer].n現在の値 > CharaAction_Balloon_FadeOut_StartMs[nPlayer][0])
                        {
                            CharaAction_Balloon_FadeOut[nPlayer].Start();
                        }
                        if (TJAPlayer3.Tx.Chara_Balloon_Broke[CharaAction_Balloon_Broke[nPlayer].n現在の値] != null)
                        {
                            TJAPlayer3.Tx.Chara_Balloon_Broke[CharaAction_Balloon_Broke[nPlayer].n現在の値].n透明度 = nowOpacity;
                            TJAPlayer3.Tx.Chara_Balloon_Broke[CharaAction_Balloon_Broke[nPlayer].n現在の値].t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Chara_Balloon_X[nPlayer], TJAPlayer3.Skin.Game_Chara_Balloon_Y[nPlayer]);
                        }
                        TJAPlayer3.stage演奏ドラム画面.PuchiChara.On進行描画(TJAPlayer3.Skin.Game_PuchiChara_BalloonX[nPlayer], TJAPlayer3.Skin.Game_PuchiChara_BalloonY[nPlayer], false, nowOpacity, true);
                        if (CharaAction_Balloon_Broke[nPlayer].b終了値に達した)
                        {
                            CharaAction_Balloon_Broke[nPlayer].t停止();
                            CharaAction_Balloon_Broke[nPlayer].n現在の値 = 0;
                            bマイどんアクション中[nPlayer] = false;
                        }
                    }
                    else if (CharaAction_Balloon_Miss[nPlayer]?.b進行中 == true && TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss != 0)
                    {
                        if (CharaAction_Balloon_FadeOut[nPlayer].Counter.b停止中 && CharaAction_Balloon_Miss[nPlayer].n現在の値 > CharaAction_Balloon_FadeOut_StartMs[nPlayer][1])
                        {
                            CharaAction_Balloon_FadeOut[nPlayer].Start();
                        }
                        if (TJAPlayer3.Tx.Chara_Balloon_Miss[CharaAction_Balloon_Miss[nPlayer].n現在の値] != null)
                        {
                            TJAPlayer3.Tx.Chara_Balloon_Miss[CharaAction_Balloon_Miss[nPlayer].n現在の値].n透明度 = nowOpacity;
                            TJAPlayer3.Tx.Chara_Balloon_Miss[CharaAction_Balloon_Miss[nPlayer].n現在の値].t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Chara_Balloon_X[nPlayer], TJAPlayer3.Skin.Game_Chara_Balloon_Y[nPlayer]);
                        }
                        TJAPlayer3.stage演奏ドラム画面.PuchiChara.On進行描画(TJAPlayer3.Skin.Game_PuchiChara_BalloonX[nPlayer], TJAPlayer3.Skin.Game_PuchiChara_BalloonY[nPlayer], false, nowOpacity, true);
                        if (CharaAction_Balloon_Miss[nPlayer].b終了値に達した)
                        {
                            CharaAction_Balloon_Miss[nPlayer].t停止();
                            CharaAction_Balloon_Miss[nPlayer].n現在の値 = 0;
                            bマイどんアクション中[nPlayer] = false;
                        }
                    }
                    else if (CharaAction_Balloon_Breaking[nPlayer]?.b進行中 == true && TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Breaking != 0)
                    {
                        TJAPlayer3.Tx.Chara_Balloon_Breaking[CharaAction_Balloon_Breaking[nPlayer].n現在の値]?.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Chara_Balloon_X[nPlayer], TJAPlayer3.Skin.Game_Chara_Balloon_Y[nPlayer]);
                        TJAPlayer3.stage演奏ドラム画面.PuchiChara.On進行描画(TJAPlayer3.Skin.Game_PuchiChara_BalloonX[nPlayer], TJAPlayer3.Skin.Game_PuchiChara_BalloonY[nPlayer], false, 255, true);
                    }

                    //if (CDTXMania.stage演奏ドラム画面.actChara.CharaAction_Balloon_Breaking?.b終了値に達した == true)
                    //{
                    //    CDTXMania.stage演奏ドラム画面.actChara.bマイどんアクション中 = false;
                    //    CDTXMania.stage演奏ドラム画面.actChara.CharaAction_Balloon_Breaking.t停止();
                    //    CDTXMania.stage演奏ドラム画面.actChara.CharaAction_Balloon_Breaking.n現在の値 = 0;
                    //}
                }
            }
        }

        public void アクションタイマーリセット(int nPlayer)
        {
            ctキャラクターアクション_10コンボ[nPlayer].t停止();
            ctキャラクターアクション_10コンボMAX[nPlayer].t停止();
            ctキャラクターアクション_ゴーゴースタート[nPlayer].t停止();
            ctキャラクターアクション_ゴーゴースタートMAX[nPlayer].t停止();
            ctキャラクターアクション_ノルマ[nPlayer].t停止();
            ctキャラクターアクション_魂MAX[nPlayer].t停止();
            ctキャラクターアクション_10コンボ[nPlayer].db現在の値 = 0D;
            ctキャラクターアクション_10コンボMAX[nPlayer].db現在の値 = 0D;
            ctキャラクターアクション_ゴーゴースタート[nPlayer].db現在の値 = 0D;
            ctキャラクターアクション_ゴーゴースタートMAX[nPlayer].db現在の値 = 0D;
            ctキャラクターアクション_ノルマ[nPlayer].db現在の値 = 0D;
            ctキャラクターアクション_魂MAX[nPlayer].db現在の値 = 0D;
            CharaAction_Balloon_Breaking[nPlayer]?.t停止();
            CharaAction_Balloon_Broke[nPlayer]?.t停止();
            CharaAction_Balloon_Miss[nPlayer]?.t停止();
            //CharaAction_Balloon_Delay[nPlayer]?.t停止();
            CharaAction_Balloon_Breaking[nPlayer].n現在の値 = 0;
            CharaAction_Balloon_Broke[nPlayer].n現在の値 = 0;
            CharaAction_Balloon_Miss[nPlayer].n現在の値 = 0;
            //CharaAction_Balloon_Delay[nPlayer].n現在の値 = 0;
        }

        public int[] arモーション番号;
        public int[] arゴーゴーモーション番号;
        public int[] arクリアモーション番号;

        public CCounter[] ctキャラクターアクション_10コンボ;
        public CCounter[] ctキャラクターアクション_10コンボMAX;
        public CCounter[] ctキャラクターアクション_ゴーゴースタート;
        public CCounter[] ctキャラクターアクション_ゴーゴースタートMAX;
        public CCounter[] ctキャラクターアクション_ノルマ;
        public CCounter[] ctキャラクターアクション_魂MAX;
        public CCounter[] CharaAction_Balloon_Breaking;
        public CCounter[] CharaAction_Balloon_Broke;
        public CCounter[] CharaAction_Balloon_Miss;
        public CCounter[] CharaAction_Balloon_Delay;

        public CCounter[] ctChara_Normal;
        public CCounter[] ctChara_GoGo;
        public CCounter[] ctChara_Clear;

        public Animations.FadeOut[] CharaAction_Balloon_FadeOut;
        private readonly int[][] CharaAction_Balloon_FadeOut_StartMs = new int[2][];

        public bool[] bマイどんアクション中;

        public bool[] b風船連打中;
        public bool b演奏中;
    }
}
