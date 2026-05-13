namespace DataVance.Domain.Finance.Shared.Enums
{
    public enum JournalStatus
    {
        Draft = 1,       // مسودة: يمكن التعديل والحذف
        Approved = 2,    // معتمد: جاهز للترحيل، لا يمكن حذفه، يمكن فك اعتماده
        Posted = 3,      // مرحل: أثّر على الأرصدة، لا يمكن تعديله أو حذفه نهائياً
        Reversed = 4     // معكوس: تم إلغاء أثره بقيد عكسي
    }
}
