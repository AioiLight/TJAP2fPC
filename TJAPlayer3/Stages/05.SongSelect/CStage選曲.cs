using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using FDK;

namespace TJAPlayer3
{
    internal class CStage選曲 : CStage
    {
        // プロパティ
        public int nスクロールバー相対y座標
        {
            get
            {
                if (act曲リスト != null)
                {
                    return act曲リスト.nスクロールバー相対y座標;
                }
                else
                {
                    return 0;
                }
            }
        }
        public bool bIsEnumeratingSongs
        {
            get
            {
                return act曲リスト.bIsEnumeratingSongs;
            }
            set
            {
                act曲リスト.bIsEnumeratingSongs = value;
            }
        }
        public bool bIsPlayingPremovie
        {
            get
            {
                return this.actPreimageパネル.bIsPlayingPremovie;
            }
        }
        public bool bスクロール中
        {
            get
            {
                return this.act曲リスト.bスクロール中;
            }
        }
        public int n確定された曲の難易度
        {
            get;
            private set;
        }
        public string str確定された曲のジャンル
        {
            get;
            private set;                
        }
		public Cスコア r確定されたスコア
		{
			get;
			private set;
		}
		public C曲リストノード r確定された曲 
		{
			get;
			private set;
		}
		public int n現在選択中の曲の難易度
		{
			get
			{
				return this.act曲リスト.n現在選択中の曲の現在の難易度レベル;
			}
		}
		public Cスコア r現在選択中のスコア
		{
			get
			{
				return this.act曲リスト.r現在選択中のスコア;
			}
		}
		public C曲リストノード r現在選択中の曲
		{
			get
			{
				return this.act曲リスト.r現在選択中の曲;
			}
		}

		// コンストラクタ
		public CStage選曲()
		{
			base.eステージID = CStage.Eステージ.選曲;
			base.eフェーズID = CStage.Eフェーズ.共通_通常状態;
			base.b活性化してない = true;
			base.list子Activities.Add( this.actオプションパネル = new CActオプションパネル() );
            base.list子Activities.Add( this.actFIFO = new CActFIFOBlack() );
			base.list子Activities.Add( this.actFIfrom結果画面 = new CActFIFOBlack() );
			//base.list子Activities.Add( this.actFOtoNowLoading = new CActFIFOBlack() );
            base.list子Activities.Add( this.actFOtoNowLoading = new CActFIFOStart() );
			base.list子Activities.Add( this.act曲リスト = new CActSelect曲リスト() );
			base.list子Activities.Add( this.actステータスパネル = new CActSelectステータスパネル() );
			base.list子Activities.Add( this.act演奏履歴パネル = new CActSelect演奏履歴パネル() );
			base.list子Activities.Add( this.actPreimageパネル = new CActSelectPreimageパネル() );
			base.list子Activities.Add( this.actPresound = new CActSelectPresound() );
			base.list子Activities.Add( this.actArtistComment = new CActSelectArtistComment() );
			base.list子Activities.Add( this.actInformation = new CActSelectInformation() );
			base.list子Activities.Add( this.actSortSongs = new CActSortSongs() );
			base.list子Activities.Add( this.actShowCurrentPosition = new CActSelectShowCurrentPosition() );
			base.list子Activities.Add( this.actQuickConfig = new CActSelectQuickConfig() );
			//base.list子Activities.Add( this.act難易度選択画面 = new CActSelect難易度選択画面() );

			this.CommandHistory = new CCommandHistory();		// #24063 2011.1.16 yyagi
		}
		
		
		// メソッド

		public void t選択曲変更通知()
		{
			this.actPreimageパネル.t選択曲が変更された();
			this.actPresound.t選択曲が変更された();
			this.act演奏履歴パネル.t選択曲が変更された();
			this.actステータスパネル.t選択曲が変更された();
			this.actArtistComment.t選択曲が変更された();

			#region [ プラグインにも通知する（BOX, RANDOM, BACK なら通知しない）]
			//---------------------
			if( TJAPlayer3.app != null )
			{
				var c曲リストノード = TJAPlayer3.stage選曲.r現在選択中の曲;
				var cスコア = TJAPlayer3.stage選曲.r現在選択中のスコア;

				if( c曲リストノード != null && cスコア != null && c曲リストノード.eノード種別 == C曲リストノード.Eノード種別.SCORE )
				{
					string str選択曲ファイル名 = cスコア.ファイル情報.ファイルの絶対パス;
				    int n曲番号inブロック = TJAPlayer3.stage選曲.act曲リスト.n現在のアンカ難易度レベルに最も近い難易度レベルを返す( c曲リストノード );

					foreach( TJAPlayer3.STPlugin stPlugin in TJAPlayer3.app.listプラグイン )
					{
						Directory.SetCurrentDirectory( stPlugin.strプラグインフォルダ );
						stPlugin.plugin.On選択曲変更( str選択曲ファイル名, n曲番号inブロック );
						Directory.SetCurrentDirectory( TJAPlayer3.strEXEのあるフォルダ );
					}
				}
			}
			//---------------------
			#endregion
		}

		// CStage 実装

		/// <summary>
		/// 曲リストをリセットする
		/// </summary>
		/// <param name="cs"></param>
		public void Refresh( CSongs管理 cs, bool bRemakeSongTitleBar)
		{
			this.act曲リスト.Refresh( cs, bRemakeSongTitleBar );
		}

