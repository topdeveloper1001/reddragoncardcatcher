//-----------------------------------------------------------------------
// <copyright file="GeneratedModels.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel;

namespace RedDragonCardCatcher.Model
{
#pragma warning disable CS1591, CS0612, CS3021, IDE1006
    [ProtoContract]
    internal partial class Club : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint presidentId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string presidentName { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string logoUrl { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public string imageUrls { get; set; }

        [ProtoMember(6, Name = @"describe", IsRequired = true)]
        public string Describe { get; set; }

        [ProtoMember(7, Name = @"name", IsRequired = true)]
        public string Name { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public uint playerNumber { get; set; }

        [ProtoMember(9, Name = @"active", IsRequired = true)]
        public uint Active { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public ulong createTime { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public long masterScores { get; set; }

        [ProtoMember(12, Name = @"region", IsRequired = true)]
        public string Region { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public string businessCard { get; set; }

        [ProtoMember(14)]
        public long masterScoresThreshold
        {
            get { return __pbn__masterScoresThreshold.GetValueOrDefault(); }
            set { __pbn__masterScoresThreshold = value; }
        }
        public bool ShouldSerializemasterScoresThreshold() => __pbn__masterScoresThreshold != null;
        public void ResetmasterScoresThreshold() => __pbn__masterScoresThreshold = null;
        private long? __pbn__masterScoresThreshold;

        [ProtoMember(15, IsRequired = true)]
        public bool masterScoresThresholdSwitch { get; set; }

        [ProtoMember(16, IsRequired = true)]
        public uint totalPlayerNumbers { get; set; }

        [ProtoMember(17, IsRequired = true)]
        public ulong masterScoresTime { get; set; }

        [ProtoMember(18, IsRequired = true)]
        public uint maxPlayerNumber { get; set; }

        [ProtoMember(19, Name = @"price", IsRequired = true)]
        public float Price { get; set; }

        [ProtoMember(20, IsRequired = true)]
        public string presidentHead { get; set; }

        [ProtoMember(21, IsRequired = true)]
        public uint showGame { get; set; }

        [ProtoMember(22, Name = @"reduction", IsRequired = true)]
        public uint Reduction { get; set; }

        [ProtoMember(23)]
        public int roomCount
        {
            get { return __pbn__roomCount.GetValueOrDefault(); }
            set { __pbn__roomCount = value; }
        }
        public bool ShouldSerializeroomCount() => __pbn__roomCount != null;
        public void ResetroomCount() => __pbn__roomCount = null;
        private int? __pbn__roomCount;

        [ProtoMember(24)]
        public int clubRoomSwitch
        {
            get { return __pbn__clubRoomSwitch.GetValueOrDefault(); }
            set { __pbn__clubRoomSwitch = value; }
        }
        public bool ShouldSerializeclubRoomSwitch() => __pbn__clubRoomSwitch != null;
        public void ResetclubRoomSwitch() => __pbn__clubRoomSwitch = null;
        private int? __pbn__clubRoomSwitch;

        [ProtoMember(25, IsRequired = true)]
        public int masterScoreLock { get; set; }
    }

    [ProtoContract]
    internal partial class ClubNamePriceReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

    }

    [ProtoContract]
    internal partial class ClubNamePriceRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint namePrice { get; set; }

    }

    [ProtoContract]
    internal partial class ClubReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"num", IsRequired = true)]
        public uint Num { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint clubId { get; set; }

    }

