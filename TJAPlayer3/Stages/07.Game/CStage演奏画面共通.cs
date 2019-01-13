using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;
using FDK;
using FDK.ExtensionMethods;
using TJAPlayer3;

namespace TJAPlayer3
{
	/// <summary>
	/// 演奏画面の共通クラス (ドラム演奏画面, ギター演奏画面の継承元)
	/// </summary>
	internal abstract class CStage演奏画面共通 : CStage
	{
		// プロパティ

		public bool bAUTOでないチップが１つでもバーを通過した	// 誰も参照していない？？
		{
			get;
			protected set;
		}

		// メソッド

		#region [ t演奏結果を格納する_ドラム() ]
		public void t演奏結果を格納する_ドラム( out CScoreIni.C演奏記録 Drums )
		{
			Drums = new CScoreIni.C演奏記録();

			//if (  )
			{
				Drums.nスコア = (long) this.actScore.Get( E楽器パート.DRUMS, 0 );
				Drums.dbゲーム型スキル値 = CScoreIni.tゲーム型スキルを計算して返す( TJAPlayer3.DTX.LEVEL.Drums, TJAPlayer3.DTX.n可視チップ数.Drums, this.nヒット数_Auto含まない.Drums.Perfect, this.actCombo.n現在のコンボ数.P1最高値, E楽器パート.DRUMS, bIsAutoPlay );
				Drums.db演奏型スキル値 = CScoreIni.t演奏型スキルを計算して返す( TJAPlayer3.DTX.n可視チップ数.Drums, this.nヒット数_Auto含まない.Drums.Perfect, this.nヒット数_Auto含まない.Drums.Great, this.nヒット数_Auto含まない.Drums.Good, this.nヒット数_Auto含まない.Drums.Poor, this.nヒット数_Auto含まない.Drums.Miss, E楽器パート.DRUMS, bIsAutoPlay );
				Drums.nPerfect数 = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay ? this.nヒット数_Auto含む.Drums.Perfect : this.nヒット数_Auto含まない.Drums.Perfect;
				Drums.nGreat数 = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay ? this.nヒット数_Auto含む.Drums.Great : this.nヒット数_Auto含まない.Drums.Great;
				Drums.nGood数 = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay ? this.nヒット数_Auto含む.Drums.Good : this.nヒット数_Auto含まない.Drums.Good;
				Drums.nPoor数 = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay ? this.nヒット数_Auto含む.Drums.Poor : this.nヒット数_Auto含まない.Drums.Poor;
				Drums.nMiss数 = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay ? this.nヒット数_Auto含む.Drums.Miss : this.nヒット数_Auto含まない.Drums.Miss;
				Drums.nPerfect数_Auto含まない = this.nヒット数_Auto含まない.Drums.Perfect;
				Drums.nGreat数_Auto含まない = this.nヒット数_Auto含まない.Drums.Great;
				Drums.nGood数_Auto含まない = this.nヒット数_Auto含まない.Drums.Good;
				Drums.nPoor数_Auto含まない = this.nヒット数_Auto含まない.Drums.Poor;
				Drums.nMiss数_Auto含まない = this.nヒット数_Auto含まない.Drums.Miss;
                Drums.n連打数 = this.n合計連打数[ 0 ];
				Drums.n最大コンボ数 = this.actCombo.n現在のコンボ数.P1最高値;
				Drums.n全チップ数 = TJAPlayer3.DTX.n可視チップ数.Drums;
				for ( int i = 0; i < (int) Eレーン.MAX;  i++ )
				{
					Drums.bAutoPlay[ i ] = bIsAutoPlay[ i ];
				}
				Drums.bTight = TJAPlayer3.ConfigIni.bTight;
				for ( int i = 0; i < 3; i++ )
				{
					Drums.bSudden[ i ] = TJAPlayer3.ConfigIni.bSudden[ i ];
					Drums.bHidden[ i ] = TJAPlayer3.ConfigIni.bHidden[ i ];
					Drums.eInvisible[ i ] = TJAPlayer3.ConfigIni.eInvisible[ i ];
					Drums.bReverse[ i ] = TJAPlayer3.ConfigIni.bReverse[ i ];
					Drums.eRandom[ i ] = TJAPlayer3.ConfigIni.eRandom[ i ];
					Drums.bLight[ i ] = TJAPlayer3.ConfigIni.bLight[ i ];
					Drums.bLeft[ i ] = TJAPlayer3.ConfigIni.bLeft[ i ];
					Drums.f譜面スクロール速度[ i ] = ( (float) ( TJAPlayer3.ConfigIni.n譜面スクロール速度[ i ] + 1 ) ) * 0.5f;
				}
				Drums.eDark = TJAPlayer3.ConfigIni.eDark;
				Drums.n演奏速度分子 = TJAPlayer3.ConfigIni.n演奏速度;
				Drums.n演奏速度分母 = 20;
				Drums.bSTAGEFAILED有効 = TJAPlayer3.ConfigIni.bSTAGEFAILED有効;
				Drums.eダメージレベル = TJAPlayer3.ConfigIni.eダメージレベル;
				Drums.b演奏にキーボードを使用した = this.b演奏にキーボードを使った.Drums;
				Drums.b演奏にMIDI入力を使用した = this.b演奏にMIDI入力を使った.Drums;
				Drums.b演奏にジョイパッドを使用した = this.b演奏にジョイパッドを使った.Drums;
				Drums.b演奏にマウスを使用した = this.b演奏にマウスを使った.Drums;
				Drums.nPerfectになる範囲ms = TJAPlayer3.nPerfect範囲ms;
				Drums.nGreatになる範囲ms = TJAPlayer3.nGreat範囲ms;
				Drums.nGoodになる範囲ms = TJAPlayer3.nGood範囲ms;
				Drums.nPoorになる範囲ms = TJAPlayer3.nPoor範囲ms;
				Drums.strDTXManiaのバージョン = TJAPlayer3.VERSION;
				Drums.最終更新日時 = DateTime.Now.ToString();
				Drums.Hash = CScoreIni.t演奏セクションのMD5を求めて返す( Drums );
                Drums.fゲージ = (float)this.actGauge.db現在のゲージ値[ 0 ];
                if( !TJAPlayer3.ConfigIni.b太鼓パートAutoPlay )
                {
                    Drums.nハイスコア = TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.nハイスコア; //2015.06.16 kairera0467 他難易度の上書き防止。
                    if( TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.nハイスコア[ TJAPlayer3.stage選曲.nSeelectedCource[0]] < (int)this.actScore.Get( E楽器パート.DRUMS, 0 ) )
                        Drums.nハイスコア[ TJAPlayer3.stage選曲.nSeelectedCource[0]] = (int)this.actScore.Get( E楽器パート.DRUMS, 0 );
                }
                var danC = TJAPlayer3.stage演奏ドラム画面.actDan.GetExam();
                for (int i = 0; i < danC.Length; i++)
                {
                    Drums.Dan_C[i] = danC[i];
                }
			}
		}
		#endregion
		#region [ t演奏結果を格納する_太鼓() ]
		public void t演奏結果を格納する_太鼓( out CScoreIni.C演奏記録 Drums )
		{
			Drums = new CScoreIni.C演奏記録();

			//if ( CDTXMania.DTX.bチップがある.Drums )
			{
				Drums.nスコア = (long) this.actScore.Get( E楽器パート.DRUMS, 0 );
				Drums.dbゲーム型スキル値 = CScoreIni.tゲーム型スキルを計算して返す( TJAPlayer3.DTX.LEVEL.Drums, TJAPlayer3.DTX.n可視チップ数.Drums, this.nヒット数_Auto含まない.Drums.Perfect, this.actCombo.n現在のコンボ数.P2, E楽器パート.DRUMS, bIsAutoPlay );
				Drums.db演奏型スキル値 = CScoreIni.t演奏型スキルを計算して返す( TJAPlayer3.DTX.n可視チップ数.Drums, this.nヒット数_Auto含まない.Drums.Perfect, this.nヒット数_Auto含まない.Drums.Great, this.nヒット数_Auto含まない.Drums.Good, this.nヒット数_Auto含まない.Drums.Poor, this.nヒット数_Auto含まない.Drums.Miss, E楽器パート.DRUMS, bIsAutoPlay );
				Drums.nPerfect数 = this.nヒット数_Auto含まない.Taiko.Perfect;
				Drums.nGreat数 = this.nヒット数_Auto含まない.Taiko.Great;
				Drums.nGood数 = this.nヒット数_Auto含まない.Taiko.Good;
				Drums.nPoor数 = this.nヒット数_Auto含まない.Taiko.Poor;
				Drums.nMiss数 = this.nヒット数_Auto含まない.Taiko.Miss;
				Drums.nPerfect数_Auto含まない = this.nヒット数_Auto含まない.Taiko.Perfect;
				Drums.nGreat数_Auto含まない = this.nヒット数_Auto含まない.Taiko.Great;
				Drums.nGood数_Auto含まない = this.nヒット数_Auto含まない.Taiko.Good;
				Drums.nPoor数_Auto含まない = this.nヒット数_Auto含まない.Taiko.Poor;
				Drums.nMiss数_Auto含まない = this.nヒット数_Auto含まない.Taiko.Miss;
                Drums.n連打数 = this.n合計連打数[ 0 ];
				Drums.n最大コンボ数 = this.actCombo.n現在のコンボ数.P2;
				Drums.n全チップ数 = TJAPlayer3.DTX.nノーツ数[ 3 ];
				for ( int i = 0; i < (int) Eレーン.MAX;  i++ )
				{
					Drums.bAutoPlay[ i ] = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay;
				}
				Drums.bTight = TJAPlayer3.ConfigIni.bTight;
				for ( int i = 0; i < 3; i++ )
				{
					Drums.bSudden[ i ] = TJAPlayer3.ConfigIni.bSudden[ i ];
					Drums.bHidden[ i ] = TJAPlayer3.ConfigIni.bHidden[ i ];
					Drums.eInvisible[ i ] = TJAPlayer3.ConfigIni.eInvisible[ i ];
					Drums.bReverse[ i ] = TJAPlayer3.ConfigIni.bReverse[ i ];
					Drums.eRandom[ i ] = TJAPlayer3.ConfigIni.eRandom[ i ];
					Drums.bLight[ i ] = TJAPlayer3.ConfigIni.bLight[ i ];
					Drums.bLeft[ i ] = TJAPlayer3.ConfigIni.bLeft[ i ];
					Drums.f譜面スクロール速度[ i ] = ( (float) ( TJAPlayer3.ConfigIni.n譜面スクロール速度[ i ] + 1 ) ) * 0.5f;
				}
				Drums.eDark = TJAPlayer3.ConfigIni.eDark;
				Drums.n演奏速度分子 = TJAPlayer3.ConfigIni.n演奏速度;
				Drums.n演奏速度分母 = 20;
				Drums.bSTAGEFAILED有効 = TJAPlayer3.ConfigIni.bSTAGEFAILED有効;
				Drums.eダメージレベル = TJAPlayer3.ConfigIni.eダメージレベル;
				Drums.b演奏にキーボードを使用した = this.b演奏にキーボードを使った.Drums;
				Drums.b演奏にMIDI入力を使用した = this.b演奏にMIDI入力を使った.Drums;
				Drums.b演奏にジョイパッドを使用した = this.b演奏にジョイパッドを使った.Drums;
				Drums.b演奏にマウスを使用した = this.b演奏にマウスを使った.Drums;
				Drums.nPerfectになる範囲ms = TJAPlayer3.nPerfect範囲ms;
				Drums.nGreatになる範囲ms = TJAPlayer3.nGreat範囲ms;
				Drums.nGoodになる範囲ms = TJAPlayer3.nGood範囲ms;
				Drums.nPoorになる範囲ms = TJAPlayer3.nPoor範囲ms;
				Drums.strDTXManiaのバージョン = TJAPlayer3.VERSION;
				Drums.最終更新日時 = DateTime.Now.ToString();
				Drums.Hash = CScoreIni.t演奏セクションのMD5を求めて返す( Drums );
                Drums.fゲージ = (float)this.actGauge.db現在のゲージ値[ 0 ];
			}
		}
		#endregion

		// CStage 実装

		public override void On活性化()
		{
            listChip = new List<CDTX.CChip>[ 4 ];
            for( int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++ )
            {
                switch( i )
                {
                    case 0:
			            listChip[i] = TJAPlayer3.DTX.listChip;
                        break;
                    case 1:
			            listChip[i] = TJAPlayer3.DTX_2P.listChip;
                        break;
                }

                int n整数値管理 = 0;
                foreach( CDTX.CChip chip in listChip[ i ] )
                {
                    chip.nList上の位置 = n整数値管理;
                    if( ( chip.nチャンネル番号 == 0x15 || chip.nチャンネル番号 == 0x16 ) && ( n整数値管理 < this.listChip[ i ].Count - 1 ) )
                    {
                        if( chip.db発声時刻ms < this.r指定時刻に一番近い未ヒットChipを過去方向優先で検索する( 0, i ).db発声時刻ms)
                        {
                            chip.n描画優先度 = 1;
                        }
                    }
                    n整数値管理++;
                }
            }

            this.ct制御タイマ = new CCounter();
            ctChipAnime = new CCounter[2];
            ctChipAnimeLag = new CCounter[2];
            for (int i = 0; i < 2; i++)
            {
                ctChipAnime[i] = new CCounter();
                ctChipAnimeLag[i] = new CCounter();
            }

            listWAV = TJAPlayer3.DTX.listWAV;

			this.eフェードアウト完了時の戻り値 = E演奏画面の戻り値.継続;
			this.n現在のトップChip = ( listChip[0].Count > 0 ) ? 0 : -1;
			this.L最後に再生したHHの実WAV番号 = new List<int>( 16 );
			this.n最後に再生したHHのチャンネル番号 = 0;
			this.n最後に再生した実WAV番号.Guitar = -1;
			this.n最後に再生した実WAV番号.Bass = -1;
			for ( int i = 0; i < 50; i++ )
			{
				this.n最後に再生したBGMの実WAV番号[ i ] = -1;
			}

			cInvisibleChip = new CInvisibleChip( TJAPlayer3.ConfigIni.nDisplayTimesMs, TJAPlayer3.ConfigIni.nFadeoutTimeMs );
			this.演奏判定ライン座標 = new C演奏判定ライン座標共通();
			for ( int k = 0; k < 4; k++ )
			{
				//for ( int n = 0; n < 5; n++ )
				//{
					this.nヒット数_Auto含まない[ k ] = new CHITCOUNTOFRANK();
					this.nヒット数_Auto含む[ k ] = new CHITCOUNTOFRANK();
				//}
				this.queWailing[ k ] = new Queue<CDTX.CChip>();
				this.r現在の歓声Chip[ k ] = null;
				cInvisibleChip.eInvisibleMode[ k ] = TJAPlayer3.ConfigIni.eInvisible[ k ];
				if ( TJAPlayer3.DTXVmode.Enabled )
				{
					TJAPlayer3.ConfigIni.n譜面スクロール速度[ k ] = TJAPlayer3.ConfigIni.nViewerScrollSpeed[ k ];
				}

				//this.nJudgeLinePosY_delta[ k ] = CDTXMania.ConfigIni.nJudgeLinePosOffset[ k ];		// #31602 2013.6.23 yyagi

				this.演奏判定ライン座標.n判定位置[ k ] = TJAPlayer3.ConfigIni.e判定位置[ k ];
				this.演奏判定ライン座標.nJudgeLinePosY_delta[ k ] = TJAPlayer3.ConfigIni.nJudgeLinePosOffset[ k ];
				this.bReverse[ k ]             = TJAPlayer3.ConfigIni.bReverse[ k ];					//

			}
			actCombo.演奏判定ライン座標 = 演奏判定ライン座標;
			for ( int i = 0; i < 3; i++ )
			{
				this.b演奏にキーボードを使った[ i ] = false;
				this.b演奏にジョイパッドを使った[ i ] = false;
				this.b演奏にMIDI入力を使った[ i ] = false;
				this.b演奏にマウスを使った[ i ] = false;
			}
			this.bAUTOでないチップが１つでもバーを通過した = false;
			cInvisibleChip.Reset();
			base.On活性化();
			this.tステータスパネルの選択();
			this.tパネル文字列の設定();
			//this.演奏判定ライン座標();
            this.bIsGOGOTIME = new bool[]{ false, false, false, false };
            this.bUseBranch = new bool[]{ false, false, false, false };
            this.n現在のコース = new int[ 4 ];
            this.n次回のコース = new int[ 4 ];
            this.b連打中 = new bool[]{ false, false, false, false };
            this.n現在の連打数 = new int[]{ 0, 0, 0, 0 };
            this.n合計連打数 = new int[]{ 0, 0, 0, 0 };
            this.n分岐した回数 = new int[ 4 ];
            this.n表示した歌詞 = 0;
            this.nJPOSSCROLL = new int[ 4 ];
            this.bLEVELHOLD = new bool[]{ false, false, false, false };

            this.bDoublePlay = TJAPlayer3.ConfigIni.nPlayerCount >= 2 ? true : false;

            this.nLoopCount_Clear = 1;

            #region[ branch ]
            this.nBranch_Perfect = new int[]{ 0, 0, 0, 0 };
            this.nBranch_Good = new int[]{ 0, 0, 0, 0 };
            this.nBranch_Miss = new int[]{ 0, 0, 0, 0 };
            this.nBranch_roll = new int[]{ 0, 0, 0, 0 };
            #endregion

            this.bIsAutoPlay = TJAPlayer3.ConfigIni.bAutoPlay;									// #24239 2011.1.23 yyagi

			
			//this.bIsAutoPlay.Guitar = CDTXMania.ConfigIni.bギターが全部オートプレイである;
			//this.bIsAutoPlay.Bass = CDTXMania.ConfigIni.bベースが全部オートプレイである;
//			this.nRisky = CDTXMania.ConfigIni.nRisky;											// #23559 2011.7.28 yyagi
			actGauge.Init( TJAPlayer3.ConfigIni.nRisky );									// #23559 2011.7.28 yyagi
			this.nPolyphonicSounds = TJAPlayer3.ConfigIni.nPoliphonicSounds;
			e判定表示優先度 = TJAPlayer3.ConfigIni.e判定表示優先度;

			TJAPlayer3.Skin.tRemoveMixerAll();	// 効果音のストリームをミキサーから解除しておく

			queueMixerSound = new Queue<stmixer>( 64 );
			bIsDirectSound = ( TJAPlayer3.Sound管理.GetCurrentSoundDeviceType() == "DirectSound" );
			bUseOSTimer = TJAPlayer3.ConfigIni.bUseOSTimer;
			this.bPAUSE = false;
			if ( TJAPlayer3.DTXVmode.Enabled )
			{
				db再生速度 = TJAPlayer3.DTX.dbDTXVPlaySpeed;
				TJAPlayer3.ConfigIni.n演奏速度 = (int) (TJAPlayer3.DTX.dbDTXVPlaySpeed * 20 + 0.5 );
			}
			else
			{
				db再生速度 = ( (double) TJAPlayer3.ConfigIni.n演奏速度 ) / 20.0;
			}
			bValidScore = ( TJAPlayer3.DTXVmode.Enabled ) ? false : true;

			#region [ 演奏開始前にmixer登録しておくべきサウンド(開幕してすぐに鳴らすことになるチップ音)を登録しておく ]
			foreach ( CDTX.CChip pChip in listChip[0] )
			{
//				Debug.WriteLine( "CH=" + pChip.nチャンネル番号.ToString( "x2" ) + ", 整数値=" + pChip.n整数値 +  ", time=" + pChip.n発声時刻ms );
				if ( pChip.n発声時刻ms <= 0 )
				{
					if ( pChip.nチャンネル番号 == 0xDA )
					{
						pChip.bHit = true;
//						Trace.TraceInformation( "first [DA] BAR=" + pChip.n発声位置 / 384 + " ch=" + pChip.nチャンネル番号.ToString( "x2" ) + ", wav=" + pChip.n整数値 + ", time=" + pChip.n発声時刻ms );
						if ( listWAV.TryGetValue( pChip.n整数値_内部番号, out CDTX.CWAV wc ) )
						{
							for ( int i = 0; i < nPolyphonicSounds; i++ )
							{
								if ( wc.rSound[ i ] != null )
								{
									TJAPlayer3.Sound管理.AddMixer( wc.rSound[ i ], db再生速度, pChip.b演奏終了後も再生が続くチップである );
									//AddMixer( wc.rSound[ i ] );		// 最初はqueueを介さず直接ミキサー登録する
								}
							}
						}
					}
				}
				else
				{
					break;
				}
			}
			#endregion

			this.sw = new Stopwatch();
			//          this.sw2 = new Stopwatch();
            //			this.gclatencymode = GCSettings.LatencyMode;
            //			GCSettings.LatencyMode = GCLatencyMode.Batch;	// 演奏画面中はGCを抑止する
            this.bIsAlreadyCleared = new bool[2];
            this.bIsAlreadyMaxed = new bool[2];

            this.ListDan_Number = 0;
            this.IsDanFailed = false;
		}
		public override void On非活性化()
		{
			this.L最後に再生したHHの実WAV番号.Clear();	// #23921 2011.1.4 yyagi
			this.L最後に再生したHHの実WAV番号 = null;	//
			this.ctチップ模様アニメ.Drums = null;
			this.ctチップ模様アニメ.Guitar = null;
			this.ctチップ模様アニメ.Bass = null;
			this.ctチップ模様アニメ.Taiko = null;

            for (int i = 0; i < 2; i++)
            {
                ctChipAnime[i] = null;
                ctChipAnimeLag[i] = null;
            }

            this.ct制御タイマ = null;
			listWAV.Clear();
			listWAV = null;
            listChip = null;
			queueMixerSound.Clear();
			queueMixerSound = null;
			cInvisibleChip.Dispose();
			cInvisibleChip = null;
//			GCSettings.LatencyMode = this.gclatencymode;

			var meanLag = CLagLogger.LogAndReturnMeanLag();

			if (TJAPlayer3.IsPerformingCalibration && meanLag != null)
			{
			    var oldInputAdjustTimeMs = TJAPlayer3.ConfigIni.nInputAdjustTimeMs;
			    var newInputAdjustTimeMs = oldInputAdjustTimeMs - (int) Math.Round(meanLag.Value);
			    Trace.TraceInformation($"Calibration complete. Updating InputAdjustTime from {oldInputAdjustTimeMs}ms to {newInputAdjustTimeMs}ms.");
			    TJAPlayer3.ConfigIni.nInputAdjustTimeMs = newInputAdjustTimeMs;
			}

			base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if ( !base.b活性化してない )
			{
				this.t背景テクスチャの生成();
				base.OnManagedリソースの作成();
			}
		}
		public override void OnManagedリソースの解放()
		{
			if ( !base.b活性化してない )
			{
				TJAPlayer3.tテクスチャの解放( ref this.tx背景 );
                Trace.TraceInformation("CStage演奏画面共通 リソースの開放");
                base.OnManagedリソースの解放();
			}
		}

		// その他

		#region [ protected ]
		//-----------------
		public class CHITCOUNTOFRANK
		{
			// Fields
			public int Good;
			public int Great;
			public int Miss;
			public int Perfect;
			public int Poor;

			// Properties
			public int this[ int index ]
			{
				get
				{
					switch ( index )
					{
						case 0:
							return this.Perfect;

						case 1:
							return this.Great;

						case 2:
							return this.Good;

						case 3:
							return this.Poor;

						case 4:
							return this.Miss;
					}
					throw new IndexOutOfRangeException();
				}
				set
				{
					switch ( index )
					{
						case 0:
							this.Perfect = value;
							return;

						case 1:
							this.Great = value;
							return;

						case 2:
							this.Good = value;
							return;

						case 3:
							this.Poor = value;
							return;

						case 4:
							this.Miss = value;
							return;
					}
					throw new IndexOutOfRangeException();
				}
			}
		}

		[StructLayout( LayoutKind.Sequential )]
		protected struct STKARAUCHI
		{
			public CDTX.CChip HH;
			public CDTX.CChip SD;
			public CDTX.CChip BD;
			public CDTX.CChip HT;
			public CDTX.CChip LT;
			public CDTX.CChip FT;
			public CDTX.CChip CY;
			public CDTX.CChip HHO;
			public CDTX.CChip RD;
			public CDTX.CChip LC;
            public CDTX.CChip LP;
            public CDTX.CChip LBD;
			public CDTX.CChip this[ int index ]
			{
				get
				{
					switch ( index )
					{
						case 0:
							return this.HH;

						case 1:
							return this.SD;

						case 2:
							return this.BD;

						case 3:
							return this.HT;

						case 4:
							return this.LT;

						case 5:
							return this.FT;

						case 6:
							return this.CY;

						case 7:
							return this.HHO;

						case 8:
							return this.RD;

						case 9:
							return this.LC;

                        case 10:
                            return this.LP;

                        case 11:
                            return this.LBD;
					}
					throw new IndexOutOfRangeException();
				}
				set
				{
					switch ( index )
					{
						case 0:
							this.HH = value;
							return;

						case 1:
							this.SD = value;
							return;

						case 2:
							this.BD = value;
							return;

						case 3:
							this.HT = value;
							return;

						case 4:
							this.LT = value;
							return;

						case 5:
							this.FT = value;
							return;

						case 6:
							this.CY = value;
							return;

						case 7:
							this.HHO = value;
							return;

						case 8:
							this.RD = value;
							return;

						case 9:
							this.LC = value;
							return;

                        case 10:
                            this.LP = value;
                            return;
					}
					throw new IndexOutOfRangeException();
				}
			}
		}

