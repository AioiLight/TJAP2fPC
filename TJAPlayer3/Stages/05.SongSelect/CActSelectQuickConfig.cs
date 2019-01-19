using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.IO;
using SlimDX;
using FDK;

namespace TJAPlayer3
{
	internal class CActSelectQuickConfig : CActSelectPopupMenu
	{
		private readonly string QuickCfgTitle = "Quick Config";

		public CActSelectQuickConfig()
		{
			CActSelectQuickConfigMain(0);
		}

        private void CActSelectQuickConfigMain(int nPlayer)
		{
/*
•Target: Drums/Guitar/Bass 
•Auto Mode: All ON/All OFF/CUSTOM 
•Auto Lane: 
•Scroll Speed: 
•Play Speed: 
•Risky: 
•Hidden/Sudden: None/Hidden/Sudden/Both 
•Conf SET: SET-1/SET-2/SET-3 
•More... 
•EXIT 
*/
			lci = new List<List<List<CItemBase>>>();									// この画面に来る度に、メニューを作り直す。
			for ( int nConfSet = 0; nConfSet < 3; nConfSet++ )
			{
				lci.Add( new List<List<CItemBase>>() );									// ConfSet用の3つ分の枠。
				for ( int nInst = 0; nInst < 3; nInst++ )
				{
                    lci[nConfSet].Add(null);                                     // Drum/Guitar/Bassで3つ分、枠を作っておく
                    lci[nConfSet][nInst] = MakeListCItemBase(nConfSet, nInst, nPlayer);
				}
			}
            base.Initialize(lci[0][0], true, (nPlayer + 1).ToString() + "P " + QuickCfgTitle, 0);
		}

        private List<CItemBase> MakeListCItemBase(int nConfigSet, int nInst, int nPlayer)
		{
			List<CItemBase> l = new List<CItemBase>();
            this.nPlayer = nPlayer;
            #region [ 共通 Target/AutoMode/AutoLane ]
            if (nPlayer == 1)
            {
                l.Add(new CItemInteger("PlayerCount", 1, 2, TJAPlayer3.ConfigIni.nPlayerCount, "", ""));
            }
            #endregion
            #region [ 個別 ScrollSpeed ]
            l.Add(new CItemInteger("ばいそく", 0, 1999, TJAPlayer3.ConfigIni.n譜面スクロール速度[nPlayer][nInst], "", ""));
            #endregion
            #region [ 共通 Dark/Risky/PlaySpeed ]
            if (nPlayer == 0)
            {
                l.Add(new CItemInteger("演奏速度", 5, 40, TJAPlayer3.ConfigIni.n演奏速度, "", ""));
            }
            #endregion
            #region [ 個別 Sud/Hid ]
            l.Add(new CItemList("ランダム", CItemBase.Eパネル種別.通常, (int)TJAPlayer3.ConfigIni.eRandom[nPlayer].Taiko, "", "", 
                new string[] { "OFF", "RANDOM", "あべこべ", "SUPER", "HYPER" }));
            l.Add(new CItemList("ドロン", CItemBase.Eパネル種別.通常, (int)TJAPlayer3.ConfigIni.eSTEALTH[nPlayer], "", "",
                new string[] { "OFF", "ドロン", "ステルス" }));
            if (nPlayer == 0)
            {
                l.Add(new CItemList("ゲーム", CItemBase.Eパネル種別.通常, (int)TJAPlayer3.ConfigIni.eGameMode, "", "",
                new string[] { "OFF", "完走!", "完走!激辛" }));
                l.Add(new CItemList(nameof(TJAPlayer3.ConfigIni.ShinuchiMode), CItemBase.Eパネル種別.通常, TJAPlayer3.ConfigIni.ShinuchiMode ? 1 : 0, "", "", new string[] { "OFF", "ON" }));
            }
            #endregion
            #region [ 共通 SET切り替え/More/Return ]
            l.Add(new CSwitchItemList("More...", CItemBase.Eパネル種別.通常, 0, "", "", ""));
            l.Add(new CSwitchItemList("戻る", CItemBase.Eパネル種別.通常, 0, "", "", ""));
            #endregion

            return l;
		}