    [ProtoContract]
    internal partial class ClubRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"club")]
        public Club Club { get; set; }

        [ProtoMember(2, Name = @"corpus", IsRequired = true)]
        public Corpus Corpus { get; set; } = Corpus.President;

        [ProtoMember(3)]
        public List<ClubPlayer> clubPlayers { get; } = new List<ClubPlayer>();

    }

    [ProtoContract]
    internal partial class ClubUpdateReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"name")]
        [DefaultValue("")]
        public string Name
        {
            get { return __pbn__Name ?? ""; }
            set { __pbn__Name = value; }
        }
        public bool ShouldSerializeName() => __pbn__Name != null;
        public void ResetName() => __pbn__Name = null;
        private string __pbn__Name;

        [ProtoMember(3, Name = @"region")]
        [DefaultValue("")]
        public string Region
        {
            get { return __pbn__Region ?? ""; }
            set { __pbn__Region = value; }
        }
        public bool ShouldSerializeRegion() => __pbn__Region != null;
        public void ResetRegion() => __pbn__Region = null;
        private string __pbn__Region;

        [ProtoMember(4, IsRequired = true)]
        public string imageUrls { get; set; }

        [ProtoMember(5)]
        [DefaultValue("")]
        public string logoUrl
        {
            get { return __pbn__logoUrl ?? ""; }
            set { __pbn__logoUrl = value; }
        }
        public bool ShouldSerializelogoUrl() => __pbn__logoUrl != null;
        public void ResetlogoUrl() => __pbn__logoUrl = null;
        private string __pbn__logoUrl;

        [ProtoMember(6, Name = @"describe")]
        [DefaultValue("")]
        public string Describe
        {
            get { return __pbn__Describe ?? ""; }
            set { __pbn__Describe = value; }
        }
        public bool ShouldSerializeDescribe() => __pbn__Describe != null;
        public void ResetDescribe() => __pbn__Describe = null;
        private string __pbn__Describe;

    }

    [ProtoContract]
    internal partial class ClubUpdateRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"name")]
        [DefaultValue("")]
        public string Name
        {
            get { return __pbn__Name ?? ""; }
            set { __pbn__Name = value; }
        }
        public bool ShouldSerializeName() => __pbn__Name != null;
        public void ResetName() => __pbn__Name = null;
        private string __pbn__Name;

        [ProtoMember(3, Name = @"region")]
        [DefaultValue("")]
        public string Region
        {
            get { return __pbn__Region ?? ""; }
            set { __pbn__Region = value; }
        }
        public bool ShouldSerializeRegion() => __pbn__Region != null;
        public void ResetRegion() => __pbn__Region = null;
        private string __pbn__Region;

        [ProtoMember(4, IsRequired = true)]
        public string imageUrls { get; set; }

        [ProtoMember(5)]
        [DefaultValue("")]
        public string logoUrl
        {
            get { return __pbn__logoUrl ?? ""; }
            set { __pbn__logoUrl = value; }
        }
        public bool ShouldSerializelogoUrl() => __pbn__logoUrl != null;
        public void ResetlogoUrl() => __pbn__logoUrl = null;
        private string __pbn__logoUrl;

        [ProtoMember(6, Name = @"describe")]
        [DefaultValue("")]
        public string Describe
        {
            get { return __pbn__Describe ?? ""; }
            set { __pbn__Describe = value; }
        }
        public bool ShouldSerializeDescribe() => __pbn__Describe != null;
        public void ResetDescribe() => __pbn__Describe = null;
        private string __pbn__Describe;

    }

    [ProtoContract]
    internal partial class ClubUpdateResN : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"name")]
        [DefaultValue("")]
        public string Name
        {
            get { return __pbn__Name ?? ""; }
            set { __pbn__Name = value; }
        }
        public bool ShouldSerializeName() => __pbn__Name != null;
        public void ResetName() => __pbn__Name = null;
        private string __pbn__Name;

        [ProtoMember(3, Name = @"region")]
        [DefaultValue("")]
        public string Region
        {
            get { return __pbn__Region ?? ""; }
            set { __pbn__Region = value; }
        }
        public bool ShouldSerializeRegion() => __pbn__Region != null;
        public void ResetRegion() => __pbn__Region = null;
        private string __pbn__Region;

        [ProtoMember(4, IsRequired = true)]
        public string imageUrls { get; set; }

        [ProtoMember(5)]
        [DefaultValue("")]
        public string logoUrl
        {
            get { return __pbn__logoUrl ?? ""; }
            set { __pbn__logoUrl = value; }
        }
        public bool ShouldSerializelogoUrl() => __pbn__logoUrl != null;
        public void ResetlogoUrl() => __pbn__logoUrl = null;
        private string __pbn__logoUrl;

        [ProtoMember(6, Name = @"describe")]
        [DefaultValue("")]
        public string Describe
        {
            get { return __pbn__Describe ?? ""; }
            set { __pbn__Describe = value; }
        }
        public bool ShouldSerializeDescribe() => __pbn__Describe != null;
        public void ResetDescribe() => __pbn__Describe = null;
        private string __pbn__Describe;

    }

    [ProtoContract]
    internal partial class IncreaseClubMemberReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"num", IsRequired = true)]
        public uint Num { get; set; }

    }

    [ProtoContract]
    internal partial class IncreaseClubMemberRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint totalPlayerNumbers { get; set; }

    }

    [ProtoContract]
    internal partial class IncreaseClubMemberResN : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint totalPlayerNumbers { get; set; }

    }

    [ProtoContract]
    internal partial class SettingClubFundReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint tagetClubId { get; set; }

        [ProtoMember(3)]
        public long masterScoresThreshold
        {
            get { return __pbn__masterScoresThreshold.GetValueOrDefault(); }
            set { __pbn__masterScoresThreshold = value; }
        }
        public bool ShouldSerializemasterScoresThreshold() => __pbn__masterScoresThreshold != null;
        public void ResetmasterScoresThreshold() => __pbn__masterScoresThreshold = null;
        private long? __pbn__masterScoresThreshold;

        [ProtoMember(4)]
        public bool masterScoresThresholdSwitch
        {
            get { return __pbn__masterScoresThresholdSwitch.GetValueOrDefault(); }
            set { __pbn__masterScoresThresholdSwitch = value; }
        }
        public bool ShouldSerializemasterScoresThresholdSwitch() => __pbn__masterScoresThresholdSwitch != null;
        public void ResetmasterScoresThresholdSwitch() => __pbn__masterScoresThresholdSwitch = null;
        private bool? __pbn__masterScoresThresholdSwitch;

    }

    [ProtoContract]
    internal partial class SettingClubFundRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public long masterScoresThreshold
        {
            get { return __pbn__masterScoresThreshold.GetValueOrDefault(); }
            set { __pbn__masterScoresThreshold = value; }
        }
        public bool ShouldSerializemasterScoresThreshold() => __pbn__masterScoresThreshold != null;
        public void ResetmasterScoresThreshold() => __pbn__masterScoresThreshold = null;
        private long? __pbn__masterScoresThreshold;

        [ProtoMember(2)]
        public bool masterScoresThresholdSwitch
        {
            get { return __pbn__masterScoresThresholdSwitch.GetValueOrDefault(); }
            set { __pbn__masterScoresThresholdSwitch = value; }
        }
        public bool ShouldSerializemasterScoresThresholdSwitch() => __pbn__masterScoresThresholdSwitch != null;
        public void ResetmasterScoresThresholdSwitch() => __pbn__masterScoresThresholdSwitch = null;
        private bool? __pbn__masterScoresThresholdSwitch;

    }

    [ProtoContract]
    internal partial class SettingClubFundResN : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public long masterScoresThreshold
        {
            get { return __pbn__masterScoresThreshold.GetValueOrDefault(); }
            set { __pbn__masterScoresThreshold = value; }
        }
        public bool ShouldSerializemasterScoresThreshold() => __pbn__masterScoresThreshold != null;
        public void ResetmasterScoresThreshold() => __pbn__masterScoresThreshold = null;
        private long? __pbn__masterScoresThreshold;

        [ProtoMember(2)]
        public bool masterScoresThresholdSwitch
        {
            get { return __pbn__masterScoresThresholdSwitch.GetValueOrDefault(); }
            set { __pbn__masterScoresThresholdSwitch = value; }
        }
        public bool ShouldSerializemasterScoresThresholdSwitch() => __pbn__masterScoresThresholdSwitch != null;
        public void ResetmasterScoresThresholdSwitch() => __pbn__masterScoresThresholdSwitch = null;
        private bool? __pbn__masterScoresThresholdSwitch;

    }

    [ProtoContract]
    internal partial class ChangeClubMasterScoreLockState : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint playerId { get; set; }

    }

    [ProtoContract]
    internal partial class ClubMasterScoreLockState : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int masterScoreLock { get; set; }

    }

    [ProtoContract]
    internal partial class ProvideClubMasterScore : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint targetId { get; set; }

        [ProtoMember(4, Name = @"value", IsRequired = true)]
        public ulong Value { get; set; }

    }

    [ProtoContract]
    internal partial class ProvideClubMasterScoreRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint targetId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public long masterScores { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long targetmasterScores { get; set; }

    }

    [ProtoContract]
    internal partial class ProvideClubMasterScoreNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint targetId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public long masterScores { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long targetmasterScores { get; set; }

    }

    [ProtoContract]
    internal partial class GetUpperClubIdAndNameReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

    }

    [ProtoContract]
    internal partial class GetUpperClubIdAndNameRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string businessCard { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string logoUrl { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string clubName { get; set; }

    }

    [ProtoContract]
    internal partial class ContributeMasterScoreToClub : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [ProtoMember(2, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(4, Name = @"value", IsRequired = true)]
        public ulong Value { get; set; }

    }

    [ProtoContract]
    internal partial class ManageClubFundReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint targetId { get; set; }

        [ProtoMember(4, Name = @"value", IsRequired = true)]
        public long Value { get; set; }

    }

    [ProtoContract]
    internal partial class ManageClubFundRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint targetId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public long masterScores { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long targetmasterScores { get; set; }

    }

    [ProtoContract]
    internal partial class ManageClubFundResN : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint targetId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public long masterScores { get; set; }

        [ProtoMember(4)]
        public long targetmasterScores
        {
            get { return __pbn__targetmasterScores.GetValueOrDefault(); }
            set { __pbn__targetmasterScores = value; }
        }
        public bool ShouldSerializetargetmasterScores() => __pbn__targetmasterScores != null;
        public void ResettargetmasterScores() => __pbn__targetmasterScores = null;
        private long? __pbn__targetmasterScores;

    }

    [ProtoContract]
    internal partial class ManageClubFundStatusReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint targetId { get; set; }

        [ProtoMember(4, Name = @"status", IsRequired = true)]
        public uint Status { get; set; }

    }

    [ProtoContract]
    internal partial class ManageClubFundStatusRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint targetId { get; set; }

        [ProtoMember(3, Name = @"status", IsRequired = true)]
        public uint Status { get; set; }

    }

    [ProtoContract]
    internal partial class ManageClubFundStatusResN : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint targetId { get; set; }

        [ProtoMember(3, Name = @"status", IsRequired = true)]
        public uint Status { get; set; }

    }

    [ProtoContract]
    internal partial class LowerClubsReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"num", IsRequired = true)]
        public uint Num { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint currentNum { get; set; }

    }

    [ProtoContract]
    internal partial class LowerClubsRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"clubs")]
        public List<Club> Clubs { get; } = new List<Club>();

        [ProtoMember(2, Name = @"total", IsRequired = true)]
        public uint Total { get; set; }

        [ProtoMember(3, Name = @"remain", IsRequired = true)]
        public uint Remain { get; set; }

    }

    [ProtoContract]
    internal partial class ManagerClubAuthorityReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint targetPalyerId { get; set; }

        [ProtoMember(3, Name = @"corpus", IsRequired = true)]
        public Corpus Corpus { get; set; } = Corpus.President;

    }

    [ProtoContract]
    internal partial class ManagerClubAuthorityRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint targetPalyerId { get; set; }

        [ProtoMember(2, Name = @"corpus", IsRequired = true)]
        public Corpus Corpus { get; set; } = Corpus.President;

    }

    [ProtoContract]
    internal partial class ManagerClubAuthorityResN : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint targetPalyerId { get; set; }

        [ProtoMember(2, Name = @"corpus", IsRequired = true)]
        public Corpus Corpus { get; set; } = Corpus.President;

    }

    [ProtoContract]
    internal partial class ClubMemberReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"num", IsRequired = true)]
        public uint Num { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint currentNum { get; set; }

        [ProtoMember(4, Name = @"condition")]
        public uint Condition
        {
            get { return __pbn__Condition.GetValueOrDefault(); }
            set { __pbn__Condition = value; }
        }
        public bool ShouldSerializeCondition() => __pbn__Condition != null;
        public void ResetCondition() => __pbn__Condition = null;
        private uint? __pbn__Condition;

        [ProtoMember(5, Name = @"value")]
        [DefaultValue("")]
        public string Value
        {
            get { return __pbn__Value ?? ""; }
            set { __pbn__Value = value; }
        }
        public bool ShouldSerializeValue() => __pbn__Value != null;
        public void ResetValue() => __pbn__Value = null;
        private string __pbn__Value;

    }

    [ProtoContract]
    internal partial class ClubMemberRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public List<ClubPlayer> clubPlayers { get; } = new List<ClubPlayer>();

        [ProtoMember(2, Name = @"total", IsRequired = true)]
        public uint Total { get; set; }

        [ProtoMember(3, Name = @"remain", IsRequired = true)]
        public uint Remain { get; set; }

    }

    [ProtoContract]
    internal partial class ClubMemberChangeResN : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint currentPlayerNumber { get; set; }

    }

    [ProtoContract]
    internal partial class MasterScoreDetailReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(2, Name = @"page", DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int Page { get; set; }

        [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int pageSize { get; set; }

    }

    [ProtoContract]
    internal partial class MasterScoreDetailRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"page", DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int Page { get; set; }

        [ProtoMember(2)]
        public List<MasterScoreRecord> masterScoreRecords { get; } = new List<MasterScoreRecord>();

    }

    [ProtoContract]
    internal partial class MasterScoreRecordsReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(2, Name = @"page", DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int Page { get; set; }

        [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int pageSize { get; set; }

    }

    [ProtoContract]
    internal partial class MasterScoreRecordsRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"page", DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int Page { get; set; }

        [ProtoMember(2)]
        public List<MasterScoreRecord> masterScoreRecords { get; } = new List<MasterScoreRecord>();

    }

    [ProtoContract]
    internal partial class MasterScoreGainsReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int clubId { get; set; }

    }

    [ProtoContract]
    internal partial class MasterScoreGainsRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"masterScoreGainsData")]
        public List<MasterScoreGainsData> masterScoreGainsDatas { get; } = new List<MasterScoreGainsData>();

    }

    [ProtoContract]
    internal partial class SubClubRebateReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int clubId { get; set; }

    }

    [ProtoContract]
    internal partial class SubClubRebateRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"subClubRebate")]
        public List<SubClubRebateData> subClubRebates { get; } = new List<SubClubRebateData>();

    }

    [ProtoContract]
    internal partial class ClubPlayer : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id")]
        public ulong Id
        {
            get { return __pbn__Id.GetValueOrDefault(); }
            set { __pbn__Id = value; }
        }
        public bool ShouldSerializeId() => __pbn__Id != null;
        public void ResetId() => __pbn__Id = null;
        private ulong? __pbn__Id;

        [ProtoMember(2)]
        public uint playerId
        {
            get { return __pbn__playerId.GetValueOrDefault(); }
            set { __pbn__playerId = value; }
        }
        public bool ShouldSerializeplayerId() => __pbn__playerId != null;
        public void ResetplayerId() => __pbn__playerId = null;
        private uint? __pbn__playerId;

        [ProtoMember(3)]
        [DefaultValue("")]
        public string playerName
        {
            get { return __pbn__playerName ?? ""; }
            set { __pbn__playerName = value; }
        }
        public bool ShouldSerializeplayerName() => __pbn__playerName != null;
        public void ResetplayerName() => __pbn__playerName = null;
        private string __pbn__playerName;

        [ProtoMember(4, IsRequired = true)]
        public Corpus playerDuties { get; set; } = Corpus.President;

        [ProtoMember(5)]
        public ulong joinClubTime
        {
            get { return __pbn__joinClubTime.GetValueOrDefault(); }
            set { __pbn__joinClubTime = value; }
        }
        public bool ShouldSerializejoinClubTime() => __pbn__joinClubTime != null;
        public void ResetjoinClubTime() => __pbn__joinClubTime = null;
        private ulong? __pbn__joinClubTime;

        [ProtoMember(6, IsRequired = true)]
        public string playerHeaderUrl { get; set; }

        [ProtoMember(7)]
        public long masterScore
        {
            get { return __pbn__masterScore.GetValueOrDefault(); }
            set { __pbn__masterScore = value; }
        }
        public bool ShouldSerializemasterScore() => __pbn__masterScore != null;
        public void ResetmasterScore() => __pbn__masterScore = null;
        private long? __pbn__masterScore;

        [ProtoMember(8, Name = @"diamond")]
        public long Diamond
        {
            get { return __pbn__Diamond.GetValueOrDefault(); }
            set { __pbn__Diamond = value; }
        }
        public bool ShouldSerializeDiamond() => __pbn__Diamond != null;
        public void ResetDiamond() => __pbn__Diamond = null;
        private long? __pbn__Diamond;

        [ProtoMember(9)]
        public uint masterScoreStatus
        {
            get { return __pbn__masterScoreStatus.GetValueOrDefault(); }
            set { __pbn__masterScoreStatus = value; }
        }
        public bool ShouldSerializemasterScoreStatus() => __pbn__masterScoreStatus != null;
        public void ResetmasterScoreStatus() => __pbn__masterScoreStatus = null;
        private uint? __pbn__masterScoreStatus;

    }

    [ProtoContract]
    internal partial class GenerateCodeRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class GenerateCodeResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"code", IsRequired = true)]
        public string Code { get; set; }

    }

    [ProtoContract]
    internal partial class InviteCodeRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int codeType { get; set; }

    }

    [ProtoContract]
    internal partial class InviteCodeResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int codeType { get; set; }

        [ProtoMember(2)]
        public List<InviteCode> inviteCodes { get; } = new List<InviteCode>();

        [ProtoMember(3, IsRequired = true)]
        public string registerUrl { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public bool canGenSubClub { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public string clubName { get; set; }

    }

    [ProtoContract]
    internal partial class InviteCode : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"code", IsRequired = true)]
        public string Code { get; set; }

        [ProtoMember(2, Name = @"status", IsRequired = true)]
        public int Status { get; set; }

    }

    [ProtoContract]
    internal partial class PsDefaultChangeClubReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"code", IsRequired = true)]
        public string Code { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint oldClubId { get; set; }

    }

    [ProtoContract]
    internal partial class PsDefaultChangeClubResp : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint newClubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string newClubName { get; set; }

    }

    [ProtoContract]
    internal partial class GetClubRoomTemplateReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

    }

    [ProtoContract]
    internal partial class GetClubRoomTemplateResp : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"clubRoomTemplate")]
        public List<ClubRoomTemplate> clubRoomTemplates { get; } = new List<ClubRoomTemplate>();

    }

    [ProtoContract]
    internal partial class ClubRoomTemplate : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public int Id { get; set; }

        [ProtoMember(2, Name = @"type", IsRequired = true)]
        public int Type { get; set; }

        [ProtoMember(3, Name = @"blind", IsRequired = true)]
        public string Blind { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int playerCount { get; set; }

        [ProtoMember(5, Name = @"bankroll", IsRequired = true)]
        public string Bankroll { get; set; }

        [ProtoMember(6, Name = @"time", IsRequired = true)]
        public int Time { get; set; }

        [ProtoMember(7, Name = @"insurance", IsRequired = true)]
        public int Insurance { get; set; }

        [ProtoMember(8, Name = @"straddle", IsRequired = true)]
        public int Straddle { get; set; }

        [ProtoMember(9, Name = @"gps", IsRequired = true)]
        public int Gps { get; set; }

        [ProtoMember(10, Name = @"grant", IsRequired = true)]
        public int Grant { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(12, Name = @"ante")]
        public long Ante
        {
            get { return __pbn__Ante.GetValueOrDefault(); }
            set { __pbn__Ante = value; }
        }
        public bool ShouldSerializeAnte() => __pbn__Ante != null;
        public void ResetAnte() => __pbn__Ante = null;
        private long? __pbn__Ante;

        [ProtoMember(13)]
        public int dealerMultiple
        {
            get { return __pbn__dealerMultiple.GetValueOrDefault(); }
            set { __pbn__dealerMultiple = value; }
        }
        public bool ShouldSerializedealerMultiple() => __pbn__dealerMultiple != null;
        public void ResetdealerMultiple() => __pbn__dealerMultiple = null;
        private int? __pbn__dealerMultiple;

        [ProtoMember(16)]
        public int canBringOut
        {
            get { return __pbn__canBringOut.GetValueOrDefault(); }
            set { __pbn__canBringOut = value; }
        }
        public bool ShouldSerializecanBringOut() => __pbn__canBringOut != null;
        public void ResetcanBringOut() => __pbn__canBringOut = null;
        private int? __pbn__canBringOut;

        [ProtoMember(17)]
        public float minKeepMultiple
        {
            get { return __pbn__minKeepMultiple.GetValueOrDefault(); }
            set { __pbn__minKeepMultiple = value; }
        }
        public bool ShouldSerializeminKeepMultiple() => __pbn__minKeepMultiple != null;
        public void ResetminKeepMultiple() => __pbn__minKeepMultiple = null;
        private float? __pbn__minKeepMultiple;

        [ProtoMember(18)]
        public float bringOutMultiple
        {
            get { return __pbn__bringOutMultiple.GetValueOrDefault(); }
            set { __pbn__bringOutMultiple = value; }
        }
        public bool ShouldSerializebringOutMultiple() => __pbn__bringOutMultiple != null;
        public void ResetbringOutMultiple() => __pbn__bringOutMultiple = null;
        private float? __pbn__bringOutMultiple;

    }

    [ProtoContract]
    internal partial class DeleteClubRoomTemplateReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"id", IsRequired = true)]
        public int Id { get; set; }

    }

    [ProtoContract]
    internal partial class DeleteClubRoomTemplateResp : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"state", IsRequired = true)]
        public int State { get; set; }

        [ProtoMember(2, Name = @"id", IsRequired = true)]
        public int Id { get; set; }

    }

    [ProtoContract]
    internal partial class CreateClubRoomTemplateReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(2, Name = @"bb", IsRequired = true)]
        public int Bb { get; set; }

        [ProtoMember(3, Name = @"bankroll", IsRequired = true)]
        public int Bankroll { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int playerCount { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int keepTime { get; set; }

        [ProtoMember(6, Name = @"ante", IsRequired = true)]
        public int Ante { get; set; }

        [ProtoMember(7, Name = @"multiple", IsRequired = true)]
        public int Multiple { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int thinkTime { get; set; }

        [ProtoMember(9, Name = @"insurance", IsRequired = true)]
        public int Insurance { get; set; }

        [ProtoMember(10, Name = @"straddle", IsRequired = true)]
        public int Straddle { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public int gpsIp { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public int clubRoomApproveSwitch { get; set; }

        [ProtoMember(14, Name = @"sb", IsRequired = true)]
        public int Sb { get; set; }

        [ProtoMember(15, IsRequired = true)]
        public int dealerMultiple { get; set; }

        [ProtoMember(16, IsRequired = true)]
        public int canBringOut { get; set; }

        [ProtoMember(17, IsRequired = true)]
        public float minKeepMultiple { get; set; }

        [ProtoMember(18, IsRequired = true)]
        public float bringOutMultiple { get; set; }

        [ProtoMember(19, IsRequired = true)]
        public int playType { get; set; }

        [ProtoMember(20, IsRequired = true)]
        public int raiseLimitFixed { get; set; }

        [ProtoMember(21, IsRequired = true)]
        public float raiseLimitPot { get; set; }

    }

    [ProtoContract]
    internal partial class CreateClubRoomTemplateResp : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"state", IsRequired = true)]
        public int State { get; set; }

    }

    [ProtoContract]
    internal partial class CreateClubRoomReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"id", IsRequired = true)]
        public int Id { get; set; }

    }

    [ProtoContract]
    internal partial class CreateClubRoomResp : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"state", IsRequired = true)]
        public bool State { get; set; }

    }

    [ProtoContract]
    internal partial class ClubIncomeStaticsReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int clubId { get; set; }

    }

    [ProtoContract]
    internal partial class ClubIncomeStaticsRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public List<ClubIncomeStatics> clubIncomeStatics { get; } = new List<ClubIncomeStatics>();

    }

    [ProtoContract]
    internal partial class ClubIncomeStatics : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int timeType { get; set; }

        [ProtoMember(2, Name = @"prebates", IsRequired = true)]
        public long Prebates { get; set; }

        [ProtoMember(3, Name = @"pinsurance", IsRequired = true)]
        public long Pinsurance { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long jpBonus { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public long clubRaceData { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerContributeToClubInfoReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);
    }

    [ProtoContract]
    internal partial class PlayerContributeToClubInfoRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"score")]
        public uint Score
        {
            get { return __pbn__Score.GetValueOrDefault(); }
            set { __pbn__Score = value; }
        }
        public bool ShouldSerializeScore() => __pbn__Score != null;
        public void ResetScore() => __pbn__Score = null;
        private uint? __pbn__Score;

        [ProtoMember(2)]
        public uint toHonor
        {
            get { return __pbn__toHonor.GetValueOrDefault(); }
            set { __pbn__toHonor = value; }
        }
        public bool ShouldSerializetoHonor() => __pbn__toHonor != null;
        public void ResettoHonor() => __pbn__toHonor = null;
        private uint? __pbn__toHonor;

        [ProtoMember(3)]
        public float withdrawFee
        {
            get { return __pbn__withdrawFee.GetValueOrDefault(); }
            set { __pbn__withdrawFee = value; }
        }
        public bool ShouldSerializewithdrawFee() => __pbn__withdrawFee != null;
        public void ResetwithdrawFee() => __pbn__withdrawFee = null;
        private float? __pbn__withdrawFee;

    }

    [ProtoContract]
    internal partial class NotifyPlayerRoomDestory : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyGameOverResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(4, Name = @"gameResult")]
        public List<GameResult> gameResults { get; } = new List<GameResult>();

        [ProtoMember(5, IsRequired = true)]
        public int handCount { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public long maxPot { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public long allBankroll { get; set; }

        [ProtoMember(8, Name = @"gains", IsRequired = true)]
        public long Gains { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public string createrName { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public string createrIcon { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public int sitCount { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public string createTime { get; set; }

        [ProtoMember(14, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(15, IsRequired = true)]
        public int gameTime { get; set; }

        [ProtoMember(16, IsRequired = true)]
        public int roomType { get; set; }

        [ProtoMember(17, IsRequired = true)]
        public int bankrollType { get; set; }

        [ProtoMember(18, Name = @"insurance", IsRequired = true)]
        public int Insurance { get; set; }

        [ProtoMember(19, Name = @"straddle", IsRequired = true)]
        public int Straddle { get; set; }

        [ProtoMember(20, Name = @"sb")]
        public long Sb
        {
            get { return __pbn__Sb.GetValueOrDefault(); }
            set { __pbn__Sb = value; }
        }
        public bool ShouldSerializeSb() => __pbn__Sb != null;
        public void ResetSb() => __pbn__Sb = null;
        private long? __pbn__Sb;

    }

    [ProtoContract]
    internal partial class GameResult : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public long initBankroll { get; set; }

        [ProtoMember(4, Name = @"ganis", IsRequired = true)]
        public long Ganis { get; set; }

        [ProtoMember(5, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

        [ProtoMember(6)]
        public long totalInsurance
        {
            get { return __pbn__totalInsurance.GetValueOrDefault(); }
            set { __pbn__totalInsurance = value; }
        }
        public bool ShouldSerializetotalInsurance() => __pbn__totalInsurance != null;
        public void ResettotalInsurance() => __pbn__totalInsurance = null;
        private long? __pbn__totalInsurance;

        [ProtoMember(7)]
        public int handCount
        {
            get { return __pbn__handCount.GetValueOrDefault(); }
            set { __pbn__handCount = value; }
        }
        public bool ShouldSerializehandCount() => __pbn__handCount != null;
        public void ResethandCount() => __pbn__handCount = null;
        private int? __pbn__handCount;

    }

    [ProtoContract]
    internal partial class GameRule : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string applyCost { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public long initChip { get; set; }

        [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int actionCount { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int signUpType { get; set; }

    }

    [ProtoContract]
    internal partial class NotifySngRewardResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"sngReward")]
        public List<sngReward> sngRewards { get; } = new List<sngReward>();

        [ProtoMember(2, IsRequired = true)]
        public GameRule gameRule { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public string createrName { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public string createrIcon { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int sitCount { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public string createTime { get; set; }

        [ProtoMember(10, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public int gameTime { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public int roomType { get; set; }

        [ProtoMember(13, Name = @"insurance", IsRequired = true)]
        public int Insurance { get; set; }

        [ProtoMember(14, Name = @"straddle", IsRequired = true)]
        public int Straddle { get; set; }

    }

    [ProtoContract]
    internal partial class sngReward : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"rank", IsRequired = true)]
        public int Rank { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(4)]
        public int rewardGold
        {
            get { return __pbn__rewardGold.GetValueOrDefault(); }
            set { __pbn__rewardGold = value; }
        }
        public bool ShouldSerializerewardGold() => __pbn__rewardGold != null;
        public void ResetrewardGold() => __pbn__rewardGold = null;
        private int? __pbn__rewardGold;

        [ProtoMember(5, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

        [ProtoMember(6)]
        [DefaultValue("")]
        public string rewardItems
        {
            get { return __pbn__rewardItems ?? ""; }
            set { __pbn__rewardItems = value; }
        }
        public bool ShouldSerializerewardItems() => __pbn__rewardItems != null;
        public void ResetrewardItems() => __pbn__rewardItems = null;
        private string __pbn__rewardItems;

    }

    [ProtoContract]
    internal partial class CareerRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint roomType { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint playType { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public uint dateType { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public uint reqType { get; set; }

    }

    [ProtoContract]
    internal partial class CareerResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public CareerData careerData { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public CareerProcessData careerProcessData { get; set; }

    }

    [ProtoContract]
    internal partial class CareerData : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"hands", IsRequired = true)]
        public uint Hands { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint winHands { get; set; }

        [ProtoMember(3, Name = @"bets", IsRequired = true)]
        public uint Bets { get; set; }

        [ProtoMember(4, Name = @"raises", IsRequired = true)]
        public uint Raises { get; set; }

        [ProtoMember(5, Name = @"calls", IsRequired = true)]
        public uint Calls { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public uint threeBets { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public string winBBs { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public string maxWinBBs { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public long maxWinChips { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public string maxCards { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public long totalWinChips { get; set; }

        [ProtoMember(12, Name = @"vps", IsRequired = true)]
        public uint Vps { get; set; }

        [ProtoMember(13, Name = @"rounds", IsRequired = true)]
        public uint Rounds { get; set; }

        [ProtoMember(14, Name = @"steals", IsRequired = true)]
        public uint Steals { get; set; }

        [ProtoMember(15, IsRequired = true)]
        public uint winSteals { get; set; }

        [ProtoMember(16, IsRequired = true)]
        public uint otherSteals { get; set; }

        [ProtoMember(17, IsRequired = true)]
        public uint foldToSteals { get; set; }

        [ProtoMember(18, IsRequired = true)]
        public uint continueBets { get; set; }

        [ProtoMember(19, IsRequired = true)]
        public uint otherContinueBets { get; set; }

        [ProtoMember(20, IsRequired = true)]
        public uint foldToContinueBets { get; set; }

        [ProtoMember(21, Name = @"flops", IsRequired = true)]
        public uint Flops { get; set; }

        [ProtoMember(22, Name = @"turns", IsRequired = true)]
        public uint Turns { get; set; }

        [ProtoMember(23, Name = @"rivers", IsRequired = true)]
        public uint Rivers { get; set; }

        [ProtoMember(24, IsRequired = true)]
        public uint preFlopRaises { get; set; }

        [ProtoMember(25, IsRequired = true)]
        public uint wentToShutDowns { get; set; }

        [ProtoMember(26, IsRequired = true)]
        public uint winWentToShutDowns { get; set; }

        [ProtoMember(27, Name = @"allins", IsRequired = true)]
        public uint Allins { get; set; }

        [ProtoMember(28, IsRequired = true)]
        public uint winAllins { get; set; }

        [ProtoMember(29, IsRequired = true)]
        public uint totalMatchs { get; set; }

        [ProtoMember(30, Name = @"champions", IsRequired = true)]
        public uint Champions { get; set; }

        [ProtoMember(31, IsRequired = true)]
        public uint rewardCircles { get; set; }

        [ProtoMember(32, IsRequired = true)]
        public long totalLoseChip { get; set; }

        [ProtoMember(33, IsRequired = true)]
        public long totalRebuy { get; set; }

        [ProtoMember(34, IsRequired = true)]
        public uint vpWinHands { get; set; }

        [ProtoMember(35, IsRequired = true)]
        public int rewardItemId { get; set; }

    }

    [ProtoContract]
    internal partial class CareerProcessData : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string vpWinRate { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string vpRate { get; set; }

        [ProtoMember(3, Name = @"hands", IsRequired = true)]
        public uint Hands { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public uint totalMatchs { get; set; }

        [ProtoMember(5, Name = @"champions", IsRequired = true)]
        public uint Champions { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public uint rewardCircles { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public string winRate { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public string aggressionFactor { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public string threeBetRate { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public string stealRate { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public string winStealRate { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public string foldToStealRate { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public string preFlopRaiseRate { get; set; }

        [ProtoMember(14, IsRequired = true)]
        public string continueBetRate { get; set; }

        [ProtoMember(15, IsRequired = true)]
        public string foldToContinuBetRate { get; set; }

        [ProtoMember(16, IsRequired = true)]
        public string wentToShowDownRate { get; set; }

        [ProtoMember(17, IsRequired = true)]
        public string winWentToShowDownRate { get; set; }

        [ProtoMember(18, IsRequired = true)]
        public string allinRate { get; set; }

        [ProtoMember(19, IsRequired = true)]
        public string allinWinRate { get; set; }

        [ProtoMember(20, IsRequired = true)]
        public string perWinBB { get; set; }

        [ProtoMember(21, IsRequired = true)]
        public string perRebuy { get; set; }

        [ProtoMember(22, Name = @"profit", IsRequired = true)]
        public long Profit { get; set; }

        [ProtoMember(23, IsRequired = true)]
        public int rewardItemId { get; set; }

    }

    [ProtoContract]
    internal partial class ChatMessage : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public ulong Id { get; set; }

        [ProtoMember(2, Name = @"type", IsRequired = true)]
        public ChatType Type { get; set; } = ChatType.ChatClub;

        [ProtoMember(3, Name = @"text", IsRequired = true)]
        public string Text { get; set; }

        [ProtoMember(4, Name = @"time", IsRequired = true)]
        public uint Time { get; set; }

    }

    [ProtoContract]
    internal partial class ChatRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"type", IsRequired = true)]
        public ChatType Type { get; set; } = ChatType.ChatClub;

        [ProtoMember(2, Name = @"text", IsRequired = true)]
        public string Text { get; set; }

        [ProtoMember(10)]
        public uint clubId
        {
            get { return __pbn__clubId.GetValueOrDefault(); }
            set { __pbn__clubId = value; }
        }
        public bool ShouldSerializeclubId() => __pbn__clubId != null;
        public void ResetclubId() => __pbn__clubId = null;
        private uint? __pbn__clubId;

    }

    [ProtoContract]
    internal partial class ChatResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class ChatNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"message", IsRequired = true)]
        public ChatMessage Message { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint playerId { get; set; }

    }

    [ProtoContract]
    internal partial class ClubNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"club", IsRequired = true)]
        public Club Club { get; set; }

    }

    [ProtoContract]
    internal partial class ClubApplication : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint applicationPlayerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string applicationPlayerName { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public uint approveId { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public string approveName { get; set; }

        [ProtoMember(6, Name = @"describe", IsRequired = true)]
        public string Describe { get; set; }

        [ProtoMember(7, Name = @"status", IsRequired = true)]
        public ApplStatus Status { get; set; } = ApplStatus.Wait;

        [ProtoMember(8, IsRequired = true)]
        public uint clubId { get; set; }

    }

    [ProtoContract]
    internal partial class OfficialRoom : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

        [ProtoMember(2, Name = @"bb", IsRequired = true)]
        public uint Bb { get; set; }

        [ProtoMember(3, Name = @"blind", IsRequired = true)]
        public string Blind { get; set; }

        [ProtoMember(4)]
        public bool isCheck
        {
            get { return __pbn__isCheck.GetValueOrDefault(); }
            set { __pbn__isCheck = value; }
        }
        public bool ShouldSerializeisCheck() => __pbn__isCheck != null;
        public void ResetisCheck() => __pbn__isCheck = null;
        private bool? __pbn__isCheck;

        [ProtoMember(5, IsRequired = true)]
        public int playType { get; set; }

    }

    [ProtoContract]
    internal partial class ClubCreateRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"name", IsRequired = true)]
        public string Name { get; set; }

        [ProtoMember(2, Name = @"region", IsRequired = true)]
        public string Region { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string logoUrl { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string imageUrl { get; set; }

        [ProtoMember(5, Name = @"describe", IsRequired = true)]
        public string Describe { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public uint rechargeNumber { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public string superiorClubId { get; set; }

    }

    [ProtoContract]
    internal partial class ClubCreateResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"club")]
        public List<Club> Clubs { get; } = new List<Club>();

    }

    [ProtoContract]
    internal partial class AllOfficialRoomRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public uint clubId
        {
            get { return __pbn__clubId.GetValueOrDefault(); }
            set { __pbn__clubId = value; }
        }
        public bool ShouldSerializeclubId() => __pbn__clubId != null;
        public void ResetclubId() => __pbn__clubId = null;
        private uint? __pbn__clubId;

    }

    [ProtoContract]
    internal partial class AllOfficialRoomResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"officialRoom")]
        public List<OfficialRoom> officialRooms { get; } = new List<OfficialRoom>();

    }

    [ProtoContract]
    internal partial class SetClubOfficialRoomRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"officialRoom")]
        public List<OfficialRoom> officialRooms { get; } = new List<OfficialRoom>();

    }

    [ProtoContract]
    internal partial class SetClubOfficialRoomResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class FindClubOfficealRoomRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

    }

    [ProtoContract]
    internal partial class FindClubOfficealRoomResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string clubName { get; set; }

        [ProtoMember(3, Name = @"officialRoom")]
        public List<OfficialRoom> officialRooms { get; } = new List<OfficialRoom>();

    }

    [ProtoContract]
    internal partial class FindTableRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"blind", IsRequired = true)]
        public string Blind { get; set; }

        [ProtoMember(3, Name = @"page", IsRequired = true)]
        public uint Page { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public uint pageSize { get; set; }

    }

    [ProtoContract]
    internal partial class FindTableResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(3, Name = @"room")]
        public List<Room> Rooms { get; } = new List<Room>();

    }

    [ProtoContract]
    internal partial class FindAllTableRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(3, Name = @"page", IsRequired = true)]
        public uint Page { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public uint pageSize { get; set; }

    }

    [ProtoContract]
    internal partial class FindAllTableResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(3, Name = @"room")]
        public List<Room> Rooms { get; } = new List<Room>();

    }

    [ProtoContract]
    internal partial class FindClubAndClubPlayersRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2)]
        public uint playerId
        {
            get { return __pbn__playerId.GetValueOrDefault(); }
            set { __pbn__playerId = value; }
        }
        public bool ShouldSerializeplayerId() => __pbn__playerId != null;
        public void ResetplayerId() => __pbn__playerId = null;
        private uint? __pbn__playerId;

        [ProtoMember(3, Name = @"page")]
        public uint Page
        {
            get { return __pbn__Page.GetValueOrDefault(); }
            set { __pbn__Page = value; }
        }
        public bool ShouldSerializePage() => __pbn__Page != null;
        public void ResetPage() => __pbn__Page = null;
        private uint? __pbn__Page;

        [ProtoMember(4)]
        public uint pageSize
        {
            get { return __pbn__pageSize.GetValueOrDefault(); }
            set { __pbn__pageSize = value; }
        }
        public bool ShouldSerializepageSize() => __pbn__pageSize != null;
        public void ResetpageSize() => __pbn__pageSize = null;
        private uint? __pbn__pageSize;

        [ProtoMember(5, Name = @"type")]
        [DefaultValue("")]
        public string Type
        {
            get { return __pbn__Type ?? ""; }
            set { __pbn__Type = value; }
        }
        public bool ShouldSerializeType() => __pbn__Type != null;
        public void ResetType() => __pbn__Type = null;
        private string __pbn__Type;

    }

    [ProtoContract]
    internal partial class FindClubAndClubPlayersResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"club", IsRequired = true)]
        public Club Club { get; set; }

        [ProtoMember(2, Name = @"clubPlayer")]
        public List<ClubPlayer> clubPlayers { get; } = new List<ClubPlayer>();

        [ProtoMember(3)]
        public ClubPlayer clubPlayerMe { get; set; }

    }

    [ProtoContract]
    internal partial class ClubUpdateRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"name")]
        [DefaultValue("")]
        public string Name
        {
            get { return __pbn__Name ?? ""; }
            set { __pbn__Name = value; }
        }
        public bool ShouldSerializeName() => __pbn__Name != null;
        public void ResetName() => __pbn__Name = null;
        private string __pbn__Name;

        [ProtoMember(3, Name = @"region")]
        [DefaultValue("")]
        public string Region
        {
            get { return __pbn__Region ?? ""; }
            set { __pbn__Region = value; }
        }
        public bool ShouldSerializeRegion() => __pbn__Region != null;
        public void ResetRegion() => __pbn__Region = null;
        private string __pbn__Region;

        [ProtoMember(4)]
        [DefaultValue("")]
        public string imageUrl
        {
            get { return __pbn__imageUrl ?? ""; }
            set { __pbn__imageUrl = value; }
        }
        public bool ShouldSerializeimageUrl() => __pbn__imageUrl != null;
        public void ResetimageUrl() => __pbn__imageUrl = null;
        private string __pbn__imageUrl;

        [ProtoMember(5)]
        [DefaultValue("")]
        public string logoUrl
        {
            get { return __pbn__logoUrl ?? ""; }
            set { __pbn__logoUrl = value; }
        }
        public bool ShouldSerializelogoUrl() => __pbn__logoUrl != null;
        public void ResetlogoUrl() => __pbn__logoUrl = null;
        private string __pbn__logoUrl;

        [ProtoMember(6, Name = @"describe")]
        [DefaultValue("")]
        public string Describe
        {
            get { return __pbn__Describe ?? ""; }
            set { __pbn__Describe = value; }
        }
        public bool ShouldSerializeDescribe() => __pbn__Describe != null;
        public void ResetDescribe() => __pbn__Describe = null;
        private string __pbn__Describe;

        [ProtoMember(7)]
        public bool autoApproval
        {
            get { return __pbn__autoApproval.GetValueOrDefault(); }
            set { __pbn__autoApproval = value; }
        }
        public bool ShouldSerializeautoApproval() => __pbn__autoApproval != null;
        public void ResetautoApproval() => __pbn__autoApproval = null;
        private bool? __pbn__autoApproval;

    }

    [ProtoContract]
    internal partial class ClubUpdateResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"club", IsRequired = true)]
        public Club Club { get; set; }

    }

    [ProtoContract]
    internal partial class ClubSearchRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"page")]
        public uint Page
        {
            get { return __pbn__Page.GetValueOrDefault(); }
            set { __pbn__Page = value; }
        }
        public bool ShouldSerializePage() => __pbn__Page != null;
        public void ResetPage() => __pbn__Page = null;
        private uint? __pbn__Page;

        [ProtoMember(2)]
        public uint pageSize
        {
            get { return __pbn__pageSize.GetValueOrDefault(); }
            set { __pbn__pageSize = value; }
        }
        public bool ShouldSerializepageSize() => __pbn__pageSize != null;
        public void ResetpageSize() => __pbn__pageSize = null;
        private uint? __pbn__pageSize;

        [ProtoMember(3)]
        [DefaultValue("")]
        public string clubIds
        {
            get { return __pbn__clubIds ?? ""; }
            set { __pbn__clubIds = value; }
        }
        public bool ShouldSerializeclubIds() => __pbn__clubIds != null;
        public void ResetclubIds() => __pbn__clubIds = null;
        private string __pbn__clubIds;

        [ProtoMember(4, Name = @"name")]
        [DefaultValue("")]
        public string Name
        {
            get { return __pbn__Name ?? ""; }
            set { __pbn__Name = value; }
        }
        public bool ShouldSerializeName() => __pbn__Name != null;
        public void ResetName() => __pbn__Name = null;
        private string __pbn__Name;

        [ProtoMember(5, Name = @"region")]
        [DefaultValue("")]
        public string Region
        {
            get { return __pbn__Region ?? ""; }
            set { __pbn__Region = value; }
        }
        public bool ShouldSerializeRegion() => __pbn__Region != null;
        public void ResetRegion() => __pbn__Region = null;
        private string __pbn__Region;

    }

    [ProtoContract]
    internal partial class ClubSearchResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"page", IsRequired = true)]
        public uint Page { get; set; }

        [ProtoMember(2, Name = @"club")]
        public List<Club> Clubs { get; } = new List<Club>();

        [ProtoMember(3, Name = @"recommedClub")]
        public List<Club> recommedClubs { get; } = new List<Club>();

    }

    [ProtoContract]
    internal partial class FindClubPlayerRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"page", IsRequired = true)]
        public uint Page { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint pageSize { get; set; }

        [ProtoMember(4)]
        [DefaultValue("")]
        public string playerName
        {
            get { return __pbn__playerName ?? ""; }
            set { __pbn__playerName = value; }
        }
        public bool ShouldSerializeplayerName() => __pbn__playerName != null;
        public void ResetplayerName() => __pbn__playerName = null;
        private string __pbn__playerName;

    }

    [ProtoContract]
    internal partial class FindClubPlayerResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"page", IsRequired = true)]
        public uint Page { get; set; }

        [ProtoMember(2, Name = @"clubPlayer")]
        public List<ClubPlayer> clubPlayers { get; } = new List<ClubPlayer>();

    }

    [ProtoContract]
    internal partial class ApplyClubPlayerRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, Name = @"region", IsRequired = true)]
        public string Region { get; set; }

    }

    [ProtoContract]
    internal partial class ApplyClubPlayerResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public bool auotApprove
        {
            get { return __pbn__auotApprove.GetValueOrDefault(); }
            set { __pbn__auotApprove = value; }
        }
        public bool ShouldSerializeauotApprove() => __pbn__auotApprove != null;
        public void ResetauotApprove() => __pbn__auotApprove = null;
        private bool? __pbn__auotApprove;

    }

    [ProtoContract]
    internal partial class ApproveClubPlayerRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public ulong applyId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public ulong notifyId { get; set; }

        [ProtoMember(4, Name = @"status", IsRequired = true)]
        public ApplStatus Status { get; set; } = ApplStatus.Wait;

    }

    [ProtoContract]
    internal partial class ApproveClubPlayerResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class SetClubPlayerRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint playerId { get; set; }

        [ProtoMember(3, Name = @"corpus")]
        [DefaultValue(Corpus.President)]
        public Corpus Corpus
        {
            get { return __pbn__Corpus ?? Corpus.President; }
            set { __pbn__Corpus = value; }
        }
        public bool ShouldSerializeCorpus() => __pbn__Corpus != null;
        public void ResetCorpus() => __pbn__Corpus = null;
        private Corpus? __pbn__Corpus;

        [ProtoMember(4, Name = @"alias")]
        [DefaultValue("")]
        public string Alias
        {
            get { return __pbn__Alias ?? ""; }
            set { __pbn__Alias = value; }
        }
        public bool ShouldSerializeAlias() => __pbn__Alias != null;
        public void ResetAlias() => __pbn__Alias = null;
        private string __pbn__Alias;

    }

    [ProtoContract]
    internal partial class SetClubPlayerResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class KickClubPlayerRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint playerId { get; set; }

    }

    [ProtoContract]
    internal partial class KickClubPlayerResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class CancelClubRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

    }

    [ProtoContract]
    internal partial class CancelClubResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class DissolutionClubRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

    }

    [ProtoContract]
    internal partial class DissolutionClubResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class ClubKickOutNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string clubName { get; set; }

    }

    [ProtoContract]
    internal partial class GiveClubActivityRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string cardId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int clubActivity { get; set; }

    }

    [ProtoContract]
    internal partial class GiveClubActivityResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int clubActivity { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int canGiveClubActivity { get; set; }

    }

    [ProtoContract]
    internal partial class FindClubInfoRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string cardID { get; set; }

    }

    [ProtoContract]
    internal partial class FindClubInfoResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string cardId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string clubName { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string clubIcon { get; set; }

    }

    [ProtoContract]
    internal partial class SubClubRebateRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int clubId { get; set; }

    }

    [ProtoContract]
    internal partial class SubClubRebateResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"subClubRebate")]
        public List<SubClubRebateData> subClubRebates { get; } = new List<SubClubRebateData>();

    }

    [ProtoContract]
    internal partial class SubClubRebateData : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int clubCardId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string clubName { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int lastDayRebate { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int lastWeekRebate { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int lastMonthRebate { get; set; }

    }

    [ProtoContract]
    internal partial class SetClubMasterScoreThresholdRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public bool masterScoresThresholdSwitch { get; set; }

        [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int masterScoresThreshold { get; set; }

    }

    [ProtoContract]
    internal partial class SetClubMasterScoreThresholdResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public bool masterScoresThresholdSwitch { get; set; }

        [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int masterScoresThreshold { get; set; }

    }

    [ProtoContract]
    internal partial class FindClubSinglePlayerRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int clubId { get; set; }

    }

    [ProtoContract]
    internal partial class FindSingleClubPlayerResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public ClubPlayer clubPlayer { get; set; }

    }

    [ProtoContract]
    internal partial class HelpRepayCreditScoreRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint creditScore { get; set; }

    }

    [ProtoContract]
    internal partial class HelpRepayCreditScoreResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"club", IsRequired = true)]
        public Club Club { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public ClubPlayer clubPlayer { get; set; }

    }

    [ProtoContract]
    internal partial class AddClubCreditScoreRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint creditScore { get; set; }

    }

    [ProtoContract]
    internal partial class AddClubCreditScoreResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint creditScore { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint alreadyUseCreditScore { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public uint alreadyAllotCreditScore { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public uint masterScore { get; set; }

    }

    [ProtoContract]
    internal partial class WithdrawClubCreditScoreRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint creditScore { get; set; }

    }

    [ProtoContract]
    internal partial class WithdrawClubCreditScoreResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint creditScore { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint alreadyUseCreditScore { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public uint alreadyAllotCreditScore { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public uint masterScore { get; set; }

    }

    [ProtoContract]
    internal partial class AllotPlayerCreditScoreRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint playerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint creditScore { get; set; }

    }

    [ProtoContract]
    internal partial class AllotPlayerCreditScoreResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"club", IsRequired = true)]
        public Club Club { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public ClubPlayer clubPlayer { get; set; }

    }

    [ProtoContract]
    internal partial class AllotPlayerCreditScoreNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"club")]
        public Club Club { get; set; }

        [ProtoMember(2)]
        public ClubPlayer clubPlayer { get; set; }

    }

    [ProtoContract]
    internal partial class RepayClubCreditScoreRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint playerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint creditScore { get; set; }

    }

    [ProtoContract]
    internal partial class RepayClubCreditScoreResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint clubId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint playerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint creditScore { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public uint alreadyUseCreditScore { get; set; }

    }

    [ProtoContract]
    internal partial class RoomTypeEnum : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"codes")]
        [DefaultValue(ERoomType.noRoom)]
        public ERoomType Codes
        {
            get { return __pbn__Codes ?? ERoomType.noRoom; }
            set { __pbn__Codes = value; }
        }
        public bool ShouldSerializeCodes() => __pbn__Codes != null;
        public void ResetCodes() => __pbn__Codes = null;
        private ERoomType? __pbn__Codes;

        [ProtoContract]
        internal enum ERoomType
        {
            noRoom = 0,
            sngRoom = 1,
            mttRoom = 2,
            nlRoom = 3,
        }

    }

    [ProtoContract]
    internal partial class PlayerStateEnum : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"codes")]
        [DefaultValue(EPlayerState.Nostate)]
        public EPlayerState Codes
        {
            get { return __pbn__Codes ?? EPlayerState.Nostate; }
            set { __pbn__Codes = value; }
        }
        public bool ShouldSerializeCodes() => __pbn__Codes != null;
        public void ResetCodes() => __pbn__Codes = null;
        private EPlayerState? __pbn__Codes;

        [ProtoContract]
        internal enum EPlayerState
        {
            [ProtoEnum(Name = @"nostate")]
            Nostate = 0,
            [ProtoEnum(Name = @"watching")]
            Watching = 1,
            [ProtoEnum(Name = @"gameing")]
            Gameing = 2,
            [ProtoEnum(Name = @"allin")]
            Allin = 3,
            [ProtoEnum(Name = @"fold")]
            Fold = 4,
            [ProtoEnum(Name = @"rebuy")]
            Rebuy = 5,
            [ProtoEnum(Name = @"keepsit")]
            Keepsit = 6,
            [ProtoEnum(Name = @"sitdown")]
            Sitdown = 7,
            [ProtoEnum(Name = @"sngover")]
            Sngover = 8,
        }

    }

    [ProtoContract]
    internal partial class ErrorMsg : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        [DefaultValue(Codes.Ok)]
        public Codes codes
        {
            get { return __pbn__codes ?? Codes.Ok; }
            set { __pbn__codes = value; }
        }
        public bool ShouldSerializecodes() => __pbn__codes != null;
        public void Resetcodes() => __pbn__codes = null;
        private Codes? __pbn__codes;

        [ProtoMember(2, Name = @"msg")]
        [DefaultValue("")]
        public string Msg
        {
            get { return __pbn__Msg ?? ""; }
            set { __pbn__Msg = value; }
        }
        public bool ShouldSerializeMsg() => __pbn__Msg != null;
        public void ResetMsg() => __pbn__Msg = null;
        private string __pbn__Msg;

        [ProtoContract]
        internal enum Codes
        {
            Ok = 0,
            Error = 1,
            ErrServerMaintenance = 2,
            ErrPlayerNotFound = 1000,
            ErrLogin = 1001,
            ErrRelogin = 1002,
            ErrPlayerPhoneExists = 1003,
            ErrPlayerConnect = 1004,
            ErrPlayerTokenRequest = 1005,
            ErrPlayerCaptchaFrequently = 1006,
            ErrPlayerCaptchaRequest = 1007,
            ErrPlayerPlatformAuth = 1008,
            ErrPlayerPlatformCaptcha = 1009,
            ErrPlayerSignUp = 1010,
            ErrPlayerBindPhone = 1011,
            ErrPlayerChangePassword = 1012,
            ErrPlayerLoginRequest = 1013,
            ErrPlayerWechatLogin = 1014,
            ErrPlayerIconNoImageType = 1015,
            ErrPlayerIconSave = 1016,
            ErrPlayerEditInfo = 1017,
            ErrPlayerInfoRequest = 1018,
            ErrPlayerRoomsRequest = 1019,
            ErrPlayerLogout = 1020,
            ErrLoginTokenTimeOut = 1021,
            ErrPlayerForbiddenNickname = 1022,
            ErrPlayerCaptcha = 1023,
            ErrPlayerWechatAccessToken = 1024,
            ErrPlayerPassword = 1025,
            ErrPlayerWechatExists = 1026,
            ErrPlayerNameInvalidLength = 1027,
            ErrPlayerNameWithSpaces = 1028,
            ErrPlayerForbiddenSignature = 1029,
            ErrPlayerInvalidPhone = 1030,
            ErrPlayerVersionNotAllowed = 1031,
            ErrPlayerVersionUpgrade = 1032,
            ErrPlayerVersionRestart = 1033,
            ErrPlayerInvalidToken = 1034,
            ErrPlayerInvalidSessionKey = 1035,
            ErrPlayerPhoneNotBound = 1036,
            ErrPlayerUnbindPhone = 1037,
            ErrPlayerGpsIp = 1038,
            ErrNotOpenGps = 1039,
            ErrPlayerEditCostNotEnough = 1040,
            ErrInvalidCaptcha = 1041,
            ErrNotEqualP2Captcha = 1042,
            ErrP2NotCheckDaysInvalid = 1043,
            ErrP2IndexInvalid = 1044,
            ErrP2NotCheckAmountInvalid = 1045,
            ErrPlayerNameRepeat = 1046,
            ErrPlayerPhoneNotMatch = 1047,
            ErrRetryTimeOver3 = 1048,
            ErrPlayerAlreadyFrozen = 1049,
            ErrPlayerMasterScoreNotEnough = 1050,
            ErrAccountDeviceLocked = 1051,
            ErrPlayerPhoneUsed = 1052,
            ErrAccountChangeDeviceLimit = 1053,
            ErrReconnectRoomNotFound = 1999,
            ErrRoomNotFound = 2000,
            ErrInvitationCode = 2001,
            ErrJoinRoom = 2002,
            ErrCreateRoom = 2003,
            ErrConnectRoom = 2004,
            ErrSeatIsOccupied = 2005,
            ErrPlayerNotInGame = 2006,
            ErrSeatIsUnoccupied = 2007,
            ErrSeatIsOthers = 2008,
            ErrSitDown = 2009,
            ErrStandUp = 2010,
            ErrStandUpFirst = 2011,
            ErrOutRoom = 2012,
            ErrNotRoomCreator = 2013,
            ErrRoomState = 2014,
            ErrPlayersNotEnough = 2015,
            ErrStartGame = 2016,
            ErrGameNotFound = 2017,
            ErrIllegalAction = 2018,
            ErrGoldNotEnough = 2019,
            ErrPlayerCall = 2020,
            ErrPlayerFold = 2021,
            ErrPlayerCheck = 2022,
            ErrIllegalParameter = 2023,
            ErrPlayerRaise = 2024,
            ErrPlayerAllIn = 2025,
            ErrRoomForbiddenName = 2026,
            ErrMessageForbiddenWords = 2027,
            ErrSeatIsRebuying = 2028,
            ErrDiamondsNotEnough = 2029,
            ErrCreateRoomCeiling = 2030,
            ErrNotUpToMinimumTableTime = 2031,
            ErrAdvanceLeaveCannotGoTable = 2032,
            ErrAdvanceSettle = 2033,
            ErrPlayerHaveSit = 2034,
            ErrShowCardState = 2035,
            ErrShowCardTimes = 2036,
            ErrShowCardHasDone = 2037,
            ErrRoomNotOfferJp = 2038,
            ErrBringOutTime = 2039,
            ErrBringOutCount = 2040,
            ErrBringOutRoomType = 2041,
            ErrBringOutNotMultiple = 2042,
            ErrBringOutNotEnoughScore = 2043,
            ErrBringOutOverMax = 2044,
            ErrBringOutNotAllow = 2045,
            ErrBringOutBankRollType = 2046,
            ErrBringOutPlayerInAction = 2047,
            ErrReplayNotFound = 3000,
            ErrGetReplayList = 3001,
            ErrGetReplay = 3002,
            ErrorVideoNotCollected = 3003,
            ErrorVideoCollected = 3004,
            ErrorVideoCollectedLimit = 3005,
            ErrClubCreate = 4000,
            ErrCreateExceedMaxNumber = 4001,
            ErrClubUpdate = 4002,
            ErrClubSearch = 4003,
            ErrAlreadyApply = 4004,
            ErrAlreadyJoin = 4005,
            ErrApply = 4006,
            ErrInsufficientAuthority = 4007,
            ErrAlreadyApprove = 4008,
            ErrClubNotFind = 4009,
            ErrClubPlayerTooMore = 4010,
            ErrPlayerNotFind = 4011,
            ErrKickVicePresident = 4012,
            ErrKickOutSelf = 4013,
            ErrHasBecomeVicePresident = 4014,
            ErrHasBecomeNormalPlayer = 4015,
            ErrClubExistOtherPlayer = 4016,
            ErrNotMoreJoin = 4017,
            ErrClubForbidden = 4018,
            ErrAlreadyUseCreditScoreIsNotZero = 4019,
            ErrNoRepayment = 4020,
            ErrApproveNotMoreJoin = 4021,
            ErrAgentClubNotFind = 4022,
            ErrClubActivityBelowShow = 4023,
            ErrClubActivityHandselNotEnough = 4024,
            ErrMasterScoreThresholdAuthorityNotEnough = 4025,
            ErrMasterScoreThresholdNotAllowed = 4026,
            ErrClubAlreadyForbidden = 4027,
            ErrPlayerNotFoundInClUB = 40028,
            ErrAuthorityNotEnough = 40029,
            ErrTooLong = 40030,
            ErrClubMAXPlayerTooMore = 4031,
            ErrClubName = 4032,
            ErrCodeMax = 4033,
            ErrProvideMasterScoreIsClosed = 4034,
            ErrContributeMasterScoreIsClosed = 4035,
            ErrRecommendClubCantContributeMasterScoreToSuperiorClub = 4036,
            ErrMasterScoreNotMore = 4500,
            ErrCreditScoreNotMore = 4501,
            ErrPlayerCreditScoreNotMore = 4502,
            ErrRepayCreditScoreTooMore = 4503,
            ErrCreditOverAllocateMax = 4504,
            ErrFreezeMasterScore = 4505,
            ErrMasterScoreTooMore = 4506,
            ErrChatRequest = 5000,
            ErrChatNotClubMember = 5001,
            ErrVoiceRoomNotFound = 5002,
            ErrVoiceRequest = 5003,
            ErrRoomType = 6000,
            ErrRoomList = 6001,
            ErrMallProductNotFound = 6100,
            ErrMallReceiptAuthFailed = 6101,
            ErrMallProductsRequest = 6102,
            ErrMallPaymentsRequest = 6103,
            ErrMallReceiptRequest = 6104,
            ErrMallInvalidPaymentId = 6105,
            ErrMallOrderRequest = 6106,
            ErrMallBuyRequest = 6107,
            ErrMallDiamondNotEnough = 6108,
            ErrMTTApplyNotExist = 7000,
            ErrMTTAlreadyApply = 7001,
            ErrMTTApplyCostNotEnough = 7002,
            ErrMTTApplyMax = 7003,
            ErrMTTApplyEndBlind = 7004,
            ErrMTTCancelApplyFail = 7005,
            ErrAdvanceLeaveTable = 7006,
            ErrRaceClubRewardDeposit = 7007,
            ErrClubNoApply = 7008,
            ErrMTTEntryTimeout = 7010,
            ErrMTTEntryBlindExceed = 7011,
            ErrMTTEntryNumExceed = 7012,
            ErrMTTEntryCostNotEnough = 7013,
            ErrMTTReBuyChipIllegal = 7014,
            ErrItemNotEnough = 7100,
            ErrHandselPlayerNotFind = 7101,
            ErrItemCanNotUse = 7102,
            ErrInteractionNoSit = 7103,
            ErrInteractionCostNoEnough = 7104,
            ErrShowEmojiNoSit = 7105,
            ErrCdKeyAlreadyUse = 7106,
            ErrCdKeyNotFind = 7017,
            ErrCdKeyOverdue = 7018,
            ErrItemCanNotRevert = 7019,
            ErrItemRevertFail = 7020,
            ErrItemNoMoreQRTicket = 7021,
            ErrInsuranceNotBuyPlayerId = 7200,
            ErrInsuranceNotChooseOuts = 7201,
            ErrInsuranceAmountIllegal = 7202,
            ErrInsuranceTimeout = 7203,
            ErrInsuranceMustBuyRiverCard = 7204,
            ErrInsuranceResetTimeCostNotEnough = 7205,
            ErrInsuranceResetTimeCountMax = 7206,
            ErrAddThinkTimeNotActionPlayer = 7210,
            ErrAddThinkTimeMaxCount = 7211,
            ErrAddThinkTimeCostNotEnough = 7212,
            ErrAddThinkTimeMaxTimePreRound = 7213,
            ErrKeepSitStatus = 7220,
            ErrCancelKeepSitStatus = 7221,
            ErrKeepSitMaxCount = 7222,
            ErrKeepSitCannotStandup = 7223,
            ErrReconnetc = 8000,
            ErrHandReviewnotFound = 8001,
            ErrRoomDestory = 8002,
            ErrRoomDestoryRebuy = 8003,
            ErrFrequentOperation = 8004,
            ErrRoomFinishing = 8005,
            ErrJoinOfficialCommonRoom = 9000,
            ErrJoinOfficialCommonRoomErrClubId = 9001,
            ErrClubRoomIsOpen = 9002,
            ErrNoneNotify = 9050,
            ErrNotifyOutTime = 9051,
            ErrNotSit = 9052,
            ErrNotRebuy = 9053,
            ErrDrawMax = 10000,
            ErrBankCard = 10001,
            ErrBankCardNum = 10002,
            ErrBankCardInfo = 10003,
            ErrDrawTime = 10004,
            ErrRepDrawOrderId = 10005,
            ErrDrawDayMax = 10006,
            ErrDrawUnKown = 10007,
            ErrDrawException = 10008,
            ErrWalletPwdRepeated = 10009,
            ErrGetOrderInfo = 10010,
            ErrWalletPasswordNotNull = 10011,
            ErrWalletPasswordNoEq = 10012,
            ErrDrawFail = 10013,
            ErrPayAmount = 10014,
            ErrDrawAmount = 10015,
            ErrPayClose = 10016,
            ErrDrawCount = 10017,
            ErrRedPacketActivityOver = 10018,
        }

    }

    [ProtoContract]
    internal partial class NotifyGamePause : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public GmNotifyEnum gmNotifyEnum { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyGameReStart : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public GmNotifyEnum gmNotifyEnum { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyGameDelayed : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public GmNotifyEnum gmNotifyEnum { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int delayedTime { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyGameErrorRestart : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public GmNotifyEnum gmNotifyEnum { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyGameSettlement : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public GmNotifyEnum gmNotifyEnum { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyGameKickPlayer : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string playeName { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public GmNotifyEnum gmNotifyEnum { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyGameCancelBan : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public GmNotifyEnum gmNotifyEnum { get; set; }

    }

    [ProtoContract]
    internal partial class GmNotifyEnum : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        [DefaultValue(GmNotifyCodes.Nocodes)]
        public GmNotifyCodes gmNotifyCodes
        {
            get { return __pbn__gmNotifyCodes ?? GmNotifyCodes.Nocodes; }
            set { __pbn__gmNotifyCodes = value; }
        }
        public bool ShouldSerializegmNotifyCodes() => __pbn__gmNotifyCodes != null;
        public void ResetgmNotifyCodes() => __pbn__gmNotifyCodes = null;
        private GmNotifyCodes? __pbn__gmNotifyCodes;

        [ProtoContract]
        internal enum GmNotifyCodes
        {
            [ProtoEnum(Name = @"GAMEPAUSE")]
            Gamepause = 1,
            [ProtoEnum(Name = @"GAMERESTART")]
            Gamerestart = 2,
            [ProtoEnum(Name = @"GAMEDELAYED")]
            Gamedelayed = 3,
            [ProtoEnum(Name = @"GAMEERRORRESTART")]
            Gameerrorrestart = 4,
            [ProtoEnum(Name = @"GAMESETTLEMENT")]
            Gamesettlement = 5,
            [ProtoEnum(Name = @"GAMEKICKPLAYER")]
            Gamekickplayer = 6,
            [ProtoEnum(Name = @"GAMECANCELBAN")]
            Gamecancelban = 7,
            [ProtoEnum(Name = @"NOCODES")]
            Nocodes = 8,
        }

    }

    [ProtoContract]
    internal partial class HandReviewRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int handCount { get; set; }

    }

    [ProtoContract]
    internal partial class HandReviewResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"handReview")]
        public List<HandReview> handReviews { get; } = new List<HandReview>();

        [ProtoMember(2, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int allHand { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int currHand { get; set; }

        [ProtoMember(5, Name = @"sb", IsRequired = true)]
        public long Sb { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public bool isCollected { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int collectedCount { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int allCollectCount { get; set; }

    }

    [ProtoContract]
    internal partial class HandReview : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(2, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public bool isDealer { get; set; }

        [ProtoMember(5, Name = @"bb", IsRequired = true)]
        public bool Bb { get; set; }

        [ProtoMember(6, Name = @"sb", IsRequired = true)]
        public bool Sb { get; set; }

        [ProtoMember(7)]
        public HandCard handCard { get; set; }

        [ProtoMember(8)]
        public FlopCard flopCard { get; set; }

        [ProtoMember(9)]
        public Card trunCard { get; set; }

        [ProtoMember(10)]
        public Card riverCard { get; set; }

        [ProtoMember(11)]
        public int handPower
        {
            get { return __pbn__handPower.GetValueOrDefault(); }
            set { __pbn__handPower = value; }
        }
        public bool ShouldSerializehandPower() => __pbn__handPower != null;
        public void ResethandPower() => __pbn__handPower = null;
        private int? __pbn__handPower;

        [ProtoMember(12, Name = @"gains", IsRequired = true)]
        public long Gains { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public int preflopAction { get; set; }

        [ProtoMember(14, IsRequired = true)]
        public long preflopGains { get; set; }

        [ProtoMember(15, IsRequired = true)]
        public int flopAction { get; set; }

        [ProtoMember(16, IsRequired = true)]
        public long flopGains { get; set; }

        [ProtoMember(17, IsRequired = true)]
        public int trunAction { get; set; }

        [ProtoMember(18, IsRequired = true)]
        public long trunGains { get; set; }

        [ProtoMember(19, IsRequired = true)]
        public int riverAction { get; set; }

        [ProtoMember(20, IsRequired = true)]
        public long riverGains { get; set; }

        [ProtoMember(21)]
        public long buyInsurAmount
        {
            get { return __pbn__buyInsurAmount.GetValueOrDefault(); }
            set { __pbn__buyInsurAmount = value; }
        }
        public bool ShouldSerializebuyInsurAmount() => __pbn__buyInsurAmount != null;
        public void ResetbuyInsurAmount() => __pbn__buyInsurAmount = null;
        private long? __pbn__buyInsurAmount;

        [ProtoMember(22)]
        public long returnInsurAmount
        {
            get { return __pbn__returnInsurAmount.GetValueOrDefault(); }
            set { __pbn__returnInsurAmount = value; }
        }
        public bool ShouldSerializereturnInsurAmount() => __pbn__returnInsurAmount != null;
        public void ResetreturnInsurAmount() => __pbn__returnInsurAmount = null;
        private long? __pbn__returnInsurAmount;

        [ProtoMember(23, Name = @"straddle", IsRequired = true)]
        public bool Straddle { get; set; }

        [ProtoMember(24, IsRequired = true)]
        public int playerId { get; set; }

    }

    [ProtoContract]
    internal partial class HandCard2 : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"card")]
        public List<Card> Cards { get; } = new List<Card>();

    }

    [ProtoContract]
    internal partial class FlopCard : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"card")]
        public List<Card> Cards { get; } = new List<Card>();

    }

    [ProtoContract]
    internal partial class Card2 : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string cardSuit { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int cardNumber { get; set; }

    }

    [ProtoContract]
    internal partial class TriggerInsuranceNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long buyAmountMin { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public long buyAmountMax { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public long insurPot { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public long playerInPool { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int restThinkTime { get; set; }

        [ProtoMember(9)]
        public List<Card> buyerHandCards { get; } = new List<Card>();

        [ProtoMember(10)]
        public List<Card> overtakeOutsCards { get; } = new List<Card>();

        [ProtoMember(11, Name = @"odds")]
        public List<Odds> Odds { get; } = new List<Odds>();

        [ProtoMember(12, IsRequired = true)]
        public int resetTimeItemId { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public int resetTimeCostCount { get; set; }

        [ProtoMember(14, IsRequired = true)]
        public int resetTime { get; set; }

        [ProtoMember(15)]
        public bool mustBuyAllOuts
        {
            get { return __pbn__mustBuyAllOuts.GetValueOrDefault(); }
            set { __pbn__mustBuyAllOuts = value; }
        }
        public bool ShouldSerializemustBuyAllOuts() => __pbn__mustBuyAllOuts != null;
        public void ResetmustBuyAllOuts() => __pbn__mustBuyAllOuts = null;
        private bool? __pbn__mustBuyAllOuts;

        [ProtoMember(16)]
        public List<Card> equalOutsCards { get; } = new List<Card>();

        [ProtoMember(17, Name = @"inPoolPlayer")]
        public List<InPoolPlayerHandCard> inPoolPlayers { get; } = new List<InPoolPlayerHandCard>();

        [ProtoMember(18, Name = @"pot")]
        public List<Pot> Pots { get; } = new List<Pot>();

        [ProtoMember(19, IsRequired = true)]
        public bool equalOutsLimit { get; set; }

    }

    [ProtoContract]
    internal partial class OptionBroadCastRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"option", IsRequired = true)]
        public InsuranceOption Option { get; set; } = InsuranceOption.SelectOuts;

        [ProtoMember(2, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(3)]
        public int outsCardNum
        {
            get { return __pbn__outsCardNum.GetValueOrDefault(); }
            set { __pbn__outsCardNum = value; }
        }
        public bool ShouldSerializeoutsCardNum() => __pbn__outsCardNum != null;
        public void ResetoutsCardNum() => __pbn__outsCardNum = null;
        private int? __pbn__outsCardNum;

        [ProtoMember(4)]
        public int buyAmount
        {
            get { return __pbn__buyAmount.GetValueOrDefault(); }
            set { __pbn__buyAmount = value; }
        }
        public bool ShouldSerializebuyAmount() => __pbn__buyAmount != null;
        public void ResetbuyAmount() => __pbn__buyAmount = null;
        private int? __pbn__buyAmount;

    }

    [ProtoContract]
    internal partial class OptionBroadCastResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"option", IsRequired = true)]
        public InsuranceOption Option { get; set; } = InsuranceOption.SelectOuts;

        [ProtoMember(2, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(3)]
        public int outsCardNum
        {
            get { return __pbn__outsCardNum.GetValueOrDefault(); }
            set { __pbn__outsCardNum = value; }
        }
        public bool ShouldSerializeoutsCardNum() => __pbn__outsCardNum != null;
        public void ResetoutsCardNum() => __pbn__outsCardNum = null;
        private int? __pbn__outsCardNum;

        [ProtoMember(4)]
        public int buyAmount
        {
            get { return __pbn__buyAmount.GetValueOrDefault(); }
            set { __pbn__buyAmount = value; }
        }
        public bool ShouldSerializebuyAmount() => __pbn__buyAmount != null;
        public void ResetbuyAmount() => __pbn__buyAmount = null;
        private int? __pbn__buyAmount;

    }

    [ProtoContract]
    internal partial class BuyInsuranceRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public long buyAmount { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(5)]
        public int[] buyOutsCardNums { get; set; }

    }

    [ProtoContract]
    internal partial class BuyInsuranceResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int buyOutsCount { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public long buyAmount { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public long returnAmount { get; set; }

    }

    [ProtoContract]
    internal partial class UnbuyInsuranceRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

    }

    [ProtoContract]
    internal partial class UnbuyInsuranceResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int playerId { get; set; }

    }

    [ProtoContract]
    internal partial class ResetBuyThinkTimeRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

    }

    [ProtoContract]
    internal partial class ResetBuyThinkTimeResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int restThinkTime { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public bool canReset { get; set; }

        [ProtoMember(6)]
        public int resetTimeItemId
        {
            get { return __pbn__resetTimeItemId.GetValueOrDefault(); }
            set { __pbn__resetTimeItemId = value; }
        }
        public bool ShouldSerializeresetTimeItemId() => __pbn__resetTimeItemId != null;
        public void ResetresetTimeItemId() => __pbn__resetTimeItemId = null;
        private int? __pbn__resetTimeItemId;

        [ProtoMember(7)]
        public int resetTimeCostCount
        {
            get { return __pbn__resetTimeCostCount.GetValueOrDefault(); }
            set { __pbn__resetTimeCostCount = value; }
        }
        public bool ShouldSerializeresetTimeCostCount() => __pbn__resetTimeCostCount != null;
        public void ResetresetTimeCostCount() => __pbn__resetTimeCostCount = null;
        private int? __pbn__resetTimeCostCount;

        [ProtoMember(8)]
        public int resetTime
        {
            get { return __pbn__resetTime.GetValueOrDefault(); }
            set { __pbn__resetTime = value; }
        }
        public bool ShouldSerializeresetTime() => __pbn__resetTime != null;
        public void ResetresetTime() => __pbn__resetTime = null;
        private int? __pbn__resetTime;

    }

    [ProtoContract]
    internal partial class InsuranceSettlementNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public bool isHitOuts { get; set; }

        [ProtoMember(5)]
        public long returnAmount
        {
            get { return __pbn__returnAmount.GetValueOrDefault(); }
            set { __pbn__returnAmount = value; }
        }
        public bool ShouldSerializereturnAmount() => __pbn__returnAmount != null;
        public void ResetreturnAmount() => __pbn__returnAmount = null;
        private long? __pbn__returnAmount;

    }

    [ProtoContract]
    internal partial class InsuranceHoleCardNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, Name = @"playerHandCard")]
        public List<InPoolPlayerHandCard> playerHandCards { get; } = new List<InPoolPlayerHandCard>();

    }

    [ProtoContract]
    internal partial class Card5 : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string cardSuit { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int cardNumber { get; set; }

    }

    [ProtoContract]
    internal partial class Odds : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int cardCount { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string odds { get; set; }

    }

    [ProtoContract]
    internal partial class InPoolPlayerHandCard : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int outsNum { get; set; }

        [ProtoMember(4)]
        public List<Card> handCards { get; } = new List<Card>();

    }

    [ProtoContract]
    internal partial class DoPlayerCallResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(3, Name = @"action", IsRequired = true)]
        public int Action { get; set; }

        [ProtoMember(4, Name = @"bankroll", IsRequired = true)]
        public int Bankroll { get; set; }

        [ProtoMember(5, Name = @"bet")]
        public int Bet
        {
            get { return __pbn__Bet.GetValueOrDefault(); }
            set { __pbn__Bet = value; }
        }
        public bool ShouldSerializeBet() => __pbn__Bet != null;
        public void ResetBet() => __pbn__Bet = null;
        private int? __pbn__Bet;

    }

    [ProtoContract]
    internal partial class Pot : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"winnerId")]
        public int[] winnerIds { get; set; }

        [ProtoMember(2, Name = @"gold", IsRequired = true)]
        public long Gold { get; set; }

        [ProtoMember(3)]
        public int[] playerIds { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int potType { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int potId { get; set; }

    }

    [ProtoContract]
    internal partial class NoInsuranceNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        [DefaultValue(NoInsuranceTips.NoTips)]
        public NoInsuranceTips turnTips
        {
            get { return __pbn__turnTips ?? NoInsuranceTips.NoTips; }
            set { __pbn__turnTips = value; }
        }
        public bool ShouldSerializeturnTips() => __pbn__turnTips != null;
        public void ResetturnTips() => __pbn__turnTips = null;
        private NoInsuranceTips? __pbn__turnTips;

        [ProtoMember(2)]
        [DefaultValue(NoInsuranceTips.NoTips)]
        public NoInsuranceTips riverTips
        {
            get { return __pbn__riverTips ?? NoInsuranceTips.NoTips; }
            set { __pbn__riverTips = value; }
        }
        public bool ShouldSerializeriverTips() => __pbn__riverTips != null;
        public void ResetriverTips() => __pbn__riverTips = null;
        private NoInsuranceTips? __pbn__riverTips;

        [ProtoMember(3, IsRequired = true)]
        public int outsLimit { get; set; }

    }

    [ProtoContract]
    internal partial class WaitBuyInsuranceNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int buyPlayerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string buyPlayerName { get; set; }

    }

    [ProtoContract]
    internal partial class ItemTemplateNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public List<ItemTemplate> itemTemplates { get; } = new List<ItemTemplate>();

    }

    [ProtoContract]
    internal partial class PlayerItemNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public List<PlayerItem> playerItems { get; } = new List<PlayerItem>();

    }

    [ProtoContract]
    internal partial class UseItemRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string itemId { get; set; }

        [ProtoMember(2, Name = @"count")]
        public int Count
        {
            get { return __pbn__Count.GetValueOrDefault(); }
            set { __pbn__Count = value; }
        }
        public bool ShouldSerializeCount() => __pbn__Count != null;
        public void ResetCount() => __pbn__Count = null;
        private int? __pbn__Count;

        [ProtoMember(3, Name = @"name")]
        [DefaultValue("")]
        public string Name
        {
            get { return __pbn__Name ?? ""; }
            set { __pbn__Name = value; }
        }
        public bool ShouldSerializeName() => __pbn__Name != null;
        public void ResetName() => __pbn__Name = null;
        private string __pbn__Name;

        [ProtoMember(4, Name = @"phone")]
        [DefaultValue("")]
        public string Phone
        {
            get { return __pbn__Phone ?? ""; }
            set { __pbn__Phone = value; }
        }
        public bool ShouldSerializePhone() => __pbn__Phone != null;
        public void ResetPhone() => __pbn__Phone = null;
        private string __pbn__Phone;

        [ProtoMember(5, Name = @"wechat")]
        [DefaultValue("")]
        public string Wechat
        {
            get { return __pbn__Wechat ?? ""; }
            set { __pbn__Wechat = value; }
        }
        public bool ShouldSerializeWechat() => __pbn__Wechat != null;
        public void ResetWechat() => __pbn__Wechat = null;
        private string __pbn__Wechat;

        [ProtoMember(6, Name = @"address")]
        [DefaultValue("")]
        public string Address
        {
            get { return __pbn__Address ?? ""; }
            set { __pbn__Address = value; }
        }
        public bool ShouldSerializeAddress() => __pbn__Address != null;
        public void ResetAddress() => __pbn__Address = null;
        private string __pbn__Address;

    }

    [ProtoContract]
    internal partial class UseItemResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"suc", IsRequired = true)]
        public bool Suc { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string itemId { get; set; }

    }

    [ProtoContract]
    internal partial class AddPlayerItemNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public List<PlayerItem> addItems { get; } = new List<PlayerItem>();

    }

    [ProtoContract]
    internal partial class DeletePlayerItemNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"itemCount")]
        public List<PlayerItemCount> itemCounts { get; } = new List<PlayerItemCount>();

    }

    [ProtoContract]
    internal partial class PlayerItemCount : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string itemId { get; set; }

        [ProtoMember(2, Name = @"count", IsRequired = true)]
        public long Count { get; set; }

    }

    [ProtoContract]
    internal partial class ItemTemplate : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int itemTempId { get; set; }

        [ProtoMember(2, Name = @"name", IsRequired = true)]
        public string Name { get; set; }

        [ProtoMember(3, Name = @"type", IsRequired = true)]
        public int Type { get; set; }

        [ProtoMember(4, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

        [ProtoMember(5, Name = @"desc", IsRequired = true)]
        public string Desc { get; set; }

        [ProtoMember(6)]
        [DefaultValue("")]
        public string effectDescs
        {
            get { return __pbn__effectDescs ?? ""; }
            set { __pbn__effectDescs = value; }
        }
        public bool ShouldSerializeeffectDescs() => __pbn__effectDescs != null;
        public void ReseteffectDescs() => __pbn__effectDescs = null;
        private string __pbn__effectDescs;

        [ProtoMember(7, IsRequired = true)]
        public int canGift { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public string smallIcon { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public string engName { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public string engDesc { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public int canConvert { get; set; }

        [ProtoMember(12, Name = @"convert", IsRequired = true)]
        public string Convert { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerItem : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string itemId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int itemTempId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(4, Name = @"count", IsRequired = true)]
        public long Count { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int expireTime { get; set; }

    }

    [ProtoContract]
    internal partial class TakeMascotRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int itemTempId { get; set; }

    }

    [ProtoContract]
    internal partial class TakeMascotResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int curMascotItemTempId { get; set; }

    }

    [ProtoContract]
    internal partial class HandselItemPlayerInfoRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int targetPlayerId { get; set; }

    }

    [ProtoContract]
    internal partial class HandselItemPlayerInfoResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int targetPlayerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string playerIcon { get; set; }

    }

    [ProtoContract]
    internal partial class HandselItemRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string itemId { get; set; }

        [ProtoMember(2, Name = @"count", IsRequired = true)]
        public int Count { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int targetPlayerId { get; set; }

    }

    [ProtoContract]
    internal partial class HandselItemResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string itemId { get; set; }

        [ProtoMember(2, Name = @"count", IsRequired = true)]
        public int Count { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int targetPlayerId { get; set; }

    }

    [ProtoContract]
    internal partial class GetCdKeyRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string cdKey { get; set; }

    }

    [ProtoContract]
    internal partial class GetCdKeyResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int templateId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public long templateCount { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string cdKey { get; set; }

    }

    [ProtoContract]
    internal partial class UseCdKeyRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string cdKey { get; set; }

    }

    [ProtoContract]
    internal partial class UseCdKeyResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string cdKey { get; set; }

    }

    [ProtoContract]
    internal partial class ConvertItemRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string itemId { get; set; }

    }

    [ProtoContract]
    internal partial class ConvertItemResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"suc", IsRequired = true)]
        public bool Suc { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string itemId { get; set; }

    }

    [ProtoContract]
    internal partial class UseQRCodeTicketResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"suc", IsRequired = true)]
        public bool Suc { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int itemTemplateId { get; set; }

        [ProtoMember(3, Name = @"url", IsRequired = true)]
        public string Url { get; set; }

    }

    [ProtoContract]
    internal partial class RedPacketResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int templateId { get; set; }

        [ProtoMember(2, Name = @"count", IsRequired = true)]
        public long Count { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int playerId { get; set; }

    }

    [ProtoContract]
    internal partial class RedPacketWithMoneyResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int templateId { get; set; }

        [ProtoMember(2, Name = @"count", IsRequired = true)]
        public long Count { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int playerId { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyPlayerBonus : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(3, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int handPowerType { get; set; }

        [ProtoMember(5, Name = @"bonus", IsRequired = true)]
        public int Bonus { get; set; }

    }

    [ProtoContract]
    internal partial class JackpotInfoRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

    }

    [ProtoContract]
    internal partial class JackpotInfoResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"jackpot", IsRequired = true)]
        public long Jackpot { get; set; }

        [ProtoMember(2, Name = @"sb", IsRequired = true)]
        public long Sb { get; set; }

        [ProtoMember(3, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(4, Name = @"straddle", IsRequired = true)]
        public bool Straddle { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int lowestDivideBb { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int divideBb { get; set; }

        [ProtoMember(7)]
        public List<TriggerCard> triggerCards { get; } = new List<TriggerCard>();

        [ProtoMember(8, Name = @"enable", IsRequired = true)]
        public bool Enable { get; set; }

        [ProtoMember(100)]
        [DefaultValue("")]
        public string gameType
        {
            get { return __pbn__gameType ?? ""; }
            set { __pbn__gameType = value; }
        }
        public bool ShouldSerializegameType() => __pbn__gameType != null;
        public void ResetgameType() => __pbn__gameType = null;
        private string __pbn__gameType;

    }

    [ProtoContract]
    internal partial class TriggerCard : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int handPowerType { get; set; }

        [ProtoMember(2, Name = @"rate", IsRequired = true)]
        public double Rate { get; set; }

    }

    [ProtoContract]
    internal partial class JackpotRecordsRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class JackpotRecordsResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"max")]
        public JackpotUserRecord Max { get; set; }

        [ProtoMember(2, Name = @"players")]
        public List<JackpotUserRecord> Players { get; } = new List<JackpotUserRecord>();

    }

    [ProtoContract]
    internal partial class JackpotUserRecord : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int handPowerType { get; set; }

        [ProtoMember(3, Name = @"jackpot", IsRequired = true)]
        public long Jackpot { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long bonusTime { get; set; }

    }

    [ProtoContract]
    internal partial class Product : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [ProtoMember(2, Name = @"name", IsRequired = true)]
        public string Name { get; set; }

        [ProtoMember(3, Name = @"desc", IsRequired = true)]
        public string Desc { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long costCount { get; set; }

        [ProtoMember(5, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public MallShowType showType { get; set; } = MallShowType.Normal;

        [ProtoMember(7, IsRequired = true)]
        public int itemTempId { get; set; }

        [ProtoMember(8, Name = @"count", IsRequired = true)]
        public long Count { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public string engName { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public string engDesc { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public int costItemId { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public int originalCost { get; set; }

    }

    [ProtoContract]
    internal partial class Payment : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [ProtoMember(2, Name = @"diamond", IsRequired = true)]
        public long Diamond { get; set; }

        [ProtoMember(3, Name = @"cost", IsRequired = true)]
        public long Cost { get; set; }

        [ProtoMember(4, Name = @"type", IsRequired = true)]
        public string Type { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public MallShowType showType { get; set; } = MallShowType.Normal;

        [ProtoMember(6, IsRequired = true)]
        public string goodsName { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public string engGoodsName { get; set; }

    }

    [ProtoContract]
    internal partial class WechatOrder : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string prePayId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string partnerId { get; set; }

        [ProtoMember(3, Name = @"package", IsRequired = true)]
        public string Package { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string nonceStr { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public string timeStamp { get; set; }

        [ProtoMember(6, Name = @"sign", IsRequired = true)]
        public string Sign { get; set; }
    }

    [ProtoContract]
    internal partial class IapOrder : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string productId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string callbackUrl { get; set; }

        [ProtoMember(3, Name = @"amount", IsRequired = true)]
        public long Amount { get; set; }

    }

    [ProtoContract]
    internal partial class Order : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string orderId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint paymentId { get; set; }

        [ProtoMember(3, Name = @"time", IsRequired = true)]
        public uint Time { get; set; }

        [ProtoMember(11)]
        public IapOrder iapOrder
        {
            get { return __pbn__extra.Is(11) ? ((IapOrder)__pbn__extra.Object) : null; }
            set { __pbn__extra = new DiscriminatedUnionObject(11, value); }
        }
        public bool ShouldSerializeiapOrder() => __pbn__extra.Is(11);
        public void ResetiapOrder() => DiscriminatedUnionObject.Reset(ref __pbn__extra, 11);

        private DiscriminatedUnionObject __pbn__extra;

        [ProtoMember(12)]
        public WechatOrder wechatOrder
        {
            get { return __pbn__extra.Is(12) ? ((WechatOrder)__pbn__extra.Object) : null; }
            set { __pbn__extra = new DiscriminatedUnionObject(12, value); }
        }
        public bool ShouldSerializewechatOrder() => __pbn__extra.Is(12);
        public void ResetwechatOrder() => DiscriminatedUnionObject.Reset(ref __pbn__extra, 12);

    }

    [ProtoContract]
    internal partial class MallProductsRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class MallProductsResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"products")]
        public List<Product> Products { get; } = new List<Product>();

    }

    [ProtoContract]
    internal partial class MallPaymentsRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class MallPaymentsResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"payments")]
        public List<Payment> Payments { get; } = new List<Payment>();

        [ProtoMember(2, IsRequired = true)]
        public string payType { get; set; }

    }

    [ProtoContract]
    internal partial class MallOrderRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"type", IsRequired = true)]
        public string Type { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint paymentId { get; set; }

    }

    [ProtoContract]
    internal partial class MallOrderResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"order", IsRequired = true)]
        public Order Order { get; set; }

    }

    [ProtoContract]
    internal partial class MallBuyRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint productId { get; set; }

    }

    [ProtoContract]
    internal partial class MallBuyResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int productId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string itemId { get; set; }

        [ProtoMember(3)]
        public int mascotItemTempId
        {
            get { return __pbn__mascotItemTempId.GetValueOrDefault(); }
            set { __pbn__mascotItemTempId = value; }
        }
        public bool ShouldSerializemascotItemTempId() => __pbn__mascotItemTempId != null;
        public void ResetmascotItemTempId() => __pbn__mascotItemTempId = null;
        private int? __pbn__mascotItemTempId;

    }

    [ProtoContract]
    internal partial class MallPaymentNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public bool isSuccess { get; set; }

        [ProtoMember(2)]
        public uint paymentId
        {
            get { return __pbn__paymentId.GetValueOrDefault(); }
            set { __pbn__paymentId = value; }
        }
        public bool ShouldSerializepaymentId() => __pbn__paymentId != null;
        public void ResetpaymentId() => __pbn__paymentId = null;
        private uint? __pbn__paymentId;

        [ProtoMember(3, Name = @"diamond")]
        public long Diamond
        {
            get { return __pbn__Diamond.GetValueOrDefault(); }
            set { __pbn__Diamond = value; }
        }
        public bool ShouldSerializeDiamond() => __pbn__Diamond != null;
        public void ResetDiamond() => __pbn__Diamond = null;
        private long? __pbn__Diamond;

        [ProtoMember(4, Name = @"gold")]
        public long Gold
        {
            get { return __pbn__Gold.GetValueOrDefault(); }
            set { __pbn__Gold = value; }
        }
        public bool ShouldSerializeGold() => __pbn__Gold != null;
        public void ResetGold() => __pbn__Gold = null;
        private long? __pbn__Gold;

        [ProtoMember(5, Name = @"masterscore")]
        public long Masterscore
        {
            get { return __pbn__Masterscore.GetValueOrDefault(); }
            set { __pbn__Masterscore = value; }
        }
        public bool ShouldSerializeMasterscore() => __pbn__Masterscore != null;
        public void ResetMasterscore() => __pbn__Masterscore = null;
        private long? __pbn__Masterscore;

    }

    [ProtoContract]
    internal partial class MasterScoreRecord : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public ulong Id { get; set; }

        [ProtoMember(2, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(3, Name = @"expend", IsRequired = true)]
        public ulong Expend { get; set; }

        [ProtoMember(4, Name = @"income", IsRequired = true)]
        public ulong Income { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public TransactionType transactionType { get; set; } = TransactionType.Grant;

        [ProtoMember(6, IsRequired = true)]
        public long masterScore { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public ulong transactionTime { get; set; }

        [ProtoMember(8)]
        [DefaultValue("")]
        public string expendName
        {
            get { return __pbn__expendName ?? ""; }
            set { __pbn__expendName = value; }
        }
        public bool ShouldSerializeexpendName() => __pbn__expendName != null;
        public void ResetexpendName() => __pbn__expendName = null;
        private string __pbn__expendName;

        [ProtoMember(9)]
        [DefaultValue("")]
        public string incomeName
        {
            get { return __pbn__incomeName ?? ""; }
            set { __pbn__incomeName = value; }
        }
        public bool ShouldSerializeincomeName() => __pbn__incomeName != null;
        public void ResetincomeName() => __pbn__incomeName = null;
        private string __pbn__incomeName;

        [ProtoMember(10)]
        public long curMasterScore
        {
            get { return __pbn__curMasterScore.GetValueOrDefault(); }
            set { __pbn__curMasterScore = value; }
        }
        public bool ShouldSerializecurMasterScore() => __pbn__curMasterScore != null;
        public void ResetcurMasterScore() => __pbn__curMasterScore = null;
        private long? __pbn__curMasterScore;

        [ProtoMember(11, Name = @"icon")]
        [DefaultValue("")]
        public string Icon
        {
            get { return __pbn__Icon ?? ""; }
            set { __pbn__Icon = value; }
        }
        public bool ShouldSerializeIcon() => __pbn__Icon != null;
        public void ResetIcon() => __pbn__Icon = null;
        private string __pbn__Icon;

    }

    [ProtoContract]
    internal partial class MasterScoreStatistics : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public ulong Id { get; set; }

        [ProtoMember(2, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(4, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int totalScore { get; set; }

    }

    [ProtoContract]
    internal partial class ContributionMasterScoreRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public long masterScore { get; set; }

    }

    [ProtoContract]
    internal partial class ContributionMasterScoreResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public long masterScore { get; set; }

    }

    [ProtoContract]
    internal partial class GrantMasterScoreRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(2, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public long masterScore { get; set; }

    }

    [ProtoContract]
    internal partial class GrantMasterScoreResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public long masterScore { get; set; }

    }

    [ProtoContract]
    internal partial class MasterScoreRecordsRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(2, Name = @"page", DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int Page { get; set; }

        [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int pageSize { get; set; }

    }

    [ProtoContract]
    internal partial class MasterScoreRecordsResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"page", DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int Page { get; set; }

        [ProtoMember(2)]
        public List<MasterScoreRecord> masterScoreRecords { get; } = new List<MasterScoreRecord>();

    }

    [ProtoContract]
    internal partial class MasterScoreStatisticsRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(2, Name = @"page", DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int Page { get; set; }

        [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int pageSize { get; set; }

    }

    [ProtoContract]
    internal partial class MasterScoreStatisticsResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"page", DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int Page { get; set; }

        [ProtoMember(2)]
        public List<MasterScoreStatistics> masterScoreStatistics { get; } = new List<MasterScoreStatistics>();

    }

    [ProtoContract]
    internal partial class MasterScoreGainsRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int clubId { get; set; }

    }

    [ProtoContract]
    internal partial class MasterScoreGainsResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"masterScoreGainsData")]
        public List<MasterScoreGainsData> masterScoreGainsDatas { get; } = new List<MasterScoreGainsData>();

    }

    [ProtoContract]
    internal partial class MasterScoreGainsData : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public ulong dataTime { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int clubRebate { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int clubInsureRebate { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int subClubRebate { get; set; }

    }

    [ProtoContract]
    internal partial class JoinMTTRoomRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string invitationCode { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string sessionKey { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class JoinMTTRoomResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string invitationCode { get; set; }

        [ProtoMember(3, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(4, Name = @"pot", IsRequired = true)]
        public long Pot { get; set; }

        [ProtoMember(5, Name = @"sitInfo")]
        public List<SitInfo> sitInfoes { get; } = new List<SitInfo>();

        [ProtoMember(6, IsRequired = true)]
        public int roomType { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int createrId { get; set; }

        [ProtoMember(8, Name = @"name", IsRequired = true)]
        public string Name { get; set; }

        [ProtoMember(9, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

        [ProtoMember(10, Name = @"upbinld", DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int Upbinld { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public int actionTime { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(13, Name = @"pots")]
        public List<Pot> Pots { get; } = new List<Pot>();

        [ProtoMember(14)]
        public PubCard pubCard { get; set; }

        [ProtoMember(15, IsRequired = true)]
        public string signUpCost { get; set; }

        [ProtoMember(16, IsRequired = true)]
        public int signUpFeePercent { get; set; }

        [ProtoMember(17, IsRequired = true)]
        public long baseBankroll { get; set; }

        [ProtoMember(18, IsRequired = true)]
        public int reBuyRestNum { get; set; }

        [ProtoMember(19, IsRequired = true)]
        public int addRestNum { get; set; }

        [ProtoMember(20, IsRequired = true)]
        public int rEndBlind { get; set; }

        [ProtoMember(21, IsRequired = true)]
        public int addonChips { get; set; }

        [ProtoMember(22, IsRequired = true)]
        public int curBlindRank { get; set; }

        [ProtoMember(23, Name = @"mycard")]
        public List<Card> Mycards { get; } = new List<Card>();

        [ProtoMember(24)]
        public HandPowerEnum handPowerEnum { get; set; }

        [ProtoMember(25, IsRequired = true)]
        public int joinPlayerId { get; set; }

        [ProtoMember(26, IsRequired = true)]
        public int curBlindRestTime { get; set; }

        [ProtoMember(27)]
        public int endSignupBlind
        {
            get { return __pbn__endSignupBlind.GetValueOrDefault(); }
            set { __pbn__endSignupBlind = value; }
        }
        public bool ShouldSerializeendSignupBlind() => __pbn__endSignupBlind != null;
        public void ResetendSignupBlind() => __pbn__endSignupBlind = null;
        private int? __pbn__endSignupBlind;

        [ProtoMember(28)]
        [DefaultValue("")]
        public string rebuyCost
        {
            get { return __pbn__rebuyCost ?? ""; }
            set { __pbn__rebuyCost = value; }
        }
        public bool ShouldSerializerebuyCost() => __pbn__rebuyCost != null;
        public void ResetrebuyCost() => __pbn__rebuyCost = null;
        private string __pbn__rebuyCost;

        [ProtoMember(29)]
        public int rebuySurchargePercent
        {
            get { return __pbn__rebuySurchargePercent.GetValueOrDefault(); }
            set { __pbn__rebuySurchargePercent = value; }
        }
        public bool ShouldSerializerebuySurchargePercent() => __pbn__rebuySurchargePercent != null;
        public void ResetrebuySurchargePercent() => __pbn__rebuySurchargePercent = null;
        private int? __pbn__rebuySurchargePercent;

        [ProtoMember(30, IsRequired = true)]
        public int signUpType { get; set; }

        [ProtoMember(31, Name = @"sb", IsRequired = true)]
        public long Sb { get; set; }

        [ProtoMember(32, IsRequired = true)]
        public int playType { get; set; }

        [ProtoMember(33, IsRequired = true)]
        public int raiseLimitFixed { get; set; }

        [ProtoMember(34, IsRequired = true)]
        public string raiseLimitPot { get; set; }

        [ProtoMember(35, Name = @"item")]
        public List<PublicCardCostItem> Items { get; } = new List<PublicCardCostItem>();

    }

    [ProtoContract]
    internal partial class PublicCardCostItem : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int itemId { get; set; }

        [ProtoMember(2, Name = @"count", IsRequired = true)]
        public int Count { get; set; }

        [ProtoMember(3, Name = @"state", IsRequired = true)]
        public string State { get; set; }

    }

    [ProtoContract]
    internal partial class HandPowerEnum1 : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        [DefaultValue(HandPowerTypes.HighCard)]
        public HandPowerTypes handPowerTypes
        {
            get { return __pbn__handPowerTypes ?? HandPowerTypes.HighCard; }
            set { __pbn__handPowerTypes = value; }
        }
        public bool ShouldSerializehandPowerTypes() => __pbn__handPowerTypes != null;
        public void ResethandPowerTypes() => __pbn__handPowerTypes = null;
        private HandPowerTypes? __pbn__handPowerTypes;

        [ProtoContract]
        internal enum HandPowerTypes
        {
            [ProtoEnum(Name = @"HIGH_CARD")]
            HighCard = 1,
            [ProtoEnum(Name = @"ONE_PAIR")]
            OnePair = 2,
            [ProtoEnum(Name = @"TWO_PAIR")]
            TwoPair = 3,
            [ProtoEnum(Name = @"THREE_OF_A_KIND")]
            ThreeOfAKind = 4,
            [ProtoEnum(Name = @"STRAIGHT")]
            Straight = 5,
            [ProtoEnum(Name = @"FLUSH")]
            Flush = 6,
            [ProtoEnum(Name = @"FULL_HOUSE")]
            FullHouse = 7,
            [ProtoEnum(Name = @"FOUR_OF_A_KIND")]
            FourOfAKind = 8,
            [ProtoEnum(Name = @"STRAIGHT_FLUSH")]
            StraightFlush = 9,
            [ProtoEnum(Name = @"ROYAL_STRAIGHT_FLUSH")]
            RoyalStraightFlush = 10,
            [ProtoEnum(Name = @"NO_CARD")]
            NoCard = 11,
        }

    }

    [ProtoContract]
    internal partial class RaceBlindTable : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int blindRank { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int smallBlind { get; set; }

        [ProtoMember(3, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerInfo : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(3, Name = @"state", IsRequired = true)]
        public int State { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int gameGold { get; set; }

        [ProtoMember(5, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public string playerName { get; set; }

    }

    [ProtoContract]
    internal partial class SitInfo1 : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, Name = @"action", IsRequired = true)]
        public int Action { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long actionTime { get; set; }

        [ProtoMember(5, Name = @"bet", IsRequired = true)]
        public long Bet { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public bool isDealer { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public bool isSB { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public bool isBB { get; set; }

        [ProtoMember(9, Name = @"bankroll", IsRequired = true)]
        public long Bankroll { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public long needCall { get; set; }

        [ProtoMember(11, Name = @"state", IsRequired = true)]
        public int State { get; set; }

        [ProtoMember(12, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

        [ProtoMember(13, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

        [ProtoMember(14, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(15, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(16, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(17, Name = @"managed", IsRequired = true)]
        public bool Managed { get; set; }

        [ProtoMember(18)]
        public bool isStraddle
        {
            get { return __pbn__isStraddle.GetValueOrDefault(); }
            set { __pbn__isStraddle = value; }
        }
        public bool ShouldSerializeisStraddle() => __pbn__isStraddle != null;
        public void ResetisStraddle() => __pbn__isStraddle = null;
        private bool? __pbn__isStraddle;

        [ProtoMember(19, Name = @"isforce")]
        public bool Isforce
        {
            get { return __pbn__Isforce.GetValueOrDefault(); }
            set { __pbn__Isforce = value; }
        }
        public bool ShouldSerializeIsforce() => __pbn__Isforce != null;
        public void ResetIsforce() => __pbn__Isforce = null;
        private bool? __pbn__Isforce;

        [ProtoMember(20, IsRequired = true)]
        public int takeMascot { get; set; }

        [ProtoMember(21)]
        public int sngOverRank
        {
            get { return __pbn__sngOverRank.GetValueOrDefault(); }
            set { __pbn__sngOverRank = value; }
        }
        public bool ShouldSerializesngOverRank() => __pbn__sngOverRank != null;
        public void ResetsngOverRank() => __pbn__sngOverRank = null;
        private int? __pbn__sngOverRank;

        [ProtoMember(22)]
        public int suspicionTag
        {
            get { return __pbn__suspicionTag.GetValueOrDefault(); }
            set { __pbn__suspicionTag = value; }
        }
        public bool ShouldSerializesuspicionTag() => __pbn__suspicionTag != null;
        public void ResetsuspicionTag() => __pbn__suspicionTag = null;
        private int? __pbn__suspicionTag;

        [ProtoMember(23)]
        public int aGroupOfTag
        {
            get { return __pbn__aGroupOfTag.GetValueOrDefault(); }
            set { __pbn__aGroupOfTag = value; }
        }
        public bool ShouldSerializeaGroupOfTag() => __pbn__aGroupOfTag != null;
        public void ResetaGroupOfTag() => __pbn__aGroupOfTag = null;
        private int? __pbn__aGroupOfTag;

        [ProtoMember(24, Name = @"endaction", IsRequired = true)]
        public int Endaction { get; set; }

        [ProtoMember(25)]
        public int keepSitRestTime
        {
            get { return __pbn__keepSitRestTime.GetValueOrDefault(); }
            set { __pbn__keepSitRestTime = value; }
        }
        public bool ShouldSerializekeepSitRestTime() => __pbn__keepSitRestTime != null;
        public void ResetkeepSitRestTime() => __pbn__keepSitRestTime = null;
        private int? __pbn__keepSitRestTime;

    }

    [ProtoContract]
    internal partial class Pot1 : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"winnerId")]
        public int[] winnerIds { get; set; }

        [ProtoMember(2, Name = @"gold", IsRequired = true)]
        public long Gold { get; set; }

        [ProtoMember(3)]
        public int[] playerIds { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int potType { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int potId { get; set; }

    }

    [ProtoContract]
    internal partial class PubCard2 : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"card")]
        public List<Card> Cards { get; } = new List<Card>();

    }

    [ProtoContract]
    internal partial class Card1 : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string cardSuit { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int cardNumber { get; set; }

    }

    [ProtoContract]
    internal partial class MTTConnectRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"incode", IsRequired = true)]
        public string Incode { get; set; }

    }

    [ProtoContract]
    internal partial class MTTGameUpdate : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string invitationCode { get; set; }

        [ProtoMember(3, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(4, Name = @"pot", IsRequired = true)]
        public long Pot { get; set; }

        [ProtoMember(5, Name = @"sitInfo")]
        public List<SitInfo> sitInfoes { get; } = new List<SitInfo>();

        [ProtoMember(6, IsRequired = true)]
        public int roomType { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int createrId { get; set; }

        [ProtoMember(8, Name = @"name", IsRequired = true)]
        public string Name { get; set; }

        [ProtoMember(9, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

        [ProtoMember(10, Name = @"upbinld", DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int Upbinld { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public int actionTime { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(13, Name = @"pots")]
        public List<Pot> Pots { get; } = new List<Pot>();

        [ProtoMember(14)]
        public PubCard pubCard { get; set; }

        [ProtoMember(15, Name = @"sb", IsRequired = true)]
        public long Sb { get; set; }

    }

    [ProtoContract]
    internal partial class MTTReEntryNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int countDown { get; set; }

    }

    [ProtoContract]
    internal partial class MTTPurchaseRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"type", IsRequired = true)]
        public MTTPurchaseType Type { get; set; } = MTTPurchaseType.ReEntry;

        [ProtoMember(2, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string rebuyItemUniqueId { get; set; }

    }

    [ProtoContract]
    internal partial class MTTPurchaseResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"suc", IsRequired = true)]
        public bool Suc { get; set; }

        [ProtoMember(2)]
        public int reBuyRestNum
        {
            get { return __pbn__reBuyRestNum.GetValueOrDefault(); }
            set { __pbn__reBuyRestNum = value; }
        }
        public bool ShouldSerializereBuyRestNum() => __pbn__reBuyRestNum != null;
        public void ResetreBuyRestNum() => __pbn__reBuyRestNum = null;
        private int? __pbn__reBuyRestNum;

        [ProtoMember(3)]
        public int addRestNum
        {
            get { return __pbn__addRestNum.GetValueOrDefault(); }
            set { __pbn__addRestNum = value; }
        }
        public bool ShouldSerializeaddRestNum() => __pbn__addRestNum != null;
        public void ResetaddRestNum() => __pbn__addRestNum = null;
        private int? __pbn__addRestNum;

        [ProtoMember(4, Name = @"type", IsRequired = true)]
        public MTTPurchaseType Type { get; set; } = MTTPurchaseType.ReEntry;

        [ProtoMember(5)]
        public int playerId
        {
            get { return __pbn__playerId.GetValueOrDefault(); }
            set { __pbn__playerId = value; }
        }
        public bool ShouldSerializeplayerId() => __pbn__playerId != null;
        public void ResetplayerId() => __pbn__playerId = null;
        private int? __pbn__playerId;

    }

    [ProtoContract]
    internal partial class MTTUnReEntryRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

    }

    [ProtoContract]
    internal partial class MTTUnReEntryResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"suc", IsRequired = true)]
        public bool Suc { get; set; }

    }

    [ProtoContract]
    internal partial class MTTPlayerOverRankNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(2, Name = @"rank", IsRequired = true)]
        public int Rank { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(5, Name = @"reward", IsRequired = true)]
        public string Reward { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int playerId { get; set; }

    }

    [ProtoContract]
    internal partial class MTTOutRoomRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class mttDetailRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

    }

    [ProtoContract]
    internal partial class mttDetailResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public long avgBankRoll { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public long maxBankRoll { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long minBankRoll { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int curGameNum { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int preceedTime { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int restPlayerNum { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int totalPlayerNum { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public long totalBonus { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public int rewardNum { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public int blindRestTime { get; set; }

        [ProtoMember(12, Name = @"bonusInfo")]
        public List<MTTBonusInfo> bonusInfoes { get; } = new List<MTTBonusInfo>();

        [ProtoMember(13, IsRequired = true)]
        public int totalBuyCount { get; set; }

        [ProtoMember(14, IsRequired = true)]
        public int floatRewardItemId { get; set; }

        [ProtoMember(15, IsRequired = true)]
        public int awardType { get; set; }

    }

    [ProtoContract]
    internal partial class MTTBonusInfo : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int rankStart { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int rankEnd { get; set; }

        [ProtoMember(3, Name = @"percent", IsRequired = true)]
        public int Percent { get; set; }

        [ProtoMember(4)]
        [DefaultValue("")]
        public string itemsReward
        {
            get { return __pbn__itemsReward ?? ""; }
            set { __pbn__itemsReward = value; }
        }
        public bool ShouldSerializeitemsReward() => __pbn__itemsReward != null;
        public void ResetitemsReward() => __pbn__itemsReward = null;
        private string __pbn__itemsReward;

    }

    [ProtoContract]
    internal partial class mttRankRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int rankStart { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int rankEnd { get; set; }

    }

    [ProtoContract]
    internal partial class mttRankResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, Name = @"rankPlayer")]
        public List<mttRankPlayer> rankPlayers { get; } = new List<mttRankPlayer>();

        [ProtoMember(3, IsRequired = true)]
        public bool isInRank { get; set; }

    }

    [ProtoContract]
    internal partial class mttRankPlayer : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"rank", IsRequired = true)]
        public int Rank { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string playerIcon { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int curGameId { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public long bankRoll { get; set; }

    }

    [ProtoContract]
    internal partial class mttDataRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

    }

    [ProtoContract]
    internal partial class mttDataResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string signUpCost { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int signUpFee { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public long baseBankroll { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int reBuyRestNum { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int addRestNum { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int rEndBlind { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int addonChips { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int curBlindRank { get; set; }

        [ProtoMember(9, Name = @"raceBlind")]
        public List<RaceBlindTable> raceBlinds { get; } = new List<RaceBlindTable>();

        [ProtoMember(10, IsRequired = true)]
        public int signUpType { get; set; }

    }

    [ProtoContract]
    internal partial class MTTWatchRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2)]
        public int gameId
        {
            get { return __pbn__gameId.GetValueOrDefault(); }
            set { __pbn__gameId = value; }
        }
        public bool ShouldSerializegameId() => __pbn__gameId != null;
        public void ResetgameId() => __pbn__gameId = null;
        private int? __pbn__gameId;

        [ProtoMember(3)]
        public int watchPlayerId
        {
            get { return __pbn__watchPlayerId.GetValueOrDefault(); }
            set { __pbn__watchPlayerId = value; }
        }
        public bool ShouldSerializewatchPlayerId() => __pbn__watchPlayerId != null;
        public void ResetwatchPlayerId() => __pbn__watchPlayerId = null;
        private int? __pbn__watchPlayerId;

        [ProtoMember(4, IsRequired = true)]
        public string sessionKey { get; set; }

    }

    [ProtoContract]
    internal partial class MTTOverNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int createrId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string createrName { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public string createrIcon { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public string createTime { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int roomType { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int maxPlayerCount { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public int durationTime { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public string startTime { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public int upBlindTime { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public string applyCost { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public long initChip { get; set; }

        [ProtoMember(14)]
        public long totalBonus
        {
            get { return __pbn__totalBonus.GetValueOrDefault(); }
            set { __pbn__totalBonus = value; }
        }
        public bool ShouldSerializetotalBonus() => __pbn__totalBonus != null;
        public void ResettotalBonus() => __pbn__totalBonus = null;
        private long? __pbn__totalBonus;

        [ProtoMember(15, Name = @"playerReward")]
        public List<MTTPlayerReward> playerRewards { get; } = new List<MTTPlayerReward>();

        [ProtoMember(16, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(17, IsRequired = true)]
        public int playerCount { get; set; }

        [ProtoMember(18, IsRequired = true)]
        public int totalReBuyCount { get; set; }

        [ProtoMember(19, IsRequired = true)]
        public int signUpType { get; set; }

        [ProtoMember(20)]
        public int floatRewardItemId
        {
            get { return __pbn__floatRewardItemId.GetValueOrDefault(); }
            set { __pbn__floatRewardItemId = value; }
        }
        public bool ShouldSerializefloatRewardItemId() => __pbn__floatRewardItemId != null;
        public void ResetfloatRewardItemId() => __pbn__floatRewardItemId = null;
        private int? __pbn__floatRewardItemId;

        [ProtoMember(21, Name = @"straddle", IsRequired = true)]
        public int Straddle { get; set; }

    }

    [ProtoContract]
    internal partial class MTTPlayerReward : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"rank", IsRequired = true)]
        public int Rank { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(4)]
        public long rewardGold
        {
            get { return __pbn__rewardGold.GetValueOrDefault(); }
            set { __pbn__rewardGold = value; }
        }
        public bool ShouldSerializerewardGold() => __pbn__rewardGold != null;
        public void ResetrewardGold() => __pbn__rewardGold = null;
        private long? __pbn__rewardGold;

        [ProtoMember(5, IsRequired = true)]
        public string playerIcon { get; set; }

        [ProtoMember(6)]
        [DefaultValue("")]
        public string rewardItems
        {
            get { return __pbn__rewardItems ?? ""; }
            set { __pbn__rewardItems = value; }
        }
        public bool ShouldSerializerewardItems() => __pbn__rewardItems != null;
        public void ResetrewardItems() => __pbn__rewardItems = null;
        private string __pbn__rewardItems;

        [ProtoMember(7, IsRequired = true)]
        public int buyCount { get; set; }

    }

    [ProtoContract]
    internal partial class MTTMyRankRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

    }

    [ProtoContract]
    internal partial class MTTMyRankResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, Name = @"rank", IsRequired = true)]
        public int Rank { get; set; }

    }

    [ProtoContract]
    internal partial class WaitingHandNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int waitCount { get; set; }

    }

    [ProtoContract]
    internal partial class MttFinalTableNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class OptionParams : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"option")]
        [DefaultValue(NotifyOption.ApplJoinClub)]
        public NotifyOption Option
        {
            get { return __pbn__Option ?? NotifyOption.ApplJoinClub; }
            set { __pbn__Option = value; }
        }
        public bool ShouldSerializeOption() => __pbn__Option != null;
        public void ResetOption() => __pbn__Option = null;
        private NotifyOption? __pbn__Option;

        [ProtoMember(2)]
        [DefaultValue("")]
        public string clubName
        {
            get { return __pbn__clubName ?? ""; }
            set { __pbn__clubName = value; }
        }
        public bool ShouldSerializeclubName() => __pbn__clubName != null;
        public void ResetclubName() => __pbn__clubName = null;
        private string __pbn__clubName;

        [ProtoMember(3)]
        public int clubId
        {
            get { return __pbn__clubId.GetValueOrDefault(); }
            set { __pbn__clubId = value; }
        }
        public bool ShouldSerializeclubId() => __pbn__clubId != null;
        public void ResetclubId() => __pbn__clubId = null;
        private int? __pbn__clubId;

        [ProtoMember(4)]
        public long applyId
        {
            get { return __pbn__applyId.GetValueOrDefault(); }
            set { __pbn__applyId = value; }
        }
        public bool ShouldSerializeapplyId() => __pbn__applyId != null;
        public void ResetapplyId() => __pbn__applyId = null;
        private long? __pbn__applyId;

        [ProtoMember(5)]
        public int recordId
        {
            get { return __pbn__recordId.GetValueOrDefault(); }
            set { __pbn__recordId = value; }
        }
        public bool ShouldSerializerecordId() => __pbn__recordId != null;
        public void ResetrecordId() => __pbn__recordId = null;
        private int? __pbn__recordId;

        [ProtoMember(6)]
        [DefaultValue("")]
        public string raceName
        {
            get { return __pbn__raceName ?? ""; }
            set { __pbn__raceName = value; }
        }
        public bool ShouldSerializeraceName() => __pbn__raceName != null;
        public void ResetraceName() => __pbn__raceName = null;
        private string __pbn__raceName;

        [ProtoMember(7)]
        public int raceRank
        {
            get { return __pbn__raceRank.GetValueOrDefault(); }
            set { __pbn__raceRank = value; }
        }
        public bool ShouldSerializeraceRank() => __pbn__raceRank != null;
        public void ResetraceRank() => __pbn__raceRank = null;
        private int? __pbn__raceRank;

        [ProtoMember(8)]
        public int rewardType
        {
            get { return __pbn__rewardType.GetValueOrDefault(); }
            set { __pbn__rewardType = value; }
        }
        public bool ShouldSerializerewardType() => __pbn__rewardType != null;
        public void ResetrewardType() => __pbn__rewardType = null;
        private int? __pbn__rewardType;

        [ProtoMember(9, Name = @"raceReward")]
        public List<RaceReward> raceRewards { get; } = new List<RaceReward>();

    }

    [ProtoContract]
    internal partial class RaceReward : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        [DefaultValue("")]
        public string rewardName
        {
            get { return __pbn__rewardName ?? ""; }
            set { __pbn__rewardName = value; }
        }
        public bool ShouldSerializerewardName() => __pbn__rewardName != null;
        public void ResetrewardName() => __pbn__rewardName = null;
        private string __pbn__rewardName;

        [ProtoMember(2)]
        public long rewardNum
        {
            get { return __pbn__rewardNum.GetValueOrDefault(); }
            set { __pbn__rewardNum = value; }
        }
        public bool ShouldSerializerewardNum() => __pbn__rewardNum != null;
        public void ResetrewardNum() => __pbn__rewardNum = null;
        private long? __pbn__rewardNum;

    }

    [ProtoContract]
    internal partial class NotifyParameter : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"banner")]
        [DefaultValue("")]
        public string Banner
        {
            get { return __pbn__Banner ?? ""; }
            set { __pbn__Banner = value; }
        }
        public bool ShouldSerializeBanner() => __pbn__Banner != null;
        public void ResetBanner() => __pbn__Banner = null;
        private string __pbn__Banner;

    }

    [ProtoContract]
    internal partial class Notification : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public ulong notifyId { get; set; }

        [ProtoMember(2, Name = @"type", IsRequired = true)]
        public NotifyType Type { get; set; } = NotifyType.NotifyNotice;

        [ProtoMember(3, Name = @"title", IsRequired = true)]
        public int Title { get; set; }

        [ProtoMember(4, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

        [ProtoMember(5, Name = @"desciption", IsRequired = true)]
        public int Desciption { get; set; }

        [ProtoMember(6, Name = @"time", DataFormat = DataFormat.FixedSize, IsRequired = true)]
        public uint Time { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public bool isPush { get; set; }

        [ProtoMember(8, Name = @"params")]
        public List<NotifyParameter> Params { get; } = new List<NotifyParameter>();

        [ProtoMember(9)]
        public OptionParams optionPrams { get; set; }

        [ProtoMember(10)]
        public List<TitleParam> titleParams { get; } = new List<TitleParam>();

        [ProtoMember(11)]
        public List<DescParam> descParams { get; } = new List<DescParam>();

    }

    [ProtoContract]
    internal partial class TitleParam : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string titleParams { get; set; }

    }

    [ProtoContract]
    internal partial class DescParam : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string descParams { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public ulong Id { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public ulong Id { get; set; }

        [ProtoMember(2, Name = @"content", IsRequired = true)]
        public string Content { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyListRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public NotifyType notifyType { get; set; } = NotifyType.NotifyNotice;

    }

    [ProtoContract]
    internal partial class NotifyListResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public NotifyType notifyType { get; set; } = NotifyType.NotifyNotice;

        [ProtoMember(2, Name = @"notifications")]
        public List<Notification> Notifications { get; } = new List<Notification>();

    }

    [ProtoContract]
    internal partial class NotifyNewCommonRoom : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int gammeId { get; set; }

    }

    [ProtoContract]
    internal partial class authorityPlayerRebuyReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string notifyId { get; set; }

        [ProtoMember(2, Name = @"agree", IsRequired = true)]
        public int Agree { get; set; }

    }

    [ProtoContract]
    internal partial class authorityPlayerRebuyRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"status", IsRequired = true)]
        public int Status { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerServer : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"type", IsRequired = true)]
        public ServerType Type { get; set; } = ServerType.Chat;

        [ProtoMember(2, Name = @"ip", IsRequired = true)]
        public string Ip { get; set; }

        [ProtoMember(3, Name = @"port", IsRequired = true)]
        public uint Port { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerData : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint handCount { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint inPotCount { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint raceCount { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public uint rewardCount { get; set; }

    }

    [ProtoContract]
    internal partial class Player : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint playerId { get; set; }

        [ProtoMember(6, Name = @"gold", IsRequired = true)]
        public long Gold { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public bool hasPhone { get; set; }

        [ProtoMember(12, Name = @"servers")]
        public List<PlayerServer> Servers { get; } = new List<PlayerServer>();

        [ProtoMember(13, Name = @"diamond", IsRequired = true)]
        public long Diamond { get; set; }

        [ProtoMember(10, Name = @"reconnect")]
        public Reconnect Reconnect { get; set; }

        [ProtoMember(11)]
        [DefaultValue("")]
        public string accountId
        {
            get { return __pbn__accountId ?? ""; }
            set { __pbn__accountId = value; }
        }
        public bool ShouldSerializeaccountId() => __pbn__accountId != null;
        public void ResetaccountId() => __pbn__accountId = null;
        private string __pbn__accountId;

        [ProtoMember(7, Name = @"token")]
        [DefaultValue("")]
        public string Token
        {
            get { return __pbn__Token ?? ""; }
            set { __pbn__Token = value; }
        }
        public bool ShouldSerializeToken() => __pbn__Token != null;
        public void ResetToken() => __pbn__Token = null;
        private string __pbn__Token;

        [ProtoMember(2, Name = @"icon")]
        [DefaultValue("")]
        public string Icon
        {
            get { return __pbn__Icon ?? ""; }
            set { __pbn__Icon = value; }
        }
        public bool ShouldSerializeIcon() => __pbn__Icon != null;
        public void ResetIcon() => __pbn__Icon = null;
        private string __pbn__Icon;

        [ProtoMember(3, Name = @"gender")]
        public uint Gender
        {
            get { return __pbn__Gender.GetValueOrDefault(); }
            set { __pbn__Gender = value; }
        }
        public bool ShouldSerializeGender() => __pbn__Gender != null;
        public void ResetGender() => __pbn__Gender = null;
        private uint? __pbn__Gender;

        [ProtoMember(4, Name = @"name")]
        [DefaultValue("")]
        public string Name
        {
            get { return __pbn__Name ?? ""; }
            set { __pbn__Name = value; }
        }
        public bool ShouldSerializeName() => __pbn__Name != null;
        public void ResetName() => __pbn__Name = null;
        private string __pbn__Name;

        [ProtoMember(5, Name = @"signature")]
        [DefaultValue("")]
        public string Signature
        {
            get { return __pbn__Signature ?? ""; }
            set { __pbn__Signature = value; }
        }
        public bool ShouldSerializeSignature() => __pbn__Signature != null;
        public void ResetSignature() => __pbn__Signature = null;
        private string __pbn__Signature;

        [ProtoMember(14)]
        public PlayerData playerData { get; set; }

        [ProtoMember(15, Name = @"settings")]
        [DefaultValue("")]
        public string Settings
        {
            get { return __pbn__Settings ?? ""; }
            set { __pbn__Settings = value; }
        }
        public bool ShouldSerializeSettings() => __pbn__Settings != null;
        public void ResetSettings() => __pbn__Settings = null;
        private string __pbn__Settings;

        [ProtoMember(16)]
        public bool isWeixin
        {
            get { return __pbn__isWeixin.GetValueOrDefault(); }
            set { __pbn__isWeixin = value; }
        }
        public bool ShouldSerializeisWeixin() => __pbn__isWeixin != null;
        public void ResetisWeixin() => __pbn__isWeixin = null;
        private bool? __pbn__isWeixin;

        [ProtoMember(17)]
        public bool isUpload
        {
            get { return __pbn__isUpload.GetValueOrDefault(); }
            set { __pbn__isUpload = value; }
        }
        public bool ShouldSerializeisUpload() => __pbn__isUpload != null;
        public void ResetisUpload() => __pbn__isUpload = null;
        private bool? __pbn__isUpload;

        [ProtoMember(18, Name = @"club")]
        [DefaultValue("")]
        public string Club
        {
            get { return __pbn__Club ?? ""; }
            set { __pbn__Club = value; }
        }
        public bool ShouldSerializeClub() => __pbn__Club != null;
        public void ResetClub() => __pbn__Club = null;
        private string __pbn__Club;

        [ProtoMember(19, IsRequired = true)]
        public int takeMascot { get; set; }

        [ProtoMember(20)]
        [DefaultValue("")]
        public string clubLevel
        {
            get { return __pbn__clubLevel ?? ""; }
            set { __pbn__clubLevel = value; }
        }
        public bool ShouldSerializeclubLevel() => __pbn__clubLevel != null;
        public void ResetclubLevel() => __pbn__clubLevel = null;
        private string __pbn__clubLevel;

        [ProtoMember(21)]
        [DefaultValue("")]
        public string addBetType
        {
            get { return __pbn__addBetType ?? ""; }
            set { __pbn__addBetType = value; }
        }
        public bool ShouldSerializeaddBetType() => __pbn__addBetType != null;
        public void ResetaddBetType() => __pbn__addBetType = null;
        private string __pbn__addBetType;

        [ProtoMember(22)]
        [DefaultValue("")]
        public string tableStyle
        {
            get { return __pbn__tableStyle ?? ""; }
            set { __pbn__tableStyle = value; }
        }
        public bool ShouldSerializetableStyle() => __pbn__tableStyle != null;
        public void ResettableStyle() => __pbn__tableStyle = null;
        private string __pbn__tableStyle;

        [ProtoMember(23)]
        public int cardStyle
        {
            get { return __pbn__cardStyle.GetValueOrDefault(); }
            set { __pbn__cardStyle = value; }
        }
        public bool ShouldSerializecardStyle() => __pbn__cardStyle != null;
        public void ResetcardStyle() => __pbn__cardStyle = null;
        private int? __pbn__cardStyle;

        [ProtoMember(24)]
        public int paySettingIndex
        {
            get { return __pbn__paySettingIndex.GetValueOrDefault(); }
            set { __pbn__paySettingIndex = value; }
        }
        public bool ShouldSerializepaySettingIndex() => __pbn__paySettingIndex != null;
        public void ResetpaySettingIndex() => __pbn__paySettingIndex = null;
        private int? __pbn__paySettingIndex;

        [ProtoMember(25)]
        public int notCheckPasswordDays
        {
            get { return __pbn__notCheckPasswordDays.GetValueOrDefault(); }
            set { __pbn__notCheckPasswordDays = value; }
        }
        public bool ShouldSerializenotCheckPasswordDays() => __pbn__notCheckPasswordDays != null;
        public void ResetnotCheckPasswordDays() => __pbn__notCheckPasswordDays = null;
        private int? __pbn__notCheckPasswordDays;

        [ProtoMember(26)]
        public int notCheckPasswordAmount
        {
            get { return __pbn__notCheckPasswordAmount.GetValueOrDefault(); }
            set { __pbn__notCheckPasswordAmount = value; }
        }
        public bool ShouldSerializenotCheckPasswordAmount() => __pbn__notCheckPasswordAmount != null;
        public void ResetnotCheckPasswordAmount() => __pbn__notCheckPasswordAmount = null;
        private int? __pbn__notCheckPasswordAmount;

        [ProtoMember(27)]
        public bool setPaySetting
        {
            get { return __pbn__setPaySetting.GetValueOrDefault(); }
            set { __pbn__setPaySetting = value; }
        }
        public bool ShouldSerializesetPaySetting() => __pbn__setPaySetting != null;
        public void ResetsetPaySetting() => __pbn__setPaySetting = null;
        private bool? __pbn__setPaySetting;

        [ProtoMember(28)]
        [DefaultValue("")]
        public string secondPasswordPhone
        {
            get { return __pbn__secondPasswordPhone ?? ""; }
            set { __pbn__secondPasswordPhone = value; }
        }
        public bool ShouldSerializesecondPasswordPhone() => __pbn__secondPasswordPhone != null;
        public void ResetsecondPasswordPhone() => __pbn__secondPasswordPhone = null;
        private string __pbn__secondPasswordPhone;

        [ProtoMember(29)]
        [DefaultValue("")]
        public string secondPasswordNationCode
        {
            get { return __pbn__secondPasswordNationCode ?? ""; }
            set { __pbn__secondPasswordNationCode = value; }
        }
        public bool ShouldSerializesecondPasswordNationCode() => __pbn__secondPasswordNationCode != null;
        public void ResetsecondPasswordNationCode() => __pbn__secondPasswordNationCode = null;
        private string __pbn__secondPasswordNationCode;

        [ProtoMember(30)]
        public bool deviceLock
        {
            get { return __pbn__deviceLock.GetValueOrDefault(); }
            set { __pbn__deviceLock = value; }
        }
        public bool ShouldSerializedeviceLock() => __pbn__deviceLock != null;
        public void ResetdeviceLock() => __pbn__deviceLock = null;
        private bool? __pbn__deviceLock;

        [ProtoMember(31, Name = @"account", IsRequired = true)]
        public string Account { get; set; }

        [ProtoMember(32)]
        public int cardbackStyle
        {
            get { return __pbn__cardbackStyle.GetValueOrDefault(); }
            set { __pbn__cardbackStyle = value; }
        }
        public bool ShouldSerializecardbackStyle() => __pbn__cardbackStyle != null;
        public void ResetcardbackStyle() => __pbn__cardbackStyle = null;
        private int? __pbn__cardbackStyle;

        [ProtoMember(33)]
        public int tablebackStyle
        {
            get { return __pbn__tablebackStyle.GetValueOrDefault(); }
            set { __pbn__tablebackStyle = value; }
        }
        public bool ShouldSerializetablebackStyle() => __pbn__tablebackStyle != null;
        public void ResettablebackStyle() => __pbn__tablebackStyle = null;
        private int? __pbn__tablebackStyle;

        [ProtoMember(34, IsRequired = true)]
        public bool hasWalletPwd { get; set; }

    }

    [ProtoContract]
    internal partial class ModifyPlayerInfoCost : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int costItemId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public long costCount { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerUpdateStyleRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        [DefaultValue("")]
        public string addBetType
        {
            get { return __pbn__addBetType ?? ""; }
            set { __pbn__addBetType = value; }
        }
        public bool ShouldSerializeaddBetType() => __pbn__addBetType != null;
        public void ResetaddBetType() => __pbn__addBetType = null;
        private string __pbn__addBetType;

        [ProtoMember(2)]
        [DefaultValue("")]
        public string tableStyle
        {
            get { return __pbn__tableStyle ?? ""; }
            set { __pbn__tableStyle = value; }
        }
        public bool ShouldSerializetableStyle() => __pbn__tableStyle != null;
        public void ResettableStyle() => __pbn__tableStyle = null;
        private string __pbn__tableStyle;

        [ProtoMember(3)]
        [DefaultValue("")]
        public string cardStyle
        {
            get { return __pbn__cardStyle ?? ""; }
            set { __pbn__cardStyle = value; }
        }
        public bool ShouldSerializecardStyle() => __pbn__cardStyle != null;
        public void ResetcardStyle() => __pbn__cardStyle = null;
        private string __pbn__cardStyle;

        [ProtoMember(4)]
        [DefaultValue("")]
        public string cardbackStyle
        {
            get { return __pbn__cardbackStyle ?? ""; }
            set { __pbn__cardbackStyle = value; }
        }
        public bool ShouldSerializecardbackStyle() => __pbn__cardbackStyle != null;
        public void ResetcardbackStyle() => __pbn__cardbackStyle = null;
        private string __pbn__cardbackStyle;

        [ProtoMember(5)]
        [DefaultValue("")]
        public string tablebackStyle
        {
            get { return __pbn__tablebackStyle ?? ""; }
            set { __pbn__tablebackStyle = value; }
        }
        public bool ShouldSerializetablebackStyle() => __pbn__tablebackStyle != null;
        public void ResettablebackStyle() => __pbn__tablebackStyle = null;
        private string __pbn__tablebackStyle;

    }

    [ProtoContract]
    internal partial class PlayerUpdateStyleResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        [DefaultValue("")]
        public string addBetType
        {
            get { return __pbn__addBetType ?? ""; }
            set { __pbn__addBetType = value; }
        }
        public bool ShouldSerializeaddBetType() => __pbn__addBetType != null;
        public void ResetaddBetType() => __pbn__addBetType = null;
        private string __pbn__addBetType;

        [ProtoMember(2)]
        [DefaultValue("")]
        public string tableStyle
        {
            get { return __pbn__tableStyle ?? ""; }
            set { __pbn__tableStyle = value; }
        }
        public bool ShouldSerializetableStyle() => __pbn__tableStyle != null;
        public void ResettableStyle() => __pbn__tableStyle = null;
        private string __pbn__tableStyle;

        [ProtoMember(3)]
        [DefaultValue("")]
        public string cardStyle
        {
            get { return __pbn__cardStyle ?? ""; }
            set { __pbn__cardStyle = value; }
        }
        public bool ShouldSerializecardStyle() => __pbn__cardStyle != null;
        public void ResetcardStyle() => __pbn__cardStyle = null;
        private string __pbn__cardStyle;

        [ProtoMember(4)]
        [DefaultValue("")]
        public string cardbackStyle
        {
            get { return __pbn__cardbackStyle ?? ""; }
            set { __pbn__cardbackStyle = value; }
        }
        public bool ShouldSerializecardbackStyle() => __pbn__cardbackStyle != null;
        public void ResetcardbackStyle() => __pbn__cardbackStyle = null;
        private string __pbn__cardbackStyle;

        [ProtoMember(5)]
        [DefaultValue("")]
        public string tablebackStyle
        {
            get { return __pbn__tablebackStyle ?? ""; }
            set { __pbn__tablebackStyle = value; }
        }
        public bool ShouldSerializetablebackStyle() => __pbn__tablebackStyle != null;
        public void ResettablebackStyle() => __pbn__tablebackStyle = null;
        private string __pbn__tablebackStyle;

    }

    [ProtoContract]
    internal partial class Reconnect : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string roomServerIp { get; set; }

        [ProtoMember(2, Name = @"port", IsRequired = true)]
        public int Port { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(5, Name = @"incode", IsRequired = true)]
        public string Incode { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int roomType { get; set; }

        [ProtoMember(8)]
        public int raceId
        {
            get { return __pbn__raceId.GetValueOrDefault(); }
            set { __pbn__raceId = value; }
        }
        public bool ShouldSerializeraceId() => __pbn__raceId != null;
        public void ResetraceId() => __pbn__raceId = null;
        private int? __pbn__raceId;

    }

    [ProtoContract]
    internal partial class PlayerToken : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public TokenType tokenType { get; set; } = TokenType.TokenChat;

        [ProtoMember(2, Name = @"token", IsRequired = true)]
        public string Token { get; set; }

        [ProtoMember(3)]
        public uint expiryTime
        {
            get { return __pbn__expiryTime.GetValueOrDefault(); }
            set { __pbn__expiryTime = value; }
        }
        public bool ShouldSerializeexpiryTime() => __pbn__expiryTime != null;
        public void ResetexpiryTime() => __pbn__expiryTime = null;
        private uint? __pbn__expiryTime;

    }

    [ProtoContract]
    internal partial class PlayerTokenRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public TokenType tokenType { get; set; } = TokenType.TokenChat;

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerTokenResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"token", IsRequired = true)]
        public PlayerToken Token { get; set; }

        [ProtoMember(2, Name = @"ip")]
        [DefaultValue("")]
        public string Ip
        {
            get { return __pbn__Ip ?? ""; }
            set { __pbn__Ip = value; }
        }
        public bool ShouldSerializeIp() => __pbn__Ip != null;
        public void ResetIp() => __pbn__Ip = null;
        private string __pbn__Ip;

        [ProtoMember(3, Name = @"port")]
        public uint Port
        {
            get { return __pbn__Port.GetValueOrDefault(); }
            set { __pbn__Port = value; }
        }
        public bool ShouldSerializePort() => __pbn__Port != null;
        public void ResetPort() => __pbn__Port = null;
        private uint? __pbn__Port;

    }

    [ProtoContract]
    internal partial class PlayerSignUpRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string phoneNumber { get; set; }

        [ProtoMember(2, Name = @"password", IsRequired = true)]
        public string Password { get; set; }

        [ProtoMember(3, Name = @"captcha", IsRequired = true)]
        public string Captcha { get; set; }

        [ProtoMember(4, Name = @"version")]
        [DefaultValue("")]
        public string Version
        {
            get { return __pbn__Version ?? ""; }
            set { __pbn__Version = value; }
        }
        public bool ShouldSerializeVersion() => __pbn__Version != null;
        public void ResetVersion() => __pbn__Version = null;
        private string __pbn__Version;

        [ProtoMember(5, IsRequired = true)]
        public string nationCode { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerSignUpResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class PlayerBindPhoneRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string phoneNumber { get; set; }

        [ProtoMember(2, Name = @"password", IsRequired = true)]
        public string Password { get; set; }

        [ProtoMember(3, Name = @"captcha", IsRequired = true)]
        public string Captcha { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public string nationCode { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerBindPhoneResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"isok", IsRequired = true)]
        public bool Isok { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerUnbindPhoneRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string phoneNumber { get; set; }

        [ProtoMember(2, Name = @"captcha", IsRequired = true)]
        public string Captcha { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerUnbindPhoneResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"isok", IsRequired = true)]
        public bool Isok { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerChangePasswordRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string phoneNumber { get; set; }

        [ProtoMember(2, Name = @"password", IsRequired = true)]
        public string Password { get; set; }

        [ProtoMember(3, Name = @"captcha", IsRequired = true)]
        public string Captcha { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string nationCode { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerChangePasswordResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"player", IsRequired = true)]
        public Player Player { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerLoginRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string accountId { get; set; }

        [ProtoMember(2, Name = @"password")]
        [DefaultValue("")]
        public string Password
        {
            get { return __pbn__Password ?? ""; }
            set { __pbn__Password = value; }
        }
        public bool ShouldSerializePassword() => __pbn__Password != null;
        public void ResetPassword() => __pbn__Password = null;
        private string __pbn__Password;

        [ProtoMember(3, Name = @"token")]
        [DefaultValue("")]
        public string Token
        {
            get { return __pbn__Token ?? ""; }
            set { __pbn__Token = value; }
        }
        public bool ShouldSerializeToken() => __pbn__Token != null;
        public void ResetToken() => __pbn__Token = null;
        private string __pbn__Token;

        [ProtoMember(4, Name = @"version")]
        [DefaultValue("")]
        public string Version
        {
            get { return __pbn__Version ?? ""; }
            set { __pbn__Version = value; }
        }
        public bool ShouldSerializeVersion() => __pbn__Version != null;
        public void ResetVersion() => __pbn__Version = null;
        private string __pbn__Version;

        [ProtoMember(5, IsRequired = true)]
        public string nationCode { get; set; }

        [ProtoMember(6, Name = @"uuid")]
        [DefaultValue("")]
        public string Uuid
        {
            get { return __pbn__Uuid ?? ""; }
            set { __pbn__Uuid = value; }
        }
        public bool ShouldSerializeUuid() => __pbn__Uuid != null;
        public void ResetUuid() => __pbn__Uuid = null;
        private string __pbn__Uuid;

        [ProtoMember(7)]
        [DefaultValue("")]
        public string clientIp
        {
            get { return __pbn__clientIp ?? ""; }
            set { __pbn__clientIp = value; }
        }
        public bool ShouldSerializeclientIp() => __pbn__clientIp != null;
        public void ResetclientIp() => __pbn__clientIp = null;
        private string __pbn__clientIp;

    }

    [ProtoContract]
    internal partial class PlayerLoginResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string sessionKey { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerConnectRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string sessionKey { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string deviceId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string deviceType { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerConnectResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"player", IsRequired = true)]
        public Player Player { get; set; }

        [ProtoMember(2)]
        [DefaultValue("")]
        public string videoServerIp
        {
            get { return __pbn__videoServerIp ?? ""; }
            set { __pbn__videoServerIp = value; }
        }
        public bool ShouldSerializevideoServerIp() => __pbn__videoServerIp != null;
        public void ResetvideoServerIp() => __pbn__videoServerIp = null;
        private string __pbn__videoServerIp;

        [ProtoMember(3)]
        public bool bandWechat
        {
            get { return __pbn__bandWechat.GetValueOrDefault(); }
            set { __pbn__bandWechat = value; }
        }
        public bool ShouldSerializebandWechat() => __pbn__bandWechat != null;
        public void ResetbandWechat() => __pbn__bandWechat = null;
        private bool? __pbn__bandWechat;

    }

    [ProtoContract]
    internal partial class PlayerWechatLoginRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"code", IsRequired = true)]
        public string Code { get; set; }

        [ProtoMember(2, Name = @"version")]
        [DefaultValue("")]
        public string Version
        {
            get { return __pbn__Version ?? ""; }
            set { __pbn__Version = value; }
        }
        public bool ShouldSerializeVersion() => __pbn__Version != null;
        public void ResetVersion() => __pbn__Version = null;
        private string __pbn__Version;

    }

    [ProtoContract]
    internal partial class PlayerWechatLoginResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"player", IsRequired = true)]
        public Player Player { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerEditRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"icon")]
        [DefaultValue("")]
        public string Icon
        {
            get { return __pbn__Icon ?? ""; }
            set { __pbn__Icon = value; }
        }
        public bool ShouldSerializeIcon() => __pbn__Icon != null;
        public void ResetIcon() => __pbn__Icon = null;
        private string __pbn__Icon;

        [ProtoMember(2, Name = @"gender")]
        public uint Gender
        {
            get { return __pbn__Gender.GetValueOrDefault(); }
            set { __pbn__Gender = value; }
        }
        public bool ShouldSerializeGender() => __pbn__Gender != null;
        public void ResetGender() => __pbn__Gender = null;
        private uint? __pbn__Gender;

        [ProtoMember(3, Name = @"name")]
        [DefaultValue("")]
        public string Name
        {
            get { return __pbn__Name ?? ""; }
            set { __pbn__Name = value; }
        }
        public bool ShouldSerializeName() => __pbn__Name != null;
        public void ResetName() => __pbn__Name = null;
        private string __pbn__Name;

        [ProtoMember(4, Name = @"signature")]
        [DefaultValue("")]
        public string Signature
        {
            get { return __pbn__Signature ?? ""; }
            set { __pbn__Signature = value; }
        }
        public bool ShouldSerializeSignature() => __pbn__Signature != null;
        public void ResetSignature() => __pbn__Signature = null;
        private string __pbn__Signature;

        [ProtoMember(5)]
        public bool isUpload
        {
            get { return __pbn__isUpload.GetValueOrDefault(); }
            set { __pbn__isUpload = value; }
        }
        public bool ShouldSerializeisUpload() => __pbn__isUpload != null;
        public void ResetisUpload() => __pbn__isUpload = null;
        private bool? __pbn__isUpload;

    }

    [ProtoContract]
    internal partial class PlayerEditResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"player", IsRequired = true)]
        public Player Player { get; set; }

        [ProtoMember(2, Name = @"modifyCost")]
        public List<ModifyPlayerInfoCost> modifyCosts { get; } = new List<ModifyPlayerInfoCost>();

        [ProtoMember(3, Name = @"nextModifyCost")]
        public List<ModifyPlayerInfoCost> nextModifyCosts { get; } = new List<ModifyPlayerInfoCost>();

    }

    [ProtoContract]
    internal partial class PlayerInfoRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public uint playerId
        {
            get { return __pbn__playerId.GetValueOrDefault(); }
            set { __pbn__playerId = value; }
        }
        public bool ShouldSerializeplayerId() => __pbn__playerId != null;
        public void ResetplayerId() => __pbn__playerId = null;
        private uint? __pbn__playerId;

    }

    [ProtoContract]
    internal partial class PlayerInfoResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"player", IsRequired = true)]
        public Player Player { get; set; }

        [ProtoMember(2, Name = @"modifyCost")]
        public List<ModifyPlayerInfoCost> modifyCosts { get; } = new List<ModifyPlayerInfoCost>();

        [ProtoMember(3, Name = @"nextModifyCost")]
        public List<ModifyPlayerInfoCost> nextModifyCosts { get; } = new List<ModifyPlayerInfoCost>();

    }

    [ProtoContract]
    internal partial class PlayerCaptchaRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string phoneNumber { get; set; }

        [ProtoMember(2, Name = @"type")]
        public int Type
        {
            get { return __pbn__Type.GetValueOrDefault(); }
            set { __pbn__Type = value; }
        }
        public bool ShouldSerializeType() => __pbn__Type != null;
        public void ResetType() => __pbn__Type = null;
        private int? __pbn__Type;

        [ProtoMember(3, Name = @"version")]
        [DefaultValue("")]
        public string Version
        {
            get { return __pbn__Version ?? ""; }
            set { __pbn__Version = value; }
        }
        public bool ShouldSerializeVersion() => __pbn__Version != null;
        public void ResetVersion() => __pbn__Version = null;
        private string __pbn__Version;

    }

    [ProtoContract]
    internal partial class PlayerCaptchaResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public uint banTime
        {
            get { return __pbn__banTime.GetValueOrDefault(); }
            set { __pbn__banTime = value; }
        }
        public bool ShouldSerializebanTime() => __pbn__banTime != null;
        public void ResetbanTime() => __pbn__banTime = null;
        private uint? __pbn__banTime;

        [ProtoMember(2, Name = @"type")]
        public int Type
        {
            get { return __pbn__Type.GetValueOrDefault(); }
            set { __pbn__Type = value; }
        }
        public bool ShouldSerializeType() => __pbn__Type != null;
        public void ResetType() => __pbn__Type = null;
        private int? __pbn__Type;

    }

    [ProtoContract]
    internal partial class PlayerDailyGold : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"gold", IsRequired = true)]
        public long Gold { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerGoldUpdate : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"gold", IsRequired = true)]
        public int Gold { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerDiamondUpdate : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"diamond", IsRequired = true)]
        public uint Diamond { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerLogoutRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class PlayerLogoutResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class getPlayerInfoRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint playerId { get; set; }

    }

    [ProtoContract]
    internal partial class getPlayerInfoResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"player", IsRequired = true)]
        public Player Player { get; set; }

    }

    [ProtoContract]
    internal partial class EveryDayRewardItemTemplate : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int itemTempId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public long itemTempCount { get; set; }

        [ProtoMember(3, Name = @"day")]
        public int Day
        {
            get { return __pbn__Day.GetValueOrDefault(); }
            set { __pbn__Day = value; }
        }
        public bool ShouldSerializeDay() => __pbn__Day != null;
        public void ResetDay() => __pbn__Day = null;
        private int? __pbn__Day;

    }

    [ProtoContract]
    internal partial class EveryDayRewardNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"templates")]
        public List<EveryDayRewardItemTemplate> Templates { get; } = new List<EveryDayRewardItemTemplate>();

        [ProtoMember(2)]
        public int totalDay
        {
            get { return __pbn__totalDay.GetValueOrDefault(); }
            set { __pbn__totalDay = value; }
        }
        public bool ShouldSerializetotalDay() => __pbn__totalDay != null;
        public void ResettotalDay() => __pbn__totalDay = null;
        private int? __pbn__totalDay;

        [ProtoMember(3)]
        public int curDay
        {
            get { return __pbn__curDay.GetValueOrDefault(); }
            set { __pbn__curDay = value; }
        }
        public bool ShouldSerializecurDay() => __pbn__curDay != null;
        public void ResetcurDay() => __pbn__curDay = null;
        private int? __pbn__curDay;

    }

    [ProtoContract]
    internal partial class PlayerMasterScoresLog : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"action", IsRequired = true)]
        public int Action { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public long actionCount { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public long actionTime { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int actionType { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public string clubId { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public string clubName { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public long curCount { get; set; }

        [ProtoMember(8, Name = @"id", IsRequired = true)]
        public long Id { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public int itemTempId { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public int propsId { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public string targetPlayerId { get; set; }

        [ProtoMember(14, IsRequired = true)]
        public string targetPlayerName { get; set; }

    }

    [ProtoContract]
    internal partial class GetPlayerMasterScoresLogRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int pageNow { get; set; }

    }

    [ProtoContract]
    internal partial class GetPlayerMasterScoresLogResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"logs")]
        public List<PlayerMasterScoresLog> Logs { get; } = new List<PlayerMasterScoresLog>();

        [ProtoMember(2, IsRequired = true)]
        public int pageNow { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int totalPage { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public bool hasPre { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public bool hasNext { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int totalCount { get; set; }

    }

    [ProtoContract]
    internal partial class SetPlayerSecondPasswordRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"phone", IsRequired = true)]
        public string Phone { get; set; }

        [ProtoMember(2, Name = @"pwd", IsRequired = true)]
        public string Pwd { get; set; }

        [ProtoMember(3, Name = @"captcha", IsRequired = true)]
        public string Captcha { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string secondPasswordNationCode { get; set; }

    }

    [ProtoContract]
    internal partial class SetPlayerSecondPasswordResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class SetPlayerPaySettingsRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"index", IsRequired = true)]
        public int Index { get; set; }

        [ProtoMember(2, Name = @"days")]
        public int Days
        {
            get { return __pbn__Days.GetValueOrDefault(); }
            set { __pbn__Days = value; }
        }
        public bool ShouldSerializeDays() => __pbn__Days != null;
        public void ResetDays() => __pbn__Days = null;
        private int? __pbn__Days;

        [ProtoMember(3, Name = @"amount")]
        public int Amount
        {
            get { return __pbn__Amount.GetValueOrDefault(); }
            set { __pbn__Amount = value; }
        }
        public bool ShouldSerializeAmount() => __pbn__Amount != null;
        public void ResetAmount() => __pbn__Amount = null;
        private int? __pbn__Amount;

    }

    [ProtoContract]
    internal partial class SetPlayerPaySettingsResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"index", IsRequired = true)]
        public int Index { get; set; }

        [ProtoMember(2, Name = @"days")]
        public int Days
        {
            get { return __pbn__Days.GetValueOrDefault(); }
            set { __pbn__Days = value; }
        }
        public bool ShouldSerializeDays() => __pbn__Days != null;
        public void ResetDays() => __pbn__Days = null;
        private int? __pbn__Days;

        [ProtoMember(3, Name = @"amount")]
        public int Amount
        {
            get { return __pbn__Amount.GetValueOrDefault(); }
            set { __pbn__Amount = value; }
        }
        public bool ShouldSerializeAmount() => __pbn__Amount != null;
        public void ResetAmount() => __pbn__Amount = null;
        private int? __pbn__Amount;

    }

    [ProtoContract]
    internal partial class NeedInputCodeResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"state", IsRequired = true)]
        public p2State State { get; set; } = p2State.Empty;

        [ProtoMember(2, IsRequired = true)]
        public string methodName { get; set; }

        [ProtoMember(3, Name = @"type", IsRequired = true)]
        public int Type { get; set; }

    }

    [ProtoContract]
    internal partial class CheckSecondPasswordPageRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string methodName { get; set; }

    }

    [ProtoContract]
    internal partial class CheckSecondPasswordResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"state", IsRequired = true)]
        public p2State State { get; set; } = p2State.Empty;

        [ProtoMember(2, IsRequired = true)]
        public string methodName { get; set; }

    }

    [ProtoContract]
    internal partial class VerifySecondPasswordRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string methodName { get; set; }

        [ProtoMember(2, Name = @"pwd", IsRequired = true)]
        public string Pwd { get; set; }

        [ProtoMember(3)]
        public int roomId
        {
            get { return __pbn__roomId.GetValueOrDefault(); }
            set { __pbn__roomId = value; }
        }
        public bool ShouldSerializeroomId() => __pbn__roomId != null;
        public void ResetroomId() => __pbn__roomId = null;
        private int? __pbn__roomId;

    }

    [ProtoContract]
    internal partial class GetPlayerSecondPasswordCaptchaRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string phoneNumber { get; set; }

        [ProtoMember(2, Name = @"type")]
        public int Type
        {
            get { return __pbn__Type.GetValueOrDefault(); }
            set { __pbn__Type = value; }
        }
        public bool ShouldSerializeType() => __pbn__Type != null;
        public void ResetType() => __pbn__Type = null;
        private int? __pbn__Type;

        [ProtoMember(3, Name = @"version")]
        [DefaultValue("")]
        public string Version
        {
            get { return __pbn__Version ?? ""; }
            set { __pbn__Version = value; }
        }
        public bool ShouldSerializeVersion() => __pbn__Version != null;
        public void ResetVersion() => __pbn__Version = null;
        private string __pbn__Version;

    }

    [ProtoContract]
    internal partial class GetPlayerSecondPasswordCaptchaResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public uint banTime
        {
            get { return __pbn__banTime.GetValueOrDefault(); }
            set { __pbn__banTime = value; }
        }
        public bool ShouldSerializebanTime() => __pbn__banTime != null;
        public void ResetbanTime() => __pbn__banTime = null;
        private uint? __pbn__banTime;

        [ProtoMember(2, Name = @"type")]
        public int Type
        {
            get { return __pbn__Type.GetValueOrDefault(); }
            set { __pbn__Type = value; }
        }
        public bool ShouldSerializeType() => __pbn__Type != null;
        public void ResetType() => __pbn__Type = null;
        private int? __pbn__Type;

    }

    [ProtoContract]
    internal partial class BandWechatRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string openId { get; set; }

    }

    [ProtoContract]
    internal partial class BandWechatResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public bool bandWechat { get; set; }

    }

    [ProtoContract]
    internal partial class VerifyDeviceLockSmsRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string methodName { get; set; }

        [ProtoMember(2, Name = @"sms", IsRequired = true)]
        public string Sms { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string deviceCode { get; set; }

    }

    [ProtoContract]
    internal partial class SetDeviceLockRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public bool lockSwitch { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string deviceCode { get; set; }

    }

    [ProtoContract]
    internal partial class SetDeviceLockResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public bool lockSwitch { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyNextRoundStartRoomResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, Name = @"sitInfo")]
        public List<SitInfo> sitInfoes { get; } = new List<SitInfo>();

        [ProtoMember(4, Name = @"pot", IsRequired = true)]
        public long Pot { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int roomType { get; set; }

        [ProtoMember(6, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(7, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

        [ProtoMember(8, DataFormat = DataFormat.ZigZag)]
        public int upBlindTime
        {
            get { return __pbn__upBlindTime.GetValueOrDefault(); }
            set { __pbn__upBlindTime = value; }
        }
        public bool ShouldSerializeupBlindTime() => __pbn__upBlindTime != null;
        public void ResetupBlindTime() => __pbn__upBlindTime = null;
        private int? __pbn__upBlindTime;

        [ProtoMember(9, DataFormat = DataFormat.ZigZag)]
        public int endTime
        {
            get { return __pbn__endTime.GetValueOrDefault(); }
            set { __pbn__endTime = value; }
        }
        public bool ShouldSerializeendTime() => __pbn__endTime != null;
        public void ResetendTime() => __pbn__endTime = null;
        private int? __pbn__endTime;

        [ProtoMember(10, Name = @"sb", IsRequired = true)]
        public long Sb { get; set; }

    }

    [ProtoContract]
    internal partial class SitInfo3 : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, Name = @"action", IsRequired = true)]
        public int Action { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long actionTime { get; set; }

        [ProtoMember(5, Name = @"bet", IsRequired = true)]
        public long Bet { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public bool isDealer { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public bool isSB { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public bool isBB { get; set; }

        [ProtoMember(9, Name = @"bankroll", IsRequired = true)]
        public long Bankroll { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public long needCall { get; set; }

        [ProtoMember(11, Name = @"state", IsRequired = true)]
        public int State { get; set; }

        [ProtoMember(12, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

        [ProtoMember(13, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

        [ProtoMember(14, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(15, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(16, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(17, Name = @"managed", IsRequired = true)]
        public bool Managed { get; set; }

        [ProtoMember(18)]
        public bool isStraddle
        {
            get { return __pbn__isStraddle.GetValueOrDefault(); }
            set { __pbn__isStraddle = value; }
        }
        public bool ShouldSerializeisStraddle() => __pbn__isStraddle != null;
        public void ResetisStraddle() => __pbn__isStraddle = null;
        private bool? __pbn__isStraddle;

        [ProtoMember(19, Name = @"isforce")]
        public bool Isforce
        {
            get { return __pbn__Isforce.GetValueOrDefault(); }
            set { __pbn__Isforce = value; }
        }
        public bool ShouldSerializeIsforce() => __pbn__Isforce != null;
        public void ResetIsforce() => __pbn__Isforce = null;
        private bool? __pbn__Isforce;

        [ProtoMember(20, IsRequired = true)]
        public int takeMascot { get; set; }

        [ProtoMember(21)]
        public int sngOverRank
        {
            get { return __pbn__sngOverRank.GetValueOrDefault(); }
            set { __pbn__sngOverRank = value; }
        }
        public bool ShouldSerializesngOverRank() => __pbn__sngOverRank != null;
        public void ResetsngOverRank() => __pbn__sngOverRank = null;
        private int? __pbn__sngOverRank;

        [ProtoMember(22)]
        public int suspicionTag
        {
            get { return __pbn__suspicionTag.GetValueOrDefault(); }
            set { __pbn__suspicionTag = value; }
        }
        public bool ShouldSerializesuspicionTag() => __pbn__suspicionTag != null;
        public void ResetsuspicionTag() => __pbn__suspicionTag = null;
        private int? __pbn__suspicionTag;

        [ProtoMember(23)]
        public int aGroupOfTag
        {
            get { return __pbn__aGroupOfTag.GetValueOrDefault(); }
            set { __pbn__aGroupOfTag = value; }
        }
        public bool ShouldSerializeaGroupOfTag() => __pbn__aGroupOfTag != null;
        public void ResetaGroupOfTag() => __pbn__aGroupOfTag = null;
        private int? __pbn__aGroupOfTag;

        [ProtoMember(24, Name = @"endaction", IsRequired = true)]
        public int Endaction { get; set; }

        [ProtoMember(25)]
        public int keepSitRestTime
        {
            get { return __pbn__keepSitRestTime.GetValueOrDefault(); }
            set { __pbn__keepSitRestTime = value; }
        }
        public bool ShouldSerializekeepSitRestTime() => __pbn__keepSitRestTime != null;
        public void ResetkeepSitRestTime() => __pbn__keepSitRestTime = null;
        private int? __pbn__keepSitRestTime;

    }

    [ProtoContract]
    internal partial class StartCommonGameRoomResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, Name = @"sitInfo")]
        public List<SitInfo> sitInfoes { get; } = new List<SitInfo>();

        [ProtoMember(4, IsRequired = true)]
        public int roomType { get; set; }

        [ProtoMember(5, Name = @"pot", IsRequired = true)]
        public long Pot { get; set; }

        [ProtoMember(6, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

        [ProtoMember(7, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(8, DataFormat = DataFormat.ZigZag)]
        public int upBlindTime
        {
            get { return __pbn__upBlindTime.GetValueOrDefault(); }
            set { __pbn__upBlindTime = value; }
        }
        public bool ShouldSerializeupBlindTime() => __pbn__upBlindTime != null;
        public void ResetupBlindTime() => __pbn__upBlindTime = null;
        private int? __pbn__upBlindTime;

        [ProtoMember(9, DataFormat = DataFormat.ZigZag)]
        public int endTime
        {
            get { return __pbn__endTime.GetValueOrDefault(); }
            set { __pbn__endTime = value; }
        }
        public bool ShouldSerializeendTime() => __pbn__endTime != null;
        public void ResetendTime() => __pbn__endTime = null;
        private int? __pbn__endTime;

        [ProtoMember(10, Name = @"sb", IsRequired = true)]
        public long Sb { get; set; }

    }

    [ProtoContract]
    internal partial class LoginRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string playerPassword { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string playerName { get; set; }

    }

    [ProtoContract]
    internal partial class LoginResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public int Id { get; set; }

        [ProtoMember(2, Name = @"gold", IsRequired = true)]
        public long Gold { get; set; }

        [ProtoMember(3, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string playerPassword { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(6)]
        public RoomInfos roomInfos { get; set; }

    }

    [ProtoContract]
    internal partial class RoomInfos : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"roomInfo")]
        public List<RoomInfo> roomInfoes { get; } = new List<RoomInfo>();

    }

    [ProtoContract]
    internal partial class RoomInfo : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int serverId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string invitationCode { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(5, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int playerCountLimit { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int inGamePlayerCount { get; set; }

    }

    [ProtoContract]
    internal partial class CreatePokerRoomRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomType { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(3, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(4, Name = @"bankroll", IsRequired = true)]
        public long Bankroll { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int joinPlayerCount { get; set; }

        [ProtoMember(6, Name = @"time", IsRequired = true)]
        public int Time { get; set; }

        [ProtoMember(7, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

        [ProtoMember(8, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int thinkTime { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public int applyItemTemplateId { get; set; }

        [ProtoMember(11, Name = @"insurance")]
        public int Insurance
        {
            get { return __pbn__Insurance.GetValueOrDefault(); }
            set { __pbn__Insurance = value; }
        }
        public bool ShouldSerializeInsurance() => __pbn__Insurance != null;
        public void ResetInsurance() => __pbn__Insurance = null;
        private int? __pbn__Insurance;

        [ProtoMember(12, Name = @"straddle")]
        public int Straddle
        {
            get { return __pbn__Straddle.GetValueOrDefault(); }
            set { __pbn__Straddle = value; }
        }
        public bool ShouldSerializeStraddle() => __pbn__Straddle != null;
        public void ResetStraddle() => __pbn__Straddle = null;
        private int? __pbn__Straddle;

        [ProtoMember(13)]
        public int minOnTableTime
        {
            get { return __pbn__minOnTableTime.GetValueOrDefault(); }
            set { __pbn__minOnTableTime = value; }
        }
        public bool ShouldSerializeminOnTableTime() => __pbn__minOnTableTime != null;
        public void ResetminOnTableTime() => __pbn__minOnTableTime = null;
        private int? __pbn__minOnTableTime;

        [ProtoMember(14, IsRequired = true)]
        public int playType { get; set; }

    }

    [ProtoContract]
    internal partial class CreateSNGPokerRoomRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public long applyCost { get; set; }

        [ProtoMember(2, Name = @"surcharge", IsRequired = true)]
        public long Surcharge { get; set; }

        [ProtoMember(3, Name = @"bankroll", IsRequired = true)]
        public long Bankroll { get; set; }

        [ProtoMember(4, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int upBlindTime { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int joinPlayerCount { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int applyItemTemplateId { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public int playType { get; set; }

    }

    [ProtoContract]
    internal partial class NotifySngStartBegin : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"countdown", IsRequired = true)]
        public int Countdown { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class CreatePokerRoomResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, Name = @"ip", IsRequired = true)]
        public string Ip { get; set; }

        [ProtoMember(3, Name = @"port", IsRequired = true)]
        public int Port { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int roomType { get; set; }

        [ProtoMember(6, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int actionTime { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int playType { get; set; }

    }

    [ProtoContract]
    internal partial class ConnectRoomServerRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string invitationCode { get; set; }

        [ProtoMember(2)]
        public int roomId
        {
            get { return __pbn__roomId.GetValueOrDefault(); }
            set { __pbn__roomId = value; }
        }
        public bool ShouldSerializeroomId() => __pbn__roomId != null;
        public void ResetroomId() => __pbn__roomId = null;
        private int? __pbn__roomId;

    }

    [ProtoContract]
    internal partial class ConnectRoomServerResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, Name = @"ip", IsRequired = true)]
        public string Ip { get; set; }

        [ProtoMember(3, Name = @"port", IsRequired = true)]
        public int Port { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string invitationCode { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int roomType { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int playType { get; set; }

    }

    [ProtoContract]
    internal partial class HeartbeatRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class HeartbeatResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"heart", IsRequired = true)]
        public bool Heart { get; set; }

        [ProtoMember(2, Name = @"timestamp", IsRequired = true)]
        public long Timestamp { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyDestroyRoom : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

    }

    [ProtoContract]
    internal partial class JoinRoomRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string invitationCode { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string sessionKey { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int joinGameClubId { get; set; }

    }

    [ProtoContract]
    internal partial class JoinRoomResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string invitationCode { get; set; }

        [ProtoMember(3, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(4, Name = @"pot", IsRequired = true)]
        public long Pot { get; set; }

        [ProtoMember(5, Name = @"sitInfo")]
        public List<SitInfo> sitInfoes { get; } = new List<SitInfo>();

        [ProtoMember(6, IsRequired = true)]
        public int roomType { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int createrId { get; set; }

        [ProtoMember(8, Name = @"name", IsRequired = true)]
        public string Name { get; set; }

        [ProtoMember(9, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

        [ProtoMember(10, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int endTime { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public int actionTime { get; set; }

        [ProtoMember(12)]
        public PubCard pubCard { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(14, IsRequired = true)]
        public int bankrollType { get; set; }

        [ProtoMember(15, IsRequired = true)]
        public int addThinkTime { get; set; }

        [ProtoMember(16, IsRequired = true)]
        public int addThinkTimeCostItemId { get; set; }

        [ProtoMember(17, IsRequired = true)]
        public int addThinkTimeCostCount { get; set; }

        [ProtoMember(18, IsRequired = true)]
        public int insuranceTarget { get; set; }

        [ProtoMember(19, IsRequired = true)]
        public int straddleTarget { get; set; }

        [ProtoMember(20, IsRequired = true)]
        public int gpsIpTarget { get; set; }

        [ProtoMember(21, Name = @"sb", IsRequired = true)]
        public long Sb { get; set; }

        [ProtoMember(22, IsRequired = true)]
        public int joinGameClubId { get; set; }

        [ProtoMember(23, Name = @"play", IsRequired = true)]
        public bool Play { get; set; }

        [ProtoMember(24)]
        [DefaultValue("")]
        public string clubName
        {
            get { return __pbn__clubName ?? ""; }
            set { __pbn__clubName = value; }
        }
        public bool ShouldSerializeclubName() => __pbn__clubName != null;
        public void ResetclubName() => __pbn__clubName = null;
        private string __pbn__clubName;

        [ProtoMember(25)]
        public int clubTableNO
        {
            get { return __pbn__clubTableNO.GetValueOrDefault(); }
            set { __pbn__clubTableNO = value; }
        }
        public bool ShouldSerializeclubTableNO() => __pbn__clubTableNO != null;
        public void ResetclubTableNO() => __pbn__clubTableNO = null;
        private int? __pbn__clubTableNO;

        [ProtoMember(26, IsRequired = true)]
        public int playType { get; set; }

        [ProtoMember(27, IsRequired = true)]
        public int raiseLimitFixed { get; set; }

        [ProtoMember(28, IsRequired = true)]
        public string raiseLimitPot { get; set; }

        [ProtoMember(29, Name = @"pots")]
        public Pots Pots { get; set; }

        [ProtoMember(30)]
        public int clubRoom
        {
            get { return __pbn__clubRoom.GetValueOrDefault(); }
            set { __pbn__clubRoom = value; }
        }
        public bool ShouldSerializeclubRoom() => __pbn__clubRoom != null;
        public void ResetclubRoom() => __pbn__clubRoom = null;
        private int? __pbn__clubRoom;

        [ProtoMember(31)]
        [DefaultValue("")]
        public string clubInviteCode
        {
            get { return __pbn__clubInviteCode ?? ""; }
            set { __pbn__clubInviteCode = value; }
        }
        public bool ShouldSerializeclubInviteCode() => __pbn__clubInviteCode != null;
        public void ResetclubInviteCode() => __pbn__clubInviteCode = null;
        private string __pbn__clubInviteCode;

        [ProtoMember(32)]
        public bool canStart
        {
            get { return __pbn__canStart.GetValueOrDefault(); }
            set { __pbn__canStart = value; }
        }
        public bool ShouldSerializecanStart() => __pbn__canStart != null;
        public void ResetcanStart() => __pbn__canStart = null;
        private bool? __pbn__canStart;

        [ProtoMember(33)]
        public bool canOver
        {
            get { return __pbn__canOver.GetValueOrDefault(); }
            set { __pbn__canOver = value; }
        }
        public bool ShouldSerializecanOver() => __pbn__canOver != null;
        public void ResetcanOver() => __pbn__canOver = null;
        private bool? __pbn__canOver;

        [ProtoMember(34, Name = @"item")]
        public List<PublicCardCostItem> Items { get; } = new List<PublicCardCostItem>();

        [ProtoMember(35, IsRequired = true)]
        public int canBringOut { get; set; }

        [ProtoMember(36, IsRequired = true)]
        public float minKeepMultiple { get; set; }

        [ProtoMember(37, IsRequired = true)]
        public float bringOutMultiple { get; set; }

    }

    [ProtoContract]
    internal partial class JoinSNGRoomRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string invitationCode { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string sessionKey { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class JoinSNGRoomResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string invitationCode { get; set; }

        [ProtoMember(3, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(4, Name = @"pot", IsRequired = true)]
        public long Pot { get; set; }

        [ProtoMember(5, Name = @"sitInfo")]
        public List<SitInfo> sitInfoes { get; } = new List<SitInfo>();

        [ProtoMember(6, IsRequired = true)]
        public int roomType { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int createrId { get; set; }

        [ProtoMember(8, Name = @"name", IsRequired = true)]
        public string Name { get; set; }

        [ProtoMember(9, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

        [ProtoMember(10, Name = @"upbinld", DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int Upbinld { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public int actionTime { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(13, Name = @"sb", IsRequired = true)]
        public long Sb { get; set; }

        [ProtoMember(14, IsRequired = true)]
        public int curBlindRestTime { get; set; }

        [ProtoMember(15)]
        public PubCard pubCard { get; set; }

        [ProtoMember(16, IsRequired = true)]
        public bool isStart { get; set; }

        [ProtoMember(17, IsRequired = true)]
        public int playType { get; set; }

        [ProtoMember(18, IsRequired = true)]
        public int raiseLimitFixed { get; set; }

        [ProtoMember(19, IsRequired = true)]
        public string raiseLimitPot { get; set; }

        [ProtoMember(20, Name = @"pots")]
        public Pots Pots { get; set; }

        [ProtoMember(21, Name = @"item")]
        public List<PublicCardCostItem> Items { get; } = new List<PublicCardCostItem>();

    }

    [ProtoContract]
    internal partial class SitDownRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(4)]
        public int clubId
        {
            get { return __pbn__clubId.GetValueOrDefault(); }
            set { __pbn__clubId = value; }
        }
        public bool ShouldSerializeclubId() => __pbn__clubId != null;
        public void ResetclubId() => __pbn__clubId = null;
        private int? __pbn__clubId;

        [ProtoMember(5, Name = @"gps", IsRequired = true)]
        public string Gps { get; set; }

        [ProtoMember(6)]
        [DefaultValue("")]
        public string clientIp
        {
            get { return __pbn__clientIp ?? ""; }
            set { __pbn__clientIp = value; }
        }
        public bool ShouldSerializeclientIp() => __pbn__clientIp != null;
        public void ResetclientIp() => __pbn__clientIp = null;
        private string __pbn__clientIp;

    }

    [ProtoContract]
    internal partial class SitDownResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public SitInfo sitInfo { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class Cards : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public List<Card> card { get; } = new List<Card>();

    }

    [ProtoContract]
    internal partial class StandUpRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class AdvanceLeaveTableRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class AdvanceLeaveTableResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int playerId { get; set; }

    }

    [ProtoContract]
    internal partial class StandUpResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(4, Name = @"allow", IsRequired = true)]
        public bool Allow { get; set; }

        [ProtoMember(5, Name = @"advleavn", IsRequired = true)]
        public bool Advleavn { get; set; }

    }

    [ProtoContract]
    internal partial class OutRoomRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2)]
        public int gameId
        {
            get { return __pbn__gameId.GetValueOrDefault(); }
            set { __pbn__gameId = value; }
        }
        public bool ShouldSerializegameId() => __pbn__gameId != null;
        public void ResetgameId() => __pbn__gameId = null;
        private int? __pbn__gameId;

        [ProtoMember(3, DataFormat = DataFormat.ZigZag)]
        public int sitId
        {
            get { return __pbn__sitId.GetValueOrDefault(); }
            set { __pbn__sitId = value; }
        }
        public bool ShouldSerializesitId() => __pbn__sitId != null;
        public void ResetsitId() => __pbn__sitId = null;
        private int? __pbn__sitId;

    }

    [ProtoContract]
    internal partial class OutRoomResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(4, Name = @"allow", IsRequired = true)]
        public bool Allow { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int roomId { get; set; }

    }

    [ProtoContract]
    internal partial class OutSngRoomRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

    }

    [ProtoContract]
    internal partial class OutSngRoomResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"trusteeship", IsRequired = true)]
        public bool Trusteeship { get; set; }

        [ProtoMember(2)]
        public int sitId
        {
            get { return __pbn__sitId.GetValueOrDefault(); }
            set { __pbn__sitId = value; }
        }
        public bool ShouldSerializesitId() => __pbn__sitId != null;
        public void ResetsitId() => __pbn__sitId = null;
        private int? __pbn__sitId;

        [ProtoMember(3, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(4)]
        public int gameId
        {
            get { return __pbn__gameId.GetValueOrDefault(); }
            set { __pbn__gameId = value; }
        }
        public bool ShouldSerializegameId() => __pbn__gameId != null;
        public void ResetgameId() => __pbn__gameId = null;
        private int? __pbn__gameId;

    }

    [ProtoContract]
    internal partial class SngOverRankResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(2, Name = @"rank", IsRequired = true)]
        public int Rank { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(5, Name = @"reward", IsRequired = true)]
        public string Reward { get; set; }

    }

    [ProtoContract]
    internal partial class StartCommonGameRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyUpBlindResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(2, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int blindRank { get; set; }

        [ProtoMember(6, Name = @"sb", IsRequired = true)]
        public long Sb { get; set; }

    }

    [ProtoContract]
    internal partial class StartCommonGameResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"card")]
        public List<Card> Cards { get; } = new List<Card>();

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(5, Name = @"sitInfo")]
        public List<SitInfo> sitInfoes { get; } = new List<SitInfo>();

        [ProtoMember(6, Name = @"pot", IsRequired = true)]
        public long Pot { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public long highChip { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public HandPowerEnum handPowerEnum { get; set; }

        [ProtoMember(10, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public int endTime { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public long baseRaise { get; set; }

    }

    [ProtoContract]
    internal partial class StartSNGGameResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"card")]
        public List<Card> Cards { get; } = new List<Card>();

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(5, Name = @"sitInfo")]
        public List<SitInfo> sitInfoes { get; } = new List<SitInfo>();

        [ProtoMember(6, Name = @"pot", IsRequired = true)]
        public int Pot { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int highChip { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public HandPowerEnum handPowerEnum { get; set; }

        [ProtoMember(10, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public int upBlindTime { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public long baseRaise { get; set; }

    }

    [ProtoContract]
    internal partial class Card : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string cardSuit { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int cardNumber { get; set; }

        [ProtoMember(3, Name = @"tag")]
        public int Tag
        {
            get { return __pbn__Tag.GetValueOrDefault(); }
            set { __pbn__Tag = value; }
        }
        public bool ShouldSerializeTag() => __pbn__Tag != null;
        public void ResetTag() => __pbn__Tag = null;
        private int? __pbn__Tag;

        [ProtoMember(4, Name = @"ctype")]
        public int Ctype
        {
            get { return __pbn__Ctype.GetValueOrDefault(); }
            set { __pbn__Ctype = value; }
        }
        public bool ShouldSerializeCtype() => __pbn__Ctype != null;
        public void ResetCtype() => __pbn__Ctype = null;
        private int? __pbn__Ctype;

    }

    [ProtoContract]
    internal partial class SitInfo : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, Name = @"action", IsRequired = true)]
        public int Action { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long actionTime { get; set; }

        [ProtoMember(5, Name = @"bet", IsRequired = true)]
        public long Bet { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public bool isDealer { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public bool isSB { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public bool isBB { get; set; }

        [ProtoMember(9, Name = @"bankroll", IsRequired = true)]
        public long Bankroll { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public long needCall { get; set; }

        [ProtoMember(11, Name = @"state", IsRequired = true)]
        public int State { get; set; }

        [ProtoMember(12, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

        [ProtoMember(13, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

        [ProtoMember(14, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(15, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(16, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(17, Name = @"managed", IsRequired = true)]
        public bool Managed { get; set; }

        [ProtoMember(18)]
        public bool isStraddle
        {
            get { return __pbn__isStraddle.GetValueOrDefault(); }
            set { __pbn__isStraddle = value; }
        }
        public bool ShouldSerializeisStraddle() => __pbn__isStraddle != null;
        public void ResetisStraddle() => __pbn__isStraddle = null;
        private bool? __pbn__isStraddle;

        [ProtoMember(19, Name = @"isforce")]
        public bool Isforce
        {
            get { return __pbn__Isforce.GetValueOrDefault(); }
            set { __pbn__Isforce = value; }
        }
        public bool ShouldSerializeIsforce() => __pbn__Isforce != null;
        public void ResetIsforce() => __pbn__Isforce = null;
        private bool? __pbn__Isforce;

        [ProtoMember(20, IsRequired = true)]
        public int takeMascot { get; set; }

        [ProtoMember(21)]
        public int sngOverRank
        {
            get { return __pbn__sngOverRank.GetValueOrDefault(); }
            set { __pbn__sngOverRank = value; }
        }
        public bool ShouldSerializesngOverRank() => __pbn__sngOverRank != null;
        public void ResetsngOverRank() => __pbn__sngOverRank = null;
        private int? __pbn__sngOverRank;

        [ProtoMember(22)]
        public int suspicionTag
        {
            get { return __pbn__suspicionTag.GetValueOrDefault(); }
            set { __pbn__suspicionTag = value; }
        }
        public bool ShouldSerializesuspicionTag() => __pbn__suspicionTag != null;
        public void ResetsuspicionTag() => __pbn__suspicionTag = null;
        private int? __pbn__suspicionTag;

        [ProtoMember(23)]
        public int aGroupOfTag
        {
            get { return __pbn__aGroupOfTag.GetValueOrDefault(); }
            set { __pbn__aGroupOfTag = value; }
        }
        public bool ShouldSerializeaGroupOfTag() => __pbn__aGroupOfTag != null;
        public void ResetaGroupOfTag() => __pbn__aGroupOfTag = null;
        private int? __pbn__aGroupOfTag;

        [ProtoMember(24, Name = @"endaction", IsRequired = true)]
        public int Endaction { get; set; }

        [ProtoMember(25)]
        public int keepSitRestTime
        {
            get { return __pbn__keepSitRestTime.GetValueOrDefault(); }
            set { __pbn__keepSitRestTime = value; }
        }
        public bool ShouldSerializekeepSitRestTime() => __pbn__keepSitRestTime != null;
        public void ResetkeepSitRestTime() => __pbn__keepSitRestTime = null;
        private int? __pbn__keepSitRestTime;

    }

    [ProtoContract]
    internal partial class PlayerCallRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerCallResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, Name = @"pot", IsRequired = true)]
        public long Pot { get; set; }

        [ProtoMember(4)]
        public ActionPlayerInfo actionPlayerInfo { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public DoPlayerCallResponse doPlayerCallResponse { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public long highChip { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public long baseRaise { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyFlopRoundResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, Name = @"card")]
        public List<Card> Cards { get; } = new List<Card>();

        [ProtoMember(4, Name = @"pot", IsRequired = true)]
        public long Pot { get; set; }

        [ProtoMember(5)]
        public ActionPlayerInfo actionPlayerInfo { get; set; }

        [ProtoMember(6)]
        public DoPlayerCallResponse doPlayerCallResponse { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int gameBettingState { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public long highChip { get; set; }

        [ProtoMember(9)]
        public HandPowerEnum handPowerEnum { get; set; }

        [ProtoMember(10, Name = @"pots")]
        public List<Pot> Pots { get; } = new List<Pot>();

        [ProtoMember(11, IsRequired = true)]
        public long baseRaise { get; set; }

        [ProtoMember(12)]
        public List<Card> bestHoleCards { get; } = new List<Card>();

    }

    [ProtoContract]
    internal partial class DoPlayerResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(3, Name = @"action", IsRequired = true)]
        public int Action { get; set; }

        [ProtoMember(4, Name = @"bankroll", IsRequired = true)]
        public long Bankroll { get; set; }

        [ProtoMember(5, Name = @"bet")]
        public long Bet
        {
            get { return __pbn__Bet.GetValueOrDefault(); }
            set { __pbn__Bet = value; }
        }
        public bool ShouldSerializeBet() => __pbn__Bet != null;
        public void ResetBet() => __pbn__Bet = null;
        private long? __pbn__Bet;

    }

    [ProtoContract]
    internal partial class ActionPlayerInfo : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, Name = @"action", IsRequired = true)]
        public int Action { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long actionTime { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public long needCall { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerFoldRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerFoldResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, Name = @"pot", IsRequired = true)]
        public long Pot { get; set; }

        [ProtoMember(4)]
        public ActionPlayerInfo actionPlayerInfo { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public DoPlayerFoldResponse doPlayerFoldResponse { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public long highChip { get; set; }

        [ProtoMember(7, Name = @"isfold", IsRequired = true)]
        public int Isfold { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public long baseRaise { get; set; }

    }

    [ProtoContract]
    internal partial class DoPlayerFoldResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(3, Name = @"action", IsRequired = true)]
        public int Action { get; set; }

        [ProtoMember(4, Name = @"bankroll", IsRequired = true)]
        public long Bankroll { get; set; }

        [ProtoMember(5, Name = @"bet")]
        public long Bet
        {
            get { return __pbn__Bet.GetValueOrDefault(); }
            set { __pbn__Bet = value; }
        }
        public bool ShouldSerializeBet() => __pbn__Bet != null;
        public void ResetBet() => __pbn__Bet = null;
        private long? __pbn__Bet;

    }

    [ProtoContract]
    internal partial class PlayerCheckRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerCheckResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, Name = @"pot", IsRequired = true)]
        public long Pot { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public ActionPlayerInfo actionPlayerInfo { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public DoPlayerCheckResponse doPlayerCheckResponse { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public long highChip { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public long baseRaise { get; set; }

    }

    [ProtoContract]
    internal partial class DoPlayerCheckResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(3, Name = @"action", IsRequired = true)]
        public int Action { get; set; }

        [ProtoMember(4, Name = @"bankroll", IsRequired = true)]
        public long Bankroll { get; set; }

        [ProtoMember(5, Name = @"bet")]
        public long Bet
        {
            get { return __pbn__Bet.GetValueOrDefault(); }
            set { __pbn__Bet = value; }
        }
        public bool ShouldSerializeBet() => __pbn__Bet != null;
        public void ResetBet() => __pbn__Bet = null;
        private long? __pbn__Bet;

    }

    [ProtoContract]
    internal partial class PlayerRaiseRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long betGold { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerRaiseResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, Name = @"pot", IsRequired = true)]
        public long Pot { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public ActionPlayerInfo actionPlayerInfo { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public DoPlayerRaiseResponse doPlayerRaiseResponse { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public long highChip { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public long baseRaise { get; set; }

    }

    [ProtoContract]
    internal partial class DoPlayerRaiseResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(3, Name = @"action", IsRequired = true)]
        public int Action { get; set; }

        [ProtoMember(4, Name = @"bankroll", IsRequired = true)]
        public long Bankroll { get; set; }

        [ProtoMember(5, Name = @"bet")]
        public long Bet
        {
            get { return __pbn__Bet.GetValueOrDefault(); }
            set { __pbn__Bet = value; }
        }
        public bool ShouldSerializeBet() => __pbn__Bet != null;
        public void ResetBet() => __pbn__Bet = null;
        private long? __pbn__Bet;

    }

    [ProtoContract]
    internal partial class PlayerAllInRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerAllInResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, Name = @"pot", IsRequired = true)]
        public long Pot { get; set; }

        [ProtoMember(4)]
        public ActionPlayerInfo actionPlayerInfo { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public DoPlayerAllInResponse doPlayerAllInResponse { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public long highChip { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public long baseRaise { get; set; }

    }

    [ProtoContract]
    internal partial class DoPlayerAllInResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(3, Name = @"action", IsRequired = true)]
        public int Action { get; set; }

        [ProtoMember(4, Name = @"bankroll", IsRequired = true)]
        public long Bankroll { get; set; }

        [ProtoMember(5, Name = @"bet")]
        public long Bet
        {
            get { return __pbn__Bet.GetValueOrDefault(); }
            set { __pbn__Bet = value; }
        }
        public bool ShouldSerializeBet() => __pbn__Bet != null;
        public void ResetBet() => __pbn__Bet = null;
        private long? __pbn__Bet;

    }

    [ProtoContract]
    internal partial class PlayerReBuyRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, Name = @"multiple", IsRequired = true)]
        public int Multiple { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int buyType { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public long buyInChip { get; set; }

        [ProtoMember(7)]
        public int clubId
        {
            get { return __pbn__clubId.GetValueOrDefault(); }
            set { __pbn__clubId = value; }
        }
        public bool ShouldSerializeclubId() => __pbn__clubId != null;
        public void ResetclubId() => __pbn__clubId = null;
        private int? __pbn__clubId;

        [ProtoMember(8)]
        public int serviceTemplateId
        {
            get { return __pbn__serviceTemplateId.GetValueOrDefault(); }
            set { __pbn__serviceTemplateId = value; }
        }
        public bool ShouldSerializeserviceTemplateId() => __pbn__serviceTemplateId != null;
        public void ResetserviceTemplateId() => __pbn__serviceTemplateId = null;
        private int? __pbn__serviceTemplateId;

        [ProtoMember(9)]
        public int serviceCount
        {
            get { return __pbn__serviceCount.GetValueOrDefault(); }
            set { __pbn__serviceCount = value; }
        }
        public bool ShouldSerializeserviceCount() => __pbn__serviceCount != null;
        public void ResetserviceCount() => __pbn__serviceCount = null;
        private int? __pbn__serviceCount;

    }

    [ProtoContract]
    internal partial class NotifyPlayerReBuyResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(4, Name = @"rebuy", IsRequired = true)]
        public long Rebuy { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int playerId { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerUnReBuyRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyGainsResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, Name = @"pots")]
        public List<Pot> Pots { get; } = new List<Pot>();

        [ProtoMember(4, Name = @"playerGainsInfo")]
        public List<PlayerGainsInfo> playerGainsInfoes { get; } = new List<PlayerGainsInfo>();

        [ProtoMember(7, IsRequired = true)]
        public bool isRiverShowDown { get; set; }

        [ProtoMember(8)]
        public PubCard pubCard { get; set; }

        [ProtoMember(9)]
        public DoPlayerCallResponse doPlayerCallResponse { get; set; }

    }

    [ProtoContract]
    internal partial class PlayerGainsInfo : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public HandCard handCard { get; set; }

        [ProtoMember(2)]
        public HandPower handPower { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(4, Name = @"bankroll", IsRequired = true)]
        public long Bankroll { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(6, Name = @"gains", IsRequired = true)]
        public long Gains { get; set; }

        [ProtoMember(7)]
        public HandCard bestHandCard { get; set; }

    }

    [ProtoContract]
    internal partial class HandPower : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(9, IsRequired = true)]
        public HandPowerEnum handPowerEnum { get; set; }

        [ProtoMember(2, Name = @"cards")]
        public int[] Cards { get; set; }

    }

    [ProtoContract]
    internal partial class PubCard : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"card")]
        public List<Card> Cards { get; } = new List<Card>();

    }

    [ProtoContract]
    internal partial class HandCard : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"card")]
        public List<Card> Cards { get; } = new List<Card>();

    }

    [ProtoContract]
    internal partial class NotifyNextRoundStartResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"card")]
        public List<Card> Cards { get; } = new List<Card>();

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(5, Name = @"sitInfo")]
        public List<SitInfo> sitInfoes { get; } = new List<SitInfo>();

        [ProtoMember(6, Name = @"pot", IsRequired = true)]
        public long Pot { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public long highChip { get; set; }

        [ProtoMember(8)]
        public HandPowerEnum handPowerEnum { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public long baseRaise { get; set; }

        [ProtoMember(10, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(11, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

        [ProtoMember(12, DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int upBlindTime { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public int endTime { get; set; }

        [ProtoMember(14, Name = @"sb", IsRequired = true)]
        public long Sb { get; set; }

        [ProtoMember(15)]
        public int handCount
        {
            get { return __pbn__handCount.GetValueOrDefault(); }
            set { __pbn__handCount = value; }
        }
        public bool ShouldSerializehandCount() => __pbn__handCount != null;
        public void ResethandCount() => __pbn__handCount = null;
        private int? __pbn__handCount;

    }

    [ProtoContract]
    internal partial class NotifyReBuyResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(4, Name = @"rebuy", IsRequired = true)]
        public long Rebuy { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(6, Name = @"multiple", IsRequired = true)]
        public int Multiple { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int dobuyType { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int itemTemplateId { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public long baseBankRoll { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public long playerBankRoll { get; set; }

        [ProtoMember(11)]
        public int clubCreditScore
        {
            get { return __pbn__clubCreditScore.GetValueOrDefault(); }
            set { __pbn__clubCreditScore = value; }
        }
        public bool ShouldSerializeclubCreditScore() => __pbn__clubCreditScore != null;
        public void ResetclubCreditScore() => __pbn__clubCreditScore = null;
        private int? __pbn__clubCreditScore;

        [ProtoMember(12)]
        public int serviceTemplateId
        {
            get { return __pbn__serviceTemplateId.GetValueOrDefault(); }
            set { __pbn__serviceTemplateId = value; }
        }
        public bool ShouldSerializeserviceTemplateId() => __pbn__serviceTemplateId != null;
        public void ResetserviceTemplateId() => __pbn__serviceTemplateId = null;
        private int? __pbn__serviceTemplateId;

        [ProtoMember(13)]
        [DefaultValue("")]
        public string servicePercentage
        {
            get { return __pbn__servicePercentage ?? ""; }
            set { __pbn__servicePercentage = value; }
        }
        public bool ShouldSerializeservicePercentage() => __pbn__servicePercentage != null;
        public void ResetservicePercentage() => __pbn__servicePercentage = null;
        private string __pbn__servicePercentage;

        [ProtoMember(14)]
        public int serviceCount
        {
            get { return __pbn__serviceCount.GetValueOrDefault(); }
            set { __pbn__serviceCount = value; }
        }
        public bool ShouldSerializeserviceCount() => __pbn__serviceCount != null;
        public void ResetserviceCount() => __pbn__serviceCount = null;
        private int? __pbn__serviceCount;

        [ProtoMember(15)]
        public int minOnTableTime
        {
            get { return __pbn__minOnTableTime.GetValueOrDefault(); }
            set { __pbn__minOnTableTime = value; }
        }
        public bool ShouldSerializeminOnTableTime() => __pbn__minOnTableTime != null;
        public void ResetminOnTableTime() => __pbn__minOnTableTime = null;
        private int? __pbn__minOnTableTime;

        [ProtoMember(16, IsRequired = true)]
        public int thinkTime { get; set; }

    }

    [ProtoContract]
    internal partial class ScorecardRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3)]
        public int clubId
        {
            get { return __pbn__clubId.GetValueOrDefault(); }
            set { __pbn__clubId = value; }
        }
        public bool ShouldSerializeclubId() => __pbn__clubId != null;
        public void ResetclubId() => __pbn__clubId = null;
        private int? __pbn__clubId;

    }

    [ProtoContract]
    internal partial class NotifyGameStopResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class HandPowerEnum : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        [DefaultValue(HandPowerTypes.HighCard)]
        public HandPowerTypes handPowerTypes
        {
            get { return __pbn__handPowerTypes ?? HandPowerTypes.HighCard; }
            set { __pbn__handPowerTypes = value; }
        }
        public bool ShouldSerializehandPowerTypes() => __pbn__handPowerTypes != null;
        public void ResethandPowerTypes() => __pbn__handPowerTypes = null;
        private HandPowerTypes? __pbn__handPowerTypes;

        [ProtoContract]
        internal enum HandPowerTypes
        {
            [ProtoEnum(Name = @"HIGH_CARD")]
            HighCard = 1,
            [ProtoEnum(Name = @"ONE_PAIR")]
            OnePair = 2,
            [ProtoEnum(Name = @"TWO_PAIR")]
            TwoPair = 3,
            [ProtoEnum(Name = @"THREE_OF_A_KIND")]
            ThreeOfAKind = 4,
            [ProtoEnum(Name = @"STRAIGHT")]
            Straight = 5,
            [ProtoEnum(Name = @"FLUSH")]
            Flush = 6,
            [ProtoEnum(Name = @"FULL_HOUSE")]
            FullHouse = 7,
            [ProtoEnum(Name = @"FOUR_OF_A_KIND")]
            FourOfAKind = 8,
            [ProtoEnum(Name = @"STRAIGHT_FLUSH")]
            StraightFlush = 9,
            [ProtoEnum(Name = @"ROYAL_STRAIGHT_FLUSH")]
            RoyalStraightFlush = 10,
            [ProtoEnum(Name = @"NO_CARD")]
            NoCard = 11,
        }

    }

    [ProtoContract]
    internal partial class ActionRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(4, Name = @"gold", IsRequired = true)]
        public long Gold { get; set; }

    }

    [ProtoContract]
    internal partial class ReconnectionRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, Name = @"incode", IsRequired = true)]
        public string Incode { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int playerId { get; set; }

    }

    [ProtoContract]
    internal partial class ReconnectionResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public PubCard pubCard { get; set; }

        [ProtoMember(2, Name = @"reconnectionSitInfo")]
        public List<ReconnectionSitInfo> reconnectionSitInfoes { get; } = new List<ReconnectionSitInfo>();

        [ProtoMember(3)]
        public HandCard handCard { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long endPot { get; set; }

        [ProtoMember(5, Name = @"pots")]
        public Pots Pots { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public HandPowerEnum handPowerEnum { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int createrId { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public int roomType { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public int endTime { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public int thinkTime { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public int upBlindTime { get; set; }

        [ProtoMember(13, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(14, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(15, Name = @"incode", IsRequired = true)]
        public string Incode { get; set; }

        [ProtoMember(16, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

        [ProtoMember(17, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(18, IsRequired = true)]
        public int sngStartCD { get; set; }

        [ProtoMember(19, IsRequired = true)]
        public long initBankRoll { get; set; }

        [ProtoMember(20, Name = @"apply", IsRequired = true)]
        public string Apply { get; set; }

        [ProtoMember(21, IsRequired = true)]
        public int surchargePercent { get; set; }

        [ProtoMember(22, IsRequired = true)]
        public int addoneChip { get; set; }

        [ProtoMember(23, Name = @"rebuycount", IsRequired = true)]
        public int Rebuycount { get; set; }

        [ProtoMember(24, IsRequired = true)]
        public int addoneCount { get; set; }

        [ProtoMember(25, IsRequired = true)]
        public int currbBlindRank { get; set; }

        [ProtoMember(26, IsRequired = true)]
        public int rebuyBlindRank { get; set; }

        [ProtoMember(27, IsRequired = true)]
        public int curBlindRestTime { get; set; }

        [ProtoMember(28)]
        public int endSignupBlind
        {
            get { return __pbn__endSignupBlind.GetValueOrDefault(); }
            set { __pbn__endSignupBlind = value; }
        }
        public bool ShouldSerializeendSignupBlind() => __pbn__endSignupBlind != null;
        public void ResetendSignupBlind() => __pbn__endSignupBlind = null;
        private int? __pbn__endSignupBlind;

        [ProtoMember(29)]
        [DefaultValue("")]
        public string rebuyCost
        {
            get { return __pbn__rebuyCost ?? ""; }
            set { __pbn__rebuyCost = value; }
        }
        public bool ShouldSerializerebuyCost() => __pbn__rebuyCost != null;
        public void ResetrebuyCost() => __pbn__rebuyCost = null;
        private string __pbn__rebuyCost;

        [ProtoMember(30)]
        public int rebuySurchargePercent
        {
            get { return __pbn__rebuySurchargePercent.GetValueOrDefault(); }
            set { __pbn__rebuySurchargePercent = value; }
        }
        public bool ShouldSerializerebuySurchargePercent() => __pbn__rebuySurchargePercent != null;
        public void ResetrebuySurchargePercent() => __pbn__rebuySurchargePercent = null;
        private int? __pbn__rebuySurchargePercent;

        [ProtoMember(31, IsRequired = true)]
        public int signUpType { get; set; }

        [ProtoMember(32, IsRequired = true)]
        public int addThinkTime { get; set; }

        [ProtoMember(33, IsRequired = true)]
        public int addThinkTimeCostItemId { get; set; }

        [ProtoMember(34, IsRequired = true)]
        public int addThinkTimeCostCount { get; set; }

        [ProtoMember(35, IsRequired = true)]
        public int joninClubId { get; set; }

        [ProtoMember(36, IsRequired = true)]
        public int insuranceTarget { get; set; }

        [ProtoMember(37, IsRequired = true)]
        public int straddleTarget { get; set; }

        [ProtoMember(38, IsRequired = true)]
        public int gpsIpTarget { get; set; }

        [ProtoMember(39, IsRequired = true)]
        public long baseRaise { get; set; }

        [ProtoMember(40, Name = @"sb", IsRequired = true)]
        public long Sb { get; set; }

        [ProtoMember(41, Name = @"play", IsRequired = true)]
        public bool Play { get; set; }

        [ProtoMember(42)]
        [DefaultValue("")]
        public string clubName
        {
            get { return __pbn__clubName ?? ""; }
            set { __pbn__clubName = value; }
        }
        public bool ShouldSerializeclubName() => __pbn__clubName != null;
        public void ResetclubName() => __pbn__clubName = null;
        private string __pbn__clubName;

        [ProtoMember(43)]
        public int clubTableNO
        {
            get { return __pbn__clubTableNO.GetValueOrDefault(); }
            set { __pbn__clubTableNO = value; }
        }
        public bool ShouldSerializeclubTableNO() => __pbn__clubTableNO != null;
        public void ResetclubTableNO() => __pbn__clubTableNO = null;
        private int? __pbn__clubTableNO;

        [ProtoMember(44, IsRequired = true)]
        public long initPot { get; set; }

        [ProtoMember(45, IsRequired = true)]
        public int playType { get; set; }

        [ProtoMember(46)]
        public List<Card> bestHoleCards { get; } = new List<Card>();

        [ProtoMember(47, IsRequired = true)]
        public int raiseLimitFixed { get; set; }

        [ProtoMember(48, IsRequired = true)]
        public string raiseLimitPot { get; set; }

        [ProtoMember(49)]
        public int handCount
        {
            get { return __pbn__handCount.GetValueOrDefault(); }
            set { __pbn__handCount = value; }
        }
        public bool ShouldSerializehandCount() => __pbn__handCount != null;
        public void ResethandCount() => __pbn__handCount = null;
        private int? __pbn__handCount;

        [ProtoMember(50)]
        public int clubRoom
        {
            get { return __pbn__clubRoom.GetValueOrDefault(); }
            set { __pbn__clubRoom = value; }
        }
        public bool ShouldSerializeclubRoom() => __pbn__clubRoom != null;
        public void ResetclubRoom() => __pbn__clubRoom = null;
        private int? __pbn__clubRoom;

        [ProtoMember(51)]
        [DefaultValue("")]
        public string clubInviteCode
        {
            get { return __pbn__clubInviteCode ?? ""; }
            set { __pbn__clubInviteCode = value; }
        }
        public bool ShouldSerializeclubInviteCode() => __pbn__clubInviteCode != null;
        public void ResetclubInviteCode() => __pbn__clubInviteCode = null;
        private string __pbn__clubInviteCode;

        [ProtoMember(52)]
        public bool canStart
        {
            get { return __pbn__canStart.GetValueOrDefault(); }
            set { __pbn__canStart = value; }
        }
        public bool ShouldSerializecanStart() => __pbn__canStart != null;
        public void ResetcanStart() => __pbn__canStart = null;
        private bool? __pbn__canStart;

        [ProtoMember(53)]
        public bool canOver
        {
            get { return __pbn__canOver.GetValueOrDefault(); }
            set { __pbn__canOver = value; }
        }
        public bool ShouldSerializecanOver() => __pbn__canOver != null;
        public void ResetcanOver() => __pbn__canOver = null;
        private bool? __pbn__canOver;

        [ProtoMember(54)]
        public int bankrollType
        {
            get { return __pbn__bankrollType.GetValueOrDefault(); }
            set { __pbn__bankrollType = value; }
        }
        public bool ShouldSerializebankrollType() => __pbn__bankrollType != null;
        public void ResetbankrollType() => __pbn__bankrollType = null;
        private int? __pbn__bankrollType;

        [ProtoMember(55, Name = @"item")]
        public List<PublicCardCostItem> Items { get; } = new List<PublicCardCostItem>();

        [ProtoMember(56, IsRequired = true)]
        public int canBringOut { get; set; }

        [ProtoMember(57, IsRequired = true)]
        public float minKeepMultiple { get; set; }

        [ProtoMember(58, IsRequired = true)]
        public float bringOutMultiple { get; set; }

    }

    [ProtoContract]
    internal partial class ReconnectionSitInfo : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, Name = @"endaction", IsRequired = true)]
        public int Endaction { get; set; }

        [ProtoMember(4, Name = @"toaction", IsRequired = true)]
        public int Toaction { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public long actionTime { get; set; }

        [ProtoMember(6, Name = @"bet", IsRequired = true)]
        public long Bet { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public bool isDealer { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public bool isSB { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public bool isBB { get; set; }

        [ProtoMember(10, Name = @"bankroll", IsRequired = true)]
        public long Bankroll { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public long needCall { get; set; }

        [ProtoMember(12, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(14, Name = @"state", IsRequired = true)]
        public int State { get; set; }

        [ProtoMember(15, Name = @"managed", IsRequired = true)]
        public bool Managed { get; set; }

        [ProtoMember(16, Name = @"rank", IsRequired = true)]
        public int Rank { get; set; }

        [ProtoMember(17)]
        public bool isStraddle
        {
            get { return __pbn__isStraddle.GetValueOrDefault(); }
            set { __pbn__isStraddle = value; }
        }
        public bool ShouldSerializeisStraddle() => __pbn__isStraddle != null;
        public void ResetisStraddle() => __pbn__isStraddle = null;
        private bool? __pbn__isStraddle;

        [ProtoMember(18, Name = @"isforce")]
        public bool Isforce
        {
            get { return __pbn__Isforce.GetValueOrDefault(); }
            set { __pbn__Isforce = value; }
        }
        public bool ShouldSerializeIsforce() => __pbn__Isforce != null;
        public void ResetIsforce() => __pbn__Isforce = null;
        private bool? __pbn__Isforce;

        [ProtoMember(19, IsRequired = true)]
        public int takeMascot { get; set; }

        [ProtoMember(20)]
        public int sTag
        {
            get { return __pbn__sTag.GetValueOrDefault(); }
            set { __pbn__sTag = value; }
        }
        public bool ShouldSerializesTag() => __pbn__sTag != null;
        public void ResetsTag() => __pbn__sTag = null;
        private int? __pbn__sTag;

        [ProtoMember(21)]
        public int aTag
        {
            get { return __pbn__aTag.GetValueOrDefault(); }
            set { __pbn__aTag = value; }
        }
        public bool ShouldSerializeaTag() => __pbn__aTag != null;
        public void ResetaTag() => __pbn__aTag = null;
        private int? __pbn__aTag;

        [ProtoMember(22)]
        public int keepSitRestTime
        {
            get { return __pbn__keepSitRestTime.GetValueOrDefault(); }
            set { __pbn__keepSitRestTime = value; }
        }
        public bool ShouldSerializekeepSitRestTime() => __pbn__keepSitRestTime != null;
        public void ResetkeepSitRestTime() => __pbn__keepSitRestTime = null;
        private int? __pbn__keepSitRestTime;

    }

    [ProtoContract]
    internal partial class Pots : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public List<Pot> pot { get; } = new List<Pot>();

    }

    [ProtoContract]
    internal partial class CommonRoomSitDownTermRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

    }

    [ProtoContract]
    internal partial class CommonRoomSitDownTermResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public bool canSitDown { get; set; }

        [ProtoMember(2, Name = @"gold")]
        public long Gold
        {
            get { return __pbn__Gold.GetValueOrDefault(); }
            set { __pbn__Gold = value; }
        }
        public bool ShouldSerializeGold() => __pbn__Gold != null;
        public void ResetGold() => __pbn__Gold = null;
        private long? __pbn__Gold;

        [ProtoMember(3)]
        public long baseBankRoll
        {
            get { return __pbn__baseBankRoll.GetValueOrDefault(); }
            set { __pbn__baseBankRoll = value; }
        }
        public bool ShouldSerializebaseBankRoll() => __pbn__baseBankRoll != null;
        public void ResetbaseBankRoll() => __pbn__baseBankRoll = null;
        private long? __pbn__baseBankRoll;

        [ProtoMember(4, Name = @"multiple")]
        public int Multiple
        {
            get { return __pbn__Multiple.GetValueOrDefault(); }
            set { __pbn__Multiple = value; }
        }
        public bool ShouldSerializeMultiple() => __pbn__Multiple != null;
        public void ResetMultiple() => __pbn__Multiple = null;
        private int? __pbn__Multiple;

    }

    [ProtoContract]
    internal partial class CancelCommonRoomSitDownTermRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

    }

    [ProtoContract]
    internal partial class CancelCommonRoomSitDownTermResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int sitId { get; set; }

    }

    [ProtoContract]
    internal partial class ConfirmBankRollRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, Name = @"multiple", IsRequired = true)]
        public int Multiple { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int sitId { get; set; }

    }

    [ProtoContract]
    internal partial class ConfirmBankRollResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public bool buyBankRollState { get; set; }

        [ProtoMember(2)]
        public int roomId
        {
            get { return __pbn__roomId.GetValueOrDefault(); }
            set { __pbn__roomId = value; }
        }
        public bool ShouldSerializeroomId() => __pbn__roomId != null;
        public void ResetroomId() => __pbn__roomId = null;
        private int? __pbn__roomId;

        [ProtoMember(3)]
        public int gameId
        {
            get { return __pbn__gameId.GetValueOrDefault(); }
            set { __pbn__gameId = value; }
        }
        public bool ShouldSerializegameId() => __pbn__gameId != null;
        public void ResetgameId() => __pbn__gameId = null;
        private int? __pbn__gameId;

        [ProtoMember(4)]
        public int sitId
        {
            get { return __pbn__sitId.GetValueOrDefault(); }
            set { __pbn__sitId = value; }
        }
        public bool ShouldSerializesitId() => __pbn__sitId != null;
        public void ResetsitId() => __pbn__sitId = null;
        private int? __pbn__sitId;

    }

    [ProtoContract]
    internal partial class OverGameGainsShowCardRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int cardNO { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyOverGameGainsShowCardResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(2, Name = @"card")]
        public List<Card> Cards { get; } = new List<Card>();

        [ProtoMember(3, IsRequired = true)]
        public int cardNo { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int playerId { get; set; }

    }

    [ProtoContract]
    internal partial class AdvStandUpResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"state", IsRequired = true)]
        public int State { get; set; }

    }

    [ProtoContract]
    internal partial class AdvOutRoomResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"state", IsRequired = true)]
        public int State { get; set; }

    }

    [ProtoContract]
    internal partial class CancelStandUpRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

    }

    [ProtoContract]
    internal partial class CancelStandUpResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"state", IsRequired = true)]
        public int State { get; set; }

    }

    [ProtoContract]
    internal partial class CloseScorecardResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"state", IsRequired = true)]
        public int State { get; set; }

    }

    [ProtoContract]
    internal partial class AddThinkTimeRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class AddThinkTimeResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public long restActionTime { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int addTime { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int costItemId { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int costCount { get; set; }

    }

    [ProtoContract]
    internal partial class InteractionItemRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int interactionIndex { get; set; }

    }

    [ProtoContract]
    internal partial class InteractionItemResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int interactionIndex { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int fromSitId { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int toSitId { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int costItemId { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int costCount { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int restCount { get; set; }

    }

    [ProtoContract]
    internal partial class ShowEmojiRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string emojiId { get; set; }

    }

    [ProtoContract]
    internal partial class ShowEmojiResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string emojiId { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int playerId { get; set; }

    }

    [ProtoContract]
    internal partial class ReportAgroupOfCardRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string reportPlayerIds { get; set; }

    }

    [ProtoContract]
    internal partial class ReportAgroupOfCardResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"state", IsRequired = true)]
        public int State { get; set; }

    }

    [ProtoContract]
    internal partial class HideAgroupOfCardRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string hidePlayerId { get; set; }

    }

    [ProtoContract]
    internal partial class HideAgroupOfCardResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"state", IsRequired = true)]
        public int State { get; set; }

    }

    [ProtoContract]
    internal partial class GpsStateResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int gpsIpTarget { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int roomId { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyAdvanceLeaveTable : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public long bankRoll { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int bankRollType { get; set; }

        [ProtoMember(4)]
        public int serviceCost
        {
            get { return __pbn__serviceCost.GetValueOrDefault(); }
            set { __pbn__serviceCost = value; }
        }
        public bool ShouldSerializeserviceCost() => __pbn__serviceCost != null;
        public void ResetserviceCost() => __pbn__serviceCost = null;
        private int? __pbn__serviceCost;

        [ProtoMember(5)]
        public int serviceCostType
        {
            get { return __pbn__serviceCostType.GetValueOrDefault(); }
            set { __pbn__serviceCostType = value; }
        }
        public bool ShouldSerializeserviceCostType() => __pbn__serviceCostType != null;
        public void ResetserviceCostType() => __pbn__serviceCostType = null;
        private int? __pbn__serviceCostType;

    }

    [ProtoContract]
    internal partial class WatchPublicCardRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class WatchPublicCardResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"card")]
        public List<Card> Cards { get; } = new List<Card>();

        [ProtoMember(2, IsRequired = true)]
        public int nextCost { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int nextCostItemId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class KeepSitRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class KeepSitResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int keepSitRestTime { get; set; }

    }

    [ProtoContract]
    internal partial class CancelKeepSitRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class CancelKeepSitResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int playerId { get; set; }

    }

    [ProtoContract]
    internal partial class DyPlayerRebuyNotEnough : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int shortType { get; set; }

    }

    [ProtoContract]
    internal partial class DyRefusePlayerRebuy : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int playerId { get; set; }

    }

    [ProtoContract]
    internal partial class StartClubRoomReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int clubId { get; set; }

    }

    [ProtoContract]
    internal partial class StartClubRoomResp : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, Name = @"state", IsRequired = true)]
        public int State { get; set; }

    }

    [ProtoContract]
    internal partial class SettlementClubGame : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class BringOutInfoRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class BringOutInfoResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public float minKeepMultiple { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public float bringOutMultiple { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public long totalBringOut { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public long baseBankRoll { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public long bankRoll { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int bankRollType { get; set; }

    }

    [ProtoContract]
    internal partial class BringOutRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, Name = @"count", IsRequired = true)]
        public long Count { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int bankRollType { get; set; }

    }

    [ProtoContract]
    internal partial class BringOutResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(5, Name = @"count", IsRequired = true)]
        public long Count { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int bankRollType { get; set; }

        [ProtoMember(7, Name = @"status", IsRequired = true)]
        public int Status { get; set; }

    }

    [ProtoContract]
    internal partial class RankInfo : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(3, Name = @"rank", IsRequired = true)]
        public int Rank { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long rewardAmount { get; set; }

        [ProtoMember(5, Name = @"cards")]
        public List<Card> Cards { get; } = new List<Card>();

        [ProtoMember(6, IsRequired = true)]
        public string rankDate { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public string headIcon { get; set; }

    }

    [ProtoContract]
    internal partial class showRankConfigReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playType { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int roomType { get; set; }

    }

    [ProtoContract]
    internal partial class showRankConfigRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"show", IsRequired = true)]
        public int Show { get; set; }

    }

    [ProtoContract]
    internal partial class RankInfoReq : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"type", IsRequired = true)]
        public RankInfoType Type { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playType { get; set; }

    }

    [ProtoContract]
    internal partial class RankInfoRes : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"info")]
        public List<RankInfo> Infoes { get; } = new List<RankInfo>();

        [ProtoMember(2)]
        public RankInfo selfInfo { get; set; }

    }

    [ProtoContract]
    internal partial class RaceListRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceType { get; set; }

        [ProtoMember(2, Name = @"page", IsRequired = true)]
        public int Page { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public long createTime { get; set; }

    }

    [ProtoContract]
    internal partial class RaceListResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceCount { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int pageCount { get; set; }

        [ProtoMember(3)]
        public RaceInfos raceInfos { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int raceType { get; set; }

    }

    [ProtoContract]
    internal partial class RaceInfos : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"raceInfo")]
        public List<RaceInfo> raceInfoes { get; } = new List<RaceInfo>();

    }

    [ProtoContract]
    internal partial class RaceInfo : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public int Id { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string raceName { get; set; }

        [ProtoMember(3, Name = @"cover", IsRequired = true)]
        public string Cover { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int upBlind { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int raceType { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public long startTime { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int racerNum { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public string raceLimit { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public int raceState { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public long createTime { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public int matchType { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public int signupType { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public int signUpCost { get; set; }

        [ProtoMember(14, IsRequired = true)]
        public int maxTableCount { get; set; }

    }

    [ProtoContract]
    internal partial class RaceApplyRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string applyItemUniqueId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int clubId { get; set; }

    }

    [ProtoContract]
    internal partial class RaceApplyResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"msg", IsRequired = true)]
        public string Msg { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int raceId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public bool isStarted { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public SignUpStatus signUpStatus { get; set; } = SignUpStatus.CanSignUp;

    }

    [ProtoContract]
    internal partial class RaceCancelApplyRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

    }

    [ProtoContract]
    internal partial class RaceCancelApplyResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"msg")]
        [DefaultValue("")]
        public string Msg
        {
            get { return __pbn__Msg ?? ""; }
            set { __pbn__Msg = value; }
        }
        public bool ShouldSerializeMsg() => __pbn__Msg != null;
        public void ResetMsg() => __pbn__Msg = null;
        private string __pbn__Msg;

        [ProtoMember(2, IsRequired = true)]
        public int raceId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public bool isStarted { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public SignUpStatus signUpStatus { get; set; } = SignUpStatus.CanSignUp;

    }

    [ProtoContract]
    internal partial class RaceMTTRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

    }

    [ProtoContract]
    internal partial class RaceMTTResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string raceName { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public long startTime { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int maxTableCount { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int maxRaceCount { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public string raceLimit { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public int startStack { get; set; }

        [ProtoMember(10)]
        public uint roomId
        {
            get { return __pbn__roomId.GetValueOrDefault(); }
            set { __pbn__roomId = value; }
        }
        public bool ShouldSerializeroomId() => __pbn__roomId != null;
        public void ResetroomId() => __pbn__roomId = null;
        private uint? __pbn__roomId;

        [ProtoMember(11, IsRequired = true)]
        public int upBlind { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public int signUpType { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public string signUpCost { get; set; }

        [ProtoMember(14, IsRequired = true)]
        public int awardType { get; set; }

        [ProtoMember(15, Name = @"bonus", IsRequired = true)]
        public int Bonus { get; set; }

        [ProtoMember(16, IsRequired = true)]
        public int floatpoolType { get; set; }

        [ProtoMember(17, IsRequired = true)]
        public int actionTimeout { get; set; }

        [ProtoMember(18, IsRequired = true)]
        public int minRaceCount { get; set; }

        [ProtoMember(19, IsRequired = true)]
        public int rEndBlind { get; set; }

        [ProtoMember(20, IsRequired = true)]
        public int endSignupBlind { get; set; }

        [ProtoMember(21, IsRequired = true)]
        public int rebuyNum { get; set; }

        [ProtoMember(22, IsRequired = true)]
        public int reentryNum { get; set; }

        [ProtoMember(23, IsRequired = true)]
        public int addonNum { get; set; }

        [ProtoMember(24, IsRequired = true)]
        public int addonChip { get; set; }

        [ProtoMember(25, Name = @"awardTemplate")]
        public List<AwardTemplate> awardTemplates { get; } = new List<AwardTemplate>();

        [ProtoMember(26, IsRequired = true)]
        public int playersNum { get; set; }

        [ProtoMember(27, IsRequired = true)]
        public int signUpFeePercent { get; set; }

        [ProtoMember(29, IsRequired = true)]
        public long avgChips { get; set; }

        [ProtoMember(30, IsRequired = true)]
        public long minChips { get; set; }

        [ProtoMember(31, IsRequired = true)]
        public long maxChips { get; set; }

        [ProtoMember(32, IsRequired = true)]
        public int curBlindLevel { get; set; }

        [ProtoMember(33, IsRequired = true)]
        public int curBlindRestTime { get; set; }

        [ProtoMember(35, Name = @"incode", IsRequired = true)]
        public string Incode { get; set; }

        [ProtoMember(36, IsRequired = true)]
        public int restPlayerNum { get; set; }

        [ProtoMember(37, IsRequired = true)]
        public int curTableNum { get; set; }

        [ProtoMember(38, IsRequired = true)]
        public string rebuyCost { get; set; }

        [ProtoMember(39, IsRequired = true)]
        public int rebuyFee { get; set; }

        [ProtoMember(40, IsRequired = true)]
        public int raceType { get; set; }

        [ProtoMember(41, IsRequired = true)]
        public bool isStarted { get; set; }

        [ProtoMember(42, IsRequired = true)]
        public int signUpStatus { get; set; }

    }

    [ProtoContract]
    internal partial class DefaultBlind : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"rank", IsRequired = true)]
        public int Rank { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int smallBlind { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int bigBlind { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long anteNum { get; set; }

    }

    [ProtoContract]
    internal partial class AwardTemplate : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public int Id { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int beginRankd { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int endRankd { get; set; }

        [ProtoMember(4, Name = @"items")]
        public List<Awards> Items { get; } = new List<Awards>();

    }

    [ProtoContract]
    internal partial class Awards : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public int Id { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int itemId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int itemNum { get; set; }

    }

    [ProtoContract]
    internal partial class RacePlayerNumRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

    }

    [ProtoContract]
    internal partial class RacePlayerNumResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerNum { get; set; }

        [ProtoMember(3, Name = @"playerList")]
        public List<RacePlayer> playerLists { get; } = new List<RacePlayer>();

    }

    [ProtoContract]
    internal partial class RaceStartResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string raceName { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class RaceFinishResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

        [ProtoMember(2, Name = @"players")]
        public List<RacePlayer> Players { get; } = new List<RacePlayer>();

    }

    [ProtoContract]
    internal partial class RacePlayer : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, Name = @"ranking")]
        public int Ranking
        {
            get { return __pbn__Ranking.GetValueOrDefault(); }
            set { __pbn__Ranking = value; }
        }
        public bool ShouldSerializeRanking() => __pbn__Ranking != null;
        public void ResetRanking() => __pbn__Ranking = null;
        private int? __pbn__Ranking;

        [ProtoMember(3)]
        [DefaultValue("")]
        public string playerName
        {
            get { return __pbn__playerName ?? ""; }
            set { __pbn__playerName = value; }
        }
        public bool ShouldSerializeplayerName() => __pbn__playerName != null;
        public void ResetplayerName() => __pbn__playerName = null;
        private string __pbn__playerName;

        [ProtoMember(4, Name = @"score")]
        public int Score
        {
            get { return __pbn__Score.GetValueOrDefault(); }
            set { __pbn__Score = value; }
        }
        public bool ShouldSerializeScore() => __pbn__Score != null;
        public void ResetScore() => __pbn__Score = null;
        private int? __pbn__Score;

        [ProtoMember(5, Name = @"award")]
        public int Award
        {
            get { return __pbn__Award.GetValueOrDefault(); }
            set { __pbn__Award = value; }
        }
        public bool ShouldSerializeAward() => __pbn__Award != null;
        public void ResetAward() => __pbn__Award = null;
        private int? __pbn__Award;

        [ProtoMember(6, Name = @"icon")]
        [DefaultValue("")]
        public string Icon
        {
            get { return __pbn__Icon ?? ""; }
            set { __pbn__Icon = value; }
        }
        public bool ShouldSerializeIcon() => __pbn__Icon != null;
        public void ResetIcon() => __pbn__Icon = null;
        private string __pbn__Icon;

    }

    [ProtoContract]
    internal partial class StartMTTNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string raceName { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(5, Name = @"incode", IsRequired = true)]
        public string Incode { get; set; }

    }

    [ProtoContract]
    internal partial class RaceMttRewardRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

    }

    [ProtoContract]
    internal partial class RaceMttRewardResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int rewardPlayerNum { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public long totalBonus { get; set; }

        [ProtoMember(4, Name = @"bonusInfo")]
        public List<BonusInfo> bonusInfoes { get; } = new List<BonusInfo>();

        [ProtoMember(5, IsRequired = true)]
        public int floatRewardItemId { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int awardType { get; set; }

        [ProtoMember(7)]
        [DefaultValue("")]
        public string raceRemark
        {
            get { return __pbn__raceRemark ?? ""; }
            set { __pbn__raceRemark = value; }
        }
        public bool ShouldSerializeraceRemark() => __pbn__raceRemark != null;
        public void ResetraceRemark() => __pbn__raceRemark = null;
        private string __pbn__raceRemark;

    }

    [ProtoContract]
    internal partial class BonusInfo : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int rankStart { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int rankEnd { get; set; }

        [ProtoMember(3, Name = @"percent")]
        public int Percent
        {
            get { return __pbn__Percent.GetValueOrDefault(); }
            set { __pbn__Percent = value; }
        }
        public bool ShouldSerializePercent() => __pbn__Percent != null;
        public void ResetPercent() => __pbn__Percent = null;
        private int? __pbn__Percent;

        [ProtoMember(4)]
        [DefaultValue("")]
        public string itemsReward
        {
            get { return __pbn__itemsReward ?? ""; }
            set { __pbn__itemsReward = value; }
        }
        public bool ShouldSerializeitemsReward() => __pbn__itemsReward != null;
        public void ResetitemsReward() => __pbn__itemsReward = null;
        private string __pbn__itemsReward;

    }

    [ProtoContract]
    internal partial class RaceMttRankRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int rankStart { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int rankEnd { get; set; }

    }

    [ProtoContract]
    internal partial class RaceMttRankResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

        [ProtoMember(2, Name = @"rankPlayer")]
        public List<mttRankPlayer> rankPlayers { get; } = new List<mttRankPlayer>();

        [ProtoMember(3, IsRequired = true)]
        public int restPlayerNum { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int playersNum { get; set; }

    }

    [ProtoContract]
    internal partial class MttRankPlayer : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"rank", IsRequired = true)]
        public int Rank { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string playerIcon { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int curGameId { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public long bankRoll { get; set; }

    }

    [ProtoContract]
    internal partial class RaceMttTableRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

    }

    [ProtoContract]
    internal partial class RaceMttTableResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

        [ProtoMember(2, Name = @"raceMttTable")]
        public List<RaceMttTable> raceMttTables { get; } = new List<RaceMttTable>();

    }

    [ProtoContract]
    internal partial class RaceMttTable : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int tableId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerNum { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public long minChips { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long maxChips { get; set; }

    }

    [ProtoContract]
    internal partial class RaceMTTGameIdRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

    }

    [ProtoContract]
    internal partial class RaceMTTGameIdResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class RaceMTTBlindRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

    }

    [ProtoContract]
    internal partial class RaceMTTBlindResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

        [ProtoMember(2, Name = @"blinds")]
        public List<DefaultBlind> Blinds { get; } = new List<DefaultBlind>();

    }

    [ProtoContract]
    internal partial class MTTRevivalRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string revivalItemUniqueId { get; set; }

    }

    [ProtoContract]
    internal partial class MTTRevivalResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int raceId { get; set; }

        [ProtoMember(2, Name = @"suc", IsRequired = true)]
        public bool Suc { get; set; }

    }

    [ProtoContract]
    internal partial class ConmmonRankRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class ConmmonRankResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int handCount { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long allBankRoll { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public long avgEndPot { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int avgHandCostTime { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int endTime { get; set; }

        [ProtoMember(8)]
        public List<OnLookers> onLookers { get; } = new List<OnLookers>();

        [ProtoMember(9, Name = @"conmmonRank")]
        public List<ConmmonRank> conmmonRanks { get; } = new List<ConmmonRank>();

        [ProtoMember(10, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(11)]
        public long insurancePool
        {
            get { return __pbn__insurancePool.GetValueOrDefault(); }
            set { __pbn__insurancePool = value; }
        }
        public bool ShouldSerializeinsurancePool() => __pbn__insurancePool != null;
        public void ResetinsurancePool() => __pbn__insurancePool = null;
        private long? __pbn__insurancePool;

    }

    [ProtoContract]
    internal partial class OnLookers : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(3, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

    }

    [ProtoContract]
    internal partial class ConmmonRank : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(4, Name = @"bankroll", IsRequired = true)]
        public long Bankroll { get; set; }

        [ProtoMember(5, Name = @"gains", IsRequired = true)]
        public long Gains { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int inGame { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public bool advLeven { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int handCount { get; set; }

    }

    [ProtoContract]
    internal partial class SngRoomRank : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class SngRoomRankResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int handCount { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int playerCount { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int allPlayerCount { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int nowBlindRank { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int nowBb { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int nextBlindRank { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public int nextBb { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public int avgHandCostTime { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public int upBlindTime { get; set; }

        [ProtoMember(12)]
        public List<OnLookers> onLookers { get; } = new List<OnLookers>();

        [ProtoMember(13, Name = @"sNGRank")]
        public List<SNGRank> sNGRanks { get; } = new List<SNGRank>();

        [ProtoMember(14, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(15, Name = @"sb", IsRequired = true)]
        public int Sb { get; set; }

        [ProtoMember(16, IsRequired = true)]
        public int nextSb { get; set; }

    }

    [ProtoContract]
    internal partial class SNGRank : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long nowBankroll { get; set; }

        [ProtoMember(5, Name = @"rank", IsRequired = true)]
        public int Rank { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyReLogin : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"relogin", IsRequired = true)]
        public bool Relogin { get; set; }

    }

    [ProtoContract]
    internal partial class RecordListRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint roomType { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint playType { get; set; }

        [ProtoMember(3, Name = @"page", IsRequired = true)]
        public int Page { get; set; }

    }

    [ProtoContract]
    internal partial class RecordListResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int nowPage { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int nextPage { get; set; }

        [ProtoMember(3)]
        public Records Records { get; set; }

    }

    [ProtoContract]
    internal partial class Records : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public List<Record> record { get; } = new List<Record>();

    }

    [ProtoContract]
    internal partial class Record : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public int Id { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int roomType { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string recordName { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int recordType { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public string roomCreaterName { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public string roomCreaterIcon { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public string createTime { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public string startTime { get; set; }

        [ProtoMember(10, Name = @"duration", IsRequired = true)]
        public int Duration { get; set; }

        [ProtoMember(11, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(12, Name = @"ante", IsRequired = true)]
        public long Ante { get; set; }

        [ProtoMember(13, Name = @"gains", IsRequired = true)]
        public long Gains { get; set; }

        [ProtoMember(14, Name = @"rank", IsRequired = true)]
        public int Rank { get; set; }

        [ProtoMember(15, IsRequired = true)]
        public int playerCount { get; set; }

        [ProtoMember(16, IsRequired = true)]
        public int upblindTime { get; set; }

        [ProtoMember(17, IsRequired = true)]
        public long initBankRoll { get; set; }

        [ProtoMember(18, IsRequired = true)]
        public int detailId { get; set; }

        [ProtoMember(19, IsRequired = true)]
        public string itemReward { get; set; }

        [ProtoMember(20, Name = @"insurance", IsRequired = true)]
        public int Insurance { get; set; }

        [ProtoMember(21, Name = @"straddle", IsRequired = true)]
        public int Straddle { get; set; }

        [ProtoMember(22, Name = @"sb", IsRequired = true)]
        public long Sb { get; set; }

        [ProtoMember(23, IsRequired = true)]
        public int playType { get; set; }

    }

    [ProtoContract]
    internal partial class RecordDetailRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public int Id { get; set; }

    }

    [ProtoContract]
    internal partial class RecordDetailResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public int Id { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int handCount { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public long maxPot { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long allBankRoll { get; set; }

        [ProtoMember(5, Name = @"rtype", IsRequired = true)]
        public int Rtype { get; set; }

        [ProtoMember(6, Name = @"apply", IsRequired = true)]
        public string Apply { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public long initBankRoll { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public int upBlindTime { get; set; }

        [ProtoMember(9, Name = @"recordDetailInfo")]
        public List<RecordDetailInfo> recordDetailInfoes { get; } = new List<RecordDetailInfo>();

        [ProtoMember(10, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public string createrName { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public string createrIcon { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public int sitCount { get; set; }

        [ProtoMember(14, IsRequired = true)]
        public string createTime { get; set; }

        [ProtoMember(15, IsRequired = true)]
        public int gameTime { get; set; }

        [ProtoMember(16, Name = @"bb")]
        public long Bb
        {
            get { return __pbn__Bb.GetValueOrDefault(); }
            set { __pbn__Bb = value; }
        }
        public bool ShouldSerializeBb() => __pbn__Bb != null;
        public void ResetBb() => __pbn__Bb = null;
        private long? __pbn__Bb;

        [ProtoMember(17, Name = @"mttallbouns")]
        public long Mttallbouns
        {
            get { return __pbn__Mttallbouns.GetValueOrDefault(); }
            set { __pbn__Mttallbouns = value; }
        }
        public bool ShouldSerializeMttallbouns() => __pbn__Mttallbouns != null;
        public void ResetMttallbouns() => __pbn__Mttallbouns = null;
        private long? __pbn__Mttallbouns;

        [ProtoMember(18)]
        [DefaultValue("")]
        public string startTime
        {
            get { return __pbn__startTime ?? ""; }
            set { __pbn__startTime = value; }
        }
        public bool ShouldSerializestartTime() => __pbn__startTime != null;
        public void ResetstartTime() => __pbn__startTime = null;
        private string __pbn__startTime;

        [ProtoMember(19, IsRequired = true)]
        public int playerCount { get; set; }

        [ProtoMember(20, IsRequired = true)]
        public int totalRebuyCount { get; set; }

        [ProtoMember(21, IsRequired = true)]
        public int signUpType { get; set; }

        [ProtoMember(22)]
        public int floatRewardItemId
        {
            get { return __pbn__floatRewardItemId.GetValueOrDefault(); }
            set { __pbn__floatRewardItemId = value; }
        }
        public bool ShouldSerializefloatRewardItemId() => __pbn__floatRewardItemId != null;
        public void ResetfloatRewardItemId() => __pbn__floatRewardItemId = null;
        private int? __pbn__floatRewardItemId;

        [ProtoMember(23, Name = @"insurance", IsRequired = true)]
        public int Insurance { get; set; }

        [ProtoMember(24, Name = @"straddle", IsRequired = true)]
        public int Straddle { get; set; }

        [ProtoMember(25, Name = @"sb", IsRequired = true)]
        public long Sb { get; set; }

        [ProtoMember(26)]
        public int clubRoom
        {
            get { return __pbn__clubRoom.GetValueOrDefault(); }
            set { __pbn__clubRoom = value; }
        }
        public bool ShouldSerializeclubRoom() => __pbn__clubRoom != null;
        public void ResetclubRoom() => __pbn__clubRoom = null;
        private int? __pbn__clubRoom;

    }

    [ProtoContract]
    internal partial class RecordDetailInfo : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(3, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int buyCount { get; set; }

        [ProtoMember(5, Name = @"gains", IsRequired = true)]
        public long Gains { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public long bankRoll { get; set; }

        [ProtoMember(7, Name = @"rank", IsRequired = true)]
        public int Rank { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public string itemReward { get; set; }

        [ProtoMember(9)]
        public long totalInsurance
        {
            get { return __pbn__totalInsurance.GetValueOrDefault(); }
            set { __pbn__totalInsurance = value; }
        }
        public bool ShouldSerializetotalInsurance() => __pbn__totalInsurance != null;
        public void ResettotalInsurance() => __pbn__totalInsurance = null;
        private long? __pbn__totalInsurance;

        [ProtoMember(10, IsRequired = true)]
        public int handCount { get; set; }

    }

    [ProtoContract]
    internal partial class RedPacketRankRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class RedPacketRankResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"rank")]
        public List<RedPacketRank> Ranks { get; } = new List<RedPacketRank>();

    }

    [ProtoContract]
    internal partial class RedPacketRank : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int rankId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string playerIcon { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(5, Name = @"money", IsRequired = true)]
        public long Money { get; set; }

        [ProtoMember(6, Name = @"time", IsRequired = true)]
        public string Time { get; set; }

    }

    [ProtoContract]
    internal partial class RedPacketActivityRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class RedPacketActivityResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"show", IsRequired = true)]
        public int Show { get; set; }

    }

    [ProtoContract]
    internal partial class ReplayRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

    }

    [ProtoContract]
    internal partial class ReplayResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public ulong startTime { get; set; }

        [ProtoMember(2, Name = @"stages")]
        public List<ReplayStage> Stages { get; } = new List<ReplayStage>();

        [ProtoMember(3, IsRequired = true)]
        public uint roomId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public string invitationCode { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public uint creatorId { get; set; }

        [ProtoMember(7, Name = @"bb", IsRequired = true)]
        public uint Bb { get; set; }

        [ProtoMember(8, Name = @"pot", IsRequired = true)]
        public uint Pot { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public uint roomType { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public ulong endTime { get; set; }

    }

    [ProtoContract]
    internal partial class ReplayInfo : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint playerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint replayId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public uint gameType { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public uint playerNum { get; set; }

        [ProtoMember(6, Name = @"bb", IsRequired = true)]
        public uint Bb { get; set; }

        [ProtoMember(7, Name = @"ante", IsRequired = true)]
        public uint Ante { get; set; }

        [ProtoMember(8, Name = @"income", DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int Income { get; set; }

        [ProtoMember(9, Name = @"time", DataFormat = DataFormat.FixedSize, IsRequired = true)]
        public uint Time { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public uint creatorId { get; set; }

        [ProtoMember(12, Name = @"hand", IsRequired = true)]
        public uint Hand { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public string roomName { get; set; }

    }

    [ProtoContract]
    internal partial class ReplayListRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"page", IsRequired = true)]
        public uint Page { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint pageSize { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint gameType { get; set; }

    }

    [ProtoContract]
    internal partial class ReplayListResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"page", IsRequired = true)]
        public uint Page { get; set; }

        [ProtoMember(2, Name = @"infoList")]
        public List<ReplayInfo> infoLists { get; } = new List<ReplayInfo>();

        [ProtoMember(3, IsRequired = true)]
        public uint pagetTotal { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public uint gameType { get; set; }

    }

    [ProtoContract]
    internal partial class ReplayLastRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint gameId { get; set; }

    }

    [ProtoContract]
    internal partial class ReplayLastResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint replayId { get; set; }

        [ProtoMember(2, Name = @"replay", IsRequired = true)]
        public ReplayResponse Replay { get; set; }

    }

    [ProtoContract]
    internal partial class ReplayPlayer : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint sitId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string playerIcon { get; set; }

        [ProtoMember(4, Name = @"gold", IsRequired = true)]
        public uint Gold { get; set; }

        [ProtoMember(5, Name = @"cards")]
        public uint[] Cards { get; set; }

    }

    [ProtoContract]
    internal partial class ReplayGain : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint sitId { get; set; }

        [ProtoMember(2, Name = @"gold", DataFormat = DataFormat.ZigZag, IsRequired = true)]
        public int Gold { get; set; }

    }

    [ProtoContract]
    internal partial class ReplayGameInfo : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"players", IsRequired = true)]
        public ReplayPlayer Players { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint roomType { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string creatorIcon { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public uint bigBlind { get; set; }

    }

    [ProtoContract]
    internal partial class ReplayPlayerAction : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public ulong timeOff { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint sitId { get; set; }

        [ProtoMember(3, Name = @"action", IsRequired = true)]
        public ReplayAction Action { get; set; } = ReplayAction.Bet;

        [ProtoMember(4, Name = @"gold", IsRequired = true)]
        public uint Gold { get; set; }

    }

    [ProtoContract]
    internal partial class ReplayGameStage : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public ulong timeOff { get; set; }

        [ProtoMember(2, Name = @"stage", IsRequired = true)]
        public ReplayStage Stage { get; set; } = ReplayStage.PreFlop;

        [ProtoMember(3, Name = @"cards")]
        public uint[] Cards { get; set; }

    }

    [ProtoContract]
    internal partial class ReplayGameGains : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"gain")]
        public List<ReplayGain> Gains { get; } = new List<ReplayGain>();

    }

    [ProtoContract]
    internal partial class RoomSng : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"apply", IsRequired = true)]
        public string Apply { get; set; }

        [ProtoMember(2, Name = @"chip", IsRequired = true)]
        public long Chip { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint blindingTime { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public uint signUpFeePercent { get; set; }

    }

    [ProtoContract]
    internal partial class Room : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(2, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint serverId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string invitationCode { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(6, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public uint playerCountLimit { get; set; }

        [ProtoMember(8, IsRequired = true)]
        public uint roomType { get; set; }

        [ProtoMember(10, Name = @"ip", IsRequired = true)]
        public string Ip { get; set; }

        [ProtoMember(11, Name = @"port", IsRequired = true)]
        public uint Port { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public uint gameId { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public uint playerCount { get; set; }

        [ProtoMember(14, IsRequired = true)]
        public ulong createTime { get; set; }

        [ProtoMember(15, IsRequired = true)]
        public uint leftTime { get; set; }

        [ProtoMember(16)]
        public bool isEntered
        {
            get { return __pbn__isEntered.GetValueOrDefault(); }
            set { __pbn__isEntered = value; }
        }
        public bool ShouldSerializeisEntered() => __pbn__isEntered != null;
        public void ResetisEntered() => __pbn__isEntered = null;
        private bool? __pbn__isEntered;

        [ProtoMember(17, IsRequired = true)]
        public uint totalTime { get; set; }

        [ProtoMember(18, IsRequired = true)]
        public bool isStarted { get; set; }

        [ProtoMember(19, IsRequired = true)]
        public string creatorIcon { get; set; }

        [ProtoMember(20, IsRequired = true)]
        public string creatorName { get; set; }

        [ProtoMember(21)]
        public RoomSng roomSng { get; set; }

        [ProtoMember(22)]
        public int clubId
        {
            get { return __pbn__clubId.GetValueOrDefault(); }
            set { __pbn__clubId = value; }
        }
        public bool ShouldSerializeclubId() => __pbn__clubId != null;
        public void ResetclubId() => __pbn__clubId = null;
        private int? __pbn__clubId;

        [ProtoMember(23)]
        public int raceId
        {
            get { return __pbn__raceId.GetValueOrDefault(); }
            set { __pbn__raceId = value; }
        }
        public bool ShouldSerializeraceId() => __pbn__raceId != null;
        public void ResetraceId() => __pbn__raceId = null;
        private int? __pbn__raceId;

        [ProtoMember(24)]
        public int signUpStatus
        {
            get { return __pbn__signUpStatus.GetValueOrDefault(); }
            set { __pbn__signUpStatus = value; }
        }
        public bool ShouldSerializesignUpStatus() => __pbn__signUpStatus != null;
        public void ResetsignUpStatus() => __pbn__signUpStatus = null;
        private int? __pbn__signUpStatus;

        [ProtoMember(25)]
        public int startTime
        {
            get { return __pbn__startTime.GetValueOrDefault(); }
            set { __pbn__startTime = value; }
        }
        public bool ShouldSerializestartTime() => __pbn__startTime != null;
        public void ResetstartTime() => __pbn__startTime = null;
        private int? __pbn__startTime;

        [ProtoMember(26, Name = @"ante")]
        public long Ante
        {
            get { return __pbn__Ante.GetValueOrDefault(); }
            set { __pbn__Ante = value; }
        }
        public bool ShouldSerializeAnte() => __pbn__Ante != null;
        public void ResetAnte() => __pbn__Ante = null;
        private long? __pbn__Ante;

        [ProtoMember(27, Name = @"order", IsRequired = true)]
        public int Order { get; set; }

        [ProtoMember(28)]
        public bool hasRebuy
        {
            get { return __pbn__hasRebuy.GetValueOrDefault(); }
            set { __pbn__hasRebuy = value; }
        }
        public bool ShouldSerializehasRebuy() => __pbn__hasRebuy != null;
        public void ResethasRebuy() => __pbn__hasRebuy = null;
        private bool? __pbn__hasRebuy;

        [ProtoMember(29)]
        public bool hasAddon
        {
            get { return __pbn__hasAddon.GetValueOrDefault(); }
            set { __pbn__hasAddon = value; }
        }
        public bool ShouldSerializehasAddon() => __pbn__hasAddon != null;
        public void ResethasAddon() => __pbn__hasAddon = null;
        private bool? __pbn__hasAddon;

        [ProtoMember(30, IsRequired = true)]
        public int signUpType { get; set; }

        [ProtoMember(31, Name = @"insurance")]
        public bool Insurance
        {
            get { return __pbn__Insurance.GetValueOrDefault(); }
            set { __pbn__Insurance = value; }
        }
        public bool ShouldSerializeInsurance() => __pbn__Insurance != null;
        public void ResetInsurance() => __pbn__Insurance = null;
        private bool? __pbn__Insurance;

        [ProtoMember(32)]
        public long baseBankroll
        {
            get { return __pbn__baseBankroll.GetValueOrDefault(); }
            set { __pbn__baseBankroll = value; }
        }
        public bool ShouldSerializebaseBankroll() => __pbn__baseBankroll != null;
        public void ResetbaseBankroll() => __pbn__baseBankroll = null;
        private long? __pbn__baseBankroll;

        [ProtoMember(33, Name = @"multiple")]
        public int Multiple
        {
            get { return __pbn__Multiple.GetValueOrDefault(); }
            set { __pbn__Multiple = value; }
        }
        public bool ShouldSerializeMultiple() => __pbn__Multiple != null;
        public void ResetMultiple() => __pbn__Multiple = null;
        private int? __pbn__Multiple;

        [ProtoMember(34, Name = @"straddle")]
        public int Straddle
        {
            get { return __pbn__Straddle.GetValueOrDefault(); }
            set { __pbn__Straddle = value; }
        }
        public bool ShouldSerializeStraddle() => __pbn__Straddle != null;
        public void ResetStraddle() => __pbn__Straddle = null;
        private int? __pbn__Straddle;

        [ProtoMember(35, Name = @"sb", IsRequired = true)]
        public long Sb { get; set; }

        [ProtoMember(36)]
        [DefaultValue("")]
        public string sngReward
        {
            get { return __pbn__sngReward ?? ""; }
            set { __pbn__sngReward = value; }
        }
        public bool ShouldSerializesngReward() => __pbn__sngReward != null;
        public void ResetsngReward() => __pbn__sngReward = null;
        private string __pbn__sngReward;

        [ProtoMember(37, IsRequired = true)]
        public int playType { get; set; }

        [ProtoMember(38)]
        public int privateRoom
        {
            get { return __pbn__privateRoom.GetValueOrDefault(); }
            set { __pbn__privateRoom = value; }
        }
        public bool ShouldSerializeprivateRoom() => __pbn__privateRoom != null;
        public void ResetprivateRoom() => __pbn__privateRoom = null;
        private int? __pbn__privateRoom;

        [ProtoMember(39)]
        public int floatRewardItemId
        {
            get { return __pbn__floatRewardItemId.GetValueOrDefault(); }
            set { __pbn__floatRewardItemId = value; }
        }
        public bool ShouldSerializefloatRewardItemId() => __pbn__floatRewardItemId != null;
        public void ResetfloatRewardItemId() => __pbn__floatRewardItemId = null;
        private int? __pbn__floatRewardItemId;

        [ProtoMember(40)]
        [DefaultValue("")]
        public string endTime
        {
            get { return __pbn__endTime ?? ""; }
            set { __pbn__endTime = value; }
        }
        public bool ShouldSerializeendTime() => __pbn__endTime != null;
        public void ResetendTime() => __pbn__endTime = null;
        private string __pbn__endTime;

    }

    [ProtoContract]
    internal partial class CommonRoomListRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(2, Name = @"playType")]
        public int[] playTypes { get; set; }

        [ProtoMember(3)]
        public bool hideFull
        {
            get { return __pbn__hideFull.GetValueOrDefault(); }
            set { __pbn__hideFull = value; }
        }
        public bool ShouldSerializehideFull() => __pbn__hideFull != null;
        public void ResethideFull() => __pbn__hideFull = null;
        private bool? __pbn__hideFull;

        [ProtoMember(4)]
        public bool hideEmpty
        {
            get { return __pbn__hideEmpty.GetValueOrDefault(); }
            set { __pbn__hideEmpty = value; }
        }
        public bool ShouldSerializehideEmpty() => __pbn__hideEmpty != null;
        public void ResethideEmpty() => __pbn__hideEmpty = null;
        private bool? __pbn__hideEmpty;

        [ProtoMember(5, Name = @"playCount")]
        public List<RoomFilterPlayerCount> playCounts { get; } = new List<RoomFilterPlayerCount>();

        [ProtoMember(6, Name = @"restTime")]
        public List<RoomFilterRestTime> restTimes { get; } = new List<RoomFilterRestTime>();

        [ProtoMember(7, Name = @"roomTemple")]
        public List<RoomTemple> roomTemples { get; } = new List<RoomTemple>();

        [ProtoMember(8, Name = @"bb")]
        public long[] Bbs { get; set; }

        [ProtoMember(9, Name = @"ante")]
        public int Ante
        {
            get { return __pbn__Ante.GetValueOrDefault(); }
            set { __pbn__Ante = value; }
        }
        public bool ShouldSerializeAnte() => __pbn__Ante != null;
        public void ResetAnte() => __pbn__Ante = null;
        private int? __pbn__Ante;

        [ProtoMember(10, Name = @"straddle")]
        public int Straddle
        {
            get { return __pbn__Straddle.GetValueOrDefault(); }
            set { __pbn__Straddle = value; }
        }
        public bool ShouldSerializeStraddle() => __pbn__Straddle != null;
        public void ResetStraddle() => __pbn__Straddle = null;
        private int? __pbn__Straddle;

        [ProtoMember(11, IsRequired = true)]
        public int startRoomId { get; set; }

        [ProtoMember(12, Name = @"version")]
        public long Version
        {
            get { return __pbn__Version.GetValueOrDefault(); }
            set { __pbn__Version = value; }
        }
        public bool ShouldSerializeVersion() => __pbn__Version != null;
        public void ResetVersion() => __pbn__Version = null;
        private long? __pbn__Version;

        [ProtoMember(13, Name = @"shortAnte")]
        public List<string> shortAntes { get; } = new List<string>();

        [ProtoMember(14)]
        public bool isFilter
        {
            get { return __pbn__isFilter.GetValueOrDefault(); }
            set { __pbn__isFilter = value; }
        }
        public bool ShouldSerializeisFilter() => __pbn__isFilter != null;
        public void ResetisFilter() => __pbn__isFilter = null;
        private bool? __pbn__isFilter;

    }

    [ProtoContract]
    internal partial class CommonRoomListResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"rooms")]
        public List<Room> Rooms { get; } = new List<Room>();

        [ProtoMember(2, IsRequired = true)]
        public int pageSize { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int totalSize { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int startRoomId { get; set; }

        [ProtoMember(5)]
        [DefaultValue(EmptyCause.ClubActivity)]
        public EmptyCause emptyCause
        {
            get { return __pbn__emptyCause ?? EmptyCause.ClubActivity; }
            set { __pbn__emptyCause = value; }
        }
        public bool ShouldSerializeemptyCause() => __pbn__emptyCause != null;
        public void ResetemptyCause() => __pbn__emptyCause = null;
        private EmptyCause? __pbn__emptyCause;

        [ProtoMember(6, IsRequired = true)]
        public int startRoomCount { get; set; }

        [ProtoMember(7, Name = @"version")]
        public long Version
        {
            get { return __pbn__Version.GetValueOrDefault(); }
            set { __pbn__Version = value; }
        }
        public bool ShouldSerializeVersion() => __pbn__Version != null;
        public void ResetVersion() => __pbn__Version = null;
        private long? __pbn__Version;

    }

    [ProtoContract]
    internal partial class RaceRoomListRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(2, Name = @"sngormtt", IsRequired = true)]
        public int Sngormtt { get; set; }

    }

    [ProtoContract]
    internal partial class RaceRoomListResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"sngormtt", IsRequired = true)]
        public int Sngormtt { get; set; }

        [ProtoMember(2, Name = @"rooms")]
        public List<Room> Rooms { get; } = new List<Room>();

    }

    [ProtoContract]
    internal partial class RoomUpdateRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(2, Name = @"requestRoom")]
        public List<RequestRoom> requestRooms { get; } = new List<RequestRoom>();

    }

    [ProtoContract]
    internal partial class RequestRoom : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, Name = @"sngormtt", IsRequired = true)]
        public int Sngormtt { get; set; }

    }

    [ProtoContract]
    internal partial class RoomUpdateResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public List<UpdateRoom> updateRooms { get; } = new List<UpdateRoom>();

    }

    [ProtoContract]
    internal partial class UpdateRoom : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public bool isStarted { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int playerCount { get; set; }

        [ProtoMember(4)]
        public int leftTime
        {
            get { return __pbn__leftTime.GetValueOrDefault(); }
            set { __pbn__leftTime = value; }
        }
        public bool ShouldSerializeleftTime() => __pbn__leftTime != null;
        public void ResetleftTime() => __pbn__leftTime = null;
        private int? __pbn__leftTime;

        [ProtoMember(5, Name = @"sngormtt", IsRequired = true)]
        public int Sngormtt { get; set; }

        [ProtoMember(6)]
        public int playerCountLimit
        {
            get { return __pbn__playerCountLimit.GetValueOrDefault(); }
            set { __pbn__playerCountLimit = value; }
        }
        public bool ShouldSerializeplayerCountLimit() => __pbn__playerCountLimit != null;
        public void ResetplayerCountLimit() => __pbn__playerCountLimit = null;
        private int? __pbn__playerCountLimit;

    }

    [ProtoContract]
    internal partial class MyRoomListRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int clubId { get; set; }

    }

    [ProtoContract]
    internal partial class MyRoomListResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"rooms")]
        public List<Room> Rooms { get; } = new List<Room>();

    }

    [ProtoContract]
    internal partial class RoomTemple : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"bb", IsRequired = true)]
        public long Bb { get; set; }

        [ProtoMember(2, Name = @"straddle", IsRequired = true)]
        public bool Straddle { get; set; }

        [ProtoMember(3, Name = @"insurance", IsRequired = true)]
        public bool Insurance { get; set; }

        [ProtoMember(4, Name = @"ante", IsRequired = true)]
        public bool Ante { get; set; }

        [ProtoMember(5)]
        public int limitCount
        {
            get { return __pbn__limitCount.GetValueOrDefault(); }
            set { __pbn__limitCount = value; }
        }
        public bool ShouldSerializelimitCount() => __pbn__limitCount != null;
        public void ResetlimitCount() => __pbn__limitCount = null;
        private int? __pbn__limitCount;

        [ProtoMember(6, Name = @"index")]
        public int Index
        {
            get { return __pbn__Index.GetValueOrDefault(); }
            set { __pbn__Index = value; }
        }
        public bool ShouldSerializeIndex() => __pbn__Index != null;
        public void ResetIndex() => __pbn__Index = null;
        private int? __pbn__Index;

    }

    [ProtoContract]
    internal partial class RoomFilterPlayerCount : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playCountMin { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playCountMax { get; set; }

    }

    [ProtoContract]
    internal partial class RoomFilterRestTime : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int restTimeMin { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int restTimeMax { get; set; }

    }

    [ProtoContract]
    internal partial class RoomUpdateNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"type", IsRequired = true)]
        public UpdateType Type { get; set; } = UpdateType.Created;

        [ProtoMember(2, Name = @"rooms")]
        public List<Room> Rooms { get; } = new List<Room>();

        [ProtoMember(3, IsRequired = true)]
        public RoomListType listType { get; set; }

    }

    [ProtoContract]
    internal partial class RoomInfoRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public int roomId
        {
            get { return __pbn__roomId.GetValueOrDefault(); }
            set { __pbn__roomId = value; }
        }
        public bool ShouldSerializeroomId() => __pbn__roomId != null;
        public void ResetroomId() => __pbn__roomId = null;
        private int? __pbn__roomId;

        [ProtoMember(2)]
        public int raceId
        {
            get { return __pbn__raceId.GetValueOrDefault(); }
            set { __pbn__raceId = value; }
        }
        public bool ShouldSerializeraceId() => __pbn__raceId != null;
        public void ResetraceId() => __pbn__raceId = null;
        private int? __pbn__raceId;

    }

    [ProtoContract]
    internal partial class RoomInfoResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"room", IsRequired = true)]
        public Room Room { get; set; }

    }

    [ProtoContract]
    internal partial class ClubRoomInfoRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int clubId { get; set; }

        [ProtoMember(2, Name = @"playType")]
        public int[] playTypes { get; set; }

        [ProtoMember(3)]
        public bool hideFull
        {
            get { return __pbn__hideFull.GetValueOrDefault(); }
            set { __pbn__hideFull = value; }
        }
        public bool ShouldSerializehideFull() => __pbn__hideFull != null;
        public void ResethideFull() => __pbn__hideFull = null;
        private bool? __pbn__hideFull;

        [ProtoMember(4)]
        public bool hideEmpty
        {
            get { return __pbn__hideEmpty.GetValueOrDefault(); }
            set { __pbn__hideEmpty = value; }
        }
        public bool ShouldSerializehideEmpty() => __pbn__hideEmpty != null;
        public void ResethideEmpty() => __pbn__hideEmpty = null;
        private bool? __pbn__hideEmpty;

        [ProtoMember(5, Name = @"playCount")]
        public List<RoomFilterPlayerCount> playCounts { get; } = new List<RoomFilterPlayerCount>();

        [ProtoMember(6, Name = @"restTime")]
        public List<RoomFilterRestTime> restTimes { get; } = new List<RoomFilterRestTime>();

        [ProtoMember(7, Name = @"roomTemple")]
        public List<RoomTemple> roomTemples { get; } = new List<RoomTemple>();

        [ProtoMember(8, Name = @"bb")]
        public long[] Bbs { get; set; }

        [ProtoMember(9, Name = @"ante")]
        public int Ante
        {
            get { return __pbn__Ante.GetValueOrDefault(); }
            set { __pbn__Ante = value; }
        }
        public bool ShouldSerializeAnte() => __pbn__Ante != null;
        public void ResetAnte() => __pbn__Ante = null;
        private int? __pbn__Ante;

        [ProtoMember(10, Name = @"straddle")]
        public int Straddle
        {
            get { return __pbn__Straddle.GetValueOrDefault(); }
            set { __pbn__Straddle = value; }
        }
        public bool ShouldSerializeStraddle() => __pbn__Straddle != null;
        public void ResetStraddle() => __pbn__Straddle = null;
        private int? __pbn__Straddle;

        [ProtoMember(11, IsRequired = true)]
        public int startRoomId { get; set; }

    }

    [ProtoContract]
    internal partial class ClubRoomInfoResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"rooms")]
        public List<Room> Rooms { get; } = new List<Room>();

        [ProtoMember(2, IsRequired = true)]
        public int pageSize { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int totalSize { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int startRoomId { get; set; }

        [ProtoMember(5)]
        [DefaultValue(EmptyCause.ClubActivity)]
        public EmptyCause emptyCause
        {
            get { return __pbn__emptyCause ?? EmptyCause.ClubActivity; }
            set { __pbn__emptyCause = value; }
        }
        public bool ShouldSerializeemptyCause() => __pbn__emptyCause != null;
        public void ResetemptyCause() => __pbn__emptyCause = null;
        private EmptyCause? __pbn__emptyCause;

        [ProtoMember(6, IsRequired = true)]
        public int startRoomCount { get; set; }

        [ProtoMember(7, Name = @"corpus")]
        public int Corpus
        {
            get { return __pbn__Corpus.GetValueOrDefault(); }
            set { __pbn__Corpus = value; }
        }
        public bool ShouldSerializeCorpus() => __pbn__Corpus != null;
        public void ResetCorpus() => __pbn__Corpus = null;
        private int? __pbn__Corpus;

    }

    [ProtoContract]
    internal partial class ShowPlayerInfoInRoomRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int targetPlayerId { get; set; }

        [ProtoMember(2)]
        public int roomId
        {
            get { return __pbn__roomId.GetValueOrDefault(); }
            set { __pbn__roomId = value; }
        }
        public bool ShouldSerializeroomId() => __pbn__roomId != null;
        public void ResetroomId() => __pbn__roomId = null;
        private int? __pbn__roomId;

        [ProtoMember(3)]
        public int roomType
        {
            get { return __pbn__roomType.GetValueOrDefault(); }
            set { __pbn__roomType = value; }
        }
        public bool ShouldSerializeroomType() => __pbn__roomType != null;
        public void ResetroomType() => __pbn__roomType = null;
        private int? __pbn__roomType;

        [ProtoMember(4)]
        public int playType
        {
            get { return __pbn__playType.GetValueOrDefault(); }
            set { __pbn__playType = value; }
        }
        public bool ShouldSerializeplayType() => __pbn__playType != null;
        public void ResetplayType() => __pbn__playType = null;
        private int? __pbn__playType;

        [ProtoMember(5)]
        public int gameId
        {
            get { return __pbn__gameId.GetValueOrDefault(); }
            set { __pbn__gameId = value; }
        }
        public bool ShouldSerializegameId() => __pbn__gameId != null;
        public void ResetgameId() => __pbn__gameId = null;
        private int? __pbn__gameId;

        [ProtoMember(6)]
        public int sitId
        {
            get { return __pbn__sitId.GetValueOrDefault(); }
            set { __pbn__sitId = value; }
        }
        public bool ShouldSerializesitId() => __pbn__sitId != null;
        public void ResetsitId() => __pbn__sitId = null;
        private int? __pbn__sitId;

    }

    [ProtoContract]
    internal partial class ShowPlayerInfoInRoomResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(3, Name = @"icon", IsRequired = true)]
        public string Icon { get; set; }

        [ProtoMember(4, Name = @"gender", IsRequired = true)]
        public int Gender { get; set; }

        [ProtoMember(5, Name = @"diamond")]
        public long Diamond
        {
            get { return __pbn__Diamond.GetValueOrDefault(); }
            set { __pbn__Diamond = value; }
        }
        public bool ShouldSerializeDiamond() => __pbn__Diamond != null;
        public void ResetDiamond() => __pbn__Diamond = null;
        private long? __pbn__Diamond;

        [ProtoMember(6, Name = @"gold")]
        public long Gold
        {
            get { return __pbn__Gold.GetValueOrDefault(); }
            set { __pbn__Gold = value; }
        }
        public bool ShouldSerializeGold() => __pbn__Gold != null;
        public void ResetGold() => __pbn__Gold = null;
        private long? __pbn__Gold;

        [ProtoMember(7, Name = @"signature")]
        [DefaultValue("")]
        public string Signature
        {
            get { return __pbn__Signature ?? ""; }
            set { __pbn__Signature = value; }
        }
        public bool ShouldSerializeSignature() => __pbn__Signature != null;
        public void ResetSignature() => __pbn__Signature = null;
        private string __pbn__Signature;

        [ProtoMember(8, IsRequired = true)]
        public int handCount { get; set; }

        [ProtoMember(9, IsRequired = true)]
        public string vpRate { get; set; }

        [ProtoMember(10, IsRequired = true)]
        public int joinRaceCount { get; set; }

        [ProtoMember(11, IsRequired = true)]
        public int rewardCount { get; set; }

        [ProtoMember(12, IsRequired = true)]
        public int takeMascot { get; set; }

        [ProtoMember(13, Name = @"haveMascot")]
        public int[] haveMascots { get; set; }

        [ProtoMember(14, Name = @"interactionItem")]
        public List<InteractionItem> interactionItems { get; } = new List<InteractionItem>();

        [ProtoMember(15)]
        public long masterScore
        {
            get { return __pbn__masterScore.GetValueOrDefault(); }
            set { __pbn__masterScore = value; }
        }
        public bool ShouldSerializemasterScore() => __pbn__masterScore != null;
        public void ResetmasterScore() => __pbn__masterScore = null;
        private long? __pbn__masterScore;

        [ProtoMember(16, Name = @"vip", IsRequired = true)]
        public int Vip { get; set; }

        [ProtoMember(17)]
        public PlayerItem costItem { get; set; }

        [ProtoMember(18)]
        public CareerProcessData careerProcessData { get; set; }

        [ProtoMember(19)]
        public int roomId
        {
            get { return __pbn__roomId.GetValueOrDefault(); }
            set { __pbn__roomId = value; }
        }
        public bool ShouldSerializeroomId() => __pbn__roomId != null;
        public void ResetroomId() => __pbn__roomId = null;
        private int? __pbn__roomId;

        [ProtoMember(20)]
        public int gameId
        {
            get { return __pbn__gameId.GetValueOrDefault(); }
            set { __pbn__gameId = value; }
        }
        public bool ShouldSerializegameId() => __pbn__gameId != null;
        public void ResetgameId() => __pbn__gameId = null;
        private int? __pbn__gameId;

        [ProtoMember(21)]
        public int sitId
        {
            get { return __pbn__sitId.GetValueOrDefault(); }
            set { __pbn__sitId = value; }
        }
        public bool ShouldSerializesitId() => __pbn__sitId != null;
        public void ResetsitId() => __pbn__sitId = null;
        private int? __pbn__sitId;

    }

    [ProtoContract]
    internal partial class DeductPlayersItemRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public PlayerItem costItem { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int targetPlayerId { get; set; }

        [ProtoMember(3)]
        public int roomType
        {
            get { return __pbn__roomType.GetValueOrDefault(); }
            set { __pbn__roomType = value; }
        }
        public bool ShouldSerializeroomType() => __pbn__roomType != null;
        public void ResetroomType() => __pbn__roomType = null;
        private int? __pbn__roomType;

        [ProtoMember(4)]
        public int playType
        {
            get { return __pbn__playType.GetValueOrDefault(); }
            set { __pbn__playType = value; }
        }
        public bool ShouldSerializeplayType() => __pbn__playType != null;
        public void ResetplayType() => __pbn__playType = null;
        private int? __pbn__playType;

    }

    [ProtoContract]
    internal partial class DeductPlayersItemResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public PlayerItem playerCurrentItem { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public CareerProcessData careerProcessData { get; set; }

    }

    [ProtoContract]
    internal partial class InteractionItem : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"index", IsRequired = true)]
        public int Index { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int costItemId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int costNum { get; set; }

    }

    [ProtoContract]
    internal partial class CancelSngApplyRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

    }

    [ProtoContract]
    internal partial class CancelSngApplyResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public bool outReuslt { get; set; }

    }

    [ProtoContract]
    internal partial class NotifyCancelSngApplyResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

    }

    [ProtoContract]
    internal partial class SngDetailRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

    }

    [ProtoContract]
    internal partial class SngDetailResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, Name = @"rank", IsRequired = true)]
        public int Rank { get; set; }

        [ProtoMember(3, Name = @"raceBlindTable")]
        public List<RaceBlindTable> raceBlindTables { get; } = new List<RaceBlindTable>();

        [ProtoMember(4, Name = @"sngBonusInfo")]
        public List<SngBonusInfo> sngBonusInfoes { get; } = new List<SngBonusInfo>();

        [ProtoMember(5, IsRequired = true)]
        public long allBonus { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int bonusType { get; set; }

        [ProtoMember(7, IsRequired = true)]
        public int floatRewardItemId { get; set; }

    }

    [ProtoContract]
    internal partial class SngBonusInfo : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int rankStart { get; set; }

        [ProtoMember(2, Name = @"gold")]
        public long Gold
        {
            get { return __pbn__Gold.GetValueOrDefault(); }
            set { __pbn__Gold = value; }
        }
        public bool ShouldSerializeGold() => __pbn__Gold != null;
        public void ResetGold() => __pbn__Gold = null;
        private long? __pbn__Gold;

        [ProtoMember(3)]
        [DefaultValue("")]
        public string itemsReward
        {
            get { return __pbn__itemsReward ?? ""; }
            set { __pbn__itemsReward = value; }
        }
        public bool ShouldSerializeitemsReward() => __pbn__itemsReward != null;
        public void ResetitemsReward() => __pbn__itemsReward = null;
        private string __pbn__itemsReward;

    }

    [ProtoContract]
    internal partial class NotifyTrusteeshipResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public int sitId { get; set; }

        [ProtoMember(5, Name = @"trusteeship", IsRequired = true)]
        public bool Trusteeship { get; set; }

    }

    [ProtoContract]
    internal partial class CancelTrusteeshipRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int sitId { get; set; }

    }

    [ProtoContract]
    internal partial class VideoInfoListRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int recordId { get; set; }

        [ProtoMember(2, Name = @"page", IsRequired = true)]
        public int Page { get; set; }

        [ProtoMember(3, Name = @"sort", IsRequired = true)]
        public int Sort { get; set; }

    }

    [ProtoContract]
    internal partial class VideoInfoListResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int recordId { get; set; }

        [ProtoMember(2, Name = @"page", IsRequired = true)]
        public int Page { get; set; }

        [ProtoMember(3, Name = @"videoInfo")]
        public List<VideoInfo> videoInfoes { get; } = new List<VideoInfo>();

        [ProtoMember(4, IsRequired = true)]
        public int perPageCount { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int totalCount { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public int roomType { get; set; }

    }

    [ProtoContract]
    internal partial class CollectVideoRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int recordId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int handCount { get; set; }

    }

    [ProtoContract]
    internal partial class CollectVideoResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int recordId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int handCount { get; set; }

    }

    [ProtoContract]
    internal partial class CancelCollectVideoRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int recordId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int handCount { get; set; }

    }

    [ProtoContract]
    internal partial class CancelCollectVideoResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int recordId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int handCount { get; set; }

    }

    [ProtoContract]
    internal partial class HandReviewCollectVideoRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int recordId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int handCount { get; set; }

    }

    [ProtoContract]
    internal partial class HandReviewCollectVideoResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int recordId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int handCount { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public bool isCollected { get; set; }

    }

    [ProtoContract]
    internal partial class CollectVideoListRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class CollectVideoListResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"videoInfo")]
        public List<VideoInfo> videoInfoes { get; } = new List<VideoInfo>();

        [ProtoMember(2, IsRequired = true)]
        public int collectedCount { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int allCollectCount { get; set; }

    }

    [ProtoContract]
    internal partial class VideoInfo : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int recordId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int handCount { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public long handBeginTime { get; set; }

        [ProtoMember(5)]
        public List<Card> holeCards { get; } = new List<Card>();

        [ProtoMember(6, IsRequired = true)]
        public int endHandPowerType { get; set; }

        [ProtoMember(7)]
        public List<Card> pubCards { get; } = new List<Card>();

        [ProtoMember(8, IsRequired = true)]
        public long selfProfit { get; set; }

        [ProtoMember(9, Name = @"collected", IsRequired = true)]
        public bool Collected { get; set; }

        [ProtoMember(10)]
        public int showPlayerId
        {
            get { return __pbn__showPlayerId.GetValueOrDefault(); }
            set { __pbn__showPlayerId = value; }
        }
        public bool ShouldSerializeshowPlayerId() => __pbn__showPlayerId != null;
        public void ResetshowPlayerId() => __pbn__showPlayerId = null;
        private int? __pbn__showPlayerId;

        [ProtoMember(11)]
        [DefaultValue("")]
        public string showPlayerName
        {
            get { return __pbn__showPlayerName ?? ""; }
            set { __pbn__showPlayerName = value; }
        }
        public bool ShouldSerializeshowPlayerName() => __pbn__showPlayerName != null;
        public void ResetshowPlayerName() => __pbn__showPlayerName = null;
        private string __pbn__showPlayerName;

        [ProtoMember(12, IsRequired = true)]
        public string roomName { get; set; }

        [ProtoMember(13, IsRequired = true)]
        public int floatRewardItemId { get; set; }

    }

    [ProtoContract]
    internal partial class VoiceRoomRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint roomId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint gameId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string voiceId { get; set; }

    }

    [ProtoContract]
    internal partial class VoiceRoomResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class VoiceRoomNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public uint playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public uint roomId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public uint gameId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string voiceId { get; set; }

    }

    [ProtoContract]
    internal partial class OpenWalletPayRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    }

    [ProtoContract]
    internal partial class OpenWalletPayResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string playerName { get; set; }

        [ProtoMember(3, Name = @"masterscore", IsRequired = true)]
        public long Masterscore { get; set; }

        [ProtoMember(4, Name = @"mainPayType")]
        public List<string> mainPayTypes { get; } = new List<string>();

        [ProtoMember(5, Name = @"otherPayType")]
        public List<string> otherPayTypes { get; } = new List<string>();

    }

    [ProtoContract]
    internal partial class PayRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"amount", IsRequired = true)]
        public int Amount { get; set; }

        [ProtoMember(2, Name = @"bankid", IsRequired = true)]
        public string Bankid { get; set; }

    }

    [ProtoContract]
    internal partial class PayResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"error", IsRequired = true)]
        public string Error { get; set; }

        [ProtoMember(2, Name = @"url", IsRequired = true)]
        public string Url { get; set; }

    }

    [ProtoContract]
    internal partial class OrderInfoRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"type", IsRequired = true)]
        public int Type { get; set; }

    }

    [ProtoContract]
    internal partial class OrderInfoResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public List<OrderInfo> orderInfos { get; } = new List<OrderInfo>();

    }

    [ProtoContract]
    internal partial class OrderInfo : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string orderId { get; set; }

        [ProtoMember(2, Name = @"time", IsRequired = true)]
        public string Time { get; set; }

        [ProtoMember(3, Name = @"amount", IsRequired = true)]
        public long Amount { get; set; }

        [ProtoMember(4, Name = @"status", IsRequired = true)]
        public int Status { get; set; }

        [ProtoMember(5, Name = @"type", IsRequired = true)]
        public int Type { get; set; }

    }

    [ProtoContract]
    internal partial class SetBankCardRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string cardId { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public string confirmCardId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public int bankInfo { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string trueName { get; set; }

    }

    [ProtoContract]
    internal partial class BankCardResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"masterscore", IsRequired = true)]
        public long Masterscore { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public int playerId { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public string bankId { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public string bankName { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public string trueName { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public uint drawCount { get; set; }
    }

    [ProtoContract]
    internal partial class OpenWalletDrawRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string walletPassword { get; set; }
    }

    [ProtoContract]
    internal partial class OpenWalletDrawResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public bool bindBackCard { get; set; }

        [ProtoMember(2, Name = @"masterscore")]
        public long Masterscore
        {
            get { return __pbn__Masterscore.GetValueOrDefault(); }
            set { __pbn__Masterscore = value; }
        }
        public bool ShouldSerializeMasterscore() => __pbn__Masterscore != null;
        public void ResetMasterscore() => __pbn__Masterscore = null;
        private long? __pbn__Masterscore;

        [ProtoMember(3)]
        public int playerId
        {
            get { return __pbn__playerId.GetValueOrDefault(); }
            set { __pbn__playerId = value; }
        }
        public bool ShouldSerializeplayerId() => __pbn__playerId != null;
        public void ResetplayerId() => __pbn__playerId = null;
        private int? __pbn__playerId;

        [ProtoMember(4)]
        [DefaultValue("")]
        public string bankId
        {
            get { return __pbn__bankId ?? ""; }
            set { __pbn__bankId = value; }
        }
        public bool ShouldSerializebankId() => __pbn__bankId != null;
        public void ResetbankId() => __pbn__bankId = null;
        private string __pbn__bankId;

        [ProtoMember(5)]
        [DefaultValue("")]
        public string bankName
        {
            get { return __pbn__bankName ?? ""; }
            set { __pbn__bankName = value; }
        }
        public bool ShouldSerializebankName() => __pbn__bankName != null;
        public void ResetbankName() => __pbn__bankName = null;
        private string __pbn__bankName;

        [ProtoMember(6)]
        [DefaultValue("")]
        public string trueName
        {
            get { return __pbn__trueName ?? ""; }
            set { __pbn__trueName = value; }
        }
        public bool ShouldSerializetrueName() => __pbn__trueName != null;
        public void ResettrueName() => __pbn__trueName = null;
        private string __pbn__trueName;

        [ProtoMember(7)]
        public uint drawCount
        {
            get { return __pbn__drawCount.GetValueOrDefault(); }
            set { __pbn__drawCount = value; }
        }
        public bool ShouldSerializedrawCount() => __pbn__drawCount != null;
        public void ResetdrawCount() => __pbn__drawCount = null;
        private uint? __pbn__drawCount;

    }

    [ProtoContract]
    internal partial class DrawRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"amount", IsRequired = true)]
        public uint Amount { get; set; }

    }

    [ProtoContract]
    internal partial class DrawResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public OrderInfo orderInfo { get; set; }

        [ProtoMember(2, Name = @"masterscore", IsRequired = true)]
        public long Masterscore { get; set; }

    }

    [ProtoContract]
    internal partial class DrawCallBackResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public bool isSuccess { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public OrderInfo orderInfo { get; set; }

    }

    [ProtoContract]
    internal partial class SetWalletPwdRequest : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, IsRequired = true)]
        public string walletPwd { get; set; }

        [ProtoMember(2, Name = @"captcha", IsRequired = true)]
        public string Captcha { get; set; }

        [ProtoMember(3, Name = @"phone")]
        [DefaultValue("")]
        public string Phone
        {
            get { return __pbn__Phone ?? ""; }
            set { __pbn__Phone = value; }
        }
        public bool ShouldSerializePhone() => __pbn__Phone != null;
        public void ResetPhone() => __pbn__Phone = null;
        private string __pbn__Phone;

        [ProtoMember(4)]
        [DefaultValue("")]
        public string nationCode
        {
            get { return __pbn__nationCode ?? ""; }
            set { __pbn__nationCode = value; }
        }
        public bool ShouldSerializenationCode() => __pbn__nationCode != null;
        public void ResetnationCode() => __pbn__nationCode = null;
        private string __pbn__nationCode;

    }

    [ProtoContract]
    internal partial class SetWalletPwdResponse : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"suc", IsRequired = true)]
        public bool Suc { get; set; }

    }

    [ProtoContract]
    internal partial class WorldMessageNotify : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public int contentCode
        {
            get { return __pbn__contentCode.GetValueOrDefault(); }
            set { __pbn__contentCode = value; }
        }
        public bool ShouldSerializecontentCode() => __pbn__contentCode != null;
        public void ResetcontentCode() => __pbn__contentCode = null;
        private int? __pbn__contentCode;

        [ProtoMember(2, Name = @"content")]
        [DefaultValue("")]
        public string Content
        {
            get { return __pbn__Content ?? ""; }
            set { __pbn__Content = value; }
        }
        public bool ShouldSerializeContent() => __pbn__Content != null;
        public void ResetContent() => __pbn__Content = null;
        private string __pbn__Content;

        [ProtoMember(3, Name = @"loop", IsRequired = true)]
        public int Loop { get; set; }

        [ProtoMember(4, Name = @"contentParam")]
        public List<contentParam> contentParams { get; } = new List<contentParam>();

        [ProtoMember(5)]
        public int notifyType
        {
            get { return __pbn__notifyType.GetValueOrDefault(); }
            set { __pbn__notifyType = value; }
        }
        public bool ShouldSerializenotifyType() => __pbn__notifyType != null;
        public void ResetnotifyType() => __pbn__notifyType = null;
        private int? __pbn__notifyType;

        [ProtoMember(6)]
        public int templateId
        {
            get { return __pbn__templateId.GetValueOrDefault(); }
            set { __pbn__templateId = value; }
        }
        public bool ShouldSerializetemplateId() => __pbn__templateId != null;
        public void ResettemplateId() => __pbn__templateId = null;
        private int? __pbn__templateId;

    }

    [ProtoContract]
    internal partial class contentParam : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"contentParam", IsRequired = true)]
        public string contentParamValue { get; set; }

    }

    [ProtoContract]
    internal enum Corpus
    {
        [ProtoEnum(Name = @"PRESIDENT")]
        President = 1,
        [ProtoEnum(Name = @"MANAGER")]
        Manager = 2,
        [ProtoEnum(Name = @"OBSERVER")]
        Observer = 3,
        [ProtoEnum(Name = @"NORMAL")]
        Normal = 4,
        [ProtoEnum(Name = @"UNJOIN")]
        Unjoin = 5,
    }

    [ProtoContract]
    internal enum ChatType
    {
        ChatClub = 1,
    }

    [ProtoContract]
    internal enum ApplStatus
    {
        [ProtoEnum(Name = @"WAIT")]
        Wait = 1,
        [ProtoEnum(Name = @"PASS")]
        Pass = 2,
        [ProtoEnum(Name = @"REFUSE")]
        Refuse = 3,
        [ProtoEnum(Name = @"NOT_APPLY")]
        NotApply = 4,
    }

    [ProtoContract]
    internal enum changeType
    {
        [ProtoEnum(Name = @"WITHDRAW")]
        Withdraw = 1,
        [ProtoEnum(Name = @"ADD")]
        Add = 2,
        [ProtoEnum(Name = @"HELP_REPAY")]
        HelpRepay = 3,
        [ProtoEnum(Name = @"REPAY")]
        Repay = 4,
        [ProtoEnum(Name = @"USE")]
        Use = 5,
    }

    [ProtoContract]
    internal enum InsuranceOption
    {
        SelectOuts = 1,
        UnSelectOuts = 2,
        SelectAll = 3,
        UnSelectAll = 4,
        BuyAmount = 5,
    }

    [ProtoContract]
    internal enum NoInsuranceTips
    {
        NoTips = 0,
        NoOuts = 1,
        PotNoWinner = 2,
        OutsLimit = 3,
        OmahaPlayerCountLimit = 4,
        OmahaPotPlayerLimit = 5,
    }

    [ProtoContract]
    internal enum MallShowType
    {
        Normal = 1,
        Hot = 2,
        Discount = 3,
    }

    [ProtoContract]
    internal enum PaymentType
    {
        [ProtoEnum(Name = @"diamonds60")]
        Diamonds60 = 1,
        [ProtoEnum(Name = @"diamonds300")]
        Diamonds300 = 2,
        [ProtoEnum(Name = @"diamonds1280")]
        Diamonds1280 = 3,
        [ProtoEnum(Name = @"diamonds2580")]
        Diamonds2580 = 4,
        [ProtoEnum(Name = @"diamonds5180")]
        Diamonds5180 = 5,
        [ProtoEnum(Name = @"diamonds12980")]
        Diamonds12980 = 6,
    }

    [ProtoContract]
    internal enum PayType
    {
        [ProtoEnum(Name = @"IAP")]
        Iap = 1,
        Wechat = 2,
        Fast = 3,
    }

    [ProtoContract]
    internal enum TransactionType
    {
        [ProtoEnum(Name = @"GRANT")]
        Grant = 1,
        [ProtoEnum(Name = @"CONTRIBUTION")]
        Contribution = 2,
        [ProtoEnum(Name = @"RECHARGE")]
        Recharge = 5,
        [ProtoEnum(Name = @"INSURANCE_REBATE")]
        InsuranceRebate = 6,
        [ProtoEnum(Name = @"SETTLEMENT_REBATE")]
        SettlementRebate = 7,
        [ProtoEnum(Name = @"REBATE")]
        Rebate = 8,
        [ProtoEnum(Name = @"WITHDRAW_CREDIT_SCORE")]
        WithdrawCreditScore = 9,
        [ProtoEnum(Name = @"ADD_CREDIT_SCORE")]
        AddCreditScore = 10,
        [ProtoEnum(Name = @"HELP_REPAY")]
        HelpRepay = 11,
        [ProtoEnum(Name = @"SYSTEM_REDUCE")]
        SystemReduce = 12,
        [ProtoEnum(Name = @"SETTLEMENT_SUBCLUB_REBATE")]
        SettlementSubclubRebate = 13,
        [ProtoEnum(Name = @"JACKPOT_REBATE")]
        JackpotRebate = 14,
        [ProtoEnum(Name = @"JACKPOT_REDUCE")]
        JackpotReduce = 15,
        [ProtoEnum(Name = @"JACKPOT_SETTLEMENT_REDUCE")]
        JackpotSettlementReduce = 16,
        [ProtoEnum(Name = @"JP_GM_ADD")]
        JpGmAdd = 17,
        [ProtoEnum(Name = @"JP_GM_REDUCE")]
        JpGmReduce = 18,
        [ProtoEnum(Name = @"SYSTEM_INCOME_MALL")]
        SystemIncomeMall = 19,
        [ProtoEnum(Name = @"GRANTED")]
        Granted = 20,
        [ProtoEnum(Name = @"CONTRIBUTIONED")]
        Contributioned = 21,
        [ProtoEnum(Name = @"HANDSREWARD")]
        Handsreward = 22,
        [ProtoEnum(Name = @"RANKREWARD")]
        Rankreward = 23,
        [ProtoEnum(Name = @"ITEMREVERT")]
        Itemrevert = 24,
        [ProtoEnum(Name = @"SYSTEM_RACE_REWARD")]
        SystemRaceReward = 25,
        [ProtoEnum(Name = @"REDPACKET_REWARD")]
        RedpacketReward = 26,
        [ProtoEnum(Name = @"RACESERVICEBACK")]
        Raceserviceback = 27,
        [ProtoEnum(Name = @"GRANT_TO_LOWER_CLUB")]
        GrantToLowerClub = 28,
        [ProtoEnum(Name = @"CLUB_CONTRIBUTE_TO_UPPER_CLUB")]
        ClubContributeToUpperClub = 29,
        [ProtoEnum(Name = @"UPPER_CLUB_GRANTED")]
        UpperClubGranted = 30,
        [ProtoEnum(Name = @"LOWER_CLUB_CONTRIBUTED")]
        LowerClubContributed = 31,
        [ProtoEnum(Name = @"HONOR_CLUB_COST")]
        HonorClubCost = 32,
        [ProtoEnum(Name = @"HONOR_CLUB_ADD")]
        HonorClubAdd = 33,
    }

    [ProtoContract]
    internal enum MTTPurchaseType
    {
        ReEntry = 1,
        ReBuy = 2,
        Addon = 3,
    }

    [ProtoContract]
    internal enum NotifyType
    {
        NotifyNotice = 1,
        NotifySystem = 2,
        NotifyClub = 3,
        NotifyAuthority = 4,
    }

    [ProtoContract]
    internal enum NotifyOption
    {
        ApplJoinClub = 1,
        QueryRecord = 2,
        QueryReward = 3,
        IntoMatchList = 4,
        BindPhone = 5,
        ClubIdCredit = 6,
        ClubMaserThreshold = 7,
        AuthorityPlayerRebuy = 8,
    }

    [ProtoContract]
    internal enum TokenType
    {
        TokenChat = 1,
    }

    [ProtoContract]
    internal enum ServerType
    {
        Chat = 1,
    }

    [ProtoContract]
    internal enum p2State
    {
        [ProtoEnum(Name = @"empty")]
        Empty = 1,
        [ProtoEnum(Name = @"notequal")]
        Notequal = 2,
        [ProtoEnum(Name = @"equal")]
        Equal = 3,
        needInput = 4,
        [ProtoEnum(Name = @"error")]
        Error = 5,
        [ProtoEnum(Name = @"ok")]
        Ok = 6,
    }

    [ProtoContract]
    internal enum RankInfoType
    {
        [ProtoEnum(Name = @"TYPE_TODAY")]
        TypeToday = 0,
        [ProtoEnum(Name = @"TYPE_YESTERDAY")]
        TypeYesterday = 1,
        [ProtoEnum(Name = @"TYPE_HISTORY_1ST")]
        TypeHistory1st = 2,
    }

    [ProtoContract]
    internal enum SignUpStatus
    {
        CanSignUp = 1,
        AlreadySignUp = 2,
        NotSignUp = 3,
        Revival = 4,
    }

    [ProtoContract]
    internal enum ReplayAction
    {
        Bet = 1,
        Call = 2,
        Fold = 3,
        Check = 4,
        Raise = 5,
        ReRaise = 6,
        AllIn = 7,
    }

    [ProtoContract]
    internal enum ReplayStage
    {
        PreFlop = 1,
        Flop = 2,
        Turn = 3,
        River = 4,
    }

    [ProtoContract]
    internal enum RoomListType
    {
        RoomListOfficial = 0,
        RoomListClub = 1,
        RoomListPersonal = 2,
    }

    [ProtoContract]
    internal enum UpdateType
    {
        Created = 1,
        Deleted = 2,
        Updated = 3,
    }

    [ProtoContract]
    internal enum EmptyCause
    {
        ClubActivity = 1,
        NoneResult = 2,
    }
#pragma warning restore CS1591, CS0612, CS3021, IDE1006
}