		protected struct stmixer
		{
			internal bool bIsAdd;
			internal CSound csound;
			internal bool b演奏終了後も再生が続くチップである;
		};

		public CAct演奏AVI actAVI;
        public Rainbow Rainbow;
		protected CAct演奏チップファイアGB actChipFireGB;
		public CAct演奏Combo共通 actCombo;
		protected CAct演奏Danger共通 actDANGER;
		//protected CActFIFOBlack actFI;
        protected CActFIFOStart actFI;
		protected CActFIFOBlack actFO;
		protected CActFIFOResult actFOClear;
		public    CAct演奏ゲージ共通 actGauge;

        public CAct演奏DrumsDancer actDancer;
		protected CAct演奏判定文字列共通 actJudgeString;
		public TaikoLaneFlash actTaikoLaneFlash;
		protected CAct演奏レーンフラッシュGB共通 actLaneFlushGB;
		public CAct演奏パネル文字列 actPanel;
		public CAct演奏演奏情報 actPlayInfo;
		public CAct演奏スコア共通 actScore;
		public CAct演奏ステージ失敗 actStageFailed;
		protected CAct演奏ステータスパネル共通 actStatusPanels;
		protected CAct演奏スクロール速度 act譜面スクロール速度;
		public    C演奏判定ライン座標共通 演奏判定ライン座標;
        protected CAct演奏Drums連打 actRoll;
        protected CAct演奏Drums風船 actBalloon;
        public CAct演奏Drumsキャラクター actChara;
        protected CAct演奏Drums連打キャラ actRollChara;
        protected CAct演奏Drumsコンボ吹き出し actComboBalloon;
        protected CAct演奏Combo音声 actComboVoice;
        protected CAct演奏PauseMenu actPauseMenu;
        public CAct演奏Drumsチップエフェクト actChipEffects;
        public CAct演奏DrumsFooter actFooter;
        public CAct演奏DrumsRunner actRunner;
        public CAct演奏DrumsMob actMob;
        public Dan_Cert actDan;
		public bool bPAUSE;
        public bool[] bIsAlreadyCleared;
        public bool[] bIsAlreadyMaxed;
		protected STDGBVALUE<bool> b演奏にMIDI入力を使った;
		protected STDGBVALUE<bool> b演奏にキーボードを使った;
		protected STDGBVALUE<bool> b演奏にジョイパッドを使った;
		protected STDGBVALUE<bool> b演奏にマウスを使った;
		protected STDGBVALUE<CCounter> ctチップ模様アニメ;
        public CCounter[] ctChipAnime;
        public CCounter[] ctChipAnimeLag;

		protected E演奏画面の戻り値 eフェードアウト完了時の戻り値;
        protected readonly int[] nチャンネル0Atoパッド08 = new int[] { 1, 2, 3, 4, 5, 7, 6, 1, 8, 0, 9, 9 };
        protected readonly int[] nチャンネル0Atoレーン07 = new int[] { 1, 2, 3, 4, 5, 7, 6, 1, 9, 0, 8, 8 };
                                                                    //                         RD LC  LP  RD
		protected readonly int[] nパッド0Atoチャンネル0A = new int[] { 0x11, 0x12, 0x13, 0x14, 0x15, 0x17, 0x16, 0x18, 0x19, 0x1a, 0x1b, 0x1c };
        protected readonly int[] nパッド0Atoパッド08 = new int[] { 1, 2, 3, 4, 5, 6, 7, 1, 8, 0, 9, 9 };// パッド画像のヒット処理用
                                                              //   HH SD BD HT LT FT CY HHO RD LC LP LBD
        protected readonly int[] nパッド0Atoレーン07 = new int[] { 1, 2, 3, 4, 5, 6, 7, 1, 9, 0, 8, 8 };
		public STDGBVALUE<CHITCOUNTOFRANK> nヒット数_Auto含まない;
		public STDGBVALUE<CHITCOUNTOFRANK> nヒット数_Auto含む;
		protected int n現在のトップChip = -1;
		protected int[] n最後に再生したBGMの実WAV番号 = new int[ 50 ];
		protected int n最後に再生したHHのチャンネル番号;
		protected List<int> L最後に再生したHHの実WAV番号;		// #23921 2011.1.4 yyagi: change "int" to "List<int>", for recording multiple wav No.
		protected STLANEVALUE<int> n最後に再生した実WAV番号;	// #26388 2011.11.8 yyagi: change "n最後に再生した実WAV番号.GUITAR" and "n最後に再生した実WAV番号.BASS"
																//							into "n最後に再生した実WAV番号";
//		protected int n最後に再生した実WAV番号.GUITAR;
//		protected int n最後に再生した実WAV番号.BASS;

		protected volatile Queue<stmixer> queueMixerSound;		// #24820 2013.1.21 yyagi まずは単純にAdd/Removeを1個のキューでまとめて管理するやり方で設計する
		protected DateTime dtLastQueueOperation;				//
		protected bool bIsDirectSound;							//
		protected double db再生速度;
		protected bool bValidScore;
//		protected bool bDTXVmode;
//		protected STDGBVALUE<int> nJudgeLinePosY_delta;			// #31602 2013.6.23 yyagi 表示遅延対策として、判定ラインの表示位置をずらす機能を追加する
		protected STDGBVALUE<bool> bReverse;

		protected STDGBVALUE<Queue<CDTX.CChip>> queWailing;
		protected STDGBVALUE<CDTX.CChip> r現在の歓声Chip;
		protected CTexture txチップ;
		protected CTexture txヒットバー;

		protected CTexture tx背景;

		protected STAUTOPLAY bIsAutoPlay;		// #24239 2011.1.23 yyagi
//		protected int nRisky_InitialVar, nRiskyTime;		// #23559 2011.7.28 yyagi → CAct演奏ゲージ共通クラスに隠蔽
		protected int nPolyphonicSounds;
		protected List<CDTX.CChip>[] listChip = new List<CDTX.CChip>[4];
		protected Dictionary<int, CDTX.CWAV> listWAV;
		protected CInvisibleChip cInvisibleChip;
		protected bool bUseOSTimer;
		protected E判定表示優先度 e判定表示優先度;

        public bool[] bIsGOGOTIME = new bool[ 4 ];
        public bool[] bUseBranch = new bool[ 4 ];
        public int[] n現在のコース = new int[ 4 ]; //0:普通譜面 1:玄人譜面 2:達人譜面
        public int[] n次回のコース = new int[ 4 ];
        protected bool[] b譜面分岐中 = new bool[] { false, false, false, false };
        protected int[] n分岐した回数 = new int[ 4 ];
        protected int[] nJPOSSCROLL = new int[ 4 ];

        private bool[] b強制的に分岐させた = new bool[] { false, false, false, false };
        private bool[] bLEVELHOLD = new bool[] { false, false, false, false };
        protected int[] nBranch_roll = new int[ 4 ];
        protected int[] nBranch_Perfect = new int[ 4 ];
        protected int[] nBranch_Good = new int[ 4 ];
        protected int[] nBranch_Miss = new int[ 4 ];
        protected int nListCount;

        private int n表示した歌詞 = 0;

        public bool[] b連打中 = new bool[]{ false, false, false, false }; //奥の手
        private int[] n合計連打数 = new int[ 4 ];
        protected int[] n風船残り = new int[ 4 ];
        protected int[] n現在の連打数 = new int[ 4 ];
        protected E連打State eRollState;

        public CCounter ct制御タイマ;

        protected int nタイマ番号;
        protected int n現在の音符の顔番号;

        protected int nWaitButton;
        

        protected CDTX.CChip[] chip現在処理中の連打チップ = new CDTX.CChip[ 4 ];

        protected const int NOTE_GAP = 25;
        
        public int nLoopCount_Clear;

        //Type-Bの場合
        //0:1～9
        //1:10～19
        //2:20～29
        //3:
        //4:
        //5:
        //6:
        //7:
        //8:
        //9:
        //10:100以降
        //
        //Type-Cの場合
        //0:1～9
        //1:10～29
        //2:30～49
        //3:50～99
        //4:100以降
        //5～9:使用しない
        //
        //Type-Aの場合は使いません。
        protected int[] nScore = new int[11];

        protected int[] nHand = new int[4];

        protected CSound soundRed;
        protected CSound soundBlue;
        protected CSound soundAdlib;



        public bool bDoublePlay; // 2016.08.21 kairera0467 表示だけ。

		protected Stopwatch sw;		// 2011.6.13 最適化検討用のストップウォッチ
//		protected Stopwatch sw2;
//		protected GCLatencyMode gclatencymode;

        public struct STBranchStatus
        {
            public int nBranch_Perfect;
            public int nBranch_Good;
            public int nBranch_Miss;
            public int nBranch_Roll;
            public bool b強制的に分岐させた;
            public bool bLEVELHOLD;
            public bool bUseBranch;
            public int n現在のコース; //0:普通譜面 1:玄人譜面 2:達人譜面
            public int n次回のコース;
            public bool b譜面分岐中;
            public int n分岐した回数;
        }

        //
        private System.Timers.Timer combot;
        //

        private int ListDan_Number;
        private bool IsDanFailed;

		public void AddMixer( CSound cs, bool _b演奏終了後も再生が続くチップである )
		{
			stmixer stm = new stmixer()
			{
				bIsAdd = true,
				csound = cs,
				b演奏終了後も再生が続くチップである = _b演奏終了後も再生が続くチップである
			};
			queueMixerSound.Enqueue( stm );
//		Debug.WriteLine( "★Queue: add " + Path.GetFileName( stm.csound.strファイル名 ));
		}
		public void RemoveMixer( CSound cs )
		{
			stmixer stm = new stmixer()
			{
				bIsAdd = false,
				csound = cs,
				b演奏終了後も再生が続くチップである = false
			};
			queueMixerSound.Enqueue( stm );
//		Debug.WriteLine( "★Queue: remove " + Path.GetFileName( stm.csound.strファイル名 ));
		}
		public void ManageMixerQueue()
		{
			// もしサウンドの登録/削除が必要なら、実行する
			if ( queueMixerSound.Count > 0 )
			{
				//Debug.WriteLine( "☆queueLength=" + queueMixerSound.Count );
				DateTime dtnow = DateTime.Now;
				TimeSpan ts = dtnow - dtLastQueueOperation;
				if ( ts.Milliseconds > 7 )
				{
					for ( int i = 0; i < 2 && queueMixerSound.Count > 0; i++ )
					{
						dtLastQueueOperation = dtnow;
						stmixer stm = queueMixerSound.Dequeue();
						if ( stm.bIsAdd )
						{
							TJAPlayer3.Sound管理.AddMixer( stm.csound, db再生速度, stm.b演奏終了後も再生が続くチップである );
						}
						else
						{
							TJAPlayer3.Sound管理.RemoveMixer( stm.csound );
						}
					}
				}
			}
		}

	    internal E判定 e指定時刻からChipのJUDGEを返す(long nTime, CDTX.CChip pChip)
	    {
	        var e判定 = e指定時刻からChipのJUDGEを返すImpl(nTime, pChip);

	        // When performing calibration, reduce audio distraction from user input.
	        // For users who play primarily by watching notes cross the judgment position,
	        // you might think that we want them to see visual judgment feedback during
	        // calibration, but we do not. Humans are remarkably good at adjusting
	        // the timing of their own physical movement, even without realizing it.
	        // We are calibrating their input timing for the purposes of judgment.
	        // We do not want them subconsciously playing early so as to line up
	        // their hits with the perfect, good, etc. judgment results based on their
	        // current (and soon to be replaced) input adjust time values.
	        // Instead, we want them focused on the sounds of their keyboard, tatacon,
	        // other controller, etc. and the visuals of notes crossing the judgment position.
	        if (TJAPlayer3.IsPerformingCalibration)
	        {
	            return e判定 < E判定.Good ? E判定.Good : e判定;
	        }
	        else
	        {
	            return e判定;
	        }
	    }

		private E判定 e指定時刻からChipのJUDGEを返すImpl( long nTime, CDTX.CChip pChip )
		{
			if ( pChip != null )
			{
				pChip.nLag = (int) ( nTime - pChip.n発声時刻ms );		// #23580 2011.1.3 yyagi: add "nInputAdjustTime" to add input timing adjust feature
				int nDeltaTime = Math.Abs( pChip.nLag );
				//Debug.WriteLine("nAbsTime=" + (nTime - pChip.n発声時刻ms) + ", nDeltaTime=" + (nTime + nInputAdjustTime - pChip.n発声時刻ms));

                if( pChip.nチャンネル番号 == 0x15 || pChip.nチャンネル番号 == 0x16 )
                {
				    if ( CSound管理.rc演奏用タイマ.n現在時刻ms > pChip.n発声時刻ms && CSound管理.rc演奏用タイマ.n現在時刻ms < pChip.nノーツ終了時刻ms )
				    {
					    return E判定.Perfect;
				    }
                }
                else if( pChip.nチャンネル番号 == 0x17 )
                {
				    if ( CSound管理.rc演奏用タイマ.n現在時刻ms >= pChip.n発声時刻ms - 17 && CSound管理.rc演奏用タイマ.n現在時刻ms < pChip.nノーツ終了時刻ms )
				    {
					    return E判定.Perfect;
				    }
                }
				if ( nDeltaTime <= TJAPlayer3.nPerfect範囲ms )
				{
					return E判定.Perfect;
				}
				if ( nDeltaTime <= TJAPlayer3.nGood範囲ms )
				{
                    if( TJAPlayer3.ConfigIni.bJust )
                        return E判定.Poor;
					return E判定.Good;
				}
				if ( nDeltaTime <= TJAPlayer3.nPoor範囲ms )
				{
					return E判定.Poor;
				}
			}
			return E判定.Miss;
		}

		protected CDTX.CChip r空うちChip( E楽器パート part, Eパッド pad )
		{
			return null;
		}
		protected CDTX.CChip r指定時刻に一番近いChip_ヒット未済問わず不可視考慮( long nTime, int nChannel, int nInputAdjustTime, int nPlayer )
		{
			//sw2.Start();
//Trace.TraceInformation( "NTime={0}, nChannel={1:x2}", nTime, nChannel );
			nTime += nInputAdjustTime;						// #24239 2011.1.23 yyagi InputAdjust

			int nIndex_InitialPositionSearchingToPast;
			if ( this.n現在のトップChip == -1 )				// 演奏データとして1個もチップがない場合は
			{
				//sw2.Stop();
				return null;
			}
			int count = listChip[ nPlayer ].Count;
			int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = this.n現在のトップChip;
			if ( this.n現在のトップChip >= count )			// その時点で演奏すべきチップが既に全部無くなっていたら
			{
				nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = count - 1;
			}
			//int nIndex_NearestChip_Future;	// = nIndex_InitialPositionSearchingToFuture;
			//while ( nIndex_NearestChip_Future < count )		// 未来方向への検索
			for ( ; nIndex_NearestChip_Future < count; nIndex_NearestChip_Future++)
			{
				CDTX.CChip chip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];

				if ( ( ( 0x11 <= nChannel ) && ( nChannel <= 0x14 ) ) || nChannel == 0x1F )
				{
					if ( ( ( chip.nチャンネル番号 == nChannel ) || ( chip.nチャンネル番号 == ( nChannel ) ) ) )
					{
						if ( chip.n発声時刻ms > nTime )
						{
							break;
						}
                        if( chip.nコース != this.n次回のコース[ nPlayer ] )
                        {
                            break;
                        }
						nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
					}
					continue;	// ほんの僅かながら高速化
				}

				// nIndex_NearestChip_Future++;
			}
			int nIndex_NearestChip_Past = nIndex_InitialPositionSearchingToPast;
			//while ( nIndex_NearestChip_Past >= 0 )			// 過去方向への検索
			for ( ; nIndex_NearestChip_Past >= 0; nIndex_NearestChip_Past-- )
			{
				CDTX.CChip chip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];

				if ( ( 0x11 <= nChannel ) && ( nChannel <= 0x14 ) )
				{
					if ( ( ( chip.nチャンネル番号 == nChannel ) )  )
					{
						break;
					}
				}
				// nIndex_NearestChip_Past--;
			}

