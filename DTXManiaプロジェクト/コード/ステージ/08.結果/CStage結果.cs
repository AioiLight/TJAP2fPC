using System;
using System.IO;
using System.Diagnostics;
using FDK;

namespace DTXMania
{
	internal class CStage結果 : CStage
	{
		// プロパティ

		public STDGBVALUE<bool> b新記録スキル;
		public STDGBVALUE<bool> b新記録スコア;
        public STDGBVALUE<bool> b新記録ランク;
		public STDGBVALUE<float> fPerfect率;
		public STDGBVALUE<float> fGreat率;
		public STDGBVALUE<float> fGood率;
		public STDGBVALUE<float> fPoor率;
        public STDGBVALUE<float> fMiss率;
        public STDGBVALUE<bool> bオート;        // #23596 10.11.16 add ikanick
                                                //        10.11.17 change (int to bool) ikanick
		public STDGBVALUE<int> nランク値;
		public STDGBVALUE<int> n演奏回数;
		public int n総合ランク値;
		public CDTX.CChip[] r空うちドラムチップ;
		public STDGBVALUE<CScoreIni.C演奏記録> st演奏記録;


		// コンストラクタ

		public CStage結果()
		{
			this.st演奏記録.Drums = new CScoreIni.C演奏記録();
			this.st演奏記録.Guitar = new CScoreIni.C演奏記録();
			this.st演奏記録.Bass = new CScoreIni.C演奏記録();
			this.st演奏記録.Taiko = new CScoreIni.C演奏記録();
			this.r空うちドラムチップ = new CDTX.CChip[ 10 ];
			this.n総合ランク値 = -1;
			this.nチャンネル0Atoレーン07 = new int[] { 1, 2, 3, 4, 5, 7, 6, 1, 7, 0 };
			base.eステージID = CStage.Eステージ.結果;
			base.eフェーズID = CStage.Eフェーズ.共通_通常状態;
			base.b活性化してない = true;
			base.list子Activities.Add( this.actResultImage = new CActResultImage() );
			base.list子Activities.Add( this.actParameterPanel = new CActResultParameterPanel() );
			base.list子Activities.Add( this.actRank = new CActResultRank() );
			base.list子Activities.Add( this.actSongBar = new CActResultSongBar() );
			base.list子Activities.Add( this.actOption = new CActオプションパネル() );
			base.list子Activities.Add( this.actFI = new CActFIFOResult() );
			base.list子Activities.Add( this.actFO = new CActFIFOBlack() );
		}

		
		// CStage 実装

