﻿//-----------------------------------------------------------------------
// <copyright file="RDPackageType.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using System.Reflection;

namespace RedDragonCardCatcher.Model
{
    [Obfuscation(Exclude = true)]
    internal enum RDPackageType : short
    {
        Club,
        ClubNamePriceReq,
        ClubNamePriceRes,
        ClubReq,
        ClubRes,
        ClubUpdateReq,
        ClubUpdateRes,
        ClubUpdateResN,
        IncreaseClubMemberReq,
        IncreaseClubMemberRes,
        IncreaseClubMemberResN,
        SettingClubFundReq,
        SettingClubFundRes,
        SettingClubFundResN,
        ChangeClubMasterScoreLockState,
        ClubMasterScoreLockState,
        ProvideClubMasterScore,
        ProvideClubMasterScoreRes,
        ProvideClubMasterScoreNotify,
        GetUpperClubIdAndNameReq,
        GetUpperClubIdAndNameRes,
        ContributeMasterScoreToClub,
        ManageClubFundReq,
        ManageClubFundRes,
        ManageClubFundResN,
        ManageClubFundStatusReq,
        ManageClubFundStatusRes,
        ManageClubFundStatusResN,
        LowerClubsReq,
        LowerClubsRes,
        ManagerClubAuthorityReq,
        ManagerClubAuthorityRes,
        ManagerClubAuthorityResN,
        ClubMemberReq,
        ClubMemberRes,
        ClubMemberChangeResN,
        MasterScoreDetailReq,
        MasterScoreDetailRes,
        MasterScoreRecordsReq,
        MasterScoreRecordsRes,
        MasterScoreGainsReq,
        MasterScoreGainsRes,
        SubClubRebateReq,
        SubClubRebateRes,
        ClubPlayer,
        GenerateCodeRequest,
        GenerateCodeResponse,
        InviteCodeRequest,
        InviteCodeResponse,
        InviteCode,
        PsDefaultChangeClubReq,
        PsDefaultChangeClubResp,
        GetClubRoomTemplateReq,
        GetClubRoomTemplateResp,
        ClubRoomTemplate,
        DeleteClubRoomTemplateReq,
        DeleteClubRoomTemplateResp,
        CreateClubRoomTemplateReq,
        CreateClubRoomTemplateResp,
        CreateClubRoomReq,
        CreateClubRoomResp,
        ClubIncomeStaticsReq,
        ClubIncomeStaticsRes,
        ClubIncomeStatics,
        PlayerContributeToClubInfoReq,
        PlayerContributeToClubInfoRes,
        NotifyPlayerRoomDestory,
        NotifyGameOverResponse,
        GameResult,
        GameRule,
        NotifySngRewardResponse,
        sngReward,
        CareerRequest,
        CareerResponse,
        CareerData,
        CareerProcessData,
        Chat,        
        ChatRequest,
        ChatResponse,
        ChatNotify,
        ClubNotify,
        ClubApplication,
        OfficialRoom,
        ClubCreateRequest,
        ClubCreateResponse,
        AllOfficialRoomRequest,
        AllOfficialRoomResponse,
        SetClubOfficialRoomRequest,
        SetClubOfficialRoomResponse,
        FindClubOfficealRoomRequest,
        FindClubOfficealRoomResponse,
        FindTableRequest,
        FindTableResponse,
        FindAllTableRequest,
        FindAllTableResponse,
        FindClubAndClubPlayersRequest,
        FindClubAndClubPlayersResponse,
        ClubUpdateRequest,
        ClubUpdateResponse,
        ClubSearchRequest,
        ClubSearchResponse,
        FindClubPlayerRequest,
        FindClubPlayerResponse,
        ApplyClubPlayerRequest,
        ApplyClubPlayerResponse,
        ApproveClubPlayerRequest,
        ApproveClubPlayerResponse,
        SetClubPlayerRequest,
        SetClubPlayerResponse,
        KickClubPlayerRequest,
        KickClubPlayerResponse,
        CancelClubRequest,
        CancelClubResponse,
        DissolutionClubRequest,
        DissolutionClubResponse,
        ClubKickOutNotify,
        GiveClubActivityRequest,
        GiveClubActivityResponse,
        FindClubInfoRequest,
        FindClubInfoResponse,
        SubClubRebateRequest,
        SubClubRebateResponse,
        SubClubRebateData,
        SetClubMasterScoreThresholdRequest,
        SetClubMasterScoreThresholdResponse,
        FindClubSinglePlayerRequest,
        FindSingleClubPlayerResponse,
        HelpRepayCreditScoreRequest,
        HelpRepayCreditScoreResponse,
        AddClubCreditScoreRequest,
        AddClubCreditScoreResponse,
        WithdrawClubCreditScoreRequest,
        WithdrawClubCreditScoreResponse,
        AllotPlayerCreditScoreRequest,
        AllotPlayerCreditScoreResponse,
        AllotPlayerCreditScoreNotify,
        RepayClubCreditScoreRequest,
        RepayClubCreditScoreResponse,
        RoomTypeEnum,
        PlayerStateEnum,
        ErrorMsg,
        NotifyGamePause,
        NotifyGameReStart,
        NotifyGameDelayed,
        NotifyGameErrorRestart,
        NotifyGameSettlement,
        NotifyGameKickPlayer,
        NotifyGameCancelBan,
        GmNotifyEnum,
        HandReviewRequest,
        HandReviewResponse,
        HandReview,
        HandCard2,
        FlopCard,
        Card2,
        TriggerInsuranceNotify,
        OptionBroadCastRequest,
        OptionBroadCastResponse,
        BuyInsuranceRequest,
        BuyInsuranceResponse,
        UnbuyInsuranceRequest,
        UnbuyInsuranceResponse,
        ResetBuyThinkTimeRequest,
        ResetBuyThinkTimeResponse,
        InsuranceSettlementNotify,
        InsuranceHoleCardNotify,
        Card5,
        Odds,
        InPoolPlayerHandCard,
        DoPlayerCallResponse,
        Pot,
        NoInsuranceNotify,
        WaitBuyInsuranceNotify,
        ItemTemplateNotify,
        PlayerItemNotify,
        UseItemRequest,
        UseItemResponse,
        AddPlayerItemNotify,
        DeletePlayerItemNotify,
        PlayerItemCount,
        ItemTemplate,
        PlayerItem,
        TakeMascotRequest,
        TakeMascotResponse,
        HandselItemPlayerInfoRequest,
        HandselItemPlayerInfoResponse,
        HandselItemRequest,
        HandselItemResponse,
        GetCdKeyRequest,
        GetCdKeyResponse,
        UseCdKeyRequest,
        UseCdKeyResponse,
        ConvertItemRequest,
        ConvertItemResponse,
        UseQRCodeTicketResponse,
        RedPacketResponse,
        RedPacketWithMoneyResponse,
        NotifyPlayerBonus,
        JackpotInfoRequest,
        JackpotInfoResponse,
        TriggerCard,
        JackpotRecordsRequest,
        JackpotRecordsResponse,
        JackpotUserRecord,
        Product,
        Payment,
        WechatOrder,
        IapOrder,
        Order,
        MallProductsRequest,
        MallProductsResponse,
        MallPaymentsRequest,
        MallPaymentsResponse,
        MallOrderRequest,
        MallOrderResponse,
        MallBuyRequest,
        MallBuyResponse,
        MallPaymentNotify,
        MasterScoreRecord,
        MasterScoreStatistics,
        ContributionMasterScoreRequest,
        ContributionMasterScoreResponse,
        GrantMasterScoreRequest,
        GrantMasterScoreResponse,
        MasterScoreRecordsRequest,
        MasterScoreRecordsResponse,
        MasterScoreStatisticsRequest,
        MasterScoreStatisticsResponse,
        MasterScoreGainsRequest,
        MasterScoreGainsResponse,
        MasterScoreGainsData,
        JoinMTTRoomRequest,
        JoinMTTRoomResponse,
        PublicCardCostItem,
        HandPowerEnum1,
        RaceBlindTable,
        PlayerInfo,
        SitInfo1,
        Pot1,
        PubCard2,
        Card1,
        MTTConnectRequest,
        MTTGameUpdate,
        MTTReEntryNotify,
        MTTPurchaseRequest,
        MTTPurchaseResponse,
        MTTUnReEntryRequest,
        MTTUnReEntryResponse,
        MTTPlayerOverRankNotify,
        MTTOutRoomRequest,
        mttDetailRequest,
        mttDetailResponse,
        MTTBonusInfo,
        mttRankRequest,
        mttRankResponse,
        mttRankPlayer,
        mttDataRequest,
        mttDataResponse,
        MTTWatchRequest,
        MTTOverNotify,
        MTTPlayerReward,
        MTTMyRankRequest,
        MTTMyRankResponse,
        WaitingHandNotify,
        MttFinalTableNotify,
        OptionParams,
        RaceReward,
        NotifyParameter,
        Notification,
        TitleParam,
        DescParam,
        NotifyRequest,
        NotifyResponse,
        NotifyListRequest,
        NotifyListResponse,
        NotifyNewCommonRoom,
        authorityPlayerRebuyReq,
        authorityPlayerRebuyRes,
        PlayerServer,
        PlayerData,
        Player,
        ModifyPlayerInfoCost,
        PlayerUpdateStyleRequest,
        PlayerUpdateStyleResponse,
        Reconnect,
        PlayerToken,
        PlayerTokenRequest,
        PlayerTokenResponse,
        PlayerSignUpRequest,
        PlayerSignUpResponse,
        PlayerBindPhoneRequest,
        PlayerBindPhoneResponse,
        PlayerUnbindPhoneRequest,
        PlayerUnbindPhoneResponse,
        PlayerChangePasswordRequest,
        PlayerChangePasswordResponse,
        PlayerLoginRequest,
        PlayerLoginResponse,
        PlayerConnectRequest,
        PlayerConnectResponse,
        PlayerWechatLoginRequest,
        PlayerWechatLoginResponse,
        PlayerEditRequest,
        PlayerEditResponse,
        PlayerInfoRequest,
        PlayerInfoResponse,
        PlayerCaptchaRequest,
        PlayerCaptchaResponse,
        PlayerDailyGold,
        PlayerGoldUpdate,
        PlayerDiamondUpdate,
        PlayerLogoutRequest,
        PlayerLogoutResponse,
        getPlayerInfoRequest,
        getPlayerInfoResponse,
        EveryDayRewardItemTemplate,
        EveryDayRewardNotify,
        PlayerMasterScoresLog,
        GetPlayerMasterScoresLogRequest,
        GetPlayerMasterScoresLogResponse,
        SetPlayerSecondPasswordRequest,
        SetPlayerSecondPasswordResponse,
        SetPlayerPaySettingsRequest,
        SetPlayerPaySettingsResponse,
        NeedInputCodeResponse,
        CheckSecondPasswordPageRequest,
        CheckSecondPasswordResponse,
        VerifySecondPasswordRequest,
        GetPlayerSecondPasswordCaptchaRequest,
        GetPlayerSecondPasswordCaptchaResponse,
        BandWechatRequest,
        BandWechatResponse,
        VerifyDeviceLockSmsRequest,
        SetDeviceLockRequest,
        SetDeviceLockResponse,
        NotifyNextRoundStartRoomResponse,
        SitInfo3,
        StartCommonGameRoomResponse,
        LoginRequest,
        LoginResponse,
        RoomInfos,
        RoomInfo,
        CreatePokerRoomRequest,
        CreateSNGPokerRoomRequest,
        NotifySngStartBegin,
        CreatePokerRoomResponse,
        ConnectRoomServerRequest,
        ConnectRoomServerResponse,
        HeartbeatRequest,
        HeartbeatResponse,
        NotifyDestroyRoom,
        JoinRoomRequest,
        JoinRoomResponse,
        JoinSNGRoomRequest,
        JoinSNGRoomResponse,
        SitDownRequest,
        SitDownResponse,
        Cards,
        StandUpRequest,
        AdvanceLeaveTableRequest,
        AdvanceLeaveTableResponse,
        StandUpResponse,
        OutRoomRequest,
        OutRoomResponse,
        OutSngRoomRequest,
        OutSngRoomResponse,
        SngOverRankResponse,
        StartCommonGameRequest,
        NotifyUpBlindResponse,
        StartCommonGameResponse,
        StartSNGGameResponse,
        Card,
        SitInfo,
        PlayerCallRequest,
        PlayerCallResponse,
        NotifyFlopRoundResponse,
        DoPlayerResponse,
        ActionPlayerInfo,
        PlayerFoldRequest,
        PlayerFoldResponse,
        DoPlayerFoldResponse,
        PlayerCheckRequest,
        PlayerCheckResponse,
        DoPlayerCheckResponse,
        PlayerRaiseRequest,
        PlayerRaiseResponse,
        DoPlayerRaiseResponse,
        PlayerAllInRequest,
        PlayerAllInResponse,
        DoPlayerAllInResponse,
        PlayerReBuyRequest,
        NotifyPlayerReBuyResponse,
        PlayerUnReBuyRequest,
        NotifyGainsResponse,
        PlayerGainsInfo,
        HandPower,
        PubCard,
        HandCard,
        NotifyNextRoundStartResponse,
        NotifyReBuyResponse,
        ScorecardRequest,
        NotifyGameStopResponse,
        HandPowerEnum,
        ActionRequest,
        ReconnectionRequest,
        ReconnectionResponse,
        ReconnectionSitInfo,
        Pots,
        CommonRoomSitDownTermRequest,
        CommonRoomSitDownTermResponse,
        CancelCommonRoomSitDownTermRequest,
        CancelCommonRoomSitDownTermResponse,
        ConfirmBankRollRequest,
        ConfirmBankRollResponse,
        OverGameGainsShowCardRequest,
        NotifyOverGameGainsShowCardResponse,
        AdvStandUpResponse,
        AdvOutRoomResponse,
        CancelStandUpRequest,
        CancelStandUpResponse,
        CloseScorecardResponse,
        AddThinkTimeRequest,
        AddThinkTimeResponse,
        InteractionItemRequest,
        InteractionItemResponse,
        ShowEmojiRequest,
        ShowEmojiResponse,
        ReportAgroupOfCardRequest,
        ReportAgroupOfCardResponse,
        HideAgroupOfCardRequest,
        HideAgroupOfCardResponse,
        GpsStateResponse,
        NotifyAdvanceLeaveTable,
        WatchPublicCardRequest,
        WatchPublicCardResponse,
        KeepSitRequest,
        KeepSitResponse,
        CancelKeepSitRequest,
        CancelKeepSitResponse,
        DyPlayerRebuyNotEnough,
        DyRefusePlayerRebuy,
        StartClubRoomReq,
        StartClubRoomResp,
        SettlementClubGame,
        BringOutInfoRequest,
        BringOutInfoResponse,
        BringOutRequest,
        BringOutResponse,
        RankInfo,
        showRankConfigReq,
        showRankConfigRes,
        RankInfoReq,
        RankInfoRes,
        RaceListRequest,
        RaceListResponse,
        RaceInfos,
        RaceInfo,
        RaceApplyRequest,
        RaceApplyResponse,
        RaceCancelApplyRequest,
        RaceCancelApplyResponse,
        RaceMTTRequest,
        RaceMTTResponse,
        DefaultBlind,
        AwardTemplate,
        Awards,
        RacePlayerNumRequest,
        RacePlayerNumResponse,
        RaceStartResponse,
        RaceFinishResponse,
        RacePlayer,
        StartMTTNotify,
        RaceMttRewardRequest,
        RaceMttRewardResponse,
        BonusInfo,
        RaceMttRankRequest,
        RaceMttRankResponse,
        MttRankPlayer,
        RaceMttTableRequest,
        RaceMttTableResponse,
        RaceMttTable,
        RaceMTTGameIdRequest,
        RaceMTTGameIdResponse,
        RaceMTTBlindRequest,
        RaceMTTBlindResponse,
        MTTRevivalRequest,
        MTTRevivalResponse,
        ConmmonRankRequest,
        ConmmonRankResponse,
        OnLookers,
        ConmmonRank,
        SngRoomRank,
        SngRoomRankResponse,
        SNGRank,
        NotifyReLogin,
        RecordListRequest,
        RecordListResponse,
        Records,
        Record,
        RecordDetailRequest,
        RecordDetailResponse,
        RecordDetailInfo,
        RedPacketRankRequest,
        RedPacketRankResponse,
        RedPacketRank,
        RedPacketActivityRequest,
        RedPacketActivityResponse,
        ReplayRequest,
        ReplayResponse,
        ReplayInfo,
        ReplayListRequest,
        ReplayListResponse,
        ReplayLastRequest,
        ReplayLastResponse,
        ReplayPlayer,
        ReplayGain,
        ReplayGameInfo,
        ReplayPlayerAction,
        ReplayGameStage,
        ReplayGameGains,
        RoomSng,
        Room,
        CommonRoomListRequest,
        CommonRoomListResponse,
        RaceRoomListRequest,
        RaceRoomListResponse,
        RoomUpdateRequest,
        RequestRoom,
        RoomUpdateResponse,
        UpdateRoom,
        MyRoomListRequest,
        MyRoomListResponse,
        RoomTemple,
        RoomFilterPlayerCount,
        RoomFilterRestTime,
        RoomUpdateNotify,
        RoomInfoRequest,
        RoomInfoResponse,
        ClubRoomInfoRequest,
        ClubRoomInfoResponse,
        ShowPlayerInfoInRoomRequest,
        ShowPlayerInfoInRoomResponse,
        DeductPlayersItemRequest,
        DeductPlayersItemResponse,
        InteractionItem,
        CancelSngApplyRequest,
        CancelSngApplyResponse,
        NotifyCancelSngApplyResponse,
        SngDetailRequest,
        SngDetailResponse,
        SngBonusInfo,
        NotifyTrusteeshipResponse,
        CancelTrusteeshipRequest,
        VideoInfoListRequest,
        VideoInfoListResponse,
        CollectVideoRequest,
        CollectVideoResponse,
        CancelCollectVideoRequest,
        CancelCollectVideoResponse,
        HandReviewCollectVideoRequest,
        HandReviewCollectVideoResponse,
        CollectVideoListRequest,
        CollectVideoListResponse,
        VideoInfo,
        VoiceRoomRequest,
        VoiceRoomResponse,
        VoiceRoomNotify,
        OpenWalletPayRequest,
        OpenWalletPayResponse,
        PayRequest,
        PayResponse,
        OrderInfoRequest,
        OrderInfoResponse,
        OrderInfo,
        SetBankCardRequest,
        BankCardResponse,
        OpenWalletDrawRequest,
        OpenWalletDrawResponse,
        DrawRequest,
        DrawResponse,
        DrawCallBackResponse,
        SetWalletPwdRequest,
        SetWalletPwdResponse,
        WorldMessageNotify,
        contentParam
    }
}