			if ( nIndex_NearestChip_Future >= count )
			{
				if ( nIndex_NearestChip_Past < 0 )	// 検索対象が過去未来どちらにも見つからなかった場合
				{
					return null;
				}
				else 								// 検索対象が未来方向には見つからなかった(しかし過去方向には見つかった)場合
				{
					//sw2.Stop();
					return listChip[ nPlayer ][ nIndex_NearestChip_Past ];
				}
			}
			else if ( nIndex_NearestChip_Past < 0 )	// 検索対象が過去方向には見つからなかった(しかし未来方向には見つかった)場合
			{
				//sw2.Stop();
				return listChip[ nPlayer ][ nIndex_NearestChip_Future ];
			}
													// 検索対象が過去未来の双方に見つかったなら、より近い方を採用する
			CDTX.CChip nearestChip_Future = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
			CDTX.CChip nearestChip_Past   = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
			int nDiffTime_Future = Math.Abs( (int) ( nTime - nearestChip_Future.n発声時刻ms ) );
			int nDiffTime_Past   = Math.Abs( (int) ( nTime - nearestChip_Past.n発声時刻ms ) );
			if ( nDiffTime_Future >= nDiffTime_Past )
			{
				//sw2.Stop();
				return nearestChip_Past;
			}
			//sw2.Stop();
			return nearestChip_Future;
		}

		protected CDTX.CChip r指定時刻に一番近い連打Chip_ヒット未済問わず不可視考慮( long nTime, int nChannel, int nInputAdjustTime, int nPlayer )
		{
			//sw2.Start();
//Trace.TraceInformation( "NTime={0}, nChannel={1:x2}", nTime, nChannel );
			nTime += nInputAdjustTime;						// #24239 2011.1.23 yyagi InputAdjust

			int nIndex_InitialPositionSearchingToPast;
			if ( this.n現在のトップChip == -1 )				// 演奏データとして1個もチップがない場合は
			{
				//sw2.Stop();
				return null;
			}

            List<CDTX.CChip> playerListChip = listChip[ nPlayer ];
            int count = playerListChip.Count;
			int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = this.n現在のトップChip;
			if ( this.n現在のトップChip >= count )			// その時点で演奏すべきチップが既に全部無くなっていたら
			{
				nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = count - 1;
			}
			//int nIndex_NearestChip_Future;	// = nIndex_InitialPositionSearchingToFuture;
			//while ( nIndex_NearestChip_Future < count )		// 未来方向への検索
			for ( ; nIndex_NearestChip_Future < count; nIndex_NearestChip_Future++)
			{
				if ( ( ( 0x11 <= nChannel ) && ( nChannel <= 0x17 ) ) )
				{
                    CDTX.CChip chip = playerListChip[ nIndex_NearestChip_Future ];

                    if ( chip.nチャンネル番号 == nChannel )
					{
						if ( chip.n発声時刻ms > nTime )
						{
							break;
						}
                        if( chip.nコース != this.n次回のコース[ nPlayer ] )
                        {
                            break;
                        }
						nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
					}
					continue;	// ほんの僅かながら高速化
				}

				// nIndex_NearestChip_Future++;
			}
			int nIndex_NearestChip_Past = nIndex_InitialPositionSearchingToPast;
			//while ( nIndex_NearestChip_Past >= 0 )			// 過去方向への検索
			for ( ; nIndex_NearestChip_Past >= 0; nIndex_NearestChip_Past-- )
			{
				if ( ( 0x15 <= nChannel ) && ( nChannel <= 0x17 ) )
				{
                    CDTX.CChip chip = playerListChip[ nIndex_NearestChip_Past ];

					if ( ( ( chip.nチャンネル番号 == nChannel ) )  )
					{
						break;
					}
				}
				// nIndex_NearestChip_Past--;
			}

			if ( nIndex_NearestChip_Future >= count )
			{
				if ( nIndex_NearestChip_Past < 0 )	// 検索対象が過去未来どちらにも見つからなかった場合
				{
					return null;
				}
				else 								// 検索対象が未来方向には見つからなかった(しかし過去方向には見つかった)場合
				{
					//sw2.Stop();
					return playerListChip[ nIndex_NearestChip_Past ];
				}
			}
			else if ( nIndex_NearestChip_Past < 0 )	// 検索対象が過去方向には見つからなかった(しかし未来方向には見つかった)場合
			{
				//sw2.Stop();
				return playerListChip[ nIndex_NearestChip_Future ];
			}
													// 検索対象が過去未来の双方に見つかったなら、より近い方を採用する
			CDTX.CChip nearestChip_Future = playerListChip[ nIndex_NearestChip_Future ];
			CDTX.CChip nearestChip_Past   = playerListChip[ nIndex_NearestChip_Past ];
			int nDiffTime_Future = Math.Abs( (int) ( nTime - nearestChip_Future.n発声時刻ms ) );
			int nDiffTime_Past   = Math.Abs( (int) ( nTime - nearestChip_Past.n発声時刻ms ) );
			if ( nDiffTime_Future >= nDiffTime_Past )
			{
				//sw2.Stop();
				return nearestChip_Past;
			}
			//sw2.Stop();
			return nearestChip_Future;
		}
		protected void tサウンド再生( CDTX.CChip pChip, int nPlayer )
		{
			int index = pChip.nチャンネル番号;
            if( index == 0x11 || index == 0x13 || index == 0x1A )
                this.soundRed?.t再生を開始する();
            else if( index == 0x12 || index == 0x14 || index == 0x1B )
                this.soundBlue?.t再生を開始する();
            else if( index == 0x1F )
                this.soundAdlib?.t再生を開始する();

            if( this.nHand[ nPlayer ] == 0 )
                this.nHand[ nPlayer ]++;
            else
                this.nHand[ nPlayer ] = 0;
		}

		protected void tステータスパネルの選択()
		{
			if ( TJAPlayer3.bコンパクトモード )
			{
				this.actStatusPanels.tラベル名からステータスパネルを決定する( null );
			}
			else if ( TJAPlayer3.stage選曲.r確定された曲 != null )
			{
				this.actStatusPanels.tラベル名からステータスパネルを決定する( TJAPlayer3.stage選曲.r確定された曲.ar難易度ラベル[ TJAPlayer3.stage選曲.nSeelectedCource[0]] );
			}
		}

        protected bool tRollProcess( CDTX.CChip pChip, double dbProcess_time, int num, int sort, int Input, int nPlayer )
        {
            if( dbProcess_time >= pChip.n発声時刻ms && dbProcess_time < pChip.nノーツ終了時刻ms )
            {
                if( pChip.nRollCount == 0 )
                {
                    this.actRoll.b表示[ nPlayer ] = true;
                    this.n現在の連打数[ nPlayer ] = 0;
                    this.actRoll.t枠表示時間延長( nPlayer );
                }
                this.actRoll.t枠表示時間延長(nPlayer);
                this.b連打中[ nPlayer ] = true;
                if(this.actRoll.ct連打アニメ[nPlayer].b終了値に達してない)
                {
                    this.actRoll.ct連打アニメ[nPlayer] = new CCounter(0, 9, 14, TJAPlayer3.Timer);
                    this.actRoll.ct連打アニメ[nPlayer].n現在の値 = 1;
                }
                else
                {
                    this.actRoll.ct連打アニメ[nPlayer] = new CCounter(0, 9, 14, TJAPlayer3.Timer);
                }


                pChip.RollEffectLevel += 10;
                if(pChip.RollEffectLevel >= 100)
                {
                    pChip.RollEffectLevel = 100;
                    pChip.RollInputTime = new CCounter(0, 1500, 1, TJAPlayer3.Timer);
                    pChip.RollDelay?.t停止();
                } else
                {
                    pChip.RollInputTime = new CCounter(0, 150, 1, TJAPlayer3.Timer);
                    pChip.RollDelay?.t停止(); 
                }

                if ( pChip.nチャンネル番号 == 0x15 )
                    this.eRollState = E連打State.roll;
                else
                    this.eRollState = E連打State.rollB;

                pChip.nRollCount++;
                
                this.n現在の連打数[ nPlayer ]++;
                this.nBranch_roll[ nPlayer ]++;
                this.n合計連打数[ nPlayer ]++;
                if(TJAPlayer3.stage選曲.nSeelectedCource[0] != (int)Difficulty.Dan) this.actRollChara.Start(nPlayer);

                //2017.01.28 DD CDTXから直接呼び出す
                if (pChip.bGOGOTIME && !TJAPlayer3.ConfigIni.ShinuchiMode) //2018.03.11 kairera0467 チップに埋め込んだフラグから読み取る
                {
                    // 旧配点・旧筐体配点
                    if( TJAPlayer3.DTX.nScoreModeTmp == 0 || TJAPlayer3.DTX.nScoreModeTmp == 1 )
                    {
                        if( pChip.nチャンネル番号 == 0x15 )
                            this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, (long)( 300 * 1.2f ), nPlayer );
                        else
                            this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, (long)( 360 * 1.2f ), nPlayer );
                    }
                    // 新配点
                    else
                    {
                        if( pChip.nチャンネル番号 == 0x15 )
                            this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, (long)( 100 * 1.2f ), nPlayer );
                        else
                            this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, (long)( 200 * 1.2f ), nPlayer );
                    }
                }
                else
                {
                    // 旧配点・旧筐体配点
                    if( TJAPlayer3.DTX.nScoreModeTmp == 0 || TJAPlayer3.DTX.nScoreModeTmp == 1 )
                    {
                        if( pChip.nチャンネル番号 == 0x15 )
                            this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, 300L, nPlayer );
                        else
                            this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, 360L, nPlayer );
                    }
                    // 新配点
                    else
                    {
                        if( pChip.nチャンネル番号 == 0x15 )
                            this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, 100L, nPlayer );
                        else
                            this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, 200L, nPlayer );
                    }
                }


                //赤か青かの分岐
                if( sort == 0 )
                {
                    this.soundRed?.t再生を開始する();
                    if( pChip.nチャンネル番号 == 0x15 )
                    {
                        //CDTXMania.Skin.soundRed.t再生する();
                        //CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start( 1, nPlayer );
                        TJAPlayer3.stage演奏ドラム画面.FlyingNotes.Start(1, nPlayer, true);
                    }
                    else
                    {
                        //CDTXMania.Skin.soundRed.t再生する();
                        //CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start( 3, nPlayer );
                        TJAPlayer3.stage演奏ドラム画面.FlyingNotes.Start(3, nPlayer, true);
                    }
                }
                else
                {
                    this.soundBlue?.t再生を開始する();
                    if( pChip.nチャンネル番号 == 0x15 )
                    {
                        //CDTXMania.Skin.soundBlue.t再生する();
                        //CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start( 2, nPlayer );
                        TJAPlayer3.stage演奏ドラム画面.FlyingNotes.Start(2, nPlayer, true);
                    }
                    else
                    {
                        //CDTXMania.Skin.soundBlue.t再生する();
                        //CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start( 4, nPlayer );
                        TJAPlayer3.stage演奏ドラム画面.FlyingNotes.Start(4, nPlayer, true);
                    }
                }

                TJAPlayer3.stage演奏ドラム画面.actTaikoLaneFlash.PlayerLane[nPlayer].Start(PlayerLane.FlashType.Hit);
            }
            else
            {
                this.b連打中[ nPlayer ] = false;
                return true;
            }

            return false;
        }

        protected bool tBalloonProcess( CDTX.CChip pChip, double dbProcess_time, int player )
        {
            //if( dbProcess_time >= pChip.n発声時刻ms && dbProcess_time < pChip.nノーツ終了時刻ms )
            if ((int)CSound管理.rc演奏用タイマ.n現在時刻ms >= pChip.n発声時刻ms && (int)CSound管理.rc演奏用タイマ.n現在時刻ms <= pChip.nノーツ終了時刻ms)
            {
                if( pChip.nRollCount == 0 )
                {
                    this.n風船残り[ player ] = pChip.nBalloon;
                }

                this.b連打中[ player ] = true;
                if(actChara.CharaAction_Balloon_Breaking != null && player == 0)
                {
                    actChara.アクションタイマーリセット();
                    actChara.bマイどんアクション中 = true;
                    actChara.CharaAction_Balloon_Breaking = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Breaking - 1, TJAPlayer3.Skin.Game_Chara_Balloon_Timer, TJAPlayer3.Timer);
                   
                }
                if (this.actBalloon.ct風船アニメ[player].b終了値に達してない)
                {
                    this.actBalloon.ct風船アニメ[player] = new CCounter(0, 9, 14, TJAPlayer3.Timer);
                    this.actBalloon.ct風船アニメ[player].n現在の値 = 1;
                }
                else
                {
                    this.actBalloon.ct風船アニメ[player] = new CCounter(0, 9, 14, TJAPlayer3.Timer);
                }
                this.eRollState = E連打State.balloon;
                pChip.nRollCount++;
                this.n風船残り[ player ]--;

                this.n合計連打数[player]++; //  成績発表の連打数に風船を含めるように (AioiLight)
                //分岐のための処理。実装してない。

                //赤か青かの分岐
                if ( pChip.nBalloon == pChip.nRollCount )
                {
                    //ﾊﾟｧｰﾝ
                    TJAPlayer3.Skin.soundBalloon.t再生する();
                    //CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start( 3, player ); //ここで飛ばす。飛ばされるのは大音符のみ。
                    TJAPlayer3.stage演奏ドラム画面.FlyingNotes.Start(3, player);
                    TJAPlayer3.stage演奏ドラム画面.Rainbow.Start( player );
                    //CDTXMania.stage演奏ドラム画面.actChipFireD.Start( 0, player );
                    if(pChip.bGOGOTIME && !TJAPlayer3.ConfigIni.ShinuchiMode)
                    {
                        this.actScore.Add(E楽器パート.TAIKO, this.bIsAutoPlay, 6000L, player);
                    } else
                    {
                        this.actScore.Add(E楽器パート.TAIKO, this.bIsAutoPlay, 5000L, player);
                    }
                    pChip.bHit = true;
                    chip現在処理中の連打チップ[ player ].bHit = true;
                    //this.b連打中 = false;
                    //this.actChara.b風船連打中 = false;
                    pChip.b可視 = false;
                    this.actChara.bマイどんアクション中 = false; // 風船終了後、再生されていたアクションがされないようにするために追加。(AioiLight)
                    if (actChara.CharaAction_Balloon_Broke != null && player == 0)
                    {
                        actChara.アクションタイマーリセット();
                        actChara.bマイどんアクション中 = true;
                        actChara.CharaAction_Balloon_Broke = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke - 1, TJAPlayer3.Skin.Game_Chara_Balloon_Timer, TJAPlayer3.Timer);
                        if(actChara.CharaAction_Balloon_Delay != null )actChara.CharaAction_Balloon_Delay = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Balloon_Delay - 1, 1, TJAPlayer3.Timer);
                    }
                    this.eRollState = E連打State.none;
                }
                else
                {
                    if(pChip.bGOGOTIME && !TJAPlayer3.ConfigIni.ShinuchiMode)
                    {
                        this.actScore.Add(E楽器パート.TAIKO, this.bIsAutoPlay, 360L, player);
                    } else
                    {
                        this.actScore.Add(E楽器パート.TAIKO, this.bIsAutoPlay, 300L, player);
                    }
                    //CDTXMania.Skin.soundRed.t再生する();
                    this.soundRed?.t再生を開始する();
                }
                TJAPlayer3.stage演奏ドラム画面.actTaikoLaneFlash.PlayerLane[player].Start(PlayerLane.FlashType.Hit);
            }
            else
            {
                if ( chip現在処理中の連打チップ[ player ] != null )
                    chip現在処理中の連打チップ[ player ].bHit = true;
                this.b連打中[ player ] = false;
                this.actChara.b風船連打中 = false;
                return false;
            }

            

            return true;
        }

		protected E判定 tチップのヒット処理( long nHitTime, CDTX.CChip pChip )
		{
			return tチップのヒット処理( nHitTime, pChip, true );
		}
		protected abstract E判定 tチップのヒット処理( long nHitTime, CDTX.CChip pChip, bool bCorrectLane );
		protected E判定 tチップのヒット処理( long nHitTime, CDTX.CChip pChip, E楽器パート screenmode )		// E楽器パート screenmode
		{
			return tチップのヒット処理( nHitTime, pChip, screenmode, true, 1, 0 );
		}
		protected E判定 tチップのヒット処理( long nHitTime, CDTX.CChip pChip, E楽器パート screenmode, bool bCorrectLane, int nNowInput )
		{
			return tチップのヒット処理( nHitTime, pChip, screenmode, bCorrectLane, nNowInput, 0 );
		}
		protected unsafe E判定 tチップのヒット処理( long nHitTime, CDTX.CChip pChip, E楽器パート screenmode, bool bCorrectLane, int nNowInput, int nPlayer )
		{
            //unsafeコードにつき、デバッグ中の変更厳禁!

            //if( ( pChip.nコース != this.n現在のコース ) && !CDTXMania.DTX.bチップがある.Branch )
                //return E判定.Auto;
            bool bAutoPlay = false;
            switch( nPlayer )
            {
                case 0:
                    bAutoPlay = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay;
                    break;
                case 1:
                    bAutoPlay = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay2P;
                    break;
            }

            if( !pChip.b可視 )
                return E判定.Auto;

            if( pChip.nチャンネル番号 != 0x15 && pChip.nチャンネル番号 != 0x16 && pChip.nチャンネル番号 != 0x17 && pChip.nチャンネル番号 != 0x18 )
            {
                //if( nPlayer == pChip.nPlayerSide )
			        pChip.bHit = true;
            }

			if ( pChip.e楽器パート == E楽器パート.UNKNOWN )
			{
				this.bAUTOでないチップが１つでもバーを通過した = true;
			}
			else
			{
				//cInvisibleChip.StartSemiInvisible( pChip.e楽器パート );
			}

			E判定 eJudgeResult = E判定.Auto;
			switch ( pChip.e楽器パート )
			{
				case E楽器パート.DRUMS:
				case E楽器パート.GUITAR:
				case E楽器パート.BASS:
					break;
				case E楽器パート.TAIKO:
					{
                        //連打が短すぎると発声されない
						eJudgeResult = (bCorrectLane)? this.e指定時刻からChipのJUDGEを返す( nHitTime, pChip ) : E判定.Miss;

					    if (!bAutoPlay && eJudgeResult != E判定.Miss)
					    {
					        CLagLogger.Add(nPlayer, pChip);
					    }

                        if( pChip.nチャンネル番号 == 0x15 || pChip.nチャンネル番号 == 0x16 )
                        {
                            #region[ 連打 ]
                            //---------------------------
                            this.b連打中[ nPlayer ] = true;
                            if( bAutoPlay )
                            {
                                if( TJAPlayer3.ConfigIni.bAuto先生の連打 )
                                {
                                    if( CSound管理.rc演奏用タイマ.n現在時刻ms > ( pChip.n発声時刻ms + ( 1000.0 / 15.0 ) * pChip.nRollCount ) )
                                    {
                                        if( this.nHand[ nPlayer ] == 0 )
                                            this.nHand[ nPlayer ]++;
                                        else
                                            this.nHand[ nPlayer ] = 0;

                                        TJAPlayer3.stage演奏ドラム画面.actTaikoLaneFlash.PlayerLane[nPlayer].Start(PlayerLane.FlashType.Hit);
                                        //CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start( pChip.nチャンネル番号 == 0x15 ? 1 : 3, nPlayer );
                                        TJAPlayer3.stage演奏ドラム画面.FlyingNotes.Start(pChip.nチャンネル番号 == 0x15 ? 1 : 3, nPlayer, true);
                                        TJAPlayer3.stage演奏ドラム画面.actMtaiko.tMtaikoEvent( pChip.nチャンネル番号, this.nHand[ nPlayer ], nPlayer );
                                

                                        this.tRollProcess( pChip, CSound管理.rc演奏用タイマ.n現在時刻ms, 1, 0, 0, nPlayer );
                                    }
                                }
                            }
                            else
                            {
                                this.eRollState = E連打State.roll;
                                this.tRollProcess( pChip, CSound管理.rc演奏用タイマ.n現在時刻ms, 1, nNowInput, 0, nPlayer );
                            }

                            //if ((int)CSound管理.rc演奏用タイマ.n現在時刻ms >= pChip.nノーツ終了時刻ms)
                            //{
                            //    if (actChara.CharaAction_Balloon_Breaking.b進行中)
                            //    {
                            //        this.actChara.bマイどんアクション中 = false; // 風船終了後、再生されていたアクションがされないようにするために追加。(AioiLight)
                            //        if (actChara.CharaAction_Balloon_Miss != null)
                            //        {
                            //            actChara.アクションタイマーリセット();
                            //            actChara.bマイどんアクション中 = true;
                            //            actChara.CharaAction_Balloon_Miss = new CCounter(0, CDTXMania.Skin.Game_Chara_Ptn_Balloon_Miss - 1, CDTXMania.Skin.Game_Chara_Balloon_Timer, CDTXMania.Timer);
                            //            System.Windows.Forms.MessageBox.Show("");
                            //        }
                            //    }

                            //}

                            break;
                            //---------------------------
                            #endregion
                        }
                        else if( pChip.nチャンネル番号 == 0x17 )
                        {
                            #region[ 風船 ]
                            this.b連打中[ nPlayer ] = true;
                            this.actChara.b風船連打中 = true;
                            
                            if( bAutoPlay )
                            {
                                if( pChip.nBalloon != 0 )
                                {
                                    if( CSound管理.rc演奏用タイマ.n現在時刻ms > ( pChip.n発声時刻ms + ( ( pChip.nノーツ終了時刻ms - pChip.n発声時刻ms ) / pChip.nBalloon ) * pChip.nRollCount ) )
                                    {
                                        if( this.nHand[ nPlayer ] == 0 )
                                            this.nHand[ nPlayer ]++;
                                        else
                                            this.nHand[ nPlayer ] = 0;

                                        TJAPlayer3.stage演奏ドラム画面.actTaikoLaneFlash.PlayerLane[nPlayer].Start(PlayerLane.FlashType.Hit);
                                        TJAPlayer3.stage演奏ドラム画面.actMtaiko.tMtaikoEvent( pChip.nチャンネル番号, this.nHand[ nPlayer ], nPlayer );
                                
                                        this.tBalloonProcess( pChip, CSound管理.rc演奏用タイマ.n現在時刻ms, nPlayer );
                                    }
                                }
                            }
                            else
                            {
                                this.tBalloonProcess( pChip, CSound管理.rc演奏用タイマ.n現在時刻ms, nPlayer );
                            }
                            break;
                            #endregion
                        }
                        else if( pChip.nチャンネル番号 == 0x18 )
                        {
                            if( pChip.nノーツ終了時刻ms <= CSound管理.rc演奏用タイマ.n現在時刻ms )
                            {
                                this.b連打中[ nPlayer ] = false;
                                //this.actChara.b風船連打中 = false;
                                pChip.bHit = true;
                                break;
                            }
                        }
                        else if( pChip.nチャンネル番号 == 0x1F )
                        {
                            if( eJudgeResult != E判定.Auto && eJudgeResult != E判定.Miss )
                            {
	    					    this.actJudgeString.Start( 0, E判定.Bad, pChip.nLag, pChip, nPlayer );
                                TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.Start( 0x11, eJudgeResult, true, nPlayer );
                                TJAPlayer3.stage演奏ドラム画面.actChipFireD.Start( 0x11, eJudgeResult, nPlayer );
                            }
                            break;
                        }
                        else
                        {
                            if( eJudgeResult != E判定.Miss )
                            {
                                pChip.bShow = false;
                            }
                        }

                        if( eJudgeResult != E判定.Auto && eJudgeResult != E判定.Miss )
                        {
						    this.actJudgeString.Start( 0, bAutoPlay ? E判定.Auto : eJudgeResult, pChip.nLag, pChip, nPlayer );
                            TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.Start( pChip.nチャンネル番号, eJudgeResult, true, nPlayer );
                            TJAPlayer3.stage演奏ドラム画面.actChipFireD.Start( pChip.nチャンネル番号, eJudgeResult, nPlayer );

                            if( TJAPlayer3.ConfigIni.b太鼓パートAutoPlay ? true : ( nNowInput == 2 || nNowInput == 3 ) )
                            {
                                //if( pChip.nチャンネル番号 == 0x13 || pChip.nチャンネル番号 == 0x1A )
                                //    //CDTXMania.stage演奏ドラム画面.actChipFireD.Start( 0, nPlayer );
                                //else if( pChip.nチャンネル番号 == 0x14 || pChip.nチャンネル番号 == 0x1B )
                                //   //CDTXMania.stage演奏ドラム画面.actChipFireD.Start( 1, nPlayer );
                            }
                        }
                        else if( eJudgeResult != E判定.Poor && eJudgeResult != E判定.Bad )
                        {
						    //this.actJudgeString.Start( 0,bAutoPlay ? E判定.Auto : eJudgeResult, pChip.nLag, pChip, nPlayer );
                        }
					}
					break;
			}
            if ((pChip.e楽器パート != E楽器パート.UNKNOWN))
            {
                if (pChip.nチャンネル番号 != 0x15 && pChip.nチャンネル番号 != 0x16 && pChip.nチャンネル番号 != 0x17 && pChip.nチャンネル番号 != 0x18 && pChip.nチャンネル番号 != 0x1F)
                {
                    if (pChip.nコース == this.n現在のコース[nPlayer])
                    {
                        actGauge.Damage(screenmode, pChip.e楽器パート, eJudgeResult, nPlayer);
                    }
                }

            }

            if ( eJudgeResult != E判定.Poor && eJudgeResult != E判定.Miss )
            {
                double dbUnit = (((60.0 / (TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM))));

                // ランナー(たたけたやつ)
                this.actRunner.Start(nPlayer, false, pChip);

                if ((int)actGauge.db現在のゲージ値[nPlayer] >= 100 && this.bIsAlreadyMaxed[nPlayer] == false)
                {
                    if(TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn != 0 && nPlayer == 0 && actChara.CharaAction_Balloon_Delay.b終了値に達した)
                    {
                        this.actChara.アクションタイマーリセット();
                        this.actChara.ctキャラクターアクション_魂MAX = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn - 1, (dbUnit / TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn) * 2, CSound管理.rc演奏用タイマ);
                        this.actChara.ctキャラクターアクション_魂MAX.t進行db();
                        this.actChara.ctキャラクターアクション_魂MAX.db現在の値 = 0D;
                        this.actChara.bマイどんアクション中 = true;
                    }
                    this.bIsAlreadyMaxed[nPlayer] = true;
                }
                if ((int)actGauge.db現在のゲージ値[nPlayer] >= 80 && this.bIsAlreadyCleared[nPlayer] == false)
                {
                    if(TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn != 0 && nPlayer == 0 && actChara.CharaAction_Balloon_Delay.b終了値に達した)
                    {
                        this.actChara.アクションタイマーリセット();
                        this.actChara.ctキャラクターアクション_ノルマ = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn - 1, (dbUnit / TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn) * 2, CSound管理.rc演奏用タイマ);
                        this.actChara.ctキャラクターアクション_ノルマ.t進行db();
                        this.actChara.ctキャラクターアクション_ノルマ.db現在の値 = 0D;
                        this.actChara.bマイどんアクション中 = true;
                    }
                    this.bIsAlreadyCleared[nPlayer] = true;
                    TJAPlayer3.stage演奏ドラム画面.actBackground.ClearIn(nPlayer);
                }
            }

			if ( eJudgeResult == E判定.Poor || eJudgeResult == E判定.Miss || eJudgeResult == E判定.Bad )
			{
                // ランナー(みすったやつ)
                this.actRunner.Start(nPlayer, true, pChip);
                //if (actGauge.db現在のゲージ値[nPlayer] < 80.0)
                //{
                //    CDTXMania.stage演奏ドラム画面.actBackground.tFadeOut(nPlayer);
                //}
                if ((int)actGauge.db現在のゲージ値[nPlayer] < 100 && this.bIsAlreadyMaxed[nPlayer] == true)
                {
                    this.bIsAlreadyMaxed[nPlayer] = false;
                }
                if ((int)actGauge.db現在のゲージ値[nPlayer] < 80 && this.bIsAlreadyCleared[nPlayer] == true)
                {
                    this.bIsAlreadyCleared[nPlayer] = false;
                    //CDTXMania.stage演奏ドラム画面.actBackground.ClearIn(nPlayer);
                }
                cInvisibleChip.ShowChipTemporally( pChip.e楽器パート );
			}
			switch ( pChip.e楽器パート )
			{
				case E楽器パート.DRUMS:
				case E楽器パート.GUITAR:
				case E楽器パート.BASS:
					break;
                case E楽器パート.TAIKO:
                    if( !bAutoPlay )
                    {
                        if( pChip.nチャンネル番号 == 0x15 || pChip.nチャンネル番号 == 0x16 || pChip.nチャンネル番号 == 0x17 || pChip.nチャンネル番号 == 0x18 )
                            break;

					    switch ( eJudgeResult )
					    {
                            case E判定.Perfect:
                                {
                                    this.nBranch_Perfect[ nPlayer ]++;
                                    if( nPlayer == 0 ) this.nヒット数_Auto含まない.Drums.Perfect++;
                                    this.actCombo.n現在のコンボ数[ nPlayer ]++;
                                    if (this.actCombo.ctコンボ加算[nPlayer].b終了値に達してない)
                                    {
                                        this.actCombo.ctコンボ加算[nPlayer].n現在の値 = 1;
                                    }
                                    else
                                    {
                                        this.actCombo.ctコンボ加算[nPlayer].n現在の値 = 0;
                                    }
                                }
                                break;
                            case E判定.Great:
                            case E判定.Good:
                                {
                                    this.nBranch_Good[ nPlayer ]++;
                                    if( nPlayer == 0 ) this.nヒット数_Auto含まない.Drums.Great++;
                                    this.actCombo.n現在のコンボ数[ nPlayer ]++;
                                    //this.actCombo.ctコンボ加算 = new CCounter( 0, 8, 10, CDTXMania.Timer );
                                    //this.actCombo.ctコンボ加算.t進行();
                                    if (this.actCombo.ctコンボ加算[nPlayer].b終了値に達してない)
                                    {
                                        this.actCombo.ctコンボ加算[nPlayer].n現在の値 = 1;
                                    }
                                    else
                                    {
                                        this.actCombo.ctコンボ加算[nPlayer].n現在の値 = 0;
                                    }

                                }
                                break;
                            case E判定.Poor:
		    				case E判定.Miss:
			    			case E判定.Bad:
                                {
                                    if( pChip.nチャンネル番号 == 0x1F )
                                        break;
                                    this.nBranch_Miss[ nPlayer ]++;
                                    if( nPlayer == 0 ) this.nヒット数_Auto含まない.Drums.Miss++;
                                    this.actCombo.n現在のコンボ数[ nPlayer ] = 0;
                                    this.actComboVoice.tリセット();
                                    //for (int i = 0; i < 2; i++)
                                    //{
                                    //    ctChipAnime[i].t停止();
                                    //}
                                }
			    				break;
				    		default:
					    		this.nヒット数_Auto含む.Drums[ (int) eJudgeResult ]++;
		    					break;
			    		}
                    }
					else if ( bAutoPlay )
					{
						switch ( eJudgeResult )
						{
                            case E判定.Perfect:
                            case E判定.Great:
                            case E判定.Good:
                                {
                                    if( pChip.nチャンネル番号 != 0x15 && pChip.nチャンネル番号 != 0x16 && pChip.nチャンネル番号 != 0x17 && pChip.nチャンネル番号 != 0x18 )
                                    {
                                        this.nBranch_Perfect[ nPlayer ]++;
                                        if( nPlayer == 0 ) this.nヒット数_Auto含む.Drums.Perfect++;
                                        this.actCombo.n現在のコンボ数[ nPlayer ]++;
                                        //this.actCombo.ctコンボ加算.t進行();
                                        if (this.actCombo.ctコンボ加算[nPlayer].b終了値に達してない)
                                        {
                                            this.actCombo.ctコンボ加算[nPlayer].n現在の値 = 1;
                                        }
                                        else
                                        {
                                            this.actCombo.ctコンボ加算[nPlayer].n現在の値 = 0;
                                        }
                                    }
                                }
                                break;

							default:
                                {
                                    if( pChip.nチャンネル番号 != 0x15 && pChip.nチャンネル番号 != 0x16 && pChip.nチャンネル番号 != 0x17 && pChip.nチャンネル番号 != 0x18 && pChip.nチャンネル番号 != 0x1F )
                                    {
                                        this.nBranch_Miss[ nPlayer ]++;
								        this.actCombo.n現在のコンボ数[ nPlayer ] = 0;
                                        this.actComboVoice.tリセット();
                                        //for (int i = 0; i < 2; i++)
                                        //{
                                        //    ctChipAnime[i].t停止();
                                        //}
                                    }
                                }
								break;
						}
					}
                    actDan.Update();
                
                    #region[ コンボ音声 ]
                    if( pChip.nチャンネル番号 < 0x15 || ( pChip.nチャンネル番号 >= 0x1A ) )
                    {
                        if( this.actCombo.n現在のコンボ数[ nPlayer ] % 100 == 0 && this.actCombo.n現在のコンボ数[ nPlayer ] > 0 )
                        {
                            this.actComboBalloon.Start( this.actCombo.n現在のコンボ数[ nPlayer ], nPlayer );
                        }
                        this.actComboVoice.t再生( this.actCombo.n現在のコンボ数[ nPlayer ], nPlayer );

                        double dbUnit = (((60.0 / (TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM))));
                        dbUnit = (((60.0 / pChip.dbBPM)));

                        //CDTXMania.act文字コンソール.tPrint(620, 80, C文字コンソール.Eフォント種別.白, "BPM: " + dbUnit.ToString());

                        for (int i = 0; i < 2; i++)
                        {
                            if (this.actCombo.n現在のコンボ数[i] == 50 || this.actCombo.n現在のコンボ数[i] == 300)
                            {
                                ctChipAnimeLag[i] = new CCounter(0, 664, 1, TJAPlayer3.Timer);
                            }
                        }

                        if (this.actCombo.n現在のコンボ数[0] % 10 == 0 && this.actCombo.n現在のコンボ数[0] > 0)
                        {
                            //if (this.actChara.bマイどんアクション中 == false)
                            //{
                                if (!pChip.bGOGOTIME) //2018.03.11 kairera0467 チップに埋め込んだフラグから読み取る
                                {
                                    if (TJAPlayer3.Skin.Game_Chara_Ptn_10combo != 0 && nPlayer == 0 && !this.actChara.ctキャラクターアクション_ノルマ.b進行中db && actChara.CharaAction_Balloon_Delay.b終了値に達した)
                                    {
                                        if (TJAPlayer3.stage演奏ドラム画面.actGauge.db現在のゲージ値[0] < 100)
                                        {
                                            // 魂ゲージMAXではない
                                            // ジャンプ_ノーマル
                                            this.actChara.アクションタイマーリセット();
                                            this.actChara.ctキャラクターアクション_10コンボ = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_10combo - 1, (dbUnit / TJAPlayer3.Skin.Game_Chara_Ptn_10combo) * 2, CSound管理.rc演奏用タイマ);
                                            this.actChara.ctキャラクターアクション_10コンボ.t進行db();
                                            this.actChara.ctキャラクターアクション_10コンボ.db現在の値 = 0D;
                                            this.actChara.bマイどんアクション中 = true;
                                            //this.actChara.マイどん_アクション_10コンボ();
                                        }
                                    }
                                    if (TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max != 0 && nPlayer == 0 && !this.actChara.ctキャラクターアクション_魂MAX.b進行中db && actChara.CharaAction_Balloon_Delay.b終了値に達した)
                                    {
                                        if (TJAPlayer3.stage演奏ドラム画面.actGauge.db現在のゲージ値[0] >= 100)
                                        {
                                            // 魂ゲージMAX
                                            // ジャンプ_MAX
                                            this.actChara.アクションタイマーリセット();
                                            this.actChara.ctキャラクターアクション_10コンボMAX = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max - 1, (dbUnit / TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max) * 2, CSound管理.rc演奏用タイマ);
                                            this.actChara.ctキャラクターアクション_10コンボMAX.t進行db();
                                            this.actChara.ctキャラクターアクション_10コンボMAX.db現在の値 = 0D;
                                            this.actChara.bマイどんアクション中 = true;
                                        }
                                    }
                                }
                                
                            //}
                            else
                            {
                                // 魂ゲージMAX
                                // ジャンプ_MAX
                                //CDTXMania.stage演奏ドラム画面.actChara.マイどん_アクション_タイマーリセット();
                                //CDTXMania.stage演奏ドラム画面.actChara.マイどん_アクション_スタート(CDTXMania.stage演奏ドラム画面.actChara.nキャラクターアクション_10コンボMAX枚数, 2);
                            }

                            /*
                                if (CDTXMania.stage演奏ドラム画面.actGauge.db現在のゲージ値[0] <= 100)
                                {
                                    this.actChara.アクションタイマーリセット();
                                    this.actChara.ctキャラクターアクション_魂MAX = new CCounter(0, CDTXMania.stage演奏ドラム画面.actChara.nキャラクターアクション_魂MAX枚数 - 1, (dbUnit / CDTXMania.stage演奏ドラム画面.actChara.nキャラクターアクション_魂MAX枚数) * 2, CSound管理.rc演奏用タイマ);
                                    this.actChara.ctキャラクターアクション_魂MAX.t進行db();
                                    this.actChara.ctキャラクターアクション_魂MAX.db現在の値 = 0D;
                                    this.actChara.bマイどんアクション中 = true;
                                } else if (CDTXMania.stage演奏ドラム画面.actGauge.db現在のゲージ値[0] <= 80)
                                {
                                    this.actChara.アクションタイマーリセット();
                                    this.actChara.ctキャラクターアクション_ノルマ = new CCounter(0, CDTXMania.stage演奏ドラム画面.actChara.nキャラクターアクション_ノルマ枚数 - 1, (dbUnit / CDTXMania.stage演奏ドラム画面.actChara.nキャラクターアクション_ノルマ枚数) * 2, CSound管理.rc演奏用タイマ);
                                    this.actChara.ctキャラクターアクション_ノルマ.t進行db();
                                    this.actChara.ctキャラクターアクション_ノルマ.db現在の値 = 0D;
                                    this.actChara.bマイどんアクション中 = true;
                                }
                            */
                        }
                        if(this.actCombo.n現在のコンボ数[0] == 50 || this.actCombo.n現在のコンボ数[1] == 50)
                        {

                        }


                            this.t紙吹雪_開始();
                    }
                    #endregion


					break;


				default:
					break;
			}
			if ( ( ( pChip.e楽器パート != E楽器パート.UNKNOWN ) ) && ( eJudgeResult != E判定.Miss ) && ( eJudgeResult != E判定.Bad ) && ( eJudgeResult != E判定.Poor ) && ( pChip.nチャンネル番号 <= 0x14 || pChip.nチャンネル番号 == 0x1A || pChip.nチャンネル番号 == 0x1B ) )
			{
				int nCombos = this.actCombo.n現在のコンボ数[ nPlayer ];
                long nInit = TJAPlayer3.DTX.nScoreInit[ 0, TJAPlayer3.stage選曲.nSeelectedCource[0]];
                long nDiff = TJAPlayer3.DTX.nScoreDiff[ TJAPlayer3.stage選曲.nSeelectedCource[0]];
                long nAddScore = 0;

                if( TJAPlayer3.ConfigIni.ShinuchiMode )  //2016.07.04 kairera0467 真打モード。
                {
                    nAddScore = TJAPlayer3.DTX.nScoreInit[ 1, TJAPlayer3.stage選曲.nSeelectedCource[0]];
                    if( nAddScore == 0 )
                    {
                        //可の時に0除算をするとエラーが発生するため、それらしい数値を自動算出する。
                        //メモ
                        //風船1回
                        nAddScore = 100;
                        //( 100万 - ( ( 風船の打数 - 風船音符の数 * 300 ) + ( 風船音符の数 * 5000 ) ) ) / ノーツ数
                        //(最大コンボ数＋大音符数)×初項＋(風船の総打数－風船数)×300＋風船数×5000
                        //int nBallonCount = 0;
                        //int nBallonNoteCount = CDTXMania.DTX.n風船数[ 2 ] + CDTXMania.DTX.n風船数[ 3 ];
                        //int test = ( 1000000 - ( ( nBallonCount - nBallonNoteCount * 300 ) + ( nBallonNoteCount * 5000 ) ) ) / ( CDTXMania.DTX.nノーツ数[ 2 ] + CDTXMania.DTX.nノーツ数[ 3 ] );
                    }

                    if (eJudgeResult == E判定.Great || eJudgeResult == E判定.Good)
                    {
                        nAddScore = nAddScore / 2;
                    }

                    if( pChip.nチャンネル番号 == 0x13 || pChip.nチャンネル番号 == 0x14 || pChip.nチャンネル番号 == 0x1A || pChip.nチャンネル番号 == 0x1B )
                    {
                        nAddScore = nAddScore * 2;
                    }

                    this.actScore.Add( E楽器パート.TAIKO, bIsAutoPlay, nAddScore, nPlayer );
                }
                else if( TJAPlayer3.DTX.nScoreModeTmp == 2 )
                {
                    if( nCombos < 10 )
                    {
                        nAddScore = this.nScore[ 0 ];
                    }
                    else if( nCombos >= 10 && nCombos <= 29 )
                    {
                        nAddScore = this.nScore[ 1 ];
                    }
                    else if( nCombos >= 30 && nCombos <= 49 )
                    {
                        nAddScore = this.nScore[ 2 ];
                    }
                    else if( nCombos >= 50 && nCombos <= 99 )
                    {
                        nAddScore = this.nScore[ 3 ];
                    }
                    else if (nCombos >= 100)
                    {
                        nAddScore = this.nScore[ 4 ];
                    }

                    if (eJudgeResult == E判定.Great || eJudgeResult == E判定.Good)
                    {
                        nAddScore = nAddScore / 2;
                    }

                    if (pChip.bGOGOTIME) //2018.03.11 kairera0467 チップに埋め込んだフラグから読み取る
                    {
                        nAddScore = (int)(nAddScore * 1.2f);
                    }

                    //100コンボ毎のボーナス
                    if( nCombos % 100 == 0 && nCombos > 99 )
                    {
                        if(this.actScore.ctボーナス加算タイマ[nPlayer].b進行中)
                        {
                            this.actScore.ctボーナス加算タイマ[nPlayer].t停止();
                            this.actScore.BonusAdd(nPlayer);
                        }
                        this.actScore.ctボーナス加算タイマ[nPlayer].n現在の値 = 0;
                        this.actScore.ctボーナス加算タイマ[nPlayer] = new CCounter(0, 2, 1000, TJAPlayer3.Timer);

                        //combot = new System.Timers.Timer();
                        //if(nPlayer == 0)
                        //{
                        //    combot.Elapsed += new System.Timers.ElapsedEventHandler(combotimer_event_1);
                        //} else
                        //{
                        //    combot.Elapsed += new System.Timers.ElapsedEventHandler(combotimer_event_2);
                        //}

                        //combot.Interval = 2000; // ミリ秒単位で指定
                        //combot.Enabled = true;
                    }

                    nAddScore = (int)( nAddScore / 10 );
                    nAddScore = (int)( nAddScore * 10 );

                    //大音符のボーナス
                    if( pChip.nチャンネル番号 == 0x13 || pChip.nチャンネル番号 == 0x14 || pChip.nチャンネル番号 == 0x1A || pChip.nチャンネル番号 == 0x1B )
                    {
                        nAddScore = nAddScore * 2;
                    }

                    this.actScore.Add( E楽器パート.TAIKO, bIsAutoPlay, nAddScore, nPlayer );
                    //this.actScore.Add( E楽器パート.DRUMS, bIsAutoPlay, nAddScore );
                }
                else if( TJAPlayer3.DTX.nScoreModeTmp == 1 )
                {
                    if (nCombos < 10)
                    {
                        nAddScore = this.nScore[ 0 ];
                    }
                    else if( nCombos >= 10 && nCombos <= 19 )
                    {
                        nAddScore = this.nScore[ 1 ];
                    }
                    else if( nCombos >= 20 && nCombos <= 29 )
                    {
                        nAddScore = this.nScore[ 2 ];
                    }
                    else if( nCombos >= 30 && nCombos <= 39 )
                    {
                        nAddScore = this.nScore[ 3 ];
                    }
                    else if( nCombos >= 40 && nCombos <= 49 )
                    {
                        nAddScore = this.nScore[ 4 ];
                    }
                    else if( nCombos >= 50 && nCombos <= 59 )
                    {
                        nAddScore = this.nScore[ 5 ];
                    }
                    else if( nCombos >= 60 && nCombos <= 69 )
                    {
                        nAddScore = this.nScore[ 6 ];
                    }
                    else if( nCombos >= 70 && nCombos <= 79 )
                    {
                        nAddScore = this.nScore[ 7 ];
                    }
                    else if( nCombos >= 80 && nCombos <= 89 )
                    {
                        nAddScore = this.nScore[ 8 ];
                    }
                    else if( nCombos >= 90 && nCombos <= 99 )
                    {
                        nAddScore = this.nScore[ 9 ];
                    }
                    else if( nCombos >= 100 )
                    {
                        nAddScore = this.nScore[ 10 ];
                    }

                    if (eJudgeResult == E判定.Great || eJudgeResult == E判定.Good)
                    {
                        nAddScore = nAddScore / 2;
                    }


                    if (pChip.bGOGOTIME) //2018.03.11 kairera0467 チップに埋め込んだフラグから読み取る
                        nAddScore = (int)( nAddScore * 1.2f );

                    nAddScore = (int)( nAddScore / 10.0 );
                    nAddScore = (int)( nAddScore * 10 );

                    //大音符のボーナス
                    if( pChip.nチャンネル番号 == 0x13 || pChip.nチャンネル番号 == 0x14 || pChip.nチャンネル番号 == 0x1A || pChip.nチャンネル番号 == 0x1B )
                    {
                        nAddScore = nAddScore * 2;
                    }

                    this.actScore.Add( E楽器パート.TAIKO, bIsAutoPlay, nAddScore, nPlayer );
                }
                else
                {
                    if( eJudgeResult == E判定.Perfect )
                    {
                        if( nCombos < 200 )
                        {
                            nAddScore = 1000;
                        }
                        else
                        {
                            nAddScore = 2000;
                        }
                    }
                    else if (eJudgeResult == E判定.Great || eJudgeResult == E判定.Good)
                    {
                        if( nCombos < 200 )
                        {
                            nAddScore = 500;
                        }
                        else
                        {
                            nAddScore = 1000;
                        }
                    }

                    if (pChip.bGOGOTIME) //2018.03.11 kairera0467 チップに埋め込んだフラグから読み取る
                        nAddScore = (int)(nAddScore * 1.2f);

                    //大音符のボーナス
                    if (pChip.nチャンネル番号 == 0x13 || pChip.nチャンネル番号 == 0x25 )
                    {
                        nAddScore = nAddScore * 2;
                    }


                    this.actScore.Add( E楽器パート.TAIKO, bIsAutoPlay, nAddScore, nPlayer );
                    //this.actScore.Add( E楽器パート.DRUMS, bIsAutoPlay, nAddScore );              
                }

                //CDTXMania.act文字コンソール.tPrint( 50, 220, C文字コンソール.Eフォント種別.赤, nAddScore.ToString() );
			}
			return eJudgeResult;
		}

        protected void t分岐状況チェック( int n現在時刻, int nPlayer )
        {
            CDTX dTX = TJAPlayer3.DTX;

            switch( nPlayer )
            {
                case 1:
                    dTX = TJAPlayer3.DTX_2P;
                    break;
                default:
                    break;
            }

            for( int i = this.n現在のトップChip; i < dTX.listChip.Count; i++ )
            {
                if( ( dTX.listChip[ i ].nチャンネル番号 <= 0x11 && dTX.listChip[ i ].nチャンネル番号 >= 0x18 ) != false )
                {
                    if( dTX.listChip[ i ].nコース == this.n現在のコース[ nPlayer ] )
                    {
                        dTX.listChip[i].b可視 = true;
                    }
                    else
                    {
                        dTX.listChip[i].b可視 = false;
                    }
                }
            }
        }


		protected abstract void tチップのヒット処理_BadならびにTight時のMiss( E楽器パート part );
		protected abstract void tチップのヒット処理_BadならびにTight時のMiss( E楽器パート part, int nLane );
		protected void tチップのヒット処理_BadならびにTight時のMiss( E楽器パート part, E楽器パート screenmode )
		{
			this.tチップのヒット処理_BadならびにTight時のMiss( part, 0, screenmode );
		}
		protected void tチップのヒット処理_BadならびにTight時のMiss( E楽器パート part, int nLane, E楽器パート screenmode )
		{
            //まだpChipでのチャンネル判別に対応していない。

			this.bAUTOでないチップが１つでもバーを通過した = true;
			cInvisibleChip.StartSemiInvisible( part );
			cInvisibleChip.ShowChipTemporally( part );
			//this.t判定にあわせてゲージを増減する( screenmode, part, E判定.Miss );
			actGauge.Damage( screenmode, part, E判定.Miss, 0 );
			switch ( part )
			{
				case E楽器パート.DRUMS:
				case E楽器パート.GUITAR:
				case E楽器パート.BASS:
					break;

				case E楽器パート.TAIKO:
					this.actCombo.n現在のコンボ数.P1 = 0;
					break;

				default:
					return;
			}
		}

		protected CDTX.CChip r指定時刻に一番近いChipを過去方向優先で検索する( long nTime, int nChannel, int nInputAdjustTime, int nPlayer )
		{
			//sw2.Start();
			nTime += nInputAdjustTime;

			int nIndex_InitialPositionSearchingToPast;
			int nTimeDiff;
			int count = listChip[ nPlayer ].Count;
			if ( count <= 0 )			// 演奏データとして1個もチップがない場合は
			{
				//sw2.Stop();
				return null;
			}

			int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = this.n現在のトップChip;
			if ( this.n現在のトップChip >= count )		// その時点で演奏すべきチップが既に全部無くなっていたら
			{
				nIndex_NearestChip_Future  = nIndex_InitialPositionSearchingToPast = count - 1;
			}
			// int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToFuture;
//			while ( nIndex_NearestChip_Future < count )	// 未来方向への検索
			for ( ; nIndex_NearestChip_Future < count; nIndex_NearestChip_Future++ )
			{
				CDTX.CChip chip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
				if ( chip.b可視 )
				{
					if( chip.nチャンネル番号 == nChannel )
					{
						if ( chip.n発声時刻ms > nTime )
						{
							break;
						}
                        nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
					}
				}
//				nIndex_NearestChip_Future++;
			}
			int nIndex_NearestChip_Past = nIndex_InitialPositionSearchingToPast;
//			while ( nIndex_NearestChip_Past >= 0 )		// 過去方向への検索
			for ( ; nIndex_NearestChip_Past >= 0; nIndex_NearestChip_Past-- )
			{
				CDTX.CChip chip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
				//if ( (!chip.bHit && chip.b可視 ) && ( (  0x93 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x99 ) ) )
                if( chip.b可視 && chip.nチャンネル番号 == nChannel )
				{
				    break;
				}
			}
			if ( ( nIndex_NearestChip_Future >= count ) && ( nIndex_NearestChip_Past < 0 ) )	// 検索対象が過去未来どちらにも見つからなかった場合
			{
				//sw2.Stop();
				return null;
			}
			CDTX.CChip nearestChip;	// = null;	// 以下のifブロックのいずれかで必ずnearestChipには非nullが代入されるので、null初期化を削除
			if ( nIndex_NearestChip_Future >= count )											// 検索対象が未来方向には見つからなかった(しかし過去方向には見つかった)場合
			{
				nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else if ( nIndex_NearestChip_Past < 0 )												// 検索対象が過去方向には見つからなかった(しかし未来方向には見つかった)場合
			{
				nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else
			{
				int nTimeDiff_Future = Math.Abs( (int) ( nTime - listChip[ nPlayer ][ nIndex_NearestChip_Future ].n発声時刻ms ) );
				int nTimeDiff_Past   = Math.Abs( (int) ( nTime - listChip[ nPlayer ][ nIndex_NearestChip_Past   ].n発声時刻ms ) );
				if ( nTimeDiff_Future < nTimeDiff_Past )
				{
                    if( !listChip[ nPlayer ][ nIndex_NearestChip_Past ].bHit && ( listChip[ nPlayer ][ nIndex_NearestChip_Past ].n発声時刻ms + ( 108 ) >= nTime ) )
                    {
					    nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
                    }
                    else
					    nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}
				else
				{
					nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}
			}
			nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
            int n検索範囲時間ms = 0;
			if ( ( n検索範囲時間ms > 0 ) && ( nTimeDiff > n検索範囲時間ms ) )					// チップは見つかったが、検索範囲時間外だった場合
			{
				//sw2.Stop();
				return null;
			}
			//sw2.Stop();
			return nearestChip;
		}

		protected CDTX.CChip r指定時刻に一番近い未ヒットChipを過去方向優先で検索する( long nTime, int nPlayer )
		{
			//sw2.Start();
			int nIndex_InitialPositionSearchingToPast;
			int nTimeDiff;
			int count = listChip[ nPlayer ].Count;
			if ( count <= 0 )			// 演奏データとして1個もチップがない場合は
			{
				//sw2.Stop();
				return null;
			}

			int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = this.n現在のトップChip;
			if ( this.n現在のトップChip >= count )		// その時点で演奏すべきチップが既に全部無くなっていたら
			{
				nIndex_NearestChip_Future  = nIndex_InitialPositionSearchingToPast = count - 1;
			}
			// int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToFuture;
//			while ( nIndex_NearestChip_Future < count )	// 未来方向への検索
			for ( ; nIndex_NearestChip_Future < count; nIndex_NearestChip_Future++ )
			{
                if( nIndex_NearestChip_Future < 0 )
                    continue;

				CDTX.CChip chip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
				if ( !chip.bHit && chip.b可視 )
				{
					if ( ( ( 0x11 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x18 ) ) || chip.nチャンネル番号 == 0x1A || chip.nチャンネル番号 == 0x1B || chip.nチャンネル番号 == 0x1F )
					{
						if ( chip.n発声時刻ms > nTime )
						{
							break;
						}
                        nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
					}
				}
                if( chip.bHit && chip.b可視 ) // 2015.11.5 kairera0467 連打対策
                {
                    if( ( 0x15 <= chip.nチャンネル番号) && ( chip.nチャンネル番号 <= 0x17 ) )
                    {
                        if (chip.nノーツ終了時刻ms > nTime)
                        {
                            nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
                            break;
                        }
                    }
                }
//				nIndex_NearestChip_Future++;
			}
			int nIndex_NearestChip_Past = nIndex_InitialPositionSearchingToPast;
//			while ( nIndex_NearestChip_Past >= 0 )		// 過去方向への検索
			for ( ; nIndex_NearestChip_Past >= 0; nIndex_NearestChip_Past-- )
			{
				CDTX.CChip chip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
				//if ( (!chip.bHit && chip.b可視 ) && ( (  0x93 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x99 ) ) )
                if ( (!chip.bHit && chip.b可視 ) && ( (  0x11 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x17 ) ) || chip.nチャンネル番号 == 0x1A || chip.nチャンネル番号 == 0x1B || chip.nチャンネル番号 == 0x1F )
					{
						break;
					}
                //2015.11.5 kairera0467 連打対策
				else if ( ( chip.b可視 ) && ( (  0x15 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x17 ) ) )
					{
						break;
					}
//				nIndex_NearestChip_Past--;
			}
			if ( ( nIndex_NearestChip_Future >= count ) && ( nIndex_NearestChip_Past < 0 ) )	// 検索対象が過去未来どちらにも見つからなかった場合
			{
				//sw2.Stop();
				return null;
			}
			CDTX.CChip nearestChip;	// = null;	// 以下のifブロックのいずれかで必ずnearestChipには非nullが代入されるので、null初期化を削除
			if ( nIndex_NearestChip_Future >= count )											// 検索対象が未来方向には見つからなかった(しかし過去方向には見つかった)場合
			{
                nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else if ( nIndex_NearestChip_Past < 0 )												// 検索対象が過去方向には見つからなかった(しかし未来方向には見つかった)場合
			{
                nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else
			{
				int nTimeDiff_Future = Math.Abs( (int) ( nTime - listChip[ nPlayer ][ nIndex_NearestChip_Future ].n発声時刻ms ) );
				int nTimeDiff_Past   = Math.Abs( (int) ( nTime - listChip[ nPlayer ][ nIndex_NearestChip_Past   ].n発声時刻ms ) );
				if ( nTimeDiff_Future < nTimeDiff_Past )
				{
                    if( !listChip[ nPlayer ][ nIndex_NearestChip_Past ].bHit && ( listChip[ nPlayer ][ nIndex_NearestChip_Past ].n発声時刻ms + ( 108 ) >= nTime ) )
                    {
					    nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
                    }
                    else
					    nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}
				else
				{
					nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}

                //2015.11.5 kairera0467　連打音符の判定
                if( listChip[ nPlayer ][ nIndex_NearestChip_Future ].nチャンネル番号 >= 0x15 && listChip[ nPlayer ][ nIndex_NearestChip_Future ].nチャンネル番号 <= 0x17 )
                {
                    if( listChip[ nPlayer ][ nIndex_NearestChip_Future ].n発声時刻ms <= nTime && listChip[ nPlayer ][ nIndex_NearestChip_Future ].nノーツ終了時刻ms >= nTime )
                    {
                        nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
                    }
                }
			}
			nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
            int n検索範囲時間ms = 0;
			if ( ( n検索範囲時間ms > 0 ) && ( nTimeDiff > n検索範囲時間ms ) )					// チップは見つかったが、検索範囲時間外だった場合
			{
				//sw2.Stop();
				return null;
			}
			//sw2.Stop();
			return nearestChip;
		}

		protected CDTX.CChip r指定時刻に一番近い未ヒットChip( long nTime, int nInputAdjustTime, int nPlayer )
		{
			//sw2.Start();
//Trace.TraceInformation( "nTime={0}, nChannel={1:x2}, 現在のTop={2}", nTime, nChannel,CDTXMania.DTX.listChip[ this.n現在のトップChip ].n発声時刻ms );
			nTime += nInputAdjustTime;

			int nIndex_InitialPositionSearchingToPast;
			int nTimeDiff;
			if ( this.n現在のトップChip == -1 )			// 演奏データとして1個もチップがない場合は
			{
				//sw2.Stop();
				return null;
			}
			int count = listChip[ nPlayer ].Count;
			int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = this.n現在のトップChip;
			if ( this.n現在のトップChip >= count )		// その時点で演奏すべきチップが既に全部無くなっていたら
			{
				nIndex_NearestChip_Future  = nIndex_InitialPositionSearchingToPast = count - 1;
			}
			// int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToFuture;
//			while ( nIndex_NearestChip_Future < count )	// 未来方向への検索
			for ( ; nIndex_NearestChip_Future < count; nIndex_NearestChip_Future++ )
			{
				CDTX.CChip chip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
				if ( !chip.bHit && chip.b可視 )
				{
					if ( ( ( 0x11 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x1F ) ) )
					{
						if ( chip.n発声時刻ms > nTime )
						{
							break;
						}
						nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
					}
				}
//				nIndex_NearestChip_Future++;
			}
			int nIndex_NearestChip_Past = nIndex_InitialPositionSearchingToPast;
//			while ( nIndex_NearestChip_Past >= 0 )		// 過去方向への検索
			for ( ; nIndex_NearestChip_Past >= 0; nIndex_NearestChip_Past-- )
			{
				CDTX.CChip chip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
				if ( ( !chip.bHit && chip.b可視 ) && ( (  0x11 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x1F ) ) )
					{
						break;
					}
//				nIndex_NearestChip_Past--;
			}
			if ( ( nIndex_NearestChip_Future >= count ) && ( nIndex_NearestChip_Past < 0 ) )	// 検索対象が過去未来どちらにも見つからなかった場合
			{
				//sw2.Stop();
				return null;
			}
			CDTX.CChip nearestChip;	// = null;	// 以下のifブロックのいずれかで必ずnearestChipには非nullが代入されるので、null初期化を削除
			if ( nIndex_NearestChip_Future >= count )											// 検索対象が未来方向には見つからなかった(しかし過去方向には見つかった)場合
			{
				nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else if ( nIndex_NearestChip_Past < 0 )												// 検索対象が過去方向には見つからなかった(しかし未来方向には見つかった)場合
			{
				nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else
			{
				int nTimeDiff_Future = Math.Abs( (int) ( nTime - listChip[ nPlayer ][ nIndex_NearestChip_Future ].n発声時刻ms ) );
				int nTimeDiff_Past   = Math.Abs( (int) ( nTime - listChip[ nPlayer ][ nIndex_NearestChip_Past   ].n発声時刻ms ) );
				if ( nTimeDiff_Future < nTimeDiff_Past )
				{
					nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}
				else
				{
					nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}
			}
			nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
            int n検索範囲時間ms = 0;
			if ( ( n検索範囲時間ms > 0 ) && ( nTimeDiff > n検索範囲時間ms ) )					// チップは見つかったが、検索範囲時間外だった場合
			{
				//sw2.Stop();
				return null;
			}
			//sw2.Stop();
			return nearestChip;
		}
	
		protected CDTX.CChip r指定時刻に一番近い未ヒットChip( long nTime, int nChannelFlag, int nInputAdjustTime, int n検索範囲時間ms )
		{
			return this.r指定時刻に一番近い未ヒットChip( nTime, nChannelFlag, nInputAdjustTime, 0, 0 );
		}
		protected CDTX.CChip r指定時刻に一番近い未ヒットChip( long nTime, int nChannel, int nInputAdjustTime, int n検索範囲時間ms, int nPlayer )
		{
			//sw2.Start();
//Trace.TraceInformation( "nTime={0}, nChannel={1:x2}, 現在のTop={2}", nTime, nChannel,CDTXMania.DTX.listChip[ this.n現在のトップChip ].n発声時刻ms );
			nTime += nInputAdjustTime;

			int nIndex_InitialPositionSearchingToPast;
			int nTimeDiff;
			if ( this.n現在のトップChip == -1 )			// 演奏データとして1個もチップがない場合は
			{
				//sw2.Stop();
				return null;
			}
			int count = listChip[ nPlayer ].Count;
			int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = this.n現在のトップChip;
			if ( this.n現在のトップChip >= count )		// その時点で演奏すべきチップが既に全部無くなっていたら
			{
				nIndex_NearestChip_Future  = nIndex_InitialPositionSearchingToPast = count - 1;
			}
			// int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToFuture;
//			while ( nIndex_NearestChip_Future < count )	// 未来方向への検索
			for ( ; nIndex_NearestChip_Future < count; nIndex_NearestChip_Future++ )
			{
				CDTX.CChip chip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
				if ( !chip.bHit )
				{
                    if( ( 0x11 <= nChannel) && ( nChannel <= 0x1F ) )
                    {
                        if ((chip.nチャンネル番号 == nChannel) || (chip.nチャンネル番号 == (nChannel + 0x20)))
                        {
                            if (chip.n発声時刻ms > nTime)
                            {
                                break;
                            }
                            nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
                        }
                        continue;
                    }

					//if ( ( ( 0xDE <= nChannel ) && ( nChannel <= 0xDF ) ) )
                    if ( ( ( 0xDF == nChannel ) ) )
					{
                        if( chip.nチャンネル番号 == nChannel )
                        {
						    if ( chip.n発声時刻ms > nTime )
						    {
						    	break;
						    }
						    nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
                        }
					}

                    if ( ( ( 0x50 == nChannel ) ) )
					{
                        if( chip.nチャンネル番号 == nChannel )
                        {
						    if ( chip.n発声時刻ms > nTime )
						    {
						    	break;
						    }
						    nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
                        }
					}

				}
//				nIndex_NearestChip_Future++;
			}
			int nIndex_NearestChip_Past = nIndex_InitialPositionSearchingToPast;
//			while ( nIndex_NearestChip_Past >= 0 )		// 過去方向への検索
			for ( ; nIndex_NearestChip_Past >= 0; nIndex_NearestChip_Past-- )
			{
				CDTX.CChip chip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
				if ( (!chip.bHit) &&
						(
							(
                                ( ( ( ( nChannel >= 0x11 ) && ( nChannel <= 0x14 ) ) || nChannel == 0x1A || nChannel == 0x1B || nChannel == 0x1F ) && ( chip.nチャンネル番号 == nChannel ) )
							)
							||
							(
							//	( ( ( nChannel >= 0xDE ) && ( nChannel <= 0xDF ) ) && ( chip.nチャンネル番号 == nChannel ) )
	                            ( ( ( nChannel == 0xDF ) ) && ( chip.nチャンネル番号 == nChannel ) )
							)
							||
							(
							//	( ( ( nChannel >= 0xDE ) && ( nChannel <= 0xDF ) ) && ( chip.nチャンネル番号 == nChannel ) )
	                            ( ( ( nChannel == 0x50 ) ) && ( chip.nチャンネル番号 == nChannel ) )
							)
						)
					)
					{
						break;
					}
//				nIndex_NearestChip_Past--;
			}
			if ( ( nIndex_NearestChip_Future >= count ) && ( nIndex_NearestChip_Past < 0 ) )	// 検索対象が過去未来どちらにも見つからなかった場合
			{
				//sw2.Stop();
				return null;
			}
			CDTX.CChip nearestChip;	// = null;	// 以下のifブロックのいずれかで必ずnearestChipには非nullが代入されるので、null初期化を削除
			if ( nIndex_NearestChip_Future >= count )											// 検索対象が未来方向には見つからなかった(しかし過去方向には見つかった)場合
			{
				nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else if ( nIndex_NearestChip_Past < 0 )												// 検索対象が過去方向には見つからなかった(しかし未来方向には見つかった)場合
			{
				nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else
			{
				int nTimeDiff_Future = Math.Abs( (int) ( nTime - listChip[ nPlayer ][ nIndex_NearestChip_Future ].n発声時刻ms ) );
				int nTimeDiff_Past   = Math.Abs( (int) ( nTime - listChip[ nPlayer ][ nIndex_NearestChip_Past   ].n発声時刻ms ) );

                if( nChannel == 0xDF ) //0xDFの場合は過去方向への検索をしない
                {
                    return listChip[ nPlayer ][ nIndex_NearestChip_Future ];
                }

				if ( nTimeDiff_Future < nTimeDiff_Past )
				{
					nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}
				else
				{
					nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}
			}
			nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			if ( ( n検索範囲時間ms > 0 ) && ( nTimeDiff > n検索範囲時間ms ) )					// チップは見つかったが、検索範囲時間外だった場合
			{
				//sw2.Stop();
				return null;
			}
			//sw2.Stop();
			return nearestChip;
		}
		public bool r検索範囲内にチップがあるか調べる( long nTime, int nInputAdjustTime, int n検索範囲時間ms, int nPlayer )
		{
			nTime += nInputAdjustTime;

			for ( int i = 0; i < listChip[ nPlayer ].Count; i++ )
			{
				CDTX.CChip chip = listChip[ nPlayer ][ i ];
				if ( !chip.bHit )
				{
					if ( ( ( 0x11 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x14 ) ) || chip.nチャンネル番号 == 0x1A || chip.nチャンネル番号 == 0x1B )
					{
						if ( chip.n発声時刻ms < nTime + n検索範囲時間ms )
						{
                            if( chip.nコース == this.n現在のコース[ nPlayer ] ) //2016.06.14 kairera0467 譜面分岐も考慮するようにしてみる。
						        return true;
						}
					}
				}
			}
			
			return false;
		}

		protected void ChangeInputAdjustTimeInPlaying( IInputDevice keyboard, int plusminus )		// #23580 2011.1.16 yyagi UI for InputAdjustTime in playing screen.
		{
			int offset;
			if (keyboard.bキーが押されている((int) SlimDX.DirectInput.Key.LeftControl) ||
				keyboard.bキーが押されている((int) SlimDX.DirectInput.Key.RightControl))
			{
				offset = plusminus;
			}
			else
			{
				offset = plusminus * 10;
			}

		    var newInputAdjustTimeMs = (TJAPlayer3.ConfigIni.nInputAdjustTimeMs + offset).Clamp(-99, 99);
			TJAPlayer3.ConfigIni.nInputAdjustTimeMs = newInputAdjustTimeMs;
		}

		protected abstract void t入力処理_ドラム();
		protected abstract void ドラムスクロール速度アップ();
		protected abstract void ドラムスクロール速度ダウン();
		protected void tキー入力()
		{
			IInputDevice keyboard = TJAPlayer3.Input管理.Keyboard;
			if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.F1 ) &&
				( keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.RightShift ) || keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.LeftShift ) ) )
			{	// shift+f1 (pause)
                //this.bPAUSE = !this.bPAUSE;
                //if ( this.bPAUSE )
                //{
                //    CSound管理.rc演奏用タイマ.t一時停止();
                //    CDTXMania.Timer.t一時停止();
                //    CDTXMania.DTX.t全チップの再生一時停止();
                //}
                //else
                //{
                //    CSound管理.rc演奏用タイマ.t再開();
                //    CDTXMania.Timer.t再開();
                //    CDTXMania.DTX.t全チップの再生再開();
                //}
			}
			if ( ( !this.bPAUSE && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				this.t入力処理_ドラム();
				if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.UpArrow ) && ( keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.RightShift ) || keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.LeftShift ) ) )
				{	// shift (+ctrl) + UpArrow (BGMAdjust)
					TJAPlayer3.DTX.t各自動再生音チップの再生時刻を変更する( ( keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.LeftControl ) || keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.RightControl ) ) ? 1 : 10 );
					TJAPlayer3.DTX.tWave再生位置自動補正();
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.DownArrow ) && ( keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.RightShift ) || keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.LeftShift ) ) )
				{	// shift + DownArrow (BGMAdjust)
					TJAPlayer3.DTX.t各自動再生音チップの再生時刻を変更する( ( keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.LeftControl ) || keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.RightControl ) ) ? -1 : -10 );
					TJAPlayer3.DTX.tWave再生位置自動補正();
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.UpArrow ) )
				{	// UpArrow(scrollspeed up)
					ドラムスクロール速度アップ();
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.DownArrow ) )
				{	// DownArrow (scrollspeed down)
					ドラムスクロール速度ダウン();
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.Delete ) )
				{	// del (debug info)
					TJAPlayer3.ConfigIni.b演奏情報を表示する = !TJAPlayer3.ConfigIni.b演奏情報を表示する;
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.LeftArrow ) )		// #24243 2011.1.16 yyagi UI for InputAdjustTime in playing screen.
				{
					ChangeInputAdjustTimeInPlaying( keyboard, -1 );
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.RightArrow ) )		// #24243 2011.1.16 yyagi UI for InputAdjustTime in playing screen.
				{
					ChangeInputAdjustTimeInPlaying( keyboard, +1 );
				}
				else if ( ( base.eフェーズID == CStage.Eフェーズ.共通_通常状態 ) && ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.Escape ) || TJAPlayer3.Pad.b押されたGB( Eパッド.FT ) ) && !this.actPauseMenu.bIsActivePopupMenu )
				{	// escape (exit)
                    this.t演奏中止();
				}
                else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.D1 ) )
                {
                    if( this.n分岐した回数[ 0 ] < TJAPlayer3.DTX.listBRANCH.Count )
                        this.t分岐処理( 0, TJAPlayer3.DTX.listBRANCH[ this.n分岐した回数[ 0 ] ].n命令時のChipList番号, 0 );
                    TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化( this.n現在のコース[ 0 ], 0, 0 );
                    TJAPlayer3.stage演奏ドラム画面.actMtaiko.tBranchEvent( this.n現在のコース[ 0 ], 0, 0 );
                    this.n現在のコース[ 0 ] = 0;
                    this.n次回のコース[ 0 ] = 0;
                    this.b強制的に分岐させた[ 0 ] = true;
                }
                else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.D2 ) )		// #24243 2011.1.16 yyagi UI for InputAdjustTime in playing screen.
                {
                    if( this.n分岐した回数[ 0 ] < TJAPlayer3.DTX.listBRANCH.Count )
                        this.t分岐処理( 1, TJAPlayer3.DTX.listBRANCH[ this.n分岐した回数[ 0 ] ].n命令時のChipList番号, 0 );
                    TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化( this.n現在のコース[ 0 ], 1, 0 );
                    TJAPlayer3.stage演奏ドラム画面.actMtaiko.tBranchEvent( this.n現在のコース[ 0 ], 1, 0 );
                    this.n現在のコース[ 0 ] = 1;
                    this.n次回のコース[ 0 ] = 1;
                    this.b強制的に分岐させた[ 0 ] = true;
                }
                else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.D3 ) )		// #24243 2011.1.16 yyagi UI for InputAdjustTime in playing screen.
                {
                    if( this.n分岐した回数[ 0 ] < TJAPlayer3.DTX.listBRANCH.Count )
                        this.t分岐処理( 2, TJAPlayer3.DTX.listBRANCH[ this.n分岐した回数[ 0 ] ].n命令時のChipList番号, 0 );
                    TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化( this.n現在のコース[ 0 ], 2, 0 );
                    TJAPlayer3.stage演奏ドラム画面.actMtaiko.tBranchEvent( this.n現在のコース[ 0 ], 2, 0 );
                    this.n現在のコース[ 0 ] = 2;
                    this.n次回のコース[ 0 ] = 2;
                    this.b強制的に分岐させた[ 0 ] = true;
                }
                //else if (keyboard.bキーが押された((int)SlimDX.DirectInput.Key.D1))
                //{
                //    if (this.n分岐した回数[1] < CDTXMania.DTX.listBRANCH.Count)
                //        this.t分岐処理(0, CDTXMania.DTX.listBRANCH[this.n分岐した回数[1]].n命令時のChipList番号, 1);
                //    CDTXMania.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化(this.n現在のコース[1], 0, 1);
                //    CDTXMania.stage演奏ドラム画面.actMtaiko.tBranchEvent(this.n現在のコース[1], 1);
                //    this.n現在のコース[1] = 0;
                //    this.n次回のコース[1] = 0;
                //    this.b強制的に分岐させた = true;
                //}
                //else if (keyboard.bキーが押された((int)SlimDX.DirectInput.Key.D2))		// #24243 2011.1.16 yyagi UI for InputAdjustTime in playing screen.
                //{
                //    if (this.n分岐した回数[1] < CDTXMania.DTX.listBRANCH.Count)
                //        this.t分岐処理(1, CDTXMania.DTX.listBRANCH[this.n分岐した回数[1]].n命令時のChipList番号, 1);
                //    CDTXMania.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化(this.n現在のコース[1], 1, 1);
                //    CDTXMania.stage演奏ドラム画面.actMtaiko.tBranchEvent(this.n現在のコース[1], 1);
                //    this.n現在のコース[1] = 1;
                //    this.n次回のコース[1] = 1;
                //    this.b強制的に分岐させた = true;
                //}
                //else if (keyboard.bキーが押された((int)SlimDX.DirectInput.Key.D3))		// #24243 2011.1.16 yyagi UI for InputAdjustTime in playing screen.
                //{
                //    if (this.n分岐した回数[1] < CDTXMania.DTX.listBRANCH.Count)
                //        this.t分岐処理(2, CDTXMania.DTX.listBRANCH[this.n分岐した回数[0]].n命令時のChipList番号, 1);
                //    CDTXMania.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化(this.n現在のコース[1], 2, 1);
                //    CDTXMania.stage演奏ドラム画面.actMtaiko.tBranchEvent(this.n現在のコース[1], 2);
                //    this.n現在のコース[1] = 2;
                //    this.n次回のコース[1] = 2;
                //    this.b強制的に分岐させた = true;
                //}

				if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.F4 ) )
				{
                    if( TJAPlayer3.ConfigIni.bJudgeCountDisplay == false )
                        TJAPlayer3.ConfigIni.bJudgeCountDisplay = true;
                    else
                        TJAPlayer3.ConfigIni.bJudgeCountDisplay = false;
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.F5 ) )
				{
                    switch( TJAPlayer3.ConfigIni.eClipDispType  )
                    {
                        case EClipDispType.OFF:
                            TJAPlayer3.ConfigIni.eClipDispType = EClipDispType.背景のみ;
                            break;
                        case EClipDispType.背景のみ:
                            TJAPlayer3.ConfigIni.eClipDispType = EClipDispType.ウィンドウのみ;
                            break;
                        case EClipDispType.ウィンドウのみ:
                            TJAPlayer3.ConfigIni.eClipDispType = EClipDispType.両方;
                            break;
                        case EClipDispType.両方:
                            TJAPlayer3.ConfigIni.eClipDispType = EClipDispType.OFF;
                            break;
                    }
				}