		public override void On活性化()
		{
			Trace.TraceInformation( "結果ステージを活性化します。" );
			Trace.Indent();
			try
			{
				#region [ 初期化 ]
				//---------------------
				this.eフェードアウト完了時の戻り値 = E戻り値.継続;
				this.bアニメが完了 = false;
				this.bIsCheckedWhetherResultScreenShouldSaveOrNot = false;				// #24609 2011.3.14 yyagi
				this.n最後に再生したHHのWAV番号 = -1;
				this.n最後に再生したHHのチャンネル番号 = 0;
				for( int i = 0; i < 3; i++ )
				{
					this.b新記録スキル[ i ] = false;
                    this.b新記録スコア[ i ] = false;
                    this.b新記録ランク[ i ] = false;
				}
				//---------------------
				#endregion

				#region [ 結果の計算 ]
				//---------------------
				for( int i = 0; i < 3; i++ )
				{
					this.nランク値[ i ] = -1;
					this.fPerfect率[ i ] = this.fGreat率[ i ] = this.fGood率[ i ] = this.fPoor率[ i ] = this.fMiss率[ i ] = 0.0f;	// #28500 2011.5.24 yyagi
					if ( ( ( ( i != 0 ) || ( CDTXMania.DTX.bチップがある.Drums  ) ) ) )
					{
						CScoreIni.C演奏記録 part = this.st演奏記録[ i ];
						bool bIsAutoPlay = true;
						switch( i )
						{
							case 0:
                                bIsAutoPlay = CDTXMania.ConfigIni.b太鼓パートAutoPlay;
								break;

							case 1:
								bIsAutoPlay = CDTXMania.ConfigIni.b太鼓パートAutoPlay;
								break;

							case 2:
								bIsAutoPlay = CDTXMania.ConfigIni.b太鼓パートAutoPlay;
								break;
						}
						this.fPerfect率[ i ] = bIsAutoPlay ? 0f : ( ( 100f * part.nPerfect数 ) / ( (float) part.n全チップ数 ) );
						this.fGreat率[ i ] = bIsAutoPlay ? 0f : ( ( 100f * part.nGreat数 ) / ( (float) part.n全チップ数 ) );
						this.fGood率[ i ] = bIsAutoPlay ? 0f : ( ( 100f * part.nGood数 ) / ( (float) part.n全チップ数 ) );
						this.fPoor率[ i ] = bIsAutoPlay ? 0f : ( ( 100f * part.nPoor数 ) / ( (float) part.n全チップ数 ) );
						this.fMiss率[ i ] = bIsAutoPlay ? 0f : ( ( 100f * part.nMiss数 ) / ( (float) part.n全チップ数 ) );
						this.bオート[ i ] = bIsAutoPlay;	// #23596 10.11.16 add ikanick そのパートがオートなら1
															//        10.11.17 change (int to bool) ikanick
						this.nランク値[ i ] = CScoreIni.tランク値を計算して返す( part );
					}
				}
				this.n総合ランク値 = CScoreIni.t総合ランク値を計算して返す( this.st演奏記録.Drums, this.st演奏記録.Guitar, this.st演奏記録.Bass );
				//---------------------
				#endregion

                #region [ .score.ini の作成と出力 ]
				//---------------------
				string str = CDTXMania.DTX.strファイル名の絶対パス + ".score.ini";
				CScoreIni ini = new CScoreIni( str );

				bool[] b今までにフルコンボしたことがある = new bool[] { false, false, false };

				for( int i = 0; i < 3; i++ )
				{
					// フルコンボチェックならびに新記録ランクチェックは、ini.Record[] が、スコアチェックや演奏型スキルチェックの IF 内で書き直されてしまうよりも前に行う。(2010.9.10)
					
					b今までにフルコンボしたことがある[ i ] = ini.stセクション[ i * 2 ].bフルコンボである | ini.stセクション[ i * 2 + 1 ].bフルコンボである;

					#region [deleted by #24459]
			//		if( this.nランク値[ i ] <= CScoreIni.tランク値を計算して返す( ini.stセクション[ ( i * 2 ) + 1 ] ) )
			//		{
			//			this.b新記録ランク[ i ] = true;
					//		}
					#endregion
					// #24459 上記の条件だと[HiSkill.***]でのランクしかチェックしていないので、BestRankと比較するよう変更。
					if ( this.nランク値[ i ] >= 0 && ini.stファイル.BestRank[ i ] > this.nランク値[ i ] )		// #24459 2011.3.1 yyagi update BestRank
					{
						this.b新記録ランク[ i ] = true;
						ini.stファイル.BestRank[ i ] = this.nランク値[ i ];
					}

					// 新記録スコアチェック
					if( ( this.st演奏記録[ i ].nスコア > ini.stセクション[ i * 2 ].nスコア ) && !CDTXMania.ConfigIni.b太鼓パートAutoPlay )
					{
						this.b新記録スコア[ i ] = true;
						ini.stセクション[ i * 2 ] = this.st演奏記録[ i ];
					}

                    // 新記録スキルチェック
                    if (this.st演奏記録[i].db演奏型スキル値 > ini.stセクション[(i * 2) + 1].db演奏型スキル値)
                    {
                        this.b新記録スキル[ i ] = true;
                        ini.stセクション[(i * 2) + 1] = this.st演奏記録[ i ];
                    }

					// ラストプレイ #23595 2011.1.9 ikanick
                    // オートじゃなければプレイ結果を書き込む
                    if( CDTXMania.ConfigIni.b太鼓パートAutoPlay == false ) {
                        ini.stセクション[i + 6] = this.st演奏記録[ i ];
                    }

                    // #23596 10.11.16 add ikanick オートじゃないならクリア回数を1増やす
                    //        11.02.05 bオート to t更新条件を取得する use      ikanick
					bool[] b更新が必要か否か = new bool[ 3 ];
					CScoreIni.t更新条件を取得する( out b更新が必要か否か[ 0 ], out b更新が必要か否か[ 1 ], out b更新が必要か否か[ 2 ] );

                    if (b更新が必要か否か[ i ])
                    {
                        switch ( i )
                        {
                            case 0:
                                ini.stファイル.ClearCountDrums++;
                                break;
                            case 1:
                                ini.stファイル.ClearCountGuitar++;
                                break;
                            case 2:
                                ini.stファイル.ClearCountBass++;
                                break;
                            default:
                                throw new Exception("クリア回数増加のk(0-2)が範囲外です。");
                        }
                    }
                    //---------------------------------------------------------------------/
				}
                if( CDTXMania.ConfigIni.bScoreIniを出力する )
				    ini.t書き出し( str );
				//---------------------
				#endregion

				#region [ リザルト画面への演奏回数の更新 #24281 2011.1.30 yyagi]
                if( CDTXMania.ConfigIni.bScoreIniを出力する )
                {
                    this.n演奏回数.Drums = ini.stファイル.PlayCountDrums;
                    this.n演奏回数.Guitar = ini.stファイル.PlayCountGuitar;
                    this.n演奏回数.Bass = ini.stファイル.PlayCountBass;
                }
				#endregion
				#region [ 選曲画面の譜面情報の更新 ]
				//---------------------
				if( !CDTXMania.bコンパクトモード )
				{
					Cスコア cスコア = CDTXMania.stage選曲.r確定されたスコア;
					bool[] b更新が必要か否か = new bool[ 3 ];
					CScoreIni.t更新条件を取得する( out b更新が必要か否か[ 0 ], out b更新が必要か否か[ 1 ], out b更新が必要か否か[ 2 ] );
					for( int m = 0; m < 3; m++ )
					{
						if( b更新が必要か否か[ m ] )
						{
							// FullCombo した記録を FullCombo なしで超えた場合、FullCombo マークが消えてしまう。
							// → FullCombo は、最新記録と関係なく、一度達成したらずっとつくようにする。(2010.9.11)
							cスコア.譜面情報.フルコンボ[ m ] = this.st演奏記録[ m ].bフルコンボである | b今までにフルコンボしたことがある[ m ];

							if( this.b新記録スキル[ m ] )
							{
								cスコア.譜面情報.最大スキル[ m ] = this.st演奏記録[ m ].db演奏型スキル値;
		                    }

                            if (this.b新記録ランク[ m ])
                            {
                                cスコア.譜面情報.最大ランク[ m ] = this.nランク値[ m ];
                            }
						}
					}
				}
				//---------------------
				#endregion

				base.On活性化();
			}
			finally
			{
				Trace.TraceInformation( "結果ステージの活性化を完了しました。" );
				Trace.Unindent();
			}
		}
		public override void On非活性化()
		{
			if( this.rResultSound != null )
			{
				CDTXMania.Sound管理.tサウンドを破棄する( this.rResultSound );
				this.rResultSound = null;
			}
			base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if( !base.b活性化してない )
			{
				//this.tx背景 = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\8_background.png" ) );
				//this.tx上部パネル = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\8_header.png" ) );
				//this.tx下部パネル = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\8_footer panel.png" ), true );
				//this.txオプションパネル = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\Screen option panels.png" ) );
				base.OnManagedリソースの作成();
			}
		}
		public override void OnManagedリソースの解放()
		{
			if( !base.b活性化してない )
			{
				if( this.ct登場用 != null )
				{
					this.ct登場用 = null;
				}
				//CDTXMania.tテクスチャの解放( ref this.tx背景 );
				//CDTXMania.tテクスチャの解放( ref this.tx上部パネル );
				//CDTXMania.tテクスチャの解放( ref this.tx下部パネル );
				//CDTXMania.tテクスチャの解放( ref this.txオプションパネル );
				base.OnManagedリソースの解放();
			}
		}
		public override int On進行描画()
		{
			if( !base.b活性化してない )
			{
				int num;
				if( base.b初めての進行描画 )
				{
					this.ct登場用 = new CCounter( 0, 100, 5, CDTXMania.Timer );
					this.actFI.tフェードイン開始();
					base.eフェーズID = CStage.Eフェーズ.共通_フェードイン;
					if( this.rResultSound != null )
					{
						this.rResultSound.t再生を開始する();
					}
					base.b初めての進行描画 = false;
				}
				this.bアニメが完了 = true;
				if( this.ct登場用.b進行中 )
				{
					this.ct登場用.t進行();
					if( this.ct登場用.b終了値に達した )
					{
						this.ct登場用.t停止();
					}
					else
					{
						this.bアニメが完了 = false;
					}
				}

				// 描画

				if(CDTXMania.Tx.Result_Background != null )
				{
                    CDTXMania.Tx.Result_Background.t2D描画( CDTXMania.app.Device, 0, 0 );
				}
				if( this.ct登場用.b進行中 && ( CDTXMania.Tx.Result_Header != null ) )
				{
					double num2 = ( (double) this.ct登場用.n現在の値 ) / 100.0;
					double num3 = Math.Sin( Math.PI / 2 * num2 );
					num = ( (int) ( CDTXMania.Tx.Result_Header.sz画像サイズ.Height * num3 ) ) - CDTXMania.Tx.Result_Header.sz画像サイズ.Height;
				}
				else
				{
					num = 0;
				}
				if(CDTXMania.Tx.Result_Header != null )
				{
                    CDTXMania.Tx.Result_Header.t2D描画( CDTXMania.app.Device, 0, 0 );
				}
                if ( this.actResultImage.On進行描画() == 0 )
				{
					this.bアニメが完了 = false;
				}
				if ( this.actParameterPanel.On進行描画() == 0 )
				{
					this.bアニメが完了 = false;
				}

				if ( this.actSongBar.On進行描画() == 0 )
				{
					this.bアニメが完了 = false;
				}

                #region ネームプレート
                for (int i = 0; i < CDTXMania.ConfigIni.nPlayerCount; i++)
                {
                    if (CDTXMania.Tx.NamePlate[i] != null)
                    {
                        CDTXMania.Tx.NamePlate[i].t2D描画(CDTXMania.app.Device, CDTXMania.Skin.Result_NamePlate_X[i], CDTXMania.Skin.Result_NamePlate_Y[i]);
                    }
                }
                #endregion

                if ( base.eフェーズID == CStage.Eフェーズ.共通_フェードイン )
				{
					if( this.actFI.On進行描画() != 0 )
					{
						base.eフェーズID = CStage.Eフェーズ.共通_通常状態;
					}
				}
				else if( ( base.eフェーズID == CStage.Eフェーズ.共通_フェードアウト ) )			//&& ( this.actFO.On進行描画() != 0 ) )
				{
					return (int) this.eフェードアウト完了時の戻り値;
				}
				#region [ #24609 2011.3.14 yyagi ランク更新or演奏型スキル更新時、リザルト画像をpngで保存する ]
				if ( this.bアニメが完了 == true && this.bIsCheckedWhetherResultScreenShouldSaveOrNot == false	// #24609 2011.3.14 yyagi; to save result screen in case BestRank or HiSkill.
					&& CDTXMania.ConfigIni.bScoreIniを出力する
					&& CDTXMania.ConfigIni.bIsAutoResultCapture)												// #25399 2011.6.9 yyagi
				{
					CheckAndSaveResultScreen(true);
					this.bIsCheckedWhetherResultScreenShouldSaveOrNot = true;
				}
				#endregion

				// キー入力

				if( CDTXMania.act現在入力を占有中のプラグイン == null )
				{
					if( ( ( CDTXMania.Pad.b押されたDGB( Eパッド.CY ) || CDTXMania.Pad.b押された( E楽器パート.DRUMS, Eパッド.RD ) ) || ( CDTXMania.Pad.b押された( E楽器パート.DRUMS, Eパッド.LC ) || CDTXMania.Input管理.Keyboard.bキーが押された( (int)SlimDX.DirectInput.Key.Return ) ) ) && !this.bアニメが完了 )
					{
						this.actFI.tフェードイン完了();					// #25406 2011.6.9 yyagi
						this.actResultImage.tアニメを完了させる();
						this.actParameterPanel.tアニメを完了させる();
						this.actSongBar.tアニメを完了させる();
						this.ct登場用.t停止();
					}
					#region [ #24609 2011.4.7 yyagi リザルト画面で[F12]を押下すると、リザルト画像をpngで保存する機能は、CDTXManiaに移管。 ]
//					if ( CDTXMania.Input管理.Keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.F12 ) &&
//						CDTXMania.ConfigIni.bScoreIniを出力する )
//					{
//						CheckAndSaveResultScreen(false);
//						this.bIsCheckedWhetherResultScreenShouldSaveOrNot = true;
//					}
					#endregion
					if ( base.eフェーズID == CStage.Eフェーズ.共通_通常状態 )
					{
						if ( CDTXMania.Input管理.Keyboard.bキーが押された( (int)SlimDX.DirectInput.Key.Escape ) )
                        {
                            if (!CDTXMania.stage結果.actParameterPanel.b文字アニメ終了)
                            {
                                CDTXMania.stage結果.actParameterPanel.b文字アニメ終了 = true;
                            }
                            else
                            {
                                CDTXMania.Skin.sound取消音.t再生する();
                                this.actFO.tフェードアウト開始();
                                base.eフェーズID = CStage.Eフェーズ.共通_フェードアウト;
                                this.eフェードアウト完了時の戻り値 = E戻り値.完了;
                            }
						}
						if ( ( ( CDTXMania.Pad.b押されたDGB( Eパッド.CY ) || CDTXMania.Pad.b押された( E楽器パート.DRUMS, Eパッド.RD ) ) || ( CDTXMania.Pad.b押された( E楽器パート.DRUMS, Eパッド.LC ) || CDTXMania.Input管理.Keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.Return ) ) ) && this.bアニメが完了 )
                        {
                            if (!CDTXMania.stage結果.actParameterPanel.b文字アニメ終了)
                            {
                                CDTXMania.stage結果.actParameterPanel.b文字アニメ終了 = true;
                            }
                            else
                            {
                                CDTXMania.Skin.sound取消音.t再生する();
                                //							this.actFO.tフェードアウト開始();
                                base.eフェーズID = CStage.Eフェーズ.共通_フェードアウト;
                                this.eフェードアウト完了時の戻り値 = E戻り値.完了;
                            }
						}
					}
				}
			}
			return 0;
		}

