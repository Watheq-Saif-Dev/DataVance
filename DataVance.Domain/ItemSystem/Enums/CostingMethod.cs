namespace DataVance.Domain.ItemSystem.Enums
{
    public enum CostingMethod
    {
        FIFO = 1,         // الوارد أولاً يصرف أولاً
        WeightedAverage = 2, // المتوسط المرجح (الأكثر شيوعاً)
        StandardCost = 3  // التكلفة المعيارية
    }
}