#if DEBUG
                if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.F6 ) )
                {
                    if( CDTXMania.ConfigIni.b太鼓パートAutoPlay == false )
                        CDTXMania.ConfigIni.b太鼓パートAutoPlay = true;
                    else
                        CDTXMania.ConfigIni.b太鼓パートAutoPlay = false;
                }
                if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.F7 ) )
                {
                    if( CDTXMania.ConfigIni.b太鼓パートAutoPlay2P == false )
                        CDTXMania.ConfigIni.b太鼓パートAutoPlay2P = true;
                    else
                        CDTXMania.ConfigIni.b太鼓パートAutoPlay2P = false;
                }
#endif
			}
            if( !this.actPauseMenu.bIsActivePopupMenu && this.bPAUSE && ( ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.UpArrow ) )
				{	// UpArrow(scrollspeed up)
					ドラムスクロール速度アップ();
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.DownArrow ) )
				{	// DownArrow (scrollspeed down)
					ドラムスクロール速度ダウン();
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.Delete ) )
				{	// del (debug info)
					TJAPlayer3.ConfigIni.b演奏情報を表示する = !TJAPlayer3.ConfigIni.b演奏情報を表示する;
				}
            }

		    #region [ Minus & Equals Sound Group Level ]
		    KeyboardSoundGroupLevelControlHandler.Handle(
		        keyboard, TJAPlayer3.SoundGroupLevelController, TJAPlayer3.Skin, false);
		    #endregion
		}

		protected void t入力メソッド記憶( E楽器パート part )
		{
			if ( TJAPlayer3.Pad.st検知したデバイス.Keyboard )
			{
				this.b演奏にキーボードを使った[ (int) part ] = true;
			}
			if ( TJAPlayer3.Pad.st検知したデバイス.Joypad )
			{
				this.b演奏にジョイパッドを使った[ (int) part ] = true;
			}
			if ( TJAPlayer3.Pad.st検知したデバイス.MIDIIN )
			{
				this.b演奏にMIDI入力を使った[ (int) part ] = true;
			}
			if ( TJAPlayer3.Pad.st検知したデバイス.Mouse )
			{
				this.b演奏にマウスを使った[ (int) part ] = true;
			}
		}


		protected abstract void t進行描画_AVI();
		protected void t進行描画_AVI(int x, int y)
		{
			if ( ( ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) ) && ( !TJAPlayer3.ConfigIni.bストイックモード && TJAPlayer3.ConfigIni.bAVI有効 ) )
			{
				this.actAVI.t進行描画( x, y );
			}
		}
		protected abstract void t進行描画_DANGER();
		protected void t進行描画_MIDIBGM()
		{
			if ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED )
			{
				CStage.Eフェーズ eフェーズid1 = base.eフェーズID;
			}
		}
		protected void t進行描画_STAGEFAILED()
		{
			if ( ( ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED ) || ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) ) && ( ( this.actStageFailed.On進行描画() != 0 ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) ) )
			{
				this.eフェードアウト完了時の戻り値 = E演奏画面の戻り値.ステージ失敗;
				base.eフェーズID = CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト;
				this.actFO.tフェードアウト開始();
			}
		}

		protected void t進行描画_チップファイアGB()
		{
			this.actChipFireGB.On進行描画();
		}
		protected abstract void t進行描画_パネル文字列();
		protected void t進行描画_パネル文字列( int x, int y )
		{
			if ( ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				this.actPanel.t進行描画( x, y );
			}
		}
		protected void tパネル文字列の設定()
		{
		    // When performing calibration, inform the player that
		    // calibration is taking place, rather than
		    // displaying the panel title or song title as usual.

		    var panelString = TJAPlayer3.IsPerformingCalibration
		        ? "Calibrating input..."
		        : string.IsNullOrEmpty( TJAPlayer3.DTX.PANEL ) ? TJAPlayer3.DTX.TITLE: TJAPlayer3.DTX.PANEL;

		    this.actPanel.SetPanelString( panelString, TJAPlayer3.stage選曲.str確定された曲のジャンル, TJAPlayer3.Skin.Game_StageText );
		}


		protected void t進行描画_ゲージ()
		{
			if ( ( ( ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) ) ) )
			{
				this.actGauge.On進行描画();
			}
		}
		protected void t進行描画_コンボ()
		{
			this.actCombo.On進行描画();
		}
		protected void t進行描画_スコア()
		{
			this.actScore.On進行描画();
		}
		protected void t進行描画_ステータスパネル()
		{
			this.actStatusPanels.On進行描画();
		}
        protected bool t進行描画_チップ( E楽器パート ePlayMode )
        {
            return this.t進行描画_チップ( ePlayMode, 0 );
        }
		protected bool t進行描画_チップ( E楽器パート ePlayMode, int nPlayer )
		{
			if ( ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED ) || ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				return true;
			}
			if ( ( this.n現在のトップChip == -1 ) || ( this.n現在のトップChip >= listChip[ nPlayer ].Count ) )
			{
				return true;
			}
            if (IsDanFailed)
            {
                return true;
            }

			var n現在時刻ms = CSound管理.rc演奏用タイマ.n現在時刻ms;

			if( this.r指定時刻に一番近い未ヒットChip( (long)n現在時刻ms, 0x50, 0, 1000000, nPlayer ) == null )
            {
                this.actChara.b演奏中 = false;
            }

			var db現在の譜面スクロール速度 = this.act譜面スクロール速度.db現在の譜面スクロール速度;

			//double speed = 264.0;	// BPM150の時の1小節の長さ[dot]
			const double speed = 324.0;	// BPM150の時の1小節の長さ[dot]

			double ScrollSpeedDrums = (( db現在の譜面スクロール速度.Drums + 1.0 ) * speed ) * 0.5 * 37.5 / 60000.0;
			double ScrollSpeedGuitar = ( db現在の譜面スクロール速度.Guitar + 1.0 ) * 0.5 * 0.5 * 37.5 * speed / 60000.0;
			double ScrollSpeedBass = ( db現在の譜面スクロール速度.Bass + 1.0 ) * 0.5 * 0.5 * 37.5 * speed / 60000.0;
            double ScrollSpeedTaiko = (( db現在の譜面スクロール速度.Drums + 1.0 ) * speed ) * 0.5 * 37.5 / 60000.0;

			CConfigIni configIni = TJAPlayer3.ConfigIni;

			CDTX dTX = TJAPlayer3.DTX;
            bool bAutoPlay = false;
            switch( nPlayer ) //2017.08.11 kairera0467
            {
                case 0:
                    bAutoPlay = configIni.b太鼓パートAutoPlay;
                    break;
                case 1:
                    bAutoPlay = configIni.b太鼓パートAutoPlay2P;
                    dTX = TJAPlayer3.DTX_2P;
                    break;
                default:
                    break;
            }

            if( this.n分岐した回数[ nPlayer ] == 0 )
            {
                this.bUseBranch[ nPlayer ] = dTX.bHIDDENBRANCH ? false : dTX.bチップがある.Branch;
            }


            //CDTXMania.act文字コンソール.tPrint(0, 0, C文字コンソール.Eフォント種別.灰, this.nLoopCount_Clear.ToString()  );

            float? play_bpm_time = null;

            //for ( int nCurrentTopChip = this.n現在のトップChip; nCurrentTopChip < dTX.listChip.Count; nCurrentTopChip++ )
            for ( int nCurrentTopChip = dTX.listChip.Count - 1; nCurrentTopChip > 0; nCurrentTopChip-- )
			{
				CDTX.CChip pChip = dTX.listChip[ nCurrentTopChip ];
//Debug.WriteLine( "nCurrentTopChip=" + nCurrentTopChip + ", ch=" + pChip.nチャンネル番号.ToString("x2") + ", 発音位置=" + pChip.n発声位置 + ", 発声時刻ms=" + pChip.n発声時刻ms );
				var time = pChip.n発声時刻ms - n現在時刻ms;
				pChip.nバーからの距離dot.Drums = (int) ( time * ScrollSpeedDrums );
				pChip.nバーからの距離dot.Guitar = (int) ( time * ScrollSpeedGuitar );
				pChip.nバーからの距離dot.Bass = (int) ( time * ScrollSpeedBass );
                pChip.nバーからの距離dot.Taiko = (int) ( ( time * pChip.dbBPM * pChip.dbSCROLL * (db現在の譜面スクロール速度.Drums + 1.5 ) ) / 628.7 );
                pChip.nバーからのノーツ末端距離dot.Drums = 0;
                pChip.nバーからのノーツ末端距離dot.Guitar = 0;
                pChip.nバーからのノーツ末端距離dot.Bass = 0;
                if( pChip.nノーツ終了時刻ms != 0 )
                    pChip.nバーからのノーツ末端距離dot.Taiko = (int) ( ( ( pChip.nノーツ終了時刻ms - n現在時刻ms) * pChip.dbBPM * pChip.dbSCROLL * (db現在の譜面スクロール速度.Drums + 1.5 ) ) / 628.7 );

                if( configIni.eScrollMode == EScrollMode.BMSCROLL || configIni.eScrollMode == EScrollMode.HBSCROLL )
                {
                    if( !play_bpm_time.HasValue )
                    {
                        play_bpm_time = this.GetNowPBMTime( dTX, 0 );
                    }

                    var dbSCROLL = configIni.eScrollMode == EScrollMode.BMSCROLL ? 1.0 : pChip.dbSCROLL;

                    pChip.nバーからの距離dot.Taiko = (int)( ( ( pChip.fBMSCROLLTime * NOTE_GAP ) - ( play_bpm_time * NOTE_GAP ) ) * dbSCROLL * ( db現在の譜面スクロール速度.Drums + 1.5 ) );
                    if( pChip.nノーツ終了時刻ms != 0 )
                        pChip.nバーからのノーツ末端距離dot.Taiko = (int)( ( ( pChip.fBMSCROLLTime_end * NOTE_GAP) - ( play_bpm_time * NOTE_GAP ) ) * pChip.dbSCROLL * ( db現在の譜面スクロール速度.Drums + 1.5 ) );
                }

				int instIndex = (int) pChip.e楽器パート;

                if (!pChip.bHit)
                {
                    if( pChip.nチャンネル番号 >= 0x11 && pChip.nチャンネル番号 <= 0x14 || pChip.nチャンネル番号 == 0x1A || pChip.nチャンネル番号 == 0x1B )//|| pChip.nチャンネル番号 == 0x9A )
                    {
                        if ( ( pChip.n発声時刻ms + 120 ) < n現在時刻ms )
                        {
                            if ( this.e指定時刻からChipのJUDGEを返す( n現在時刻ms, pChip ) == E判定.Miss )
                            //( ( pChip.nバーからの距離dot.Taiko < -40 ) && ( this.e指定時刻からChipのJUDGEを返す( CSound管理.rc演奏用タイマ.n現在時刻, pChip, nInputAdjustTime ) == E判定.Miss ) ) )
                            {
                                this.tチップのヒット処理( n現在時刻ms, pChip, E楽器パート.TAIKO, false, 0, nPlayer );
                                pChip.eNoteState = ENoteState.bad;
                            }
                        }
                    }
                }

                if( pChip.nバーからの距離dot[ instIndex ] < -150 )
                {
                    if( !( pChip.nチャンネル番号 >= 0x11 && pChip.nチャンネル番号 <= 0x14 ) || pChip.nチャンネル番号 == 0x1A || pChip.nチャンネル番号 == 0x1B )
                    {
                        //2016.02.11 kairera0467
                        //太鼓の単音符の場合は座標による判定を行わない。
                        //(ここで判定をすると高スピードでスクロールしている時に見逃し不可判定が行われない。)
                        pChip.bHit = true;
                    }
                }

                var cChipCurrentlyInProcess = chip現在処理中の連打チップ[ nPlayer ];
                if( cChipCurrentlyInProcess != null && !cChipCurrentlyInProcess.bHit )
                {
                    if( cChipCurrentlyInProcess.nチャンネル番号 >= 0x13 && cChipCurrentlyInProcess.nチャンネル番号 <= 0x15 )//|| pChip.nチャンネル番号 == 0x9A )
                    {
				        if ( ( ( cChipCurrentlyInProcess.nバーからの距離dot.Taiko < -500 ) && ( cChipCurrentlyInProcess.n発声時刻ms <= n現在時刻ms && cChipCurrentlyInProcess.nノーツ終了時刻ms >= n現在時刻ms ) ) )
                           //( ( chip現在処理中の連打チップ.nバーからのノーツ末端距離dot.Taiko < -500 ) && ( chip現在処理中の連打チップ.n発声時刻ms <= CSound管理.rc演奏用タイマ.n現在時刻ms && chip現在処理中の連打チップ.nノーツ終了時刻ms >= CSound管理.rc演奏用タイマ.n現在時刻ms ) ) )
                           //( ( pChip.n発声時刻ms <= CSound管理.rc演奏用タイマ.n現在時刻ms && pChip.nノーツ終了時刻ms >= CSound管理.rc演奏用タイマ.n現在時刻ms ) ) )
		    		    {
                            if( bAutoPlay )
    		    		        this.tチップのヒット処理( n現在時刻ms, cChipCurrentlyInProcess, E楽器パート.TAIKO, false, 0, nPlayer );
	    		    	}
                    }
                }
                
				switch ( pChip.nチャンネル番号 )
				{
					#region [ 01: BGM ]
					case 0x01:	// BGM
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							if ( configIni.bBGM音を発声する )
							{
								dTX.tチップの再生( pChip, CSound管理.rc演奏用タイマ.n前回リセットした時のシステム時刻 + pChip.n発声時刻ms, (int) Eレーン.BGM );
							}
						}
						break;
					#endregion
					#region [ 03: BPM変更 ]
					case 0x03:	// BPM変更
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							this.actPlayInfo.dbBPM = ( ( ( (double) configIni.n演奏速度 ) / 20.0 ) ) * dTX.BASEBPM; //2016.07.10 kairera0467 太鼓の仕様にあわせて修正。(そもそもの仕様が不明&コードミス疑惑)
						}
						break;
					#endregion
					#region [ 04, 07: EmptySlot ]
					case 0x04:
					case 0x07:
						break;
					#endregion
					#region [ 08: BPM変更(拡張) ]
					case 0x08:	// BPM変更(拡張)
                        //CDTXMania.act文字コンソール.tPrint( 414 + pChip.nバーからの距離dot.Drums + 4, 192, C文字コンソール.Eフォント種別.白, "BRANCH START" + "  " + pChip.n整数値.ToString() );
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
                            //if( pChip.nコース == this.n現在のコース[ nPlayer ] )
                            //{
							    //if ( dTX.listBPM.ContainsKey( pChip.n整数値_内部番号 ) )
							    //{
								    //this.actPlayInfo.dbBPM = ( dTX.listBPM[ pChip.n整数値_内部番号 ].dbBPM値 * ( ( (double) configIni.n演奏速度 ) / 20.0 ) );// + dTX.BASEBPM;
							    //}
                                //double bpm = ( dTX.listBPM[ pChip.n整数値_内部番号 ].dbBPM値 * ( ( (double) configIni.n演奏速度 ) / 20.0 ) );
                                //int nUnit = (int)((60.0 / ( bpm ) / this.actChara.nキャラクター通常モーション枚数 ) * 1000 );
                                //int nUnit_gogo = (int)((60.0 / ( bpm ) / this.actChara.nキャラクターゴーゴーモーション枚数 ) * 1000 );
                                //this.actChara.ct通常モーション = new CCounter( 0, this.actChara.nキャラクター通常モーション枚数 - 1, nUnit, CDTXMania.Timer );
                                //this.actChara.ctゴーゴーモーション = new CCounter(0, this.actChara.nキャラクターゴーゴーモーション枚数 - 1, nUnit_gogo * 2, CDTXMania.Timer);

                            //}
						}
						break;
					#endregion

					#region [ 11-1f: 太鼓1P ]
					case 0x11:
					case 0x12:
					case 0x13:
					case 0x14:
                        {
                            this.t進行描画_チップ_Taiko( configIni, ref dTX, ref pChip, nPlayer );
                        }
                        break;

					case 0x15:
					case 0x16:
					case 0x17:
                        {
                            //2015.03.28 kairera0467
                            //描画順序を変えるため、メイン処理だけをこちらに残して描画処理は分離。

                            //this.t進行描画_チップ_Taiko連打(configIni, ref dTX, ref pChip);
                            //2015.04.13 kairera0467 ここを外さないと恋文2000の連打に対応できず、ここをつけないと他のコースと重なっている連打をどうにもできない。
                            //常時実行メソッドに渡したら対応できた!?
                            //if ((!pChip.bHit && (pChip.nバーからの距離dot.Drums < 0)))
                            {
                                if( ( pChip.n発声時刻ms <= (int)n現在時刻ms && pChip.nノーツ終了時刻ms >= (int)n現在時刻ms ) )
                                {
                                    //if( this.n現在のコース == pChip.nコース )
                                    if( pChip.b可視 == true )
                                        this.chip現在処理中の連打チップ[ nPlayer ] = pChip;
                                }
                            }
                            if (pChip.n描画優先度 <= 0)
                                this.t進行描画_チップ_Taiko連打(configIni, ref dTX, ref pChip, nPlayer);
                        }

                        break;
                    case 0x18:
                        {
                            if( ( !pChip.bHit && (pChip.nバーからの距離dot.Drums < 0 ) ) )
                            {
                                this.b連打中[ nPlayer ] = false;
                                this.actRoll.b表示[ nPlayer ] = false;
                                this.actChara.b風船連打中 = false;
                                pChip.bHit = true;
                                if( chip現在処理中の連打チップ[ nPlayer ] != null )
                                    chip現在処理中の連打チップ[ nPlayer ].bHit = true;
                                this.eRollState = E連打State.none;
                            }
                            if( pChip.n描画優先度 <= 0 )
                                this.t進行描画_チップ_Taiko連打(configIni, ref dTX, ref pChip, nPlayer);
                        }

                        break;
					case 0x19:
                    case 0x1c:
                    case 0x1d:
                    case 0x1e:
                        break;

					case 0x1a:
                    case 0x1b:
					case 0x1f:
                        {
                            this.t進行描画_チップ_Taiko( configIni, ref dTX, ref pChip, nPlayer );
                        }
						break;
					#endregion
					#region [ 20-2F: EmptySlot ]
					case 0x20:
					case 0x21:
					case 0x22:
					case 0x23:
					case 0x24:
					case 0x25:
					case 0x26:
					case 0x27:
					case 0x28:
                    case 0x29:
                    case 0x2a:
                    case 0x2b:
                    case 0x2c:
                    case 0x2d:
                    case 0x2e:
                    case 0x2f:
						break;
					#endregion
					#region [ 31-3f: EmptySlot ]
					case 0x31:
					case 0x32:
					case 0x33:
					case 0x34:
					case 0x35:
					case 0x36:
					case 0x37:
					case 0x38:
					case 0x39:
					case 0x3a:
                    case 0x3b:
                    case 0x3c:
                    case 0x3d:
                    case 0x3e:
                    case 0x3f:
						break;
					#endregion

					#region [ 50: 小節線 ]
					case 0x50:	// 小節線
						{
                            if ( !pChip.bHit && ( pChip.nバーからの距離dot.Taiko < 0 ) )
						    {
                                this.actChara.b演奏中 = true;
                                if( this.actPlayInfo.n小節番号 == 0 )
                                {
                                    for (int i = 0; i < 2; i++)
                                    {
                                        ctChipAnime[i] = new CCounter(0, 3, 60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM * 1 / 4, CSound管理.rc演奏用タイマ);
                                    }

                                    if (TJAPlayer3.Skin.Game_Chara_Ptn_Normal != 0)
                                    {
                                        double dbPtn_Normal = (60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM) * TJAPlayer3.Skin.Game_Chara_Beat_Normal / this.actChara.arモーション番号.Length;
                                        this.actChara.ctChara_Normal = new CCounter(0, this.actChara.arモーション番号.Length - 1, dbPtn_Normal, CSound管理.rc演奏用タイマ);
                                    }
                                    else
                                    {
                                        this.actChara.ctChara_Normal = new CCounter();
                                    }
                                    if (TJAPlayer3.Skin.Game_Chara_Ptn_Clear != 0)
                                    {
                                        double dbPtn_Clear = (60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM) * TJAPlayer3.Skin.Game_Chara_Beat_Clear / this.actChara.arクリアモーション番号.Length;
                                        this.actChara.ctChara_Clear = new CCounter(0, this.actChara.arクリアモーション番号.Length - 1, dbPtn_Clear, CSound管理.rc演奏用タイマ);
                                    }
                                    else
                                    {
                                        this.actChara.ctChara_Clear = new CCounter();
                                    }
                                    if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGo != 0)
                                    {
                                        double dbPtn_GoGo = (60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM) * TJAPlayer3.Skin.Game_Chara_Beat_GoGo / this.actChara.arゴーゴーモーション番号.Length;
                                        this.actChara.ctChara_GoGo = new CCounter(0, this.actChara.arゴーゴーモーション番号.Length - 1, dbPtn_GoGo, CSound管理.rc演奏用タイマ);
                                    }
                                    else
                                    {
                                        this.actChara.ctChara_GoGo = new CCounter();
                                    }
                                    this.ct制御タイマ = new CCounter(0, 10, 500, CSound管理.rc演奏用タイマ);
                                    if (TJAPlayer3.Skin.Game_Dancer_Ptn != 0)
                                    {
                                        double dbUnit_dancer = (((60 / (TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM))) / this.actDancer.ar踊り子モーション番号.Length);
                                        this.actDancer.ct踊り子モーション = new CCounter(0, this.actDancer.ar踊り子モーション番号.Length - 1, dbUnit_dancer * TJAPlayer3.Skin.Game_Dancer_Beat, CSound管理.rc演奏用タイマ);
                                    }
                                    else
                                    {
                                        this.actDancer.ct踊り子モーション = new CCounter();
                                    }
                                    if (TJAPlayer3.Skin.Game_Mob_Ptn != 0 && TJAPlayer3.Skin.Game_Mob_Beat > 0 ) //2018.6.15 Game_Mob_Beatが0のままCCounter生成をされて無限ループが発生しないよう対策
                                    {
                                        this.actMob.ctMob = new CCounter(1, 180, 60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM * TJAPlayer3.Skin.Game_Mob_Beat / 180, CSound管理.rc演奏用タイマ);
                                        this.actMob.ctMobPtn = new CCounter(0, TJAPlayer3.Skin.Game_Mob_Ptn - 1, 60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM * TJAPlayer3.Skin.Game_Mob_Ptn_Beat / TJAPlayer3.Skin.Game_Mob_Ptn, CSound管理.rc演奏用タイマ);
                                    }
                                    else
                                    {
                                        this.actMob.ctMob = new CCounter();
                                        this.actMob.ctMobPtn = new CCounter();
                                    }
                                    TJAPlayer3.stage演奏ドラム画面.PuchiChara.ChangeBPM(60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM);

                                    //this.actChara.ctChara_Normal = new CCounter( 0, this.actChara.arモーション番号.Length - 1, dbPtn_Normal, CSound管理.rc演奏用タイマ );
                                    //this.actChara.ctChara_GoGo = new CCounter( 0, this.actChara.arゴーゴーモーション番号.Length - 1, dbPtn_GoGo, CSound管理.rc演奏用タイマ );
                                    //this.actChara.ctChara_Clear = new CCounter( 0, this.actChara.arクリアモーション番号.Length - 1, dbPtn_Clear, CSound管理.rc演奏用タイマ );

                                    //this.ct制御タイマ = new CCounter(0, 10, 500, CSound管理.rc演奏用タイマ);

                                    //for (int i = 0; i < 2; i++)
                                    //{
                                    //    ctChipAnime[i] = new CCounter(0, 3, 60.0 / CDTXMania.stage演奏ドラム画面.actPlayInfo.dbBPM * 1 / 4, CSound管理.rc演奏用タイマ);
                                    //}

                                    ////this.actChara.ctChara_Normal.db現在の値 = 0;

                                    ////this.actDancer.ct通常モーション = new CCounter( 0, this.actDancer.arモーション番号_通常.Length - 1, ( dbUnit * 4.0) / this.actDancer.arモーション番号_通常.Length, CSound管理.rc演奏用タイマ );

                                    //// ↓踊り子・モブ↓
                                    //this.actDancer.ct踊り子モーション = new CCounter(0, this.actDancer.ar踊り子モーション番号.Length - 1, (dbUnit * CDTXMania.Skin.Game_Dancer_Beat) / this.actDancer.ar踊り子モーション番号.Length, CSound管理.rc演奏用タイマ);
                                    ////this.actChara.ctモブモーション = new CCounter(0, this.actChara.arモブモーション番号.Length - 1, (dbUnit) / this.actChara.arモブモーション番号.Length, CSound管理.rc演奏用タイマ);
                                    //this.actDancer.ct踊り子モーション.db現在の値 = 0;
                                    ////this.actChara.ctモブモーション.db現在の値 = 0;
                                    //this.actMob.ctMob = new CCounter(1, 180, 60.0 / CDTXMania.stage演奏ドラム画面.actPlayInfo.dbBPM * CDTXMania.Skin.Game_Mob_Beat / 180, CSound管理.rc演奏用タイマ);
                                    //this.actMob.ctMobPtn = new CCounter(0, CDTXMania.Skin.Game_Mob_Ptn - 1, 60.0 / CDTXMania.stage演奏ドラム画面.actPlayInfo.dbBPM * CDTXMania.Skin.Game_Mob_Ptn_Beat / CDTXMania.Skin.Game_Mob_Ptn, CSound管理.rc演奏用タイマ);
                                    //// ↑踊り子・モブ↑
                                    ////this.actDancer.ctモブ = new CCounter( 1.0, 16.0, (( dbUnit / 16.0 )), CSound管理.rc演奏用タイマ );

                                    //if (CDTXMania.Skin.Game_Chara_Ptn_Clear != 0 )
                                    //{
                                    //    double dbUnit_max = ( ( ( 60.0 / ( CDTXMania.stage演奏ドラム画面.actPlayInfo.dbBPM ) ) ) / this.actChara.arクリアモーション番号.Length );
                                    //    this.actChara.ctChara_Clear = new CCounter( 0, this.actChara.arクリアモーション番号.Length - 1, dbPtn_Clear, CSound管理.rc演奏用タイマ );
                                    //}
                                    //if(CDTXMania.Skin.Game_Chara_Ptn_GoGo != 0 )
                                    //{
                                    //    double dbUnit_max_gogo = ( ( ( 60.0 / ( CDTXMania.stage演奏ドラム画面.actPlayInfo.dbBPM ) ) ) / this.actChara.arゴーゴーモーション番号.Length );
                                    //    this.actChara.ctChara_GoGo = new CCounter( 0, this.actChara.arゴーゴーモーション番号.Length - 1, dbPtn_GoGo, CSound管理.rc演奏用タイマ );
                                    //}
                                }
                                if ( pChip.nコース == this.n現在のコース[ nPlayer ] )
                                    this.actPlayInfo.n小節番号++;
                                pChip.bHit = true;
                            }
                            this.t進行描画_チップ_小節線( configIni, ref dTX, ref pChip, nPlayer );
							break;
						}
					#endregion
					#region [ 51: 拍線 ]
					case 0x51:	// 拍線
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
						}
                        //太鼓では拍線を使わない。
						//this.txチップ.t2D描画( CDTXMania.app.Device, 295, configIni.bReverse.Drums ? ( ( 0x38 + pChip.nバーからの距離dot.Drums ) - 1 ) : ( ( 567 - pChip.nバーからの距離dot.Drums ) - 1 ), new Rectangle( 0, 772, 559, 2 ) );

                        //this.t進行描画_チップ_小節線( configIni, ref dTX, ref pChip );
						break;
					#endregion
					#region [ 52-53: EmptySlot ]
					case 0x52:
						break;
					#endregion
					#region [ 54: 動画再生 ]
					case 0x54:	// 動画再生
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							if ( configIni.bAVI有効 )
							{
								switch ( pChip.eAVI種別 )
								{
									case EAVI種別.AVI:
										if ( pChip.rAVI != null )
										{
											this.actAVI.Start( pChip.nチャンネル番号, pChip.rAVI, pChip.rDShow, 278, 355, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, pChip.n発声時刻ms );
										}
										break;
									case EAVI種別.Unknown:
										if ( pChip.rAVI != null || pChip.rDShow != null )
										{
											this.actAVI.Start( pChip.nチャンネル番号, pChip.rAVI, pChip.rDShow, 278, 355, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, pChip.n発声時刻ms );
										}
										break;
								}
							}
						}
						break;
					#endregion
                    #region[ 55-60: EmptySlot ]
                    case 0x55:
                    case 0x56:
                    case 0x57:
                    case 0x58:
                    case 0x59:
                        break;
                    #endregion
                    #region [ 61-89: EmptySlot ]
                    case 0x60:
                    case 0x61:
					case 0x62:
					case 0x63:
					case 0x64:
					case 0x65:
					case 0x66:
					case 0x67:
					case 0x68:
					case 0x69:
					case 0x70:
					case 0x71:
					case 0x72:
					case 0x73:
					case 0x74:
					case 0x75:
					case 0x76:
					case 0x77:
					case 0x78:
					case 0x79:
					case 0x80:
					case 0x81:
					case 0x82:
					case 0x83:
                    case 0x84:
                    case 0x85:
                    case 0x86:
                    case 0x87:
                    case 0x88:
                    case 0x89:
                        break;
					#endregion

                    #region[ 90-9A: EmptySlot ]
                    case 0x90:
					case 0x91:
					case 0x92:
                    case 0x93:
                    case 0x94:
                    case 0x95:
                    case 0x96:
                    case 0x97:
                    case 0x98:
                    case 0x99:
                    case 0x9A:
						break;
                    #endregion

                    #region[ 9B-9F: 太鼓 ]
                    case 0x9B:
                        // 段位認定モードの幕アニメーション
                        if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0))
                        {
                            pChip.bHit = true;
                            if (pChip.nコース == this.n現在のコース[nPlayer])
                            {
                                if (this.actDan.GetFailedAllChallenges())
                                {
                                    this.n現在のトップChip = TJAPlayer3.DTX.listChip.Count - 1;	// 終端にシーク
                                    IsDanFailed = true;
                                    return true;
                                }
                                this.actDan.Start(this.ListDan_Number);
                                ListDan_Number++;
                            }
                        }
                        break;
                    //0x9C BPM変化(アニメーション用)
                    case 0x9C:
                        //CDTXMania.act文字コンソール.tPrint( 414 + pChip.nバーからの距離dot.Taiko + 8, 192, C文字コンソール.Eフォント種別.白, "BPMCHANGE" );
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
                            if( pChip.nコース == this.n現在のコース[ nPlayer ] )
                            {
							    if ( dTX.listBPM.TryGetValue( pChip.n整数値_内部番号, out CDTX.CBPM cBPM ) )
							    {
                                    this.actPlayInfo.dbBPM = cBPM.dbBPM値 * ( ( (double) configIni.n演奏速度 ) / 20.0 );// + dTX.BASEBPM;
							    }


                                for (int i = 0; i < 2; i++)
                                {
                                    ctChipAnime[i] = new CCounter(0, 3, 60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM * 1 / 4, CSound管理.rc演奏用タイマ);
                                }

                                if (TJAPlayer3.Skin.Game_Chara_Ptn_Normal != 0)
                                {
                                    double dbPtn_Normal = (60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM) * TJAPlayer3.Skin.Game_Chara_Beat_Normal / this.actChara.arモーション番号.Length;
                                    this.actChara.ctChara_Normal = new CCounter(0, this.actChara.arモーション番号.Length - 1, dbPtn_Normal, CSound管理.rc演奏用タイマ);
                                } else
                                {
                                    this.actChara.ctChara_Normal = new CCounter();
                                }
                                if (TJAPlayer3.Skin.Game_Chara_Ptn_Clear != 0)
                                {
                                    double dbPtn_Clear = (60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM) * TJAPlayer3.Skin.Game_Chara_Beat_Clear / this.actChara.arクリアモーション番号.Length;
                                    this.actChara.ctChara_Clear = new CCounter(0, this.actChara.arクリアモーション番号.Length - 1, dbPtn_Clear, CSound管理.rc演奏用タイマ);
                                }
                                else
                                {
                                    this.actChara.ctChara_Clear = new CCounter();
                                }
                                if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGo != 0)
                                {
                                    double dbPtn_GoGo = (60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM) * TJAPlayer3.Skin.Game_Chara_Beat_GoGo / this.actChara.arゴーゴーモーション番号.Length;
                                    this.actChara.ctChara_GoGo = new CCounter(0, this.actChara.arゴーゴーモーション番号.Length - 1, dbPtn_GoGo, CSound管理.rc演奏用タイマ);
                                } else
                                {
                                    this.actChara.ctChara_GoGo = new CCounter();
                                }
                                this.ct制御タイマ = new CCounter(0, 10, 500, CSound管理.rc演奏用タイマ);
                                if (TJAPlayer3.Skin.Game_Dancer_Ptn != 0)
                                {
                                    double dbUnit_dancer = (((60 / (TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM))) / this.actDancer.ar踊り子モーション番号.Length);
                                    this.actDancer.ct踊り子モーション = new CCounter(0, this.actDancer.ar踊り子モーション番号.Length - 1, dbUnit_dancer * TJAPlayer3.Skin.Game_Dancer_Beat, CSound管理.rc演奏用タイマ);
                                }
                                else
                                {
                                    this.actDancer.ct踊り子モーション = new CCounter();
                                }
                                if (TJAPlayer3.Skin.Game_Mob_Ptn != 0)
                                {
                                    this.actMob.ctMob = new CCounter(1, 180, 60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM * TJAPlayer3.Skin.Game_Mob_Beat / 180, CSound管理.rc演奏用タイマ);
                                    this.actMob.ctMobPtn = new CCounter(0, TJAPlayer3.Skin.Game_Mob_Ptn - 1, 60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM * TJAPlayer3.Skin.Game_Mob_Ptn_Beat / TJAPlayer3.Skin.Game_Mob_Ptn, CSound管理.rc演奏用タイマ);
                                } else
                                {
                                    this.actMob.ctMob = new CCounter();
                                    this.actMob.ctMobPtn = new CCounter();
                                }

                                TJAPlayer3.stage演奏ドラム画面.PuchiChara.ChangeBPM(60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM);
                                //this.actDancer.ct踊り子モーション = new CCounter(0, this.actDancer.ar踊り子モーション番号.Length - 1, (dbUnit * CDTXMania.Skin.Game_Dancer_Beat) / this.actDancer.ar踊り子モーション番号.Length, CSound管理.rc演奏用タイマ);
                                //this.actChara.ctモブモーション = new CCounter(0, this.actChara.arモブモーション番号.Length - 1, (dbUnit) / this.actChara.arモブモーション番号.Length, CSound管理.rc演奏用タイマ);
                                //#if C_82D982F182AF82CD82A282AF82A2
                                /*
                                 * for( int dancer = 0; dancer < 5; dancer++ )
                                    this.actDancer.st投げ上げ[ dancer ].ct進行 = new CCounter( 0, this.actDancer.arモーション番号_登場.Length - 1, dbUnit / this.actDancer.arモーション番号_登場.Length, CSound管理.rc演奏用タイマ );

                                this.actDancer.ct通常モーション = new CCounter( 0, this.actDancer.arモーション番号_通常.Length - 1, ( dbUnit * 4 ) / this.actDancer.arモーション番号_通常.Length, CSound管理.rc演奏用タイマ );
                                this.actDancer.ctモブ = new CCounter( 1.0, 16.0, (int)((60.0 / bpm / 16.0 ) * 1000 ), CSound管理.rc演奏用タイマ );
//#endif
                               */
                            }

                        }
                        break;

                    case 0x9D: //SCROLL
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							//if ( dTX.listSCROLL.ContainsKey( pChip.n整数値_内部番号 ) )
							//{
								//this.actPlayInfo.dbBPM = ( dTX.listBPM[ pChip.n整数値_内部番号 ].dbBPM値 * ( ( (double) configIni.n演奏速度 ) / 20.0 ) );// + dTX.BASEBPM;
							//}
						}
                        break;

                    case 0x9E: //ゴーゴータイム
                        if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
                        {
                            pChip.bHit = true;
                            this.bIsGOGOTIME[ nPlayer ] = true;
                            //double dbUnit = (((60.0 / (CDTXMania.stage演奏ドラム画面.actPlayInfo.dbBPM))));
                            double dbUnit = (((60.0 / pChip.dbBPM)));
                            if(nPlayer == 0)
                            {
                                if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart != 0 && nPlayer == 0 && actChara.CharaAction_Balloon_Delay.b終了値に達した)
                                {
                                    if (TJAPlayer3.stage演奏ドラム画面.actGauge.db現在のゲージ値[0] < 100)
                                    {
                                        // 魂ゲージMAXではない
                                        // ゴーゴースタート_ノーマル
                                        this.actChara.アクションタイマーリセット();
                                        this.actChara.ctキャラクターアクション_ゴーゴースタート = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart - 1, (dbUnit / TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart) * 2, CSound管理.rc演奏用タイマ);
                                        this.actChara.ctキャラクターアクション_ゴーゴースタート.t進行db();
                                        this.actChara.ctキャラクターアクション_ゴーゴースタート.db現在の値 = 0D;
                                        this.actChara.bマイどんアクション中 = true;
                                        //this.actChara.マイどん_アクション_10コンボ();
                                    }
                                }
                                if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max != 0 && nPlayer == 0 && actChara.CharaAction_Balloon_Delay.b終了値に達した)
                                {
                                    if (TJAPlayer3.stage演奏ドラム画面.actGauge.db現在のゲージ値[0] >= 100)
                                    {
                                        // 魂ゲージMAX
                                        // ゴーゴースタート_MAX
                                        this.actChara.アクションタイマーリセット();
                                        this.actChara.ctキャラクターアクション_ゴーゴースタートMAX = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max - 1, (dbUnit / TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max) * 2, CSound管理.rc演奏用タイマ);
                                        this.actChara.ctキャラクターアクション_ゴーゴースタートMAX.t進行db();
                                        this.actChara.ctキャラクターアクション_ゴーゴースタートMAX.db現在の値 = 0D;
                                        this.actChara.bマイどんアクション中 = true;
                                    }
                                }

                            }
                            TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.GOGOSTART();
                        }
                        break;
                    case 0x9F: //ゴーゴータイム
                        if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
                        {
                            pChip.bHit = true;
                            this.bIsGOGOTIME[ nPlayer ] = false;
                        }
                        break;
                    #endregion

					#region [ a0-a8: EmptySlot ]
					case 0xa0:
					case 0xa1:
					case 0xa2:
					case 0xa3:
					case 0xa4:
					case 0xa5:
					case 0xa6:
					case 0xa7:
					case 0xa8:
                        break;
					#endregion
					#region [ B1～BC EmptySlot ]
					case 0xb1:
					case 0xb2:
					case 0xb3:
					case 0xb4:
					case 0xb5:
					case 0xb6:
					case 0xb7:
					case 0xb8:
					case 0xb9:
                    case 0xba:
                    case 0xbb:
					case 0xbc:
						break;
					#endregion
					#region [ c4, c7, d5-d9: EmptySlot ]
					case 0xc4:
					case 0xc7:
					case 0xd5:
					case 0xd6:	// BGA画像入れ替え
					case 0xd7:
					case 0xd8:
					case 0xd9:
                    //case 0xe0:
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
						}
						break;
					#endregion

					#region [ da: ミキサーへチップ音追加 ]
					case 0xDA:
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
//Debug.WriteLine( "[DA(AddMixer)] BAR=" + pChip.n発声位置 / 384 + " ch=" + pChip.nチャンネル番号.ToString( "x2" ) + ", wav=" + pChip.n整数値.ToString( "x2" ) + ", time=" + pChip.n発声時刻ms );
							pChip.bHit = true;
							if ( listWAV.TryGetValue( pChip.n整数値_内部番号, out CDTX.CWAV wc ) )	// 参照が遠いので後日最適化する
							{
								for ( int i = 0; i < nPolyphonicSounds; i++ )
								{
									if ( wc.rSound[ i ] != null )
									{
										//CDTXMania.Sound管理.AddMixer( wc.rSound[ i ] );
										AddMixer( wc.rSound[ i ], pChip.b演奏終了後も再生が続くチップである );
									}
								}
							}
						}
						break;
					#endregion
					#region [ db: ミキサーからチップ音削除 ]
					case 0xDB:
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
//Debug.WriteLine( "[DB(RemoveMixer)] BAR=" + pChip.n発声位置 / 384 + " ch=" + pChip.nチャンネル番号.ToString( "x2" ) + ", wav=" + pChip.n整数値.ToString( "x2" ) + ", time=" + pChip.n発声時刻ms );
							pChip.bHit = true;
							if ( listWAV.TryGetValue( pChip.n整数値_内部番号, out CDTX.CWAV wc ) )	// 参照が遠いので後日最適化する
							{
							    for ( int i = 0; i < nPolyphonicSounds; i++ )
							    {
									if ( wc.rSound[ i ] != null )
									{
										//CDTXMania.Sound管理.RemoveMixer( wc.rSound[ i ] );
										if ( !wc.rSound[ i ].b演奏終了後も再生が続くチップである )	// #32248 2013.10.16 yyagi
										{															// DTX終了後も再生が続くチップの0xDB登録をなくすことはできず。
											RemoveMixer( wc.rSound[ i ] );							// (ミキサー解除のタイミングが遅延する場合の対応が面倒なので。)
										}															// そこで、代わりにフラグをチェックしてミキサー削除ロジックへの遷移をカットする。
									}
							    }
							}
						}
						break;
                    #endregion

                    #region[ dc-df:太鼓(特殊命令) ]
                    case 0xDC: //DELAY
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							//if ( dTX.listDELAY.ContainsKey( pChip.n整数値_内部番号 ) )
							//{
								//this.actPlayInfo.dbBPM = ( dTX.listBPM[ pChip.n整数値_内部番号 ].dbBPM値 * ( ( (double) configIni.n演奏速度 ) / 20.0 ) );// + dTX.BASEBPM;
							//}
						}
                        break;
                    case 0xDD: //譜面分岐条件リセット
                        if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
                        {
                            this.tBranchReset( nPlayer );
                            pChip.bHit = true;
                        }
                        break;
                    case 0xDE: //譜面分岐スタート
                        //可視化
                        //CDTXMania.act文字コンソール.tPrint( 414 + pChip.nバーからの距離dot.Taiko + 4, 192, C文字コンソール.Eフォント種別.白, "BRANCH START" + "  " + pChip.n整数値.ToString() );
                        if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
                        {
                            TJAPlayer3.stage演奏ドラム画面.bUseBranch[ nPlayer ] = true;
                            if( !this.bLEVELHOLD[ nPlayer ] )
                            {
                                this.tBranchJudge( dTX, this.nBranch_roll[ nPlayer ], this.nBranch_Perfect[ nPlayer ], this.nBranch_Good[ nPlayer ], this.nBranch_Miss[ nPlayer ], nPlayer );
                                this.t分岐処理( this.n次回のコース[ nPlayer ], dTX.listBRANCH[ this.n分岐した回数[ nPlayer ] ].n命令時のChipList番号, nPlayer );
                                TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化( this.n現在のコース[ nPlayer ], this.n次回のコース[ nPlayer ], nPlayer );
                                TJAPlayer3.stage演奏ドラム画面.actMtaiko.tBranchEvent( this.n現在のコース[ nPlayer ], this.n次回のコース[ nPlayer ], nPlayer );
                                if( dTX.listBRANCH[ this.n分岐した回数[ nPlayer ] ].n分岐の種類 == 0 )
                                {
                                    this.n現在のコース[ nPlayer ] = this.n次回のコース[ nPlayer ];
                                }
                            }
                            //if( n現在のコース == pChip.nコース )
                                this.n分岐した回数[ nPlayer ]++;

                            


                            pChip.bHit = true;
                        }
                        break;
                    
                    case 0xDF:
                        //CDTXMania.act文字コンソール.tPrint( 414 + pChip.nバーからの距離dot.Taiko + 4, 192 + 16, C文字コンソール.Eフォント種別.白, "0XDF");
                        if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
                        {
                            //精度分岐だとなんでか知らんが0xDE→0xDFにならない...
                            this.n現在のコース[ nPlayer ] = this.n次回のコース[ nPlayer ];
                            this.b強制的に分岐させた[ nPlayer ] = false;
                            this.chip現在処理中の連打チップ[ nPlayer ] = null;

                            pChip.bHit = true;
                        }
                        break;
                    case 0xE0:
                        //if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
                        //{
                            //#BARLINEONと#BARLINEOFF
                            //演奏中は使用しません。
                        //}
                        break;
                    case 0xE1:
                        if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
                        {
                            if( this.n現在のコース[ nPlayer ] == pChip.nコース )
                            {
                                //LEVELHOLD
                                this.bLEVELHOLD[ nPlayer ] = true;
                            }
                        }
                        break;
                    case 0xE2:
                        if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
                        {
                            if (nPlayer == 0)
                            {
                                TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t判定枠移動(dTX.listJPOSSCROLL[nJPOSSCROLL[nPlayer]].db移動時間, dTX.listJPOSSCROLL[nJPOSSCROLL[nPlayer]].n移動距離px, dTX.listJPOSSCROLL[nJPOSSCROLL[nPlayer]].n移動方向);
                            }
                            else
                            {
                                TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t判定枠移動2(dTX.listJPOSSCROLL[nJPOSSCROLL[nPlayer]].db移動時間, dTX.listJPOSSCROLL[nJPOSSCROLL[nPlayer]].n移動距離px, dTX.listJPOSSCROLL[nJPOSSCROLL[nPlayer]].n移動方向);
                            }
                            this.nJPOSSCROLL[ nPlayer ]++;
                            pChip.bHit = true;
                        }
                        break;
                    #endregion
                    #region[ f1: 歌詞 ]
                    case 0xF1:
                        if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
                            if( dTX.listLiryc.Count > this.n表示した歌詞 )
                            {
                                this.actPanel.t歌詞テクスチャを生成する( dTX.listLiryc[ this.n表示した歌詞 ] );
                                this.n表示した歌詞++;
                            }
                            pChip.bHit = true;
                        }
                        break;
					#endregion
                    #region[ ff: 譜面の強制終了 ]
                    //バグで譜面がとてつもないことになっているため、#ENDがきたらこれを差し込む。
                    case 0xFF:
                        if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
                            return true;
                        }
                        break;
					#endregion

					#region [ その他(未定義) ]
					default:
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
						}
						break;
					#endregion 
                }

            }
			return false;
		}

        protected bool t進行描画_チップ_連打( E楽器パート ePlayMode, int nPlayer )
		{
			if ( ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED ) || ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				return true;
			}
			if ( ( this.n現在のトップChip == -1 ) || ( this.n現在のトップChip >= listChip[ nPlayer ].Count ) )
			{
				return true;
			}

			CConfigIni configIni = TJAPlayer3.ConfigIni;

			CDTX dTX = TJAPlayer3.DTX;
            bool bAutoPlay = false;
            switch( nPlayer ) //2017.08.11 kairera0467
            {
                case 0:
                    bAutoPlay = configIni.b太鼓パートAutoPlay;
                    break;
                case 1:
                    bAutoPlay = configIni.b太鼓パートAutoPlay2P;
                    dTX = TJAPlayer3.DTX_2P;
                    break;
                default:
                    break;
            }

			var n現在時刻ms = CSound管理.rc演奏用タイマ.n現在時刻ms;

            //for ( int nCurrentTopChip = this.n現在のトップChip; nCurrentTopChip < dTX.listChip.Count; nCurrentTopChip++ )
            for ( int nCurrentTopChip = dTX.listChip.Count - 1; nCurrentTopChip > 0; nCurrentTopChip-- )
			{
				CDTX.CChip pChip = dTX.listChip[ nCurrentTopChip ];

                if ( !pChip.bHit )
                {
                    bool bRollChip = pChip.nチャンネル番号 >= 0x15 && pChip.nチャンネル番号 <= 0x19;
                    if( bRollChip && ( ( pChip.e楽器パート != E楽器パート.UNKNOWN ) ) )
                    {
                        int instIndex = (int) pChip.e楽器パート;
                        if( pChip.nバーからの距離dot[instIndex] < -40 )
                        {
                            if ( this.e指定時刻からChipのJUDGEを返す( n現在時刻ms, pChip ) == E判定.Miss )
                            {
                                this.tチップのヒット処理( n現在時刻ms, pChip, E楽器パート.TAIKO, false, 0, nPlayer );
                            }
                        }
                    }
                }

				switch ( pChip.nチャンネル番号 )
				{
                    #region[ 15-19: 連打 ]
                    case 0x15: //連打
                    case 0x16: //連打(大)
                    case 0x17: //風船
                    case 0x18: //連打終了
                    case 0x19:
                        {
                            if( pChip.n描画優先度 >= 1 )
                                this.t進行描画_チップ_Taiko連打( configIni, ref dTX, ref pChip, nPlayer );
                        }
                        break;
                    #endregion
                }

            }
			return false;
		}

        public void tBranchReset( int player )
        {    
            if( player != -1 )
            {
                this.nBranch_roll[ player ] = 0;
                this.nBranch_Perfect[ player ] = 0;
                this.nBranch_Good[ player ] = 0;
                this.nBranch_Miss[ player ] = 0;
            }
            else
            {
                for( int i = 0; i < 4; i++ )
                {
                    this.nBranch_roll[ i ] = 0;
                    this.nBranch_Perfect[ i ] = 0;
                    this.nBranch_Good[ i ] = 0;
                    this.nBranch_Miss[ i ] = 0;
                }
            }
        }

        public void tBranchJudge( CDTX dTX, int n連打数, int n良, int n可, int n不可, int nPlayer )
        {
            if( this.b強制的に分岐させた[ nPlayer ] ) return;

            int n種類 = dTX.listBRANCH[ this.n分岐した回数[ nPlayer ] ].n分岐の種類;

            double dbRate = 0;

            if( ( n良 + n可 + n不可 ) != 0 )
            {
                dbRate = ((double)n良 / (double)(n良 + n可 + n不可)) * 100.0;
            }


            if( n種類 == 0 )
            {
                if( dbRate < dTX.listBRANCH[this.n分岐した回数[ nPlayer ]].n条件数値A )
                {
                    this.n次回のコース[ nPlayer ] = 0;
                }
                else if( dbRate >= dTX.listBRANCH[this.n分岐した回数[ nPlayer ]].n条件数値A && dbRate < dTX.listBRANCH[this.n分岐した回数[ nPlayer ]].n条件数値B )
                {
                    this.n次回のコース[ nPlayer ] = 1;
                }
                else if( dbRate >= dTX.listBRANCH[this.n分岐した回数[ nPlayer ]].n条件数値B )
                {
                    this.n次回のコース[ nPlayer ] = 2;
                }
            }
            else if( n種類 == 1 )
            {
                if( n連打数 < dTX.listBRANCH[this.n分岐した回数[ nPlayer ]].n条件数値A )
                {
                    this.n次回のコース[ nPlayer ] = 0;
                }
                else if( n連打数 >= dTX.listBRANCH[this.n分岐した回数[ nPlayer ]].n条件数値A && n連打数 < dTX.listBRANCH[this.n分岐した回数[ nPlayer ]].n条件数値B )
                {
                    this.n次回のコース[ nPlayer ] = 1;
                }
                else if( n連打数 >= dTX.listBRANCH[this.n分岐した回数[ nPlayer ]].n条件数値B )
                {
                    this.n次回のコース[ nPlayer ] = 2;
                }

                this.nBranch_roll[ nPlayer ] = 0;
            }
        }

        public int nBranchJudge( CDTX dTX, int n連打数, int n良, int n可, int n不可 )
        {

            int n種類 = dTX.listBRANCH[ this.n分岐した回数[ 0 ] ].n分岐の種類;
            int n次回のコース = 0;

            double dbRate = 0;

            if( ( n良 + n可 + n不可 ) != 0 )
            {
                dbRate = ( (double)n良 / (double)( n良 + n可 + n不可 ) ) * 100.0;
            }


            if( n種類 == 0 )
            {
                if( dbRate < dTX.listBRANCH[ this.n分岐した回数[ 0 ] ].n条件数値A )
                {
                    n次回のコース = 0;
                }
                else if( dbRate >= dTX.listBRANCH[ this.n分岐した回数[ 0 ] ].n条件数値A && dbRate < dTX.listBRANCH[ this.n分岐した回数[ 0 ] ].n条件数値B )
                {
                    n次回のコース = 1;
                }
                else if( dbRate >= dTX.listBRANCH[ this.n分岐した回数[ 0 ] ].n条件数値B )
                {
                    n次回のコース = 2;
                }
            }
            else if( n種類 == 1 )
            {
                if( n連打数 < dTX.listBRANCH[ this.n分岐した回数[ 0 ] ].n条件数値A )
                {
                    n次回のコース = 0;
                }
                else if( n連打数 >= dTX.listBRANCH[ this.n分岐した回数[ 0 ] ].n条件数値A && n連打数 < dTX.listBRANCH[ this.n分岐した回数[ 0 ] ].n条件数値B )
                {
                    n次回のコース = 1;
                }
                else if( n連打数 >= dTX.listBRANCH[ this.n分岐した回数[ 0 ] ].n条件数値B )
                {
                    n次回のコース = 2;
                }
            }

            return n次回のコース;
        }
        public void t分岐処理( int n分岐先, int n分岐開始位置のChip番号, int nPlayer )
        {
            int n消すコース1 = 1;
            int n消すコース2 = 2;

            switch( n分岐先 )
            {
                case 0:
                    n消すコース1 = 1;
                    n消すコース2 = 2;
                    break;
                case 1:
                    n消すコース1 = 0;
                    n消すコース2 = 2;
                    break;
                case 2:
                    n消すコース1 = 0;
                    n消すコース2 = 1;
                    break;
            }
            //2015.06.24 ソート処理で正確な番号が取得できなくなっていたので、とりあえずこれで対応。
            //2015.07.21 「卓球de脱臼」でバグが発生するのを修正完了。未ヒットチップを未来方向のみ検索して対応。
            

            //ソート後の譜面分岐開始位置のchip番号を正常に取得できないため、ここで現在の時刻から一番近い位置の音符を消す処理を作る必要がある。
            //CDTX.CChip chipNoHit = this.r指定時刻に一番近い未ヒットChip( CSound管理.rc演奏用タイマ.n現在時刻ms, 0xDF, 0, 10000 );
            CDTX.CChip chipNoHit = this.r指定時刻に一番近い未ヒットChip( CSound管理.rc演奏用タイマ.n現在時刻ms + 1, 0xDF, 0, 10000, nPlayer ); //とりあえず検索開始を1ms後にして対応。
            if( chipNoHit == null )
                return;

            n分岐開始位置のChip番号 = chipNoHit.n整数値;
            
            //2017.08.15 kairera0467 複数譜面同時再生対応もどき
            CDTX dTX = TJAPlayer3.DTX;
            switch( nPlayer )
            {
                case 1:
                    dTX = TJAPlayer3.DTX_2P;
                    break;
                default:
                    break;
            }


            for( int A = n分岐開始位置のChip番号; A < dTX.listChip.Count; A++ )
            {
                //if( dTX.listChip[ A ].n発声時刻ms < dTX.listBRANCH[ this.n分岐した回数 ].db分岐時間ms )
                if( dTX.listChip[ A ].n整数値 < n分岐開始位置のChip番号 )
                {
                    dTX.listChip[ A ].b可視 = true;
                    continue;
                }

                if( dTX.listChip[ A ].nチャンネル番号 == 0x01 ) continue;
                //if( CDTXMania.DTX.listChip[ A ].nチャンネル番号 == 0x50 ) continue;
                if( dTX.listChip[ A ].nチャンネル番号 == 0x9C ) continue;
                if( dTX.listChip[ A ].nチャンネル番号 == 0xDD ) continue;
                if( dTX.listChip[ A ].nチャンネル番号 == 0xDE ) continue;
                if( dTX.listChip[ A ].nチャンネル番号 == 0xDF ) continue;

                if( dTX.listChip[ A ].nコース == n消すコース1 || dTX.listChip[ A ].nコース == n消すコース2 )
                {
                    dTX.listChip[ A ].b可視 = false;
                }
                else
                {
                    dTX.listChip[ A ].b可視 = true;
                    dTX.listChip[ A ].eNoteState = ENoteState.none;
                }
            }
        }

        public int GetRoll(int player)
        {
            return n合計連打数[player];
        }

        protected float GetNowPBMTime( CDTX tja, float play_time )
        {
            float bpm_time = 0;
            int last_input = 0;
            float last_bpm_change_time;
            play_time = CSound管理.rc演奏用タイマ.n現在時刻ms - tja.nOFFSET;

            for (int i = 1; ; i++)
            {
                //BPMCHANGEの数越えた
                if( i >= tja.listBPM.Count )
                {
                    CDTX.CBPM cBPM = tja.listBPM[ last_input ];
                    bpm_time = (float)cBPM.bpm_change_bmscroll_time + ( ( play_time - (float)cBPM.bpm_change_time ) * (float)cBPM.dbBPM値 / 15000.0f );
                    last_bpm_change_time = (float)cBPM.bpm_change_time;
                    break;
                }
                for( ; i < tja.listBPM.Count; i++ )
                {
                    CDTX.CBPM cBPM = tja.listBPM[ i ];
                    if (cBPM.bpm_change_time == 0 || cBPM.bpm_change_course == this.n現在のコース[ 0 ] )
                    {
                        break;
                    }
                }
                if( i == tja.listBPM.Count )
                {
                    i = tja.listBPM.Count - 1;
                    continue;
                }

                if( play_time < tja.listBPM[ i ].bpm_change_time )
                {
                    CDTX.CBPM cBPM = tja.listBPM[ last_input ];
                    bpm_time = (float)cBPM.bpm_change_bmscroll_time + ( ( play_time - (float)cBPM.bpm_change_time ) * (float)cBPM.dbBPM値 / 15000.0f );
                    last_bpm_change_time = (float)cBPM.bpm_change_time;
                    break;
                }
                else
                {
                    last_input = i;
                }
            }

            return bpm_time;
        }

		public void t再読込()
		{
			TJAPlayer3.DTX.t全チップの再生停止とミキサーからの削除();
			this.eフェードアウト完了時の戻り値 = E演奏画面の戻り値.再読込_再演奏;
			base.eフェーズID = CStage.Eフェーズ.演奏_再読込;
			this.bPAUSE = false;
		}

        public void t演奏やりなおし()
        {
			TJAPlayer3.DTX.t全チップの再生停止とミキサーからの削除();
            this.t数値の初期化( true, true );
            this.actAVI.tReset();
            this.t演奏位置の変更( 0, 0 );
            this.t演奏位置の変更( 0, 1 );
            TJAPlayer3.stage演奏ドラム画面.On活性化();
            for( int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++ )
            {
                this.chip現在処理中の連打チップ[ i ] = null;
            }
            this.bPAUSE = false;
        }

		public void t停止()
		{
			TJAPlayer3.DTX.t全チップの再生停止とミキサーからの削除();
			this.actAVI.Stop();
			this.actPanel.Stop();				// PANEL表示停止
			TJAPlayer3.Timer.t一時停止();		// 再生時刻カウンタ停止

			this.n現在のトップChip = TJAPlayer3.DTX.listChip.Count - 1;	// 終端にシーク

			// 自分自身のOn活性化()相当の処理もすべき。
		}

        public void t数値の初期化( bool b演奏記録, bool b演奏状態 )
        {
            if( b演奏記録 )
            {
                this.nヒット数_Auto含む.Taiko.Perfect = 0;
                this.nヒット数_Auto含む.Taiko.Great = 0;
                this.nヒット数_Auto含む.Taiko.Good = 0;
                this.nヒット数_Auto含む.Taiko.Poor = 0;
                this.nヒット数_Auto含む.Taiko.Miss = 0;

                this.nヒット数_Auto含まない.Taiko.Perfect = 0;
                this.nヒット数_Auto含まない.Taiko.Great = 0;
                this.nヒット数_Auto含まない.Taiko.Good = 0;
                this.nヒット数_Auto含まない.Taiko.Poor = 0;
                this.nヒット数_Auto含まない.Taiko.Miss = 0;

                this.actCombo.On活性化();
                this.actScore.On活性化();
                this.actGauge.Init( TJAPlayer3.ConfigIni.nRisky );
            }
            if( b演奏状態 )
            {
                for( int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++ )
                {
                    this.bIsGOGOTIME[ i ] = false;
                    this.bLEVELHOLD[ i ] = false;
                    this.b強制的に分岐させた[ i ] = false;
                    this.b譜面分岐中[ i ] = false;
                    this.b連打中[ i ] = false;
                    this.n現在のコース[ i ] = 0;
                    this.n次回のコース[ i] = 0;
                    this.n現在の連打数[ i ] = 0;
                    this.n合計連打数[ i ] = 0;
                    this.n分岐した回数[ i ] = 0;
                }

                this.actComboVoice.tリセット();
            }

            this.ReSetScore(TJAPlayer3.DTX.nScoreInit[0, TJAPlayer3.stage選曲.nSeelectedCource[0]], TJAPlayer3.DTX.nScoreDiff[TJAPlayer3.stage選曲.nSeelectedCource[0]]);
            this.nHand = new int[]{ 0, 0, 0, 0 };
        }

		public void t演奏位置の変更( int nStartBar, int nPlayer )
		{
			// まず全サウンドオフにする
			TJAPlayer3.DTX.t全チップの再生停止();
			this.actAVI.Stop();
            CDTX dTX = TJAPlayer3.DTX;
            switch( nPlayer )
            {
                case 1:
                    dTX = TJAPlayer3.DTX_2P;
                    break;
                default:
                    break;
            }

            if( dTX == null ) return; //CDTXがnullの場合はプレイヤーが居ないのでその場で処理終了


			#region [ 再生開始小節の変更 ]
			//nStartBar++;									// +1が必要

			#region [ 演奏済みフラグのついたChipをリセットする ]
			for ( int i = 0; i < dTX.listChip.Count; i++ )
			{
				CDTX.CChip pChip = dTX.listChip[ i ];
				if ( pChip.bHit )
				{
					CDTX.CChip p = (CDTX.CChip) pChip.Clone();
					p.bHit = false;
                    //2016.11.23 kairera0467 太鼓用に追加
                    p.eNoteState = ENoteState.none;
                    p.nProcessTime = 0;
                    p.nRollCount = 0;
                    dTX.listChip[ i ].nRollCount = 0;

					dTX.listChip[ i ] = p;
				}
			}
			#endregion

			#region [ 処理を開始するチップの特定 ]
			//for ( int i = this.n現在のトップChip; i < CDTXMania.DTX.listChip.Count; i++ )
			bool bSuccessSeek = false;
			for ( int i = 0; i < dTX.listChip.Count; i++ )
			{
				CDTX.CChip pChip = dTX.listChip[ i ];
				if ( pChip.n発声位置 < 384 * nStartBar )
				{
					continue;
				}
				else
				{
					bSuccessSeek = true;
					this.n現在のトップChip = i;
					break;
				}
			}
			if ( !bSuccessSeek )
			{
				// this.n現在のトップChip = CDTXMania.DTX.listChip.Count - 1;
				this.n現在のトップChip = 0;		// 対象小節が存在しないなら、最初から再生
			}
			#endregion

			#region [ 演奏開始の発声時刻msを取得し、タイマに設定 ]
			int nStartTime = dTX.listChip[ this.n現在のトップChip ].n発声時刻ms;

			CSound管理.rc演奏用タイマ.tリセット();	// これでPAUSE解除されるので、次のPAUSEチェックは不要
			//if ( !this.bPAUSE )
			//{
				CSound管理.rc演奏用タイマ.t一時停止();
			//}
			CSound管理.rc演奏用タイマ.n現在時刻 = nStartTime;
			#endregion

			List<CSound> pausedCSound = new List<CSound>();

			#region [ BGMやギターなど、演奏開始のタイミングで再生がかかっているサウンドのの途中再生開始 ] // (CDTXのt入力_行解析_チップ配置()で小節番号が+1されているのを削っておくこと)
			for ( int i = this.n現在のトップChip; i >= 0; i-- )
			{
				CDTX.CChip pChip = dTX.listChip[ i ];
				int nDuration = pChip.GetDuration();

				if ( ( pChip.n発声時刻ms + nDuration > 0 ) && ( pChip.n発声時刻ms <= nStartTime ) && ( nStartTime <= pChip.n発声時刻ms + nDuration ) )
				{
					if ( pChip.bWAVを使うチャンネルである && ( pChip.nチャンネル番号 >> 4 ) != 0xB )	// wav系チャンネル、且つ、空打ちチップではない
					{
						CDTX.CWAV wc;
						bool b = dTX.listWAV.TryGetValue( pChip.n整数値_内部番号, out wc );
						if ( !b ) continue;

						if ( ( wc.bIsBGMSound && TJAPlayer3.ConfigIni.bBGM音を発声する ) || ( !wc.bIsBGMSound ) )
						{
							TJAPlayer3.DTX.tチップの再生( pChip, CSound管理.rc演奏用タイマ.n前回リセットした時のシステム時刻 + pChip.n発声時刻ms, (int) Eレーン.BGM );
							#region [ PAUSEする ]
							int j = wc.n現在再生中のサウンド番号;
							if ( wc.rSound[ j ] != null )
							{
							    wc.rSound[ j ].t再生を一時停止する();
							    wc.rSound[ j ].t再生位置を変更する( nStartTime - pChip.n発声時刻ms );
							    pausedCSound.Add( wc.rSound[ j ] );
							}
							#endregion
						}
					}
				}
			}
			#endregion
			#region [ 演奏開始時点で既に表示されているBGAとAVIの、シークと再生 ]
			this.actAVI.SkipStart( nStartTime );
			#endregion
			#region [ PAUSEしていたサウンドを一斉に再生再開する(ただしタイマを止めているので、ここではまだ再生開始しない) ]
			foreach ( CSound cs in pausedCSound )
			{
				cs.tサウンドを再生する();
			}
			pausedCSound.Clear();
			pausedCSound = null;
			#endregion
			#region [ タイマを再開して、PAUSEから復帰する ]
			CSound管理.rc演奏用タイマ.n現在時刻 = nStartTime;
			TJAPlayer3.Timer.tリセット();						// これでPAUSE解除されるので、3行先の再開()は不要
			TJAPlayer3.Timer.n現在時刻 = nStartTime;				// Debug表示のTime: 表記を正しくするために必要
			CSound管理.rc演奏用タイマ.t再開();
			//CDTXMania.Timer.t再開();
			this.bPAUSE = false;								// システムがPAUSE状態だったら、強制解除
			this.actPanel.Start();
			#endregion
			#endregion
		}

        public void t演奏中止()
        {
            this.actFO.tフェードアウト開始();
            base.eフェーズID = CStage.Eフェーズ.共通_フェードアウト;
            this.eフェードアウト完了時の戻り値 = E演奏画面の戻り値.演奏中断;
        }

		/// <summary>
		/// DTXV用の設定をする。(全AUTOなど)
		/// 元の設定のバックアップなどはしないので、あとでConfig.iniを上書き保存しないこと。
		/// </summary>
		protected void tDTXV用の設定()
		{
			TJAPlayer3.ConfigIni.bAutoPlay.HH = true;
			TJAPlayer3.ConfigIni.bAutoPlay.SD = true;
			TJAPlayer3.ConfigIni.bAutoPlay.BD = true;
			TJAPlayer3.ConfigIni.bAutoPlay.HT = true;
			TJAPlayer3.ConfigIni.bAutoPlay.LT = true;
			TJAPlayer3.ConfigIni.bAutoPlay.CY = true;
			TJAPlayer3.ConfigIni.bAutoPlay.FT = true;
			TJAPlayer3.ConfigIni.bAutoPlay.RD = true;
			TJAPlayer3.ConfigIni.bAutoPlay.LC = true;
            TJAPlayer3.ConfigIni.bAutoPlay.LP = true;
            TJAPlayer3.ConfigIni.bAutoPlay.LBD = true;
			TJAPlayer3.ConfigIni.bAutoPlay.GtR = true;
			TJAPlayer3.ConfigIni.bAutoPlay.GtB = true;
			TJAPlayer3.ConfigIni.bAutoPlay.GtB = true;
			TJAPlayer3.ConfigIni.bAutoPlay.GtPick = true;
			TJAPlayer3.ConfigIni.bAutoPlay.GtW = true;
			TJAPlayer3.ConfigIni.bAutoPlay.BsR = true;
			TJAPlayer3.ConfigIni.bAutoPlay.BsB = true;
			TJAPlayer3.ConfigIni.bAutoPlay.BsB = true;
			TJAPlayer3.ConfigIni.bAutoPlay.BsPick = true;
			TJAPlayer3.ConfigIni.bAutoPlay.BsW = true;

			this.bIsAutoPlay = TJAPlayer3.ConfigIni.bAutoPlay;

			TJAPlayer3.ConfigIni.bAVI有効 = true;
			TJAPlayer3.ConfigIni.bBGA有効 = true;
			for ( int i = 0; i < 3; i++ )
			{
				TJAPlayer3.ConfigIni.bGraph[ i ] = false;
				TJAPlayer3.ConfigIni.bHidden[ i ] = false;
				TJAPlayer3.ConfigIni.bLeft[ i ] = false;
				TJAPlayer3.ConfigIni.bLight[ i ] = false;
				TJAPlayer3.ConfigIni.bReverse[ i ] = false;
				TJAPlayer3.ConfigIni.bSudden[ i ] = false;
				TJAPlayer3.ConfigIni.eInvisible[ i ] = EInvisible.OFF;
				TJAPlayer3.ConfigIni.eRandom[ i ] = Eランダムモード.OFF;
				TJAPlayer3.ConfigIni.n表示可能な最小コンボ数[ i ] = 65535;
				TJAPlayer3.ConfigIni.判定文字表示位置[ i ] = E判定文字表示位置.表示OFF;
				// CDTXMania.ConfigIni.n譜面スクロール速度[ i ] = CDTXMania.ConfigIni.nViewerScrollSpeed[ i ];	// これだけはOn活性化()で行うこと。
																												// そうしないと、演奏開始直後にスクロール速度が変化して見苦しい。
			}

			TJAPlayer3.ConfigIni.eDark = Eダークモード.OFF;

			TJAPlayer3.ConfigIni.b演奏情報を表示する = TJAPlayer3.ConfigIni.bViewerShowDebugStatus;
			TJAPlayer3.ConfigIni.bScoreIniを出力する = false;
			TJAPlayer3.ConfigIni.bSTAGEFAILED有効 = false;
			TJAPlayer3.ConfigIni.bTight = false;
			TJAPlayer3.ConfigIni.bストイックモード = false;

			TJAPlayer3.ConfigIni.nRisky = 0;
		}

		protected abstract void t進行描画_チップ_ドラムス( CConfigIni configIni, ref CDTX dTX, ref CDTX.CChip pChip );
		protected abstract void t進行描画_チップ本体_ドラムス( CConfigIni configIni, ref CDTX dTX, ref CDTX.CChip pChip );
		protected abstract void t進行描画_チップ_Taiko( CConfigIni configIni, ref CDTX dTX, ref CDTX.CChip pChip, int nPlayer );
		protected abstract void t進行描画_チップ_Taiko連打( CConfigIni configIni, ref CDTX dTX, ref CDTX.CChip pChip, int nPlayer );

		protected abstract void t進行描画_チップ_フィルイン( CConfigIni configIni, ref CDTX dTX, ref CDTX.CChip pChip );
		protected abstract void t進行描画_チップ_小節線( CConfigIni configIni, ref CDTX dTX, ref CDTX.CChip pChip, int nPlayer );
		protected void t進行描画_チップアニメ()
		{
            if( this.b初めての進行描画 )
            {
                //this.ct制御タイマ = FDK.CSound管理.rc演奏用タイマ;
                //this.ct制御タイマ = new CCounter(0, 10, 500, CSound管理.rc演奏用タイマ);
                //this.ct制御タイマ.t進行LoopDb();
            }
            for (int i = 0; i < 2; i++)
            {
                ctChipAnime[i].t進行LoopDb();
                //CDTXMania.act文字コンソール.tPrint(0, 20 * i, C文字コンソール.Eフォント種別.白, ctChipAnime[i].db現在の値.ToString());
                ctChipAnimeLag[i].t進行();
                //    CDTXMania.act文字コンソール.tPrint(0, 20 * i, C文字コンソール.Eフォント種別.白, ctChipAnimeLag[i].n現在の値.ToString());
                //
            }

            //CDTXMania.act文字コンソール.tPrint(60, 140, C文字コンソール.Eフォント種別.白, ct制御タイマ.n現在の値.ToString());
            //this.nタイマ番号 = (int)this.actChara.ctモブモーション.db現在の値;
            //CDTXMania.act文字コンソール.tPrint(0, 0, C文字コンソール.Eフォント種別.白, this.nタイマ番号.ToString());


            //if (this.actChara.ctモブモーション.db現在の値 <= 30)
            //{
            //    this.n現在の音符の顔番号 = 0;
            //} else
            //{
            //    this.n現在の音符の顔番号 = 1;
            //}

            /*long num = FDK.CSound管理.rc演奏用タイマ.n現在時刻;
			if( num < this.ct制御タイマ )
			{
				this.ct制御タイマ = num;
			}
			while( ( num - this.ct制御タイマ ) >= 1000 )
			{
				if( this.n現在の音符の顔番号 == 0 )
				{
					this.n現在の音符の顔番号 = 1;
		        }
				else if( this.n現在の音符の顔番号 == 1 )
				{
					this.n現在の音符の顔番号 = 0;
		        }

                if( this.actCombo.n現在のコンボ数.P1 < 50 )
                {
                    this.ct制御タイマ += 500;
                }
                else if(this.actCombo.n現在のコンボ数.P1 >= 50 && this.actCombo.n現在のコンボ数.P1 < 150)
                {
                    this.ct制御タイマ += 400;
                }
                else if( this.actCombo.n現在のコンボ数.P1 >= 150 && this.actCombo.n現在のコンボ数.P1 < 250 )
                {
                    this.ct制御タイマ += 300;
                }
                else if( this.actCombo.n現在のコンボ数.P1 >= 250 && this.actCombo.n現在のコンボ数.P1 < 300 )
                {
                    this.ct制御タイマ += 200;
                }
                else if( this.actCombo.n現在のコンボ数.P1 >= 300 )
                {
                    this.ct制御タイマ += 80;
                }
                else
                {
                    this.ct制御タイマ += 500;
                }

		    }*/

            //if ( this.actChara.ctゴーゴーモーション != null )
            //{
            //    this.actChara.ctゴーゴーモーション.t進行LoopDb();
            //}
        }

		protected bool t進行描画_フェードイン_アウト()
		{
			switch ( base.eフェーズID )
			{
				case CStage.Eフェーズ.共通_フェードイン:
					if ( this.actFI.On進行描画() != 0 )
					{
						base.eフェーズID = CStage.Eフェーズ.共通_通常状態;
					}
					break;

				case CStage.Eフェーズ.共通_フェードアウト:
				case CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト:
					if ( this.actFO.On進行描画() != 0 )
					{
						return true;
					}
					break;

				case CStage.Eフェーズ.演奏_STAGE_CLEAR_フェードアウト:
					if ( this.actFOClear.On進行描画() == 0 )
					{
						break;
					}
					return true;
		
			}
			return false;
		}
		protected void t進行描画_レーンフラッシュD()
		{
			//if ( ( CDTXMania.ConfigIni.eDark == Eダークモード.OFF ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				this.actTaikoLaneFlash.On進行描画();
			}
		}
		protected abstract void t進行描画_演奏情報();
		protected void t進行描画_演奏情報(int x, int y)
		{
			if ( !TJAPlayer3.ConfigIni.b演奏情報を表示しない )
			{
				this.actPlayInfo.t進行描画( x, y );
			}
		}
		protected void t進行描画_背景()
		{
			if ( this.tx背景 != null )
			{
				this.tx背景.t2D描画( TJAPlayer3.app.Device, 0, 0 );
			}
		}

		protected void t進行描画_判定ライン()
		{
			if ( TJAPlayer3.ConfigIni.eDark != Eダークモード.FULL )
			{
				int y = TJAPlayer3.ConfigIni.bReverse.Drums ? 53 - 演奏判定ライン座標.nJudgeLinePosY_delta.Drums : 567 + 演奏判定ライン座標.nJudgeLinePosY_delta.Drums;
																// #31602 2013.6.23 yyagi 描画遅延対策として、判定ラインの表示位置をオフセット調整できるようにする
				if ( this.txヒットバー != null )
				{
				    this.txヒットバー.t2D描画( TJAPlayer3.app.Device, 295, y, new Rectangle( 0, 0, 558, 6 ) );
				}
			}
		}
		protected void t進行描画_判定文字列()
		{
			this.actJudgeString.t進行描画( 演奏判定ライン座標 );
		}
		protected void t進行描画_判定文字列1_通常位置指定の場合()
		{
			if ( ( (E判定文字表示位置) TJAPlayer3.ConfigIni.判定文字表示位置.Drums ) != E判定文字表示位置.コンボ下 )	// 判定ライン上または横
			{
				this.actJudgeString.t進行描画( 演奏判定ライン座標 );
			}
		}
		protected void t進行描画_判定文字列2_判定ライン上指定の場合()
		{
			if ( ( (E判定文字表示位置) TJAPlayer3.ConfigIni.判定文字表示位置.Drums ) == E判定文字表示位置.コンボ下 )	// 判定ライン上または横
			{
				this.actJudgeString.t進行描画( 演奏判定ライン座標 );
			}
		}

		protected void t進行描画_譜面スクロール速度()
		{
			this.act譜面スクロール速度.On進行描画();
		}
        protected abstract void t紙吹雪_開始();
		protected abstract void t背景テクスチャの生成();
		protected void t背景テクスチャの生成( string DefaultBgFilename, Rectangle bgrect, string bgfilename )
		{
            try
            {
                if( !String.IsNullOrEmpty( bgfilename ) )
                    this.tx背景 = TJAPlayer3.tテクスチャの生成( TJAPlayer3.stage選曲.r確定されたスコア.ファイル情報.フォルダの絶対パス + bgfilename );
                else
                    this.tx背景 = TJAPlayer3.tテクスチャの生成( CSkin.Path( DefaultBgFilename ) );
            }
            catch (Exception e)
            {
                Trace.TraceError( e.ToString() );
                Trace.TraceError( "例外が発生しましたが処理を継続します。 (a80767e1-4de7-4fec-b072-d078b3659e62)" );
                this.tx背景 = null;
            }
		}

        public void ReSetScore(int scoreInit, int scoreDiff)
        {
            //一打目の処理落ちがひどいので、あらかじめここで点数の計算をしておく。
            // -1だった場合、その前を引き継ぐ。
            int nInit = scoreInit != -1 ? scoreInit : this.nScore[0];
            int nDiff = scoreDiff != -1 ? scoreDiff : this.nScore[1] - this.nScore[0];
            int nAddScore = 0;
            int[] n倍率 = { 0, 1, 2, 4, 8 };

            if( TJAPlayer3.DTX.nScoreModeTmp == 1 )
            {
                for( int i = 0; i < 11; i++ )
                {
                    this.nScore[ i ] = (int)( nInit + ( nDiff * ( i ) ) );
                }
            }
            else if( TJAPlayer3.DTX.nScoreModeTmp == 2 )
            {
                for( int i = 0; i < 5; i++ )
                {
                    this.nScore[ i ] = (int)( nInit + ( nDiff * n倍率[ i ] ) );

                    this.nScore[ i ] = (int)( this.nScore[ i ] / 10.0 );
                    this.nScore[ i ] = this.nScore[ i ] * 10;

                }

                //this.nScore[ 0 ] = (int)nInit;
                //this.nScore[ 1 ] = (int)( nInit + nDiff );
                //this.nScore[ 2 ] = (int)( nInit + ( nDiff * 2 ) );
                //this.nScore[ 3 ] = (int)( nInit + ( nDiff * 4 ) );
                //this.nScore[ 4 ] = (int)( nInit + ( nDiff * 8 ) );
            }
        }
        #endregion
	}
}
