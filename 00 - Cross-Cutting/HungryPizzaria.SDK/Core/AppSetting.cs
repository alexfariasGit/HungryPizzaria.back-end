using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizzaria.SDK.Core
{
    public class AppSetting
    {
        public string Host { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string AliasEmail { get; set; }
        public int Port { get; set; }
        public string ApiKeySenderGrid { get; set; }
        public string FCMPushNotificationKey { get; set; }
        public string BLOB_StorageAccountName { get; set; }
        public string BLOB_StorageAccountKey { get; set; }
        public string BLOB_ContainerName_PhotosProfile { get; set; }
        public string BLOB_ContainerName_Operation { get; set; }
        public string BLOB_CaminhoDiretorio_PhotosProfile { get; set; }
    }
}
