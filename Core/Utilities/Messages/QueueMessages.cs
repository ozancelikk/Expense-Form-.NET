using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Messages
{
   public static class QueueMessages
    {
        public static string ANewQueueCreated = "Yeni bir kuyruk eklendi";

        public static string AnQueueDeleted = "Bir kuyruk silindi";

        public static string AMessageQueuePurged = "Bir mesaj kuyruğu temizlendi";

        public static string BindingProcessCompleted = "Bind işlemi tamamlandı";

        public static string ANewExchangeDeclared = "Yeni bir exchange tanımlandı";
        public static string UnBindingProcessCompleted = "Unbind işlemi başarı ile tamamlandı";
    }
}