		public enum E戻り値 : int
		{
			継続,
			完了
		}


		// その他

		#region [ private ]
		//-----------------
		private CCounter ct登場用;
		private E戻り値 eフェードアウト完了時の戻り値;
		private CActFIFOResult actFI;
		private CActFIFOBlack actFO;
		private CActオプションパネル actOption;
		private CActResultParameterPanel actParameterPanel;
		private CActResultRank actRank;
		private CActResultImage actResultImage;
		private CActResultSongBar actSongBar;
		private bool bアニメが完了;
		private bool bIsCheckedWhetherResultScreenShouldSaveOrNot;				// #24509 2011.3.14 yyagi
		private readonly int[] nチャンネル0Atoレーン07;
		private int n最後に再生したHHのWAV番号;
		private int n最後に再生したHHのチャンネル番号;
		private CSound rResultSound;
		//private CTexture txオプションパネル;
		//private CTexture tx下部パネル;
		//private CTexture tx上部パネル;
		//private CTexture tx背景;

		#region [ #24609 リザルト画像をpngで保存する ]		// #24609 2011.3.14 yyagi; to save result screen in case BestRank or HiSkill.
		/// <summary>
		/// リザルト画像のキャプチャと保存。
		/// 自動保存モード時は、ランク更新or演奏型スキル更新時に自動保存。
		/// 手動保存モード時は、ランクに依らず保存。
		/// </summary>
		/// <param name="bIsAutoSave">true=自動保存モード, false=手動保存モード</param>
		private void CheckAndSaveResultScreen(bool bIsAutoSave)
		{
			string path = Path.GetDirectoryName( CDTXMania.DTX.strファイル名の絶対パス );
			string datetime = DateTime.Now.ToString( "yyyyMMddHHmmss" );
			if ( bIsAutoSave )
			{
				// リザルト画像を自動保存するときは、dtxファイル名.yyMMddHHmmss_DRUMS_SS.png という形式で保存。
				for ( int i = 0; i < 3; i++ )
				{
					if ( this.b新記録ランク[ i ] == true || this.b新記録スキル[ i ] == true )
					{
						string strPart = ( (E楽器パート) ( i ) ).ToString();
						string strRank = ( (CScoreIni.ERANK) ( this.nランク値[ i ] ) ).ToString();
						string strFullPath = CDTXMania.DTX.strファイル名の絶対パス + "." + datetime + "_" + strPart + "_" + strRank + ".png";
						//Surface.ToFile( pSurface, strFullPath, ImageFileFormat.Png );
						CDTXMania.app.SaveResultScreen( strFullPath );
					}
				}
			}
			#region [ #24609 2011.4.11 yyagi; リザルトの手動保存ロジックは、CDTXManiaに移管した。]
//			else
//			{
//				// リザルト画像を手動保存するときは、dtxファイル名.yyMMddHHmmss_SS.png という形式で保存。(楽器名無し)
//				string strRank = ( (CScoreIni.ERANK) ( CDTXMania.stage結果.n総合ランク値 ) ).ToString();
//				string strSavePath = CDTXMania.strEXEのあるフォルダ + "\\" + "Capture_img";
//				if ( !Directory.Exists( strSavePath ) )
//				{
//					try
//					{
//						Directory.CreateDirectory( strSavePath );
//					}
//					catch
//					{
//					}
//				}
//				string strFullPath = strSavePath + "\\" + CDTXMania.DTX.TITLE +
//					"." + datetime + "_" + strRank + ".png";
//				// Surface.ToFile( pSurface, strFullPath, ImageFileFormat.Png );
//				CDTXMania.app.SaveResultScreen( strFullPath );
//			}
			#endregion
		}
		#endregion
		//-----------------
		#endregion
	}
}