		public override void On活性化()
		{
			Trace.TraceInformation( "選曲ステージを活性化します。" );
			Trace.Indent();
			try
			{
                this.eフェードアウト完了時の戻り値 = E戻り値.継続;
				this.bBGM再生済み = false;
				this.ftフォント = new Font("MS UI Gothic", 26f, GraphicsUnit.Pixel );
				for( int i = 0; i < 4; i++ )
					this.ctキー反復用[ i ] = new CCounter( 0, 0, 0, TJAPlayer3.Timer );

                //this.act難易度選択画面.bIsDifficltSelect = true;
				base.On活性化();

				this.actステータスパネル.t選択曲が変更された();	// 最大ランクを更新
                // Discord Presenceの更新
                Discord.UpdatePresence("", Properties.Discord.Stage_SongSelect, TJAPlayer3.StartupTime);
            }
			finally
			{
                TJAPlayer3.ConfigIni.eScrollMode = EScrollMode.Normal;
                TJAPlayer3.ConfigIni.bスクロールモードを上書き = false;
                Trace.TraceInformation( "選曲ステージの活性化を完了しました。" );
				Trace.Unindent();
			}
		}
		public override void On非活性化()
		{
			Trace.TraceInformation( "選曲ステージを非活性化します。" );
			Trace.Indent();
			try
			{
				if( this.ftフォント != null )
				{
					this.ftフォント.Dispose();
					this.ftフォント = null;
				}
				for( int i = 0; i < 4; i++ )
				{
					this.ctキー反復用[ i ] = null;
				}
				base.On非活性化();
			}
			finally
			{
				Trace.TraceInformation( "選曲ステージの非活性化を完了しました。" );
				Trace.Unindent();
			}
		}
		public override void OnManagedリソースの作成()
		{
			if( !base.b活性化してない )
			{
				//this.tx背景 = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_background.jpg" ), false );
				//this.tx上部パネル = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_header_panel.png" ), false );
				//this.tx下部パネル = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_footer panel.png" ) );

				//this.txFLIP = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_skill number on gauge etc.png" ), false );
                //this.tx難易度名 = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_difficulty name.png" ) );
                //this.txジャンル別背景[0] = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_background_Anime.png" ) );
                //this.txジャンル別背景[1] = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_background_JPOP.png" ) );
                //this.txジャンル別背景[2] = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_background_Game.png" ) );
                //this.txジャンル別背景[3] = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_background_Namco.png" ) );
                //this.txジャンル別背景[4] = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_background_Classic.png" ) );
                //this.txジャンル別背景[5] = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_background_Child.png" ) );
                //this.txジャンル別背景[6] = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_background_Variety.png" ) );
                //this.txジャンル別背景[7] = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_background_VOCALID.png" ) );
                //this.txジャンル別背景[8] = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_background_Other.png" ) );

                //this.tx難易度別背景[0] = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_background_Easy.png" ) );
                //this.tx難易度別背景[1] = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_background_Normal.png" ) );
                //this.tx難易度別背景[2] = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_background_Hard.png" ) );
                //this.tx難易度別背景[3] = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_background_Master.png" ) );
                //this.tx難易度別背景[4] = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_background_Edit.png" ) );
                //this.tx下部テキスト = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\5_footer text.png" ) );
                this.ct背景スクロール用タイマー = new CCounter(0, TJAPlayer3.Tx.SongSelect_Background.szテクスチャサイズ.Width, 30, TJAPlayer3.Timer);
				base.OnManagedリソースの作成();
			}
		}
		public override void OnManagedリソースの解放()
		{
			if( !base.b活性化してない )
			{
				//CDTXMania.tテクスチャの解放( ref this.tx背景 );
				//CDTXMania.tテクスチャの解放( ref this.tx上部パネル );
				//CDTXMania.tテクスチャの解放( ref this.tx下部パネル );
				//CDTXMania.tテクスチャの解放( ref this.txFLIP );
                //CDTXMania.tテクスチャの解放( ref this.tx難易度名 );
                //CDTXMania.tテクスチャの解放( ref this.tx下部テキスト );
                //for( int j = 0; j < 9; j++ )
                //{
                //    CDTXMania.tテクスチャの解放( ref this.txジャンル別背景[ j ] );
                //}
                //for( int j = 0; j < 5; j++ )
                //{
                //    CDTXMania.tテクスチャの解放( ref this.tx難易度別背景[ j ] );
                //}
				base.OnManagedリソースの解放();
			}
		}
		public override int On進行描画()
		{
			if( !base.b活性化してない )
			{
			this.ct背景スクロール用タイマー.t進行Loop();
				#region [ 初めての進行描画 ]
				//---------------------
				if( base.b初めての進行描画 )
				{
					this.ct登場時アニメ用共通 = new CCounter( 0, 100, 3, TJAPlayer3.Timer );
					if( TJAPlayer3.r直前のステージ == TJAPlayer3.stage結果 )
					{
						this.actFIfrom結果画面.tフェードイン開始();
						base.eフェーズID = CStage.Eフェーズ.選曲_結果画面からのフェードイン;
					}
					else
					{
						this.actFIFO.tフェードイン開始();
						base.eフェーズID = CStage.Eフェーズ.共通_フェードイン;
					}
					this.t選択曲変更通知();
					base.b初めての進行描画 = false;
				}
				//---------------------
				#endregion

				this.ct登場時アニメ用共通.t進行();

				if( TJAPlayer3.Tx.SongSelect_Background != null )
                    TJAPlayer3.Tx.SongSelect_Background.t2D描画( TJAPlayer3.app.Device, 0, 0 );

                if( this.r現在選択中の曲 != null )
                {
                    if(this.nStrジャンルtoNum(this.r現在選択中の曲.strジャンル) != 0 || r現在選択中の曲.eノード種別 == C曲リストノード.Eノード種別.BOX || r現在選択中の曲.eノード種別 == C曲リストノード.Eノード種別.SCORE)
                    {
                        nGenreBack = this.nStrジャンルtoNum(this.r現在選択中の曲.strジャンル);
                    }
                    if (TJAPlayer3.Tx.SongSelect_GenreBack[nGenreBack] != null )
                    {
                        for( int i = 0 ; i <(1280 / TJAPlayer3.Tx.SongSelect_Background.szテクスチャサイズ.Width) + 2; i++ )
                            if (TJAPlayer3.Tx.SongSelect_GenreBack[nGenreBack] != null )
                                    TJAPlayer3.Tx.SongSelect_GenreBack[nGenreBack].t2D描画(TJAPlayer3.app.Device, -ct背景スクロール用タイマー.n現在の値 + TJAPlayer3.Tx.SongSelect_Background.szテクスチャサイズ.Width * i , 0);
                    }
                }


				//this.actPreimageパネル.On進行描画();
			//	this.bIsEnumeratingSongs = !this.actPreimageパネル.bIsPlayingPremovie;				// #27060 2011.3.2 yyagi: #PREMOVIE再生中は曲検索を中断する

				this.act曲リスト.On進行描画();
				int y = 0;
				if( this.ct登場時アニメ用共通.b進行中 )
				{
					double db登場割合 = ( (double) this.ct登場時アニメ用共通.n現在の値 ) / 100.0;	// 100が最終値
					double dbY表示割合 = Math.Sin( Math.PI / 2 * db登場割合 );
					y = ( (int) (TJAPlayer3.Tx.SongSelect_Header.sz画像サイズ.Height * dbY表示割合 ) ) - TJAPlayer3.Tx.SongSelect_Header.sz画像サイズ.Height;
				}
				if( TJAPlayer3.Tx.SongSelect_Header != null )
                    TJAPlayer3.Tx.SongSelect_Header.t2D描画( TJAPlayer3.app.Device, 0, 0 );

				this.actInformation.On進行描画();
				if( TJAPlayer3.Tx.SongSelect_Footer != null )
                    TJAPlayer3.Tx.SongSelect_Footer.t2D描画( TJAPlayer3.app.Device, 0, 720 - TJAPlayer3.Tx.SongSelect_Footer.sz画像サイズ.Height );

                #region ネームプレート
                for (int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++)
                {
                    if (TJAPlayer3.Tx.NamePlate[i] != null)
                    {
                        TJAPlayer3.Tx.NamePlate[i].t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.SongSelect_NamePlate_X[i], TJAPlayer3.Skin.SongSelect_NamePlate_Y[i]);
                    }
                }
                #endregion

                #region[ 下部テキスト ]
                if (TJAPlayer3.Tx.SongSelect_Auto != null)
                {
                    if (TJAPlayer3.ConfigIni.b太鼓パートAutoPlay)
                    {
                        TJAPlayer3.Tx.SongSelect_Auto.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.SongSelect_Auto_X[0], TJAPlayer3.Skin.SongSelect_Auto_Y[0]);
                    }
                    if (TJAPlayer3.ConfigIni.nPlayerCount > 1 && TJAPlayer3.ConfigIni.b太鼓パートAutoPlay2P)
                    {
                        TJAPlayer3.Tx.SongSelect_Auto.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.SongSelect_Auto_X[1], TJAPlayer3.Skin.SongSelect_Auto_Y[1]);
                    }
                }
                if (TJAPlayer3.ConfigIni.eGameMode == EGame.完走叩ききりまショー)
                    TJAPlayer3.act文字コンソール.tPrint(0, 0, C文字コンソール.Eフォント種別.白, "GAME: SURVIVAL");
                if (TJAPlayer3.ConfigIni.eGameMode == EGame.完走叩ききりまショー激辛)
                    TJAPlayer3.act文字コンソール.tPrint(0, 0, C文字コンソール.Eフォント種別.白, "GAME: SURVIVAL HARD");
                if (TJAPlayer3.ConfigIni.bSuperHard)
                    TJAPlayer3.act文字コンソール.tPrint(0, 16, C文字コンソール.Eフォント種別.赤, "SUPER HARD MODE : ON");
                if (TJAPlayer3.ConfigIni.eScrollMode == EScrollMode.BMSCROLL)
                    TJAPlayer3.act文字コンソール.tPrint(0, 32, C文字コンソール.Eフォント種別.赤, "BMSCROLL : ON");
                else if (TJAPlayer3.ConfigIni.eScrollMode == EScrollMode.HBSCROLL)
                    TJAPlayer3.act文字コンソール.tPrint(0, 32, C文字コンソール.Eフォント種別.赤, "HBSCROLL : ON");
                #endregion