		// メソッド
		public override void tActivatePopupMenu( E楽器パート einst ,int nPlayer)
		{
            this.CActSelectQuickConfigMain(nPlayer);
            base.tActivatePopupMenu(einst, nPlayer);
		}
		//public void tDeativatePopupMenu()
		//{
		//	base.tDeativatePopupMenu();
		//}

		public override void t進行描画sub()
		{

		}

        public override void tEnter押下Main(int nSortOrder)
        {
            #region [ 1P ]
            if (nPlayer == 0)
                switch (n現在の選択行)
                {
                    case (int)EOrder1P.ScrollSpeed:
                        TJAPlayer3.ConfigIni.n譜面スクロール速度[nPlayer][nCurrentTarget] = (int)GetObj現在値((int)EOrder1P.ScrollSpeed);
                        break;

                    case (int)EOrder1P.PlaySpeed:
                        TJAPlayer3.ConfigIni.n演奏速度 = (int)GetObj現在値((int)EOrder1P.PlaySpeed);
                        break;
                    case (int)EOrder1P.Random:
                        TJAPlayer3.ConfigIni.eRandom[nPlayer].Taiko = (Eランダムモード)GetIndex((int)EOrder1P.Random);
                        break;
                    case (int)EOrder1P.Stealth:
                        TJAPlayer3.ConfigIni.eSTEALTH[nPlayer] = (Eステルスモード)GetIndex((int)EOrder1P.Stealth);
                        break;
                    case (int)EOrder1P.GameMode:
                        EGame game = EGame.OFF;
                        switch ((int)GetIndex((int)EOrder1P.GameMode))
                        {
                            case 0: game = EGame.OFF; break;
                            case 1: game = EGame.完走叩ききりまショー; break;
                            case 2: game = EGame.完走叩ききりまショー激辛; break;
                        }
                        TJAPlayer3.ConfigIni.eGameMode = game;
                        break;
                    case (int)EOrder1P.ShinuchiMode:
                        TJAPlayer3.ConfigIni.ShinuchiMode = !TJAPlayer3.ConfigIni.ShinuchiMode;
                        break;
                    case (int)EOrder1P.More:
                        SetAutoParameters();            // 簡易CONFIGメニュー脱出に伴い、簡易CONFIG内のAUTOの設定をConfigIniクラスに反映する
                        this.bGotoDetailConfig = true;
                        this.tDeativatePopupMenu();
                        break;

                    case (int)EOrder1P.Return:
                        SetAutoParameters();            // 簡易CONFIGメニュー脱出に伴い、簡易CONFIG内のAUTOの設定をConfigIniクラスに反映する
                        this.tDeativatePopupMenu();
                        break;
                    default:
                        break;
                }
            #endregion
            #region [ 2P ]
            if (nPlayer == 1)
                switch (n現在の選択行)
                {
                    case (int)EOrder2P.PlayerCount:
                        TJAPlayer3.ConfigIni.nPlayerCount = (int)GetObj現在値((int)EOrder2P.PlayerCount);
                        break;
                    case (int)EOrder2P.ScrollSpeed:
                        TJAPlayer3.ConfigIni.n譜面スクロール速度[nPlayer][nCurrentTarget] = (int)GetObj現在値((int)EOrder2P.ScrollSpeed);
                        break;
                    case (int)EOrder2P.Random:
                        TJAPlayer3.ConfigIni.eRandom[nPlayer].Taiko = (Eランダムモード)GetIndex((int)EOrder2P.Random);
                        break;
                    case (int)EOrder2P.Stealth:
                        TJAPlayer3.ConfigIni.eSTEALTH[nPlayer] = (Eステルスモード)GetIndex((int)EOrder2P.Stealth);
                        break;
                    case (int)EOrder2P.More:
                        SetAutoParameters();            // 簡易CONFIGメニュー脱出に伴い、簡易CONFIG内のAUTOの設定をConfigIniクラスに反映する
                        this.bGotoDetailConfig = true;
                        this.tDeativatePopupMenu();
                        break;

                    case (int)EOrder2P.Return:
                        SetAutoParameters();            // 簡易CONFIGメニュー脱出に伴い、簡易CONFIG内のAUTOの設定をConfigIniクラスに反映する
                        this.tDeativatePopupMenu();
                        break;
                    default:
                        break;
                }
            #endregion
        }

