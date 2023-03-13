using Business.Concrete;
using Core.Utilities.IoC;
using Entities.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Constants
{
    public class Messages
    {
        internal static string TaxonomizedDeviceAlreadyExists => LanguageManager.GetLanguage()["taxonomizedDeviceAlreadyExists"].ToString();

        public static string PleaseAddReportField => LanguageManager.GetLanguage()["pleaseaddreportstore"].ToString();
        public static string Successful => LanguageManager.GetLanguage()["successful"].ToString();
        public static string Unsuccessful => LanguageManager.GetLanguage()["unsuccessful"].ToString();
        public static string DeviceFlagAlreadyExists => LanguageManager.GetLanguage()["deviceFlagAlreadyExists"].ToString();
        public static string newOperationClaimAdded => LanguageManager.GetLanguage()["newOperationClaimAdded"].ToString();
        public static string DeviceAdded => LanguageManager.GetLanguage()["deviceAdded"].ToString();
        public static string NewErrorOccurred => LanguageManager.GetLanguage()["newErrorOccured"].ToString();
        public static string SonicWallTZ300WParserSelected => LanguageManager.GetLanguage()["sonicWallTZ300WParserSelected"].ToString();
        public static string NewSupportedDeviceOccurred => LanguageManager.GetLanguage()["newSupportedDeviceOccurred"].ToString();
        public static string NewLogAdded => LanguageManager.GetLanguage()["newLogAdded"].ToString();

        public static string ReportStoreAlreadyExists => LanguageManager.GetLanguage()["reportStoreAlreadyExists"].ToString();
        public static string ReportAlreadyExists => LanguageManager.GetLanguage()["reportAlreadyExists"].ToString();
        public static string DeviceColumCannotBeEmpty => LanguageManager.GetLanguage()["deviceColumnCannotBeEmpty"].ToString();
        public static string DeviceColumnAlreadyExists => LanguageManager.GetLanguage()["deviceColumnAlreadtyExists"].ToString();
        public static string MatchedDataAlreadyExists => LanguageManager.GetLanguage()["matchedDataAlreadyExists"].ToString();
        public static string PleaseSelectDifferentDevice => LanguageManager.GetLanguage()["pleaseSelectDifferentDevice"].ToString();
        public static string AddingSuccessful => LanguageManager.GetLanguage()["addingSuccessful"].ToString();
        public static string DeletionSuccessful => LanguageManager.GetLanguage()["deletionSuccessful"].ToString();
        public static string UpdateSuccessful => LanguageManager.GetLanguage()["updateSuccessful"].ToString();
        public static string ThisDeviceAlreadyExists => LanguageManager.GetLanguage()["thisDeviceAlreadyExists"].ToString();
        public static string AuthorizationDenied => LanguageManager.GetLanguage()["authorizationDenied"].ToString();
        public static string UserRegistered => LanguageManager.GetLanguage()["userRegistered"].ToString();
        public static string UserNotFound => LanguageManager.GetLanguage()["userNotFound"].ToString();
        public static string PasswordError => LanguageManager.GetLanguage()["passwordError"].ToString();
        public static string SuccessfulLogin => LanguageManager.GetLanguage()["successfulLogin"].ToString();
        public static string UserAlreadyExists => LanguageManager.GetLanguage()["userAlreadyExists"].ToString();
        public static string AccessTokenCreated => LanguageManager.GetLanguage()["accessTokenCreated"].ToString();
        public static string unauthorizedAccess => LanguageManager.GetLanguage()["unauthorizedAccess"].ToString();
        public static string SuperUserCannotBeDeleted => LanguageManager.GetLanguage()["superUserCannotBeDeleted"].ToString();


        public static string UserUpdated => LanguageManager.GetLanguage()["userUpdated"].ToString();

        public static string ThisOperationClaimAlreadyExists => LanguageManager.GetLanguage()["thisOperationClaimAlreadyExists"].ToString();

        public static string NewDeviceParserAdded => LanguageManager.GetLanguage()["newDeviceParserAdded"].ToString();

        public static string ADeviceParserDeleted => LanguageManager.GetLanguage()["aDeviceParserDeleted"].ToString();
        public static string ADeviceParserUpdated => LanguageManager.GetLanguage()["aDeviceParserUpdated"].ToString();

        public static string DiscoveredDeviceAdded => LanguageManager.GetLanguage()["discoveredDeviceAdded"].ToString();
        public static string DiscoveredDeviceUpdated => LanguageManager.GetLanguage()["discoveredDeviceUpdated"].ToString();
        public static string DiscoveredDeviceDeleted => LanguageManager.GetLanguage()["discoveredDeviceDeleted"].ToString();

        public static string ThisDeviceParserAlreadyExists => LanguageManager.GetLanguage()["thisDeviceParserAlreadyExists"].ToString();

        public static string DiscoveredDeviceAddedToUsedDevice => LanguageManager.GetLanguage()["discoveredDeviceAddedToUsedDevice"].ToString();

        public static string EmailConfigDeleted => LanguageManager.GetLanguage()["emailConfigDeleted"].ToString();

        public static string MessageSentSuccessfully => LanguageManager.GetLanguage()["messageSentSuccessfully"].ToString();

        public static string AnErrorOccurredDuringTheUpdateProcess => LanguageManager.GetLanguage()["anErrorOccurredDuringTheUpdateProcess"].ToString();

        public static string AnErrorOccurredDuringTheDeleteProcess => LanguageManager.GetLanguage()["anErrorOccurredDuringTheDeleteProcess"].ToString();
        public static string DeDuplicationServiceIsStarted => LanguageManager.GetLanguage()["deDuplicationServiceIsStarted"].ToString();
        public static string DeDuplicationServiceCompletedSuccessfully => LanguageManager.GetLanguage()["deDuplicationServiceCompletedSuccessfully"].ToString();
        public static string HealthCheckServiceIsStarted => LanguageManager.GetLanguage()["healthCheckServiceIsStarted"].ToString();
        public static string HealthCheckServiceCompletedSuccessfully => LanguageManager.GetLanguage()["healthCheckServiceCompletedSuccessfully"].ToString();
        public static string TimeStampLimitExceded => LanguageManager.GetLanguage()["timeStampLimitExceded"].ToString();

        public static string CustomerInformationAlreadyExists => LanguageManager.GetLanguage()["customerInformationAlreadyExists"].ToString();

        public static string RabbitMQConnectionSettingLimitExceded => LanguageManager.GetLanguage()["rabbitMQConnectionSettingLimitExceded"].ToString();
        public static string RabbitMQConnectionError => LanguageManager.GetLanguage()["rabbitMQConnectionError"].ToString();

        public static string IndexingWasSuccessful => LanguageManager.GetLanguage()["indexingWasSuccessful"].ToString();

        public static string UsedDeviceAlreadyExists => LanguageManager.GetLanguage()["usedDeviceAlreadyExists"].ToString();

        public static string MailConfigAlreadyExists => LanguageManager.GetLanguage()["mailConfigAlreadyExists"].ToString();

        public static string LicenseConfigAlreadyExists => LanguageManager.GetLanguage()["licenseConfigAlreadyExists"].ToString();

        public static string CustomerInfırmationAlreadyExists => LanguageManager.GetLanguage()["customerInfırmationAlreadyExists"].ToString();

        public static string MissingOrIncorrectEntry => LanguageManager.GetLanguage()["missingOrIncorrectEntry"].ToString();
        public static string NoDataFound => LanguageManager.GetLanguage()["noDataFound"].ToString();
        public static string AddingUnSuccessful => LanguageManager.GetLanguage()["addingUnSuccessful"].ToString();

        public static string VouncherAlreadyExists => LanguageManager.GetLanguage()["VouncherAlreadyExists"].ToString();

        public static string AnErrorOccurredWhileSearchingforDeviceLogs = LanguageManager.GetLanguage()["AnErrorOccurredWhileSearchingforDeviceLogs"].ToString();

        public static string ArchiveConfigurationsAlreadyExists = LanguageManager.GetLanguage()["ArchiveConfigurationsAlreadyExists"].ToString();



    }
}
