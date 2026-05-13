using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Entities.EventSystem
{

    public enum OutboxTargetType
    {
        Operation = 1,
        Event = 2
    }
    public class OutboxMessage : BaseEntity
    {
        // نوع العملية (مثال: UpsertPermissionCommand)
        public string Type { get; private set; } = string.Empty;

        // البيانات الفعلية للعملية محفوظة كـ JSON
        public string Content { get; private set; } = string.Empty;

        public OutboxTargetType TargetType { get; set; }
        // متى حدثت هذه العملية؟
        public DateTime OccurredOnUtc { get; private set; }

        // متى تمت معالجتها في الخلفية؟ (تكون null إذا لم تُعالج بعد)
        public DateTime? ProcessedOnUtc { get; private set; }

        // تسجيل أي خطأ يحدث أثناء المعالجة في الخلفية (مفيد جداً للتتبع)
        public string? Error { get; private set; }
        public int RetryCount { get; set; }                 // عدد محاولات إعادة الإرسال
        public bool Processed { get; private set; } = false;             // هل تمت معالجته؟
        public bool IsFromDomain { get; private set; } = false;             // هل تمت معالجته؟

        // معرف المستخدم الذي قام بالعملية
        public Guid UserId { get; private set; }
        public string UserEmail { get; private set; } = " ";

        // مشيد للـ EF Core
        private OutboxMessage() { }

        // المشيد الاحترافي للإنشاء
        public OutboxMessage(string type, string content, OutboxTargetType targetType, Guid userId, string? userEmail, bool isFromDomain)
        {
            Id = Guid.NewGuid();
            Type = type;
            Content = content;
            OccurredOnUtc = DateTime.UtcNow;
            TargetType = targetType;
            UserId = userId;
            UserEmail = userEmail;
            IsFromDomain = isFromDomain;
        }
        public void SetError(string errorMessage)
        {
            this.Error = errorMessage;
            // يمكنك هنا أيضاً زيادة عدد المحاولات إذا أردت
            // this.RetryCount++; 
        }
        public void MarkAsProcessed()
        {
            Processed = true;
            ProcessedOnUtc = DateTime.UtcNow;
            Error = null;
        }
        public void MarkAsFailed(string error)
        {
            RetryCount++;
            Error = error;
            ProcessedOnUtc = DateTime.UtcNow; // نعتبرها عولجت ولكن بفشل، أو يمكن تركها null لإعادة المحاولة (Retry)
        }
    }
}