        public override void tCancel()
		{
			SetAutoParameters();
			// Autoの設定値保持のロジックを書くこと！
			// (Autoのパラメータ切り替え時は実際に値設定していないため、キャンセルまたはRetern, More...時に値設定する必要有り)
		}

		/// <summary>
		/// 1つの値を、全targetに適用する。RiskyやDarkなど、全tatgetで共通の設定となるもので使う。
		/// </summary>
		/// <param name="order">設定項目リストの順番</param>
		/// <param name="index">設定値(index)</param>
		private void SetValueToAllTarget( int order, int index )
		{
			for ( int i = 0; i < 3; i++ )
			{
				lci[ nCurrentConfigSet ][ i ][ order ].SetIndex( index );
			}
		}
		

		/// <summary>
		/// ConfigIni.bAutoPlayに簡易CONFIGの状態を反映する
		/// </summary>
		private void SetAutoParameters()
		{
			for ( int target = 0; target < 3; target++ )
			{
				int[] pa = { (int) Eレーン.LC, (int) Eレーン.GtR, (int) Eレーン.BsR };
				int start = pa[ target ];
            }
        }

		// CActivity 実装

		public override void On活性化()
		{
			this.ft表示用フォント = new Font( "Arial", 26f, FontStyle.Bold, GraphicsUnit.Pixel );
			base.On活性化();
			this.bGotoDetailConfig = false;
		}
		public override void On非活性化()
		{
			if ( this.ft表示用フォント != null )
			{
				this.ft表示用フォント.Dispose();
                this.ft表示用フォント = null;
			}
			base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if( !base.b活性化してない )
			{
				//string pathパネル本体 = CSkin.Path( @"Graphics\ScreenSelect popup auto settings.png" );
				//if ( File.Exists( pathパネル本体 ) )
				//{
				//	this.txパネル本体 = CDTXMania.tテクスチャの生成( pathパネル本体, true );
				//}

				base.OnManagedリソースの作成();
			}
		}
		public override void OnManagedリソースの解放()
		{
			if ( !base.b活性化してない )
			{
				//CDTXMania.tテクスチャの解放( ref this.txパネル本体 );
				TJAPlayer3.tテクスチャの解放( ref this.tx文字列パネル );
				base.OnManagedリソースの解放();
			}
		}

		#region [ private ]
		//-----------------
		private int nCurrentTarget = 0;
		private int nCurrentConfigSet = 0;
		private List<List<List<CItemBase>>> lci;		// DrGtBs, ConfSet, 選択肢一覧。都合、3次のListとなる。
		private enum EOrder1P : int
		{
			ScrollSpeed = 0,
			PlaySpeed,
			Random,
            Stealth,
            GameMode,
            ShinuchiMode,
			More,
			Return,
            END,
			Default = 99
		};

        private enum EOrder2P : int
        {
            PlayerCount = 0,
            ScrollSpeed,
            Random,
            Stealth,
            //ShinuchiMode,
            More,
            Return,
            END,
            Default = 99
        };


        private Font ft表示用フォント;
		//private CTexture txパネル本体;
		private CTexture tx文字列パネル;
        private CTexture tx説明文1;
        private int nPlayer = 0;
		//-----------------
		#endregion
	}


}
