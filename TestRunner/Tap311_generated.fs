// Generated code
module rec ``TAP-0311``
open MyProj.ASN1.ASNType
type ``DataInterChange``  = 
    |TransferBatch of TransferBatch
    |Notification of Notification
    with static member ASN1 = createChoiceMeta<``DataInterChange``> None ["TransferBatch", ``TransferBatch``.ASN1; "Notification", ``Notification``.ASN1]


type ``TransferBatch``(* [Application 1] *) = {
    batchControlInfo : BatchControlInfo option;
    accountingInfo : AccountingInfo option;
    networkInfo : NetworkInfo option;
    messageDescriptionInfo : MessageDescriptionInfoList option;
    callEventDetails : CallEventDetailList option;
    auditControlInfo : AuditControlInfo option
} 
    with static member ASN1 = createSequenceMeta<``TransferBatch``> (Some { ClassNumber = 1; Class = Application }) [("batchControlInfo", ``BatchControlInfo``.ASN1, true);("accountingInfo", ``AccountingInfo``.ASN1, true);("networkInfo", ``NetworkInfo``.ASN1, true);("messageDescriptionInfo", ``MessageDescriptionInfoList``.ASN1, true);("callEventDetails", ``CallEventDetailList``.ASN1, true);("auditControlInfo", ``AuditControlInfo``.ASN1, true)]



type ``Notification``(* [Application 2] *) = {
    sender : Sender option;
    recipient : Recipient option;
    fileSequenceNumber : FileSequenceNumber option;
    rapFileSequenceNumber : RapFileSequenceNumber option;
    fileCreationTimeStamp : FileCreationTimeStamp option;
    fileAvailableTimeStamp : FileAvailableTimeStamp option;
    transferCutOffTimeStamp : TransferCutOffTimeStamp option;
    specificationVersionNumber : SpecificationVersionNumber option;
    releaseVersionNumber : ReleaseVersionNumber option;
    fileTypeIndicator : FileTypeIndicator option;
    operatorSpecInformation : OperatorSpecInfoList option
} 
    with static member ASN1 = createSequenceMeta<``Notification``> (Some { ClassNumber = 2; Class = Application }) [("sender", ``Sender``.ASN1, true);("recipient", ``Recipient``.ASN1, true);("fileSequenceNumber", ``FileSequenceNumber``.ASN1, true);("rapFileSequenceNumber", ``RapFileSequenceNumber``.ASN1, true);("fileCreationTimeStamp", ``FileCreationTimeStamp``.ASN1, true);("fileAvailableTimeStamp", ``FileAvailableTimeStamp``.ASN1, true);("transferCutOffTimeStamp", ``TransferCutOffTimeStamp``.ASN1, true);("specificationVersionNumber", ``SpecificationVersionNumber``.ASN1, true);("releaseVersionNumber", ``ReleaseVersionNumber``.ASN1, true);("fileTypeIndicator", ``FileTypeIndicator``.ASN1, true);("operatorSpecInformation", ``OperatorSpecInfoList``.ASN1, true)]


type ``CallEventDetailList``(* [Application 3] *) = { Items : CallEventDetail list } 
    with static member ASN1 = createSequenceOfMeta<``CallEventDetailList``> (Some { ClassNumber = 3; Class = Application }) (``CallEventDetail``.ASN1)
         static member create data : ``CallEventDetailList`` = { Items = data |> Seq.cast<``CallEventDetail``> |> Seq.toList }


type ``CallEventDetail``  = 
    |MobileOriginatedCall of MobileOriginatedCall
    |MobileTerminatedCall of MobileTerminatedCall
    |SupplServiceEvent of SupplServiceEvent
    |ServiceCentreUsage of ServiceCentreUsage
    |GprsCall of GprsCall
    |ContentTransaction of ContentTransaction
    |LocationService of LocationService
    with static member ASN1 = createChoiceMeta<``CallEventDetail``> None ["MobileOriginatedCall", ``MobileOriginatedCall``.ASN1; "MobileTerminatedCall", ``MobileTerminatedCall``.ASN1; "SupplServiceEvent", ``SupplServiceEvent``.ASN1; "ServiceCentreUsage", ``ServiceCentreUsage``.ASN1; "GprsCall", ``GprsCall``.ASN1; "ContentTransaction", ``ContentTransaction``.ASN1; "LocationService", ``LocationService``.ASN1]


type ``BatchControlInfo``(* [Application 4] *) = {
    sender : Sender option;
    recipient : Recipient option;
    fileSequenceNumber : FileSequenceNumber option;
    fileCreationTimeStamp : FileCreationTimeStamp option;
    transferCutOffTimeStamp : TransferCutOffTimeStamp option;
    fileAvailableTimeStamp : FileAvailableTimeStamp option;
    specificationVersionNumber : SpecificationVersionNumber option;
    releaseVersionNumber : ReleaseVersionNumber option;
    fileTypeIndicator : FileTypeIndicator option;
    rapFileSequenceNumber : RapFileSequenceNumber option;
    operatorSpecInformation : OperatorSpecInfoList option
} 
    with static member ASN1 = createSequenceMeta<``BatchControlInfo``> (Some { ClassNumber = 4; Class = Application }) [("sender", ``Sender``.ASN1, true);("recipient", ``Recipient``.ASN1, true);("fileSequenceNumber", ``FileSequenceNumber``.ASN1, true);("fileCreationTimeStamp", ``FileCreationTimeStamp``.ASN1, true);("transferCutOffTimeStamp", ``TransferCutOffTimeStamp``.ASN1, true);("fileAvailableTimeStamp", ``FileAvailableTimeStamp``.ASN1, true);("specificationVersionNumber", ``SpecificationVersionNumber``.ASN1, true);("releaseVersionNumber", ``ReleaseVersionNumber``.ASN1, true);("fileTypeIndicator", ``FileTypeIndicator``.ASN1, true);("rapFileSequenceNumber", ``RapFileSequenceNumber``.ASN1, true);("operatorSpecInformation", ``OperatorSpecInfoList``.ASN1, true)]



type ``AccountingInfo``(* [Application 5] *) = {
    taxation : TaxationList option;
    discounting : DiscountingList option;
    localCurrency : LocalCurrency option;
    tapCurrency : TapCurrency option;
    currencyConversionInfo : CurrencyConversionList option;
    tapDecimalPlaces : TapDecimalPlaces option
} 
    with static member ASN1 = createSequenceMeta<``AccountingInfo``> (Some { ClassNumber = 5; Class = Application }) [("taxation", ``TaxationList``.ASN1, true);("discounting", ``DiscountingList``.ASN1, true);("localCurrency", ``LocalCurrency``.ASN1, true);("tapCurrency", ``TapCurrency``.ASN1, true);("currencyConversionInfo", ``CurrencyConversionList``.ASN1, true);("tapDecimalPlaces", ``TapDecimalPlaces``.ASN1, true)]



type ``NetworkInfo``(* [Application 6] *) = {
    utcTimeOffsetInfo : UtcTimeOffsetInfoList option;
    recEntityInfo : RecEntityInfoList option
} 
    with static member ASN1 = createSequenceMeta<``NetworkInfo``> (Some { ClassNumber = 6; Class = Application }) [("utcTimeOffsetInfo", ``UtcTimeOffsetInfoList``.ASN1, true);("recEntityInfo", ``RecEntityInfoList``.ASN1, true)]


type ``MessageDescriptionInfoList``(* [Application 8] *) = { Items : MessageDescriptionInformation list } 
    with static member ASN1 = createSequenceOfMeta<``MessageDescriptionInfoList``> (Some { ClassNumber = 8; Class = Application }) (``MessageDescriptionInformation``.ASN1)
         static member create data : ``MessageDescriptionInfoList`` = { Items = data |> Seq.cast<``MessageDescriptionInformation``> |> Seq.toList }



type ``MobileOriginatedCall``(* [Application 9] *) = {
    basicCallInformation : MoBasicCallInformation option;
    locationInformation : LocationInformation option;
    equipmentIdentifier : ImeiOrEsn option;
    basicServiceUsedList : BasicServiceUsedList option;
    supplServiceCode : SupplServiceCode option;
    thirdPartyInformation : ThirdPartyInformation option;
    camelServiceUsed : CamelServiceUsed option;
    operatorSpecInformation : OperatorSpecInfoList option
} 
    with static member ASN1 = createSequenceMeta<``MobileOriginatedCall``> (Some { ClassNumber = 9; Class = Application }) [("basicCallInformation", ``MoBasicCallInformation``.ASN1, true);("locationInformation", ``LocationInformation``.ASN1, true);("equipmentIdentifier", ``ImeiOrEsn``.ASN1, true);("basicServiceUsedList", ``BasicServiceUsedList``.ASN1, true);("supplServiceCode", ``SupplServiceCode``.ASN1, true);("thirdPartyInformation", ``ThirdPartyInformation``.ASN1, true);("camelServiceUsed", ``CamelServiceUsed``.ASN1, true);("operatorSpecInformation", ``OperatorSpecInfoList``.ASN1, true)]



type ``MobileTerminatedCall``(* [Application 10] *) = {
    basicCallInformation : MtBasicCallInformation option;
    locationInformation : LocationInformation option;
    equipmentIdentifier : ImeiOrEsn option;
    basicServiceUsedList : BasicServiceUsedList option;
    camelServiceUsed : CamelServiceUsed option;
    operatorSpecInformation : OperatorSpecInfoList option
} 
    with static member ASN1 = createSequenceMeta<``MobileTerminatedCall``> (Some { ClassNumber = 10; Class = Application }) [("basicCallInformation", ``MtBasicCallInformation``.ASN1, true);("locationInformation", ``LocationInformation``.ASN1, true);("equipmentIdentifier", ``ImeiOrEsn``.ASN1, true);("basicServiceUsedList", ``BasicServiceUsedList``.ASN1, true);("camelServiceUsed", ``CamelServiceUsed``.ASN1, true);("operatorSpecInformation", ``OperatorSpecInfoList``.ASN1, true)]



type ``SupplServiceEvent``(* [Application 11] *) = {
    chargeableSubscriber : ChargeableSubscriber option;
    rapFileSequenceNumber : RapFileSequenceNumber option;
    locationInformation : LocationInformation option;
    equipmentIdentifier : ImeiOrEsn option;
    supplServiceUsed : SupplServiceUsed option;
    operatorSpecInformation : OperatorSpecInfoList option
} 
    with static member ASN1 = createSequenceMeta<``SupplServiceEvent``> (Some { ClassNumber = 11; Class = Application }) [("chargeableSubscriber", ``ChargeableSubscriber``.ASN1, true);("rapFileSequenceNumber", ``RapFileSequenceNumber``.ASN1, true);("locationInformation", ``LocationInformation``.ASN1, true);("equipmentIdentifier", ``ImeiOrEsn``.ASN1, true);("supplServiceUsed", ``SupplServiceUsed``.ASN1, true);("operatorSpecInformation", ``OperatorSpecInfoList``.ASN1, true)]



type ``ServiceCentreUsage``(* [Application 12] *) = {
    basicInformation : ScuBasicInformation option;
    rapFileSequenceNumber : RapFileSequenceNumber option;
    servingNetwork : ServingNetwork option;
    recEntityCode : RecEntityCode option;
    chargeInformation : ChargeInformation option;
    scuChargeType : ScuChargeType option;
    scuTimeStamps : ScuTimeStamps option;
    operatorSpecInformation : OperatorSpecInfoList option
} 
    with static member ASN1 = createSequenceMeta<``ServiceCentreUsage``> (Some { ClassNumber = 12; Class = Application }) [("basicInformation", ``ScuBasicInformation``.ASN1, true);("rapFileSequenceNumber", ``RapFileSequenceNumber``.ASN1, true);("servingNetwork", ``ServingNetwork``.ASN1, true);("recEntityCode", ``RecEntityCode``.ASN1, true);("chargeInformation", ``ChargeInformation``.ASN1, true);("scuChargeType", ``ScuChargeType``.ASN1, true);("scuTimeStamps", ``ScuTimeStamps``.ASN1, true);("operatorSpecInformation", ``OperatorSpecInfoList``.ASN1, true)]



type ``GprsCall``(* [Application 14] *) = {
    gprsBasicCallInformation : GprsBasicCallInformation option;
    gprsLocationInformation : GprsLocationInformation option;
    equipmentIdentifier : ImeiOrEsn option;
    gprsServiceUsed : GprsServiceUsed option;
    camelServiceUsed : CamelServiceUsed option;
    operatorSpecInformation : OperatorSpecInfoList option
} 
    with static member ASN1 = createSequenceMeta<``GprsCall``> (Some { ClassNumber = 14; Class = Application }) [("gprsBasicCallInformation", ``GprsBasicCallInformation``.ASN1, true);("gprsLocationInformation", ``GprsLocationInformation``.ASN1, true);("equipmentIdentifier", ``ImeiOrEsn``.ASN1, true);("gprsServiceUsed", ``GprsServiceUsed``.ASN1, true);("camelServiceUsed", ``CamelServiceUsed``.ASN1, true);("operatorSpecInformation", ``OperatorSpecInfoList``.ASN1, true)]



type ``ContentTransaction``(* [Application 17] *) = {
    contentTransactionBasicInfo : ContentTransactionBasicInfo option;
    chargedPartyInformation : ChargedPartyInformation option;
    servingPartiesInformation : ServingPartiesInformation option;
    contentServiceUsed : ContentServiceUsedList option;
    operatorSpecInformation : OperatorSpecInfoList option
} 
    with static member ASN1 = createSequenceMeta<``ContentTransaction``> (Some { ClassNumber = 17; Class = Application }) [("contentTransactionBasicInfo", ``ContentTransactionBasicInfo``.ASN1, true);("chargedPartyInformation", ``ChargedPartyInformation``.ASN1, true);("servingPartiesInformation", ``ServingPartiesInformation``.ASN1, true);("contentServiceUsed", ``ContentServiceUsedList``.ASN1, true);("operatorSpecInformation", ``OperatorSpecInfoList``.ASN1, true)]



type ``LocationService``(* [Application 297] *) = {
    rapFileSequenceNumber : RapFileSequenceNumber option;
    recEntityCode : RecEntityCode option;
    callReference : CallReference option;
    trackingCustomerInformation : TrackingCustomerInformation option;
    lCSSPInformation : LCSSPInformation option;
    trackedCustomerInformation : TrackedCustomerInformation option;
    locationServiceUsage : LocationServiceUsage option;
    operatorSpecInformation : OperatorSpecInfoList option
} 
    with static member ASN1 = createSequenceMeta<``LocationService``> (Some { ClassNumber = 297; Class = Application }) [("rapFileSequenceNumber", ``RapFileSequenceNumber``.ASN1, true);("recEntityCode", ``RecEntityCode``.ASN1, true);("callReference", ``CallReference``.ASN1, true);("trackingCustomerInformation", ``TrackingCustomerInformation``.ASN1, true);("lCSSPInformation", ``LCSSPInformation``.ASN1, true);("trackedCustomerInformation", ``TrackedCustomerInformation``.ASN1, true);("locationServiceUsage", ``LocationServiceUsage``.ASN1, true);("operatorSpecInformation", ``OperatorSpecInfoList``.ASN1, true)]



