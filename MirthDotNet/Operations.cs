using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MirthDotNet
{
    public static class Operations
    {
        // Alerts
        public static readonly Operation ALERT_GET = new Operation("getAlert", "Get alert", true);
        public static readonly Operation ALERT_UPDATE = new Operation("updateAlerts", "Update alerts", true);
        public static readonly Operation ALERT_REMOVE = new Operation("removeAlert", "Remove alert", true);
        public static readonly Operation ALERT_ENABLE = new Operation("enableAlert", "Enable alert", true);
        public static readonly Operation ALERT_DISABLE = new Operation("disableAlert", "Disable alert", true);
        public static readonly Operation ALERT_GET_STATUS = new Operation("getAlertStatusList", "Get alert status list", false);

        // Channels
        public static readonly Operation CHANNEL_GET = new Operation("getChannel", "Get channel", true);
        public static readonly Operation CHANNEL_UPDATE = new Operation("updateChannel", "Update channel", true);
        public static readonly Operation CHANNEL_REMOVE = new Operation("removeChannel", "Remove channel", true);
        public static readonly Operation CHANNEL_GET_SUMMARY = new Operation("getChannelSummary", "Get channel summary", false);
        public static readonly Operation CHANNEL_GET_TAGS = new Operation("getChannelTags", "Get channel tags", false);
        public static readonly Operation CHANNEL_GET_CONNECTOR_NAMES = new Operation("getConnectorNames", "Get connector names", false);
        public static readonly Operation CHANNEL_GET_METADATA_COLUMNS = new Operation("getMetaDataColumns", "Get metadata columns", false);

        // Channel Statistics
        public static readonly Operation CHANNEL_STATS_GET = new Operation("getStatistics", "Get statistics", false);
        public static readonly Operation CHANNEL_STATS_CLEAR = new Operation("clearStatistics", "Clear statistics", true);
        public static readonly Operation CHANNEL_STATS_CLEAR_ALL = new Operation("clearAllStatistics", "Clear all statistics", true);

        // Channel Status
        public static readonly Operation CHANNEL_START = new Operation("startChannel", "Start channel", true);
        public static readonly Operation CHANNEL_STOP = new Operation("stopChannel", "Stop channel", true);
        public static readonly Operation CHANNEL_HALT = new Operation("haltChannel", "Halt channel", true);
        public static readonly Operation CHANNEL_PAUSE = new Operation("pauseChannel", "Pause channel", true);
        public static readonly Operation CHANNEL_RESUME = new Operation("resumeChannel", "Resume channel", true);
        public static readonly Operation CHANNEL_START_CONNECTOR = new Operation("startConnector", "Start connector", true);
        public static readonly Operation CHANNEL_STOP_CONNECTOR = new Operation("stopConnector", "Stop connector", true);
        public static readonly Operation CHANNEL_GET_STATUS = new Operation("getChannelStatusList", "Get channel status list", false);

        // Code Templates
        public static readonly Operation CODE_TEMPLATE_GET = new Operation("getCodeTemplate", "Get code template", true);
        public static readonly Operation CODE_TEMPLATE_UPDATE = new Operation("updateCodeTemplates", "Update code template", true);
        public static readonly Operation CODE_TEMPLATE_REMOVE = new Operation("removeCodeTemplate", "Remove code template", true);

        // Configuration
        public static readonly Operation GLOBAL_SCRIPT_GET = new Operation("getGlobalScripts", "Get global scripts", true);
        public static readonly Operation GLOBAL_SCRIPT_SET = new Operation("setGlobalScripts", "Set global scripts", true);
        public static readonly Operation CONFIGURATION_CHARSET_ENCODINGS_GET = new Operation("getAvailableCharsetEncodings", "Get available charset encodings", false);
        public static readonly Operation CONFIGURATION_SERVER_SETTINGS_GET = new Operation("getServerSettings", "Get server settings", true);
        public static readonly Operation CONFIGURATION_SERVER_SETTINGS_SET = new Operation("setServerSettings", "Set server settings", true);
        public static readonly Operation CONFIGURATION_UPDATE_SETTINGS_GET = new Operation("getUpdateSettings", "Get update settings", false);
        public static readonly Operation CONFIGURATION_UPDATE_SETTINGS_SET = new Operation("setUpdateSettings", "Set update settings", true);
        public static readonly Operation CONFIGURATION_ENCRYPTION_SETTINGS_GET = new Operation("getEncryptionSettings", "Get encryption settings", true);
        public static readonly Operation CONFIGURATION_GUID_GET = new Operation("getGuid", "Get GUID", false);
        public static readonly Operation CONFIGURATION_DATABASE_DRIVERS_GET = new Operation("getDatabaseDrivers", "Get database drivers", false);
        public static readonly Operation CONFIGURATION_VERSION_GET = new Operation("getVersion", "Get version", false);
        public static readonly Operation CONFIGURATION_BUILD_DATE_GET = new Operation("getBuildDate", "Get build date", false);
        public static readonly Operation SERVER_CONFIGURATION_GET = new Operation("getServerConfiguration", "Get server configuration", true);
        public static readonly Operation SERVER_CONFIGURATION_SET = new Operation("setServerConfiguration", "Set server configuration", true);
        public static readonly Operation CONFIGURATION_SERVER_ID_GET = new Operation("getServerId", "Get server ID", false);
        public static readonly Operation CONFIGURATION_SERVER_TIMEZONE_GET = new Operation("getServerTimezone", "Get server timezone", false);
        public static readonly Operation CONFIGURATION_PASSWORD_REQUIREMENTS_GET = new Operation("getPasswordRequirements", "Get password requirements", true);
        public static readonly Operation CONFIGURATION_STATUS_GET = new Operation("getStatus", "Get status", true);

        // Engine
        public static readonly Operation CHANNEL_DEPLOY = new Operation("deployChannels", "Deploy channels", true);
        public static readonly Operation CHANNEL_REDEPLOY = new Operation("redeployAllChannels", "Redeploy all channels", true);
        public static readonly Operation CHANNEL_UNDEPLOY = new Operation("undeployChannels", "Undeploy channels", true);

        // Extensions
        public static readonly Operation PLUGIN_PROPERTIES_GET = new Operation("getPluginProperties", "Get plugin properties", true);
        public static readonly Operation PLUGIN_PROPERTIES_SET = new Operation("setPluginProperties", "Set plugin properties", true);
        public static readonly Operation PLUGIN_METADATA_GET = new Operation("getPluginMetaData", "Get plugin metadata", true);
        public static readonly Operation CONNECTOR_METADATA_GET = new Operation("getConnectorMetaData", "Get connector metadata", true);
        public static readonly Operation PLUGIN_SERVICE_INVOKE = new Operation("invoke", "Invoke plugin service", true);
        public static readonly Operation CONNECTOR_SERVICE_INVOKE = new Operation("invokeConnectorService", "Invoke connector service", true);
        public static readonly Operation EXTENSION_INSTALL = new Operation("installExtension", "Install extension", true);
        public static readonly Operation EXTENSION_UNINSTALL = new Operation("uninstallExtension", "Uninstall extension", true);
        public static readonly Operation EXTENSION_IS_ENABLED = new Operation("isExtensionEnabled", "Check if extension is installed", true);
        public static readonly Operation EXTENSION_SET_ENABLED = new Operation("setExtensionEnabled", "Enable or disable an extension", true);

        // Messages
        public static readonly Operation MESSAGE_GET_MAX_ID = new Operation("getMaxMessageId", "Get max messageId", false);
        public static readonly Operation MESSAGE_GET = new Operation("searchMessages", "Get messages by page limit", true);
        public static readonly Operation MESSAGE_GET_COUNT = new Operation("getSearchCount", "Get search results count", true);
        public static readonly Operation MESSAGE_GET_CONTENT = new Operation("getMessageContent", "Get message content", true);
        public static readonly Operation MESSAGE_REMOVE = new Operation("removeMessages", "Remove messages", true);
        public static readonly Operation MESSAGE_CLEAR = new Operation("clearMessages", "Clear messages", true);
        public static readonly Operation MESSAGE_PROCESS = new Operation("processMessages", "Process messages", true);
        public static readonly Operation MESSAGE_REPROCESS = new Operation("reprocessMessages", "Reprocess messages", true);
        public static readonly Operation MESSAGE_IMPORT = new Operation("importMessage", "Import message", true);
        public static readonly Operation MESSAGE_IMPORT_SERVER = new Operation("importMessageServer", "Import messages on the server", true);
        public static readonly Operation MESSAGE_EXPORT = new Operation("exportMessage", "Export message", true);
        public static readonly Operation MESSAGE_ATTACHMENT_GET = new Operation("getAttachment", "Get attachment", true);
        public static readonly Operation MESSAGE_ATTACHMENT_GET_BY_MESSAGE_ID = new Operation("getAttachmentsByMessageId", "Get attachments by message ID", false);
        public static readonly Operation MESSAGE_ATTACHMENT_GET_ID_BY_MESSAGE_ID = new Operation("getAttachmentIdsByMessageId", "Get attachment IDs by message ID", false);
        public static readonly Operation MESSAGE_DICOM_MESSAGE_GET = new Operation("getDICOMMessage", "Get DICOM message", false);

        // Events
        public static readonly Operation EVENT_GET_MAX_ID = new Operation("getMaxEventId", "Get max eventId", false);
        public static readonly Operation EVENT_GET = new Operation("getEvents", "Get events by page limit", false);
        public static readonly Operation EVENT_GET_COUNT = new Operation("getEventCount", "Get events results count", false);
        public static readonly Operation EVENT_EXPORT_ALL = new Operation("exportAllEvents", "Export all events", true);
        public static readonly Operation EVENT_REMOVE_ALL = new Operation("removeAllEvents", "Remove all events", true);
        public static readonly Operation EVENT_EXPORT_AND_REMOVE_ALL = new Operation("exportAndRemoveAllEvents", "Export and remove all events", true);

        // Users
        public static readonly Operation USER_GET = new Operation("getUser", "Get user", false);
        public static readonly Operation USER_UPDATE = new Operation("updateUser", "Update all users", true);
        public static readonly Operation USER_CHECK_OR_UPDATE_PASSWORD = new Operation("checkOrUpdateUserPassword", "Update all user passwords", true);
        public static readonly Operation USER_REMOVE = new Operation("removeUser", "Remove user", true);
        public static readonly Operation USER_AUTHORIZE = new Operation("authorizeUser", "Authorize user", true);
        public static readonly Operation USER_LOGIN = new Operation("login", "Login", true);
        public static readonly Operation USER_LOGOUT = new Operation("logout", "Logout", true);
        public static readonly Operation USER_IS_USER_LOGGED_IN = new Operation("isUserLoggedIn", "Check if user is logged in", true);
        public static readonly Operation USER_PREFERENCES_GET = new Operation("getUserPreferences", "Get user preferences", true);
        public static readonly Operation USER_PREFERENCES_SET = new Operation("setUserPreference", "Set user preferences", true);

        private static IDictionary<String, Operation> operationMap = new Dictionary<String, Operation>();

        static Operations()
        {
            operationMap.Add(ALERT_GET.Name, ALERT_GET);
            operationMap.Add(ALERT_UPDATE.Name, ALERT_UPDATE);
            operationMap.Add(ALERT_REMOVE.Name, ALERT_REMOVE);
            operationMap.Add(ALERT_ENABLE.Name, ALERT_ENABLE);
            operationMap.Add(ALERT_DISABLE.Name, ALERT_DISABLE);
            operationMap.Add(ALERT_GET_STATUS.Name, ALERT_GET_STATUS);
            operationMap.Add(CHANNEL_GET.Name, CHANNEL_GET);
            operationMap.Add(CHANNEL_UPDATE.Name, CHANNEL_UPDATE);
            operationMap.Add(CHANNEL_REMOVE.Name, CHANNEL_REMOVE);
            operationMap.Add(CHANNEL_GET_SUMMARY.Name, CHANNEL_GET_SUMMARY);
            operationMap.Add(CHANNEL_GET_TAGS.Name, CHANNEL_GET_TAGS);
            operationMap.Add(CHANNEL_GET_CONNECTOR_NAMES.Name, CHANNEL_GET_CONNECTOR_NAMES);
            operationMap.Add(CHANNEL_GET_METADATA_COLUMNS.Name, CHANNEL_GET_METADATA_COLUMNS);
            operationMap.Add(CHANNEL_STATS_GET.Name, CHANNEL_STATS_GET);
            operationMap.Add(CHANNEL_STATS_CLEAR.Name, CHANNEL_STATS_CLEAR);
            operationMap.Add(CHANNEL_STATS_CLEAR_ALL.Name, CHANNEL_STATS_CLEAR_ALL);
            operationMap.Add(CHANNEL_START.Name, CHANNEL_START);
            operationMap.Add(CHANNEL_STOP.Name, CHANNEL_STOP);
            operationMap.Add(CHANNEL_HALT.Name, CHANNEL_HALT);
            operationMap.Add(CHANNEL_PAUSE.Name, CHANNEL_PAUSE);
            operationMap.Add(CHANNEL_RESUME.Name, CHANNEL_RESUME);
            operationMap.Add(CHANNEL_START_CONNECTOR.Name, CHANNEL_START_CONNECTOR);
            operationMap.Add(CHANNEL_STOP_CONNECTOR.Name, CHANNEL_STOP_CONNECTOR);
            operationMap.Add(CHANNEL_GET_STATUS.Name, CHANNEL_GET_STATUS);
            operationMap.Add(CODE_TEMPLATE_GET.Name, CODE_TEMPLATE_GET);
            operationMap.Add(CODE_TEMPLATE_UPDATE.Name, CODE_TEMPLATE_UPDATE);
            operationMap.Add(CODE_TEMPLATE_REMOVE.Name, CODE_TEMPLATE_REMOVE);
            operationMap.Add(GLOBAL_SCRIPT_GET.Name, GLOBAL_SCRIPT_GET);
            operationMap.Add(GLOBAL_SCRIPT_SET.Name, GLOBAL_SCRIPT_SET);
            operationMap.Add(CONFIGURATION_CHARSET_ENCODINGS_GET.Name, CONFIGURATION_CHARSET_ENCODINGS_GET);
            operationMap.Add(CONFIGURATION_SERVER_SETTINGS_GET.Name, CONFIGURATION_SERVER_SETTINGS_GET);
            operationMap.Add(CONFIGURATION_SERVER_SETTINGS_SET.Name, CONFIGURATION_SERVER_SETTINGS_SET);
            operationMap.Add(CONFIGURATION_UPDATE_SETTINGS_GET.Name, CONFIGURATION_UPDATE_SETTINGS_GET);
            operationMap.Add(CONFIGURATION_UPDATE_SETTINGS_SET.Name, CONFIGURATION_UPDATE_SETTINGS_SET);
            operationMap.Add(CONFIGURATION_ENCRYPTION_SETTINGS_GET.Name, CONFIGURATION_ENCRYPTION_SETTINGS_GET);
            operationMap.Add(CONFIGURATION_GUID_GET.Name, CONFIGURATION_GUID_GET);
            operationMap.Add(CONFIGURATION_DATABASE_DRIVERS_GET.Name, CONFIGURATION_DATABASE_DRIVERS_GET);
            operationMap.Add(CONFIGURATION_VERSION_GET.Name, CONFIGURATION_VERSION_GET);
            operationMap.Add(CONFIGURATION_BUILD_DATE_GET.Name, CONFIGURATION_BUILD_DATE_GET);
            operationMap.Add(SERVER_CONFIGURATION_GET.Name, SERVER_CONFIGURATION_GET);
            operationMap.Add(SERVER_CONFIGURATION_SET.Name, SERVER_CONFIGURATION_SET);
            operationMap.Add(CONFIGURATION_SERVER_ID_GET.Name, CONFIGURATION_SERVER_ID_GET);
            operationMap.Add(CONFIGURATION_SERVER_TIMEZONE_GET.Name, CONFIGURATION_SERVER_TIMEZONE_GET);
            operationMap.Add(CONFIGURATION_PASSWORD_REQUIREMENTS_GET.Name, CONFIGURATION_PASSWORD_REQUIREMENTS_GET);
            operationMap.Add(CONFIGURATION_STATUS_GET.Name, CONFIGURATION_STATUS_GET);
            operationMap.Add(CHANNEL_DEPLOY.Name, CHANNEL_DEPLOY);
            operationMap.Add(CHANNEL_REDEPLOY.Name, CHANNEL_REDEPLOY);
            operationMap.Add(CHANNEL_UNDEPLOY.Name, CHANNEL_UNDEPLOY);
            operationMap.Add(PLUGIN_PROPERTIES_GET.Name, PLUGIN_PROPERTIES_GET);
            operationMap.Add(PLUGIN_PROPERTIES_SET.Name, PLUGIN_PROPERTIES_SET);
            operationMap.Add(PLUGIN_METADATA_GET.Name, PLUGIN_METADATA_GET);
            operationMap.Add(CONNECTOR_METADATA_GET.Name, CONNECTOR_METADATA_GET);
            operationMap.Add(PLUGIN_SERVICE_INVOKE.Name, PLUGIN_SERVICE_INVOKE);
            operationMap.Add(CONNECTOR_SERVICE_INVOKE.Name, CONNECTOR_SERVICE_INVOKE);
            operationMap.Add(EXTENSION_INSTALL.Name, EXTENSION_INSTALL);
            operationMap.Add(EXTENSION_UNINSTALL.Name, EXTENSION_UNINSTALL);
            operationMap.Add(EXTENSION_IS_ENABLED.Name, EXTENSION_IS_ENABLED);
            operationMap.Add(EXTENSION_SET_ENABLED.Name, EXTENSION_SET_ENABLED);
            operationMap.Add(MESSAGE_GET_MAX_ID.Name, MESSAGE_GET_MAX_ID);
            operationMap.Add(MESSAGE_GET.Name, MESSAGE_GET);
            operationMap.Add(MESSAGE_GET_COUNT.Name, MESSAGE_GET_COUNT);
            operationMap.Add(MESSAGE_GET_CONTENT.Name, MESSAGE_GET_CONTENT);
            operationMap.Add(MESSAGE_REMOVE.Name, MESSAGE_REMOVE);
            operationMap.Add(MESSAGE_CLEAR.Name, MESSAGE_CLEAR);
            operationMap.Add(MESSAGE_PROCESS.Name, MESSAGE_PROCESS);
            operationMap.Add(MESSAGE_REPROCESS.Name, MESSAGE_REPROCESS);
            operationMap.Add(MESSAGE_IMPORT.Name, MESSAGE_IMPORT);
            operationMap.Add(MESSAGE_IMPORT_SERVER.Name, MESSAGE_IMPORT_SERVER);
            operationMap.Add(MESSAGE_EXPORT.Name, MESSAGE_EXPORT);
            operationMap.Add(MESSAGE_ATTACHMENT_GET.Name, MESSAGE_ATTACHMENT_GET);
            operationMap.Add(MESSAGE_ATTACHMENT_GET_BY_MESSAGE_ID.Name, MESSAGE_ATTACHMENT_GET_BY_MESSAGE_ID);
            operationMap.Add(MESSAGE_ATTACHMENT_GET_ID_BY_MESSAGE_ID.Name, MESSAGE_ATTACHMENT_GET_ID_BY_MESSAGE_ID);
            operationMap.Add(MESSAGE_DICOM_MESSAGE_GET.Name, MESSAGE_DICOM_MESSAGE_GET);
            operationMap.Add(EVENT_GET_MAX_ID.Name, EVENT_GET_MAX_ID);
            operationMap.Add(EVENT_GET.Name, EVENT_GET);
            operationMap.Add(EVENT_GET_COUNT.Name, EVENT_GET_COUNT);
            operationMap.Add(EVENT_EXPORT_ALL.Name, EVENT_EXPORT_ALL);
            operationMap.Add(EVENT_REMOVE_ALL.Name, EVENT_REMOVE_ALL);
            operationMap.Add(EVENT_EXPORT_AND_REMOVE_ALL.Name, EVENT_EXPORT_AND_REMOVE_ALL);
            operationMap.Add(USER_GET.Name, USER_GET);
            operationMap.Add(USER_UPDATE.Name, USER_UPDATE);
            operationMap.Add(USER_CHECK_OR_UPDATE_PASSWORD.Name, USER_CHECK_OR_UPDATE_PASSWORD);
            operationMap.Add(USER_REMOVE.Name, USER_REMOVE);
            operationMap.Add(USER_LOGIN.Name, USER_LOGIN);
            operationMap.Add(USER_LOGOUT.Name, USER_LOGOUT);
            operationMap.Add(USER_IS_USER_LOGGED_IN.Name, USER_IS_USER_LOGGED_IN);
            operationMap.Add(USER_PREFERENCES_GET.Name, USER_PREFERENCES_GET);
            operationMap.Add(USER_PREFERENCES_SET.Name, USER_PREFERENCES_SET);
        }

        public static void AddOperation(Operation operation)
        {
            operationMap.Add(operation.Name, operation);
        }

        public static Operation GetOperation(String operationName)
        {
            return operationMap[operationName];
        }
    }
}
