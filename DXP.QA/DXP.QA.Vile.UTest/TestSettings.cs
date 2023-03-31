
using System.Configuration;

namespace DXP.QA.Vile.UTest
{
    public class TestSettings
    {
        private static double ParseTimeout(string timeoutConfigValue)
        {
            double.TryParse(ConfigurationManager.AppSettings[timeoutConfigValue], out var parseTimeout);
            return parseTimeout;
        }

        private static string _azureSubscriptionId;

        private static string _azurePoolSubscriptionId;

        public static string BaseUrl => ConfigurationManager.AppSettings[nameof(BaseUrl)];

        public static string PaasTestDomainName => ConfigurationManager.AppSettings["PaasTestDomainName"];

        public static string PartialZoneName => ConfigurationManager.AppSettings[nameof(PartialZoneName)];

        public static string FullZoneName => ConfigurationManager.AppSettings[nameof(FullZoneName)];

        public static string CustomHostnameResourceGroup => ConfigurationManager.AppSettings[nameof(CustomHostnameResourceGroup)];

        public static string AdminUserName => ConfigurationManager.AppSettings[nameof(AdminUserName)];

        public static string ProjectUserName => ConfigurationManager.AppSettings[nameof(ProjectUserName)];

        public static string ReaderUserName => ConfigurationManager.AppSettings[nameof(ReaderUserName)];

        public static string ReaderMarketerUserName => ConfigurationManager.AppSettings[nameof(ReaderMarketerUserName)];

        public static string PowerUserName => ConfigurationManager.AppSettings[nameof(PowerUserName)];

        public static string AzureActiveDirectoryTenantDomain => ConfigurationManager.AppSettings[nameof(AzureActiveDirectoryTenantDomain)];

        public static string AzureActiveDirectoryClientId => ConfigurationManager.AppSettings["Azure.ActiveDirectory.ClientId"];
        public static string AzureServiceAccountUserName => ConfigurationManager.AppSettings["Azure.ServiceAccount.UserName"];
        public static string AzureServiceAccountPassword => ConfigurationManager.AppSettings["Azure.ServiceAccount.Password"];

        public static string AzureActiveDirectoryClientSecret => ConfigurationManager.AppSettings["Azure.ActiveDirectory.ClientKey"];

        public static string AzureTenantId => ConfigurationManager.AppSettings[nameof(AzureTenantId)];

        public static string ApiEmail => ConfigurationManager.AppSettings[nameof(ApiEmail)];

        public static string ApiToken => ConfigurationManager.AppSettings[nameof(ApiToken)];

        public static string AzureSubscriptionId
        {
            get => _azureSubscriptionId ?? ConfigurationManager.AppSettings[nameof(AzureSubscriptionId)];
            set => _azureSubscriptionId = value;
        }

        public static string AzurePoolSubscriptionId
        {
            get => _azurePoolSubscriptionId ?? ConfigurationManager.AppSettings[nameof(AzurePoolSubscriptionId)];
            set => _azurePoolSubscriptionId = value;
        }

        public static string MockInfrastructureApiKey => ConfigurationManager.AppSettings[(MockInfrastructureApiKey)];

        public static double AlloySiteDeploymentTimeoutInMinutes => ParseTimeout(nameof(AlloySiteDeploymentTimeoutInMinutes));

        public static double QuicksilverSiteDeploymentTimeoutInMinutes => ParseTimeout(nameof(QuicksilverSiteDeploymentTimeoutInMinutes));

        public static string OrderNumbers => "61398,84044";

        public static string NugetQuickSilverDeploymentPackage => ConfigurationManager.AppSettings[nameof(NugetQuickSilverDeploymentPackage)];

        public static string AlloyDeploymentNugetPackageLinux => ConfigurationManager.AppSettings[nameof(AlloyDeploymentNugetPackageLinux)];

        public static string AlloyDeploymentNugetPackageWindow => ConfigurationManager.AppSettings[nameof(AlloyDeploymentNugetPackageWindow)];
    }
}