type ``AuditControlInfo``(* [Application 15] *) = {
    earliestCallTimeStamp : EarliestCallTimeStamp option;
    latestCallTimeStamp : LatestCallTimeStamp option;
    totalCharge : TotalCharge option;
    totalChargeRefund : TotalChargeRefund option;
    totalTaxRefund : TotalTaxRefund option;
    totalTaxValue : TotalTaxValue option;
    totalDiscountValue : TotalDiscountValue option;
    totalDiscountRefund : TotalDiscountRefund option;
    totalAdvisedChargeValueList : TotalAdvisedChargeValueList option;
    callEventDetailsCount : CallEventDetailsCount option;
    operatorSpecInformation : OperatorSpecInfoList option
} 
    with static member ASN1 = createSequenceMeta<``AuditControlInfo``> (Some { ClassNumber = 15; Class = Application }) [("earliestCallTimeStamp", ``EarliestCallTimeStamp``.ASN1, true);("latestCallTimeStamp", ``LatestCallTimeStamp``.ASN1, true);("totalCharge", ``TotalCharge``.ASN1, true);("totalChargeRefund", ``TotalChargeRefund``.ASN1, true);("totalTaxRefund", ``TotalTaxRefund``.ASN1, true);("totalTaxValue", ``TotalTaxValue``.ASN1, true);("totalDiscountValue", ``TotalDiscountValue``.ASN1, true);("totalDiscountRefund", ``TotalDiscountRefund``.ASN1, true);("totalAdvisedChargeValueList", ``TotalAdvisedChargeValueList``.ASN1, true);("callEventDetailsCount", ``CallEventDetailsCount``.ASN1, true);("operatorSpecInformation", ``OperatorSpecInfoList``.ASN1, true)]