                //this.actステータスパネル.On進行描画();

                this.actPresound.On進行描画();
				//if( this.txコメントバー != null )
				{
					//this.txコメントバー.t2D描画( CDTXMania.app.Device, 484, 314 );
				}
				//this.actArtistComment.On進行描画();
                this.act演奏履歴パネル.On進行描画();
				//this.actオプションパネル.On進行描画();
				this.actShowCurrentPosition.On進行描画();								// #27648 2011.3.28 yyagi

                //CDTXMania.act文字コンソール.tPrint( 0, 0, C文字コンソール.Eフォント種別.白, this.n現在選択中の曲の難易度.ToString() );
                TJAPlayer3.Tx.SongSelect_Difficulty.t2D描画( TJAPlayer3.app.Device, 980, 30, new Rectangle( 0, 70 * this.n現在選択中の曲の難易度, 260, 70 ) );

				if( !this.bBGM再生済み && ( base.eフェーズID == CStage.Eフェーズ.共通_通常状態 ) )
				{
					TJAPlayer3.Skin.bgm選曲画面.t再生する();
					this.bBGM再生済み = true;
				}


//Debug.WriteLine( "パンくず=" + this.r現在選択中の曲.strBreadcrumbs );
                if( this.ctDiffSelect移動待ち != null )
                    this.ctDiffSelect移動待ち.t進行();

				// キー入力
				if( base.eフェーズID == CStage.Eフェーズ.共通_通常状態 
					&& TJAPlayer3.act現在入力を占有中のプラグイン == null )
				{
					#region [ 簡易CONFIGでMore、またはShift+F1: 詳細CONFIG呼び出し ]
					if (  actQuickConfig.bGotoDetailConfig )
					{	// 詳細CONFIG呼び出し
						actQuickConfig.tDeativatePopupMenu();
						this.actPresound.tサウンド停止();
						this.eフェードアウト完了時の戻り値 = E戻り値.コンフィグ呼び出し;	// #24525 2011.3.16 yyagi: [SHIFT]-[F1]でCONFIG呼び出し
						this.actFIFO.tフェードアウト開始();
						base.eフェーズID = CStage.Eフェーズ.共通_フェードアウト;
						TJAPlayer3.Skin.sound取消音.t再生する();
						return 0;
					}
					#endregion
					if ( !this.actSortSongs.bIsActivePopupMenu && !this.actQuickConfig.bIsActivePopupMenu /*&&  !this.act難易度選択画面.bIsDifficltSelect */ )
					{
                        #region [ ESC ]
                        if (TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDX.DirectInput.Key.Escape) && (this.act曲リスト.r現在選択中の曲 != null))// && (  ) ) )
			{
                            if (this.act曲リスト.r現在選択中の曲.r親ノード == null && b難易度選択中でない)
                            {   // [ESC]
                                TJAPlayer3.Skin.sound取消音.t再生する();
                                this.eフェードアウト完了時の戻り値 = E戻り値.タイトルに戻る;
                                this.actFIFO.tフェードアウト開始();
                                base.eフェーズID = CStage.Eフェーズ.共通_フェードアウト;
                                return 0;
                            }
                            else if (b難易度選択中でない)
                            {
                                TJAPlayer3.Skin.sound取消音.t再生する();
                                bool bNeedChangeSkin = this.act曲リスト.tBOXを出る();
                                this.actPresound.tサウンド停止();
                            }
                            else
                            {
                                TJAPlayer3.Skin.sound取消音.t再生する();
                                b難易度選択中でない = true;
                            }
			}
                        #endregion
                        #region [ Shift-F1: CONFIG画面 ]
                        if ( ( TJAPlayer3.Input管理.Keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.RightShift ) || TJAPlayer3.Input管理.Keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.LeftShift ) ) &&
							TJAPlayer3.Input管理.Keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.F1 ) )
						{	// [SHIFT] + [F1] CONFIG
							this.actPresound.tサウンド停止();
							this.eフェードアウト完了時の戻り値 = E戻り値.コンフィグ呼び出し;	// #24525 2011.3.16 yyagi: [SHIFT]-[F1]でCONFIG呼び出し
							this.actFIFO.tフェードアウト開始();
							base.eフェーズID = CStage.Eフェーズ.共通_フェードアウト;
							TJAPlayer3.Skin.sound取消音.t再生する();
							return 0;
						}
						#endregion
						#region [ F2 簡易オプション ]
						if ( TJAPlayer3.Input管理.Keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.F2 ) )
						{
                            TJAPlayer3.Skin.sound変更音.t再生する();
                            this.actQuickConfig.tActivatePopupMenu( E楽器パート.DRUMS );
						}
						#endregion
						#region [ F3 1PオートON/OFF ]
						if ( TJAPlayer3.Input管理.Keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.F3 ) )
						{
							TJAPlayer3.Skin.sound変更音.t再生する();
                            C共通.bToggleBoolian( ref TJAPlayer3.ConfigIni.b太鼓パートAutoPlay );
						}
                        #endregion
                        #region [ F4 2PオートON/OFF ]
                        if (TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDX.DirectInput.Key.F4))
                        {
                            if (TJAPlayer3.ConfigIni.nPlayerCount > 1)
                            {
                                TJAPlayer3.Skin.sound変更音.t再生する();
                                C共通.bToggleBoolian(ref TJAPlayer3.ConfigIni.b太鼓パートAutoPlay2P);
                            }
                        }
                        #endregion
                        #region [ F5 スーパーハード ]
                        if ( TJAPlayer3.Input管理.Keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.F5 ) )
						{
							TJAPlayer3.Skin.sound変更音.t再生する();
                            C共通.bToggleBoolian( ref TJAPlayer3.ConfigIni.bSuperHard );
						}
						#endregion
						#region [ F6 SCROLL ]
						if ( TJAPlayer3.Input管理.Keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.F6 ) )
						{
							TJAPlayer3.Skin.sound変更音.t再生する();
                            TJAPlayer3.ConfigIni.bスクロールモードを上書き = true;
                            switch( (int)TJAPlayer3.ConfigIni.eScrollMode )
                            {
                                case 0:
                                    TJAPlayer3.ConfigIni.eScrollMode = EScrollMode.BMSCROLL;
                                    break;
                                case 1:
                                    TJAPlayer3.ConfigIni.eScrollMode = EScrollMode.HBSCROLL;
                                    break;
                                case 2:
                                    TJAPlayer3.ConfigIni.eScrollMode = EScrollMode.Normal;
                                    TJAPlayer3.ConfigIni.bスクロールモードを上書き = false;
                                    break;
                            }
						}
						#endregion

						if ( this.act曲リスト.r現在選択中の曲 != null )
						{
                            #region [ Decide ]
                            if ((TJAPlayer3.Pad.b押されたDGB(Eパッド.Decide) || (TJAPlayer3.Pad.b押されたDGB(Eパッド.LRed) || TJAPlayer3.Pad.b押されたDGB(Eパッド.RRed)) ||
                                    ((TJAPlayer3.ConfigIni.bEnterがキー割り当てのどこにも使用されていない && TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDX.DirectInput.Key.Return)))))
                            {
                                if (this.act曲リスト.r現在選択中の曲 != null)
                                {
                                    switch (this.act曲リスト.r現在選択中の曲.eノード種別)
                                    {
                                        case C曲リストノード.Eノード種別.SCORE:
                                            if(b難易度選択中でない)
                                            {
                                                TJAPlayer3.Skin.sound決定音.t再生する();
                                                b難易度選択中でない = false;
                                            }
                                            else
                                            {
                                                if (TJAPlayer3.Skin.sound曲決定音.b読み込み成功)
                                                    TJAPlayer3.Skin.sound曲決定音.t再生する();
                                                else
                                                    TJAPlayer3.Skin.sound決定音.t再生する();
                                                this.t曲を選択する();
                                            }
                                            break;
                                        case C曲リストノード.Eノード種別.BOX:
                                            {
                                                TJAPlayer3.Skin.sound決定音.t再生する();
                                                bool bNeedChangeSkin = this.act曲リスト.tBOXに入る();
                                                if (bNeedChangeSkin)
                                                {
                                                    this.eフェードアウト完了時の戻り値 = E戻り値.スキン変更;
                                                    base.eフェーズID = Eフェーズ.選曲_NowLoading画面へのフェードアウト;
                                                }
                                            }
                                            break;
                                        case C曲リストノード.Eノード種別.BACKBOX:
                                            {
                                                TJAPlayer3.Skin.sound取消音.t再生する();
                                                bool bNeedChangeSkin = this.act曲リスト.tBOXを出る();
                                                if (bNeedChangeSkin)
                                                {
                                                    this.eフェードアウト完了時の戻り値 = E戻り値.スキン変更;
                                                    base.eフェーズID = Eフェーズ.選曲_NowLoading画面へのフェードアウト;
                                                }
                                            }
                                            break;
                                        case C曲リストノード.Eノード種別.RANDOM:
                                            if (TJAPlayer3.Skin.sound曲決定音.b読み込み成功)
                                                TJAPlayer3.Skin.sound曲決定音.t再生する();
                                            else
                                                TJAPlayer3.Skin.sound決定音.t再生する();
                                            this.t曲をランダム選択する();
                                            break;
                                        //case C曲リストノード.Eノード種別.DANI:
                                        //    if (CDTXMania.Skin.sound段位移動.b読み込み成功)
                                        //        CDTXMania.Skin.sound段位移動.t再生する();
                                        //    else
                                        //        CDTXMania.Skin.sound段位移動.t再生する();
                                        //    this.X();
                                        //    break;
                                    }
                                }
                            }
                            #endregion
                            #region [ Up ]
                            this.ctキー反復用.Up.tキー反復( TJAPlayer3.Input管理.Keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.LeftArrow ), new CCounter.DGキー処理( this.tカーソルを上へ移動する ) );
							//this.ctキー反復用.Up.tキー反復( CDTXMania.Input管理.Keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.UpArrow ) || CDTXMania.Input管理.Keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.LeftArrow ), new CCounter.DGキー処理( this.tカーソルを上へ移動する ) );
							if ( TJAPlayer3.Pad.b押された( E楽器パート.DRUMS, Eパッド.LBlue ) )
							{
                                if (b難易度選択中でない)
                                {
                                    this.tカーソルを上へ移動する();
                                }
                                else
                                {
                                    Debug.WriteLine("ドラムス難易度変更");
                                    this.act曲リスト.t難易度レベルをひとつ戻す();
                                    TJAPlayer3.Skin.sound変更音.t再生する();
                                }
							}
							#endregion
							#region [ Down ]
							this.ctキー反復用.Down.tキー反復( TJAPlayer3.Input管理.Keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.RightArrow ), new CCounter.DGキー処理( this.tカーソルを下へ移動する ) );
							//this.ctキー反復用.Down.tキー反復( CDTXMania.Input管理.Keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.DownArrow ) || CDTXMania.Input管理.Keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.RightArrow ), new CCounter.DGキー処理( this.tカーソルを下へ移動する ) );
							if ( TJAPlayer3.Pad.b押された( E楽器パート.DRUMS, Eパッド.RBlue ) )
							{
                                if (b難易度選択中でない)
                                {
                                    this.tカーソルを下へ移動する();
                                }
                                else
                                {
                                    Debug.WriteLine("ドラムス難易度変更");
                                    this.act曲リスト.t難易度レベルをひとつ進める();
                                    TJAPlayer3.Skin.sound変更音.t再生する();
                                }
							}
							#endregion
							#region [ Upstairs ]
							if ( ( ( this.act曲リスト.r現在選択中の曲 != null ) && ( this.act曲リスト.r現在選択中の曲.r親ノード != null ) ) && ( TJAPlayer3.Pad.b押された( E楽器パート.DRUMS, Eパッド.FT ) || TJAPlayer3.Pad.b押されたGB( Eパッド.Cancel ) ) )
							{
								this.actPresound.tサウンド停止();
								TJAPlayer3.Skin.sound取消音.t再生する();
								this.act曲リスト.tBOXを出る();
								this.t選択曲変更通知();
							}
							#endregion
							#region [ BDx2: 簡易CONFIG ]
                            if( TJAPlayer3.Input管理.Keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.Space ) )
                            {
							    TJAPlayer3.Skin.sound変更音.t再生する();
								this.actSortSongs.tActivatePopupMenu( E楽器パート.DRUMS, ref this.act曲リスト );
                            }
							#endregion
							#region [ HHx2: 難易度変更 ]
							if ( TJAPlayer3.Pad.b押された( E楽器パート.DRUMS, Eパッド.HH ) || TJAPlayer3.Pad.b押された( E楽器パート.DRUMS, Eパッド.HHO ) )
							{	// [HH]x2 難易度変更
								CommandHistory.Add( E楽器パート.DRUMS, EパッドFlag.HH );
								EパッドFlag[] comChangeDifficulty = new EパッドFlag[] { EパッドFlag.HH, EパッドFlag.HH };
								if ( CommandHistory.CheckCommand( comChangeDifficulty, E楽器パート.DRUMS ) )
								{
									Debug.WriteLine( "ドラムス難易度変更" );
									this.act曲リスト.t難易度レベルをひとつ進める();
									TJAPlayer3.Skin.sound変更音.t再生する();
								}
							}
							#endregion
							#region [ 上: 難易度変更(上) ]
							if( TJAPlayer3.Input管理.Keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.UpArrow ) )
							{
								//CommandHistory.Add( E楽器パート.DRUMS, EパッドFlag.HH );
								//EパッドFlag[] comChangeDifficulty = new EパッドFlag[] { EパッドFlag.HH, EパッドFlag.HH };
								//if ( CommandHistory.CheckCommand( comChangeDifficulty, E楽器パート.DRUMS ) )
								{
									Debug.WriteLine( "ドラムス難易度変更" );
                                    this.act曲リスト.t難易度レベルをひとつ進める();
									TJAPlayer3.Skin.sound変更音.t再生する();
								}
							}
							#endregion
							#region [ 下: 難易度変更(下) ]
							if( TJAPlayer3.Input管理.Keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.DownArrow ) )
							{
								//CommandHistory.Add( E楽器パート.DRUMS, EパッドFlag.HH );
								//EパッドFlag[] comChangeDifficulty = new EパッドFlag[] { EパッドFlag.HH, EパッドFlag.HH };
								//if ( CommandHistory.CheckCommand( comChangeDifficulty, E楽器パート.DRUMS ) )
								{
									Debug.WriteLine( "ドラムス難易度変更" );
                                    this.act曲リスト.t難易度レベルをひとつ戻す();
									TJAPlayer3.Skin.sound変更音.t再生する();
								}
							}
							#endregion
						}
					}

				    #region [ Minus & Equals Sound Group Level ]
				    KeyboardSoundGroupLevelControlHandler.Handle(
				        TJAPlayer3.Input管理.Keyboard, TJAPlayer3.SoundGroupLevelController, TJAPlayer3.Skin, true);
				    #endregion

					this.actSortSongs.t進行描画();
					this.actQuickConfig.t進行描画();
				}
                //------------------------------
                //if (this.act難易度選択画面.bIsDifficltSelect)
                //{

                //    if (this.ctDiffSelect移動待ち.n現在の値 == this.ctDiffSelect移動待ち.n終了値)
                //    {
                //        this.act難易度選択画面.On進行描画();
                //        CDTXMania.act文字コンソール.tPrint(0, 0, C文字コンソール.Eフォント種別.赤, "NowStage:DifficltSelect");
                //    }
                //    CDTXMania.act文字コンソール.tPrint(0, 16, C文字コンソール.Eフォント種別.赤, "Count:" + this.ctDiffSelect移動待ち.n現在の値);
                //}
                //------------------------------
				switch ( base.eフェーズID )
				{
					case CStage.Eフェーズ.共通_フェードイン:
						if( this.actFIFO.On進行描画() != 0 )
						{
							base.eフェーズID = CStage.Eフェーズ.共通_通常状態;
						}
						break;

					case CStage.Eフェーズ.共通_フェードアウト:
						if( this.actFIFO.On進行描画() == 0 )
						{
							break;
						}
						return (int) this.eフェードアウト完了時の戻り値;

					case CStage.Eフェーズ.選曲_結果画面からのフェードイン:
						if( this.actFIfrom結果画面.On進行描画() != 0 )
						{
							base.eフェーズID = CStage.Eフェーズ.共通_通常状態;
						}
						break;

					case CStage.Eフェーズ.選曲_NowLoading画面へのフェードアウト:
						if( this.actFOtoNowLoading.On進行描画() == 0 )
						{
							break;
						}
						return (int) this.eフェードアウト完了時の戻り値;
				}
			}
			return 0;
		}
		public enum E戻り値 : int
		{
			継続,
			タイトルに戻る,
			選曲した,
			オプション呼び出し,
			コンフィグ呼び出し,
			スキン変更
		}
		

		// その他

		#region [ private ]
		//-----------------
		[StructLayout( LayoutKind.Sequential )]
		private struct STキー反復用カウンタ
		{
			public CCounter Up;
			public CCounter Down;
			public CCounter R;
			public CCounter B;
			public CCounter this[ int index ]
			{
				get
				{
					switch( index )
					{
						case 0:
							return this.Up;

						case 1:
							return this.Down;

						case 2:
							return this.R;

						case 3:
							return this.B;
					}
					throw new IndexOutOfRangeException();
				}
				set
				{
					switch( index )
					{
						case 0:
							this.Up = value;
							return;

						case 1:
							this.Down = value;
							return;

						case 2:
							this.R = value;
							return;

						case 3:
							this.B = value;
							return;
					}
					throw new IndexOutOfRangeException();
				}
			}
		}
		private CActSelectArtistComment actArtistComment;
		private CActFIFOBlack actFIFO;
		private CActFIFOBlack actFIfrom結果画面;
		//private CActFIFOBlack actFOtoNowLoading;
        private CActFIFOStart actFOtoNowLoading;
		private CActSelectInformation actInformation;
		private CActSelectPreimageパネル actPreimageパネル;
		public CActSelectPresound actPresound;
		private CActオプションパネル actオプションパネル;
		private CActSelectステータスパネル actステータスパネル;
		public CActSelect演奏履歴パネル act演奏履歴パネル;
		public CActSelect曲リスト act曲リスト;
		private CActSelectShowCurrentPosition actShowCurrentPosition;
        private CActSelect難易度選択画面 act難易度選択画面;

		public CActSortSongs actSortSongs;
		private CActSelectQuickConfig actQuickConfig;

                private int nGenreBack;
		private bool bBGM再生済み;
		private STキー反復用カウンタ ctキー反復用;
		public CCounter ct登場時アニメ用共通;
		private CCounter ct背景スクロール用タイマー;
		private E戻り値 eフェードアウト完了時の戻り値;
		private Font ftフォント;
		//private CTexture tx下部パネル;
		//private CTexture tx上部パネル;
		//private CTexture tx背景;
  //      private CTexture[] txジャンル別背景 = new CTexture[9];
  //      private CTexture[] tx難易度別背景 = new CTexture[5];
  //      private CTexture tx難易度名;
  //      private CTexture tx下部テキスト;
        private CCounter ctDiffSelect移動待ち;
	        private bool b難易度選択中でない = true;

		private struct STCommandTime		// #24063 2011.1.16 yyagi コマンド入力時刻の記録用
		{
			public E楽器パート eInst;		// 使用楽器
			public EパッドFlag ePad;		// 押されたコマンド(同時押しはOR演算で列挙する)
			public long time;				// コマンド入力時刻
		}
		private class CCommandHistory		// #24063 2011.1.16 yyagi コマンド入力履歴を保持_確認するクラス
		{
			readonly int buffersize = 16;
			private List<STCommandTime> stct;

			public CCommandHistory()		// コンストラクタ
			{
				stct = new List<STCommandTime>( buffersize );
			}

			/// <summary>
			/// コマンド入力履歴へのコマンド追加
			/// </summary>
			/// <param name="_eInst">楽器の種類</param>
			/// <param name="_ePad">入力コマンド(同時押しはOR演算で列挙すること)</param>
			public void Add( E楽器パート _eInst, EパッドFlag _ePad )
			{
				STCommandTime _stct = new STCommandTime {
					eInst = _eInst,
					ePad = _ePad,
					time = TJAPlayer3.Timer.n現在時刻
				};

				if ( stct.Count >= buffersize )
				{
					stct.RemoveAt( 0 );
				}
				stct.Add(_stct);
//Debug.WriteLine( "CMDHIS: 楽器=" + _stct.eInst + ", CMD=" + _stct.ePad + ", time=" + _stct.time );
			}
			public void RemoveAt( int index )
			{
				stct.RemoveAt( index );
			}

			/// <summary>
			/// コマンド入力に成功しているか調べる
			/// </summary>
			/// <param name="_ePad">入力が成功したか調べたいコマンド</param>
			/// <param name="_eInst">対象楽器</param>
			/// <returns>コマンド入力成功時true</returns>
			public bool CheckCommand( EパッドFlag[] _ePad, E楽器パート _eInst)
			{
				int targetCount = _ePad.Length;
				int stciCount = stct.Count;
				if ( stciCount < targetCount )
				{
//Debug.WriteLine("NOT start checking...stciCount=" + stciCount + ", targetCount=" + targetCount);
					return false;
				}

				long curTime = TJAPlayer3.Timer.n現在時刻;
//Debug.WriteLine("Start checking...targetCount=" + targetCount);
				for ( int i = targetCount - 1, j = stciCount - 1; i >= 0; i--, j-- )
				{
					if ( _ePad[ i ] != stct[ j ].ePad )
					{
//Debug.WriteLine( "CMD解析: false targetCount=" + targetCount + ", i=" + i + ", j=" + j + ": ePad[]=" + _ePad[i] + ", stci[j] = " + stct[j].ePad );
						return false;
					}
					if ( stct[ j ].eInst != _eInst )
					{
//Debug.WriteLine( "CMD解析: false " + i );
						return false;
					}
					if ( curTime - stct[ j ].time > 500 )
					{
//Debug.WriteLine( "CMD解析: false " + i + "; over 500ms" );
						return false;
					}
					curTime = stct[ j ].time;
				}

//Debug.Write( "CMD解析: 成功!(" + _ePad.Length + ") " );
//for ( int i = 0; i < _ePad.Length; i++ ) Debug.Write( _ePad[ i ] + ", " );
//Debug.WriteLine( "" );
				//stct.RemoveRange( 0, targetCount );			// #24396 2011.2.13 yyagi 
				stct.Clear();									// #24396 2011.2.13 yyagi Clear all command input history in case you succeeded inputting some command

				return true;
			}
		}
		private CCommandHistory CommandHistory;

		private void tカーソルを下へ移動する()
		{
			TJAPlayer3.Skin.soundカーソル移動音.t再生する();
			this.act曲リスト.t次に移動();
		}
		private void tカーソルを上へ移動する()
		{
			TJAPlayer3.Skin.soundカーソル移動音.t再生する();
			this.act曲リスト.t前に移動();
		}
		private void t曲をランダム選択する()
		{
			C曲リストノード song = this.act曲リスト.r現在選択中の曲;
			if( ( song.stackランダム演奏番号.Count == 0 ) || ( song.listランダム用ノードリスト == null ) )
			{
				if( song.listランダム用ノードリスト == null )
				{
					song.listランダム用ノードリスト = this.t指定された曲が存在する場所の曲を列挙する_子リスト含む( song );
				}
				int count = song.listランダム用ノードリスト.Count;
				if( count == 0 )
				{
					return;
				}
				int[] numArray = new int[ count ];
				for( int i = 0; i < count; i++ )
				{
					numArray[ i ] = i;
				}
				for( int j = 0; j < ( count * 1.5 ); j++ )
				{
					int index = TJAPlayer3.Random.Next( count );
					int num5 = TJAPlayer3.Random.Next( count );
					int num6 = numArray[ num5 ];
					numArray[ num5 ] = numArray[ index ];
					numArray[ index ] = num6;
				}
				for( int k = 0; k < count; k++ )
				{
					song.stackランダム演奏番号.Push( numArray[ k ] );
				}
				if( TJAPlayer3.ConfigIni.bLogDTX詳細ログ出力 )
				{
					StringBuilder builder = new StringBuilder( 0x400 );
					builder.Append( string.Format( "ランダムインデックスリストを作成しました: {0}曲: ", song.stackランダム演奏番号.Count ) );
					for( int m = 0; m < count; m++ )
					{
						builder.Append( string.Format( "{0} ", numArray[ m ] ) );
					}
					Trace.TraceInformation( builder.ToString() );
				}
			}
			this.r確定された曲 = song.listランダム用ノードリスト[ song.stackランダム演奏番号.Pop() ];
			this.n確定された曲の難易度 = this.act曲リスト.n現在のアンカ難易度レベルに最も近い難易度レベルを返す( this.r確定された曲 );
			this.r確定されたスコア = this.r確定された曲.arスコア[ this.n確定された曲の難易度 ];
            this.str確定された曲のジャンル = this.r確定された曲.strジャンル;
			this.eフェードアウト完了時の戻り値 = E戻り値.選曲した;
			this.actFOtoNowLoading.tフェードアウト開始();					// #27787 2012.3.10 yyagi 曲決定時の画面フェードアウトの省略
			base.eフェーズID = CStage.Eフェーズ.選曲_NowLoading画面へのフェードアウト;
			if( TJAPlayer3.ConfigIni.bLogDTX詳細ログ出力 )
			{
				int[] numArray2 = song.stackランダム演奏番号.ToArray();
				StringBuilder builder2 = new StringBuilder( 0x400 );
				builder2.Append( "ランダムインデックスリスト残り: " );
				if( numArray2.Length > 0 )
				{
					for( int n = 0; n < numArray2.Length; n++ )
					{
						builder2.Append( string.Format( "{0} ", numArray2[ n ] ) );
					}
				}
				else
				{
					builder2.Append( "(なし)" );
				}
				Trace.TraceInformation( builder2.ToString() );
			}
			TJAPlayer3.Skin.bgm選曲画面.t停止する();
		}
		private void t曲を選択する()
		{
			this.r確定された曲 = this.act曲リスト.r現在選択中の曲;
			this.r確定されたスコア = this.act曲リスト.r現在選択中のスコア;
			this.n確定された曲の難易度 = this.act曲リスト.n現在選択中の曲の現在の難易度レベル;
            this.str確定された曲のジャンル = this.r確定された曲.strジャンル;
            if ( ( this.r確定された曲 != null ) && ( this.r確定されたスコア != null ) )
			{
				this.eフェードアウト完了時の戻り値 = E戻り値.選曲した;
				this.actFOtoNowLoading.tフェードアウト開始();				// #27787 2012.3.10 yyagi 曲決定時の画面フェードアウトの省略
				base.eフェーズID = CStage.Eフェーズ.選曲_NowLoading画面へのフェードアウト;
			}
			TJAPlayer3.Skin.bgm選曲画面.t停止する();
		}
		public void t曲を選択する( int nCurrentLevel )
		{
			this.r確定された曲 = this.act曲リスト.r現在選択中の曲;
			this.r確定されたスコア = this.act曲リスト.r現在選択中のスコア;
			this.n確定された曲の難易度 = nCurrentLevel;
            this.str確定された曲のジャンル = this.r確定された曲.strジャンル;
            if ( ( this.r確定された曲 != null ) && ( this.r確定されたスコア != null ) )
			{
				this.eフェードアウト完了時の戻り値 = E戻り値.選曲した;
				this.actFOtoNowLoading.tフェードアウト開始();				// #27787 2012.3.10 yyagi 曲決定時の画面フェードアウトの省略
				base.eフェーズID = CStage.Eフェーズ.選曲_NowLoading画面へのフェードアウト;
			}

			TJAPlayer3.Skin.bgm選曲画面.t停止する();
		}
		private List<C曲リストノード> t指定された曲が存在する場所の曲を列挙する_子リスト含む( C曲リストノード song )
		{
			List<C曲リストノード> list = new List<C曲リストノード>();
			song = song.r親ノード;
			if( ( song == null ) && ( TJAPlayer3.Songs管理.list曲ルート.Count > 0 ) )
			{
				foreach( C曲リストノード c曲リストノード in TJAPlayer3.Songs管理.list曲ルート )
				{
					if( ( c曲リストノード.eノード種別 == C曲リストノード.Eノード種別.SCORE ) || ( c曲リストノード.eノード種別 == C曲リストノード.Eノード種別.SCORE_MIDI ) )
					{
						list.Add( c曲リストノード );
					}
					if( ( c曲リストノード.list子リスト != null ) && TJAPlayer3.ConfigIni.bランダムセレクトで子BOXを検索対象とする )
					{
						this.t指定された曲の子リストの曲を列挙する_孫リスト含む( c曲リストノード, ref list );
					}
				}
				return list;
			}
			this.t指定された曲の子リストの曲を列挙する_孫リスト含む( song, ref list );
			return list;
		}
		private void t指定された曲の子リストの曲を列挙する_孫リスト含む( C曲リストノード r親, ref List<C曲リストノード> list )
		{
			if( ( r親 != null ) && ( r親.list子リスト != null ) )
			{
				foreach( C曲リストノード c曲リストノード in r親.list子リスト )
				{
					if( ( c曲リストノード.eノード種別 == C曲リストノード.Eノード種別.SCORE ) || ( c曲リストノード.eノード種別 == C曲リストノード.Eノード種別.SCORE_MIDI ) )
					{
						list.Add( c曲リストノード );
					}
					if( ( c曲リストノード.list子リスト != null ) && TJAPlayer3.ConfigIni.bランダムセレクトで子BOXを検索対象とする )
					{
						this.t指定された曲の子リストの曲を列挙する_孫リスト含む( c曲リストノード, ref list );
					}
				}
			}
		}

        private int nStrジャンルtoNum( string strジャンル )
        {
            int nGenre = 8;
            switch( strジャンル )
            {
                case "アニメ":
                    nGenre = 2;
                    break;
                case "J-POP":
                    nGenre = 1;
                    break;
                case "ゲームミュージック":
                    nGenre = 3;
                    break;
                case "ナムコオリジナル":
                    nGenre = 4;
                    break;
                case "クラシック":
                    nGenre = 5;
                    break;
                case "どうよう":
                    nGenre = 7;
                    break;
                case "バラエティ":
                    nGenre = 6;
                    break;
                case "ボーカロイド":
                case "VOCALOID":
                    nGenre = 8;
                    break;
                default:
                    nGenre = 0;
                    break;

            }

            return nGenre;
        }
		//-----------------
		#endregion
	}
}