type ``AccessPointNameNI``(* [Application 261] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``AccessPointNameNI``> (Some { ClassNumber = 261; Class = Application })
         static member create data : ``AccessPointNameNI`` = { Item = ``AsciiString``.create data }


type ``AccessPointNameOI``(* [Application 262] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``AccessPointNameOI``> (Some { ClassNumber = 262; Class = Application })
         static member create data : ``AccessPointNameOI`` = { Item = ``AsciiString``.create data }


type ``ActualDeliveryTimeStamp``(* [Application 302] *) = { Item : ``DateTime`` }
    with static member ASN1 = createReferenceMeta<``ActualDeliveryTimeStamp``> (Some { ClassNumber = 302; Class = Application }) "DateTime" (``DateTime``.ASN1)
         static member create data : ``ActualDeliveryTimeStamp`` = { Item = data }


type ``AddressStringDigits`` = { Item : ``BCDString``  }
    with static member ASN1 = createPrimitiveMeta<``AddressStringDigits``> None
         static member create data : ``AddressStringDigits`` = { Item = ``BCDString``.create data }

type ``AdvisedCharge``(* [Application 349] *) = { Item : ``Charge``  }
    with static member ASN1 = createPrimitiveMeta<``AdvisedCharge``> (Some { ClassNumber = 349; Class = Application })
         static member create data : ``AdvisedCharge`` = { Item = ``Charge``.create data }


type ``AdvisedChargeCurrency``(* [Application 348] *) = { Item : ``Currency``  }
    with static member ASN1 = createPrimitiveMeta<``AdvisedChargeCurrency``> (Some { ClassNumber = 348; Class = Application })
         static member create data : ``AdvisedChargeCurrency`` = { Item = ``Currency``.create data }



type ``AdvisedChargeInformation``(* [Application 351] *) = {
    paidIndicator : PaidIndicator option;
    paymentMethod : PaymentMethod option;
    advisedChargeCurrency : AdvisedChargeCurrency option;
    advisedCharge : AdvisedCharge option;
    commission : Commission option
} 
    with static member ASN1 = createSequenceMeta<``AdvisedChargeInformation``> (Some { ClassNumber = 351; Class = Application }) [("paidIndicator", ``PaidIndicator``.ASN1, true);("paymentMethod", ``PaymentMethod``.ASN1, true);("advisedChargeCurrency", ``AdvisedChargeCurrency``.ASN1, true);("advisedCharge", ``AdvisedCharge``.ASN1, true);("commission", ``Commission``.ASN1, true)]


type ``AgeOfLocation``(* [Application 396] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``AgeOfLocation``> (Some { ClassNumber = 396; Class = Application })
         static member create data : ``AgeOfLocation`` = { Item = ``Integer``.create data }



type ``BasicService``(* [Application 36] *) = {
    serviceCode : BasicServiceCode option;
    transparencyIndicator : TransparencyIndicator option;
    fnur : Fnur option;
    userProtocolIndicator : UserProtocolIndicator option;
    guaranteedBitRate : GuaranteedBitRate option;
    maximumBitRate : MaximumBitRate option
} 
    with static member ASN1 = createSequenceMeta<``BasicService``> (Some { ClassNumber = 36; Class = Application }) [("serviceCode", ``BasicServiceCode``.ASN1, true);("transparencyIndicator", ``TransparencyIndicator``.ASN1, true);("fnur", ``Fnur``.ASN1, true);("userProtocolIndicator", ``UserProtocolIndicator``.ASN1, true);("guaranteedBitRate", ``GuaranteedBitRate``.ASN1, true);("maximumBitRate", ``MaximumBitRate``.ASN1, true)]


type ``BasicServiceCode`` (* [Application 426] *) = 
    |TeleServiceCode of TeleServiceCode
    |BearerServiceCode of BearerServiceCode
    with static member ASN1 = createChoiceMeta<``BasicServiceCode``> (Some { ClassNumber = 426; Class = Application }) ["TeleServiceCode", ``TeleServiceCode``.ASN1; "BearerServiceCode", ``BearerServiceCode``.ASN1]


type ``BasicServiceCodeList``(* [Application 37] *) = { Items : BasicServiceCode list } 
    with static member ASN1 = createSequenceOfMeta<``BasicServiceCodeList``> (Some { ClassNumber = 37; Class = Application }) (``BasicServiceCode``.ASN1)
         static member create data : ``BasicServiceCodeList`` = { Items = data |> Seq.cast<``BasicServiceCode``> |> Seq.toList }



type ``BasicServiceUsed``(* [Application 39] *) = {
    basicService : BasicService option;
    chargingTimeStamp : ChargingTimeStamp option;
    chargeInformationList : ChargeInformationList option;
    hSCSDIndicator : HSCSDIndicator option
} 
    with static member ASN1 = createSequenceMeta<``BasicServiceUsed``> (Some { ClassNumber = 39; Class = Application }) [("basicService", ``BasicService``.ASN1, true);("chargingTimeStamp", ``ChargingTimeStamp``.ASN1, true);("chargeInformationList", ``ChargeInformationList``.ASN1, true);("hSCSDIndicator", ``HSCSDIndicator``.ASN1, true)]


type ``BasicServiceUsedList``(* [Application 38] *) = { Items : BasicServiceUsed list } 
    with static member ASN1 = createSequenceOfMeta<``BasicServiceUsedList``> (Some { ClassNumber = 38; Class = Application }) (``BasicServiceUsed``.ASN1)
         static member create data : ``BasicServiceUsedList`` = { Items = data |> Seq.cast<``BasicServiceUsed``> |> Seq.toList }


type ``BearerServiceCode``(* [Application 40] *) = { Item : ``HexString``  }
    with static member ASN1 = createPrimitiveMeta<``BearerServiceCode``> (Some { ClassNumber = 40; Class = Application })
         static member create data : ``BearerServiceCode`` = { Item = ``HexString``.create data }


type ``CalledNumber``(* [Application 407] *) = { Item : ``AddressStringDigits``  }
    with static member ASN1 = createPrimitiveMeta<``CalledNumber``> (Some { ClassNumber = 407; Class = Application })
         static member create data : ``CalledNumber`` = { Item = ``AddressStringDigits``.create data }


type ``CalledPlace``(* [Application 42] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``CalledPlace``> (Some { ClassNumber = 42; Class = Application })
         static member create data : ``CalledPlace`` = { Item = ``AsciiString``.create data }


type ``CalledRegion``(* [Application 46] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``CalledRegion``> (Some { ClassNumber = 46; Class = Application })
         static member create data : ``CalledRegion`` = { Item = ``AsciiString``.create data }


type ``CallEventDetailsCount``(* [Application 43] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``CallEventDetailsCount``> (Some { ClassNumber = 43; Class = Application })
         static member create data : ``CallEventDetailsCount`` = { Item = ``Integer``.create data }


type ``CallEventStartTimeStamp``(* [Application 44] *) = { Item : ``DateTime`` }
    with static member ASN1 = createReferenceMeta<``CallEventStartTimeStamp``> (Some { ClassNumber = 44; Class = Application }) "DateTime" (``DateTime``.ASN1)
         static member create data : ``CallEventStartTimeStamp`` = { Item = data }


type ``CallingNumber``(* [Application 405] *) = { Item : ``AddressStringDigits``  }
    with static member ASN1 = createPrimitiveMeta<``CallingNumber``> (Some { ClassNumber = 405; Class = Application })
         static member create data : ``CallingNumber`` = { Item = ``AddressStringDigits``.create data }



type ``CallOriginator``(* [Application 41] *) = {
    callingNumber : CallingNumber option;
    clirIndicator : ClirIndicator option;
    sMSOriginator : SMSOriginator option
} 
    with static member ASN1 = createSequenceMeta<``CallOriginator``> (Some { ClassNumber = 41; Class = Application }) [("callingNumber", ``CallingNumber``.ASN1, true);("clirIndicator", ``ClirIndicator``.ASN1, true);("sMSOriginator", ``SMSOriginator``.ASN1, true)]


type ``CallReference``(* [Application 45] *) = { Item : OctetString }
    with static member ASN1 = createPrimitiveMeta<``CallReference``> (Some { ClassNumber = 45; Class = Application })
         static member create data : ``CallReference`` = { Item = ``OctetString``.create data }



type ``CallTypeGroup``(* [Application 258] *) = {
    callTypeLevel1 : CallTypeLevel1 option;
    callTypeLevel2 : CallTypeLevel2 option;
    callTypeLevel3 : CallTypeLevel3 option
} 
    with static member ASN1 = createSequenceMeta<``CallTypeGroup``> (Some { ClassNumber = 258; Class = Application }) [("callTypeLevel1", ``CallTypeLevel1``.ASN1, true);("callTypeLevel2", ``CallTypeLevel2``.ASN1, true);("callTypeLevel3", ``CallTypeLevel3``.ASN1, true)]


type ``CallTypeLevel1``(* [Application 259] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``CallTypeLevel1``> (Some { ClassNumber = 259; Class = Application })
         static member create data : ``CallTypeLevel1`` = { Item = ``Integer``.create data }


type ``CallTypeLevel2``(* [Application 255] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``CallTypeLevel2``> (Some { ClassNumber = 255; Class = Application })
         static member create data : ``CallTypeLevel2`` = { Item = ``Integer``.create data }


type ``CallTypeLevel3``(* [Application 256] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``CallTypeLevel3``> (Some { ClassNumber = 256; Class = Application })
         static member create data : ``CallTypeLevel3`` = { Item = ``Integer``.create data }


type ``CamelDestinationNumber``(* [Application 404] *) = { Item : ``AddressStringDigits``  }
    with static member ASN1 = createPrimitiveMeta<``CamelDestinationNumber``> (Some { ClassNumber = 404; Class = Application })
         static member create data : ``CamelDestinationNumber`` = { Item = ``AddressStringDigits``.create data }


type ``CamelInvocationFee``(* [Application 422] *) = { Item : ``AbsoluteAmount``  }
    with static member ASN1 = createPrimitiveMeta<``CamelInvocationFee``> (Some { ClassNumber = 422; Class = Application })
         static member create data : ``CamelInvocationFee`` = { Item = ``AbsoluteAmount``.create data }


type ``CamelServiceKey``(* [Application 55] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``CamelServiceKey``> (Some { ClassNumber = 55; Class = Application })
         static member create data : ``CamelServiceKey`` = { Item = ``Integer``.create data }


type ``CamelServiceLevel``(* [Application 56] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``CamelServiceLevel``> (Some { ClassNumber = 56; Class = Application })
         static member create data : ``CamelServiceLevel`` = { Item = ``Integer``.create data }



type ``CamelServiceUsed``(* [Application 57] *) = {
    camelServiceLevel : CamelServiceLevel option;
    camelServiceKey : CamelServiceKey option;
    defaultCallHandling : DefaultCallHandlingIndicator option;
    exchangeRateCode : ExchangeRateCode option;
    taxInformation : TaxInformationList option;
    discountInformation : DiscountInformation option;
    camelInvocationFee : CamelInvocationFee option;
    threeGcamelDestination : ThreeGcamelDestination option;
    cseInformation : CseInformation option
} 
    with static member ASN1 = createSequenceMeta<``CamelServiceUsed``> (Some { ClassNumber = 57; Class = Application }) [("camelServiceLevel", ``CamelServiceLevel``.ASN1, true);("camelServiceKey", ``CamelServiceKey``.ASN1, true);("defaultCallHandling", ``DefaultCallHandlingIndicator``.ASN1, true);("exchangeRateCode", ``ExchangeRateCode``.ASN1, true);("taxInformation", ``TaxInformationList``.ASN1, true);("discountInformation", ``DiscountInformation``.ASN1, true);("camelInvocationFee", ``CamelInvocationFee``.ASN1, true);("threeGcamelDestination", ``ThreeGcamelDestination``.ASN1, true);("cseInformation", ``CseInformation``.ASN1, true)]


type ``CauseForTerm``(* [Application 58] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``CauseForTerm``> (Some { ClassNumber = 58; Class = Application })
         static member create data : ``CauseForTerm`` = { Item = ``Integer``.create data }


type ``CellId``(* [Application 59] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``CellId``> (Some { ClassNumber = 59; Class = Application })
         static member create data : ``CellId`` = { Item = ``Integer``.create data }


type ``Charge``(* [Application 62] *) = { Item : ``AbsoluteAmount``  }
    with static member ASN1 = createPrimitiveMeta<``Charge``> (Some { ClassNumber = 62; Class = Application })
         static member create data : ``Charge`` = { Item = ``AbsoluteAmount``.create data }


type ``ChargeableSubscriber`` (* [Application 427] *) = 
    |SimChargeableSubscriber of SimChargeableSubscriber
    |MinChargeableSubscriber of MinChargeableSubscriber
    with static member ASN1 = createChoiceMeta<``ChargeableSubscriber``> (Some { ClassNumber = 427; Class = Application }) ["SimChargeableSubscriber", ``SimChargeableSubscriber``.ASN1; "MinChargeableSubscriber", ``MinChargeableSubscriber``.ASN1]


type ``ChargeableUnits``(* [Application 65] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``ChargeableUnits``> (Some { ClassNumber = 65; Class = Application })
         static member create data : ``ChargeableUnits`` = { Item = ``Integer``.create data }



type ``ChargeDetail``(* [Application 63] *) = {
    chargeType : ChargeType option;
    charge : Charge option;
    chargeableUnits : ChargeableUnits option;
    chargedUnits : ChargedUnits option;
    chargeDetailTimeStamp : ChargeDetailTimeStamp option
} 
    with static member ASN1 = createSequenceMeta<``ChargeDetail``> (Some { ClassNumber = 63; Class = Application }) [("chargeType", ``ChargeType``.ASN1, true);("charge", ``Charge``.ASN1, true);("chargeableUnits", ``ChargeableUnits``.ASN1, true);("chargedUnits", ``ChargedUnits``.ASN1, true);("chargeDetailTimeStamp", ``ChargeDetailTimeStamp``.ASN1, true)]


type ``ChargeDetailList``(* [Application 64] *) = { Items : ChargeDetail list } 
    with static member ASN1 = createSequenceOfMeta<``ChargeDetailList``> (Some { ClassNumber = 64; Class = Application }) (``ChargeDetail``.ASN1)
         static member create data : ``ChargeDetailList`` = { Items = data |> Seq.cast<``ChargeDetail``> |> Seq.toList }


type ``ChargeDetailTimeStamp``(* [Application 410] *) = { Item : ``ChargingTimeStamp`` }
    with static member ASN1 = createReferenceMeta<``ChargeDetailTimeStamp``> (Some { ClassNumber = 410; Class = Application }) "ChargingTimeStamp" (``ChargingTimeStamp``.ASN1)
         static member create data : ``ChargeDetailTimeStamp`` = { Item = data }


type ``ChargedItem``(* [Application 66] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``ChargedItem``> (Some { ClassNumber = 66; Class = Application })
         static member create data : ``ChargedItem`` = { Item = ``AsciiString``.create data }



type ``ChargedPartyEquipment``(* [Application 323] *) = {
    equipmentIdType : EquipmentIdType option;
    equipmentId : EquipmentId option
} 
    with static member ASN1 = createSequenceMeta<``ChargedPartyEquipment``> (Some { ClassNumber = 323; Class = Application }) [("equipmentIdType", ``EquipmentIdType``.ASN1, true);("equipmentId", ``EquipmentId``.ASN1, true)]



type ``ChargedPartyHomeIdentification``(* [Application 313] *) = {
    homeIdType : HomeIdType option;
    homeIdentifier : HomeIdentifier option
} 
    with static member ASN1 = createSequenceMeta<``ChargedPartyHomeIdentification``> (Some { ClassNumber = 313; Class = Application }) [("homeIdType", ``HomeIdType``.ASN1, true);("homeIdentifier", ``HomeIdentifier``.ASN1, true)]


type ``ChargedPartyHomeIdList``(* [Application 314] *) = { Items : ChargedPartyHomeIdentification list } 
    with static member ASN1 = createSequenceOfMeta<``ChargedPartyHomeIdList``> (Some { ClassNumber = 314; Class = Application }) (``ChargedPartyHomeIdentification``.ASN1)
         static member create data : ``ChargedPartyHomeIdList`` = { Items = data |> Seq.cast<``ChargedPartyHomeIdentification``> |> Seq.toList }



type ``ChargedPartyIdentification``(* [Application 309] *) = {
    chargedPartyIdType : ChargedPartyIdType option;
    chargedPartyIdentifier : ChargedPartyIdentifier option
} 
    with static member ASN1 = createSequenceMeta<``ChargedPartyIdentification``> (Some { ClassNumber = 309; Class = Application }) [("chargedPartyIdType", ``ChargedPartyIdType``.ASN1, true);("chargedPartyIdentifier", ``ChargedPartyIdentifier``.ASN1, true)]


type ``ChargedPartyIdentifier``(* [Application 287] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``ChargedPartyIdentifier``> (Some { ClassNumber = 287; Class = Application })
         static member create data : ``ChargedPartyIdentifier`` = { Item = ``AsciiString``.create data }


type ``ChargedPartyIdList``(* [Application 310] *) = { Items : ChargedPartyIdentification list } 
    with static member ASN1 = createSequenceOfMeta<``ChargedPartyIdList``> (Some { ClassNumber = 310; Class = Application }) (``ChargedPartyIdentification``.ASN1)
         static member create data : ``ChargedPartyIdList`` = { Items = data |> Seq.cast<``ChargedPartyIdentification``> |> Seq.toList }


type ``ChargedPartyIdType``(* [Application 305] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``ChargedPartyIdType``> (Some { ClassNumber = 305; Class = Application })
         static member create data : ``ChargedPartyIdType`` = { Item = ``Integer``.create data }



type ``ChargedPartyInformation``(* [Application 324] *) = {
    chargedPartyIdList : ChargedPartyIdList option;
    chargedPartyHomeIdList : ChargedPartyHomeIdList option;
    chargedPartyLocationList : ChargedPartyLocationList option;
    chargedPartyEquipment : ChargedPartyEquipment option
} 
    with static member ASN1 = createSequenceMeta<``ChargedPartyInformation``> (Some { ClassNumber = 324; Class = Application }) [("chargedPartyIdList", ``ChargedPartyIdList``.ASN1, true);("chargedPartyHomeIdList", ``ChargedPartyHomeIdList``.ASN1, true);("chargedPartyLocationList", ``ChargedPartyLocationList``.ASN1, true);("chargedPartyEquipment", ``ChargedPartyEquipment``.ASN1, true)]



type ``ChargedPartyLocation``(* [Application 320] *) = {
    locationIdType : LocationIdType option;
    locationIdentifier : LocationIdentifier option
} 
    with static member ASN1 = createSequenceMeta<``ChargedPartyLocation``> (Some { ClassNumber = 320; Class = Application }) [("locationIdType", ``LocationIdType``.ASN1, true);("locationIdentifier", ``LocationIdentifier``.ASN1, true)]


type ``ChargedPartyLocationList``(* [Application 321] *) = { Items : ChargedPartyLocation list } 
    with static member ASN1 = createSequenceOfMeta<``ChargedPartyLocationList``> (Some { ClassNumber = 321; Class = Application }) (``ChargedPartyLocation``.ASN1)
         static member create data : ``ChargedPartyLocationList`` = { Items = data |> Seq.cast<``ChargedPartyLocation``> |> Seq.toList }


type ``ChargedPartyStatus``(* [Application 67] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``ChargedPartyStatus``> (Some { ClassNumber = 67; Class = Application })
         static member create data : ``ChargedPartyStatus`` = { Item = ``Integer``.create data }


type ``ChargedUnits``(* [Application 68] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``ChargedUnits``> (Some { ClassNumber = 68; Class = Application })
         static member create data : ``ChargedUnits`` = { Item = ``Integer``.create data }



type ``ChargeInformation``(* [Application 69] *) = {
    chargedItem : ChargedItem option;
    exchangeRateCode : ExchangeRateCode option;
    callTypeGroup : CallTypeGroup option;
    chargeDetailList : ChargeDetailList option;
    taxInformation : TaxInformationList option;
    discountInformation : DiscountInformation option
} 
    with static member ASN1 = createSequenceMeta<``ChargeInformation``> (Some { ClassNumber = 69; Class = Application }) [("chargedItem", ``ChargedItem``.ASN1, true);("exchangeRateCode", ``ExchangeRateCode``.ASN1, true);("callTypeGroup", ``CallTypeGroup``.ASN1, true);("chargeDetailList", ``ChargeDetailList``.ASN1, true);("taxInformation", ``TaxInformationList``.ASN1, true);("discountInformation", ``DiscountInformation``.ASN1, true)]


type ``ChargeInformationList``(* [Application 70] *) = { Items : ChargeInformation list } 
    with static member ASN1 = createSequenceOfMeta<``ChargeInformationList``> (Some { ClassNumber = 70; Class = Application }) (``ChargeInformation``.ASN1)
         static member create data : ``ChargeInformationList`` = { Items = data |> Seq.cast<``ChargeInformation``> |> Seq.toList }


type ``ChargeRefundIndicator``(* [Application 344] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``ChargeRefundIndicator``> (Some { ClassNumber = 344; Class = Application })
         static member create data : ``ChargeRefundIndicator`` = { Item = ``Integer``.create data }


type ``ChargeType``(* [Application 71] *) = { Item : ``NumberString``  }
    with static member ASN1 = createPrimitiveMeta<``ChargeType``> (Some { ClassNumber = 71; Class = Application })
         static member create data : ``ChargeType`` = { Item = ``NumberString``.create data }


type ``ChargingId``(* [Application 72] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``ChargingId``> (Some { ClassNumber = 72; Class = Application })
         static member create data : ``ChargingId`` = { Item = ``Integer``.create data }


type ``ChargingPoint``(* [Application 73] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``ChargingPoint``> (Some { ClassNumber = 73; Class = Application })
         static member create data : ``ChargingPoint`` = { Item = ``AsciiString``.create data }


type ``ChargingTimeStamp``(* [Application 74] *) = { Item : ``DateTime`` }
    with static member ASN1 = createReferenceMeta<``ChargingTimeStamp``> (Some { ClassNumber = 74; Class = Application }) "DateTime" (``DateTime``.ASN1)
         static member create data : ``ChargingTimeStamp`` = { Item = data }


type ``ClirIndicator``(* [Application 75] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``ClirIndicator``> (Some { ClassNumber = 75; Class = Application })
         static member create data : ``ClirIndicator`` = { Item = ``Integer``.create data }


type ``Commission``(* [Application 350] *) = { Item : ``Charge``  }
    with static member ASN1 = createPrimitiveMeta<``Commission``> (Some { ClassNumber = 350; Class = Application })
         static member create data : ``Commission`` = { Item = ``Charge``.create data }


type ``CompletionTimeStamp``(* [Application 76] *) = { Item : ``DateTime`` }
    with static member ASN1 = createReferenceMeta<``CompletionTimeStamp``> (Some { ClassNumber = 76; Class = Application }) "DateTime" (``DateTime``.ASN1)
         static member create data : ``CompletionTimeStamp`` = { Item = data }


type ``ContentChargingPoint``(* [Application 345] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``ContentChargingPoint``> (Some { ClassNumber = 345; Class = Application })
         static member create data : ``ContentChargingPoint`` = { Item = ``Integer``.create data }



type ``ContentProvider``(* [Application 327] *) = {
    contentProviderIdType : ContentProviderIdType option;
    contentProviderIdentifier : ContentProviderIdentifier option
} 
    with static member ASN1 = createSequenceMeta<``ContentProvider``> (Some { ClassNumber = 327; Class = Application }) [("contentProviderIdType", ``ContentProviderIdType``.ASN1, true);("contentProviderIdentifier", ``ContentProviderIdentifier``.ASN1, true)]


type ``ContentProviderIdentifier``(* [Application 292] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``ContentProviderIdentifier``> (Some { ClassNumber = 292; Class = Application })
         static member create data : ``ContentProviderIdentifier`` = { Item = ``AsciiString``.create data }


type ``ContentProviderIdList``(* [Application 328] *) = { Items : ContentProvider list } 
    with static member ASN1 = createSequenceOfMeta<``ContentProviderIdList``> (Some { ClassNumber = 328; Class = Application }) (``ContentProvider``.ASN1)
         static member create data : ``ContentProviderIdList`` = { Items = data |> Seq.cast<``ContentProvider``> |> Seq.toList }


type ``ContentProviderIdType``(* [Application 291] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``ContentProviderIdType``> (Some { ClassNumber = 291; Class = Application })
         static member create data : ``ContentProviderIdType`` = { Item = ``Integer``.create data }


type ``ContentProviderName``(* [Application 334] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``ContentProviderName``> (Some { ClassNumber = 334; Class = Application })
         static member create data : ``ContentProviderName`` = { Item = ``AsciiString``.create data }



type ``ContentServiceUsed``(* [Application 352] *) = {
    contentTransactionCode : ContentTransactionCode option;
    contentTransactionType : ContentTransactionType option;
    objectType : ObjectType option;
    transactionDescriptionSupp : TransactionDescriptionSupp option;
    transactionShortDescription : TransactionShortDescription option;
    transactionDetailDescription : TransactionDetailDescription option;
    transactionIdentifier : TransactionIdentifier option;
    transactionAuthCode : TransactionAuthCode option;
    dataVolumeIncoming : DataVolumeIncoming option;
    dataVolumeOutgoing : DataVolumeOutgoing option;
    totalDataVolume : TotalDataVolume option;
    chargeRefundIndicator : ChargeRefundIndicator option;
    contentChargingPoint : ContentChargingPoint option;
    chargeInformationList : ChargeInformationList option;
    advisedChargeInformation : AdvisedChargeInformation option
} 
    with static member ASN1 = createSequenceMeta<``ContentServiceUsed``> (Some { ClassNumber = 352; Class = Application }) [("contentTransactionCode", ``ContentTransactionCode``.ASN1, true);("contentTransactionType", ``ContentTransactionType``.ASN1, true);("objectType", ``ObjectType``.ASN1, true);("transactionDescriptionSupp", ``TransactionDescriptionSupp``.ASN1, true);("transactionShortDescription", ``TransactionShortDescription``.ASN1, true);("transactionDetailDescription", ``TransactionDetailDescription``.ASN1, true);("transactionIdentifier", ``TransactionIdentifier``.ASN1, true);("transactionAuthCode", ``TransactionAuthCode``.ASN1, true);("dataVolumeIncoming", ``DataVolumeIncoming``.ASN1, true);("dataVolumeOutgoing", ``DataVolumeOutgoing``.ASN1, true);("totalDataVolume", ``TotalDataVolume``.ASN1, true);("chargeRefundIndicator", ``ChargeRefundIndicator``.ASN1, true);("contentChargingPoint", ``ContentChargingPoint``.ASN1, true);("chargeInformationList", ``ChargeInformationList``.ASN1, true);("advisedChargeInformation", ``AdvisedChargeInformation``.ASN1, true)]


type ``ContentServiceUsedList``(* [Application 285] *) = { Items : ContentServiceUsed list } 
    with static member ASN1 = createSequenceOfMeta<``ContentServiceUsedList``> (Some { ClassNumber = 285; Class = Application }) (``ContentServiceUsed``.ASN1)
         static member create data : ``ContentServiceUsedList`` = { Items = data |> Seq.cast<``ContentServiceUsed``> |> Seq.toList }



type ``ContentTransactionBasicInfo``(* [Application 304] *) = {
    rapFileSequenceNumber : RapFileSequenceNumber option;
    orderPlacedTimeStamp : OrderPlacedTimeStamp option;
    requestedDeliveryTimeStamp : RequestedDeliveryTimeStamp option;
    actualDeliveryTimeStamp : ActualDeliveryTimeStamp option;
    totalTransactionDuration : TotalTransactionDuration option;
    transactionStatus : TransactionStatus option
} 
    with static member ASN1 = createSequenceMeta<``ContentTransactionBasicInfo``> (Some { ClassNumber = 304; Class = Application }) [("rapFileSequenceNumber", ``RapFileSequenceNumber``.ASN1, true);("orderPlacedTimeStamp", ``OrderPlacedTimeStamp``.ASN1, true);("requestedDeliveryTimeStamp", ``RequestedDeliveryTimeStamp``.ASN1, true);("actualDeliveryTimeStamp", ``ActualDeliveryTimeStamp``.ASN1, true);("totalTransactionDuration", ``TotalTransactionDuration``.ASN1, true);("transactionStatus", ``TransactionStatus``.ASN1, true)]


type ``ContentTransactionCode``(* [Application 336] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``ContentTransactionCode``> (Some { ClassNumber = 336; Class = Application })
         static member create data : ``ContentTransactionCode`` = { Item = ``Integer``.create data }


type ``ContentTransactionType``(* [Application 337] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``ContentTransactionType``> (Some { ClassNumber = 337; Class = Application })
         static member create data : ``ContentTransactionType`` = { Item = ``Integer``.create data }


type ``CseInformation``(* [Application 79] *) = { Item : OctetString }
    with static member ASN1 = createPrimitiveMeta<``CseInformation``> (Some { ClassNumber = 79; Class = Application })
         static member create data : ``CseInformation`` = { Item = ``OctetString``.create data }



type ``CurrencyConversion``(* [Application 106] *) = {
    exchangeRateCode : ExchangeRateCode option;
    numberOfDecimalPlaces : NumberOfDecimalPlaces option;
    exchangeRate : ExchangeRate option
} 
    with static member ASN1 = createSequenceMeta<``CurrencyConversion``> (Some { ClassNumber = 106; Class = Application }) [("exchangeRateCode", ``ExchangeRateCode``.ASN1, true);("numberOfDecimalPlaces", ``NumberOfDecimalPlaces``.ASN1, true);("exchangeRate", ``ExchangeRate``.ASN1, true)]


type ``CurrencyConversionList``(* [Application 80] *) = { Items : CurrencyConversion list } 
    with static member ASN1 = createSequenceOfMeta<``CurrencyConversionList``> (Some { ClassNumber = 80; Class = Application }) (``CurrencyConversion``.ASN1)
         static member create data : ``CurrencyConversionList`` = { Items = data |> Seq.cast<``CurrencyConversion``> |> Seq.toList }


type ``CustomerIdentifier``(* [Application 364] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``CustomerIdentifier``> (Some { ClassNumber = 364; Class = Application })
         static member create data : ``CustomerIdentifier`` = { Item = ``AsciiString``.create data }


type ``CustomerIdType``(* [Application 363] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``CustomerIdType``> (Some { ClassNumber = 363; Class = Application })
         static member create data : ``CustomerIdType`` = { Item = ``Integer``.create data }


type ``DataVolume`` = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``DataVolume``> None
         static member create data : ``DataVolume`` = { Item = ``Integer``.create data }

type ``DataVolumeIncoming``(* [Application 250] *) = { Item : ``DataVolume``  }
    with static member ASN1 = createPrimitiveMeta<``DataVolumeIncoming``> (Some { ClassNumber = 250; Class = Application })
         static member create data : ``DataVolumeIncoming`` = { Item = ``DataVolume``.create data }


type ``DataVolumeOutgoing``(* [Application 251] *) = { Item : ``DataVolume``  }
    with static member ASN1 = createPrimitiveMeta<``DataVolumeOutgoing``> (Some { ClassNumber = 251; Class = Application })
         static member create data : ``DataVolumeOutgoing`` = { Item = ``DataVolume``.create data }



type ``DateTime`` = {
    localTimeStamp : LocalTimeStamp option;
    utcTimeOffsetCode : UtcTimeOffsetCode option
} 
    with static member ASN1 = createSequenceMeta<``DateTime``> None [("localTimeStamp", ``LocalTimeStamp``.ASN1, true);("utcTimeOffsetCode", ``UtcTimeOffsetCode``.ASN1, true)]


type ``DateTimeLong`` = {
    localTimeStamp : LocalTimeStamp option;
    utcTimeOffset : UtcTimeOffset option
} 
    with static member ASN1 = createSequenceMeta<``DateTimeLong``> None [("localTimeStamp", ``LocalTimeStamp``.ASN1, true);("utcTimeOffset", ``UtcTimeOffset``.ASN1, true)]

type ``DefaultCallHandlingIndicator``(* [Application 87] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``DefaultCallHandlingIndicator``> (Some { ClassNumber = 87; Class = Application })
         static member create data : ``DefaultCallHandlingIndicator`` = { Item = ``Integer``.create data }


type ``DepositTimeStamp``(* [Application 88] *) = { Item : ``DateTime`` }
    with static member ASN1 = createReferenceMeta<``DepositTimeStamp``> (Some { ClassNumber = 88; Class = Application }) "DateTime" (``DateTime``.ASN1)
         static member create data : ``DepositTimeStamp`` = { Item = data }



type ``Destination``(* [Application 89] *) = {
    calledNumber : CalledNumber option;
    dialledDigits : DialledDigits option;
    calledPlace : CalledPlace option;
    calledRegion : CalledRegion option;
    sMSDestinationNumber : SMSDestinationNumber option
} 
    with static member ASN1 = createSequenceMeta<``Destination``> (Some { ClassNumber = 89; Class = Application }) [("calledNumber", ``CalledNumber``.ASN1, true);("dialledDigits", ``DialledDigits``.ASN1, true);("calledPlace", ``CalledPlace``.ASN1, true);("calledRegion", ``CalledRegion``.ASN1, true);("sMSDestinationNumber", ``SMSDestinationNumber``.ASN1, true)]


type ``DestinationNetwork``(* [Application 90] *) = { Item : ``NetworkId``  }
    with static member ASN1 = createPrimitiveMeta<``DestinationNetwork``> (Some { ClassNumber = 90; Class = Application })
         static member create data : ``DestinationNetwork`` = { Item = ``NetworkId``.create data }


type ``DialledDigits``(* [Application 279] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``DialledDigits``> (Some { ClassNumber = 279; Class = Application })
         static member create data : ``DialledDigits`` = { Item = ``AsciiString``.create data }


type ``Discount``(* [Application 412] *) = { Item : ``DiscountValue``  }
    with static member ASN1 = createPrimitiveMeta<``Discount``> (Some { ClassNumber = 412; Class = Application })
         static member create data : ``Discount`` = { Item = ``DiscountValue``.create data }


type ``DiscountableAmount``(* [Application 423] *) = { Item : ``AbsoluteAmount``  }
    with static member ASN1 = createPrimitiveMeta<``DiscountableAmount``> (Some { ClassNumber = 423; Class = Application })
         static member create data : ``DiscountableAmount`` = { Item = ``AbsoluteAmount``.create data }


type ``DiscountApplied`` (* [Application 428] *) = 
    |FixedDiscountValue of FixedDiscountValue
    |DiscountRate of DiscountRate
    with static member ASN1 = createChoiceMeta<``DiscountApplied``> (Some { ClassNumber = 428; Class = Application }) ["FixedDiscountValue", ``FixedDiscountValue``.ASN1; "DiscountRate", ``DiscountRate``.ASN1]


type ``DiscountCode``(* [Application 91] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``DiscountCode``> (Some { ClassNumber = 91; Class = Application })
         static member create data : ``DiscountCode`` = { Item = ``Integer``.create data }



type ``DiscountInformation``(* [Application 96] *) = {
    discountCode : DiscountCode option;
    discount : Discount option;
    discountableAmount : DiscountableAmount option
} 
    with static member ASN1 = createSequenceMeta<``DiscountInformation``> (Some { ClassNumber = 96; Class = Application }) [("discountCode", ``DiscountCode``.ASN1, true);("discount", ``Discount``.ASN1, true);("discountableAmount", ``DiscountableAmount``.ASN1, true)]



type ``Discounting``(* [Application 94] *) = {
    discountCode : DiscountCode option;
    discountApplied : DiscountApplied option
} 
    with static member ASN1 = createSequenceMeta<``Discounting``> (Some { ClassNumber = 94; Class = Application }) [("discountCode", ``DiscountCode``.ASN1, true);("discountApplied", ``DiscountApplied``.ASN1, true)]


type ``DiscountingList``(* [Application 95] *) = { Items : Discounting list } 
    with static member ASN1 = createSequenceOfMeta<``DiscountingList``> (Some { ClassNumber = 95; Class = Application }) (``Discounting``.ASN1)
         static member create data : ``DiscountingList`` = { Items = data |> Seq.cast<``Discounting``> |> Seq.toList }


type ``DiscountRate``(* [Application 92] *) = { Item : ``PercentageRate``  }
    with static member ASN1 = createPrimitiveMeta<``DiscountRate``> (Some { ClassNumber = 92; Class = Application })
         static member create data : ``DiscountRate`` = { Item = ``PercentageRate``.create data }


type ``DiscountValue`` = { Item : ``AbsoluteAmount``  }
    with static member ASN1 = createPrimitiveMeta<``DiscountValue``> None
         static member create data : ``DiscountValue`` = { Item = ``AbsoluteAmount``.create data }

type ``DistanceChargeBandCode``(* [Application 98] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``DistanceChargeBandCode``> (Some { ClassNumber = 98; Class = Application })
         static member create data : ``DistanceChargeBandCode`` = { Item = ``AsciiString``.create data }


type ``EarliestCallTimeStamp``(* [Application 101] *) = { Item : ``DateTimeLong`` }
    with static member ASN1 = createReferenceMeta<``EarliestCallTimeStamp``> (Some { ClassNumber = 101; Class = Application }) "DateTimeLong" (``DateTimeLong``.ASN1)
         static member create data : ``EarliestCallTimeStamp`` = { Item = data }


type ``EquipmentId``(* [Application 290] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``EquipmentId``> (Some { ClassNumber = 290; Class = Application })
         static member create data : ``EquipmentId`` = { Item = ``AsciiString``.create data }


type ``EquipmentIdType``(* [Application 322] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``EquipmentIdType``> (Some { ClassNumber = 322; Class = Application })
         static member create data : ``EquipmentIdType`` = { Item = ``Integer``.create data }


type ``Esn``(* [Application 103] *) = { Item : ``NumberString``  }
    with static member ASN1 = createPrimitiveMeta<``Esn``> (Some { ClassNumber = 103; Class = Application })
         static member create data : ``Esn`` = { Item = ``NumberString``.create data }


type ``ExchangeRate``(* [Application 104] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``ExchangeRate``> (Some { ClassNumber = 104; Class = Application })
         static member create data : ``ExchangeRate`` = { Item = ``Integer``.create data }


type ``ExchangeRateCode``(* [Application 105] *) = { Item : ``Code``  }
    with static member ASN1 = createPrimitiveMeta<``ExchangeRateCode``> (Some { ClassNumber = 105; Class = Application })
         static member create data : ``ExchangeRateCode`` = { Item = ``Code``.create data }


type ``FileAvailableTimeStamp``(* [Application 107] *) = { Item : ``DateTimeLong`` }
    with static member ASN1 = createReferenceMeta<``FileAvailableTimeStamp``> (Some { ClassNumber = 107; Class = Application }) "DateTimeLong" (``DateTimeLong``.ASN1)
         static member create data : ``FileAvailableTimeStamp`` = { Item = data }


type ``FileCreationTimeStamp``(* [Application 108] *) = { Item : ``DateTimeLong`` }
    with static member ASN1 = createReferenceMeta<``FileCreationTimeStamp``> (Some { ClassNumber = 108; Class = Application }) "DateTimeLong" (``DateTimeLong``.ASN1)
         static member create data : ``FileCreationTimeStamp`` = { Item = data }


type ``FileSequenceNumber``(* [Application 109] *) = { Item : ``NumberString``  }
    with static member ASN1 = createPrimitiveMeta<``FileSequenceNumber``> (Some { ClassNumber = 109; Class = Application })
         static member create data : ``FileSequenceNumber`` = { Item = ``NumberString``.create data }


type ``FileTypeIndicator``(* [Application 110] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``FileTypeIndicator``> (Some { ClassNumber = 110; Class = Application })
         static member create data : ``FileTypeIndicator`` = { Item = ``AsciiString``.create data }


type ``FixedDiscountValue``(* [Application 411] *) = { Item : ``DiscountValue``  }
    with static member ASN1 = createPrimitiveMeta<``FixedDiscountValue``> (Some { ClassNumber = 411; Class = Application })
         static member create data : ``FixedDiscountValue`` = { Item = ``DiscountValue``.create data }


type ``Fnur``(* [Application 111] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``Fnur``> (Some { ClassNumber = 111; Class = Application })
         static member create data : ``Fnur`` = { Item = ``Integer``.create data }



type ``GeographicalLocation``(* [Application 113] *) = {
    servingNetwork : ServingNetwork option;
    servingBid : ServingBid option;
    servingLocationDescription : ServingLocationDescription option
} 
    with static member ASN1 = createSequenceMeta<``GeographicalLocation``> (Some { ClassNumber = 113; Class = Application }) [("servingNetwork", ``ServingNetwork``.ASN1, true);("servingBid", ``ServingBid``.ASN1, true);("servingLocationDescription", ``ServingLocationDescription``.ASN1, true)]



type ``GprsBasicCallInformation``(* [Application 114] *) = {
    gprsChargeableSubscriber : GprsChargeableSubscriber option;
    rapFileSequenceNumber : RapFileSequenceNumber option;
    gprsDestination : GprsDestination option;
    callEventStartTimeStamp : CallEventStartTimeStamp option;
    totalCallEventDuration : TotalCallEventDuration option;
    causeForTerm : CauseForTerm option;
    partialTypeIndicator : PartialTypeIndicator option;
    pDPContextStartTimestamp : PDPContextStartTimestamp option;
    networkInitPDPContext : NetworkInitPDPContext option;
    chargingId : ChargingId option
} 
    with static member ASN1 = createSequenceMeta<``GprsBasicCallInformation``> (Some { ClassNumber = 114; Class = Application }) [("gprsChargeableSubscriber", ``GprsChargeableSubscriber``.ASN1, true);("rapFileSequenceNumber", ``RapFileSequenceNumber``.ASN1, true);("gprsDestination", ``GprsDestination``.ASN1, true);("callEventStartTimeStamp", ``CallEventStartTimeStamp``.ASN1, true);("totalCallEventDuration", ``TotalCallEventDuration``.ASN1, true);("causeForTerm", ``CauseForTerm``.ASN1, true);("partialTypeIndicator", ``PartialTypeIndicator``.ASN1, true);("pDPContextStartTimestamp", ``PDPContextStartTimestamp``.ASN1, true);("networkInitPDPContext", ``NetworkInitPDPContext``.ASN1, true);("chargingId", ``ChargingId``.ASN1, true)]



type ``GprsChargeableSubscriber``(* [Application 115] *) = {
    chargeableSubscriber : ChargeableSubscriber option;
    pdpAddress : PdpAddress option;
    networkAccessIdentifier : NetworkAccessIdentifier option
} 
    with static member ASN1 = createSequenceMeta<``GprsChargeableSubscriber``> (Some { ClassNumber = 115; Class = Application }) [("chargeableSubscriber", ``ChargeableSubscriber``.ASN1, true);("pdpAddress", ``PdpAddress``.ASN1, true);("networkAccessIdentifier", ``NetworkAccessIdentifier``.ASN1, true)]



type ``GprsDestination``(* [Application 116] *) = {
    accessPointNameNI : AccessPointNameNI option;
    accessPointNameOI : AccessPointNameOI option
} 
    with static member ASN1 = createSequenceMeta<``GprsDestination``> (Some { ClassNumber = 116; Class = Application }) [("accessPointNameNI", ``AccessPointNameNI``.ASN1, true);("accessPointNameOI", ``AccessPointNameOI``.ASN1, true)]



type ``GprsLocationInformation``(* [Application 117] *) = {
    gprsNetworkLocation : GprsNetworkLocation option;
    homeLocationInformation : HomeLocationInformation option;
    geographicalLocation : GeographicalLocation option
} 
    with static member ASN1 = createSequenceMeta<``GprsLocationInformation``> (Some { ClassNumber = 117; Class = Application }) [("gprsNetworkLocation", ``GprsNetworkLocation``.ASN1, true);("homeLocationInformation", ``HomeLocationInformation``.ASN1, true);("geographicalLocation", ``GeographicalLocation``.ASN1, true)]



type ``GprsNetworkLocation``(* [Application 118] *) = {
    recEntity : RecEntityCodeList option;
    locationArea : LocationArea option;
    cellId : CellId option
} 
    with static member ASN1 = createSequenceMeta<``GprsNetworkLocation``> (Some { ClassNumber = 118; Class = Application }) [("recEntity", ``RecEntityCodeList``.ASN1, true);("locationArea", ``LocationArea``.ASN1, true);("cellId", ``CellId``.ASN1, true)]



type ``GprsServiceUsed``(* [Application 121] *) = {
    iMSSignallingContext : IMSSignallingContext option;
    dataVolumeIncoming : DataVolumeIncoming option;
    dataVolumeOutgoing : DataVolumeOutgoing option;
    chargeInformationList : ChargeInformationList option
} 
    with static member ASN1 = createSequenceMeta<``GprsServiceUsed``> (Some { ClassNumber = 121; Class = Application }) [("iMSSignallingContext", ``IMSSignallingContext``.ASN1, true);("dataVolumeIncoming", ``DataVolumeIncoming``.ASN1, true);("dataVolumeOutgoing", ``DataVolumeOutgoing``.ASN1, true);("chargeInformationList", ``ChargeInformationList``.ASN1, true)]



type ``GsmChargeableSubscriber``(* [Application 286] *) = {
    imsi : Imsi option;
    msisdn : Msisdn option
} 
    with static member ASN1 = createSequenceMeta<``GsmChargeableSubscriber``> (Some { ClassNumber = 286; Class = Application }) [("imsi", ``Imsi``.ASN1, true);("msisdn", ``Msisdn``.ASN1, true)]


type ``GuaranteedBitRate``(* [Application 420] *) = { Item : OctetString }
    with static member ASN1 = createPrimitiveMeta<``GuaranteedBitRate``> (Some { ClassNumber = 420; Class = Application })
         static member create data : ``GuaranteedBitRate`` = { Item = ``OctetString``.create data }


type ``HomeBid``(* [Application 122] *) = { Item : ``Bid``  }
    with static member ASN1 = createPrimitiveMeta<``HomeBid``> (Some { ClassNumber = 122; Class = Application })
         static member create data : ``HomeBid`` = { Item = ``Bid``.create data }


type ``HomeIdentifier``(* [Application 288] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``HomeIdentifier``> (Some { ClassNumber = 288; Class = Application })
         static member create data : ``HomeIdentifier`` = { Item = ``AsciiString``.create data }


type ``HomeIdType``(* [Application 311] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``HomeIdType``> (Some { ClassNumber = 311; Class = Application })
         static member create data : ``HomeIdType`` = { Item = ``Integer``.create data }


type ``HomeLocationDescription``(* [Application 413] *) = { Item : ``LocationDescription``  }
    with static member ASN1 = createPrimitiveMeta<``HomeLocationDescription``> (Some { ClassNumber = 413; Class = Application })
         static member create data : ``HomeLocationDescription`` = { Item = ``LocationDescription``.create data }



type ``HomeLocationInformation``(* [Application 123] *) = {
    homeBid : HomeBid option;
    homeLocationDescription : HomeLocationDescription option
} 
    with static member ASN1 = createSequenceMeta<``HomeLocationInformation``> (Some { ClassNumber = 123; Class = Application }) [("homeBid", ``HomeBid``.ASN1, true);("homeLocationDescription", ``HomeLocationDescription``.ASN1, true)]


type ``HorizontalAccuracyDelivered``(* [Application 392] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``HorizontalAccuracyDelivered``> (Some { ClassNumber = 392; Class = Application })
         static member create data : ``HorizontalAccuracyDelivered`` = { Item = ``Integer``.create data }


type ``HorizontalAccuracyRequested``(* [Application 385] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``HorizontalAccuracyRequested``> (Some { ClassNumber = 385; Class = Application })
         static member create data : ``HorizontalAccuracyRequested`` = { Item = ``Integer``.create data }


type ``HSCSDIndicator``(* [Application 424] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``HSCSDIndicator``> (Some { ClassNumber = 424; Class = Application })
         static member create data : ``HSCSDIndicator`` = { Item = ``AsciiString``.create data }


type ``Imei``(* [Application 128] *) = { Item : ``BCDString``  }
    with static member ASN1 = createPrimitiveMeta<``Imei``> (Some { ClassNumber = 128; Class = Application })
         static member create data : ``Imei`` = { Item = ``BCDString``.create data }


type ``ImeiOrEsn`` (* [Application 429] *) = 
    |Imei of Imei
    |Esn of Esn
    with static member ASN1 = createChoiceMeta<``ImeiOrEsn``> (Some { ClassNumber = 429; Class = Application }) ["Imei", ``Imei``.ASN1; "Esn", ``Esn``.ASN1]


type ``Imsi``(* [Application 129] *) = { Item : ``BCDString``  }
    with static member ASN1 = createPrimitiveMeta<``Imsi``> (Some { ClassNumber = 129; Class = Application })
         static member create data : ``Imsi`` = { Item = ``BCDString``.create data }


type ``IMSSignallingContext``(* [Application 418] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``IMSSignallingContext``> (Some { ClassNumber = 418; Class = Application })
         static member create data : ``IMSSignallingContext`` = { Item = ``Integer``.create data }



type ``InternetServiceProvider``(* [Application 329] *) = {
    ispIdType : IspIdType option;
    ispIdentifier : IspIdentifier option
} 
    with static member ASN1 = createSequenceMeta<``InternetServiceProvider``> (Some { ClassNumber = 329; Class = Application }) [("ispIdType", ``IspIdType``.ASN1, true);("ispIdentifier", ``IspIdentifier``.ASN1, true)]


type ``InternetServiceProviderIdList``(* [Application 330] *) = { Items : InternetServiceProvider list } 
    with static member ASN1 = createSequenceOfMeta<``InternetServiceProviderIdList``> (Some { ClassNumber = 330; Class = Application }) (``InternetServiceProvider``.ASN1)
         static member create data : ``InternetServiceProviderIdList`` = { Items = data |> Seq.cast<``InternetServiceProvider``> |> Seq.toList }


type ``IspIdentifier``(* [Application 294] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``IspIdentifier``> (Some { ClassNumber = 294; Class = Application })
         static member create data : ``IspIdentifier`` = { Item = ``AsciiString``.create data }


type ``IspIdType``(* [Application 293] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``IspIdType``> (Some { ClassNumber = 293; Class = Application })
         static member create data : ``IspIdType`` = { Item = ``Integer``.create data }


type ``ISPList``(* [Application 378] *) = { Items : InternetServiceProvider list } 
    with static member ASN1 = createSequenceOfMeta<``ISPList``> (Some { ClassNumber = 378; Class = Application }) (``InternetServiceProvider``.ASN1)
         static member create data : ``ISPList`` = { Items = data |> Seq.cast<``InternetServiceProvider``> |> Seq.toList }


type ``NetworkIdType``(* [Application 331] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``NetworkIdType``> (Some { ClassNumber = 331; Class = Application })
         static member create data : ``NetworkIdType`` = { Item = ``Integer``.create data }


type ``NetworkIdentifier``(* [Application 295] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``NetworkIdentifier``> (Some { ClassNumber = 295; Class = Application })
         static member create data : ``NetworkIdentifier`` = { Item = ``AsciiString``.create data }



type ``Network``(* [Application 332] *) = {
    networkIdType : NetworkIdType option;
    networkIdentifier : NetworkIdentifier option
} 
    with static member ASN1 = createSequenceMeta<``Network``> (Some { ClassNumber = 332; Class = Application }) [("networkIdType", ``NetworkIdType``.ASN1, true);("networkIdentifier", ``NetworkIdentifier``.ASN1, true)]


type ``NetworkList``(* [Application 333] *) = { Items : Network list } 
    with static member ASN1 = createSequenceOfMeta<``NetworkList``> (Some { ClassNumber = 333; Class = Application }) (``Network``.ASN1)
         static member create data : ``NetworkList`` = { Items = data |> Seq.cast<``Network``> |> Seq.toList }


type ``LatestCallTimeStamp``(* [Application 133] *) = { Item : ``DateTimeLong`` }
    with static member ASN1 = createReferenceMeta<``LatestCallTimeStamp``> (Some { ClassNumber = 133; Class = Application }) "DateTimeLong" (``DateTimeLong``.ASN1)
         static member create data : ``LatestCallTimeStamp`` = { Item = data }



type ``LCSQosDelivered``(* [Application 390] *) = {
    lCSTransactionStatus : LCSTransactionStatus option;
    horizontalAccuracyDelivered : HorizontalAccuracyDelivered option;
    verticalAccuracyDelivered : VerticalAccuracyDelivered option;
    responseTime : ResponseTime option;
    positioningMethod : PositioningMethod option;
    trackingPeriod : TrackingPeriod option;
    trackingFrequency : TrackingFrequency option;
    ageOfLocation : AgeOfLocation option
} 
    with static member ASN1 = createSequenceMeta<``LCSQosDelivered``> (Some { ClassNumber = 390; Class = Application }) [("lCSTransactionStatus", ``LCSTransactionStatus``.ASN1, true);("horizontalAccuracyDelivered", ``HorizontalAccuracyDelivered``.ASN1, true);("verticalAccuracyDelivered", ``VerticalAccuracyDelivered``.ASN1, true);("responseTime", ``ResponseTime``.ASN1, true);("positioningMethod", ``PositioningMethod``.ASN1, true);("trackingPeriod", ``TrackingPeriod``.ASN1, true);("trackingFrequency", ``TrackingFrequency``.ASN1, true);("ageOfLocation", ``AgeOfLocation``.ASN1, true)]



type ``LCSQosRequested``(* [Application 383] *) = {
    lCSRequestTimestamp : LCSRequestTimestamp option;
    horizontalAccuracyRequested : HorizontalAccuracyRequested option;
    verticalAccuracyRequested : VerticalAccuracyRequested option;
    responseTimeCategory : ResponseTimeCategory option;
    trackingPeriod : TrackingPeriod option;
    trackingFrequency : TrackingFrequency option
} 
    with static member ASN1 = createSequenceMeta<``LCSQosRequested``> (Some { ClassNumber = 383; Class = Application }) [("lCSRequestTimestamp", ``LCSRequestTimestamp``.ASN1, true);("horizontalAccuracyRequested", ``HorizontalAccuracyRequested``.ASN1, true);("verticalAccuracyRequested", ``VerticalAccuracyRequested``.ASN1, true);("responseTimeCategory", ``ResponseTimeCategory``.ASN1, true);("trackingPeriod", ``TrackingPeriod``.ASN1, true);("trackingFrequency", ``TrackingFrequency``.ASN1, true)]


type ``LCSRequestTimestamp``(* [Application 384] *) = { Item : ``DateTime`` }
    with static member ASN1 = createReferenceMeta<``LCSRequestTimestamp``> (Some { ClassNumber = 384; Class = Application }) "DateTime" (``DateTime``.ASN1)
         static member create data : ``LCSRequestTimestamp`` = { Item = data }



type ``LCSSPIdentification``(* [Application 375] *) = {
    contentProviderIdType : ContentProviderIdType option;
    contentProviderIdentifier : ContentProviderIdentifier option
} 
    with static member ASN1 = createSequenceMeta<``LCSSPIdentification``> (Some { ClassNumber = 375; Class = Application }) [("contentProviderIdType", ``ContentProviderIdType``.ASN1, true);("contentProviderIdentifier", ``ContentProviderIdentifier``.ASN1, true)]


type ``LCSSPIdentificationList``(* [Application 374] *) = { Items : LCSSPIdentification list } 
    with static member ASN1 = createSequenceOfMeta<``LCSSPIdentificationList``> (Some { ClassNumber = 374; Class = Application }) (``LCSSPIdentification``.ASN1)
         static member create data : ``LCSSPIdentificationList`` = { Items = data |> Seq.cast<``LCSSPIdentification``> |> Seq.toList }



type ``LCSSPInformation``(* [Application 373] *) = {
    lCSSPIdentificationList : LCSSPIdentificationList option;
    iSPList : ISPList option;
    networkList : NetworkList option
} 
    with static member ASN1 = createSequenceMeta<``LCSSPInformation``> (Some { ClassNumber = 373; Class = Application }) [("lCSSPIdentificationList", ``LCSSPIdentificationList``.ASN1, true);("iSPList", ``ISPList``.ASN1, true);("networkList", ``NetworkList``.ASN1, true)]


type ``LCSTransactionStatus``(* [Application 391] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``LCSTransactionStatus``> (Some { ClassNumber = 391; Class = Application })
         static member create data : ``LCSTransactionStatus`` = { Item = ``Integer``.create data }


type ``LocalCurrency``(* [Application 135] *) = { Item : ``Currency``  }
    with static member ASN1 = createPrimitiveMeta<``LocalCurrency``> (Some { ClassNumber = 135; Class = Application })
         static member create data : ``LocalCurrency`` = { Item = ``Currency``.create data }


type ``LocalTimeStamp``(* [Application 16] *) = { Item : ``NumberString``  }
    with static member ASN1 = createPrimitiveMeta<``LocalTimeStamp``> (Some { ClassNumber = 16; Class = Application })
         static member create data : ``LocalTimeStamp`` = { Item = ``NumberString``.create data }


type ``LocationArea``(* [Application 136] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``LocationArea``> (Some { ClassNumber = 136; Class = Application })
         static member create data : ``LocationArea`` = { Item = ``Integer``.create data }


type ``LocationDescription`` = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``LocationDescription``> None
         static member create data : ``LocationDescription`` = { Item = ``AsciiString``.create data }

type ``LocationIdentifier``(* [Application 289] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``LocationIdentifier``> (Some { ClassNumber = 289; Class = Application })
         static member create data : ``LocationIdentifier`` = { Item = ``AsciiString``.create data }


type ``LocationIdType``(* [Application 315] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``LocationIdType``> (Some { ClassNumber = 315; Class = Application })
         static member create data : ``LocationIdType`` = { Item = ``Integer``.create data }



type ``LocationInformation``(* [Application 138] *) = {
    networkLocation : NetworkLocation option;
    homeLocationInformation : HomeLocationInformation option;
    geographicalLocation : GeographicalLocation option
} 
    with static member ASN1 = createSequenceMeta<``LocationInformation``> (Some { ClassNumber = 138; Class = Application }) [("networkLocation", ``NetworkLocation``.ASN1, true);("homeLocationInformation", ``HomeLocationInformation``.ASN1, true);("geographicalLocation", ``GeographicalLocation``.ASN1, true)]



type ``LocationServiceUsage``(* [Application 382] *) = {
    lCSQosRequested : LCSQosRequested option;
    lCSQosDelivered : LCSQosDelivered option;
    chargingTimeStamp : ChargingTimeStamp option;
    chargeInformationList : ChargeInformationList option
} 
    with static member ASN1 = createSequenceMeta<``LocationServiceUsage``> (Some { ClassNumber = 382; Class = Application }) [("lCSQosRequested", ``LCSQosRequested``.ASN1, true);("lCSQosDelivered", ``LCSQosDelivered``.ASN1, true);("chargingTimeStamp", ``ChargingTimeStamp``.ASN1, true);("chargeInformationList", ``ChargeInformationList``.ASN1, true)]


type ``MaximumBitRate``(* [Application 421] *) = { Item : OctetString }
    with static member ASN1 = createPrimitiveMeta<``MaximumBitRate``> (Some { ClassNumber = 421; Class = Application })
         static member create data : ``MaximumBitRate`` = { Item = ``OctetString``.create data }


type ``Mdn``(* [Application 253] *) = { Item : ``NumberString``  }
    with static member ASN1 = createPrimitiveMeta<``Mdn``> (Some { ClassNumber = 253; Class = Application })
         static member create data : ``Mdn`` = { Item = ``NumberString``.create data }


type ``MessageDescription``(* [Application 142] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``MessageDescription``> (Some { ClassNumber = 142; Class = Application })
         static member create data : ``MessageDescription`` = { Item = ``AsciiString``.create data }


type ``MessageDescriptionCode``(* [Application 141] *) = { Item : ``Code``  }
    with static member ASN1 = createPrimitiveMeta<``MessageDescriptionCode``> (Some { ClassNumber = 141; Class = Application })
         static member create data : ``MessageDescriptionCode`` = { Item = ``Code``.create data }



type ``MessageDescriptionInformation``(* [Application 143] *) = {
    messageDescriptionCode : MessageDescriptionCode option;
    messageDescription : MessageDescription option
} 
    with static member ASN1 = createSequenceMeta<``MessageDescriptionInformation``> (Some { ClassNumber = 143; Class = Application }) [("messageDescriptionCode", ``MessageDescriptionCode``.ASN1, true);("messageDescription", ``MessageDescription``.ASN1, true)]


type ``MessageStatus``(* [Application 144] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``MessageStatus``> (Some { ClassNumber = 144; Class = Application })
         static member create data : ``MessageStatus`` = { Item = ``Integer``.create data }


type ``MessageType``(* [Application 145] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``MessageType``> (Some { ClassNumber = 145; Class = Application })
         static member create data : ``MessageType`` = { Item = ``Integer``.create data }


type ``Min``(* [Application 146] *) = { Item : ``NumberString``  }
    with static member ASN1 = createPrimitiveMeta<``Min``> (Some { ClassNumber = 146; Class = Application })
         static member create data : ``Min`` = { Item = ``NumberString``.create data }



type ``MinChargeableSubscriber``(* [Application 254] *) = {
    min : Min option;
    mdn : Mdn option
} 
    with static member ASN1 = createSequenceMeta<``MinChargeableSubscriber``> (Some { ClassNumber = 254; Class = Application }) [("min", ``Min``.ASN1, true);("mdn", ``Mdn``.ASN1, true)]



type ``MoBasicCallInformation``(* [Application 147] *) = {
    chargeableSubscriber : ChargeableSubscriber option;
    rapFileSequenceNumber : RapFileSequenceNumber option;
    destination : Destination option;
    destinationNetwork : DestinationNetwork option;
    callEventStartTimeStamp : CallEventStartTimeStamp option;
    totalCallEventDuration : TotalCallEventDuration option;
    simToolkitIndicator : SimToolkitIndicator option;
    causeForTerm : CauseForTerm option
} 
    with static member ASN1 = createSequenceMeta<``MoBasicCallInformation``> (Some { ClassNumber = 147; Class = Application }) [("chargeableSubscriber", ``ChargeableSubscriber``.ASN1, true);("rapFileSequenceNumber", ``RapFileSequenceNumber``.ASN1, true);("destination", ``Destination``.ASN1, true);("destinationNetwork", ``DestinationNetwork``.ASN1, true);("callEventStartTimeStamp", ``CallEventStartTimeStamp``.ASN1, true);("totalCallEventDuration", ``TotalCallEventDuration``.ASN1, true);("simToolkitIndicator", ``SimToolkitIndicator``.ASN1, true);("causeForTerm", ``CauseForTerm``.ASN1, true)]


type ``Msisdn``(* [Application 152] *) = { Item : ``BCDString``  }
    with static member ASN1 = createPrimitiveMeta<``Msisdn``> (Some { ClassNumber = 152; Class = Application })
         static member create data : ``Msisdn`` = { Item = ``BCDString``.create data }



type ``MtBasicCallInformation``(* [Application 153] *) = {
    chargeableSubscriber : ChargeableSubscriber option;
    rapFileSequenceNumber : RapFileSequenceNumber option;
    callOriginator : CallOriginator option;
    originatingNetwork : OriginatingNetwork option;
    callEventStartTimeStamp : CallEventStartTimeStamp option;
    totalCallEventDuration : TotalCallEventDuration option;
    simToolkitIndicator : SimToolkitIndicator option;
    causeForTerm : CauseForTerm option
} 
    with static member ASN1 = createSequenceMeta<``MtBasicCallInformation``> (Some { ClassNumber = 153; Class = Application }) [("chargeableSubscriber", ``ChargeableSubscriber``.ASN1, true);("rapFileSequenceNumber", ``RapFileSequenceNumber``.ASN1, true);("callOriginator", ``CallOriginator``.ASN1, true);("originatingNetwork", ``OriginatingNetwork``.ASN1, true);("callEventStartTimeStamp", ``CallEventStartTimeStamp``.ASN1, true);("totalCallEventDuration", ``TotalCallEventDuration``.ASN1, true);("simToolkitIndicator", ``SimToolkitIndicator``.ASN1, true);("causeForTerm", ``CauseForTerm``.ASN1, true)]


type ``NetworkAccessIdentifier``(* [Application 417] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``NetworkAccessIdentifier``> (Some { ClassNumber = 417; Class = Application })
         static member create data : ``NetworkAccessIdentifier`` = { Item = ``AsciiString``.create data }


type ``NetworkId`` = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``NetworkId``> None
         static member create data : ``NetworkId`` = { Item = ``AsciiString``.create data }

type ``NetworkInitPDPContext``(* [Application 245] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``NetworkInitPDPContext``> (Some { ClassNumber = 245; Class = Application })
         static member create data : ``NetworkInitPDPContext`` = { Item = ``Integer``.create data }



type ``NetworkLocation``(* [Application 156] *) = {
    recEntityCode : RecEntityCode option;
    callReference : CallReference option;
    locationArea : LocationArea option;
    cellId : CellId option
} 
    with static member ASN1 = createSequenceMeta<``NetworkLocation``> (Some { ClassNumber = 156; Class = Application }) [("recEntityCode", ``RecEntityCode``.ASN1, true);("callReference", ``CallReference``.ASN1, true);("locationArea", ``LocationArea``.ASN1, true);("cellId", ``CellId``.ASN1, true)]


type ``NonChargedNumber``(* [Application 402] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``NonChargedNumber``> (Some { ClassNumber = 402; Class = Application })
         static member create data : ``NonChargedNumber`` = { Item = ``AsciiString``.create data }


type ``NumberOfDecimalPlaces``(* [Application 159] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``NumberOfDecimalPlaces``> (Some { ClassNumber = 159; Class = Application })
         static member create data : ``NumberOfDecimalPlaces`` = { Item = ``Integer``.create data }


type ``ObjectType``(* [Application 281] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``ObjectType``> (Some { ClassNumber = 281; Class = Application })
         static member create data : ``ObjectType`` = { Item = ``Integer``.create data }


type ``OperatorSpecInfoList``(* [Application 162] *) = { Items : OperatorSpecInformation list } 
    with static member ASN1 = createSequenceOfMeta<``OperatorSpecInfoList``> (Some { ClassNumber = 162; Class = Application }) (``OperatorSpecInformation``.ASN1)
         static member create data : ``OperatorSpecInfoList`` = { Items = data |> Seq.cast<``OperatorSpecInformation``> |> Seq.toList }


type ``OperatorSpecInformation``(* [Application 163] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``OperatorSpecInformation``> (Some { ClassNumber = 163; Class = Application })
         static member create data : ``OperatorSpecInformation`` = { Item = ``AsciiString``.create data }


type ``OrderPlacedTimeStamp``(* [Application 300] *) = { Item : ``DateTime`` }
    with static member ASN1 = createReferenceMeta<``OrderPlacedTimeStamp``> (Some { ClassNumber = 300; Class = Application }) "DateTime" (``DateTime``.ASN1)
         static member create data : ``OrderPlacedTimeStamp`` = { Item = data }


type ``OriginatingNetwork``(* [Application 164] *) = { Item : ``NetworkId``  }
    with static member ASN1 = createPrimitiveMeta<``OriginatingNetwork``> (Some { ClassNumber = 164; Class = Application })
         static member create data : ``OriginatingNetwork`` = { Item = ``NetworkId``.create data }


type ``PacketDataProtocolAddress``(* [Application 165] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``PacketDataProtocolAddress``> (Some { ClassNumber = 165; Class = Application })
         static member create data : ``PacketDataProtocolAddress`` = { Item = ``AsciiString``.create data }


type ``PaidIndicator``(* [Application 346] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``PaidIndicator``> (Some { ClassNumber = 346; Class = Application })
         static member create data : ``PaidIndicator`` = { Item = ``Integer``.create data }


type ``PartialTypeIndicator``(* [Application 166] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``PartialTypeIndicator``> (Some { ClassNumber = 166; Class = Application })
         static member create data : ``PartialTypeIndicator`` = { Item = ``AsciiString``.create data }


type ``PaymentMethod``(* [Application 347] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``PaymentMethod``> (Some { ClassNumber = 347; Class = Application })
         static member create data : ``PaymentMethod`` = { Item = ``Integer``.create data }


type ``PdpAddress``(* [Application 167] *) = { Item : ``PacketDataProtocolAddress``  }
    with static member ASN1 = createPrimitiveMeta<``PdpAddress``> (Some { ClassNumber = 167; Class = Application })
         static member create data : ``PdpAddress`` = { Item = ``PacketDataProtocolAddress``.create data }


type ``PDPContextStartTimestamp``(* [Application 260] *) = { Item : ``DateTime`` }
    with static member ASN1 = createReferenceMeta<``PDPContextStartTimestamp``> (Some { ClassNumber = 260; Class = Application }) "DateTime" (``DateTime``.ASN1)
         static member create data : ``PDPContextStartTimestamp`` = { Item = data }


type ``PlmnId``(* [Application 169] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``PlmnId``> (Some { ClassNumber = 169; Class = Application })
         static member create data : ``PlmnId`` = { Item = ``AsciiString``.create data }


type ``PositioningMethod``(* [Application 395] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``PositioningMethod``> (Some { ClassNumber = 395; Class = Application })
         static member create data : ``PositioningMethod`` = { Item = ``Integer``.create data }


type ``PriorityCode``(* [Application 170] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``PriorityCode``> (Some { ClassNumber = 170; Class = Application })
         static member create data : ``PriorityCode`` = { Item = ``Integer``.create data }


type ``RapFileSequenceNumber``(* [Application 181] *) = { Item : ``FileSequenceNumber``  }
    with static member ASN1 = createPrimitiveMeta<``RapFileSequenceNumber``> (Some { ClassNumber = 181; Class = Application })
         static member create data : ``RapFileSequenceNumber`` = { Item = ``FileSequenceNumber``.create data }


type ``RecEntityCode``(* [Application 184] *) = { Item : ``Code``  }
    with static member ASN1 = createPrimitiveMeta<``RecEntityCode``> (Some { ClassNumber = 184; Class = Application })
         static member create data : ``RecEntityCode`` = { Item = ``Code``.create data }


type ``RecEntityCodeList``(* [Application 185] *) = { Items : RecEntityCode list } 
    with static member ASN1 = createSequenceOfMeta<``RecEntityCodeList``> (Some { ClassNumber = 185; Class = Application }) (``RecEntityCode``.ASN1)
         static member create data : ``RecEntityCodeList`` = { Items = data |> Seq.cast<``RecEntityCode``> |> Seq.toList }


type ``RecEntityId``(* [Application 400] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``RecEntityId``> (Some { ClassNumber = 400; Class = Application })
         static member create data : ``RecEntityId`` = { Item = ``AsciiString``.create data }


type ``RecEntityInfoList``(* [Application 188] *) = { Items : RecEntityInformation list } 
    with static member ASN1 = createSequenceOfMeta<``RecEntityInfoList``> (Some { ClassNumber = 188; Class = Application }) (``RecEntityInformation``.ASN1)
         static member create data : ``RecEntityInfoList`` = { Items = data |> Seq.cast<``RecEntityInformation``> |> Seq.toList }



type ``RecEntityInformation``(* [Application 183] *) = {
    recEntityCode : RecEntityCode option;
    recEntityType : RecEntityType option;
    recEntityId : RecEntityId option
} 
    with static member ASN1 = createSequenceMeta<``RecEntityInformation``> (Some { ClassNumber = 183; Class = Application }) [("recEntityCode", ``RecEntityCode``.ASN1, true);("recEntityType", ``RecEntityType``.ASN1, true);("recEntityId", ``RecEntityId``.ASN1, true)]


type ``RecEntityType``(* [Application 186] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``RecEntityType``> (Some { ClassNumber = 186; Class = Application })
         static member create data : ``RecEntityType`` = { Item = ``Integer``.create data }


type ``Recipient``(* [Application 182] *) = { Item : ``PlmnId``  }
    with static member ASN1 = createPrimitiveMeta<``Recipient``> (Some { ClassNumber = 182; Class = Application })
         static member create data : ``Recipient`` = { Item = ``PlmnId``.create data }


type ``ReleaseVersionNumber``(* [Application 189] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``ReleaseVersionNumber``> (Some { ClassNumber = 189; Class = Application })
         static member create data : ``ReleaseVersionNumber`` = { Item = ``Integer``.create data }


type ``RequestedDeliveryTimeStamp``(* [Application 301] *) = { Item : ``DateTime`` }
    with static member ASN1 = createReferenceMeta<``RequestedDeliveryTimeStamp``> (Some { ClassNumber = 301; Class = Application }) "DateTime" (``DateTime``.ASN1)
         static member create data : ``RequestedDeliveryTimeStamp`` = { Item = data }


type ``ResponseTime``(* [Application 394] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``ResponseTime``> (Some { ClassNumber = 394; Class = Application })
         static member create data : ``ResponseTime`` = { Item = ``Integer``.create data }


type ``ResponseTimeCategory``(* [Application 387] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``ResponseTimeCategory``> (Some { ClassNumber = 387; Class = Application })
         static member create data : ``ResponseTimeCategory`` = { Item = ``Integer``.create data }



type ``ScuBasicInformation``(* [Application 191] *) = {
    chargeableSubscriber : ScuChargeableSubscriber option;
    chargedPartyStatus : ChargedPartyStatus option;
    nonChargedNumber : NonChargedNumber option;
    clirIndicator : ClirIndicator option;
    originatingNetwork : OriginatingNetwork option;
    destinationNetwork : DestinationNetwork option
} 
    with static member ASN1 = createSequenceMeta<``ScuBasicInformation``> (Some { ClassNumber = 191; Class = Application }) [("chargeableSubscriber", ``ScuChargeableSubscriber``.ASN1, true);("chargedPartyStatus", ``ChargedPartyStatus``.ASN1, true);("nonChargedNumber", ``NonChargedNumber``.ASN1, true);("clirIndicator", ``ClirIndicator``.ASN1, true);("originatingNetwork", ``OriginatingNetwork``.ASN1, true);("destinationNetwork", ``DestinationNetwork``.ASN1, true)]



type ``ScuChargeType``(* [Application 192] *) = {
    messageStatus : MessageStatus option;
    priorityCode : PriorityCode option;
    distanceChargeBandCode : DistanceChargeBandCode option;
    messageType : MessageType option;
    messageDescriptionCode : MessageDescriptionCode option
} 
    with static member ASN1 = createSequenceMeta<``ScuChargeType``> (Some { ClassNumber = 192; Class = Application }) [("messageStatus", ``MessageStatus``.ASN1, true);("priorityCode", ``PriorityCode``.ASN1, true);("distanceChargeBandCode", ``DistanceChargeBandCode``.ASN1, true);("messageType", ``MessageType``.ASN1, true);("messageDescriptionCode", ``MessageDescriptionCode``.ASN1, true)]



type ``ScuTimeStamps``(* [Application 193] *) = {
    depositTimeStamp : DepositTimeStamp option;
    completionTimeStamp : CompletionTimeStamp option;
    chargingPoint : ChargingPoint option
} 
    with static member ASN1 = createSequenceMeta<``ScuTimeStamps``> (Some { ClassNumber = 193; Class = Application }) [("depositTimeStamp", ``DepositTimeStamp``.ASN1, true);("completionTimeStamp", ``CompletionTimeStamp``.ASN1, true);("chargingPoint", ``ChargingPoint``.ASN1, true)]


type ``ScuChargeableSubscriber`` (* [Application 430] *) = 
    |GsmChargeableSubscriber of GsmChargeableSubscriber
    |MinChargeableSubscriber of MinChargeableSubscriber
    with static member ASN1 = createChoiceMeta<``ScuChargeableSubscriber``> (Some { ClassNumber = 430; Class = Application }) ["GsmChargeableSubscriber", ``GsmChargeableSubscriber``.ASN1; "MinChargeableSubscriber", ``MinChargeableSubscriber``.ASN1]


type ``Sender``(* [Application 196] *) = { Item : ``PlmnId``  }
    with static member ASN1 = createPrimitiveMeta<``Sender``> (Some { ClassNumber = 196; Class = Application })
         static member create data : ``Sender`` = { Item = ``PlmnId``.create data }


type ``ServingBid``(* [Application 198] *) = { Item : ``Bid``  }
    with static member ASN1 = createPrimitiveMeta<``ServingBid``> (Some { ClassNumber = 198; Class = Application })
         static member create data : ``ServingBid`` = { Item = ``Bid``.create data }


type ``ServingLocationDescription``(* [Application 414] *) = { Item : ``LocationDescription``  }
    with static member ASN1 = createPrimitiveMeta<``ServingLocationDescription``> (Some { ClassNumber = 414; Class = Application })
         static member create data : ``ServingLocationDescription`` = { Item = ``LocationDescription``.create data }


type ``ServingNetwork``(* [Application 195] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``ServingNetwork``> (Some { ClassNumber = 195; Class = Application })
         static member create data : ``ServingNetwork`` = { Item = ``AsciiString``.create data }



type ``ServingPartiesInformation``(* [Application 335] *) = {
    contentProviderName : ContentProviderName option;
    contentProviderIdList : ContentProviderIdList option;
    internetServiceProviderIdList : InternetServiceProviderIdList option;
    networkList : NetworkList option
} 
    with static member ASN1 = createSequenceMeta<``ServingPartiesInformation``> (Some { ClassNumber = 335; Class = Application }) [("contentProviderName", ``ContentProviderName``.ASN1, true);("contentProviderIdList", ``ContentProviderIdList``.ASN1, true);("internetServiceProviderIdList", ``InternetServiceProviderIdList``.ASN1, true);("networkList", ``NetworkList``.ASN1, true)]



type ``SimChargeableSubscriber``(* [Application 199] *) = {
    imsi : Imsi option;
    msisdn : Msisdn option
} 
    with static member ASN1 = createSequenceMeta<``SimChargeableSubscriber``> (Some { ClassNumber = 199; Class = Application }) [("imsi", ``Imsi``.ASN1, true);("msisdn", ``Msisdn``.ASN1, true)]


type ``SimToolkitIndicator``(* [Application 200] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``SimToolkitIndicator``> (Some { ClassNumber = 200; Class = Application })
         static member create data : ``SimToolkitIndicator`` = { Item = ``AsciiString``.create data }


type ``SMSDestinationNumber``(* [Application 419] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``SMSDestinationNumber``> (Some { ClassNumber = 419; Class = Application })
         static member create data : ``SMSDestinationNumber`` = { Item = ``AsciiString``.create data }


type ``SMSOriginator``(* [Application 425] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``SMSOriginator``> (Some { ClassNumber = 425; Class = Application })
         static member create data : ``SMSOriginator`` = { Item = ``AsciiString``.create data }


type ``SpecificationVersionNumber``(* [Application 201] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``SpecificationVersionNumber``> (Some { ClassNumber = 201; Class = Application })
         static member create data : ``SpecificationVersionNumber`` = { Item = ``Integer``.create data }


type ``SsParameters``(* [Application 204] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``SsParameters``> (Some { ClassNumber = 204; Class = Application })
         static member create data : ``SsParameters`` = { Item = ``AsciiString``.create data }


type ``SupplServiceActionCode``(* [Application 208] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``SupplServiceActionCode``> (Some { ClassNumber = 208; Class = Application })
         static member create data : ``SupplServiceActionCode`` = { Item = ``Integer``.create data }


type ``SupplServiceCode``(* [Application 209] *) = { Item : ``HexString``  }
    with static member ASN1 = createPrimitiveMeta<``SupplServiceCode``> (Some { ClassNumber = 209; Class = Application })
         static member create data : ``SupplServiceCode`` = { Item = ``HexString``.create data }



type ``SupplServiceUsed``(* [Application 206] *) = {
    supplServiceCode : SupplServiceCode option;
    supplServiceActionCode : SupplServiceActionCode option;
    ssParameters : SsParameters option;
    chargingTimeStamp : ChargingTimeStamp option;
    chargeInformation : ChargeInformation option;
    basicServiceCodeList : BasicServiceCodeList option
} 
    with static member ASN1 = createSequenceMeta<``SupplServiceUsed``> (Some { ClassNumber = 206; Class = Application }) [("supplServiceCode", ``SupplServiceCode``.ASN1, true);("supplServiceActionCode", ``SupplServiceActionCode``.ASN1, true);("ssParameters", ``SsParameters``.ASN1, true);("chargingTimeStamp", ``ChargingTimeStamp``.ASN1, true);("chargeInformation", ``ChargeInformation``.ASN1, true);("basicServiceCodeList", ``BasicServiceCodeList``.ASN1, true)]


type ``TapCurrency``(* [Application 210] *) = { Item : ``Currency``  }
    with static member ASN1 = createPrimitiveMeta<``TapCurrency``> (Some { ClassNumber = 210; Class = Application })
         static member create data : ``TapCurrency`` = { Item = ``Currency``.create data }


type ``TapDecimalPlaces``(* [Application 244] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``TapDecimalPlaces``> (Some { ClassNumber = 244; Class = Application })
         static member create data : ``TapDecimalPlaces`` = { Item = ``Integer``.create data }


type ``TaxableAmount``(* [Application 398] *) = { Item : ``AbsoluteAmount``  }
    with static member ASN1 = createPrimitiveMeta<``TaxableAmount``> (Some { ClassNumber = 398; Class = Application })
         static member create data : ``TaxableAmount`` = { Item = ``AbsoluteAmount``.create data }



type ``Taxation``(* [Application 216] *) = {
    taxCode : TaxCode option;
    taxType : TaxType option;
    taxRate : TaxRate option;
    chargeType : ChargeType option;
    taxIndicator : TaxIndicator option
} 
    with static member ASN1 = createSequenceMeta<``Taxation``> (Some { ClassNumber = 216; Class = Application }) [("taxCode", ``TaxCode``.ASN1, true);("taxType", ``TaxType``.ASN1, true);("taxRate", ``TaxRate``.ASN1, true);("chargeType", ``ChargeType``.ASN1, true);("taxIndicator", ``TaxIndicator``.ASN1, true)]


type ``TaxationList``(* [Application 211] *) = { Items : Taxation list } 
    with static member ASN1 = createSequenceOfMeta<``TaxationList``> (Some { ClassNumber = 211; Class = Application }) (``Taxation``.ASN1)
         static member create data : ``TaxationList`` = { Items = data |> Seq.cast<``Taxation``> |> Seq.toList }


type ``TaxCode``(* [Application 212] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``TaxCode``> (Some { ClassNumber = 212; Class = Application })
         static member create data : ``TaxCode`` = { Item = ``Integer``.create data }


type ``TaxIndicator``(* [Application 432] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``TaxIndicator``> (Some { ClassNumber = 432; Class = Application })
         static member create data : ``TaxIndicator`` = { Item = ``AsciiString``.create data }



type ``TaxInformation``(* [Application 213] *) = {
    taxCode : TaxCode option;
    taxValue : TaxValue option;
    taxableAmount : TaxableAmount option
} 
    with static member ASN1 = createSequenceMeta<``TaxInformation``> (Some { ClassNumber = 213; Class = Application }) [("taxCode", ``TaxCode``.ASN1, true);("taxValue", ``TaxValue``.ASN1, true);("taxableAmount", ``TaxableAmount``.ASN1, true)]


type ``TaxInformationList``(* [Application 214] *) = { Items : TaxInformation list } 
    with static member ASN1 = createSequenceOfMeta<``TaxInformationList``> (Some { ClassNumber = 214; Class = Application }) (``TaxInformation``.ASN1)
         static member create data : ``TaxInformationList`` = { Items = data |> Seq.cast<``TaxInformation``> |> Seq.toList }


type ``TaxRate``(* [Application 215] *) = { Item : ``NumberString``  }
    with static member ASN1 = createPrimitiveMeta<``TaxRate``> (Some { ClassNumber = 215; Class = Application })
         static member create data : ``TaxRate`` = { Item = ``NumberString``.create data }


type ``TaxType``(* [Application 217] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``TaxType``> (Some { ClassNumber = 217; Class = Application })
         static member create data : ``TaxType`` = { Item = ``AsciiString``.create data }


type ``TaxValue``(* [Application 397] *) = { Item : ``AbsoluteAmount``  }
    with static member ASN1 = createPrimitiveMeta<``TaxValue``> (Some { ClassNumber = 397; Class = Application })
         static member create data : ``TaxValue`` = { Item = ``AbsoluteAmount``.create data }


type ``TeleServiceCode``(* [Application 218] *) = { Item : ``HexString``  }
    with static member ASN1 = createPrimitiveMeta<``TeleServiceCode``> (Some { ClassNumber = 218; Class = Application })
         static member create data : ``TeleServiceCode`` = { Item = ``HexString``.create data }



type ``ThirdPartyInformation``(* [Application 219] *) = {
    thirdPartyNumber : ThirdPartyNumber option;
    clirIndicator : ClirIndicator option
} 
    with static member ASN1 = createSequenceMeta<``ThirdPartyInformation``> (Some { ClassNumber = 219; Class = Application }) [("thirdPartyNumber", ``ThirdPartyNumber``.ASN1, true);("clirIndicator", ``ClirIndicator``.ASN1, true)]


type ``ThirdPartyNumber``(* [Application 403] *) = { Item : ``AddressStringDigits``  }
    with static member ASN1 = createPrimitiveMeta<``ThirdPartyNumber``> (Some { ClassNumber = 403; Class = Application })
         static member create data : ``ThirdPartyNumber`` = { Item = ``AddressStringDigits``.create data }


type ``ThreeGcamelDestination`` (* [Application 431] *) = 
    |CamelDestinationNumber of CamelDestinationNumber
    |GprsDestination of GprsDestination
    with static member ASN1 = createChoiceMeta<``ThreeGcamelDestination``> (Some { ClassNumber = 431; Class = Application }) ["CamelDestinationNumber", ``CamelDestinationNumber``.ASN1; "GprsDestination", ``GprsDestination``.ASN1]


type ``TotalAdvisedCharge``(* [Application 356] *) = { Item : ``AbsoluteAmount``  }
    with static member ASN1 = createPrimitiveMeta<``TotalAdvisedCharge``> (Some { ClassNumber = 356; Class = Application })
         static member create data : ``TotalAdvisedCharge`` = { Item = ``AbsoluteAmount``.create data }


type ``TotalAdvisedChargeRefund``(* [Application 357] *) = { Item : ``AbsoluteAmount``  }
    with static member ASN1 = createPrimitiveMeta<``TotalAdvisedChargeRefund``> (Some { ClassNumber = 357; Class = Application })
         static member create data : ``TotalAdvisedChargeRefund`` = { Item = ``AbsoluteAmount``.create data }



type ``TotalAdvisedChargeValue``(* [Application 360] *) = {
    advisedChargeCurrency : AdvisedChargeCurrency option;
    totalAdvisedCharge : TotalAdvisedCharge option;
    totalAdvisedChargeRefund : TotalAdvisedChargeRefund option;
    totalCommission : TotalCommission option;
    totalCommissionRefund : TotalCommissionRefund option
} 
    with static member ASN1 = createSequenceMeta<``TotalAdvisedChargeValue``> (Some { ClassNumber = 360; Class = Application }) [("advisedChargeCurrency", ``AdvisedChargeCurrency``.ASN1, true);("totalAdvisedCharge", ``TotalAdvisedCharge``.ASN1, true);("totalAdvisedChargeRefund", ``TotalAdvisedChargeRefund``.ASN1, true);("totalCommission", ``TotalCommission``.ASN1, true);("totalCommissionRefund", ``TotalCommissionRefund``.ASN1, true)]


type ``TotalAdvisedChargeValueList``(* [Application 361] *) = { Items : TotalAdvisedChargeValue list } 
    with static member ASN1 = createSequenceOfMeta<``TotalAdvisedChargeValueList``> (Some { ClassNumber = 361; Class = Application }) (``TotalAdvisedChargeValue``.ASN1)
         static member create data : ``TotalAdvisedChargeValueList`` = { Items = data |> Seq.cast<``TotalAdvisedChargeValue``> |> Seq.toList }


type ``TotalCallEventDuration``(* [Application 223] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``TotalCallEventDuration``> (Some { ClassNumber = 223; Class = Application })
         static member create data : ``TotalCallEventDuration`` = { Item = ``Integer``.create data }


type ``TotalCharge``(* [Application 415] *) = { Item : ``AbsoluteAmount``  }
    with static member ASN1 = createPrimitiveMeta<``TotalCharge``> (Some { ClassNumber = 415; Class = Application })
         static member create data : ``TotalCharge`` = { Item = ``AbsoluteAmount``.create data }


type ``TotalChargeRefund``(* [Application 355] *) = { Item : ``AbsoluteAmount``  }
    with static member ASN1 = createPrimitiveMeta<``TotalChargeRefund``> (Some { ClassNumber = 355; Class = Application })
         static member create data : ``TotalChargeRefund`` = { Item = ``AbsoluteAmount``.create data }


type ``TotalCommission``(* [Application 358] *) = { Item : ``AbsoluteAmount``  }
    with static member ASN1 = createPrimitiveMeta<``TotalCommission``> (Some { ClassNumber = 358; Class = Application })
         static member create data : ``TotalCommission`` = { Item = ``AbsoluteAmount``.create data }


type ``TotalCommissionRefund``(* [Application 359] *) = { Item : ``AbsoluteAmount``  }
    with static member ASN1 = createPrimitiveMeta<``TotalCommissionRefund``> (Some { ClassNumber = 359; Class = Application })
         static member create data : ``TotalCommissionRefund`` = { Item = ``AbsoluteAmount``.create data }


type ``TotalDataVolume``(* [Application 343] *) = { Item : ``DataVolume``  }
    with static member ASN1 = createPrimitiveMeta<``TotalDataVolume``> (Some { ClassNumber = 343; Class = Application })
         static member create data : ``TotalDataVolume`` = { Item = ``DataVolume``.create data }


type ``TotalDiscountRefund``(* [Application 354] *) = { Item : ``AbsoluteAmount``  }
    with static member ASN1 = createPrimitiveMeta<``TotalDiscountRefund``> (Some { ClassNumber = 354; Class = Application })
         static member create data : ``TotalDiscountRefund`` = { Item = ``AbsoluteAmount``.create data }


type ``TotalDiscountValue``(* [Application 225] *) = { Item : ``AbsoluteAmount``  }
    with static member ASN1 = createPrimitiveMeta<``TotalDiscountValue``> (Some { ClassNumber = 225; Class = Application })
         static member create data : ``TotalDiscountValue`` = { Item = ``AbsoluteAmount``.create data }


type ``TotalTaxRefund``(* [Application 353] *) = { Item : ``AbsoluteAmount``  }
    with static member ASN1 = createPrimitiveMeta<``TotalTaxRefund``> (Some { ClassNumber = 353; Class = Application })
         static member create data : ``TotalTaxRefund`` = { Item = ``AbsoluteAmount``.create data }


type ``TotalTaxValue``(* [Application 226] *) = { Item : ``AbsoluteAmount``  }
    with static member ASN1 = createPrimitiveMeta<``TotalTaxValue``> (Some { ClassNumber = 226; Class = Application })
         static member create data : ``TotalTaxValue`` = { Item = ``AbsoluteAmount``.create data }


type ``TotalTransactionDuration``(* [Application 416] *) = { Item : ``TotalCallEventDuration``  }
    with static member ASN1 = createPrimitiveMeta<``TotalTransactionDuration``> (Some { ClassNumber = 416; Class = Application })
         static member create data : ``TotalTransactionDuration`` = { Item = ``TotalCallEventDuration``.create data }



type ``TrackedCustomerEquipment``(* [Application 381] *) = {
    equipmentIdType : EquipmentIdType option;
    equipmentId : EquipmentId option
} 
    with static member ASN1 = createSequenceMeta<``TrackedCustomerEquipment``> (Some { ClassNumber = 381; Class = Application }) [("equipmentIdType", ``EquipmentIdType``.ASN1, true);("equipmentId", ``EquipmentId``.ASN1, true)]



type ``TrackedCustomerHomeId``(* [Application 377] *) = {
    homeIdType : HomeIdType option;
    homeIdentifier : HomeIdentifier option
} 
    with static member ASN1 = createSequenceMeta<``TrackedCustomerHomeId``> (Some { ClassNumber = 377; Class = Application }) [("homeIdType", ``HomeIdType``.ASN1, true);("homeIdentifier", ``HomeIdentifier``.ASN1, true)]


type ``TrackedCustomerHomeIdList``(* [Application 376] *) = { Items : TrackedCustomerHomeId list } 
    with static member ASN1 = createSequenceOfMeta<``TrackedCustomerHomeIdList``> (Some { ClassNumber = 376; Class = Application }) (``TrackedCustomerHomeId``.ASN1)
         static member create data : ``TrackedCustomerHomeIdList`` = { Items = data |> Seq.cast<``TrackedCustomerHomeId``> |> Seq.toList }



type ``TrackedCustomerIdentification``(* [Application 372] *) = {
    customerIdType : CustomerIdType option;
    customerIdentifier : CustomerIdentifier option
} 
    with static member ASN1 = createSequenceMeta<``TrackedCustomerIdentification``> (Some { ClassNumber = 372; Class = Application }) [("customerIdType", ``CustomerIdType``.ASN1, true);("customerIdentifier", ``CustomerIdentifier``.ASN1, true)]


type ``TrackedCustomerIdList``(* [Application 370] *) = { Items : TrackedCustomerIdentification list } 
    with static member ASN1 = createSequenceOfMeta<``TrackedCustomerIdList``> (Some { ClassNumber = 370; Class = Application }) (``TrackedCustomerIdentification``.ASN1)
         static member create data : ``TrackedCustomerIdList`` = { Items = data |> Seq.cast<``TrackedCustomerIdentification``> |> Seq.toList }



type ``TrackedCustomerInformation``(* [Application 367] *) = {
    trackedCustomerIdList : TrackedCustomerIdList option;
    trackedCustomerHomeIdList : TrackedCustomerHomeIdList option;
    trackedCustomerLocList : TrackedCustomerLocList option;
    trackedCustomerEquipment : TrackedCustomerEquipment option
} 
    with static member ASN1 = createSequenceMeta<``TrackedCustomerInformation``> (Some { ClassNumber = 367; Class = Application }) [("trackedCustomerIdList", ``TrackedCustomerIdList``.ASN1, true);("trackedCustomerHomeIdList", ``TrackedCustomerHomeIdList``.ASN1, true);("trackedCustomerLocList", ``TrackedCustomerLocList``.ASN1, true);("trackedCustomerEquipment", ``TrackedCustomerEquipment``.ASN1, true)]



type ``TrackedCustomerLocation``(* [Application 380] *) = {
    locationIdType : LocationIdType option;
    locationIdentifier : LocationIdentifier option
} 
    with static member ASN1 = createSequenceMeta<``TrackedCustomerLocation``> (Some { ClassNumber = 380; Class = Application }) [("locationIdType", ``LocationIdType``.ASN1, true);("locationIdentifier", ``LocationIdentifier``.ASN1, true)]


type ``TrackedCustomerLocList``(* [Application 379] *) = { Items : TrackedCustomerLocation list } 
    with static member ASN1 = createSequenceOfMeta<``TrackedCustomerLocList``> (Some { ClassNumber = 379; Class = Application }) (``TrackedCustomerLocation``.ASN1)
         static member create data : ``TrackedCustomerLocList`` = { Items = data |> Seq.cast<``TrackedCustomerLocation``> |> Seq.toList }



type ``TrackingCustomerEquipment``(* [Application 371] *) = {
    equipmentIdType : EquipmentIdType option;
    equipmentId : EquipmentId option
} 
    with static member ASN1 = createSequenceMeta<``TrackingCustomerEquipment``> (Some { ClassNumber = 371; Class = Application }) [("equipmentIdType", ``EquipmentIdType``.ASN1, true);("equipmentId", ``EquipmentId``.ASN1, true)]



type ``TrackingCustomerHomeId``(* [Application 366] *) = {
    homeIdType : HomeIdType option;
    homeIdentifier : HomeIdentifier option
} 
    with static member ASN1 = createSequenceMeta<``TrackingCustomerHomeId``> (Some { ClassNumber = 366; Class = Application }) [("homeIdType", ``HomeIdType``.ASN1, true);("homeIdentifier", ``HomeIdentifier``.ASN1, true)]


type ``TrackingCustomerHomeIdList``(* [Application 365] *) = { Items : TrackingCustomerHomeId list } 
    with static member ASN1 = createSequenceOfMeta<``TrackingCustomerHomeIdList``> (Some { ClassNumber = 365; Class = Application }) (``TrackingCustomerHomeId``.ASN1)
         static member create data : ``TrackingCustomerHomeIdList`` = { Items = data |> Seq.cast<``TrackingCustomerHomeId``> |> Seq.toList }



type ``TrackingCustomerIdentification``(* [Application 362] *) = {
    customerIdType : CustomerIdType option;
    customerIdentifier : CustomerIdentifier option
} 
    with static member ASN1 = createSequenceMeta<``TrackingCustomerIdentification``> (Some { ClassNumber = 362; Class = Application }) [("customerIdType", ``CustomerIdType``.ASN1, true);("customerIdentifier", ``CustomerIdentifier``.ASN1, true)]


type ``TrackingCustomerIdList``(* [Application 299] *) = { Items : TrackingCustomerIdentification list } 
    with static member ASN1 = createSequenceOfMeta<``TrackingCustomerIdList``> (Some { ClassNumber = 299; Class = Application }) (``TrackingCustomerIdentification``.ASN1)
         static member create data : ``TrackingCustomerIdList`` = { Items = data |> Seq.cast<``TrackingCustomerIdentification``> |> Seq.toList }



type ``TrackingCustomerInformation``(* [Application 298] *) = {
    trackingCustomerIdList : TrackingCustomerIdList option;
    trackingCustomerHomeIdList : TrackingCustomerHomeIdList option;
    trackingCustomerLocList : TrackingCustomerLocList option;
    trackingCustomerEquipment : TrackingCustomerEquipment option
} 
    with static member ASN1 = createSequenceMeta<``TrackingCustomerInformation``> (Some { ClassNumber = 298; Class = Application }) [("trackingCustomerIdList", ``TrackingCustomerIdList``.ASN1, true);("trackingCustomerHomeIdList", ``TrackingCustomerHomeIdList``.ASN1, true);("trackingCustomerLocList", ``TrackingCustomerLocList``.ASN1, true);("trackingCustomerEquipment", ``TrackingCustomerEquipment``.ASN1, true)]



type ``TrackingCustomerLocation``(* [Application 369] *) = {
    locationIdType : LocationIdType option;
    locationIdentifier : LocationIdentifier option
} 
    with static member ASN1 = createSequenceMeta<``TrackingCustomerLocation``> (Some { ClassNumber = 369; Class = Application }) [("locationIdType", ``LocationIdType``.ASN1, true);("locationIdentifier", ``LocationIdentifier``.ASN1, true)]


type ``TrackingCustomerLocList``(* [Application 368] *) = { Items : TrackingCustomerLocation list } 
    with static member ASN1 = createSequenceOfMeta<``TrackingCustomerLocList``> (Some { ClassNumber = 368; Class = Application }) (``TrackingCustomerLocation``.ASN1)
         static member create data : ``TrackingCustomerLocList`` = { Items = data |> Seq.cast<``TrackingCustomerLocation``> |> Seq.toList }


type ``TrackingFrequency``(* [Application 389] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``TrackingFrequency``> (Some { ClassNumber = 389; Class = Application })
         static member create data : ``TrackingFrequency`` = { Item = ``Integer``.create data }


type ``TrackingPeriod``(* [Application 388] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``TrackingPeriod``> (Some { ClassNumber = 388; Class = Application })
         static member create data : ``TrackingPeriod`` = { Item = ``Integer``.create data }


type ``TransactionAuthCode``(* [Application 342] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``TransactionAuthCode``> (Some { ClassNumber = 342; Class = Application })
         static member create data : ``TransactionAuthCode`` = { Item = ``AsciiString``.create data }


type ``TransactionDescriptionSupp``(* [Application 338] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``TransactionDescriptionSupp``> (Some { ClassNumber = 338; Class = Application })
         static member create data : ``TransactionDescriptionSupp`` = { Item = ``Integer``.create data }


type ``TransactionDetailDescription``(* [Application 339] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``TransactionDetailDescription``> (Some { ClassNumber = 339; Class = Application })
         static member create data : ``TransactionDetailDescription`` = { Item = ``AsciiString``.create data }


type ``TransactionIdentifier``(* [Application 341] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``TransactionIdentifier``> (Some { ClassNumber = 341; Class = Application })
         static member create data : ``TransactionIdentifier`` = { Item = ``AsciiString``.create data }


type ``TransactionShortDescription``(* [Application 340] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``TransactionShortDescription``> (Some { ClassNumber = 340; Class = Application })
         static member create data : ``TransactionShortDescription`` = { Item = ``AsciiString``.create data }


type ``TransactionStatus``(* [Application 303] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``TransactionStatus``> (Some { ClassNumber = 303; Class = Application })
         static member create data : ``TransactionStatus`` = { Item = ``Integer``.create data }


type ``TransferCutOffTimeStamp``(* [Application 227] *) = { Item : ``DateTimeLong`` }
    with static member ASN1 = createReferenceMeta<``TransferCutOffTimeStamp``> (Some { ClassNumber = 227; Class = Application }) "DateTimeLong" (``DateTimeLong``.ASN1)
         static member create data : ``TransferCutOffTimeStamp`` = { Item = data }


type ``TransparencyIndicator``(* [Application 228] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``TransparencyIndicator``> (Some { ClassNumber = 228; Class = Application })
         static member create data : ``TransparencyIndicator`` = { Item = ``Integer``.create data }


type ``UserProtocolIndicator``(* [Application 280] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``UserProtocolIndicator``> (Some { ClassNumber = 280; Class = Application })
         static member create data : ``UserProtocolIndicator`` = { Item = ``Integer``.create data }


type ``UtcTimeOffset``(* [Application 231] *) = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``UtcTimeOffset``> (Some { ClassNumber = 231; Class = Application })
         static member create data : ``UtcTimeOffset`` = { Item = ``AsciiString``.create data }


type ``UtcTimeOffsetCode``(* [Application 232] *) = { Item : ``Code``  }
    with static member ASN1 = createPrimitiveMeta<``UtcTimeOffsetCode``> (Some { ClassNumber = 232; Class = Application })
         static member create data : ``UtcTimeOffsetCode`` = { Item = ``Code``.create data }



type ``UtcTimeOffsetInfo``(* [Application 233] *) = {
    utcTimeOffsetCode : UtcTimeOffsetCode option;
    utcTimeOffset : UtcTimeOffset option
} 
    with static member ASN1 = createSequenceMeta<``UtcTimeOffsetInfo``> (Some { ClassNumber = 233; Class = Application }) [("utcTimeOffsetCode", ``UtcTimeOffsetCode``.ASN1, true);("utcTimeOffset", ``UtcTimeOffset``.ASN1, true)]


type ``UtcTimeOffsetInfoList``(* [Application 234] *) = { Items : UtcTimeOffsetInfo list } 
    with static member ASN1 = createSequenceOfMeta<``UtcTimeOffsetInfoList``> (Some { ClassNumber = 234; Class = Application }) (``UtcTimeOffsetInfo``.ASN1)
         static member create data : ``UtcTimeOffsetInfoList`` = { Items = data |> Seq.cast<``UtcTimeOffsetInfo``> |> Seq.toList }


type ``VerticalAccuracyDelivered``(* [Application 393] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``VerticalAccuracyDelivered``> (Some { ClassNumber = 393; Class = Application })
         static member create data : ``VerticalAccuracyDelivered`` = { Item = ``Integer``.create data }


type ``VerticalAccuracyRequested``(* [Application 386] *) = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``VerticalAccuracyRequested``> (Some { ClassNumber = 386; Class = Application })
         static member create data : ``VerticalAccuracyRequested`` = { Item = ``Integer``.create data }


type ``AbsoluteAmount`` = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``AbsoluteAmount``> None
         static member create data : ``AbsoluteAmount`` = { Item = ``Integer``.create data }

type ``Bid`` = { Item : AsciiString }
    with static member ASN1 = createPrimitiveMeta<``Bid``> None
         static member create data : ``Bid`` = { Item = ``AsciiString``.create data }

type ``Code`` = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``Code``> None
         static member create data : ``Code`` = { Item = ``Integer``.create data }

type ``AsciiString`` = { Item : ``MyVisibleString``  }
    with static member ASN1 = createPrimitiveMeta<``AsciiString``> None
         static member create data : ``AsciiString`` = { Item = ``MyVisibleString``.create data }

type ``Currency`` = { Item : ``MyVisibleString``  }
    with static member ASN1 = createPrimitiveMeta<``Currency``> None
         static member create data : ``Currency`` = { Item = ``MyVisibleString``.create data }

type ``HexString`` = { Item : ``MyVisibleString``  }
    with static member ASN1 = createPrimitiveMeta<``HexString``> None
         static member create data : ``HexString`` = { Item = ``MyVisibleString``.create data }

type ``NumberString`` = { Item : ``MyVisibleString``  }
    with static member ASN1 = createPrimitiveMeta<``NumberString``> None
         static member create data : ``NumberString`` = { Item = ``MyVisibleString``.create data }

type ``MyVisibleString`` = { Item : OctetString }
    with static member ASN1 = createPrimitiveMeta<``MyVisibleString``> None
         static member create data : ``MyVisibleString`` = { Item = ``OctetString``.create data }

type ``BCDString`` = { Item : OctetString }
    with static member ASN1 = createPrimitiveMeta<``BCDString``> None
         static member create data : ``BCDString`` = { Item = ``OctetString``.create data }

type ``PercentageRate`` = { Item : Integer }
    with static member ASN1 = createPrimitiveMeta<``PercentageRate``> None
         static member create data : ``PercentageRate`` = { Item = ``Integer``.create data }

